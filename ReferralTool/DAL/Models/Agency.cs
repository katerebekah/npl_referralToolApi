﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ReferralTool.DAL.Models
{
    public class Agency
    {
        [Key]
        public int AgencyID { get; set; }
        [Required]
        public string AgencyName { get; set; }
        [Required, MaxLength(5)]
        public int ZipCode { get; set; }
        [Required]
        public string EmailAddress { get; set; }
        [Required, MaxLength(3)]
        public int AreaCode { get; set; }
        [Required, MaxLength(8)]
        public string PhoneNumber { get; set; }
        [Required]
        public string PrimaryContactLastName { get; set; }
        [Required]
        public string PrimaryContactFirstName { get; set; }
        public string AltContactLastName { get; set; }
        public string AltContactFirstName { get; set; }
        [Required]
        public bool AgencyActiveIndicator { get; set; }
        public virtual ICollection<ServiceCategory> ServiceCategories { get; set; }
    }
}