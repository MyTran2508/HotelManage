using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Entities;
using DTO;

namespace BusinessLogicLayer.Controllers
{
    // Service controller
    public class ServiceController
    {
        // Make Service
        private Service GetService(string Id, string Name, float Price)
        {
            Service service = new Service();
            service.Id = Id;    
            service.Name = Name;    
            service.Price = Price;
            return service;
        }

        // Get All Services
        public List<Service> GetAllServices(ref string error)
        {
            using (var context = new Context())
            {
                try
                {
                    var services = context.services.ToList();
                    error = "Get All Services Success!!!";
                    return services;
                }
                catch (Exception ex)
                {
                    error = ex.Message;
                    return null;
                }
            }
        }
    
        // Get Service By Id
        public Service GetServiceById(string Id,  ref string error)
        {
            try
            {
                using (var context = new Context())
                {
                    var service = context.services.Where(sv => sv.Id == Id).FirstOrDefault();   
                    if(service != null)
                    {
                        error = "Get Service By Id Success!!!";
                    }
                    error = "Service Is Not Exsit!!!";
                    return service;
                }
            }
            catch
            {
                error = "Get Service By Id Failure!!!";
                return null;
            }
        }

        // Add New Service
        public bool AddNewService(
            string Id,
            string Name,
            float Price,
            ref string error
        )
        {
            try
            {
                using (var context = new Context())
                {
                    // Check service
                    var service = this.GetService(Id, Name, Price);
                    if (service != null)
                    {
                        context.services.Add(service);
                        var numOfState = context.SaveChanges();
                        error = $"Insert {numOfState} Success!!!";
                        return true;
                    }
                    error = "Service invalid!!!";
                    return false;
                }
            }
            catch
            {
                error = "Add New Service Failure!!!";
                return false;
            }
        }

        public bool UpdateServiceById(
            string Id, 
            string NewName, 
            float NewPrice, 
            ref string error)
        {
            try
            {
                using(var context = new Context())
                {
                   var service = context.services.
                        SingleOrDefault(s => s.Id == Id); 
                    if (service != null)
                    {
                        service.Name = NewName;
                        service.Price = NewPrice;
                        var numOfState = context.SaveChanges();
                        if(numOfState > 0)
                        {
                            error = "Update Service By Id Success!!!";
                            return true;
                        }
                        error = "Service Has No Change!!!";
                        return false;
                    }
                    error = "Service Is Not Exsit!!!";
                    return false;
                }
            }
            catch
            {
                error = "Something Was Wrong!!!";
                return false;
            }
        }

        public bool RemoveServiceById(string Id, ref string error)
        {
            try
            {
                using (var context = new Context())
                {
                    var sv = context.services.
                        SingleOrDefault(s => s.Id == Id); 
                    if (sv != null)
                    {
                        context.services.Remove(sv);
                        var numOfState = context.SaveChanges();
                        if(numOfState > 0)
                        {
                            error = "Remove Service By Id Success!!!";
                            return true;
                        }
                        error = "Remove Service By Id Failure!!!";
                        return false;
                    }
                    error = "Service Is Not Exist!!!";
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
