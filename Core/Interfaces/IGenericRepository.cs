using Core.Entities;

namespace Core.Interfaces
{
    public interface IGenericRepository<T> where T : Entity
    {
        Task<T?> GetById(int id);

        Task<IReadOnlyList<T>> ListAll();

        Task<IReadOnlyList<T>> ListWithSpecification(ISpecification<T> specification);

        Task Add(T entity);

        Task Update(T entity);

        Task Delete(T entity);

        Task<T?> GetEntityWithSpecification(ISpecification<T> specification);
    }
}
