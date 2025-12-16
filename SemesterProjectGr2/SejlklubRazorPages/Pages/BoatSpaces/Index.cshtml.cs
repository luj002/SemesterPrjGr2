using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SejlklubRazorPages.Pages.BoatSpaces;

public class IndexModel : PageModel
{
    private IBoatSpaceRepository _bsrepo;

    public List<BoatSpace> BoatSpaces { get; set; }

    public IndexModel(IBoatSpaceRepository bsrepo)
    {
        _bsrepo = bsrepo;
    }

    public void OnGet()
    {
        BoatSpaces = _bsrepo.GetAll();
    }
}
