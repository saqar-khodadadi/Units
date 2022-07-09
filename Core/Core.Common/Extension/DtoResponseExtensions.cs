using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Common.DtoHelper;

namespace Core.Common.Extension
{
    public static class DtoResponseExtensions
    {
        public static T ReturnWithIsSuccessful<T>(this T response, string message, bool isSuccessful) where T : DtoResponse
        {
            response.Message = message;
            response.IsSuccessful = isSuccessful;
            return response;
        }
    }
}
