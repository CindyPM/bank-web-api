using BankBusiness.Interfaces;
using BankEntities.Enums;
using BankEntities.General;
using Microsoft.AspNetCore.Mvc;

namespace BankWebApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CountryController : ControllerBase
    {
        private readonly ICountryManager _CountryManager;

        public CountryController(ICountryManager CountryManager)
        {
            _CountryManager = CountryManager;
        }


        [HttpGet(Name = "GetCountries")]
        public GenericResponse<List<Country>> GetCountries()
        {
            var response = new GenericResponse<List<Country>>();

            try
            {
                response = _CountryManager.GetCountries();
            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.Message = Messages.ResponseFail;

            }

            return response;
        }
    }
}
