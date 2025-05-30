using Mvc.Aids.Gof.Crea;

namespace Mvc.Tests.Aids.Gof.Crea;

[TestClass] public sealed class SingletonTests : StaticTests {
    protected override Type setType() => typeof(Singleton);
    [TestMethod] public void NewTest() => same(Singleton.New(), Singleton.New());
}
