using Core.Validator;
using Moq;



namespace LoanTests
{
	public class ValidatorTests
	{

        private Mock<IValidator> validatorMock;

        [SetUp]
        public void Setup()
        {
			validatorMock = new Mock<IValidator>();
		}

        [Test]
        public void Validator_Reutrns_False()
        {
			validatorMock.Setup(x => x.IsLoanValid(It.IsAny<Core.Applications.Loan>())).Returns(false);

            var validator =  validatorMock.Object;
            var loan = new Core.Applications.Loan();

            var result = validator.IsLoanValid(loan);

            Assert.IsFalse(result);
		}


		[Test]
		public void Validator_Reutrns_True()
		{
			validatorMock.Setup(x => x.IsLoanValid(It.IsAny<Core.Applications.Loan>())).Returns(true);

			var validator = validatorMock.Object;
			var loan = new Core.Applications.Loan();

			var result = validator.IsLoanValid(loan);

			Assert.IsTrue(result);
		}
	}
}