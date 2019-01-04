using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidateTransformDerive.Framework.DataProvider
{
    public abstract class KeyValueBase<TKey, TValue> : IProvideKeyValue<TKey, TValue>
    {
        protected abstract TKey KeyInternal { get; }

        protected abstract TValue ValueInternal { get; }

        TKey IProvideKey<TKey>.Key => KeyInternal;

        TValue IProvideValue<TValue>.Value => ValueInternal;

        object IProvideKey.GetKey() => KeyInternal;

        object IProvideValue.GetValue() => ValueInternal;
    }
}
