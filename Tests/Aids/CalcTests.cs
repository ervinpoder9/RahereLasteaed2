using Mvc.Aids;

namespace Mvc.Tests.Aids;

[TestClass]
public sealed class CalcTests : StaticTests {
    protected override Type setType() => typeof(Calc);
    [TestMethod] public void AddTest() => Assert.AreEqual(4, Calc.Add(2, 2));
    [TestMethod] public void SubtractTest() => Assert.AreEqual(0, Calc.Subtract(2, 2));
    [TestMethod] public void MultiplyTest() => Assert.AreEqual(4, Calc.Multiply(2, 2));
    [TestMethod] public void DivideTest() => Assert.AreEqual(1, Calc.Divide(2, 2));

    [TestMethod, ExpectedException(typeof(DivideByZeroException))]
    public void DivideByZeroTest() => Calc.Divide(2, 0);
}
