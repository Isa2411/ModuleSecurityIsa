using Entity.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Interface
{
    public interface IRoleViewController
    {
        public Task Delete(int id);
        public Task<IEnumerable<RoleViewDto>> GetAll();
        public Task<IEnumerable<DataSelectDto>> GetAllSelect();
        public Task<RoleViewDto> GetById(int id);
        public Task<RoleViewDto> Save(RoleViewDto roleViewDto);
        public Task Update(RoleViewDto roleViewDto);
    }
}
