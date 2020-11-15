using DomainLibrary.Enums;
using System.Collections.Generic;

namespace DomainLibrary.Entities
{
    public class PremiumUser : User, IStandardUser, IPremiumUser
    {
        public List<VideoTraining> VideoTrainings { get; set; }

        public LiveTraining LiveTraining { get; set; }

        public PremiumUser()
        {
            Role = UserRole.Premium;
        }

        public override string Info()
        {
            return $"{FirstName} {LastName} - Premium User";
        }
    }
}
