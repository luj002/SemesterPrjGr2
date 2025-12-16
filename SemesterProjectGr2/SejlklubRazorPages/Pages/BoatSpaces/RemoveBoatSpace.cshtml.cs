using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SejlklubRazorPages.Pages.BoatSpaces
{
    public class RemoveBoatSpaceModel : PageModel
    {
        private IBoatSpaceRepository _bsrepo;

        [BindProperty]
        public BoatSpace BoatSpace { get; set; }

        public RemoveBoatSpaceModel(IBoatSpaceRepository bsrepo)
        {
            _bsrepo = bsrepo;
        }

        public void OnGet(int number)
        {
            BoatSpace = _bsrepo.GetBoatSpaceByNumber(number);
        }

        public IActionResult OnPost()
        {
            _bsrepo.Remove(BoatSpace.Number);
            return RedirectToPage("Index");
        }
    }
}
