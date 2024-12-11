﻿using Smartwyre.DeveloperTest.Data;
using Smartwyre.DeveloperTest.RebateCalculators;
using Smartwyre.DeveloperTest.Types;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Smartwyre.DeveloperTest.Services;

public class RebateService : IRebateService
{
	private readonly IRebateCalculatorSelector _rebateCalculatorSelector;
	private readonly IStore<Product> _productStore;
	private readonly IStore<Rebate> _rebateStore;

	public RebateService(IRebateCalculatorSelector rebateCalculatorSelector, IStore<Product> productStore, IStore<Rebate> rebateStore)
	{
		_rebateCalculatorSelector = rebateCalculatorSelector;
		_productStore = productStore;
		_rebateStore = rebateStore;
	}

	#region Products
	/// <summary>
	/// This should reside in a product specific service, but here for speed.
	/// </summary>
	/// <param name="product"></param>
	/// <returns></returns>
	public async Task<Product> AddProduct(Product product)
	{
		return await _productStore.Save(product);
	}

	public Task<IEnumerable<Product>> ListProducts()
	{
		return _productStore.GetAll();
	}
	#endregion Products

	#region Rebates
	public async Task<Rebate> AddRebate(Rebate rebate)
	{
		return await _rebateStore.Save(rebate);
	}

	public Task<IEnumerable<Rebate>> ListRebates()
	{
		return _rebateStore.GetAll();
	}
	#endregion Rebates

	public async Task<CalculateRebateResult> CalculateRebate(CalculateRebateRequest request)
	{
		if (string.IsNullOrWhiteSpace(request.RebateIdentifier) || string.IsNullOrWhiteSpace(request.ProductIdentifier))
		{
			return new CalculateRebateResult { Success = false };
		}

		Rebate? rebate = await _rebateStore.Get(request.RebateIdentifier);
		Product? product = await _productStore.Get(request.ProductIdentifier);

		if (rebate == null || product == null)
		{
			return new CalculateRebateResult { Success = false };
		}

		var calculator = _rebateCalculatorSelector.Select(rebate.Incentive);
		if (calculator == null)
		{
			return new CalculateRebateResult { Success = false };
		}

		var result = calculator.CalculateRebate(rebate, product, request);
		if (result.Success)
		{
			rebate.AmountAwarded = result.RebateAmount;
			await _rebateStore.Save(rebate);
		}

		return result;
	}
}
