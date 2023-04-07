using FeeCalculationApp.Models;
using FeeCalculationApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace FeeCalculationApp.Controllers;

public class SubscriptionController : Controller
{
    private readonly SubscriptionFeeCalculator _feeCalculator;
    private readonly List<Subscription> _subscriptions;

    public SubscriptionController(SubscriptionFeeCalculator feeCalculator, List <Subscription> subscriptions)
    {
        _feeCalculator = feeCalculator;
        _subscriptions = subscriptions;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View("IndexGet");
    }

    [HttpPost]
    public IActionResult Index(Subscription request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        decimal fee = _feeCalculator.CalculateTotalFee(request);
        Subscription subscription = request with { Fee = fee };

        return View("IndexPost", subscription);
    }
}