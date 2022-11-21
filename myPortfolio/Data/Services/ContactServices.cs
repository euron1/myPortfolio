using myPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace myPortfolio.Data.Services
{
    public class ContactServices : IContactServices
    {
        private readonly AppDbContext _context;
        public ContactServices(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Contacts contact)
        {
            await _context.Contacts.AddAsync(contact);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var result = await _context.Contacts.FirstOrDefaultAsync(n => n.Id == id);
            _context.Contacts.Remove(result);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Contacts>> GetAllAsync()
        {
            var result = await _context.Contacts.ToListAsync();
            return result;
        }

        public async Task<Contacts> GetByIdAsync(int id)
        {
            var result = await _context.Contacts.FirstOrDefaultAsync(n => n.Id == id);
            return result;
        }

        public async Task<Contacts> UpdateAsync(int id, Contacts newContact)
        {
            _context.Update(newContact);
            await _context.SaveChangesAsync();
            return newContact;
        }
    }
}
