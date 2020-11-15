namespace DomainLibrary.Entities
{
    public class VideoTraining : Training, IVideoTraining
    {

        public string Link { get; set; }


        public override string Info()
        {
            return $"[{Difficulty}] {Title} - {Description}";
        }
    }
}