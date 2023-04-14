using Core.Applications;

namespace Core.BusinessRules
{
	internal class ValueRule : RuleBase
	{
		private const int MAX_VALUE = 1500000;
		private const int MIN_VALUE = 100000;


		public override bool ValidateRuleToLoan(Loan loan)
		{
			ParamCheck(loan);

			//If the value of the loan is more than £1.5 million or less than £100,000 then the application must be declined
			return loan.Value <= MAX_VALUE && loan.Value >= MIN_VALUE;
		}
	}
}
