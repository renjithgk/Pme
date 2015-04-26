using Pme.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Pme.DAL
{
    public class PmeContext : DbContext
    {
        public PmeContext()
        {

        }

        public DbSet<Pme.Models.Pme> Pmes { get; set; }
        public DbSet<PmeDetail> PmeDetails { get; set; }

        public void Save(Pme.Models.Pme pme, List<PmeDetail> pmeDetails)
        {
            var savedPme = Pmes.Add(pme);
            savedPme.PmeDetails = new List<PmeDetail>();

            foreach (var item in pmeDetails)
            {
                pme.PmeDetails.Add(item);
            }

            SaveChanges();
        }

        public IEnumerable<PmeDetail> GetAll()
        {
            return PmeDetails.ToList();
        }
    }
}