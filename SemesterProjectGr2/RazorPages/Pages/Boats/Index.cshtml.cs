using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPages.Pages.Boats
{
	public class IndexModel : PageModel
	{
		private IBoatRepository _repo;

		public List<Boat> Boats { get; set; }

		public IndexModel(IBoatRepository boatRepository)
		{
			_repo = boatRepository;
		}

		public void OnGet()
		{
			Boats = _repo.GetAll();
		}
	}
}