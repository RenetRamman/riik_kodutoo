using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace WebApplication1.Models
{
    public class PersonModel
    {
        public int ID { get; set; }

        [Display(Name = "Eesnimi")]
        public string? FirstName { get; set; }

        [Display(Name = "Perenimi")]
        public string? LastName { get; set; }

        [Display(Name = "Isikukood")]
        public int PersonalId { get; set; }

        [Display(Name = "Maksmisviis")]
        public string? PayingMethod { get; set; } // 0 = cash  1 = transfer
        
        [Display(Name = "Lisainfo")]
        public string? AdditionalInfo { get; set; } // Max 1500 characters
        public List<EventPersonModel>? Events { get; set; }

    }
}
