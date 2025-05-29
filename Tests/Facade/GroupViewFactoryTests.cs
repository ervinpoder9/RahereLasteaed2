using Mvc.Data;
using Mvc.Facade;

namespace Mvc.Tests.Facade;

[TestClass] public class GroupViewFactoryTests : SealedTests<GroupViewFactory, AbstractViewFactory<GroupData, GroupView>> {
    private GroupData? data;
    private GroupView? view;
    [TestInitialize] public override void Initialize() {
        base.Initialize();
        data = crData();
        view = crView();
    }
    [TestCleanup] public override void Cleanup() {
        base.Cleanup();
        data = null;
        view = null;
    }
    private GroupView crView() {
        var v = new GroupView {
            Id = 1,
            Name = "Group",
            Capacity = 10,
            PrimaryTeacher = "PTeacher",
            AssistantTeacher = "ATeacher",
            RoomNumber = 100
        };
        return v;
    }
    private GroupData crData() {
        var d = new GroupData {
            Id = 1,
            Name = "Name",
            Capacity = 10,
            PrimaryTeacher = "PTeacher",
            AssistantTeacher = "ATeacher",
            RoomNumber = 100
        };
        return d;
    }
    [TestMethod] public void CreateViewTest() {
        var f = new GroupViewFactory();
        var v = f.CreateView(data);
        notNull(v);
        equal(data?.Id, v.Id);
        equal(data?.Name, v.Name);
        equal(data?.Capacity, v.Capacity);
        equal(data?.PrimaryTeacher, v.PrimaryTeacher);
        equal(data?.AssistantTeacher, v.AssistantTeacher);
        equal(data?.RoomNumber, v.RoomNumber);
    }
    [TestMethod] public void CreateDataTest() {
        var f = new GroupViewFactory();
        var d = f.CreateData(view);
        notNull(d);
        equal(view?.Id, d.Id);
        equal(view?.Name, d.Name);
        equal(view?.Capacity, d.Capacity);
        equal(view?.PrimaryTeacher, d.PrimaryTeacher);
        equal(view?.AssistantTeacher, d.AssistantTeacher);
        equal(view?.RoomNumber, d.RoomNumber);
    }
}
