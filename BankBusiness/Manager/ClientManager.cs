using BankBusiness.Interfaces;
using BankData;
using BankEntities.Enums;
using BankEntities.General;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace BankBusiness.Manager
{
    public class ClientManager: IClientManager
    {
        private readonly BankDbContext _context;
        public ClientManager(BankDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Método que permite ontener cliente por npumero de identificación
        /// </summary>
        /// <returns></returns>
        public GenericResponse<Client> GetClientByIdAndProduct(string identificationNumber, int product)
        {
            var objResponse = new GenericResponse<Client>();
            try
            {
                var client = _context.Client
                    .Include(c => c.CDT)
                    .Include(c => c.CurrentAccount)
                    .Include(c => c.SavingsAccount)
                    .FirstOrDefault(a => a.IdentificationNumber == identificationNumber);

                if (client != null)
                {
                    if ((product == 1 && client.SavingsAccount != null && client.SavingsAccount.State == true)
                        || (product == 2 && client.CurrentAccount != null && client.CurrentAccount.State == true)
                        || (product == 3 && client.CDT != null && client.CDT.State == true))
                    {
                        objResponse.IsValid = false;
                        objResponse.Message = Messages.ResponseFailProduct;
                    }
                    else
                    {
                        objResponse.Data = JsonSerializer.Deserialize<Client>(JsonSerializer.Serialize(client));
                        objResponse.IsValid = true;
                        objResponse.Message = Messages.ResponseOk;
                    }
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

        public GenericResponse<bool> CreateOrUpdateClient(Client client)
        {
            var objResponse = new GenericResponse<bool>();
            var objClient = JsonSerializer.Deserialize<BankData.Model.Client>(JsonSerializer.Serialize(client));

            try
            {
                if (client.IdClient != 0)
                {
                    _context.Client.Update(objClient);
                }
                else
                {
                    _context.Client.Add(objClient);
                }

                _context.SaveChanges();

                objResponse.Data = true;
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
