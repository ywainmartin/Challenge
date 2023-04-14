namespace Core.Applications
{
	public interface IApplicationFactory
	{
		Application CreateApplication(Loan loan);
	}
}