namespace DomainLibrary.Entities
{
    public interface ITrainerUser
    {
        int YearsOfExperiance { get; set; }

        bool ChangeSchedule(LiveTraining liveTraining, int days);
    }
}