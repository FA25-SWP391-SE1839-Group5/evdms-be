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
                new Dealer
                {
                    Id = Guid.Parse("30000000-0000-0000-0000-000000000002"),
                    Name = "Saigon Auto Hub",
                    Region = "Ho Chi Minh City",
                    Address = "200 Le Lai, District 1, Ho Chi Minh City",
                },
                new Dealer
                {
                    Id = Guid.Parse("30000000-0000-0000-0000-000000000003"),
                    Name = "Hanoi EV Center",
                    Region = "Hanoi",
                    Address = "50 Tran Hung Dao, Hoan Kiem, Hanoi",
                },
                new Dealer
                {
                    Id = Guid.Parse("30000000-0000-0000-0000-000000000004"),
                    Name = "Da Nang Green Motors",
                    Region = "Da Nang",
                    Address = "10 Bach Dang, Hai Chau, Da Nang",
                },
            ];
    }
}
