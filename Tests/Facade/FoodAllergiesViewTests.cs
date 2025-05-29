using Mvc.Domain;
using Mvc.Facade;
using System.ComponentModel.DataAnnotations;

namespace Mvc.Tests.Facade;

[TestClass] public class FoodAllergiesTests : SealedTests<FoodAllergiesView, EntityView> {
    [TestMethod] public override void DisplayNameTest() => isDisplayName("Food Allergies");
    [TestMethod] public void AllergyNameTest() => isProperty<string?>("Allergy Name");
}
