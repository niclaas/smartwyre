using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.RebateCalculators;

public class AmountPerUomRebateCalculator : IRebateCalculator
{
	public IncentiveType IncentiveType { get; } = IncentiveType.AmountPerUom;

	public CalculateRebateResult CalculateRebate(Rebate rebate, Product product, ICalculateRebateBaseRequest request)
	{
		if (rebate.Amount == 0 || request.Volume == 0)
		{
			return new CalculateRebateResult { Success = false };
		}
		else
		{
			return new CalculateRebateResult
			{
				Success = true,
				RebateAmount = rebate.Amount * request.Volume
			};
		}
	}
}
