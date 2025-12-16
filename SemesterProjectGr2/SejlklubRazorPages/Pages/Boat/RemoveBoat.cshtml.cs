using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class CringlerModel : PageModel
{
    public void OnGet()
    {}

    public IActionResult OnPostReturn()
    {
        return RedirectToPage("Index");
    }
}