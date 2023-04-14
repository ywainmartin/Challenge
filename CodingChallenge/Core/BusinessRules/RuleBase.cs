using Core.Applications;

namespace Core.BusinessRules
{
	internal abstract class RuleBase : IRule
	{
		public abstract bool ValidateRuleToLoan(Loan loan);

		protected void ParamCheck(Loan loan)
		{
			if (loan == null)
				throw new ArgumentNullException($"{nameof(loan)}");
		}
	}
}
