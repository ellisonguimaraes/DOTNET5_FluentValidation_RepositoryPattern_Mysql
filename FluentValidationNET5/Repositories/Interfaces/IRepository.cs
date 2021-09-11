using System.Collections.Generic;
using FluentValidationNET5.Models;

namespace FluentValidationNET5.Repositories.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        List<T> GetAll();
        T GetById(long id);
        T Create(T obj);
        T Update(T obj);
        bool Delete(long id);
    }
}