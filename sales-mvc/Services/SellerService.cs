using Microsoft.EntityFrameworkCore;
using sales_mvc.Data;
using sales_mvc.Models;

namespace sales_mvc.Services
{
    public class SellerService
    {
        private readonly sales_mvcContext _context;

        public SellerService(sales_mvcContext context)
        {
            _context = context;
        }

        public List<Seller> FindAll()
        {
            return _context.Seller.ToList();
        }

        public void Insert(Seller obj)
        {
            _context.Add(obj);
            _context.SaveChanges(); 
        }

        public Seller FindById(int id)
        {
            return _context.Seller.Include(obj => obj.DepartmentId).FirstOrDefault(obj => obj.Id == id);
        }
        public void Remove(int id)
        {
            var obj = _context.Seller.Find(id);
            _context.Seller.Remove(obj);
            _context.SaveChanges();
        }
    }
}
