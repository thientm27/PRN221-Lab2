using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.Models;
using Lab2RazorCRUD.Models;
using Microsoft.Extensions.Configuration;

namespace Lab2RazorCRUD.Pages.StudentManager
{
    public class IndexModel : PageModel
    {
        private readonly BusinessObjects.Models.SchoolContext _context;
        private readonly IConfiguration Configuration;
        public IndexModel(BusinessObjects.Models.SchoolContext context, IConfiguration configuration)
        {
            _context = context;
            Configuration = configuration;
        }
        public string NameSort { get; set; }
        public string DateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
        public PaginatedList<Student> Student { get;set; }

        public async Task OnGetAsync(string sortOrder,
            string currentFiter,string searchString, int? pageIndex)
        {
            CurrentSort = sortOrder;
            NameSort = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";

            if(searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFiter;
            }
            CurrentFilter = searchString;

            IQueryable<Student> studentsIQ = from s in _context.Students select s;
            if(!string.IsNullOrEmpty(searchString) )
            {
                studentsIQ = studentsIQ.Where(s => s.LastName.Contains(searchString)
                || s.FirstMidName.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    {
                        studentsIQ = studentsIQ.OrderByDescending(s => s.LastName);
                        break;
                    }
                case "Date":
                    {
                        studentsIQ = studentsIQ.OrderBy(s => s.EnrollmentDate);
                        break;
                    }
                case "date_desc":
                    {
                        studentsIQ = studentsIQ.OrderByDescending(s => s.EnrollmentDate);
                        break;
                    }
                default:
                    {
                        studentsIQ = studentsIQ.OrderBy(s => s.LastName);
                        break;
                    }
            }
            var pageSize = Configuration.GetValue("PageSize", 4);


            Student = await PaginatedList<Student>.CreateAsync(studentsIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}
