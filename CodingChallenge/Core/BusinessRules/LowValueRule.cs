using Core.Applications;

namespace Core.BusinessRules
{
	internal class LowValueRule : RuleBase
	{
		private const int VALUE_THRESHOLD = 1000000;

		private const int SIXTYPERCENTTHRESHOLD = 60;
		private const int EIGHTYPERCENTTHRESHOLD = 60;
		private const int NINETYPERCENTTHRESHOLD = 60;

		private const int SIXTYPERCENT_CREDITTHRESHOLD = 750;
		private const int EIGHTYPERCENT_CREDITTHRESHOLD = 800;
		private const int NINETYPERCENT_CREDITTHRESHOLD = 900;

		public override bool ValidateRuleToLoan(Loan loan)
		{
			ParamCheck(loan);

			//If the value of the loan is less than £1 million then the following rules apply: 
			if (loan.Value >= VALUE_THRESHOLD)
				return true;

			var ltv = loan.LTV;

			//If the LTV is less than 60%, the credit score of the applicant must be 750 or more
			if (ltv < SIXTYPERCENTTHRESHOLD)
			{
				return loan.CreditScore >= SIXTYPERCENT_CREDITTHRESHOLD;
			}

			//If the LTV is less than 80%, the credit score of the applicant must be 800 or more
			if (ltv < EIGHTYPERCENTTHRESHOLD)
			{
				return loan.CreditScore >= EIGHTYPERCENT_CREDITTHRESHOLD;
			}

			//If the LTV is less than 90%, the credit score of the applicant must be 900 or more
			if (ltv < NINETYPERCENTTHRESHOLD)
			{
				return loan.CreditScore >= NINETYPERCENT_CREDITTHRESHOLD;
			}

			//If the LTV is 90% or more, the application must be declined
			return false;
		}
	}
}
