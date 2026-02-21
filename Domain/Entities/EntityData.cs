using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkerOrdersManagement.Domain.Entities
{
    public abstract class EntityData
    {
        public string LastName {get;set;}
        public string FirsName {get;set;}
        public string Address {get;set;}
        public string Phone {get;set;}
        public string Email {get;set;}
        public abstract string showId();
    }
}