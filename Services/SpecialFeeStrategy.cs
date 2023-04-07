using FeeCalculationApp.Models;

namespace FeeCalculationApp.Services;

internal class SpecialFeeStrategy : ISubscriptionFeeStrategy
{
    public decimal CalculateFee(Subscription request, decimal previousFee)
    {
        if (!request.SpecialOffer)
            return previousFee;

        var discount = previousFee * 0.15m;
        var newFee = previousFee - discount;
        return newFee;
    }
}