using Entity.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Interface
{
    public interface IUserRoleController
    {
        public Task Delete(int id);
        public Task<IEnumerable<UserRoleDto>> GetAll();
        public Task<IEnumerable<DataSelectDto>> GetAllSelect();
        public Task<UserRoleDto> GetById(int id);
        public Task<UserRoleDto> Save(UserRoleDto userRoleDto);
        public Task Update(UserRoleDto userRoleDto);
    }
}
