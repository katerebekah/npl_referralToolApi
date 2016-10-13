using System.Collections.Generic;
using System.Linq;
using ReferralTool.DAL.Models;

namespace ReferralTool.DAL
{
    public class RegisteredClientRepository
    {
        private ReferralContext _context = new ReferralContext();

        public List<RegisteredClient> GetAll()
        {
            return _context.RegisteredClients.ToList();
        }

        public RegisteredClient GetByEmail(string email)
        {
            RegisteredClient client = (from u in _context.RegisteredClients
                                       where u.EmailAddress == email
                                       select u).FirstOrDefault();

            return client;
        }

        public RegisteredClient GetById(int clientID)
        {
            RegisteredClient client = (from u in _context.RegisteredClients
                                       where u.RegisteredClientID == clientID
                                       select u).FirstOrDefault();
            return client;
        }

        public void AddClient(RegisteredClient client)
        {
            _context.RegisteredClients.Add(client);
            _context.SaveChanges();
        }
        public void Delete(int ClientID)
        {
            var client = (from u in _context.RegisteredClients
                          where u.RegisteredClientID == ClientID
                          select u).FirstOrDefault();
            _context.RegisteredClients.Remove(client);
            _context.SaveChanges();
        }
        public void Update(RegisteredClient modifyClient)
        {
            var client = (from u in _context.RegisteredClients
                          where u.RegisteredClientID == modifyClient.RegisteredClientID
                          select u).FirstOrDefault();
            if (!client.Equals(modifyClient))
            {
                client.AreaCode = modifyClient.AreaCode;
                client.AreaCode2 = modifyClient.AreaCode2;
                client.EmailAddress = modifyClient.EmailAddress;
                client.FirstName = modifyClient.FirstName;
                client.HouseNumber = modifyClient.HouseNumber;
                client.LastName = modifyClient.LastName;
                client.PhoneNumber1 = modifyClient.PhoneNumber1;
                client.PhoneNumber2 = modifyClient.PhoneNumber2;
                client.Referrals = modifyClient.Referrals;
                client.StreetAddress = modifyClient.StreetAddress;
                client.ZipCode = modifyClient.ZipCode;

                _context.SaveChanges();
            }    
        }
    }
}