using Mvc.Aids.Gof.Crea;

namespace Mvc.Tests.Aids.Gof.Crea;

[TestClass] public sealed class SingletonTests : BaseTests {
    [TestMethod] public void NewTest() => same(Singleton.New(), Singleton.New());
}
