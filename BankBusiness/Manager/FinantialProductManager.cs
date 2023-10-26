using BankBusiness.Interfaces;
using BankData;
using BankEntities.Enums;
using BankEntities.General;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;

namespace BankBusiness.Manager
{
    public class FinantialProductManager : IFinantialProductManager
    {
        private readonly BankDbContext _context;
        private readonly ILegalRepresentativeManager _legalRepresentative;
        private readonly IClientManager _clientManager;
        public FinantialProductManager(BankDbContext context, IClientManager clientManager, ILegalRepresentativeManager legalRepresentative)
        {
            _context = context;
            _clientManager = clientManager;
            _legalRepresentative = legalRepresentative;
        }

        /// <summary>
        /// Método que permite crear un nuevo producto para el cliente
        /// </summary>
        /// <returns></returns>
        public GenericResponse<bool> CreateFinantialProduct(Client client)
        {
            var objResponse = new GenericResponse<bool>();

            try
            {
                objResponse = _clientManager.CreateOrUpdateClient(client);

            }

            catch (Exception ex)
            {
                objResponse.IsValid = false;
                objResponse.Message = Messages.ResponseException;
            }

            return objResponse;
        }


        /// <summary>
        /// Método que permite depositar o retirar un monto
        /// </summary>
        /// <returns></returns>
        public GenericResponse<bool> DepositOrWithdrawal(DepositOrDrawal depositOrDrawal)
        {
            var objResponse = new GenericResponse<bool>();

            try
            {
                var client = _context.Client
                    .Include(m => m.SavingsAccount)
                    .Include(m => m.CurrentAccount)
                    .Include(m => m.CDT)
                    .Where(x => x.IdentificationNumber == depositOrDrawal.NumIdentification
                   && ((depositOrDrawal.TypeProduct == (int)Enums.TypeProduct.SavingsAccount && x.SavingsAccount != null && x.SavingsAccount.State == true)
                   || (depositOrDrawal.TypeProduct == (int)Enums.TypeProduct.CurrentAccount && x.CurrentAccount != null && x.CurrentAccount.State == true)
                   )).FirstOrDefault();

                if (client != null)
                {
                    if (client.SavingsAccount != null || client.CurrentAccount != null)
                    {
                        if ((depositOrDrawal.Action == (int)Enums.Action.Deposit)
                            || (depositOrDrawal.Action == (int)Enums.Action.Withdrawal &&
                            (client.SavingsAccount != null && depositOrDrawal.Amount <= client.SavingsAccount?.Balance) ||
                            (client.CurrentAccount != null && depositOrDrawal.Amount <= client.CurrentAccount?.Balance)))
                        {
                            if (depositOrDrawal.TypeProduct == (int)Enums.TypeProduct.SavingsAccount)
                            {
                                var newBalance = depositOrDrawal.Action == (int)Enums.Action.Deposit
                                ? client.SavingsAccount.Balance + depositOrDrawal.Amount
                                : client.SavingsAccount.Balance - depositOrDrawal.Amount;
                                client.SavingsAccount.Balance = newBalance;
                                _context.SavingsAccount.Update(client.SavingsAccount);
                            }
                            else
                            {
                                var newBalance = depositOrDrawal.Action == (int)Enums.Action.Deposit
                                ? client.CurrentAccount.Balance + depositOrDrawal.Amount
                                : client.CurrentAccount.Balance - depositOrDrawal.Amount;
                                client.CurrentAccount.Balance = newBalance;
                                _context.CurrentAccount.Update(client.CurrentAccount);
                            }

                            _context.SaveChanges();

                            objResponse.IsValid = true;
                            objResponse.Message = Messages.ResponseOk;
                        }
                        else
                        {
                            objResponse.IsValid = false;
                            objResponse.Message = Messages.ExceedsAmount;
                        }
                    }
                    else
                    {
                        objResponse.IsValid = false;
                        objResponse.Message = Messages.ProductNotFound;
                    }
                }
                else
                {
                    objResponse.IsValid = false;
                    objResponse.Message = Messages.ProductNotFound;
                }
            }

            catch (Exception ex)
            {
                objResponse.IsValid = false;
                objResponse.Message = Messages.ResponseException;
            }

            return objResponse;
        }

