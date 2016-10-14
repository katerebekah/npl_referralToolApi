using npl_referralTool.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace npl_referralTool.DAL
{
    public class AgencyRepository
    {
        private ReferralContext Context { get; set; }

        public AgencyRepository(ReferralContext context)
        {
            Context = context;
        }

        public AgencyRepository()
        {
            Context = new ReferralContext();
        }

        /*
         * Add 
         * Update
         * Delete
         * GetById
         * GetAll
         */

        public void Add(Agency agency)
        {
            Context.Agencies.Add(agency);
        }

        public void Update (Agency agency)
        {
            var currentAgency = Context.Agencies.FirstOrDefault(x => x.AgencyID == agency.AgencyID);
            if (currentAgency != null)
            {
                currentAgency.AgencyActiveIndicator = agency.AgencyActiveIndicator;
                currentAgency.AgencyName = agency.AgencyName;
                currentAgency.AltContactFirstName = agency.AltContactFirstName;
                currentAgency.AltContactLastName = agency.AltContactLastName;
                currentAgency.AreaCode = agency.AreaCode;
                currentAgency.EmailAddress = agency.EmailAddress;
                currentAgency.PhoneNumber = agency.PhoneNumber;
                currentAgency.PrimaryContactFirstName = agency.PrimaryContactFirstName;
                currentAgency.PrimaryContactLastName = agency.PrimaryContactLastName;
                currentAgency.ZipCode = agency.ZipCode;
                //TODO
                currentAgency.ServiceCategories = agency.ServiceCategories;
            }
            Context.SaveChanges();
        }
        
        public void Delete(int id)
        {
            var currentAgency = Context.Agencies.FirstOrDefault(x => x.AgencyID == id);
            if (currentAgency != null)
            {
                Context.Agencies.Remove(currentAgency);
            }
            Context.SaveChanges();
        }

        public Agency GetById(int id)
        {
            return Context.Agencies.FirstOrDefault(x => x.AgencyID == id);
        }

        public List<Agency> GetAll()
        {
            return Context.Agencies.ToList();
        }
    }
}