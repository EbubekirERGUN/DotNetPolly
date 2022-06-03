using Microsoft.AspNetCore.Mvc;
using RequestService.Policies;

namespace RequestService.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class RequestController : ControllerBase
{
    private readonly IHttpClientFactory _httpClientFactory;

    public RequestController(IHttpClientFactory httpClientFactory = null)
    {

        _httpClientFactory = httpClientFactory;
    }

    [HttpGet]
    public async Task<ActionResult> ImmediateHttpRetry()
    {
        var client = _httpClientFactory.CreateClient("Test");

        var response = await client.GetAsync("https://localhost:7067/api/response/40");

        // var response = await _clientPolicy.ImmediateHttpRetry.ExecuteAsync(
        //     () => client.GetAsync("https://localhost:7067/api/response/40"));

        if (response.IsSuccessStatusCode)
        {
            System.Console.WriteLine("--> Response returned Success");
            return StatusCode(StatusCodes.Status200OK);
        }
        System.Console.WriteLine("--> Response returned Failure");

        return StatusCode(StatusCodes.Status500InternalServerError);
    }


    [HttpGet]
    public async Task<ActionResult> LinearHttpRetry()
    {
        var client = _httpClientFactory.CreateClient();
        var response = await client.GetAsync("https://localhost:7067/api/response/40");

        // var response = await _clientPolicy.LinearHttpRetry.ExecuteAsync(
        //     () => client.GetAsync("https://localhost:7067/api/response/40"));

        if (response.IsSuccessStatusCode)
        {
            System.Console.WriteLine("--> Response returned Success");
            return StatusCode(StatusCodes.Status200OK);
        }
        System.Console.WriteLine("--> Response returned Failure");

        return StatusCode(StatusCodes.Status500InternalServerError);
    }


    [HttpGet]
    public async Task<ActionResult> ExponenTialHttpRetry()
    {
        var client = _httpClientFactory.CreateClient();

        var response = await client.GetAsync("https://localhost:7067/api/response/40");
        // var response = await _clientPolicy.ExponenTialHttpRetry.ExecuteAsync(
        //     () => client.GetAsync("https://localhost:7067/api/response/40"));

        if (response.IsSuccessStatusCode)
        {
            System.Console.WriteLine("--> Response returned Success");
            return StatusCode(StatusCodes.Status200OK);
        }
        System.Console.WriteLine("--> Response returned Failure");

        return StatusCode(StatusCodes.Status500InternalServerError);
    }
}
