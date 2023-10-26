using BankBusiness.Interfaces;
using BankEntities.Enums;
using BankEntities.General;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Reflection;

namespace BankWebApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ClientController : ControllerBase
    {
        private readonly IClientManager _ClientManager;

        public ClientController(IClientManager ClientManager)
        {
            _ClientManager = ClientManager;
        }


        [HttpGet(Name = "GetClientByIdAndProduct")]
        public GenericResponse<Client> GetClientByIdAndProduct(string identificationNumber, int product)
        {
            var response = new GenericResponse<Client>();

            try
            {
                response = _ClientManager.GetClientByIdAndProduct(identificationNumber, product);
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
