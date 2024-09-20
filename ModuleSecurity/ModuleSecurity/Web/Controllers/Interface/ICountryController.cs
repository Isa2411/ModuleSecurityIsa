using Entity.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Interface
{
    public interface ICountryController
    {
        Task<ActionResult<IEnumerable<CountryDto>>> GetAll();
        Task<ActionResult<CountryDto>> Save([FromBody] CountryDto dataCountryDto);
        Task<IActionResult> Update([FromBody] CountryDto dataCountryDto);
        Task<IActionResult> Delete(int id);
    }
}
