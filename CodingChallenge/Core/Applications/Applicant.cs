using System.Text;

namespace Core.Applications
{
	public class Applicant : IApplicant
	{
		internal const string NO_LOANS = "No Loans To Date";

		public string Name { get; set; }

		public Guid ApplicantId { get; set; }

		public List<Application> Applications { get; } = new List<Application>();

		public void AddApplication(Application application)
		{
			Applications.Add(application);
		}

		public double GetTotalApplicantLoanValue()
		{
			return Applications.Where(x => x.Valid).Sum(x => x.Loan.Value);
		}

		public double GetAverageLTV()
		{
			return Applications.Average(x => x.Loan.LTV);
		}

		public bool IsLatestApplicationValid()
		{
			if (Applications.Count == 0)
				return false;

			return Applications.OrderByDescending(application => application.ApplicationDateTime).First().Valid;
		}

		public List<Application> GetApplications()
		{
			return Applications;
		}
	}
}
