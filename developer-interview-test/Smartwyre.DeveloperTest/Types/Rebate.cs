namespace Smartwyre.DeveloperTest.Types;

/// <summary>
/// Rebate did not have an id, but a string identifier.
/// Product has an int id, AND a string identifier.
/// I decided to standardise on the int id for database
/// entries and leave the identifier for user readable
/// discriptions
/// </summary>
public class Rebate : Entity
{
	public IncentiveType Incentive { get; set; }
	public decimal Amount { get; set; }
	public decimal Percentage { get; set; }

	// Storing amount awarded in the Rebate class, but could
	// easily be a separated referenced object with details
	// on date awarded and id of service/user awarding it.
	public decimal AmountAwarded { get; set; }
}
