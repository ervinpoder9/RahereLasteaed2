using Mvc.Data;
using Mvc.Domain;

namespace Mvc.Tests.Domain;

[TestClass] public class GroupTests : BaseClassTests<Group, Entity<GroupData>> {
    protected override Group createObj() {
        var d = new GroupData {
            Id = 1,
            Name = "Name",
            Capacity = DateTime.Today,
            PrimaryTeacher = "Genre",
            AssistantTeacher = "Rating",
            RoomNumber = 100
        };
        return new Group(d);
    }
    [TestMethod] public void TitleTest() => equal("Title", obj?.Title);
    [TestMethod] public void ReleaseDateTest() => equal(DateTime.Today, obj?.ReleaseDate);
    [TestMethod] public void GenreTest() => equal("Genre", obj?.Genre);
    [TestMethod] public void PriceTest() => equal(1.0, obj?.Price);
    [TestMethod] public void RatingTest() => equal("Rating", obj?.Rating);
    [TestMethod] public void IdTest() => equal(1, obj?.Id);
    [TestMethod] public void DataTest() => notNull(obj?.data);
}
