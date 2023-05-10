using ShengFengDesign.Models;

namespace ShengFengDesign.Services.Interface
{
    public interface IContactUsService
    {
        Task<bool> SaveContact(ContactUs contactUs);
    }
}
