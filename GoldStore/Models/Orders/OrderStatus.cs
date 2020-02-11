namespace GoldStore.Models.Orders
{
    public enum OrderStatus
    {
        Canceled,
        Closed,
        Completed,
        SuspectedFraud,
        OnHold,
        PaymentReview,
        Pending,
        PendingPayment,
        Processing,
        Submitted
    }
}
