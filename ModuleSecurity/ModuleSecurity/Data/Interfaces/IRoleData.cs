using Entity.Dto;
using Entity.Model.Security;

namespace Data.Interfaces
{
    public interface IRoleData
    {
        public Task Delete(int id);
        public Task<IEnumerable<Role>> GetAll();
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        public Task<Role> GetById(int id);
        public Task<Role> GetByName(string name);
        public Task<Role> Save(Role entity);
        public Task Update(Role entity);
    }
}
