using EVDMS.DataAccessLayer.Entities;

namespace EVDMS.DataAccessLayer.Data.Seeds
{
    public static class CustomerSeed
    {
        public static List<Customer> Customers =>
            [
                new Customer
                {
                    Id = Guid.Parse("10000000-0000-0000-0000-000000000001"),
                    FullName = "Nguyễn Văn An",
                    Phone = "0901234567",
                    Email = "an.nguyen@email.com",
                    Address = "123 Lê Lợi, Quận 1, TP. Hồ Chí Minh",
                },
                new Customer
                {
                    Id = Guid.Parse("10000000-0000-0000-0000-000000000002"),
                    FullName = "Trần Thị Bích Ngọc",
                    Phone = "0912345678",
                    Email = "ngoc.tran@email.com",
                    Address = "456 Nguyễn Trãi, Quận 5, TP. Hồ Chí Minh",
                },
                new Customer
                {
                    Id = Guid.Parse("10000000-0000-0000-0000-000000000003"),
                    FullName = "Lê Minh Tuấn",
                    Phone = "0923456789",
                    Email = "tuan.le@email.com",
                    Address = "789 Cách Mạng Tháng 8, Quận 10, TP. Hồ Chí Minh",
                },
                new Customer
                {
                    Id = Guid.Parse("10000000-0000-0000-0000-000000000004"),
                    FullName = "Phạm Quang Huy",
                    Phone = "0934567890",
                    Email = "huy.pham@email.com",
                    Address = "321 Điện Biên Phủ, Quận Bình Thạnh, TP. Hồ Chí Minh",
                },
                new Customer
                {
                    Id = Guid.Parse("10000000-0000-0000-0000-000000000005"),
                    FullName = "Võ Thị Mai Lan",
                    Phone = "0945678901",
                    Email = "lan.vo@email.com",
                    Address = "654 Võ Văn Tần, Quận 3, TP. Hồ Chí Minh",
                },
            ];
    }
}
