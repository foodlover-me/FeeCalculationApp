using FeeCalculationApp.Models;

namespace FeeCalculationApp.Services;

public class SubscriptionFeeCalculator
{
    private readonly IEnumerable<ISubscriptionFeeStrategy> _strategies;

    public SubscriptionFeeCalculator(IEnumerable<ISubscriptionFeeStrategy> strategies)
    {
        _strategies = strategies;
    }

    internal decimal CalculateTotalFee(Subscription request)
    {
        var totalFee = 0m;
        foreach (var strategy in _strategies) totalFee = strategy.CalculateFee(request, totalFee);

        return totalFee;
    }
}