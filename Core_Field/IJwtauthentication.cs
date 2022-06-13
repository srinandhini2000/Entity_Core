using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_Field
{
    public interface IJwtauthentication
    {
        string Authenticate(string username, string password);
    }
}
