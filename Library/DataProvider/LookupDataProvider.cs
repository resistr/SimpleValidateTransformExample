using Framework.DataProvider;
using Library.DataModels;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Library.DataProvider
{
    public class LookupDataProvider : IProvideData<LookupData>
    {
        public Task<IEnumerable<LookupData>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            // get from DB :)

            IEnumerable<LookupData> data = new[]
            {
                new LookupData { Category = "YesNo", Key = 1, Name = "Yes", Value = bool.TrueString },
                new LookupData { Category = "YesNo", Key = 2, Name = "No", Value = bool.FalseString },
                new LookupData { Category = "US State", Key = 3, Name = "Alabama", Value = "AL" },
                new LookupData { Category = "US State", Key = 4, Name = "Alaska", Value = "AK" },
                new LookupData { Category = "US State", Key = 6, Name = "Arizona", Value = "AZ" },
                new LookupData { Category = "US State", Key = 7, Name = "Arkansas", Value = "AR" },
                new LookupData { Category = "US State", Key = 8, Name = "California", Value = "CA" },
                new LookupData { Category = "US State", Key = 10, Name = "Colorado", Value = "CO" },
                new LookupData { Category = "US State", Key = 11, Name = "Connecticut", Value = "CT" },
                new LookupData { Category = "US State", Key = 12, Name = "Delaware", Value = "DE" },
                new LookupData { Category = "US State", Key = 13, Name = "District of Columbia", Value = "DC" },
                new LookupData { Category = "US State", Key = 14, Name = "Florida", Value = "FL" },
                new LookupData { Category = "US State", Key = 15, Name = "Georgia", Value = "GA" },
                new LookupData { Category = "US State", Key = 17, Name = "Hawaii", Value = "HI" },
                new LookupData { Category = "US State", Key = 18, Name = "Idaho", Value = "ID" },
                new LookupData { Category = "US State", Key = 19, Name = "Illinois", Value = "IL" },
                new LookupData { Category = "US State", Key = 20, Name = "Indiana", Value = "IN" },
                new LookupData { Category = "US State", Key = 21, Name = "Iowa", Value = "IA" },
                new LookupData { Category = "US State", Key = 22, Name = "Kansas", Value = "KS" },
                new LookupData { Category = "US State", Key = 23, Name = "Kentucky", Value = "KY" },
                new LookupData { Category = "US State", Key = 24, Name = "Louisiana", Value = "LA" },
                new LookupData { Category = "US State", Key = 25, Name = "Maine", Value = "ME" },
                new LookupData { Category = "US State", Key = 26, Name = "Maryland", Value = "MD" },
                new LookupData { Category = "US State", Key = 27, Name = "Massachusetts", Value = "MA" },
                new LookupData { Category = "US State", Key = 28, Name = "Michigan", Value = "MI" },
                new LookupData { Category = "US State", Key = 29, Name = "Minnesota", Value = "MN" },
                new LookupData { Category = "US State", Key = 30, Name = "Mississippi", Value = "MS" },
                new LookupData { Category = "US State", Key = 31, Name = "Missouri", Value = "MO" },
                new LookupData { Category = "US State", Key = 32, Name = "Montana", Value = "MT" },
                new LookupData { Category = "US State", Key = 33, Name = "Nebraska", Value = "NE" },
                new LookupData { Category = "US State", Key = 34, Name = "Nevada", Value = "NV" },
                new LookupData { Category = "US State", Key = 35, Name = "New Hampshire", Value = "NH" },
                new LookupData { Category = "US State", Key = 36, Name = "New Jersey", Value = "NJ" },
                new LookupData { Category = "US State", Key = 37, Name = "New Mexico", Value = "NM" },
                new LookupData { Category = "US State", Key = 38, Name = "New York", Value = "NY" },
                new LookupData { Category = "US State", Key = 39, Name = "North Carolina", Value = "NC" },
                new LookupData { Category = "US State", Key = 40, Name = "North Dakota", Value = "ND" },
                new LookupData { Category = "US State", Key = 41, Name = "Ohio", Value = "OH" },
                new LookupData { Category = "US State", Key = 42, Name = "Oklahoma", Value = "OK" },
                new LookupData { Category = "US State", Key = 43, Name = "Oregon", Value = "OR" },
                new LookupData { Category = "US State", Key = 44, Name = "Pennsylvania", Value = "PA" },
                new LookupData { Category = "US State", Key = 46, Name = "Rhode Island", Value = "RI" },
                new LookupData { Category = "US State", Key = 47, Name = "South Carolina", Value = "SC" },
                new LookupData { Category = "US State", Key = 48, Name = "South Dakota", Value = "SD" },
                new LookupData { Category = "US State", Key = 49, Name = "Tennessee", Value = "TN" },
                new LookupData { Category = "US State", Key = 50, Name = "Texas", Value = "TX" },
                new LookupData { Category = "US State", Key = 51, Name = "Utah", Value = "UT" },
                new LookupData { Category = "US State", Key = 52, Name = "Vermont", Value = "VT" },
                new LookupData { Category = "US State", Key = 53, Name = "Virginia", Value = "VA" },
                new LookupData { Category = "US State", Key = 55, Name = "Washington", Value = "WA" },
                new LookupData { Category = "US State", Key = 56, Name = "West Virginia", Value = "WV" },
                new LookupData { Category = "US State", Key = 57, Name = "Wisconsin", Value = "WI" },
                new LookupData { Category = "US State", Key = 58, Name = "Wyoming", Value = "WY" },
                new LookupData { Category = "US State", Key = 62, Name = "American Samoa", Value = "AS" },
                new LookupData { Category = "US State", Key = 68, Name = "Guam", Value = "GU" },
                new LookupData { Category = "US State", Key = 71, Name = "Northern Mariana Islands", Value = "MP" },
                new LookupData { Category = "US State", Key = 74, Name = "Puerto Rico", Value = "PR" },
                new LookupData { Category = "US State", Key = 80, Name = "U.S. Virgin Islands", Value = "VI" }
            };

            return Task.FromResult(data);
        }
    }
}
