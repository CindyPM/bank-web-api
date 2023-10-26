using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankEntities.Enums
{
    public static class Messages
    {
        public const string ResponseOk = "Transacción exitosa";
        public const string ResponseFail = "Error al realizar la transacción";
        public const string NotFound = "No se ha encontrado información.";
        public const string ProductNotFound = "No existe este producto asociado al cliente.";
        public const string SavingAccountNotFound = "No existe cuenta de ahorros asociada al cliente. Por favor dirijase a Asignar producto y cree una.";
        public const string ExceedsAmount = "El monto solicitado excede al saldo de la cuenta.";
        public const string ResponseException = "Error con el proveedor del servicio. Comuniquese con sistemas.";
        public const string ResponseFailProduct = "El cliente ya cuenta con este producto asociado.";
        public const string ProductWithBalance = "La cuenta aún tiene saldo. Por favor retirar el dinero antes de cancelar.";
    }
}
