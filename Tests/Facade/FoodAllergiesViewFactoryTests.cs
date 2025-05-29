using Mvc.Data;
using Mvc.Facade;

namespace Mvc.Tests.Facade;

[TestClass] public class FoodAllergiesViewFactoryTests 
    : SealedTests<FoodAllergiesViewFactory, AbstractViewFactory<FoodAllergiesData, FoodAllergiesView>> {
    private FoodAllergiesData? data;
    private FoodAllergiesView? view;
    [TestInitialize] public override void Initialize() {
        base.Initialize();
        data = crData();
        view = crView();
    }
    [TestCleanup] public override void Cleanup() {
        base.Cleanup();
        data = null;
        view = null;
    }
    private FoodAllergiesView crView() {
        var v = new FoodAllergiesView {
            Id = 1,
            AllergyName = "Allergy",
            Reaction = "Reaction",
            Antidote = "Antidote"
        };
        return v;
    }
    private FoodAllergiesData crData() {
        var d = new FoodAllergiesData {
            Id = 1000,
            AllergyName = "Allergy",
            Reaction = "Reaction",
            Antidote = "Antidote"
        };
        return d;
    }
    [TestMethod] public void CreateViewTest() {
        var f = new FoodAllergiesViewFactory();
        var v = f.CreateView(data);
        notNull(v);
        equal(data?.Id, v.Id);
        equal(data?.AllergyName, v.AllergyName);
        equal(data?.Reaction, v.Reaction);
        equal(data?.Antidote, v.Antidote);
    }
    [TestMethod] public void CreateDataTest() {
        var f = new FoodAllergiesViewFactory();
        var d = f.CreateData(view);
        notNull(d);
        equal(view?.Id, d.Id);
        equal(view?.AllergyName, d.AllergyName);
        equal(view?.Reaction, d.Reaction);
        equal(view?.Antidote, d.Antidote);
    }
}