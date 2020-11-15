namespace DomainLibrary.Entities
{
    public interface IBaseEntity
    {
        int Id { get; set; }

        string Info();
    }
}