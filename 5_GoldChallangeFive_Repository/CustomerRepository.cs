using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5_GoldChallangeFive_Repository
{
    public class CustomerRepository
    {
        public List<CustomerClass> _listOfCustomers = new List<CustomerClass>();
        public Dictionary<CustomerType,string> _listOfEmails = new Dictionary<CustomerType,string>();
        
        public void AddNewCustomer(CustomerClass customer)
        {
            _listOfCustomers.Add(customer);
        }

        
        public List<CustomerClass> GetCustomerList()
        {
            List<CustomerClass> newList = _listOfCustomers;
            var customersInOrder = newList.OrderBy(CustomerClass => CustomerClass.FirstName).ToList();
            return customersInOrder;
            
        }
           
            

        public bool UpdateCustomer(string firstName, string lastName ,CustomerClass updatedCustomer)
        {
            CustomerClass existingCustomer = GetCustomerByName(firstName, lastName);
            if(existingCustomer != null)
            {
                existingCustomer.FirstName = updatedCustomer.FirstName;
                existingCustomer.LastName = updatedCustomer.LastName;
                existingCustomer.Type = updatedCustomer.Type;

                return true;
            }
            return false;
        }

        public bool DeleteCustomer(string firstName, string lastName)
        {
            CustomerClass existingCustomer = GetCustomerByName(firstName, lastName);
            if(existingCustomer == null)
            {
                return false;
            }
            int initialCount = _listOfCustomers.Count;
            _listOfCustomers.Remove(existingCustomer);
            if(initialCount > _listOfCustomers.Count)
            {
                return true;
            }
            return false;
        }

        public CustomerClass GetCustomerByName(string firstName, string lastName)
        {
            foreach(CustomerClass customer in _listOfCustomers)
            {
                if(customer.FirstName == firstName.ToUpper() && customer.LastName == lastName.ToUpper())
                {
                    return customer;
                }
            }
            return null;
        }

        public string GetGreetEmail(CustomerType customerType)
        {
                foreach(var key in _listOfEmails)
                {
                    if (customerType == key.Key)
                    {
                        return key.Value;
                    }
                }
            return null;
        }
    }
}
