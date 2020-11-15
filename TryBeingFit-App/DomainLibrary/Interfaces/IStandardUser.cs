using System.Collections.Generic;

namespace DomainLibrary.Entities
{
    public interface IStandardUser
    {
        List<VideoTraining> VideoTrainings { get; set; }
    }
}