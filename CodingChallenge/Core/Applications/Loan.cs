namespace Core.Applications
{
	public class Loan
	{
		public Guid LoanId { get; set; } = Guid.NewGuid();
		public double Value { get; set; } = 0;

		public double AssetValue { get; set; } = 0;

		public int CreditScore { get; set; } = 0;

		public double LTV 
		{ 
			get 
			{
				if(Value == 0 || AssetValue == 0)
					return 0;

				var ltv = (double)Value / AssetValue;

				return ltv * 100;

			}
		}
	}
}
