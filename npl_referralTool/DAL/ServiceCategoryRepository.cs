using npl_referralTool.DAL;
using npl_referralTool.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReferralTool.DAL
{
    public class ServiceCategoryRepository
    {
        private ReferralContext Context { get; set; }
        public ServiceCategoryRepository(ReferralContext context)
        {
            Context = context;
        }
        public ServiceCategoryRepository()
        {
            Context = new ReferralContext();
        }

        /*
         * Add
         * Update
         * Delete
         * GetAll
         * GetById
         */


        public void Add(ServiceCategory serviceCategory)
        {
            Context.ServiceCategories.Add(serviceCategory);
            Context.SaveChanges();
        }

        public void Update(ServiceCategory serviceCategory)
        {
            var currentServiceCategory = Context.ServiceCategories.FirstOrDefault(x => x.ServiceCategoryID == serviceCategory.ServiceCategoryID);
            if (currentServiceCategory != null)
            {
                currentServiceCategory.ActiveIndicator = serviceCategory.ActiveIndicator;
                currentServiceCategory.ServiceCategoryName = serviceCategory.ServiceCategoryName;
                currentServiceCategory.ServiceDescription = serviceCategory.ServiceDescription;
            }
            Context.SaveChanges();
        }

        public void Delete(int id)
        {
            var currentServiceCategory = Context.ServiceCategories.FirstOrDefault(x => x.ServiceCategoryID == id);
            if (currentServiceCategory != null)
            {
                Context.ServiceCategories.Remove(currentServiceCategory);
            }
            Context.SaveChanges();
        }

        public List<ServiceCategory> GetAll()
        {
            return Context.ServiceCategories.ToList();
        }

        public ServiceCategory GetById(int id)
        {
            return Context.ServiceCategories.FirstOrDefault(x => x.ServiceCategoryID == id);
        }
    }
}