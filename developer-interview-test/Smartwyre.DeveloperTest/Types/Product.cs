using System.Collections.Generic;

namespace Smartwyre.DeveloperTest.Types;

public class Product : Entity
{
	/// <summary>
	/// Removing Id and will use Identifier to find in database.
	/// I assume identifier could be an externally produced value
	/// from another database, but not catering for that in this
	/// implementation.
	/// </summary>
	//public int Id { get; set; }
	public string Description { get; set; }
	public decimal Price { get; set; }
	public string Uom { get; set; }
	public IEnumerable<IncentiveType> SupportedIncentives { get; set; }
}
