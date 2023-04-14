using Core.Applications;
using Core.BusinessRules;

namespace Core.Validator
{
	public class Validator : IValidator
	{
		private readonly List<IRule> LoanRules = new List<IRule>();

		public Validator()
		{
			LoanRules.Add(new ValueRule());
			LoanRules.Add(new ValueLTVCreditRule());
			LoanRules.Add(new LowValueRule());
		}

		public bool IsLoanValid(Loan loan)
		{
			return LoanRules.All((rule) => { return rule.ValidateRuleToLoan(loan); });
		}
	}
}
