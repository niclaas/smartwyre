using Newtonsoft.Json.Converters;
using System.Text.Json.Serialization;

namespace Smartwyre.DeveloperTest.Types;

// Just using this for test input json file to make the enum more readable
[JsonConverter(typeof(StringEnumConverter))]
public enum IncentiveType
{
	FixedRateRebate,
	AmountPerUom,
	FixedCashAmount
}
