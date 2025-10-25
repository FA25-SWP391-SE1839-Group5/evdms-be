namespace EVDMS.DataAccessLayer.Data.Seeds
{
    public static class DbSeeder
    {
        public static async Task SeedAsync(AppDbContext context)
        {
            if (!context.DealerOrders.Any())
            {
                var orders = DealerOrderSeed.DealerOrders;
                context.DealerOrders.AddRange(orders);
                await context.SaveChangesAsync();
            }
            if (!context.DealerPayments.Any())
            {
                var payments = DealerPaymentSeed.DealerPayments;
                context.DealerPayments.AddRange(payments);
                await context.SaveChangesAsync();
            }
        }
    }
}
