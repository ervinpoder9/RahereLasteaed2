using Mvc.Data;

namespace Mvc.Tests.Data;

[TestClass] public class FoodAllergiesDataTests : SealedTests<FoodAllergiesData, EntityData<FoodAllergiesData>> {
    [TestMethod] public void AllergyNameTest() => isProperty<string?>();
    [TestMethod] public void ReactionTest() => isProperty<string?>();
    [TestMethod] public void AntidoteTest() => isProperty<string?>();
}
