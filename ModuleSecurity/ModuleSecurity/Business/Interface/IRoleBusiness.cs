using Entity.Dto;

namespace Business.Interface
{
    public interface IRoleBusiness
    {
        public Task Delete(int id);
        public Task<IEnumerable<RoleDto>> GetAll();
        public Task<IEnumerable<DataSelectDto>> GetAllSelect();
        public Task<RoleDto> GetById(int id);
        public Task<RoleDto> GetByName(string name);
        public Task<RoleDto> Save(RoleDto entity);
        public Task Update(RoleDto entity);
    }
}
