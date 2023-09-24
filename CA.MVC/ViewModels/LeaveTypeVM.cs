using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CA.MVC.ViewModels
{
    public class LeaveTypeVM:CreateLeaveTypeVM
    {
        public Guid Id { get; set; }
    }
}
