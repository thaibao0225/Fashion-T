using Client.Data;
using Client.Entites;
using Client.Models;

namespace Client.Service
{
    public class BillService : IBillService
    {
        private readonly ApplicationDbContext _context;
        public BillService(ApplicationDbContext context)
        {

            _context = context;
        }

        public async Task<bool> CreateBillForUser(IFormCollection collection, string userId, List<ProductsInCartModel> productsInCartModel)
        {

            string firstName = collection["firstName"];
            string lastName = collection["lastName"];
            string country = collection["country"];
            string address = collection["address"];
            string city = collection["city"];
            string zip = collection["zip"];
            string phone = collection["phone"];
            string email = collection["email"];

            // Add information
            var user = _context.AppUser.FirstOrDefault(x => x.Id == userId);
            
            if (user != null)
            {
                user.FirstName = firstName;
                user.LastName = lastName;
                user.bill_Address1 = address;
                user.bill_City = city;
                user.bill_PostalCode = zip;
                user.PhoneNumber = phone;
                user.Email = email;

                _context.AppUser.Update(user);
                await _context.SaveChangesAsync();
            }

            
            if(GetBillId(userId) == "")
            {
                foreach (var item in productsInCartModel)
                {

                }
            }
            else
            {

            }


            return false;
        }

        public string GetBillId(string userId)
        {
            var bill = _context.Bills.FirstOrDefault(x => x.bill_UserId == userId);
            if(bill != null)
            {
                return bill.bill_Id;
            }
            return "";
        }

        public string SetBill()
        {
            string billId = Guid.NewGuid().ToString();

            Bills bills = new Bills()
            {
                bill_Id = billId

            };
            return "";
        }

        public string GenericListInBill(string listedGen, string item, string commad)
        {
            return listedGen + commad + item;
        }
    }
}
