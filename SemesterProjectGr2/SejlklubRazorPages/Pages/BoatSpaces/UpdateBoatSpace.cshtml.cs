using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SejlklubRazorPages.Pages.BoatSpaces
{
    public class UpdateBoatSpaceModel : PageModel
    {
        [BindProperty]
        public BoatSpace BoatSpace { get; set; }

        private IBoatSpaceRepository _bsrepo;
        public UpdateBoatSpaceModel(IBoatSpaceRepository bsrepo)
        {
            _bsrepo = bsrepo;
        }
        public void OnGet(int number)
        {
            BoatSpace = _bsrepo.GetBoatSpaceByNumber(number);
        }

        public IActionResult OnPost()
        {
            BoatSpace bsNew = BoatSpace;
            bsNew.Number = BoatSpace.Number;
            return RedirectToPage("Index");
        }

        public IActionResult OnPostDelete()
        {
            _bsrepo.Remove(BoatSpace.Number);
            return RedirectToPage("Index");
        }
    }
}
