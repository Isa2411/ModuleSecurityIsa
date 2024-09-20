using Business.Interface;
using Data.Interfaces;
using Entity.Dto;
using Entity.Model.Security;

namespace Business.Implements
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
                Last_name = person.Last_name,
                Addres = person.Addres,
                TypeDocument = person.TypeDocument,
                Document = person.Document,
                Birth_of_date = person.Birth_of_date,
                Phone = person.Phone,
                State = person.State,
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
            personDto.Last_name = person.Last_name;
            personDto.Addres = person.Addres;
            personDto.TypeDocument = person.TypeDocument;
            personDto.Document = person.Document;
            personDto.Birth_of_date = person.Birth_of_date;
            personDto.Phone = person.Phone;
            personDto.State = person.State;
            return personDto;
        }
        public Person mapData(Person person, PersonDto entity)
        {
            person.Id = entity.Id;
            person.First_name = entity.First_name;
            person.Last_name = entity.Last_name;
            person.Addres = entity.Addres;
            person.TypeDocument = entity.TypeDocument;
            person.Document = entity.Document;
            person.Birth_of_date = entity.Birth_of_date;
            person.Phone = entity.Phone;
            person.State = entity.State;
            return person;
        }

        public async Task<Person> Save(PersonDto entity)
        {
            Person person = new Person
            {
                CreatedAt = DateTime.Now.AddHours(-5)
            };

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
            await this.data.UpdatedAt(person);
        }

        Task<PersonDto> IPersonBusiness.Save(PersonDto entity)
        {
            throw new NotImplementedException();
        }
    }
}