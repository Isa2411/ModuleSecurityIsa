using Entity.Dto;

namespace Business.Interface
{
    public interface IModuleBusiness
    {
        public Task Delete(int id);
        public Task<IEnumerable<ModuleDto>> GetAll();
        public Task<IEnumerable<DataSelectDto>> GetAllSelect();
        public Task<ModuleDto> GetById(int id);
        public Task<ModuleDto> Save(ModuleDto entity);
        public Task Update(ModuleDto entity);
    }
}
