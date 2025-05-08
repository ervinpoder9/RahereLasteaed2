using System.Reflection;

namespace Mvc.Tests;

public abstract class AssemblyTests(string namespaceName) : BaseTests {
    [TestMethod] public void IsTested() {
        var testNamespace = namespaceName.Replace("Mvc", "Mvc.Tests");
        var testAssembly = Assembly.GetExecutingAssembly();
        var testClasses = testAssembly
            .GetTypes()
            .Where(t => (t?.Namespace is not null) && t.Namespace.StartsWith(testNamespace))
            .Select(t => t.Name)
            .ToArray();

        var domain = AppDomain.CurrentDomain;
        var assemblies = domain.GetAssemblies();
        namespaceName = namespaceName.Replace("Mvc", "");

        var assembly = assemblies
            .FirstOrDefault(a => (a?.FullName is not null) && a.FullName.StartsWith(namespaceName));
        if (assembly == null) notTested($"Assembly {namespaceName} not found.");

        var classes = assembly?
            .GetTypes()
            .Select(t => t.Name).Select(t => {
                var i = t.IndexOf('`');
                return i > 0 ? t.Substring(0, i) : t;
            })
            .Distinct()
            .Where(t => !testClasses.Contains(t + "Tests")).ToArray();

        if (classes?.Length == 0) return;
        var notTestedClasses = string.Join(", ", classes ?? []);
        if (classes?.Length == 1)
            notTested($"Test class for <{notTestedClasses}> not found.");
        notTested($"Test classes for <{notTestedClasses}> not found.");
    }
}