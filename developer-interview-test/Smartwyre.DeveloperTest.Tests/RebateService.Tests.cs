//using Smartwyre.DeveloperTest.Data;
//using Smartwyre.DeveloperTest.RebateCalculators;
//using Smartwyre.DeveloperTest.Services;
//using Smartwyre.DeveloperTest.Types;
//using Xunit;

//namespace Smartwyre.DeveloperTest.Tests;

//public class RebateServiceTests
//{
//	[Fact]
//	public void FixedRateCalculator_ShouldCalculate()
//	{
//		// arrange
//		var product = new Product
//		{
//			Price = 300,
//			SupportedIncentives =
//			[
//				IncentiveType.FixedCashAmount
//			]
//		};

//		var rebate = new Rebate
//		{
//			Percentage = 0.1m,
//			Incentive = IncentiveType.FixedCashAmount
//		};

//		var request = new CalculateRebateRequest
//		{
//			Volume = 3
//		};

//		var calculator1 = new FixedRateRebateCalculator();
//		var calculator2 = new AmountPerUomRebateCalculator();
//		var calculator3 = new FixedCashRebateCalculator();

//		var rebateCalculatorSelector = new RebateCalculatorSelector([calculator1, calculator2, calculator3]);

//		var productStore = new Store<Product>();
//		var rebateStore = new Store<Rebate>();

//		var rebateService = new RebateService(rebateCalculatorSelector, productStore, rebateStore);

//		// action
//		var rebateResult = rebateService.CalculateRebate calculator.CalculateRebate(rebate, product, request);

//		// assert
//		Assert.NotNull(rebateResult);
//		Assert.True(rebateResult.Success);
//		Assert.Equal(90, rebateResult.RebateAmount);
//	}
//}
