using Data.Interfaces;
using Entity.Context;
using Entity.Dto;
using Entity.Model.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Data.Implements
{
    public class ModuleData : IModuleData
    {
        private readonly ApplicationDBContext context;
        protected readonly IConfiguration configuration;

        public ModuleData(ApplicationDBContext context, IConfiguration configuration)
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
            context.Modules.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            var sql = @"SELECT Id AS TextoMostrar
                        FROM Modules
                        WHERE Deleted_at IS NULL AND State = 1
                        ORDER BY Id ASC";
            return await context.QueryAsync<DataSelectDto>(sql);
        }

        public async Task<Module> GetById(int id)
        {
            try
            {
                var sql = @"SELECT * FROM Modules WHERE Id = @Id ORDER BY Id ASC";
                return await this.context.QueryFirstOrDefaultAsync<Module>(sql, new { Id = id });
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Module> Save(Module entity)
        {
            context.Modules.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(Module entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        //public async Task<Module> GetByName(string name)
        //{
        //    return await this.context.Roles.AsNoTracking().Where(item => item.Name == name).FirstOrDefaultAsync();
        //}


        Task<Module> IModuleData.GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Module>> GetAll()
        {
            var sql = @"SELECT * FROM Modules WHERE State=true ORDER BY Id ASC";
            return await this.context.QueryAsync<Module>(sql);
        }
    }
}
