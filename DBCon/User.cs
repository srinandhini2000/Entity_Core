using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DBCon
{
    [Table("tbl_User")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "nvarchar(60)")]
        [Required]
        
        public string Firstname { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        [Required]
        public string Lastname { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        [Required]
        public string Companyname { get; set; }
        [Column(TypeName = "nvarchar(10)")]
        [Required]
        [StringLength(10, ErrorMessage = "The Mobile must contains 10 characters", MinimumLength = 10)]
        public string Phone { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [Required]
        [RegularExpression(".+@.+\\..+", ErrorMessage = "Please Enter Correct Email Address")]
        public string Email { get; set; }
        [Column(TypeName = "nvarchar(50)")]

        [Required(ErrorMessage = "Please Enter Password")]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
        [Column(TypeName = "nvarchar(50)")]

        [Required(ErrorMessage = "Please Enter Confirm Password")]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
      
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]

        public string Passwordagain { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        [Required]
        public string Timezone { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        [Required]
        public string Streetaddress_1 { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        [Required]
        public string Streetaddress_2 { get; set; }
        [Column(TypeName = "nchar(10)")]
        [Required]
        public string City { get; set; }
        [Column(TypeName = "nchar(10)")]
        [Required]
        public string State { get; set; }
        [Column(TypeName = "nchar(50)")]
        [Required]
        public string Zip { get; set; }
    }
}
