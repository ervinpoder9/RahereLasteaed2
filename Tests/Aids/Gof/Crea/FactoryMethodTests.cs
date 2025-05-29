using Mvc.Aids.Gof.Crea;

namespace Mvc.Tests.Aids.Gof.Crea;

[TestClass] public sealed class FactoryMethodTests : StaticTests {
    protected override Type? setType() => typeof(FactoryMethod);
    [TestMethod] public void CreateTest() {
        var x = new CopyTestClass1() {
            Id = 10001,
            Name = "Aaa Bbb Ccc",
            ValidFrom = DateTime.Now
        };
        var y = FactoryMethod.Create<CopyTestClass2, CopyTestClass1>(x);
        isType(y, typeof(CopyTestClass2));
        equal("Aaa Bbb Ccc", y.Name);
        isNull(y.Id);
    }
}
