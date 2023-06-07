using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Hosting;

namespace Lab2RazorPage.Pages
{
    public class UploadFileModel : PageModel
    {
        private IHostEnvironment _environment;

        public UploadFileModel(IHostEnvironment environment)
        {
            _environment = environment;
        }

        [Required(ErrorMessage = "Please choose at least one file")]
        [DataType(DataType.Upload)]
        [FileExtensions(Extensions = "png,jpg,jpeg,gif")]
        [Display(Name = "Choose file(s) to upload")]
        [BindProperty]
        public IFormFile[] FileUploads { get; set; }
        public async Task OnPostAsync()
        {
            if (FileUploads != null)
            {
                foreach (var file in FileUploads)
                {
                    var newFile = Path.Combine(_environment.ContentRootPath, "Images", file.FileName);

                    using (var fileStream = new FileStream(newFile, FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }
                }
            }   
        }
    }
}