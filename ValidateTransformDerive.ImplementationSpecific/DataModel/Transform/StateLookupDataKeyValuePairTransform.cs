using System.Collections.Generic;
using ValidateTransformDerive.Framework.Transformation;

namespace ValidateTransformDerive.ImplementationSpecific.DataModel.Transform
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
