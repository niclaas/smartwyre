using Microsoft.Extensions.DependencyInjection;
using Smartwyre.DeveloperTest.Types;
using System;

namespace Smartwyre.DeveloperTest.RebateCalculators
{
	public static class CalculatorResolverExtentions
	{
		public static IRebateCalculator GetRebateCalculator(this IServiceProvider serviceProvider, IncentiveType incentiveType)
		{
			return serviceProvider.GetKeyedService<IRebateCalculator>(incentiveType);
		}
	}
}
