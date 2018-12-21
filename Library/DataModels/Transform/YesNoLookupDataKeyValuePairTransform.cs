using Framework.DataProvider;
using Framework.Transformation;
using System.Collections.Generic;

namespace Library.DataModels.Transform
{
    /// <summary>
    /// A sample transform of yes no data to keyed data.
    /// </summary>
    public class YesNoLookupDataKeyValuePairTransform : TransformerBase<YesNoLookupData, KeyValuePair<string, YesNoLookupData>>
    {
        public override KeyValuePair<string, YesNoLookupData> TransformInternal(YesNoLookupData source)
            => new KeyValuePair<string, YesNoLookupData>(source.Name, source);
    }
}
