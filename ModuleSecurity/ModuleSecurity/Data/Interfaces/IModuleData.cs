using Entity.Dto;
using Entity.Model.Security;

namespace Data.Interfaces
{
    public interface IModuleData
    {
        public Task Delete(int id);
        public Task<IEnumerable<Module>> GetAll();
        public Task<IEnumerable<DataSelectDto>> GetAllSelect();
        public Task<Module> GetById(int id);
        public Task<Module> Save(Module entity);
        public Task Update(Module entity);
    }
}
