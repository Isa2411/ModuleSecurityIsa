using Entity.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Interface
{
    public interface IRoleController
    {
        public Task Delete(int id);
        public Task<IEnumerable<RoleDto>> GetAll();
        public Task<IEnumerable<DataSelectDto>> GetAllSelect();
        public Task<RoleDto> GetById(int id);
        public Task<RoleDto> Save(RoleDto roleDto);
        public Task Update(RoleDto roleDto);
    }
}
