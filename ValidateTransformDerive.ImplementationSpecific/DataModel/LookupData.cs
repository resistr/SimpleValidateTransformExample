using ValidateTransformDerive.Framework.DataProvider;

namespace ValidateTransformDerive.ImplementationSpecific.DataModel
{
    /// <summary>
    /// A sample base for external data; 
    /// </summary>
    public class LookupData : IProvideKey<string>, IProvideValue<string>
    {
        public int Key { get; set; }

        public string Category { get; set; }

        public string Name { get; set; }

        public string Value { get; set; }

        string IProvideKey<string>.Key => Name;

        public object GetKey()
            => Key;

        public object GetValue()
            => Value;
    }
}
