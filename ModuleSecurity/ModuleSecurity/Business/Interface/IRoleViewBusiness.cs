using Entity.Dto;

namespace Business.Interface
{
    public interface IRoleViewBusiness
    {
        public Task Delete(int id);
        public Task<IEnumerable<RoleViewDto>> GetAll();
        public Task<IEnumerable<DataSelectDto>> GetAllSelect();
        public Task<RoleViewDto> GetById(int id);
        public Task<RoleViewDto> Save(RoleViewDto entity);
        public Task Update(RoleViewDto entity);
    }
}
