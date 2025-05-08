using Mvc.Data;
using Mvc.Facade;
using Random = Mvc.Aids.Random;

namespace Mvc.Tests.Facade;

[TestClass] public class MovieViewFactoryTests : BaseTests {
    private MovieData? data;
    private MovieView? view;
    [TestInitialize] public void TestInitialize() {
        data = crData();
        view = crView();
    }
    [TestCleanup] public void TestCleanup() {
        data = null;
        view = null;
    }
    private MovieView crView() => new() {
        Id = Random.Int32(),
        Title = "Title",
        ReleaseDate = DateTime.Now,
        Price = 1,
        Genre = "Genre",
        Rating = "Rating"
    };
    private MovieData crData() => new() {
        Id = Random.Int32(),
        Title = "Title",
        ReleaseDate = DateTime.Now,
        Price = 1,
        Genre = "Genre",
        Rating = "Rating"
    };
    [TestMethod] public void CreateViewTest() {
        var f = new MovieViewFactory();
        var v = f.CreateView(data);
        notNull(v);
        equal(data?.Id, v.Id);
        equal(data?.Title, v.Title);
        equal(data?.ReleaseDate, v.ReleaseDate);
        equal(data?.Price, v.Price);
        equal(data?.Genre, v.Genre);
        equal(data?.Rating, v.Rating);
    }
    [TestMethod] public void CreateDataTest() {
        var f = new MovieViewFactory();
        var d = f.CreateData(view);
        notNull(d);
        equal(view?.Id, d.Id);
        equal(view?.Title, d.Title);
        equal(view?.ReleaseDate, d.ReleaseDate);
        equal(view?.Price, d.Price);
        equal(view?.Genre, d.Genre);
        equal(view?.Rating, d.Rating);
    }
}
