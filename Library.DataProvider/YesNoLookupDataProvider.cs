using Framework.DataProvider;
using Library.DataModel;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Library.DataProvider
{
    /// <summary>
    /// An example data provider of simple yes no data. 
    /// </summary>
    public class YesNoLookupDataProvider : IProvideData<YesNoLookupData>
    {
        public Task<IEnumerable<YesNoLookupData>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            // get from DB :)

            IEnumerable<YesNoLookupData> data = new[]
            {
                new YesNoLookupData { Category = "YesNo", Key = 1, Name = "Yes", Value = bool.TrueString },
                new YesNoLookupData { Category = "YesNo", Key = 2, Name = "No", Value = bool.FalseString }
            };

            return Task.FromResult(data);
        }
    }
}
