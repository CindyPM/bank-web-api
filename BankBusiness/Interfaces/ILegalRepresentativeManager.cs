using BankEntities.General;

namespace BankBusiness.Interfaces
{
    public interface ILegalRepresentativeManager
    {
        GenericResponse<int> CreateOrUpdateLegalRepresentative(LegalRepresentative legalRepresentative);
    }
}
