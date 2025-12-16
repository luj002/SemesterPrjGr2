using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class GorbaModel : PageModel
{
    public void OnGet()
    {}

    public IActionResult OnPostShowBoats()
    {
        return RedirectToPage("ShowBoats");
    }

    public IActionResult OnPostAddBoat()
    {
        return RedirectToPage("AddBoat");
    }

    public IActionResult OnPostRemoveBoat()
    {
        return RedirectToPage("RemoveBoat");
    }

    public IActionResult OnPostUpdateBoat()
    {
        return RedirectToPage("UpdateBoat");
    }
}