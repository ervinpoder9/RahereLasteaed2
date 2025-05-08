using Mvc.Aids.Gof.Crea;

namespace Mvc.Tests.Aids.Gof.Crea;

[TestClass] public sealed class FactoryMethodTests : BaseTests {
    [TestMethod] public void CreateTest() {
        var x = new CopyTestClass1() { Id = 1000, Name = "Aa Aa", ValidFrom = DateTime.Now };
        var y = FactoryMethod.Create<CopyTestClass2, CopyTestClass1>(x);
        isType(y, typeof(CopyTestClass2));
        equal("Aa Aa", y.Name);
        isNull(y.Id);
    }
}