        /// <summary>
        /// Método que obtener todos los productos financierps
        /// </summary>
        /// <returns></returns>
        public GenericResponse<dynamic> GetFinantialProducts()
        {
            var objResponse = new GenericResponse<dynamic>();

            try
            {
                var savingsAccount = _context.Client
                    .Include(m => m.SavingsAccount)
                    .IgnoreAutoIncludes()
                    .Where(c => c.SavingsAccount!.State == true)
                    .Select(x => new BankData.Model.Client{ Name = x.Name,  
                        IdClient = x.IdClient,  
                        IdentificationNumber = x.IdentificationNumber, 
                        SavingsAccount = x.SavingsAccount  })
                    .ToList();

                var currentAccount = _context.Client
                    .Include(m => m.CurrentAccount)
                    .IgnoreAutoIncludes()
                    .Where(c => c.CurrentAccount!.State == true)
                    .Select(x => new BankData.Model.Client { Name = x.Name,
                        IdClient = x.IdClient,
                        IdentificationNumber = x.IdentificationNumber, 
                        CurrentAccount = x.CurrentAccount })
                    .ToList();

                var cdt = _context.Client
                    .Include(m => m.CDT)
                    .IgnoreAutoIncludes()
                    .Where(c => c.CDT!.State == true)
                    .Select(x => new BankData.Model.Client { Name = x.Name,
                        IdClient = x.IdClient,
                        IdentificationNumber = x.IdentificationNumber, 
                        CDT = x.CDT })
                    .ToList();

                var listClients = savingsAccount.Concat(currentAccount).ToList().Concat(cdt).ToList();

                if (listClients != null)
                {
                    objResponse.Data = listClients;
                    objResponse.IsValid = true;
                    objResponse.Message = Messages.ResponseOk;

                }
                else
                {
                    objResponse.IsValid = false;
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

        /// <summary>
        /// Método que obtener todos los productos financierps
        /// </summary>
        /// <returns></returns>
        public GenericResponse<bool> CancelFinantialProduct(FinantialProductCancel finantialProductCancel)
        {
            var objResponse = new GenericResponse<bool>();

            try
            {
                var client = _context.Client
                    .Include(m => m.SavingsAccount)
                    .Include(m => m.CurrentAccount)
                    .Include(m => m.CDT)
                    .Where(x => x.IdClient == finantialProductCancel.IdClient).ToList();

                var product = client.Find(x =>
                    finantialProductCancel.IdFinantialProduct == x.IdCDT
                   || finantialProductCancel.IdFinantialProduct == x.IdCurrentAccount
                   || finantialProductCancel.IdFinantialProduct == x.IdSavingsAccount);


                if (client != null && product != null)
                {

                    var savingsAccount = client.Find(x => x.IdSavingsAccount != null);
                    var currentAccount = client.Find(x => x.IdCurrentAccount != null);
                    var cdt = client.Find(x => x.IdCDT != null);

                    if (finantialProductCancel.FinantialProductType == (int)Enums.TypeProduct.CDT
                        && savingsAccount == null)
                    {
                        objResponse.IsValid = false;
                        objResponse.Message = Messages.SavingAccountNotFound;
                    }
                    else
                    {
                        if ((finantialProductCancel.FinantialProductType == (int)Enums.TypeProduct.CurrentAccount
                            && currentAccount!.CurrentAccount?.Balance == 0) ||
                            (finantialProductCancel.FinantialProductType == (int)Enums.TypeProduct.SavingsAccount
                            && savingsAccount!.SavingsAccount?.Balance == 0) ||
                            finantialProductCancel.FinantialProductType == (int)Enums.TypeProduct.CDT)
                        {
                            if (finantialProductCancel.FinantialProductType == (int)Enums.TypeProduct.CurrentAccount)
                            {
                                currentAccount!.CurrentAccount!.State = false;
                                _context.CurrentAccount.Update(currentAccount.CurrentAccount);

                            }
                            else if (finantialProductCancel.FinantialProductType == (int)Enums.TypeProduct.SavingsAccount)
                            {
                                savingsAccount!.SavingsAccount!.State = false;
                                _context.SavingsAccount.Update(savingsAccount.SavingsAccount);
                            }
                            else
                            {
                                savingsAccount!.SavingsAccount!.Balance = savingsAccount.SavingsAccount.Balance + cdt!.CDT!.Balance;
                                cdt.CDT!.State = false;
                                cdt.CDT!.Balance = 0;
                                _context.SavingsAccount.Update(savingsAccount.SavingsAccount);
                                _context.CDT.Update(cdt.CDT);
                            }

                            _context.SaveChanges();

                            objResponse.Data = true;
                            objResponse.IsValid = true;
                            objResponse.Message = Messages.ResponseOk;
                        }

                        else
                        {
                            objResponse.IsValid = false;
                            objResponse.Message = Messages.ProductWithBalance;
                        }
                    }
                }
                else
                {
                    objResponse.IsValid = false;
                    objResponse.Message = Messages.ProductNotFound;
                }
            }

            catch (Exception ex)
            {
                objResponse.IsValid = false;
                objResponse.Message = Messages.ResponseException;
            }

            return objResponse;
        }

        /// <summary>
        /// Método que obtener realizar la proyección del saldo
        /// </summary>
        /// <returns></returns>
        public GenericResponse<List<FinantialProductProjectionResponse>> ProjectionOfBalance(FinantialProductProjection finantialProductProjection)
        {
            var objResponse = new GenericResponse<List<FinantialProductProjectionResponse>>();
            var listBalances = new List<FinantialProductProjectionResponse>();
            DateTime actualDate = DateTime.Now;
            int month = actualDate.Month;

            try
            {
                for (int i = 1; i <= 12; i++)
                {
                    month++;
                    if(month == 13)
                    {
                        month = 1;
                    } 

                    var interesRate = Decimal.ToDouble(finantialProductProjection.InterestRate / 100);
                    var newBalance = finantialProductProjection.Balance * Math.Pow(1 + interesRate, i); //balance*(1+interesRate)^mes 
                    listBalances.Add(new FinantialProductProjectionResponse { 
                        Month = DateAndTime.MonthName(month).ToUpper(), 
                        Balance = Math.Round(newBalance, 2)
                    });   
                }

                objResponse.Data = listBalances;    
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
