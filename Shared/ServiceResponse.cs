using CakeStore.Shared.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeStore.Shared
{
    public class ServiceResponse<T>
    {
        public T? Data { get; set; }

        public bool Success { get; set; } = true;

        public string Message { get; set; } = string.Empty;

        public static implicit operator ServiceResponse<T>(ServiceResponse<List<Category>> v)
        {
            throw new NotImplementedException();
        }
    }
}
