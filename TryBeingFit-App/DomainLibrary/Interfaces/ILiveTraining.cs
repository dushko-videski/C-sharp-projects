using System;

namespace DomainLibrary.Entities
{
    public interface ILiveTraining
    {
        DateTime NextSession { get; set; }
        TrainerUser Trainer { get; set; }

        int HoursToNextSession();
    }
}