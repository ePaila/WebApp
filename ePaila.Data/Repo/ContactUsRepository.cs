using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePaila.Data.Repo
{
    public class ContactUsRepository
    {
        ePailaEntities _db;

        public ContactUsRepository(ePailaEntities db)
        {
            _db = db;
        }

        public void Insert(string name, string from, string message)
        {
            ContactU obj = new ContactU()
            {
                Name = name,
                From = from,
                Message = message,
                DateTime=DateTime.Now
            };
            _db.ContactUs.Add(obj);
            _db.SaveChanges();
        }
    }
}
