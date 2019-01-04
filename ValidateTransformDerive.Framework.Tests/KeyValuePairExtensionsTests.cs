using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidateTransformDerive.Framework.DataProvider;

namespace ValidateTransformDerive.Framework.Tests
{
    [TestClass]
    public class KeyValuePairExtensionsTests
    {
        protected class TestData : IProvideKeyValue<string, string>
        {
            public string Key { get; set; }

            public object GetKey() => Key;

            public string Value { get; set; }

            public object GetValue() => Value;
        }

        protected readonly IEnumerable<TestData> Items = new HashSet<TestData>()
        {
            new TestData{Key = "Key1", Value = "Value1"},
            new TestData{Key = "Key2", Value = "Value2"},
        };

        [TestMethod]
        public void ToValueReadOnlyDictionaryTest()
        {
            var dictionary = Items.ToReadOnlyDictionary();
            Assert.IsInstanceOfType(dictionary, typeof(IDictionary<object, object>));
            Assert.AreEqual(Items.Count(), dictionary.Count());
            Assert.IsTrue(Items.All(itm => {
                dictionary.Single(dctItm => dctItm.Key == itm.GetKey() && dctItm.Value == itm.GetValue());
                return true;
            }));
            Assert.IsTrue(dictionary.All(dctItm => {
                Items.Single(itm => dctItm.Key == itm.GetKey() && dctItm.Value == itm.GetValue());
                return true;
            }));
        }

        [TestMethod]
        public void ToTypedReadOnlyDictionary()
        {
            var dictionary = Items.ToTypedReadOnlyDictionary();
            Assert.IsInstanceOfType(dictionary, typeof(IDictionary<string, string>));
            Assert.AreEqual(Items.Count(), dictionary.Count());
            Assert.IsTrue(Items.All(itm => {
                dictionary.Single(dctItm => dctItm.Key == itm.Key && dctItm.Value == itm.Value);
                return true;
            }));
            Assert.IsTrue(dictionary.All(dctItm => {
                Items.Single(itm => dctItm.Key == itm.Key && dctItm.Value == itm.Value);
                return true;
            }));
        }
    }
}
