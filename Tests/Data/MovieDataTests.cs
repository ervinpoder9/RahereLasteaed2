using Mvc.Data;

namespace Mvc.Tests.Data;

[TestClass] public class MovieDataTests : SealedTests<MovieData, EntityData<MovieData>> {
    [TestMethod] public void TitleTest() => isProperty<string?>();
    [TestMethod] public void ReleaseDateTest() => isProperty<DateTime>();
    [TestMethod] public void PriceTest() => isProperty<double>();
    [TestMethod] public void GenreTest() => isProperty<string?>();
    [TestMethod] public void RatingTest() => isProperty<string?>();
}
