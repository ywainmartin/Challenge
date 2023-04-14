using Core.Validator;

namespace Core.Applications
{
	public class Application
	{
		//for serialiser
		public Application() { }

		public Application(Loan loan, IValidator validator)
		{
			Loan = loan;
			Valid = validator.IsLoanValid(loan);
		}

		public Guid ApplicationId { get; } = Guid.NewGuid();
		public DateTime ApplicationDateTime { get; } = DateTime.UtcNow;
		public Loan Loan { get; set; }
		public bool Valid { get; private set; }
	}
}
