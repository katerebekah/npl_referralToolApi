using npl_referralTool.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace npl_referralTool.DAL
{
    public class ReferralRepository
    {
        private ReferralContext Context { get; set; }
        
        public ReferralRepository(ReferralContext context)
        {
            Context = context;
        }

        public ReferralRepository()
        {
            Context = new ReferralContext();
        }

        /*
         * Add
         * Update
         * Delete
         * GetById
         * GetByClientId
         * GetAll
         * GetByServiceCategoryId
         */

        public void Add(Referral referral)
        {
            Context.Referrals.Add(referral);
            Context.SaveChanges();
        }

        public void Update(Referral referral)
        {
            var currentReferral = Context.Referrals.FirstOrDefault(x => x.ReferralID == referral.ReferralID);
            if (currentReferral != null)
            {
                currentReferral.Agency = referral.Agency;
                currentReferral.AgencyEmployee = referral.AgencyEmployee;
                currentReferral.DateRequested = referral.DateRequested;
                currentReferral.DateServiceRendered = referral.DateServiceRendered;
                currentReferral.ReferralID = referral.ReferralID;
                currentReferral.RegisteredClient = referral.RegisteredClient;
                currentReferral.ServiceCategory = referral.ServiceCategory;
                currentReferral.ServiceInProgress = referral.ServiceInProgress;
                currentReferral.ServiceRendered = referral.ServiceRendered;
            }
            Context.SaveChanges();
        }

        public void Delete(int id)
        {
            var currentReferral = Context.Referrals.FirstOrDefault(x => x.ReferralID == id);
            if (currentReferral != null)
            {
                Context.Referrals.Remove(currentReferral);
            }
            Context.SaveChanges();
        }

        public Referral GetById(int id)
        {
            return Context.Referrals.FirstOrDefault(x => x.ReferralID == id);
        }

        public List<Referral> GetByClientId(int id)
        {
            return Context.Referrals.Where(x => x.RegisteredClient.RegisteredClientID == id).ToList();
        }

        public List<Referral> GetAll()
        {
            return Context.Referrals.ToList();
        }

        public List<Referral> GetByServiceCategoryId(int id)
        {
            return Context.Referrals.Where(x => x.ServiceCategory.ServiceCategoryID == id).ToList();
        }
    }
}