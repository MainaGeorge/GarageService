using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SparkAuto.Pages
{
    public class IndexModel : PageModel
    {

        [TempData]
        public string Message { get; set; }


        public void OnGet()
        {

        }
    }
}
