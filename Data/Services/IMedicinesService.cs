using sell_laptops.LMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sell_laptops.LMS.Data.Services
{
   public interface ILaptopssService
    {
        Task<IEnumerable<Laptop>> GetAll();
        Task<Laptop> GetByID(int id);
        Task Add(Laptop Laptop);
        Task<Laptop> Update(int id, Laptop newLaptop);
        Task Delete(int id);
        
    }
}
