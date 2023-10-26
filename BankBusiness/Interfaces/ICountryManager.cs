using BankEntities.General;

namespace BankBusiness.Interfaces
{
    public interface ICountryManager
    {
        GenericResponse<List<Country>> GetCountries();
    }
}
