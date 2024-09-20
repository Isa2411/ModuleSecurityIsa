using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Dto;
using Entity.Model.Security;

namespace Data.Interfaces
{
    public interface IPersonData
    {
        public Task Delete(int id);
        public Task<IEnumerable<Person>> GetAll();
        public Task<Person> GetById(int id);
        public Task<Person> GetByFirst_name(string First_name);
        public Task<Person> Save(Person entity);
        public Task UpdatedAt(Person entity);
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
    }
}
