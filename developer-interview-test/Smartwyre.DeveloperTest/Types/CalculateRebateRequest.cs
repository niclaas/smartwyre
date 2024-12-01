namespace Smartwyre.DeveloperTest.Types;

public class CalculateRebateRequest : ICalculateRebateBaseRequest
{
	public string RebateIdentifier { get; set; }

	public string ProductIdentifier { get; set; }

	public decimal Volume { get; set; }
}
