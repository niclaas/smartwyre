using Smartwyre.DeveloperTest.Types;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Smartwyre.DeveloperTest.Services;

public interface IRebateService
{
    Task<CalculateRebateResult> CalculateRebate(CalculateRebateRequest request);
	Task<Rebate> AddRebate(Rebate rebate);
	Task<IEnumerable<Rebate>> ListRebates();

	// Should be in it's own service, but can be moved out
	// once product flow is better defined.
	Task<Product> AddProduct(Product product);
	Task<IEnumerable<Product>> ListProducts();
}
