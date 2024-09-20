using Entity.Dto;
using Entity.Model.Security;

namespace Data.Interfaces
{
    public interface IUserRoleData
    {
        public Task Delete(int id);
        public Task<IEnumerable<UserRole>> GetAll();
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
        public Task<UserRole> GetById(int id);
        public Task<UserRole> Save(UserRole entity);
        public Task Update(UserRole entity);
    }
}
