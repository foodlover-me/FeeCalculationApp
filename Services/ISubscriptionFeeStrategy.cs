using FeeCalculationApp.Models;

namespace FeeCalculationApp.Services;

public interface ISubscriptionFeeStrategy
{
    decimal CalculateFee(Subscription request, decimal previousFee);
}