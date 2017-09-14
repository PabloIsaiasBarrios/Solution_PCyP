using PCyP.
    Domain.Biz;
using PCyP.Domain.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCyP.Domain.BLL
{
    public class CountryBusiness
    {
        private CountryRepository db = new CountryRepository();

        private static CountryBusiness _instance;

        private CountryBusiness()
        { 
            db = new CountryRepository();
        }

        public static CountryBusiness Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new CountryBusiness();
                return _instance;
            }
        }

        public void Add(Country model)
        {
            model.ChangedBy = 0;
            model.ChangedOn = DateTime.Now;
            model.CreatedBy = 0;
            model.CreatedOn = DateTime.Now;
            this.db.Add(model);
        }

        public List<Country> GetCountryList()
        {
            return db.All();
        }

        public Country GetCountryDetails(string id)
        {
            return this.db.Find(new Country { Id = id });
        }

        public void Delete(Country model)
        {
            this.db.Delete(model);
        }
    }
}
