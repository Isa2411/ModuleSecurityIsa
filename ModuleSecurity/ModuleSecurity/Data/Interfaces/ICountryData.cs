using Entity.Dto;
using Entity.Model.Security;

namespace Data.Interfaces
{
    public interface ICountryData
    {
        public Task Delete(int id);
        public Task<Country> GetByName(string name);
        public Task<Country> Save(Country entity);
        public Task Update(Country entity);
        public Task<Country> GetById(int id);
        public Task<IEnumerable<Country>> GetAll();
        public Task<IEnumerable<DataSelectDto>> GetAllSelect();

    }
}
