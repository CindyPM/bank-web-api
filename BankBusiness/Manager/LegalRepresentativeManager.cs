using BankBusiness.Interfaces;
using BankData;
using BankEntities.Enums;
using BankEntities.General;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace BankBusiness.Manager
{
    public class LegalRepresentativeManager : ILegalRepresentativeManager
    {
        private readonly BankDbContext _context;
        public LegalRepresentativeManager(BankDbContext context)
        {
            _context = context;
        }

        public GenericResponse<int> CreateOrUpdateLegalRepresentative(LegalRepresentative legalRepresentative)
        {
            var objResponse = new GenericResponse<int>();
            var objLegalRepresentative = JsonSerializer.Deserialize<BankData.Model.LegalRepresentative>(JsonSerializer.Serialize(legalRepresentative));

            try
            {
                if (legalRepresentative.IdLegalRepresentative != 0)
                {
                    _context.LegalRepresentative.Update(objLegalRepresentative);
                }
                else
                {
                    _context.LegalRepresentative.Add(objLegalRepresentative);
                }

                _context.SaveChanges();

                objResponse.Data = objLegalRepresentative.IdLegalRepresentative;
                objResponse.IsValid = true;
                objResponse.Message = Messages.ResponseOk;
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
