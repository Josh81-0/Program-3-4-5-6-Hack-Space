[ApiController]
[Route("api/blog")]
public class BlogController : ControllerBase
{
    [HttpGet]
    public IActionResult GetPosts()
    {
        var posts = new[]
        {
            new { Title = "Understanding Reserve Studies...", Date = "March 15, 2026", Author = "Sarah Chen", Summary = "..." },
            new { Title = "Balance Sheet Best Practices...", Date = "February 28, 2026", Author = "Michael Torres", Summary = "..." },
            // Add more as needed
        };

        return Ok(posts);
    }
}