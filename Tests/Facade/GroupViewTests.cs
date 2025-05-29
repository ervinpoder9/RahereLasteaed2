using System.ComponentModel.DataAnnotations;
using System.Drawing;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Mvc.Facade;

namespace Mvc.Tests.Facade;

[TestClass] public class GroupViewTests : SealedTests<GroupView, EntityView> {
    [TestMethod] public override void DisplayNameTest() => isDisplayName("Group");
    [TestMethod] public void NameTest() => isProperty<string?>("Group Name");
    [TestMethod] public void CapacityTest() => isProperty<int>("Group Size");
    [TestMethod] public void RoomNumberTest() => isProperty<int>("Room Number");
}

