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
    private const string TriangleInvalidError = "The triangle is not valid.";
    private const string InvalidInputError = "The input is not valid.";
    private readonly ILogger<MainController> _logger;

    private MainService _mainService = new MainService();

    public MainController(ILogger<MainController> logger)
    {
        _logger = logger;
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
        if (!_mainService.CheckValidity(triangle))
        {
            return BadRequest(TriangleInvalidError);
        }

        var perimeter = _mainService.CalculatePerimeter(triangle);
        var area = _mainService.CalculateArea(triangle);

        return Ok(new { perimeter, area });
    }
  
  [HttpGet("api/fibonacci/{n}")]
  public IActionResult GetFibonacci(int n)
  // This method calculates the first n Fibonacci numbers.
  // This method only works until n = 92, because the 93rd Fibonacci number is larger than the maximum value of ulong.
  {
    if (n < 0)
    {
      return BadRequest(InvalidInputError);
    }
    
    var fibonacci = _mainService.GetFibonacci(n);
    
    return Ok(new { fibonacci });
  }

  [HttpPost("api/sort")]
  public IActionResult Sort([FromBody] SortRequest request)
  {
    if (request.Array == null)
    {
      return BadRequest(InvalidInputError);
    }
    _mainService.QuickSort(request.Array);
    return Ok(new { request.Array });
  }
}
