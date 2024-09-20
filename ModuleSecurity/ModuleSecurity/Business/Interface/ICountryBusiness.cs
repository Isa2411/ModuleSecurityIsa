using Entity.Dto;
using Entity.Model.Security;

namespace Business.Interface
{
    public interface ICountryBusiness
    {
        Task<IEnumerable<CountryDto>> GetAll();
        Task<CountryDto> GetById(int id);
        Task<Country> Save(CountryDto entity);
        Task Update(CountryDto entity);
        Task Delete(int id);
    }
}
