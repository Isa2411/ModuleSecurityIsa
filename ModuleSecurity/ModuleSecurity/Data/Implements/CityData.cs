﻿using Data.Interfaces;
using Entity.Context;
using Entity.Dto;
using Entity.Model.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Data.Implements
{
    public class CityData : ICityData
    {
        private readonly ApplicationDBContext context;
        protected readonly IConfiguration configuration;

        public CityData(ApplicationDBContext context, IConfiguration configuration)
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
            context.Citys.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task<City> GetById(int id)
        {
            var sql = @"SELECT * FROM Cities WHERE Id = @Id ORDER BY Id ASC";
            return await this.context.QueryFirstOrDefaultAsync<City>(sql, new { Id = id });
        }

        public async Task<City> Save(City entity)
        {
            context.Citys.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(City entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task<City> GetByName(string name)
        {
            return await this.context.Citys.AsNoTracking().Where(item => item.Name == name).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            try
            {
                var sql = @"
                    SELECT Id, CONCAT(Name) AS TextoMostrar
                    FROM Cities
                    WHERE Deleted_at IS NULL AND State = 1
                    ORDER BY Id ASC";

                return await this.context.QueryAsync<DataSelectDto>(sql);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la lista de selección de Cities", ex);
            }
        }

        public async Task<IEnumerable<City>> GetAll()
        {
            try
            {
                var sql = "SELECT * FROM Cities WHERE State=true  ORDER BY Id ASC";
                return await this.context.QueryAsync<City>(sql);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener todas las Cities", ex);
            }
        }
    }
}