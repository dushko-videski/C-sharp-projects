using DomainLibrary.Entities;
using System.Collections.Generic;

namespace DomainLibrary.DB
{
    public interface IDb<T> where T : BaseEntity
    {
        List<T> GetAll();

        T GetById(int id);
        int Insert(T entityToInsert);
        void RemoveById(int id);
        void Update(T entity);

    }
}
