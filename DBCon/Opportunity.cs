using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DBCon
{
    [Table("Opportunities")]
    public class Opportunity
    {
        [Key]
        public string Customer { get; set; }

        public string Created { get; set; }

        public string Modified { get; set; }

        public string Status { get; set; }

        public string Name_Number { get; set; }

        public string Address { get; set; }

        public string Salesperson { get; set; }

        public string Action { get; set; }

        public string Due_Date { get; set; }

    }
}
