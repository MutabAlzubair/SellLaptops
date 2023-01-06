using sell_laptops.LMS.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sell_laptops.LMS.Data.Services
{
    public class LaptopssService : ILaptopssService
    {
        private readonly AppDbContext _context;

        public LaptopssService(AppDbContext context)
        {
            _context = context;
        }
        public async Task Add(Laptop Laptop)
        {
          await  _context.Laptopss.AddAsync(Laptop);
          await  _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var result = await _context.Laptopss.FirstOrDefaultAsync(n => n.ID == id);
             _context.Laptopss.Remove(result);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Laptop>> GetAll()
        {
            var result = await _context.Laptopss.ToListAsync();
            return result;
        }

        public async Task<Laptop> GetByID(int id)
        {
            var result = await _context.Laptopss.FirstOrDefaultAsync(n => n.ID == id);
            return result;
        }

        public async Task<Laptop> Update(int id, Laptop newLaptop)
        {
            _context.Update(newLaptop);
            await _context.SaveChangesAsync();
            return newLaptop;
        }
    }
}
