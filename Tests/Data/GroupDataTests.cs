using Mvc.Data;

namespace Mvc.Tests;

[TestClass] public class GroupDataTests : SealedTests<GroupData, EntityData<GroupData>> {
    [TestMethod] public void NameTest() => isProperty<string?>();
    [TestMethod] public void CapacityTest() => isProperty<int>();
    [TestMethod] public void PrimaryTeacherTest() => isProperty<string?>();
    [TestMethod] public void AssistantTeacherTest() => isProperty<string?>();
    [TestMethod] public void RoomNumberTest() => isProperty<int>();
}
