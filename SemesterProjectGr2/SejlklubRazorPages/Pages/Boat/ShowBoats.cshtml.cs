using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class SpectraModel : PageModel
{
    private BoatRepository _boatRep;
    public List<Boat> BoatList { get; set; }

    public void OnGet()
    {
        _boatRep = new BoatRepository();
        MockData.PopulateBoats(_boatRep);
        BoatList = _boatRep.GetAll();
    }

    public IActionResult OnPostReturn()
    {
        return RedirectToPage("Index");
    }
}