using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DBCon
{
    [Table("tbl_Refreshtoken")]
    public class Refreshusing
    {
        [Key]
        public string Userid { get; set; }

        public string Tokenid { get; set; }

        public string Refreshtoken { get; set; }

        public Boolean  IsActive { get; set; }
    }
}
