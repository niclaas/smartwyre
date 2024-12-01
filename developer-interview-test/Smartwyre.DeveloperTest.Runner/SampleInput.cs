using Smartwyre.DeveloperTest.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smartwyre.DeveloperTest.Runner
{
	internal class SampleInput
	{
		public ICollection<Product> Products { get; set; }
		public ICollection<Rebate> Rebates { get; set; }
	}
}
