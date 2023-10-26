using BankEntities.General;

namespace BankBusiness.Interfaces
{
    public interface IFinantialProductManager
    {
        GenericResponse<bool> CreateFinantialProduct(Client client);
        GenericResponse<bool> DepositOrWithdrawal(DepositOrDrawal depositOrDrawal);
        GenericResponse<dynamic> GetFinantialProducts();
        GenericResponse<bool> CancelFinantialProduct(FinantialProductCancel finantialProductCancel);
        GenericResponse<List<FinantialProductProjectionResponse>> ProjectionOfBalance(FinantialProductProjection finantialProductProjection);
    }
}
