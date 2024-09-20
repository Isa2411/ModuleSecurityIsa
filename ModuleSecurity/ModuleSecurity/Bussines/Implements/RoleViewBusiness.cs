using Bussines.Interfaces;
using Data.Interfaces;
using Entity.DTO;
using Entity.Model.Security;

namespace Bussines.Implements
{
    public class RoleViewBusiness : IRoleViewBusiness
    {
        protected readonly IRoleViewData data;

        public RoleViewBusiness(IRoleViewData data)
        {
            this.data = data;
        }

        public async Task Delete(int id)
        {
            await this.data.Delete(id);
        }

        public async Task<IEnumerable<RoleViewDto>> GetAll()
        {
            IEnumerable<RoleView> roleviews = await this.data.GetAll();
            var roleviewDtos = roleviews.Select(roleview => new RoleViewDto
            {
                Id = roleview.Id,
                IdRole = roleview.IdRole,
                IdView = roleview.IdView,
                State = roleview.State,
            });
            return roleviewDtos;
        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            return await this.data.GetAllSelect();
        }

        public async Task<RoleViewDto> GetById(int id)
        {

            RoleView roleview = await this.data.GetById(id);
            RoleViewDto roleviewDto = new RoleViewDto();

            roleviewDto.Id = roleview.Id;
            roleviewDto.IdRole = roleview.IdRole;
            roleviewDto.IdView = roleview.IdView;
            roleviewDto.State = roleview.State;
            return roleviewDto;
        }
        public RoleView mapData(RoleView roleview, RoleViewDto entity)
        {
            roleview.Id = entity.Id;
            roleview.IdRole = entity.IdRole;
            roleview.IdView = entity.IdView;
            roleview.State = entity.State;
            return roleview;
        }

        public async Task<RoleView> Save(RoleViewDto entity)
        {
            RoleView roleview = new RoleView();
            roleview.CreatedAt = DateTime.Now.AddHours(-5);
            roleview = this.mapData(roleview, entity);
            roleview.Role = null;
            roleview.View = null;

            return await this.data.Save(roleview);
        }

        public async Task Update(RoleViewDto entity)
        {
            RoleView roleview = await this.data.GetById(entity.Id);
            if (roleview == null)
            {
                throw new Exception("Registro NO encontrado");
            }
            roleview = this.mapData(roleview, entity);
            await this.data.Update(roleview);
        }

        public Task Update(ViewDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
