using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AopStudy.AcmeCarRental;

namespace AopStudy
{
    public class AopInvoiceService
    {
        public virtual void Save(Invoice invoice)
        {

        }

        private bool _isRetry;

        public virtual void SaveRetry(Invoice invoice)
        {
            if (!_isRetry)
            {
                _isRetry = true;
                throw new DataException();
            }
        }

        public virtual void SaveFail(Invoice invoice)
        {
            throw new DataException();
        }
    }
}
