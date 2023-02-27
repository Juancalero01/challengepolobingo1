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
        var rule = new CardboardRule();
        var model = new
        {
            CardboardOne = new Cardboard { Id = 1, Content = rule.GenerateCardboard() },
            CardboardTwo = new Cardboard { Id = 2, Content = rule.GenerateCardboard() },
            CardboardThree = new Cardboard { Id = 3, Content = rule.GenerateCardboard() },
            CardboardFour = new Cardboard { Id = 4, Content = rule.GenerateCardboard() },
        };
        return View(model);
    }

    [HttpGet]
    public async Task<IActionResult> GenerateNumber()
    {
        var rule = new BallNumberRule();
        var ballNumber = await rule.GetUniqueBallNumberAsync(_context);
        return Content(ballNumber.ToString());
    }

    [HttpPost]
    public async Task<IActionResult> Winners([FromBody] List<int> winners)
    {
        try
        {
            var rule = new CardboardHistoryRule();
            await rule.AddWinnersAsync(_context, winners);
            return Ok();
        }
        catch (Exception)
        {
            return StatusCode(500);
        }
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}