using Microsoft.AspNetCore.Mvc.Rendering;
using System.Reflection;

namespace WebApplication1.Models
{
    public class ParticipantsViewModel
    {
        // Properties
        public PersonModel personModel { get; set; }
        public CompanyModel companyModel { get; set; }
        public EventModel eventModel { get; set; }
        public EventPersonModel eventPersonModel { get; set; }
        public EventCompanyModel eventCompanyModel { get; set; }

        // Constructor
        public ParticipantsViewModel(EventModel _eventModel)
        {
            personModel = new PersonModel();
            companyModel = new CompanyModel();
            eventModel = _eventModel;
            eventPersonModel = new EventPersonModel();
            eventCompanyModel = new EventCompanyModel();
        }

        public ParticipantsViewModel()
        {
            personModel = new PersonModel();
            companyModel = new CompanyModel();
            eventModel = new EventModel();
            eventPersonModel = new EventPersonModel();
            eventCompanyModel = new EventCompanyModel();
        }
    }
}
