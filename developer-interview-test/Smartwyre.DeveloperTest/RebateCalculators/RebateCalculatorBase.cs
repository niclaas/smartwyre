using Smartwyre.DeveloperTest.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smartwyre.DeveloperTest.RebateCalculators
{
	public abstract class RebateCalculatorBase
	{
		/// <summary>
		/// Handles generic validation common to all rebate calculators
		/// </summary>
		/// <returns>true if valid, false if not</returns>
		protected bool IsValid(Rebate rebate, Product product, ICalculateRebateBaseRequest request)
		{
			// Checking a collection of supported incentive types allows for
			// larger set of incentives to be supported than the 32 in the
			// original implementation.
			return product.SupportedIncentives.Contains(rebate.Incentive);
		}
	}
}
