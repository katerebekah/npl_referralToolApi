using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace npl_referralTool.DAL.Models
{
    public class ServiceCategory
    {
        [Key]
        public int ServiceCategoryID { get; set; }
        [Required]
        public string ServiceCategoryName { get; set; }

        public string ServiceDescription { get; set; }
        [Required]
        public bool ActiveIndicator { get; set; }
    }
}