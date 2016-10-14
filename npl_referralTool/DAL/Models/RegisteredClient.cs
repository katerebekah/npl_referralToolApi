using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace npl_referralTool.DAL.Models
{
    public class RegisteredClient
    {
        [Key]
        public int RegisteredClientID { get; set; }
        [Required]
        public string LastName { get; set; }
        public string FirstName { get; set; }
        [Required]
        public int AreaCode { get; set; }
        [Required, MaxLength(8)]
        public string PhoneNumber1 { get; set; }
        public int AreaCode2 { get; set; }
        [MaxLength(8)]
        public string PhoneNumber2 { get; set; }
        public string EmailAddress { get; set; }
        public string StreetAddress { get; set; }
        public string HouseNumber { get; set; }

        public int ZipCode { get; set; }
        public string Notes { get; set; }
        public virtual ICollection<Referral> Referrals { get; set; }
    }
}