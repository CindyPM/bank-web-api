using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankEntities.General
{
    public class GenericResponse<T>
    {
        public bool IsValid { get; set; }
        public string Message { get; set; }
        public T? Data { get; set; }
    }
}
