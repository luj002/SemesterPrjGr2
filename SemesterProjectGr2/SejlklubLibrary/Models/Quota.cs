public class Quota
{
	public double Price { get; }
	public DateTime StartDate { get; }
	public DateTime EndDate { get; }
	public bool IsPaid { get; set; }
	public int Year
	{
		get
		{
			return StartDate.Year;
		}
	}
	public Quota(double price, DateTime endDate, DateTime? startDate = null, bool isPaid = false)
	{
		Price = price;
		StartDate = startDate ?? DateTime.Now;
		EndDate = endDate;
		IsPaid = isPaid;
	}
	public override string ToString()
	{
		return $"Quota for Year {Year}: Price: {Price}, Start Date: {StartDate.ToShortDateString()}, End Date: {EndDate.ToShortDateString()}, Paid: {IsPaid}";
	}
}