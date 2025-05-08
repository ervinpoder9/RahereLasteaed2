using System.ComponentModel;

namespace Mvc.Data;

public enum Roles {
    [Description("Määratlemata")] Unspecified = 0,
    [Description("Näitleja")] Actor = 1,
    [Description("Režissöör")] Director = 2,
    [Description("Produtsent")] Producer = 3,
    [Description("Stsenarist")] Writer = 4,
    [Description("Operaator")] Operator = 5,
    [Description("Kujundaja")] Decorator = 6
}