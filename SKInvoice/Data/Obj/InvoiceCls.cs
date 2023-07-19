namespace SKInvoice.Data.Obj
{
	public class InvoiceCls
	{
		public Guid InvoiceNo { get; set; }
		public Guid Type { get; set;}
		public decimal Amount { get; set; }
		public string? Description { get; set; }
		public decimal Tax { get; set; }
		public Guid ClientId { get; set; }
		public DateTime DueDate { get; set; }
		public Guid Currency { get; set; }
		public Guid CreatedBy { get; set; }
	}
}
