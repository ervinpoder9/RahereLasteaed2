using Mvc.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvc.Facade;

public sealed class RepresentativeViewFactory : AllPersonsViewFactory<RepresentativeData, RepresentativeView>
{
}
