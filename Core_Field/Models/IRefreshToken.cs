using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_Field.Models
{
    public interface IRefreshToken
    {
        string GenerateToken(string username);
    }
}
