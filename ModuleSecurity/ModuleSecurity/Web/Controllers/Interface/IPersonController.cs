using Entity.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Interface
{
    public interface IPersonController
    {
        public Task Delete(int id);
        public Task<IEnumerable<PersonDto>> GetAll();
        public Task<IEnumerable<DataSelectDto>> GetAllSelect();
        public Task<PersonDto> GetById(int id);
        public Task<PersonDto> Save(PersonDto personDto);
        public Task Update(PersonDto personDto);
    }
}
