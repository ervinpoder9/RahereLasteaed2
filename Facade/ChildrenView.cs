﻿using Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mvc.Facade;

[DisplayName("Children")] public sealed class ChildrenView : AllPersonsView
{
    private const string vanus = "Vanus";

    // Vanus
    [Display(Name = vanus)]
    public int Age => IDNumber != null ? ChildrenAge.GetAge(IDNumber) : 0;
}
