[ApiController]
[Route("api/contact")]
public class ContactController : ControllerBase
{
    private readonly AppDbContext _context;

    public ContactController(AppDbContext context) => _context = context;

    [HttpGet]
    public async Task<IActionResult> GetSubmissions()
    {
        var submissions = await _context.ContactSubmissions
            .OrderByDescending(s => s.SubmittedAt)
            .ToListAsync();
        return Ok(submissions);
    }

    [HttpPost]
    public async Task<IActionResult> Submit([FromBody] ContactSubmission submission)
    {
        _context.ContactSubmissions.Add(submission);
        await _context.SaveChangesAsync();
        return Ok(submission);
    }
}