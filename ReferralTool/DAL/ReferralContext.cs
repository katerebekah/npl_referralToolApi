using ReferralTool.DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ReferralTool.DAL
{
    public class ReferralContext : DbContext
    {
        public virtual DbSet<Agency> Agencies { get; set; }
        public virtual DbSet<AgencyEmployee> AgencyEmployees { get; set; }
        public virtual DbSet<Referral> Referrals { get; set; }
        public virtual DbSet<RegisteredClient> RegisteredClients { get; set; }
        public virtual DbSet<ServiceCategory> ServiceCategories { get; set; }
    }
}