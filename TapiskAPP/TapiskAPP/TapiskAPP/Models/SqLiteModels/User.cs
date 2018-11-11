using System;
using System.Collections.Generic;
using System.Text;

namespace TapiskAPP.Models.SqLiteModels
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Token { get; set; }
        public long CreatedToken { get; set; }
        public int RememberToken { get; set; }
    }
}
