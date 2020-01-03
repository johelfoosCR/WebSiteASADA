using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAsada.Global
{
    public class Constants
    {
        public const string JAVASCRIPT_SUCCESS_FUNCTION = "showSuccessMessage();";
        public const string JAVASCRIPT_UPDATE_FUNCTION = "showUpdateMessage();";
        public const string JAVASCRIPT_DELETE_FUNCTION = "showDeleteMessage();";
        public const string TWO_DECIMALS_REGEX_EXPRESSION = @"^[0-9]+(\.[0-9]{1,2})?$";
        public static string JAVASCRIPT_WHIT_MESSAGE_FUNCTION = "showInformationMessage({0});";
        public const string TWO_DECIMALS_VALIDATION_MESSAGE = "Solo se permiten montos con 2 decimales";
    }
}
