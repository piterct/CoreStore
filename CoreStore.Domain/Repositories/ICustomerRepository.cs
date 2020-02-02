using CoreStore.Domain.StoredContext.Entities;

namespace CoreStore.Domain.Repositories
{
    public interface  ICustomerRepository
    {
        bool CustomerDcoument(string document);
        bool CheckEmail(string email);
        void Save(Customer customer);
    }
}
