using Framework.DataProvider;
using Library.DataModel;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Library.DataProvider
{
    /// <summary>
    /// A sample data provider of state specific data.
    /// </summary>
    public class StateLookupDataProvider : IProvideData<StateLookupData>
    {
        public Task<IEnumerable<StateLookupData>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            // get from DB :)

            IEnumerable<StateLookupData> data = new[]
            {
                new StateLookupData { Category = "US State", Key = 3, Name = "Alabama", Value = "AL" },
                new StateLookupData { Category = "US State", Key = 4, Name = "Alaska", Value = "AK" },
                new StateLookupData { Category = "US State", Key = 6, Name = "Arizona", Value = "AZ" },
                new StateLookupData { Category = "US State", Key = 7, Name = "Arkansas", Value = "AR" },
                new StateLookupData { Category = "US State", Key = 8, Name = "California", Value = "CA" },
                new StateLookupData { Category = "US State", Key = 10, Name = "Colorado", Value = "CO" },
                new StateLookupData { Category = "US State", Key = 11, Name = "Connecticut", Value = "CT" },
                new StateLookupData { Category = "US State", Key = 12, Name = "Delaware", Value = "DE" },
                new StateLookupData { Category = "US State", Key = 13, Name = "District of Columbia", Value = "DC" },
                new StateLookupData { Category = "US State", Key = 14, Name = "Florida", Value = "FL" },
                new StateLookupData { Category = "US State", Key = 15, Name = "Georgia", Value = "GA" },
                new StateLookupData { Category = "US State", Key = 17, Name = "Hawaii", Value = "HI" },
                new StateLookupData { Category = "US State", Key = 18, Name = "Idaho", Value = "ID" },
                new StateLookupData { Category = "US State", Key = 19, Name = "Illinois", Value = "IL" },
                new StateLookupData { Category = "US State", Key = 20, Name = "Indiana", Value = "IN" },
                new StateLookupData { Category = "US State", Key = 21, Name = "Iowa", Value = "IA" },
                new StateLookupData { Category = "US State", Key = 22, Name = "Kansas", Value = "KS" },
                new StateLookupData { Category = "US State", Key = 23, Name = "Kentucky", Value = "KY" },
                new StateLookupData { Category = "US State", Key = 24, Name = "Louisiana", Value = "LA" },
                new StateLookupData { Category = "US State", Key = 25, Name = "Maine", Value = "ME" },
                new StateLookupData { Category = "US State", Key = 26, Name = "Maryland", Value = "MD" },
                new StateLookupData { Category = "US State", Key = 27, Name = "Massachusetts", Value = "MA" },
                new StateLookupData { Category = "US State", Key = 28, Name = "Michigan", Value = "MI" },
                new StateLookupData { Category = "US State", Key = 29, Name = "Minnesota", Value = "MN" },
                new StateLookupData { Category = "US State", Key = 30, Name = "Mississippi", Value = "MS" },
                new StateLookupData { Category = "US State", Key = 31, Name = "Missouri", Value = "MO" },
                new StateLookupData { Category = "US State", Key = 32, Name = "Montana", Value = "MT" },
                new StateLookupData { Category = "US State", Key = 33, Name = "Nebraska", Value = "NE" },
                new StateLookupData { Category = "US State", Key = 34, Name = "Nevada", Value = "NV" },
                new StateLookupData { Category = "US State", Key = 35, Name = "New Hampshire", Value = "NH" },
                new StateLookupData { Category = "US State", Key = 36, Name = "New Jersey", Value = "NJ" },
                new StateLookupData { Category = "US State", Key = 37, Name = "New Mexico", Value = "NM" },
                new StateLookupData { Category = "US State", Key = 38, Name = "New York", Value = "NY" },
                new StateLookupData { Category = "US State", Key = 39, Name = "North Carolina", Value = "NC" },
                new StateLookupData { Category = "US State", Key = 40, Name = "North Dakota", Value = "ND" },
                new StateLookupData { Category = "US State", Key = 41, Name = "Ohio", Value = "OH" },
                new StateLookupData { Category = "US State", Key = 42, Name = "Oklahoma", Value = "OK" },
                new StateLookupData { Category = "US State", Key = 43, Name = "Oregon", Value = "OR" },
                new StateLookupData { Category = "US State", Key = 44, Name = "Pennsylvania", Value = "PA" },
                new StateLookupData { Category = "US State", Key = 46, Name = "Rhode Island", Value = "RI" },
                new StateLookupData { Category = "US State", Key = 47, Name = "South Carolina", Value = "SC" },
                new StateLookupData { Category = "US State", Key = 48, Name = "South Dakota", Value = "SD" },
                new StateLookupData { Category = "US State", Key = 49, Name = "Tennessee", Value = "TN" },
                new StateLookupData { Category = "US State", Key = 50, Name = "Texas", Value = "TX" },
                new StateLookupData { Category = "US State", Key = 51, Name = "Utah", Value = "UT" },
                new StateLookupData { Category = "US State", Key = 52, Name = "Vermont", Value = "VT" },
                new StateLookupData { Category = "US State", Key = 53, Name = "Virginia", Value = "VA" },
                new StateLookupData { Category = "US State", Key = 55, Name = "Washington", Value = "WA" },
                new StateLookupData { Category = "US State", Key = 56, Name = "West Virginia", Value = "WV" },
                new StateLookupData { Category = "US State", Key = 57, Name = "Wisconsin", Value = "WI" },
                new StateLookupData { Category = "US State", Key = 58, Name = "Wyoming", Value = "WY" },
                new StateLookupData { Category = "US State", Key = 62, Name = "American Samoa", Value = "AS" },
                new StateLookupData { Category = "US State", Key = 68, Name = "Guam", Value = "GU" },
                new StateLookupData { Category = "US State", Key = 71, Name = "Northern Mariana Islands", Value = "MP" },
                new StateLookupData { Category = "US State", Key = 74, Name = "Puerto Rico", Value = "PR" },
                new StateLookupData { Category = "US State", Key = 80, Name = "U.S. Virgin Islands", Value = "VI" }
            };

            return Task.FromResult(data);
        }
    }
}
