using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;

namespace Framework.Derivation
{
    internal class DerivationAttributeStore
    {
        private Dictionary<Type, TypeStoreItem> TypeStoreItems = new Dictionary<Type, TypeStoreItem>();

        internal static DerivationAttributeStore Instance { get; } = new DerivationAttributeStore();

        internal IEnumerable<DerivationAttribute> GetTypeDerivationAttributes(DerivationContext derivationContext)
        {
            EnsureDerivationContext(derivationContext);
            TypeStoreItem item = GetTypeStoreItem(derivationContext.ObjectType);
            return item.DerivationAttributes;
        }

        internal IEnumerable<DerivationAttribute> GetPropertyDerivationAttributes(DerivationContext derivationContext)
        {
            EnsureDerivationContext(derivationContext);
            TypeStoreItem typeItem = GetTypeStoreItem(derivationContext.ObjectType);
            PropertyStoreItem item = typeItem.GetPropertyStoreItem(derivationContext.MemberName);
            return item.DerivationAttributes;
        }

        internal Type GetPropertyType(DerivationContext derivationContext)
        {
            EnsureDerivationContext(derivationContext);
            TypeStoreItem typeItem = GetTypeStoreItem(derivationContext.ObjectType);
            PropertyStoreItem item = typeItem.GetPropertyStoreItem(derivationContext.MemberName);
            return item.PropertyType;
        }

        internal bool IsPropertyContext(DerivationContext derivationContext)
        {
            EnsureDerivationContext(derivationContext);
            TypeStoreItem typeItem = GetTypeStoreItem(derivationContext.ObjectType);
            PropertyStoreItem item = null;
            return typeItem.TryGetPropertyStoreItem(derivationContext.MemberName, out item);
        }

        private TypeStoreItem GetTypeStoreItem(Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            lock (TypeStoreItems)
            {
                TypeStoreItem item = null;
                if (!TypeStoreItems.TryGetValue(type, out item))
                {
                    IEnumerable<Attribute> attributes = TypeDescriptor.GetAttributes(type).Cast<Attribute>();
                    item = new TypeStoreItem(type, attributes);
                    TypeStoreItems[type] = item;
                }
                return item;
            }
        }

        private static void EnsureDerivationContext(DerivationContext derivationContext)
        {
            if (derivationContext == null)
            {
                throw new ArgumentNullException(nameof(derivationContext));
            }
        }

        private abstract class StoreItem
        {
            internal StoreItem(IEnumerable<Attribute> attributes)
            {
                DerivationAttributes = attributes.OfType<DerivationAttribute>() ?? Enumerable.Empty<DerivationAttribute>();
            }

            internal IEnumerable<DerivationAttribute> DerivationAttributes { get; private set; }
        }

        private class TypeStoreItem : StoreItem
        {
            private object SyncRoot = new object();
            private Type Type;
            private Dictionary<string, PropertyStoreItem> PropertyStoreItems;

            internal TypeStoreItem(Type type, IEnumerable<Attribute> attributes)
                : base(attributes)
            {
                Type = type;
            }

            internal PropertyStoreItem GetPropertyStoreItem(string propertyName)
            {
                PropertyStoreItem item = null;
                if (!TryGetPropertyStoreItem(propertyName, out item))
                {
                    throw new ArgumentException(String.Format(CultureInfo.CurrentCulture, "The type '{0}' does not contain a public property named '{1}'.", Type.Name, propertyName), nameof(propertyName));
                }
                return item;
            }

            internal bool TryGetPropertyStoreItem(string propertyName, out PropertyStoreItem item)
            {
                if (string.IsNullOrEmpty(propertyName))
                {
                    throw new ArgumentNullException(nameof(propertyName));
                }

                if (PropertyStoreItems == null)
                {
                    lock (SyncRoot)
                    {
                        if (PropertyStoreItems == null)
                        {
                            PropertyStoreItems = CreatePropertyStoreItems();
                        }
                    }
                }
                if (!PropertyStoreItems.TryGetValue(propertyName, out item))
                {
                    return false;
                }
                return true;
            }

            private Dictionary<string, PropertyStoreItem> CreatePropertyStoreItems()
            {
                Dictionary<string, PropertyStoreItem> propertyStoreItems = new Dictionary<string, PropertyStoreItem>();

                PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(Type);
                foreach (PropertyDescriptor property in properties)
                {
                    PropertyStoreItem item = new PropertyStoreItem(property.PropertyType, GetExplicitAttributes(property).Cast<Attribute>());
                    propertyStoreItems[property.Name] = item;
                }

                return propertyStoreItems;
            }

            public static AttributeCollection GetExplicitAttributes(PropertyDescriptor propertyDescriptor)
            {
                List<Attribute> attributes = new List<Attribute>(propertyDescriptor.Attributes.Cast<Attribute>());
                IEnumerable<Attribute> typeAttributes = TypeDescriptor.GetAttributes(propertyDescriptor.PropertyType).Cast<Attribute>();
                bool removedAttribute = false;
                foreach (Attribute attr in typeAttributes)
                {
                    for (int i = attributes.Count - 1; i >= 0; --i)
                    {
                        if (object.ReferenceEquals(attr, attributes[i]))
                        {
                            attributes.RemoveAt(i);
                            removedAttribute = true;
                        }
                    }
                }
                return removedAttribute ? new AttributeCollection(attributes.ToArray()) : propertyDescriptor.Attributes;
            }
        }

        private class PropertyStoreItem : StoreItem
        {
            internal PropertyStoreItem(Type propertyType, IEnumerable<Attribute> attributes) : base(attributes)
                => PropertyType = propertyType;

            internal Type PropertyType { get; private set; }
        }
    }
}
