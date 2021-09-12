using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using WebAPIUI.Controllers.Login.Models;
using WebAPIUI.CustomExceptions.RegisterPerson;

namespace WebAPIUI.Controllers
{
    public class BaseAPIController : ApiController
    {
        /// <summary>
        /// Maneja los errores controlados.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="messages"></param>
        internal static void ThrowHandledException(RegisterPersonResponseType type, IList<string> messages)
        {
            var newException = new RegisterPersonException(type, messages);
            throw newException;
        }

        internal static void ThrowUnHandledException(RegisterPersonResponseType type, Exception ex)
        {
            throw new RegisterPersonException(type, ex.Message);
        }

        internal void SetResponseAsException(RegisterPersonResponseType code, RegisterPersonDataResponse response, string message)
        {
            response.ResponseCode = code;
            response.ResponseMessage = message;
            response.Content = false;
        }
    }
 
}