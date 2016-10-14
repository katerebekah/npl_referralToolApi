using Microsoft.AspNet.Identity.EntityFramework;
using npl_referralTool.DAL;
using npl_referralTool.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace npl_referralTool.DAL
{
    public class ReferralContext : IdentityDbContext<ApplicationUser>
    {
        public virtual DbSet<Agency> Agencies { get; set; }
        public virtual DbSet<AgencyEmployee> AgencyEmployees { get; set; }
        public virtual DbSet<Referral> Referrals { get; set; }
        public virtual DbSet<RegisteredClient> RegisteredClients { get; set; }
        public virtual DbSet<ServiceCategory> ServiceCategories { get; set; }

        public static ReferralContext Create()
        {
            return new ReferralContext();
        }
    }
}