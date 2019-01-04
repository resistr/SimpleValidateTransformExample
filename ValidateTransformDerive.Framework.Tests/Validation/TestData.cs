using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidateTransformDerive.Framework.DataProvider;

namespace ValidateTransformDerive.Framework.Tests.Validation
{
    public class TestData<T> { public T Value { get; set; } }

    public class TestKeyValueData<TKey, TValue> : KeyValueBase<TKey, TValue>
    {
        public TKey Key { get; set; }

        public TValue Value { get; set; }

        protected override TKey KeyInternal => Key;

        protected override TValue ValueInternal => Value;
    }

    public class TestDataValidator<T> : AbstractValidator<T>
    {
        public TestDataValidator(Action<TestDataValidator<T>> action)
            => action(this);
    }
}
