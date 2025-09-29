using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EVDMS.DataAccessLayer.Entities;

namespace EVDMS.DataAccessLayer.Data.Seeds
{
    public class DealerSeed
    {
        public static List<Dealer> Dealers =>
            [
                new Dealer
                {
                    Id = Guid.Parse("30000000-0000-0000-0000-000000000001"),
                    Name = "EV Motors Saigon",
                    Region = "Ho Chi Minh City",
                    Address = "100 Nguyen Van Cu, District 1, Ho Chi Minh City",
                },
            ];
    }
}
