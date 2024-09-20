using Data.Interfaces;
using Entity.Context;
using Entity.Dto;
using Entity.Model.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Data.Implements
{
    public class RoleViewData : IRoleViewData
    {
        private readonly ApplicationDBContext context;
        protected readonly IConfiguration configuration;

        public RoleViewData(ApplicationDBContext context, IConfiguration configuration)
        {
            this.context = context;
            this.configuration = configuration;
        }

        public async Task Delete(int id)
        {
            var entity = await GetById(id);
            if (entity == null)
                throw new Exception("Registro no encontrado");

            entity.DeleteAt = DateTime.Parse(DateTime.Today.ToString());
            entity.State = false;
            context.RoleViews.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            var sql = @"SELECT Id AS TextoMostrar
                        FROM RoleViews
                        WHERE Deleted_at IS NULL AND State = 1
                        ORDER BY Id ASC";
            return await context.QueryAsync<DataSelectDto>(sql);
        }

        public async Task<RoleView> GetById(int id)
        {
            try
            {
                var sql = @"SELECT * FROM RoleViews WHERE Id = @Id ORDER BY Id ASC";
                return await this.context.QueryFirstOrDefaultAsync<RoleView>(sql, new { Id = id });
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<RoleView> Save(RoleView entity)
        {
            context.RoleViews.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(RoleView entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        //public async Task<Role> GetByName(string name)
        //{
        //    return await this.context.Roles.AsNoTracking().Where(item => item.Name == name).FirstOrDefaultAsync();
        //}

        public async Task<IEnumerable<RoleView>> GetAll()
        {
            var sql = @"SELECT * FROM RoleViews WHERE State=true ORDER BY Id ASC";
            return await this.context.QueryAsync<RoleView>(sql);
        }
    }
}