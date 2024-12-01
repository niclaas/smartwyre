namespace Smartwyre.DeveloperTest.Types;

// Doesn't make sense to have two enums to associate the same types.
// Also, this enum will limit the total number of rebates supported
// to 32 because the underlying type of an enum is int32. Not a good
// choice if we want to support many IncentiveTypes in the future.
//public enum SupportedIncentiveType
//{
//    FixedRateRebate = 1 << 0,
//    AmountPerUom = 1 << 1,
//    FixedCashAmount = 1 << 2,
//}
