using DomainLibrary.Enums;

namespace DomainLibrary.Entities
{
    public abstract class Training : BaseEntity, ITraining
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Time { get; set; }
        public int Rating { get; set; }
        public Difficulty Difficulty { get; set; }
        public string CheckRating()
        {
            if (Rating == 1)
                return "Bad";
            if (Rating <= 3)
                return "Okey";
            if (Rating > 3)
                return "Good";

            return "unknown";
        }





    }
}
