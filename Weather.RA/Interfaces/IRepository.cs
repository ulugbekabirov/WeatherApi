﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace Weather.RA.Interfaces
{
    public interface IRepository<TEntity>
        where TEntity : class
    {
        Task<TEntity> GetByIdAsync(int id);

        Task<IEnumerable<TEntity>> GetAllAsync();

        Task CreateAsync(TEntity entity);

        Task UpdateAsync(TEntity entity);

        Task DeleteSoftlyAsync(int id);
    }
}
