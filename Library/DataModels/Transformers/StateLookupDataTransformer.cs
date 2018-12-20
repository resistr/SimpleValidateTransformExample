using Framework.Transformation;
using System.Collections.Generic;
using System.Linq;

namespace Library.DataModels.Transform
{
    public class StateLookupDataTransformer : TransformerBase<LookupData, StateLookupData>
    {
        public override StateLookupData TransformInternal(LookupData source)
            => new StateLookupData { Key = source.Name, Value = source.Value };

        public override IEnumerable<StateLookupData> Transform(IEnumerable<LookupData> source)
            => base.Transform(source.Where(item => item.Category == "US State"));
    }
}
