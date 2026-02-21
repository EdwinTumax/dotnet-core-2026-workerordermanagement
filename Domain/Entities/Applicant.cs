using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkerOrdersManagement.Domain.Entities
{
    public class Applicant : EntityData
    {
        public string ShiftId {get;set;}
        public string ExamenId {get;set;}
        public string CarreraId {get;set;}
        public string JornadaId {get;set;}

        public override string showId()
        {
            return  $"El número de expediente generado es {ShiftId}";
        }
    }
}