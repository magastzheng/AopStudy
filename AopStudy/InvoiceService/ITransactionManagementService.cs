using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AopStudy.InvoiceService
{
    public interface ITransactionManagementService
    {
        void Start();
        void Commit();
    }
}
