using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Business.Utilities.Constant.Messages
{
    public class Messages
    {
        public static string Deleted = "Silindi";
        public static string Success = "İşleminiz Başarılı";
        public static string Listed = "Listelendi";
        public static string Invalid = "İşleminiz Geçersiz";

        public static string CustomerAlreadyExistError = "The Customer to be added is already exist.";

        public static string CustomerAddedSuccessfully = "The Customer added successfully.";
        public static string AuthorizationDenied = "Authorization denied";

        public static string CustomerNotExistError = "Customer can not be found";

        public static string CustomerRegistered = "Customer registered";

        public static string CustomerAlreadyRegisteredError = "Customer already registered";

        public static string LoginSuccessfully = "Login succesfull";

        public static string AccessTokenCreated = "Access token created";

        public static string PasswordError = "Password wrong";
    }
}
