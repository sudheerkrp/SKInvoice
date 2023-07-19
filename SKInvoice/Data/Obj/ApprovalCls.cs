namespace SKInvoice.Data.Obj
{
	public class ApprovalCls
	{
		public Guid Id { get; set; }
		public Guid InvoiceNo { get; set; }
		public Guid ApprovalBy { get; set; }
		public string Status { get; set; } = "None";
	}
}
