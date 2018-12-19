using System.Collections.Generic;
using System.Linq;
using Framework.Transformation;

namespace Library.DataModels.Transform
{
    public class YesNoLookupDataTransformer : TransformerBase<LookupData, YesNoLookupData>
    {
        public override YesNoLookupData Transform(LookupData source)
            => new YesNoLookupData { Key = source.Name, Value = source.Value };

        public override IEnumerable<YesNoLookupData> Transform(IEnumerable<LookupData> source)
            => base.Transform(source.Where(item => item.Category == "YesNo"));
    }
}
