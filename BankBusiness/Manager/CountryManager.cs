using BankBusiness.Interfaces;
using BankData;
using BankEntities.Enums;
using BankEntities.General;
using System.Text.Json;

namespace BankBusiness.Manager
{
    public class CountryManager : ICountryManager
    {
        private readonly BankDbContext _context;
        public CountryManager(BankDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Método que permite obtener listado de paises
        /// </summary>
        /// <returns></returns>
        public GenericResponse<List<Country>> GetCountries()
        {
            var objResponse = new GenericResponse<List<Country>>();
            try
            {
                var country = _context.Country.ToList();

                if (country != null)
                {
                    objResponse.Data = JsonSerializer.Deserialize<List<Country>>(JsonSerializer.Serialize(country));
                    objResponse.IsValid = true;
                    objResponse.Message = Messages.ResponseOk;
                }
                else
                {
                    objResponse.IsValid = true;
                    objResponse.Message = Messages.NotFound;
                }
            }

            catch (Exception ex)
            {
                objResponse.IsValid = false;
                objResponse.Message = Messages.ResponseException;
            }

            return objResponse;
        }
    }
}
