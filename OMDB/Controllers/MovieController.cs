using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

[ApiController]
[Route("api/movie")]
public class MovieController : ControllerBase
{
    private readonly HttpClient _httpClient;
    private const string ApiKey = "772fd179"; 

    public MovieController()
    {
        _httpClient = new HttpClient();
    }

    [HttpGet]
    public async Task<IActionResult> GetMovie(string title)
    {
        if (string.IsNullOrWhiteSpace(title))
            return BadRequest("Movie title is empty");

        var url = $"http://www.omdbapi.com/?apikey={ApiKey}&t={title}";

        var response = await _httpClient.GetAsync(url);

        if (!response.IsSuccessStatusCode)
            return StatusCode(500, "OMDb API error");

        var json = await response.Content.ReadAsStringAsync();
        var movie = JsonSerializer.Deserialize<Movie>(json);

        if (movie.Response == "False")
            return NotFound(movie.Error);

        return Ok(movie);
    }
}
