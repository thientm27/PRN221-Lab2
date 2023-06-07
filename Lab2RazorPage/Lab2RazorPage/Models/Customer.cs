using System.ComponentModel.DataAnnotations;
using Lab2RazorPage.Biding;
using Microsoft.AspNetCore.Mvc;

namespace Lab2RazorPage.Models
{
    public class Customer
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Name length if 3 to 20")]
        [Display(Name = "Customer name")]
        [ModelBinder(BinderType = typeof(CheckNameBinding))]
        public string CustomerName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        [Display(Name = "Customer email")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "Year of birth is required")]
        [Display(Name = "Year of birth")]
        [Range(1960,2000, ErrorMessage = "rang must from 1960 - 2000")]
        public int? YearOfBirth { get; set; }

    }
}