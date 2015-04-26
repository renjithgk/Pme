
using System.Collections.Generic;
namespace Pme.Models
{
    public class Pme
    {
        public int PmeId { get; set; }
        public string AppMapPackageId { get; set; }
        public string Version { get; set; }
        public string ProgrameCode { get; set; }
        public string ProgrameVersionCode { get; set; }

        public virtual ICollection<PmeDetail> PmeDetails { get; set; }
    }
}