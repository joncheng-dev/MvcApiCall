using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MvcApiCall.Models;

namespace MvcApiCall.Controllers;

public class HomeController : Controller
{
	private readonly ILogger<HomeController> _logger;
	private readonly string _apikey;

	public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
	{
		_logger = logger;
		_apikey = configuration["NYT"];
	}

	public IActionResult Index()
	{
		var allArticles = Article.GetArticles(_apikey);
		// Task<string> allArticles = Article.GetArticles(_apikey);
		return View(allArticles);
	}

	public IActionResult Privacy()
	{
		return View();
	}

	[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
	public IActionResult Error()
	{
		return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
	}
}
