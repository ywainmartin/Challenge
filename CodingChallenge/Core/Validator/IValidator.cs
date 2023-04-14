using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Applications;

namespace Core.Validator
{
	public interface IValidator
	{
		bool IsLoanValid(Loan loan);
	}
}
