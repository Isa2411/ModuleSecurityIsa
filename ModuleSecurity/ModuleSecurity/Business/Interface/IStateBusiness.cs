using Entity.Dto;

namespace Business.Interface
{
    public interface IStateBusiness
    {
        Task<IEnumerable<StateDto>> GetAll();
        Task<StateDto> GetById(int id);
        Task<StateDto> Save(StateDto entity);
        Task Update(StateDto entity);
        Task Delete(int id);
    }
}
