using Mvc.Data;
using Mvc.Domain;

namespace Mvc.Tests.Domain;

[TestClass] public class GroupTests : BaseClassTests<Group, Entity<GroupData>> {
    protected override Group createObj() {
        var d = new GroupData {
            Id = 1,
            Name = "Name",
            Capacity = 10,
            PrimaryTeacher = "PTeacher",
            AssistantTeacher = "ATeacher",
            RoomNumber = 100
        };
        return new Group(d);
    }
    [TestMethod] public void NameTest() => equal("Name", obj?.Name);
    [TestMethod] public void CapacityTest() => equal(10, obj?.Capacity);
    [TestMethod] public void PrimaryTeacherTest() => equal("PTeacher", obj?.PrimaryTeacher);
    [TestMethod] public void AssistantTeacherTest() => equal("ATeacher", obj?.AssistantTeacher);
    [TestMethod] public void RoomNumberTest() => equal(100, obj?.RoomNumber);
    [TestMethod] public void IdTest() => equal(1, obj?.Id);
    [TestMethod] public void DataTest() => notNull(obj?.data);
}
