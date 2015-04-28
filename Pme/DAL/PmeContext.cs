using Pme.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
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

        public IList<PmeDetail> GetAll()
        {
            return PmeDetails.ToList();
        }

        public string GetDataAsCsv(int id)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("GetPmeDetails");
                cmd.Connection = new SqlConnection();
                cmd.Connection.ConnectionString = Database.Connection.ConnectionString;
                cmd.Parameters.Add("@id", SqlDbType.Int, 100).Value = id;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                return ds.Tables[0].ToCSV();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
    }
}