using Core.Applications;

namespace Core.BusinessRules
{
	internal class ValueLTVCreditRule : RuleBase
	{
		private const int THRESHOLD = 1000000;
		private const int LTV_LIMIT = 60;
		private const int CREDIT_SCORE_LIMIT = 950;

		public override bool ValidateRuleToLoan(Loan loan)
		{
			ParamCheck(loan);

			if (loan.Value < THRESHOLD)
				return true;

			//If the value of the loan is £1 million or more then the LTV must be 60% or less and the credit score of the applicant must be 950 or more
			return loan.LTV < LTV_LIMIT && loan.CreditScore >= CREDIT_SCORE_LIMIT;
		}
	}
}
