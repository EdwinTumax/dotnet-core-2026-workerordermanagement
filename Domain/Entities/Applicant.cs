using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkerOrdersManagement.Domain.Entities
{
    public class Applicant : EntityData
    {
        public string ShiftId {get;set;}
        public string ExamId {get;set;}
        public string CareerId {get;set;}
        public override string showId()
        {
            return  $"El número de expediente generado es {ShiftId}";
        }
        
        public Applicant() : base()
        {
            
        }

        public Applicant(string lastName, string firsName, string address, string phone, string email, string shiftId, string examId, string careerId) : base(lastName, firsName,address,phone, email)
        {
            this.ShiftId = shiftId;
            this.ExamId = examId;
            this.CareerId = careerId;
        }
    }
}