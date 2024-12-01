using Smartwyre.DeveloperTest.RebateCalculators;
using Smartwyre.DeveloperTest.Types;
using Xunit;

namespace Smartwyre.DeveloperTest.Tests;

public class RebateCalculatorTests
{
    [Fact]
    public void FixedCashCalculator_ShouldCalculate()
    {
        // arrange
        var rebate = new Rebate
        {
            Amount = 30,
            Incentive = IncentiveType.FixedRateRebate
        };

        var calculator = new FixedCashRebateCalculator();

        // action
        var rebateResult = calculator.CalculateRebate(rebate, null, null);

        // assert
        Assert.NotNull(rebateResult);
		Assert.True(rebateResult.Success);
		Assert.Equal(30, rebateResult.RebateAmount);
    }

	[Fact]
	public void FixedCashCalculator_MissingInput_ShouldFail()
	{
		// arrange
		var rebate = new Rebate
		{
			Incentive = IncentiveType.FixedRateRebate
		};

		var calculator = new FixedCashRebateCalculator();

		// action
		var rebateResult = calculator.CalculateRebate(rebate, null, null);

		// assert
		Assert.NotNull(rebateResult);
		Assert.False(rebateResult.Success);
	}

	[Fact]
	public void FixedRateCalculator_ShouldCalculate()
	{
		// arrange
		var product = new Product
		{
			Price = 300,
			SupportedIncentives =
			[
				IncentiveType.FixedCashAmount
			]
		};

		var rebate = new Rebate
		{
			Percentage = 0.1m,
			Incentive = IncentiveType.FixedCashAmount
		};

		var request = new CalculateRebateRequest
		{
			Volume = 3
		};

		var calculator = new FixedRateRebateCalculator();

		// action
		var rebateResult = calculator.CalculateRebate(rebate, product, request);

		// assert
		Assert.NotNull(rebateResult);
		Assert.True(rebateResult.Success);
		Assert.Equal(90, rebateResult.RebateAmount);
	}

	[InlineData(0, 0.1, 3)]
	[InlineData(300, 0, 3)]
	[InlineData(300, 0.1, 0)]
	[Theory]
	public void FixedRateCalculator_MissingInput_ShouldFail(decimal price, decimal percentage, decimal volume)
	{
		// arrange
		var product = new Product
		{
			Price = price,
			SupportedIncentives =
			[
				IncentiveType.FixedCashAmount
			]
		};

		var rebate = new Rebate
		{
			Percentage = percentage,
			Incentive = IncentiveType.FixedCashAmount
		};

		var request = new CalculateRebateRequest
		{
			Volume = volume
		};

		var calculator = new FixedRateRebateCalculator();

		// action
		var rebateResult = calculator.CalculateRebate(rebate, product, request);

		// assert
		Assert.NotNull(rebateResult);
		Assert.False(rebateResult.Success);
	}

	[Fact]
	public void AmountPerUomCalculator_ShouldCalculate()
	{
		// arrange
		var rebate = new Rebate
		{
			Amount = 10,
			Incentive = IncentiveType.AmountPerUom
		};

		var request = new CalculateRebateRequest
		{
			Volume = 3
		};

		var calculator = new AmountPerUomRebateCalculator();

		// action
		var rebateResult = calculator.CalculateRebate(rebate, null, request);

		// assert
		Assert.NotNull(rebateResult);
		Assert.True(rebateResult.Success);
		Assert.Equal(30, rebateResult.RebateAmount);
	}

	[InlineData(0, 3)]
	[InlineData(10, 0)]
	[Theory]
	public void AmountPerUomCalculator_MissingInput_ShouldFail(decimal amount, decimal volume)
	{
		// arrange
		var rebate = new Rebate
		{
			Amount = amount,
			Incentive = IncentiveType.AmountPerUom
		};

		var request = new CalculateRebateRequest
		{
			Volume = volume
		};

		var calculator = new AmountPerUomRebateCalculator();

		// action
		var rebateResult = calculator.CalculateRebate(rebate, null, request);

		// assert
		Assert.NotNull(rebateResult);
		Assert.False(rebateResult.Success);
	}
}
