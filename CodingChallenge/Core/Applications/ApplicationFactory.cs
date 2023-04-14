using Core.Validator;

namespace Core.Applications
{
	public class ApplicationFactory : IApplicationFactory
	{
		private readonly IValidator Validator;

		public ApplicationFactory(IValidator validator )
		{
			Validator = validator;
		}

		public Application CreateApplication(Loan loan)
		{
			return new Application(loan, Validator);
		}
	}
}
