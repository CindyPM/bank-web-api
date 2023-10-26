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
    public class FinantialProductController : ControllerBase
    {
        private readonly IFinantialProductManager _finantialProductManager;

        public FinantialProductController(IFinantialProductManager finantialProductManager)
        {
            _finantialProductManager = finantialProductManager;
        }


        [HttpPost(Name = "CreateFinantialProduct")]
        public GenericResponse<bool> CreateFinantialProduct([FromBody] Client client)
        {
            var response = new GenericResponse<bool>();

            try
            {
                response = _finantialProductManager.CreateFinantialProduct(client);
            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.Message = Messages.ResponseFail;

            }

            return response;
        }

        [HttpPost(Name = "DepositOrWithdrawal")]
        public GenericResponse<bool> DepositOrWithdrawal([FromBody] DepositOrDrawal depositOrDrawal)
        {
            var response = new GenericResponse<bool>();

            try
            {
                response = _finantialProductManager.DepositOrWithdrawal(depositOrDrawal);
            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.Message = Messages.ResponseFail;

            }

            return response;
        }

        [HttpGet(Name = "GetFinantialProducts")]
        public GenericResponse<dynamic> GetFinantialProducts()
        {
            var response = new GenericResponse<dynamic>();

            try
            {
                response = _finantialProductManager.GetFinantialProducts();
            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.Message = Messages.ResponseFail;

            }

            return response;
        }

        [HttpPost(Name = "CancelFinantialProduct")]
        public GenericResponse<bool> CancelFinantialProduct([FromBody] FinantialProductCancel finantialProductCancel)
        {
            var response = new GenericResponse<bool>();

            try
            {
                response = _finantialProductManager.CancelFinantialProduct(finantialProductCancel);
            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.Message = Messages.ResponseFail;

            }

            return response;
        }

        [HttpPost(Name = "ProjectionOfBalance")]
        public GenericResponse<List<FinantialProductProjectionResponse>> ProjectionOfBalance([FromBody] FinantialProductProjection finantialProductProjection)
        {
            var response = new GenericResponse<List<FinantialProductProjectionResponse>>();

            try
            {
                response = _finantialProductManager.ProjectionOfBalance(finantialProductProjection);
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
