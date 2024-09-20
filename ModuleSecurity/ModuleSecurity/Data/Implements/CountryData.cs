using Data.Interfaces;
using Entity.Context;
using Entity.Dto;
using Entity.Model.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Data.Implements
{
    public class CountryData : ICountryData
    {
        private readonly ApplicationDBContext context;
        protected readonly IConfiguration configuration;

        public CountryData(ApplicationDBContext context, IConfiguration configuration)
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
            context.Countrys.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task<Country> GetById(int id)
        {
            var sql = @"SELECT * FROM Countrys WHERE Id = @Id ORDER BY Id ASC";
            return await this.context.QueryFirstOrDefaultAsync<Country>(sql, new { Id = id });
        }

        public async Task<Country> Save(Country entity)
        {
            context.Countrys.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(Country entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task<Country> GetByName(string name)
        {
            return await this.context.Countrys.AsNoTracking().Where(item => item.Name == name).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            try
            {
                var sql = @"
                    SELECT Id, CONCAT(Name) AS TextoMostrar
                    FROM Countrys
                    WHERE Deleted_at IS NULL AND State = 1
                    ORDER BY Id ASC";

                return await this.context.QueryAsync<DataSelectDto>(sql);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la lista de selección de Country", ex);
            }
        }

        public async Task<IEnumerable<Country>> GetAll()
        {
            try
            {
                var sql = "SELECT * FROM Countrys WHERE State=true ORDER BY Id ASC";
                return await this.context.QueryAsync<Country>(sql);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener todos los Country", ex);
            }
        }
    }
}
