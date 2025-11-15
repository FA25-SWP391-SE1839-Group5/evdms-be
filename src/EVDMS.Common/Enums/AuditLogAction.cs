namespace EVDMS.Common.Enums
{
    public enum AuditLogAction
    {
        Login,
        Logout,
        PasswordReset,
        AccountCreation,
        AccountDeletion,
        CreateDealerOrder,
        DeliverDealerOrder,
        CreateDealerPayment,
        MarkDealerPaymentAsPaid,
        MarkDealerPaymentAsFailed,
        CreateQuotation,
        CreateSalesOrder,
        DeliverSalesOrder,
    }
}
