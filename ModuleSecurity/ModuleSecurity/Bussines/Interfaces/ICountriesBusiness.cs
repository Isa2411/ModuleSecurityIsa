using Entity.DTO;
using Entity.Model.Security;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Threading.Tasks;

namespace Business.Interface
{
    public interface ICountriesBusiness
    {
        Task<IEnumerable<CountriesDto>> GetAll();
        Task<CountriesDto> GetById(int id);
        Task<Countries> Save(CountriesDto entity);
        Task Update(CountriesDto entity);
        Task Delete(int id);
    }
}
