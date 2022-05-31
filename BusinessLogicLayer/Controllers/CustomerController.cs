using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Entities;
using DTO;

namespace BusinessLogicLayer.Controllers
{
    public class CustomerController
    {   
        // Make Customer
        private Customer GetCustomer(string Id, string CustomerName,
            string CustomerID, string Phonenumber, string Address)
        {
            Customer customer = new Customer();
            customer.Id = Id;
            customer.CustomerName = CustomerName;
            customer.CustomerId = CustomerID;
            customer.Phonenumber = Phonenumber;
            customer.Address = Address;
            return customer;
        }

        // Get All Customer
        public List<Customer> GetAllCustomer(ref string error)
        {
            using (var context = new Context())
            {
                try
                {
                    var customers = context.customers.ToList();
                    error = "Get All Customer Success!!!";
                    return customers;
                }
                catch (Exception ex)
                {
                    error = ex.Message;
                    return null;
                }
            }
        }

        // Get Customer By Id
        public Customer GetCustomerById(string Id, ref string error)
        {
            try
            {
                using (var context = new Context())
                {
                    var customer = context.customers.Where(cc => cc.Id == Id).FirstOrDefault();
                    if (customer != null)
                    {
                        error = "Get Customer By Id Success!!!";
                    }
                    error = "Customer Is Not Exsit!!!";
                    return customer;
                }
            }
            catch
            {
                error = "Get Customer By Id Failure!!!";
                return null;
            }
        }

        // Add New Customer
        public bool AddNewCustomer(
            string Id,
            string CustomerName,
            string CustomerId,
            string Phonenumber,
            string Address,
            ref string error
        )
        {
            try
            {
                using (var context = new Context())
                {
                    // Check service
                    var customer = this.GetCustomer(Id, CustomerName, CustomerId, Phonenumber, Address);
                    if (customer != null)
                    {
                        context.customers.Add(customer);
                        var numOfState = context.SaveChanges();
                        error = $"Insert {numOfState} Success!!!";
                        return true;
                    }
                    error = "Customer invalid!!!";
                    return false;
                }
            }
            catch
            {
                error = "Add New Customer Failure!!!";
                return false;
            }
        }

        // Update Customer
        public bool UpdateCustomerById(
            string Id,
            string NewCustomerName,
            string NewCustomerId,
            string NewPhonenumber,
            string NewAddress,
            ref string error
        )
        {
            try
            {
                using (var context = new Context())
                {
                    var customer = context.customers.
                         SingleOrDefault(c => c.Id == Id);
                    if (customer != null)
                    {
                        customer.CustomerName = NewCustomerName;
                        customer.CustomerId = NewCustomerId;
                        customer.Phonenumber = NewPhonenumber;
                        customer.Address = NewAddress;
                        var numOfState = context.SaveChanges();
                        if (numOfState > 0)
                        {
                            error = "Update Customer By Id Success!!!";
                            return true;
                        }
                        error = "Customer Has No Change!!!";
                        return false;
                    }
                    error = "Customer Is Not Exsit!!!";
                    return false;
                }
            }
            catch
            {
                error = "Something Was Wrong!!!";
                return false;
            }
        }

        // Delete Customer
        public bool RemoveCustomerById(string Id, ref string error)
        {
            try
            {
                using (var context = new Context())
                {
                    var customer = context.customers.
                        SingleOrDefault(s => s.Id == Id);
                    if (customer != null)
                    {
                        context.customers.Remove(customer);
                        var numOfState = context.SaveChanges();
                        if (numOfState > 0)
                        {
                            error = "Remove Customer By Id Success!!!";
                            return true;
                        }
                        error = "Remove Customer By Id Failure!!!";
                        return false;
                    }
                    error = "Customer Is Not Exist!!!";
                    return false;
                }
            }
            catch
            {
                error = "Something was wrong!!!";
                return false;
            }
        }
    }
}
