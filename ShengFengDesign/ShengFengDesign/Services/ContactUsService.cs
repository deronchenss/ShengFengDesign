using ShengFengDesign.Models;
using ShengFengDesign.Repository.Interface;
using ShengFengDesign.Services.Interface;

namespace ShengFengDesign.Services
{
    public class ContactUsService : IContactUsService
    {
        private readonly IRepository _repository;

        public ContactUsService(IRepository repository)
        {
            _repository = repository;
        }
        public Task<bool> SaveContact(ContactUs contactUs)
        {
            return _repository.SaveContactUs(contactUs);
        }
    }
}
