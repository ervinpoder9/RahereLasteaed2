using Mvc.Data;
using Mvc.Domain;

namespace Mvc.Tests.Domain;

[TestClass] public class FoodAllergiesTests : BaseClassTests<FoodAllergies, Entity<FoodAllergiesData>> {
    protected override FoodAllergies createObj() {
        var d = new FoodAllergiesData {
            Id = 1,
            AllergyName = "Allergy",
            Reaction = "Reaction",
            Antidote = "Antidote"
        };
        return new FoodAllergies(d);
    }
    [TestMethod] public void AllergyNameTest() => equal("Allergy", obj?.AllergyName);
    [TestMethod] public void ReactionTest() => equal("Reaction", obj?.Reaction);
    [TestMethod] public void AntidoteTest() => equal("Antidote", obj?.Antidote);
    [TestMethod] public void IdTest() => equal(1, obj?.Id);
    [TestMethod] public void DataTest() => notNull(obj?.data);
}
