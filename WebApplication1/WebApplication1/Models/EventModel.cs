using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace WebApplication1.Models
{
    public class EventModel
    {
        public int ID { get; set; }

        [Display(Name = "Ürituse nimi")]
        public string? Title { get; set; }

        [Display(Name = "Toimumisaeg")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Display(Name = "Toimumise koht")]
        public string? Location { get; set; }

        [Display(Name = "Lisainfo")]
        public string? AdditionalInfo { get; set; }
    }
}