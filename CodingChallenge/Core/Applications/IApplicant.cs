namespace Core.Applications
{
	public interface IApplicant
	{
		string Name { get; set; }

		Guid ApplicantId { get; set; }

		List<Application> Applications { get; }

		void AddApplication(Application application);

		double GetTotalApplicantLoanValue();

		double GetAverageLTV();

		bool IsLatestApplicationValid();

		List<Application> GetApplications();

	}
}