using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Bingoapp.Models;
using Bingoapp.Rule;
using Bingoapp.Data;

namespace Bingoapp.Controllers;

public class HomeController : Controller
{

    private readonly ApplicationDbContext _context;
    public HomeController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Index()
    {
        CardboardRule cardboardRule = new();
        BallNumberRule ballNumberRule = new();
        var model = new
        {
            CardboardOne = new Cardboard { Id = 1, Content = cardboardRule.GenerateCardboard() },
            CardboardTwo = new Cardboard { Id = 2, Content = cardboardRule.GenerateCardboard() },
            CardboardThree = new Cardboard { Id = 3, Content = cardboardRule.GenerateCardboard() },
            CardboardFour = new Cardboard { Id = 4, Content = cardboardRule.GenerateCardboard() },
        };
        ballNumberRule.ClearNumbersGenerated();
        return View(model);
    }

    [HttpGet]
    public async Task<IActionResult> GenerateNumber()
    {
        BallNumberRule ballNumberRule = new();
        var ballNumber = await ballNumberRule.GetUniqueBallNumberAsync(_context);
        return Content(ballNumber.ToString());
    }

    [HttpPost]
    public async Task<IActionResult> Winners([FromBody] List<int> winners)
    {
        CardboardHistoryRule cardboardHistoryRule = new();
        await cardboardHistoryRule.AddWinnersAsync(_context, winners);
        return Ok();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}