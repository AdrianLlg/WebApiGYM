using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIUI.CustomExceptions.ConsultaDisciplinasDeportista
{
    /// <summary>
    /// Enumerado de errores.
    /// </summary>
    public enum ConsultaDisciplinasDeportistaResponseType
    {
        /// <summary>
        /// Ok. No existe error.
        /// </summary>
        Ok = 0, 

        /// <summary>
        /// Parametros ingresados incorrectamente
        /// </summary>
        InvalidParameters = 1,

        /// <summary>
        /// No se encontraron registros.
        /// </summary>
        NoInformation = 2,


        /// <summary>
        /// Error no controlado
        /// </summary>
        Error = 3

    }

    /// <summary>
    /// ConsultaDisciplinasDeportista Exception
    /// </summary>
    public class ConsultaDisciplinasDeportistaException : Exception
    {
        /// <summary>
        /// Tipo de error.
        /// </summary>
        public ConsultaDisciplinasDeportistaResponseType Type { get; private set; }

        /// <summary>
        /// Tipo de error.
        /// </summary>
        public IList<string> MessageList { get; private set; }


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="type"></param>
        /// <param name="message"></param>
        public ConsultaDisciplinasDeportistaException(ConsultaDisciplinasDeportistaResponseType type, string message)
            : base(message)
        {
            this.Type = type;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="type"></param>
        /// <param name="messageList"></param>
        public ConsultaDisciplinasDeportistaException(ConsultaDisciplinasDeportistaResponseType type, IList<string> messageList)
            : base(JoinMessages(messageList))
        {
            this.Type = type;
            this.MessageList = messageList;
        }

        /// <summary>
        /// Une los mensajes.
        /// </summary>
        /// <param name="messageList"></param>
        /// <returns></returns>
        private static string JoinMessages(IList<string> messageList)
        {
            string res = string.Empty;
            if (messageList != null)
            {
                res = string.Join("|", messageList);
            }

            return res;
        }
    }
}