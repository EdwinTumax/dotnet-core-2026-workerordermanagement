using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkerOrdersManagement.Domain.Enums;

namespace WorkerOrdersManagement.Domain.Entities
{
    public class Order
    {
        // GET / SET -> Encapsulamiento
        #region "Campos"
        private readonly string _OrderId = Guid.NewGuid().ToString();
        private EntityType _EntityType;
        private OperationType _OperationType;
        private OrderStatus _Status;
        private Applicant _Applicant;
        #endregion

        #region "Propiedades"
        public string OrderId
        {
            get
            {
                return _OrderId;
            }          
        }
        public EntityType EntityType
        {
            get
            {
                return _EntityType;
            }
            set
            {
                _EntityType = value;
            }
        }

        public OperationType OperationType
        {
            get
            {
                return _OperationType;
            }
            set
            {
                _OperationType = value;
            }
        }

        public OrderStatus Status
        {
            get
            {
                return _Status;
            }
            set
            {
                _Status = value;
            }
        }

        public Applicant Aspirante
        {
            get
            {
                return _Applicant;
            }
            set
            {
                _Applicant = value;
            }
        }
        #endregion


        #region "Acciones"
        public void MarkAsProcessed()
        {
            this.Status = OrderStatus.PROCESSED;
        }

        public void MarkAsFailed()
        {
            this.Status = OrderStatus.FAILED;
        }
        #endregion

    }
}