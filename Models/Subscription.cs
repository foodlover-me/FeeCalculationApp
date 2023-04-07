using System.ComponentModel.DataAnnotations;

namespace FeeCalculationApp.Models;

public record Subscription(
    [Range(0, 100)]
    int NumberOfUsers,
    string ClientName,
    bool SpecialOffer,
    decimal Fee)
{
    public override string ToString() => $"subscription for {ClientName}";
}