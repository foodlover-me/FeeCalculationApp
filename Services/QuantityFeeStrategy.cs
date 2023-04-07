using FeeCalculationApp.Models;

namespace FeeCalculationApp.Services;

internal class QuantityFeeStrategy : ISubscriptionFeeStrategy
{
    public decimal CalculateFee(Subscription request, decimal previousFee)
    {
        return request.NumberOfUsers * (request.NumberOfUsers switch
        {
            < 1 or > 100 => throw new ArgumentOutOfRangeException(nameof(request),
                "The valid range for number of users is between 1 and 100"),
            <= 20 => 40m,
            <= 50 => 37.5m,
            _ => 35m
        }) + previousFee;
    }
}