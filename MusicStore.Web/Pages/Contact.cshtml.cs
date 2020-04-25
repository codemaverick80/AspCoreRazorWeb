using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MusicStore.Web.Pages
{
    public class ContactModel : PageModel
    {
        public void OnGet()
        {
        }

        public async Task OnPostViewAsync(int id)
        {

           var  message = $"View handler fired for {id}";
        }
    }
}
