using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AopStudy.InvoiceService
{
    public interface IInvoiceData
    {
        void CreateNewInvoice();
        void AddItem();
        void ProcessSalesTax();
    }
}
