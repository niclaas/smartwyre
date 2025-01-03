﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Smartwyre.DeveloperTest.Data;
using Smartwyre.DeveloperTest.RebateCalculators;
using Smartwyre.DeveloperTest.Runner;
using Smartwyre.DeveloperTest.Services;
using Smartwyre.DeveloperTest.Types;

try
{
	var testRunner = Host.CreateDefaultBuilder(args)
		.ConfigureAppConfiguration((context, config) =>
		{
			config.AddUserSecrets<Program>(optional: true, reloadOnChange: false);
		})
		.ConfigureServices((context, serviceCollection) =>
		{
			serviceCollection.AddHostedService<TestRunnerService>();

			serviceCollection.AddScoped<IRebateService, RebateService>();
			serviceCollection.AddKeyedScoped<IRebateCalculator, AmountPerUomRebateCalculator>(IncentiveType.AmountPerUom);
			serviceCollection.AddKeyedScoped<IRebateCalculator, FixedCashRebateCalculator>(IncentiveType.FixedCashAmount);
			serviceCollection.AddKeyedScoped<IRebateCalculator, FixedRateRebateCalculator>(IncentiveType.FixedRateRebate);

			serviceCollection.AddSingleton<IStore<Product>, Store<Product>>();
			serviceCollection.AddSingleton<IStore<Rebate>, Store<Rebate>>();
		});

	await testRunner.RunConsoleAsync();
}
catch (Exception ex)
{
	Console.WriteLine("Error encountered when trying to run testRunner. Details are:");
	Console.WriteLine(ex.ToString());
}
