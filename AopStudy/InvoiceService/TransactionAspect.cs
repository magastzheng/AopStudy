namespace AopStudy.InvoiceService
{
    public class TransactionAspect
    {
        private ITransactionManagementService _transaction;

        public TransactionAspect(ITransactionManagementService transaction)
        {
            _transaction = transaction;
        }

        public void OnEntry()
        {
            _transaction.Start();
        }

        public void OnSuccess()
        {
            _transaction.Commit();
        }
    }
}
