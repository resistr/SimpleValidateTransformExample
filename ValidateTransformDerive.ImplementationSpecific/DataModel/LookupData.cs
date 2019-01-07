using ValidateTransformDerive.Framework;

namespace ValidateTransformDerive.ImplementationSpecific.DataModel
{
    /// <summary>
    /// A sample base for external data; 
    /// </summary>
    public class LookupData : KeyValueBase<string, string>
    {
        public int Key { get; set; }

        public string Category { get; set; }

        public string Name { get; set; }

        public string Value { get; set; }

        protected override string KeyInternal => Name;

        protected override string ValueInternal => Value;
    }
}
