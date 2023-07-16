using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace WebApplication1.Models
{
    public class CompanyModel
    {
        public int ID { get; set; }

        [Display(Name = "Ettevõtte juriidiline nimi")]
        public string? Name { get; set; }

        [Display(Name = "Ettevõtte registrikood")]
        public string? Code { get; set; }

        [Display(Name = "Ettevõttest tulevate osavõtjate arv")]
        public int NrOfAtendees { get; set; }

        [Display(Name = "Osavõtumaksu maksmise viis")]
        public string? PayingMethod { get; set; } // 0 = cash  1 = transfer

        [Display(Name = "Lisainfo")]
        public string? AdditionalInfo { get; set; } // Max 5000 characters

        public List<EventCompanyModel>? Events { get; set; }
    }
}
