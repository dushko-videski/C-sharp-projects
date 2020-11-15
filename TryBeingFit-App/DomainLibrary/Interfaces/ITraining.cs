using DomainLibrary.Enums;

namespace DomainLibrary.Entities
{
    public interface ITraining
    {
        string Description { get; set; }
        Difficulty Difficulty { get; set; }
        int Rating { get; set; }
        int Time { get; set; }
        string Title { get; set; }

        string CheckRating();
    }
}