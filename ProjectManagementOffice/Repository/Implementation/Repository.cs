using Microsoft.EntityFrameworkCore;
using ProjectManagementOffice.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagementOffice.Repository.Implementation
{
    public class Repository<TableContext> : IRepository where TableContext : DbContext
    {
        protected TableContext context;
        public Repository(TableContext context)
        {
            this.context = context;
        }

        public async Task CreateAsync<T>(T entity) where T : class
        {
            this.context.Set<T>().Add(entity);

            _ = await this.context.SaveChangesAsync();
        }

        public async Task DeleteAsync<T>(T entity) where T : class
        {
            this.context.Set<T>().Remove(entity);

            _ = await this.context.SaveChangesAsync();
        }
        public async Task<List<T>> SelectAll<T>() where T : class
        {
            return await this.context.Set<T>().ToListAsync();
        }

        public async Task<T> SelectById<T>(long id) where T : class
        {
            return await this.context.Set<T>().FindAsync(id);
        }

        public async Task UpdateAsync<T>(T entity) where T : class
        {
            this.context.Set<T>().Update(entity);

            _ = await this.context.SaveChangesAsync();
        }
    }
}
