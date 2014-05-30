namespace AopStudy.InvoiceService
{
    public class InvoiceService
    {
        private ITransactionManagementService _transaction;
        private IInvoiceData _invoicedb;

        public InvoiceService(IInvoiceData invoicedb, ITransactionManagementService transaction)
        {
            _invoicedb = invoicedb;
            _transaction = transaction;
        }

        public void CreateInvoice()
        {
            _transaction.Start();
            _invoicedb.CreateNewInvoice();
            _invoicedb.AddItem();
            _invoicedb.ProcessSalesTax();
            _transaction.Commit();
        }
    }
}
