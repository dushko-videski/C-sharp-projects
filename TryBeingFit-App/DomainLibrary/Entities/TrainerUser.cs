using DomainLibrary.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainLibrary.Entities
{
    public class TrainerUser : User, ITrainerUser
    {
        public int YearsOfExperiance { get; set; }

        public TrainerUser()
        {
            Role = UserRole.Trainer;
        }

        public bool ChangeSchedule(LiveTraining liveTraining, int days)
        {
            if (days <= 0)
                return false;

            liveTraining.NextSession = liveTraining.NextSession.AddDays(days);
            return true;
        }

        public override string Info()
        {
            return $"{FirstName} {LastName} : {YearsOfExperiance} years of experiance";
        }
    }
}
