using Helpers;
using System.ComponentModel;

namespace Mvc.Facade;

[DisplayName("Children")] public sealed class ChildrenView : AllPersonsView
{
    public int Age => IDNumber != null ? ChildrenAge.GetAge(IDNumber) : 0;
}
