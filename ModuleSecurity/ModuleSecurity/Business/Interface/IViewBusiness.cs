using Entity.Dto;

namespace Business.Interface
{
    public interface IViewBusiness
    {
        public Task Delete(int id);
        public Task<IEnumerable<ViewDto>> GetAll();
        public Task<IEnumerable<DataSelectDto>> GetAllSelect();
        public Task<ViewDto> GetById(int id);
        public Task<ViewDto> GetByName(string name);
        public Task<ViewDto> Save(ViewDto entity);
        public Task Update(ViewDto entity);
    }
}
