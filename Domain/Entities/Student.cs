using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkerOrdersManagement.Domain.Entities
{
    public class Student : EntityData
    {
        public string StudentId {get;set;}

        public override string showId()
        {
            return $"El número de Carné generado es {StudentId}";
        }
    }
}