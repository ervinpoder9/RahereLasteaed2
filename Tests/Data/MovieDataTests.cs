using Mvc.Data;

namespace Mvc.Tests.Data;

[TestClass] public class MovieDataTests : SealedTests<MovieData, EntityData<MovieData>> {
    [TestInitialize] public override void TestInitialize() {
        base.TestInitialize();
        if (obj == null) return;
        obj.Id = 1;
        obj.Title = "Title";
        obj.Price = 1.0;
        obj.ReleaseDate = DateTime.Today;
        obj.Genre = "Genre";
        obj.Rating = "Rating";
    }
    [TestMethod] public void CloneTest() {
        var d = obj?.Clone();
        notNull(d);
        equal(1, d?.Id);
        equal("Title", d?.Title);
        equal(1.0, d?.Price);
        equal(DateTime.Today, d?.ReleaseDate);
        equal("Genre", d?.Genre);
        equal("Rating", d?.Rating);
    }
}
