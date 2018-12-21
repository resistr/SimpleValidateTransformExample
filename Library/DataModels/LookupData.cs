using Framework.DataProvider;

namespace Library.DataModels
{
    /// <summary>
    /// A sample base for external data; 
    /// </summary>
    public class LookupData : IProvideValue
    {
        public int Key { get; set; }

        public string Category { get; set; }

        public string Name { get; set; }

        public string Value { get; set; }

        public object GetValue()
            => Value;
    }
}
