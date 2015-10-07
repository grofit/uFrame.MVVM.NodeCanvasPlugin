using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using uFrame.IOC;
using uFrame.Kernel;
using uFrame.MVVM;
using uFrame.MVVM.Bindings;
using uFrame.Serialization;
using UnityEngine;
using UniRx;


public partial class TestViewModel : TestViewModelBase
{
    public override bool ComputeIsNameFrank()
    {
        return Name.ToLower().Equals("frank");
    }
}
