using Mvc.Facade;
using System.ComponentModel.DataAnnotations;

namespace Mvc.Tests.Facade;

[TestClass] public class GroupViewTests : SealedTests<GroupView, EntityView> {
    [TestMethod] public override void DisplayNameTest() => isDisplayName("Group");
}

