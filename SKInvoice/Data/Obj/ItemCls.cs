namespace SKInvoice.Data.Obj
{
	public class ItemCls
	{
		public Guid Id { get; set; }
		public string? Name { get; set; }
		public decimal Rate { get; set; }
		public int Quantity { get; set; }
		public decimal Tax { get; set; }
		public Guid InvoiceNo { get; set; }
	}
}
