using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkerOrdersManagement.Domain.Entities
{
    public class Order
    {
        #region "Propiedad"
        public string OrderId; 
        public string EntityType;
        public string OperationType;
        public string Status;
        public Aspirante Data;
        #endregion

        #region "Acciones"
        public void MarkAsProcessed()
        {
            this.Status = "Processed";
        }

        public void MarkAsFailed()
        {
            this.Status = "Failed";
        }
        #endregion

    }
}