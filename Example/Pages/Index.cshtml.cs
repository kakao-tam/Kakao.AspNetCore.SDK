using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Example.Pages;

public class IndexModel : PageModel
{
    public string? AccessToken { get; set; }
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
        AccessToken = HttpContext.Session.GetString("kakao_access_token");
    }
}

