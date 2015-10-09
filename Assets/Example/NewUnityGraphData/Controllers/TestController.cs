using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UniRx;
using uFrame.Serialization;
using uFrame.MVVM;
using uFrame.Kernel;
using uFrame.IOC;
using UnityEngine;


public class TestController : TestControllerBase {
    
    public override void InitializeTest(TestViewModel viewModel) {
        base.InitializeTest(viewModel);
        // This is called when a TestElementViewModel is created
    }
    
    public override void DoSomething(TestViewModel viewModel) {
        base.DoSomething(viewModel);

        Debug.Log("Doing Something");
    }


    public override void DoSomethingElse(TestViewModel viewModel, Boolean arg) {
        base.DoSomethingElse(viewModel, arg);

        Debug.Log("The Value Is " + arg);
    }

    public override void CommandReference(TestViewModel viewModel, SomeTypeReference arg) {
        base.CommandReference(viewModel, arg);
    }
}
