using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

namespace QwiikTest.Controllers;

[ApiController]
[Route("/")]
[Produces("application/json")]

// This is the main controller for the application. It is responsible for serving the main page and the API.

public class MainController : ControllerBase
{
    private readonly ILogger<MainController> _logger;

    public MainController(ILogger<MainController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetMainPage")]
    public IActionResult Get()
    {
        return File("wwwroot/index.html", "text/html");
    }

    [HttpGet("api", Name = "GetApi")]
    public IActionResult GetApi()
    {
        return Ok(new { message = "Hello from the API!" });
    }

    [HttpGet("api/health", Name = "GetHealth")]
    public IActionResult GetHealth()
    {
        return Ok(new { message = "Healthy!" });
    }

    [HttpPost("api/triangle")]
    public IActionResult CalculateTriangle([FromBody] Triangle triangle)
    {
        if (!TriangleService.CheckValidity(triangle))
        {
            return BadRequest("The triangle is not valid.");
        }

        var perimeter = TriangleService.CalculatePerimeter(triangle);
        var area = TriangleService.CalculateArea(triangle);

        return Ok(new { perimeter, area });
    }
  
  [HttpGet("api/fibonacci/{n}")]
  public IActionResult GetFibonacci(int n)
  // This method calculates the first n Fibonacci numbers.
  // This method only works until n = 92, because the 93rd Fibonacci number is larger than the maximum value of ulong.
  {
    if (n < 0)
    {
      return BadRequest("The number is not valid.");
    }
    
    var fibonacci = FibonacciService.GetFibonacci(n);
    
    return Ok(new { fibonacci });
  }

  [HttpPost("api/sort")]
  public IActionResult Sort([FromBody] int[] array)
  {
    QuickSortService.QuickSort(array);
    return Ok(new { array });
  }
}
