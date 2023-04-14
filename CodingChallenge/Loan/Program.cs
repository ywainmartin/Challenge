using Core.Applications;
using Core.Validator;

var applicants = new Dictionary<string,Applicant>();

var validator = new Validator();
var applicationFactory = new ApplicationFactory(validator);

var runLoanProgram = true;
const int CREDIT_SCORE_MAX = 999;
const int CREDIT_SCORE_MIN = 1;

LoadExistingApplications();



while (runLoanProgram)
{
	Console.WriteLine("Welcome to the Loan Service. Select Command");




	Console.Write($"A : Add Loan \r\n" +
				  $"D : The total number of applicants to date, broken down by their success status \r\n" +
				  $"V : The total value of loans written to date \r\n" +
				  $"M : The mean average Loan to Value of all applications received to date \r\n" +
				  $"Q : Quit");

	Console.WriteLine($"");

	var command = Console.ReadLine()?.ToUpper();

	switch(command)
	{
		case "A":
			{
				Console.Clear();
				Console.WriteLine("Enter Name:");
				var name = Console.ReadLine();


				if (string.IsNullOrEmpty(name))
				{
					InvalidEntry();
					break;
				}

				Console.WriteLine($"");
				Console.WriteLine($"Enter Loan Amount:");
				var loanAmount = Console.ReadLine();
				double loanAmountDouble;

				if (!double.TryParse(loanAmount, out loanAmountDouble))
				{
					InvalidEntry();
					break;
				}

				Console.Clear();
				Console.WriteLine($"Enter Value of Asset:");

				var assetValue = Console.ReadLine();
				double assetValueDouble;

				if (!double.TryParse(assetValue, out assetValueDouble))
				{
					InvalidEntry();
					break;
				}

				Console.Clear();
				Console.WriteLine($"Enter Credit Score:");

				var creditScore = Console.ReadLine();
				int creditScoreInt;

				if (!int.TryParse(creditScore, out creditScoreInt) || creditScoreInt > CREDIT_SCORE_MAX || creditScoreInt < CREDIT_SCORE_MIN)
				{
					InvalidEntry();
					break;
				}

				Applicant applicant = null;

				if (applicants.ContainsKey(name))
					applicant = applicants[name];
				else
				{
					applicant = new Applicant
					{
						Name = name,
						ApplicantId = Guid.NewGuid()
					};
				}

				var application = applicationFactory.CreateApplication(new Loan
				{
					Value = loanAmountDouble,
					AssetValue = assetValueDouble,
					CreditScore = creditScoreInt
				});

				applicant.AddApplication(application);

				Console.Clear();
				Console.WriteLine($"Loan Was Valid:  {applicant.IsLatestApplicationValid()}");
				Thread.Sleep(5000);

				if (!applicants.ContainsKey(name))
					applicants.Add(name, applicant);
				else
					applicants[name] = applicant;
			}
			break;
		case "D":
			{
				Console.Clear();
				Console.WriteLine($"Total Applicants: {applicants.Count}");
				

				foreach(var applicant in applicants)
				{
					Console.WriteLine($"Name: {applicant.Key}");
					Console.WriteLine($"");

					foreach (var application in applicant.Value.GetApplications())
					{
						Console.WriteLine($"Application Id: {application.ApplicationId} \t Application Date:{application.ApplicationDateTime.Date} \t Valid: {application.Valid}");
					}

					Console.WriteLine($"");
					Console.WriteLine($"");
				}

				Thread.Sleep(5000);
			}
			break;
		case "V":
			{
				Console.Clear();

				var totalValueOfLoans = applicants.Values.Sum(applicant => applicant.GetTotalApplicantLoanValue());

				Console.WriteLine($"To date the total value of all valid loans are: {totalValueOfLoans}");

				Thread.Sleep(5000);
			}
			break;
		case "M":
			{
				Console.Clear();

				var totalAverageLTV = applicants.Values.Average(applicant => applicant.GetAverageLTV());

				Console.WriteLine($"To date the average Loan to Value of all loans are: {totalAverageLTV}");

				Thread.Sleep(5000);
			}
			break;
		case "Q":
			runLoanProgram = false;
			break;
		default:
			InvalidEntry();
			break;
	}

	Console.Clear();
}

SaveApplicantData();

void SaveApplicantData()
{
	var assembly = System.Reflection.Assembly.GetExecutingAssembly();

	string path = assembly.Location;

	path = path.Replace(assembly.ManifestModule.Name, "");

	string fileName = Path.Combine(path, "data.json");

	if (!File.Exists(fileName))
	{
		File.Create(fileName);
	}

	var data = Newtonsoft.Json.JsonConvert.SerializeObject(applicants, new Newtonsoft.Json.JsonSerializerSettings 
	{ 
		NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore,
		TypeNameAssemblyFormatHandling = Newtonsoft.Json.TypeNameAssemblyFormatHandling.Simple
	});

	File.WriteAllText(fileName, data);
}

void LoadExistingApplications()
{
	var assembly = System.Reflection.Assembly.GetExecutingAssembly();

	string path = assembly.Location;

	path = path.Replace(assembly.ManifestModule.Name, "");

	string fileName = Path.Combine(path, "data.json");

	if (!File.Exists(fileName))
	{
		File.Create(fileName);
	}
	else
	{
		var contents = File.ReadAllText(fileName);

		if(!string.IsNullOrEmpty(contents))
			applicants = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, Applicant>>(contents);
	}
}

static void InvalidEntry()
{
	Console.Clear();
	Console.WriteLine($"Invalid Entry");
	Thread.Sleep(2000);
	Console.Clear();
}