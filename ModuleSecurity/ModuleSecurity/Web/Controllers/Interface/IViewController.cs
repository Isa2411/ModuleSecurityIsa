using Entity.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Interface
{
    public interface IViewController
    {
        public Task Delete(int id);
        public Task<IEnumerable<ViewDto>> GetAll();
        public Task<IEnumerable<DataSelectDto>> GetAllSelect();
        public Task<ViewDto> GetById(int id);
        public Task<ViewDto> Save(ViewDto viewDto);
        public Task Update(ViewDto viewDto);
    }
}
