using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.RebateCalculators;

public class FixedRateRebateCalculator : IRebateCalculator
{
	public IncentiveType IncentiveType { get; } = IncentiveType.FixedRateRebate;

	public CalculateRebateResult CalculateRebate(Rebate rebate, Product product, ICalculateRebateBaseRequest request)
	{
		if (rebate.Percentage == 0 || product.Price == 0 || request.Volume == 0)
		{
			return new CalculateRebateResult { Success = false };
		}
		else
		{
			return new CalculateRebateResult
			{
				Success = true,
				RebateAmount = product.Price * rebate.Percentage * request.Volume
			};
		}
	}
}
