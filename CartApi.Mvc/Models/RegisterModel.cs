using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CartApi.Mvc.Models
{
    public class RegisterModel
    {
        [RegularExpression(@"^(?=[a-zA-Z0-9._]{8,20}$)(?!.*[_.]{2})[^_.].*[^_.]$",ErrorMessage = "UserName is incorrect format")]
        public string UserName { get; set; }
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%_*#?&-])[A-Za-z\d@$!%*_#?&-]{8,}$", ErrorMessage ="Password İs İn Incorrect Format")]
        public string Password { get; set; }
    }
}