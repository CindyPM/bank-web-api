using BankEntities.General;

namespace BankBusiness.Interfaces
{
    public interface IClientManager
    {
        GenericResponse<Client> GetClientByIdAndProduct(string identificationNumber, int product);
        GenericResponse<bool> CreateOrUpdateClient(Client client);
    }
}
