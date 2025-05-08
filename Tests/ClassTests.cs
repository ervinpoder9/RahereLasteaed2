﻿using System.Reflection;

namespace Mvc.Tests;

public abstract class ClassTests<TClass, TBaseClass> : BaseClassTests<TClass, TBaseClass>
    where TClass : class, new()
    where TBaseClass : class {
    protected override TClass createObj() => new ();
}
public abstract class BaseClassTests<TClass, TBaseClass> : BaseTests
    where TClass : class
    where TBaseClass : class {
    protected TClass? obj;
    protected abstract TClass? createObj();
    [TestInitialize] public virtual void TestInitialize() => obj = createObj();
    [TestCleanup] public virtual void TestCleanup() => obj = null;
    [TestMethod] public void CanCreateTest() => notNull(obj);
    [TestMethod] public void IsTypeOfTest() => isType(obj, typeof(TClass));
    [TestMethod] public void IsBaseTypeOfTest() => equal(obj?.GetType().BaseType, typeof(TBaseClass));
    [TestMethod] public void IsTested() {
        var testMethods = GetType()
            .GetMethods(BindingFlags.Public | BindingFlags.Instance)
            .Where(m => m.GetCustomAttribute<TestMethodAttribute>() != null)
            .Select(m => m.Name).ToArray();

        var members = typeof(TClass)
            .GetMembers(BindingFlags.Public
                        | BindingFlags.Instance
                        | BindingFlags.Static
                        | BindingFlags.DeclaredOnly)
            .Select(m => m.Name)
            .Where(m => !m.Contains("get_") && !m.Contains("set_") && !m.Contains(".ctor"))
            .Where(m => !testMethods.Contains(m + "Test"))
            .ToArray();

        if (members.Length == 0) return;
        var notTestedMembers = string.Join(", ", members);
        if (members.Length == 1)
            notTested($"Test method for <{notTestedMembers}> not found.");
        notTested($"Test methods for <{notTestedMembers}> not found.");
    }
}
