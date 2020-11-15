using DomainLibrary.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLibrary.Entities
{
    public class StandardUser : User, IStandardUser
    {
        public List<VideoTraining> VideoTrainings { get; set; }

        public StandardUser()
        {
            Role = UserRole.Standard;
        }
        public override string Info()
        {
            return $"{FirstName} {LastName} - Standard User";
        }
    }
}
