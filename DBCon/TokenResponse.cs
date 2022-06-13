using System;
using System.Collections.Generic;
using System.Text;

namespace DBCon
{
    public class TokenResponse
    {
        public string JWTToken { get; set; }

        public string RefreshToken { get; set; }
    }
}
