using Core.Entities;
using Core.Interfaces;
using Infrastructure.Context;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class GenericRepository<T>(StoreContext context) : IGenericRepository<T> where T : Entity
    {
        public async Task Add(T entity)
        {
            await context.Set<T>().AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task Delete(T entity)
        {
            context.Set<T>().Remove(entity);
            await context.SaveChangesAsync();
        }


        public async Task<T?> GetById(int id)
        {
            return await context.Set<T>().FindAsync(id);
        }

        public async Task<T?> GetEntityWithSpecification(ISpecification<T> specification)
        {
            return await ApplySpecification(specification).FirstOrDefaultAsync();
        }

        public async Task<TResult?> GetEntityWithSpecification<TResult>(ISpecification<T, TResult> specification)
        {
            return await ApplySpecification(specification).FirstOrDefaultAsync();
        }

        public async Task<IReadOnlyList<T>> ListAll()
        {
            return await context.Set<T>().ToListAsync();
        }

        public async Task<IReadOnlyList<T>> ListWithSpecification(ISpecification<T> specification)
        {
            return await ApplySpecification(specification).ToListAsync();
        }

        public async Task<IReadOnlyList<TResult>> ListWithSpecification<TResult>(ISpecification<T, TResult> specification)
        {
            return await ApplySpecification(specification).ToListAsync();
        }

        public async Task Update(T entity)
        {
            context.Set<T>().Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        private IQueryable<T> ApplySpecification(ISpecification<T> specification)
        {
            return SpecificationEvaluator<T>.GetQuery(context.Set<T>().AsQueryable(), specification);
        }

        private IQueryable<TResult> ApplySpecification<TResult>(ISpecification<T, TResult> specification)
        {
            return SpecificationEvaluator<T>.GetQuery<T,TResult>(context.Set<T>().AsQueryable(), specification);
        }
    }
}
