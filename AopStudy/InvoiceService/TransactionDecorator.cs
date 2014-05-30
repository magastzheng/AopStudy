using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AopStudy.InvoiceService
{
    public class TransactionDecorator : IInvoiceData
    {
        private IInvoiceData realService;
        private ITransactionManagementService _transaction;

        public TransactionDecorator(IInvoiceData svc, ITransactionManagementService tran)
        {
            realService = svc;
            _transaction = tran;
        }

        public void CreateNewInvoice()
        {
            _transaction.Start();
            realService.CreateNewInvoice();
            _transaction.Commit();
        }

        public void AddItem()
        {
            realService.AddItem();
        }

        public void ProcessSalesTax()
        {
            realService.ProcessSalesTax();
        }
    }
}
