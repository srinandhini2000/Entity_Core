using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using DBCon;

namespace Core_Field.Models
{
    public class RefreshToken : IRefreshToken
    {
        private readonly DatabaseContext db1;
        private IEnumerable<DatabaseContext> dbcontext;

        public RefreshToken(DatabaseContext db)
        {
            db1 = db;

        }

        public RefreshToken(IEnumerable<DatabaseContext> dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        public string GenerateToken(string username)
        {
            var randomnumber = new byte[32];
            using (var randomnumbergenerator = RandomNumberGenerator.Create())
            {
                randomnumbergenerator.GetBytes(randomnumber);
                string RefreshToken1 = Convert.ToBase64String(randomnumber);

                var user = db1.tbl_Refreshtoken.FirstOrDefault(o => o.Userid == username);
                if(user!=null)
                {
                    user.Refreshtoken = RefreshToken1;
                    db1.SaveChanges();
                }
                else
                {
                    Refreshusing tbl=new Refreshusing()
                    {
                        Userid=username,
                        Tokenid=new Random().Next().ToString(),
                        Refreshtoken= RefreshToken1,
                        IsActive=true

                    };
                }
                return RefreshToken1;
            }
        }
    }
}
