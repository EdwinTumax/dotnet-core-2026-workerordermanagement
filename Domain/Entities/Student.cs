using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkerOrdersManagement.Domain.Entities
{
    public class Student : EntityData
    {
        public string StudentId {get;set;}

        public Student() : base()
        {
            
        }

        public Student(string lastName, string firsName, string address, string phone, string email, string studentId) : base(lastName,firsName,address,phone,email)
        {
            this.StudentId = studentId;            
        }

        public override string showId()
        {
            return $"El número de Carné generado es {StudentId}";
        }
    }
}