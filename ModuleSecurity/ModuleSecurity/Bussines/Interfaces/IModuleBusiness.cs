using Entity.DTO;
using Entity.Model.Security;

namespace Bussines.Interfaces
{
    public interface IModuleBusiness
    {
        public Task Delete(int id);
        public Task<IEnumerable<ModuleDto>> GetAll();
        public Task<IEnumerable<DataSelectDto>> GetAllSelect();
        public Task<ModuleDto> GetById(int id);
        public Task<Module> Save(ModuleDto entity);
        public Task Update(ModuleDto entity);
    }
}
