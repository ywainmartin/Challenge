using Core.Applications;
using Core.Validator;
using Moq;

namespace Loan.Tests
{
	public class ApplicationFactoryTests
	{

		private Mock<IApplicationFactory> applicationFactoryMock;
		private Mock<IValidator> validatorMock;


		[SetUp]
		public void Setup()
		{
			applicationFactoryMock = new Mock<IApplicationFactory>();
			validatorMock = new Mock<IValidator>();

			validatorMock.Setup(x => x.IsLoanValid(It.IsAny<Core.Applications.Loan>())).Returns(true);
		}

		[Test]
		public void ApplicationFactory_Returns_Application()
		{
			var validator = validatorMock.Object;

			var application = new Application(new Core.Applications.Loan
			{
				AssetValue = 1000000,
				CreditScore = 999,
				Value = 100000
			}, validator);


			applicationFactoryMock.Setup(x => x.CreateApplication(It.IsAny<Core.Applications.Loan>())).Returns(application);

			var applicationFactory = applicationFactoryMock.Object;

			var result = applicationFactory.CreateApplication(new Core.Applications.Loan());


			Assert.IsNotNull(result);

		}
	}
}
