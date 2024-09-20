using Entity.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Interface
{
    public interface IModuloController
    {
        Task<ActionResult<IEnumerable<ModuleDto>>> GetAll();
        Task<ActionResult<ModuleDto>> Save([FromBody] ModuleDto dataModuleDto);
        Task<IActionResult> Update([FromBody] ModuleDto dataModuleDto);
        Task<IActionResult> Delete(int id);
    }
}
