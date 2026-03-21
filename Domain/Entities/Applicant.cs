using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WorkerOrdersManagement.Domain.Entities
{
    public class Applicant : EntityData
    {
        [JsonPropertyName("shiftId")]
        public string ShiftId {get;set;}
        [JsonPropertyName("admissionExamId")]
        public string AdmissionExamId {get;set;}
        [JsonPropertyName("technicalCareerId")]
        public string TechnicalCareerId {get;set;}
        public override string showId()
        {
            return  $"El número de expediente generado es {ShiftId}";
        }
        
        public Applicant() : base()
        {
            
        }

        public Applicant(string lastName, string firsName, string address, string phone, string email, string shiftId, string admissionExamId, string technicalCareerId) : base(lastName, firsName,address,phone, email)
        {
            this.ShiftId = shiftId;
            this.AdmissionExamId = admissionExamId;
            this.TechnicalCareerId = technicalCareerId;
        }
    }
}