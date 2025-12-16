using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SejlklubRazorPages.Pages.BoatSpaces
{
    public class AddBoatSpaceModel : PageModel
    {
        private IBoatSpaceRepository _bsrepo;

        [BindProperty]
        public BoatSpace NewBoatSpace { get; set; }
        public AddBoatSpaceModel(IBoatSpaceRepository bsrepo)
        {
            _bsrepo = bsrepo;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            _bsrepo.Add(NewBoatSpace);
            return RedirectToPage("Index");
        }
    }
}
