
namespace Pme.Models
{
    public class PmeDetail
    {
        public int PmeDetailId { get; set; }
        public string Threshold { get; set; }
        public string Cpu { get; set; }
        public string Clocking { get; set; }
        public string Maximum { get; set; }
        public string Minimum { get; set; }
        public string Memory { get; set; }

        public int PmeId { get; set; }
        public Pme Pme { get; set; }

    }
}