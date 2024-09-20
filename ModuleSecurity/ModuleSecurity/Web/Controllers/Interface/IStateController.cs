using Entity.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Interface
{
    public interface IStateController
    {
        public Task<ActionResult<IEnumerable<StateDto>>> GetAll();
        public Task<ActionResult<StateDto>> Save([FromBody] StateDto dataStateDto);
        public Task<IActionResult> Update([FromBody] StateDto dataStateDto);
        public Task<IActionResult> Delete(int id);
    }
}
