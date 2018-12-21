using Framework.DataProvider;
using Framework.Transformation;
using System.Collections.Generic;

namespace Library.DataModels.Transform
{
    /// <summary>
    /// A sample transform of state data to keyed data.
    /// </summary>
    public class StateLookupDataKeyValuePairTransform : TransformerBase<StateLookupData, KeyValuePair<string, StateLookupData>>
    {
        public override KeyValuePair<string, StateLookupData> TransformInternal(StateLookupData source)
            => new KeyValuePair<string, StateLookupData>(source.Name, source);
    }
}
