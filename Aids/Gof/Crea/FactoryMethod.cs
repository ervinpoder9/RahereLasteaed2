﻿namespace Mvc.Aids.Gof.Crea;

public class FactoryMethod {
    public static TClass Create<TClass, TInput>(TInput o)
        where TClass: class, new() where TInput: class {
        var x = new TClass();
        x = Copy.Members(o, x);
        return x;
    }
}
