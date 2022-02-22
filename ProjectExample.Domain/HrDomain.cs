using HrSpecializzation = ProjectExample.Domain.Enum.HrSpecializzation;

namespace ProjectExample.Domain
{
    public class HrDomain : UserDomain
    {
        public HrSpecializzation Type { get; set; }
        public string Department { get; set; }
    }
}