namespace Mvc.Tests;
[TestClass]
public sealed class UnitTests : BaseTests {
    private object? x;
    private object? y;
    [TestInitialize] public void Initialize() {
        x = new object();
        y = new object();
    }
    [TestCleanup] public void Cleanup() {
        x = null;
        y = null;
    }
    [DataRow("abc", "abc")]
    [DataRow(1, 1)]
    [DataRow(1.01, 1.01)]
    [DataRow(true, true)]
    [DataRow(false, false)]
    [TestMethod] public void AreEqualTest(object x,object y) => equal(x, y);
    // [TestMethod] public void AreEqualFailsTest() => equal("aa", "bb");
    [TestMethod] public void AreNotEqualTest() => notEqual(1, 2);
    // [TestMethod] public void AreNotEqualFailsTest() => notEqual("aa", "aa");
    [TestMethod] public void IsTrueTest() => isTrue(true);
    // [TestMethod] public void IsTrueFailsTest() => isTrue(false);
    [TestMethod] public void IsFalseTest() => isFalse(false);
    // [TestMethod] public void IsFalseFailsTest() => isFalse(True);
    [TestMethod] public void IsNullTest() => isNull<Object>(null);
    // [TestMethod] public void IsNullFailsTest() => isNull<Object>("aa");
    [TestMethod] public void IsNotNullTest() => notNull("aa");
    // [TestMethod] public void IsNotNullFailsTest() => notNull(null);
    [TestMethod] public void IsInstanceOfTypeTest() => isType("aa", typeof(string));
    // [TestMethod] public void IsInstanceOfTypeFailsTest() => ofType("aa", typeof(int));
    [TestMethod] public void IsNotInstanceOfTypeTest() => notType("aa", typeof(int));
    // [TestMethod] public void IsNotInstanceOfTypeFailsTest() => notOfType("aa", typeof(string));
    //[TestMethod] public void FailTest() => Assert.Fail();
    // [TestMethod] public void FailFailsTest() => Assert.Fail();
    [TestMethod] public void InconclusiveTest() => notTested("Complete the test");
    [TestMethod] public void SameTest() {
        var y = x;
        same(x, y);
    }
    // [TestMethod] public void SameFailsTest() => same(x, y);
    [TestMethod] public void NotSameTest() => notSame(x, y);
    /* [TestMethod] public void NotSameFailsTest() {
        var y = x;
        notSame(x, y);
    } */
}
