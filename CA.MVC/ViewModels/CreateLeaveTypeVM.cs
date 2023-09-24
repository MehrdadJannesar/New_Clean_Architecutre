using System.ComponentModel.DataAnnotations;

namespace CA.MVC.ViewModels
{
    public class CreateLeaveTypeVM
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Default Number of Days")]
        public int DefaultDay { get; set; }
    }
}
