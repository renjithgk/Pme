using System.ComponentModel.DataAnnotations;

namespace Pme.ViewModels
{
    public class PmeViewModel
    {
        [Display(Name = "App Map Package Id"), Required]
        public string AppMapPackageId { get; set; }

        [Display(Name = "Version"), Required]
        public string Version { get; set; }

        [Display(Name = "Program Code"), Required]
        public string ProgrameCode { get; set; }

        [Display(Name = "Programe Version Code"), Required]
        public string ProgrameVersionCode { get; set; }
    }
}