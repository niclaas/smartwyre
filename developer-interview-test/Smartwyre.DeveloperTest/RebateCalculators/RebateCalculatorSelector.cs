using Smartwyre.DeveloperTest.Types;
using System.Collections.Generic;
using System.Linq;

namespace Smartwyre.DeveloperTest.RebateCalculators
{
	public class RebateCalculatorSelector : IRebateCalculatorSelector
	{
		private readonly IEnumerable<IRebateCalculator> _rebateCalculators;

		public RebateCalculatorSelector(IEnumerable<IRebateCalculator> rebateCalculators)
		{
			_rebateCalculators = rebateCalculators;
		}

		public IRebateCalculator? Select(IncentiveType incentiveType)
		{
			return _rebateCalculators?.SingleOrDefault(x => x.IncentiveType == incentiveType);
		}
	}
}
