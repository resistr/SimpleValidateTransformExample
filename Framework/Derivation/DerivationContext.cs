using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Globalization;

namespace Framework.Derivation
{
    /// <summary>
    /// Describes the context in which a derivation is performed.
    /// </summary>
    public sealed class DerivationContext : IServiceProvider
    {
        private Func<Type, object> ServiceProvider;
        private string _displayName;

        /// <summary>
        /// Initializes a new instance of the Framework.Derivation.DerivationContext
        /// class using the specified object instance.
        /// </summary>
        /// <param name="instance">The object instance to derive. It cannot be null.</param>
        /// <exception cref="ArgumentNullException">If instance is not provided.</exception>
        public DerivationContext(object instance) : this(instance, null, null) { }

        /// <summary>
        /// Initializes a new instance of the Framework.Derivation.DerivationContext
        /// class using the specified object and an optional property bag.
        /// </summary>
        /// <param name="instance">The object instance to derive. It cannot be null.</param>
        /// <param name="items">An optional set of key/value pairs to make available to consumers.</param>
        /// <exception cref="ArgumentNullException">If instance is not provided.</exception>
        public DerivationContext(object instance, IDictionary<object, object> items) : this(instance, null, items) { }

        /// <summary>
        /// Initializes a new instance of the Framework.Derivation.DerivationContext
        /// class using the service provider and dictionary of service consumers.
        /// </summary>
        /// <param name="instance">The object to derive. This parameter is required.</param>
        /// <param name="serviceProvider">
        /// The object that implements the System.IServiceProvider interface.
        /// This parameter is optional.
        /// </param>
        /// <param name="items">
        /// A dictionary of key/value pairs to make available to the service consumers.
        /// This parameter is optional.
        /// </param>
        /// <exception cref="ArgumentNullException">If instance is not provided.</exception>
        public DerivationContext(object instance, IServiceProvider serviceProvider, IDictionary<object, object> items)
        {
            ObjectInstance = instance ?? throw new ArgumentNullException(nameof(instance));

            if (serviceProvider != null)
            {
                InitializeServiceProvider(serviceType => serviceProvider.GetService(serviceType));
            }

            IServiceContainer container = serviceProvider as IServiceContainer;

            if (container != null)
            {
                _serviceContainer = new DerivationContextServiceContainer(container);
            }
            else
            {
                _serviceContainer = new DerivationContextServiceContainer();
            }

            if (items != null)
            {
                Items = new Dictionary<object, object>(items);
            }
            else
            {
                Items = new Dictionary<object, object>();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public object ObjectInstance { get; private set; }

        public Type ObjectType
        {
            get
            {
                return ObjectInstance.GetType();
            }
        }

        public string DisplayName
        {
            get
            {
                if (string.IsNullOrEmpty(_displayName))
                {
                    if (string.IsNullOrEmpty(_displayName))
                    {
                        _displayName = MemberName;

                        if (string.IsNullOrEmpty(_displayName))
                        {
                            _displayName = ObjectType.Name;
                        }
                    }
                }
                return _displayName;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(nameof(value));
                }
                _displayName = value;
            }
        }

        public string MemberName { get; set; }

        public IDictionary<object, object> Items { get; private set; }

        public void InitializeServiceProvider(Func<Type, object> serviceProvider)
        {
            ServiceProvider = serviceProvider;
        }

        public object GetService(Type serviceType)
        {
            object service = null;

            if (_serviceContainer != null)
            {
                service = _serviceContainer.GetService(serviceType);
            }

            if (service == null && ServiceProvider != null)
            {
                service = ServiceProvider(serviceType);
            }

            return service;
        }

        private IServiceContainer _serviceContainer;

        public IServiceContainer ServiceContainer
        {
            get
            {
                if (_serviceContainer == null)
                {
                    _serviceContainer = new DerivationContextServiceContainer();
                }

                return _serviceContainer;
            }
        }

        private class DerivationContextServiceContainer : IServiceContainer
        {

            private IServiceContainer ParentContainer;
            private Dictionary<Type, object> Services = new Dictionary<Type, object>();
            private readonly object Lock = new object();

            internal DerivationContextServiceContainer()
            {
            }

            internal DerivationContextServiceContainer(IServiceContainer parentContainer)
            {
                ParentContainer = parentContainer;
            }

            public void AddService(Type serviceType, ServiceCreatorCallback callback, bool promote)
            {
                if (promote && ParentContainer != null)
                {
                    ParentContainer.AddService(serviceType, callback, promote);
                }
                else
                {
                    lock (Lock)
                    {
                        if (Services.ContainsKey(serviceType))
                        {
                            throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "A service of type '{0}' already exists in the container.", serviceType), nameof(serviceType));
                        }

                        Services.Add(serviceType, callback);
                    }
                }
            }

            public void AddService(Type serviceType, ServiceCreatorCallback callback)
            {
                AddService(serviceType, callback, true);
            }

            public void AddService(Type serviceType, object serviceInstance, bool promote)
            {
                if (promote && ParentContainer != null)
                {
                    ParentContainer.AddService(serviceType, serviceInstance, promote);
                }
                else
                {
                    lock (Lock)
                    {
                        if (Services.ContainsKey(serviceType))
                        {
                            throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "A service of type '{0}' already exists in the container.", serviceType), nameof(serviceType));
                        }

                        Services.Add(serviceType, serviceInstance);
                    }
                }
            }

            public void AddService(Type serviceType, object serviceInstance)
            {
                AddService(serviceType, serviceInstance, true);
            }

            public void RemoveService(Type serviceType, bool promote)
            {
                lock (Lock)
                {
                    if (Services.ContainsKey(serviceType))
                    {
                        Services.Remove(serviceType);
                    }
                }

                if (promote && ParentContainer != null)
                {
                    ParentContainer.RemoveService(serviceType);
                }
            }

            public void RemoveService(Type serviceType)
            {
                RemoveService(serviceType, true);
            }

            public object GetService(Type serviceType)
            {
                if (serviceType == null)
                {
                    throw new ArgumentNullException(nameof(serviceType));
                }

                object service = null;
                Services.TryGetValue(serviceType, out service);

                if (service == null && ParentContainer != null)
                {
                    service = ParentContainer.GetService(serviceType);
                }

                ServiceCreatorCallback callback = service as ServiceCreatorCallback;

                if (callback != null)
                {
                    service = callback(this, serviceType);
                }

                return service;
            }
        }
    }
}
