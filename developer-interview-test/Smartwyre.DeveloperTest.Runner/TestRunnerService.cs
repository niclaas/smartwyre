using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Smartwyre.DeveloperTest.Services;
using Smartwyre.DeveloperTest.Types;
using System.Runtime.CompilerServices;

namespace Smartwyre.DeveloperTest.Runner
{
	internal class TestRunnerService : IHostedService
	{
		private readonly IRebateService _rebateService;

		public TestRunnerService(IRebateService rebateService)
		{
			_rebateService = rebateService;
		}

		public async Task StartAsync(CancellationToken cancellationToken)
		{
			using (var fs = File.OpenRead("SampleInput.json"))
			{
				using (var textReader = new StreamReader(fs))
				{
					string input = textReader.ReadToEnd();
					var sampleInput = JsonConvert.DeserializeObject<SampleInput>(input);

					foreach(var product in sampleInput.Products)
					{
						await _rebateService.AddProduct(product);
					}

					foreach (var rebate in sampleInput.Rebates)
					{
						await _rebateService.AddRebate(rebate);
					}
				}
			}

			Console.WriteLine("ISSUE REBATE");
			Console.WriteLine();
			Console.WriteLine("Products");
			Console.WriteLine("========");

			var products = await _rebateService.ListProducts();
			int i = 1;
			foreach (var product in products)
			{
				Console.Write($"{i}. {product.Description} [");
				bool firstPrinted = false;
				foreach (var incentive in product.SupportedIncentives)
				{
					if (firstPrinted)
						Console.Write(",");

					Console.Write(incentive);

					firstPrinted = true;
				}
				Console.WriteLine("]");
				i++;
			}

			Console.WriteLine();
			Console.Write("Select product for rebate: ");
			var productIdxStr = Console.ReadLine();

			int productIdx = 0;
			while (productIdx < 1 || productIdx >= i)
			{
				if (!int.TryParse(productIdxStr, out productIdx) || productIdx < 1 || productIdx >= i)
				{
					Console.Write("Invalid product identifier. Please try again: ");
					productIdxStr = Console.ReadLine();
				}
			}

			var selectedProduct = products.ElementAt(productIdx - 1);

			Console.WriteLine();
			Console.WriteLine("Rebates");
			Console.WriteLine("=======");

			var rebates = await _rebateService.ListRebates();
			i = 1;
			foreach (var rebate in rebates)
			{
				Console.WriteLine($"{i}. {rebate.Incentive} - {rebate.Percentage}% - {rebate.Amount}");
				i++;
			}

			Console.WriteLine();
			Console.Write("Select rebate to process: ");
			var rebateIdxStr = Console.ReadLine();

			int rebateIdx = 0;
			while (rebateIdx < 1 || rebateIdx >= i)
			{
				if (!int.TryParse(rebateIdxStr, out rebateIdx) || rebateIdx < 1 || rebateIdx >= i)
				{
					Console.Write("Invalid rebate identifier. Please try again: ");
					rebateIdxStr = Console.ReadLine();
				}
			}

			var selectedRebate = rebates.ElementAt(rebateIdx - 1);

			Console.WriteLine();
			Console.Write("Volume: ");
			var volumeStr = Console.ReadLine();
			decimal volume = -1;

			while (volume < 0)
			{
				if (!decimal.TryParse(volumeStr, out volume) || volume < 0)
				{
					Console.Write("Volume must be decimal of 0 or more. Try again: ");
					volumeStr = Console.ReadLine();
				}
			}

			var result = await _rebateService.CalculateRebate(new Types.CalculateRebateRequest
			{
				ProductIdentifier = selectedProduct.Identifier,
				RebateIdentifier = selectedRebate.Identifier,
				Volume = volume
			});

			Console.WriteLine();
			Console.WriteLine($"RESULT: {result.Success}");
			if (result.Success)
			{
				Console.WriteLine($"Amount Awarded: {result.RebateAmount}");
			}

			Console.WriteLine();
			Console.WriteLine("=======================");
		}

		public Task StopAsync(CancellationToken cancellationToken)
		{
			return Task.CompletedTask;
		}
	}
}
