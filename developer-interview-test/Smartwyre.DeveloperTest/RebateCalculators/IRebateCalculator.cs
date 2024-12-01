using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.RebateCalculators;

public interface IRebateCalculator
{
	/// <summary>
	/// This type is not really needed for this implementation because
	/// we use the KeyedServiceProvider to find our implementation,
	/// but if we wanted to support a version prior to dotnet 8, the
	/// lookup would have to be done with a linq query over the
	/// collection of implementers returned by the ServiceProvider.
	/// </summary>
	IncentiveType IncentiveType { get; }
	CalculateRebateResult CalculateRebate(Rebate rebate, Product product, ICalculateRebateBaseRequest request);
}
