using Entity.Dto;
using Entity.Model.Security;

namespace Data.Interfaces
{
    public interface IViewData
    {
        public Task Delete(int id);
        public Task<IEnumerable<View>> GetAll();
        public Task<IEnumerable<DataSelectDto>> GetAllSelect();
        public Task<View> GetById(int id);
        public Task<View> GetByName(string name);
        public Task<View> Save(View entity);
        public Task Update(View entity);
    }
}
