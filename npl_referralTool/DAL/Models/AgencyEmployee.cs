using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace npl_referralTool.DAL.Models
{
    public class AgencyEmployee
    {
        [Key]
        public int EmployeeID { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        public string EmailAddress { get; set; }
        [Required, MaxLength(3)]
        public int AreaCode { get; set; }
        [Required, MaxLength(8)]
        public string PhoneNumber { get; set; }
        public Agency Agency { get; set; }
        public virtual ICollection<ServiceCategory> ServiceCategories { get; set; }
    }
}