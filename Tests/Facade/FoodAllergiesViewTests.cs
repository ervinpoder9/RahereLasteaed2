using Mvc.Facade;

namespace Mvc.Tests.Facade;

[TestClass] public class FoodAllergiesViewTests : SealedTests<FoodAllergiesView, EntityView> {
    [TestMethod] public override void DisplayNameTest() => isDisplayName("Food Allergies");
    [TestMethod] public void AllergyNameTest() => isProperty<string?>("Allergy Name");
    [TestMethod] public void ReactionTest() => isProperty<string?>(null);
    [TestMethod] public void AntidoteTest() => isProperty<string?>(null);
}
