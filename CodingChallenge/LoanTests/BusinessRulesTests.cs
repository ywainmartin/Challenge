using Core.BusinessRules;

namespace LoanTests
{
	internal class BusinessRulesTests
	{
		[Test]
		public void LowValueRule_Should_Fail_If_LTV_Above_90()
		{
			var rule = new LowValueRule();
			var loan = new Core.Applications.Loan
			{
				Value = 1000,
				AssetValue = 1010
			};

			var result = rule.ValidateRuleToLoan(loan);

			Assert.IsFalse(result);

		}



		[Test]
		public void ValueLTVCreditRule_Should_Pass_If_Loan_Within_Threshold_And_InValid_CREDIT_Score()
		{
			var rule = new ValueLTVCreditRule();
			var loan = new Core.Applications.Loan
			{
				Value = 1000000,
				CreditScore = 949
			};

			var result = rule.ValidateRuleToLoan(loan);

			Assert.IsFalse(result);
		}


		[Test]
		public void ValueLTVCreditRule_Should_Pass_If_Loan_Within_Threshold_And_Valid_CREDIT_Score()
		{
			var rule = new ValueLTVCreditRule();
			var loan = new Core.Applications.Loan
			{
				Value = 1000000,
				CreditScore = 951
			};

			var result = rule.ValidateRuleToLoan(loan);

			Assert.IsTrue(result);
		}


		[Test]
		public void ValueLTVCreditRule_Should_Pass_If_Loan_Over_Threshold()
		{
			var rule = new ValueLTVCreditRule();
			var loan = new Core.Applications.Loan
			{
				Value = 75
			};

			var result = rule.ValidateRuleToLoan(loan);


			Assert.IsTrue(result);
		}

		[Test]
		public void ValueRule_Should_Pass_Valid_Loan()
		{
			var rule = new ValueRule();
			var loan = new Core.Applications.Loan
			{
				Value = 750000
			};

			var result = rule.ValidateRuleToLoan(loan);

			Assert.IsTrue(result);
		}

		[Test]
		public void ValueRule_Should_Fail_Loan_Above_Threshold()
		{
			var rule = new ValueRule();
			var loan = new Core.Applications.Loan
			{
				Value = 2000000
			};

			var result = rule.ValidateRuleToLoan(loan);

			Assert.False(result);
		}

		[Test]
		public void ValueRule_Should_Fail_Loan_Below_Threshold()
		{
			var rule = new ValueRule();
			var loan = new Core.Applications.Loan
			{
				Value = 75
			};

			var result = rule.ValidateRuleToLoan(loan);

			Assert.False(result);
		}
	}
}
