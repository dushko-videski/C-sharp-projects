using System;

namespace DomainLibrary.Entities
{
    public class LiveTraining : Training, ILiveTraining
    {
        public DateTime NextSession { get; set; }
        public TrainerUser Trainer { get; set; }

        public int HoursToNextSession()
        {
            return (NextSession - DateTime.Now).Hours;
        }

        public override string Info()
        {
            return $"[{Difficulty}] {Title} - {Description} with trainer {Trainer.Info()}";
        }
    }
}