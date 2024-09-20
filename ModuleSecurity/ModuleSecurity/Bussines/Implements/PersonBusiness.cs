using Bussines.Interfaces;
using Data.Interfaces;
using Entity.DTO;
using Entity.Model.Security;

namespace Bussines.Implements
{
    public class PersonBusiness : IPersonBusiness
    {
        protected readonly IPersonData data;

        public PersonBusiness(IPersonData data)
        {
            this.data = data;
        }

        public async Task Delete(int id)
        {
            await this.data.Delete(id);
        }

        public async Task<IEnumerable<PersonDto>> GetAll()
        {
            IEnumerable<Person> persons = await this.data.GetAll();
            var personDtos = persons.Select(person => new PersonDto
            {
                Id = person.Id,
                First_name = person.First_name,
            });
            return personDtos;
        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            return await this.data.GetAllSelect();
        }

        public Task<PersonDto> GetByFirst_name(string First_name)
        {
            throw new NotImplementedException();
        }

        public async Task<PersonDto> GetById(int id)
        {

            Person person = await this.data.GetById(id);
            PersonDto personDto = new PersonDto();

            personDto.Id = person.Id;
            personDto.First_name = person.First_name;
            return personDto;
        }
        public Person mapData(Person person, PersonDto entity)
        {
            person.Id = entity.Id;
            person.First_name = entity.First_name;
            return person;
        }

        public async Task<Person> Save(PersonDto entity)
        {
            Person person = new Person();
            person.CreatedAt = DateTime.Now.AddHours(-5);
            person = this.mapData(person, entity);

            return await this.data.Save(person);
        }

        public async Task Update(PersonDto entity)
        {
            Person person = await this.data.GetById(entity.Id);
            if (person == null)
            {
                throw new Exception("Registro NO encontrado");
            }
            person = this.mapData(person, entity);
            await this.data.Update(person);
        }
    }
}
