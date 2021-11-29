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

    }
}
