using Helpers;
using Mvc.Data;
using System.ComponentModel.DataAnnotations;

namespace Mvc.Domain;

public class Representative(RepresentativeData d): AllPersons<RepresentativeData>(d)
{
    // Esindusõigus
   public EnumRightOfRepresentation? RightOfRepresentation => data?.RightOfRepresentation;
}
