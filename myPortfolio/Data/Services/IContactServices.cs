using myPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myPortfolio.Data.Services
{
    public interface IContactServices
    {
        Task<IEnumerable<Contacts>> GetAllAsync();
        Task<Contacts> GetByIdAsync(int id);
        Task AddAsync(Contacts contact);
        Task<Contacts> UpdateAsync(int id, Contacts newContact);
        Task DeleteAsync(int id);

    }
}
