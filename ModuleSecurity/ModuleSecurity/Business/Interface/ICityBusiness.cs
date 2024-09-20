using Entity.Dto;

namespace Business.Interface
{
    public interface ICityBusiness
    {
        Task<IEnumerable<CityDto>> GetAll();
        Task<CityDto> GetById(int id);
        Task<CityDto> Save(CityDto entity);
        Task Update(CityDto entity);
        Task Delete(int id);
    }
}
