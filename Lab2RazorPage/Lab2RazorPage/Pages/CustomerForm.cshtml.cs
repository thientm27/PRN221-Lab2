using Lab2RazorPage.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lab2RazorPage.Pages
{
    public class CustomerForm : PageModel
    {
        public string Message { get; set; }
        [BindProperty]
        public Customer CustomerInfo { get; set; }
        public void OnPost()
        {
            if (ModelState.IsValid)
            {
                Message = "Information is OK";
                ModelState.Clear();
            }
            else
            {
                Message = "Error on input data.";
            }
        }
    }
}