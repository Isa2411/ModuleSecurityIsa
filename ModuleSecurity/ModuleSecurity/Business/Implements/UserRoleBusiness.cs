using Business.Interface;
using Data.Interfaces;
using Entity.Dto;
using Entity.Model.Security;

namespace Business.Implements
{
    public class UserRoleBusiness : IUserRoleBusiness
    {
        protected readonly IUserRoleData data;

        public UserRoleBusiness(IUserRoleData data)
        {
            this.data = data;
        }

        public async Task Delete(int id)
        {
            await this.data.Delete(id);
        }

        public async Task<IEnumerable<UserRoleDto>> GetAll()
        {
            IEnumerable<UserRole> userroles = await this.data.GetAll();
            var userroleDtos = userroles.Select(userrole => new UserRoleDto
            {
                Id = userrole.Id,
                IdUser = userrole.IdUser,
                IdRole = userrole.IdRole,
                State = userrole.State,
            });
            return userroleDtos;
        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            return await this.data.GetAllSelect();
        }

        public async Task<UserRoleDto> GetById(int id)
        {

            UserRole userrole = await this.data.GetById(id);
            UserRoleDto userroleDto = new UserRoleDto();

            userroleDto.Id = userrole.Id;
            userroleDto.IdUser = userrole.IdUser;
            userroleDto.IdRole = userrole.IdRole;
            userroleDto.State = userrole.State;
            return userroleDto;
        }

        public UserRole mapData(UserRole userRole, UserRoleDto entity)
        {
            userRole.Id = entity.Id;
            userRole.IdUser = entity.IdUser;
            userRole.IdRole = entity.IdRole;
            userRole.State = entity.State;
            return userRole;
        }

        public async Task<UserRole> Save(UserRoleDto entity)
        {
            UserRole userrole = new UserRole
            {
                CreateAt = DateTime.Now.AddHours(-5)
            };
            userrole = this.mapData(userrole, entity);
            userrole.User = null;
            userrole.Role = null;

            return await this.data.Save(userrole);
        }

        public async Task Update(UserRoleDto entity)
        {
            UserRole userrole = await this.data.GetById(entity.Id);
            if (userrole == null)
            {
                throw new Exception("Registro NO encontrado");
            }
            userrole = this.mapData(userrole, entity);
            await this.data.Update(userrole);
        }

        Task<UserRoleDto> IUserRoleBusiness.Save(UserRoleDto entity)
        {
            throw new NotImplementedException();
        }
    }
}