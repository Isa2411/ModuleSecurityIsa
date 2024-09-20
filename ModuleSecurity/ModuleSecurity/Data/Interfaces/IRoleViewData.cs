using Entity.Dto;
using Entity.Model.Security;

namespace Data.Interfaces
{
    public interface IRoleViewData
    {
        public Task Delete(int id);
        public Task<IEnumerable<RoleView>> GetAll();
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        public Task<RoleView> GetById(int id);
        public Task<RoleView> Save(RoleView entity);
        public Task Update(RoleView entity);
    }
}
