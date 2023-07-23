using CA.Domain.Common;

namespace CA.Domain.Models
{
    public class LeaveType:BaseDomainEntity
    {
        public string Name { get; set; }
        public int DefaultDay { get; set; }
    }
}
