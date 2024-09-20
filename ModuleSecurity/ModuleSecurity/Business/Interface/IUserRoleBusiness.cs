using Entity.Dto;

namespace Business.Interface
{
    public interface IUserRoleBusiness
    {
        public Task Delete(int id);
        public Task<IEnumerable<UserRoleDto>> GetAll();
        public Task<IEnumerable<DataSelectDto>> GetAllSelect();
        public Task<UserRoleDto> GetById(int id);
        public Task<UserRoleDto> Save(UserRoleDto entity);
        public Task Update(UserRoleDto entity);
    }
}
