using Core.Applications;

namespace Core.BusinessRules
{
	public interface IRule
	{
		bool ValidateRuleToLoan(Loan loan);
	}
}
