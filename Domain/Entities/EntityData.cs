using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WorkerOrdersManagement.Domain.Entities
{
    public abstract class EntityData
    {
        [JsonPropertyName("lastName")]
        public string LastName {get; set;}
        [JsonPropertyName("firstName")]
        public string FirsName {get; set;}
          [JsonPropertyName("address")]
        public string Address {get; set;}
          [JsonPropertyName("phone")]
        public string Phone {get; set;}
          [JsonPropertyName("email")]
        public string Email {get; set;}
        public EntityData()
        {
            
        }
        public EntityData(string lastName, string firsName, string address, string phone, string email)
        {
            this.LastName = lastName;
            this.FirsName = firsName;
            this.Address = address;
            this.Phone = phone;
            this.Email = email;
        }
        public abstract string showId();
    }
}