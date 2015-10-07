// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 2.0.50727.1433
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using uFrame.MVVM;


[ParadoxNotion.Design.CategoryAttribute("ViewModels/TestViewModel")]
[ParadoxNotion.Design.NameAttribute("Set Name")]
public class SetNameAction : NodeCanvas.Framework.ActionTask {
    
    [ParadoxNotion.Design.RequiredFieldAttribute()]
    public BBParameter<String> NewValue;
    
    private TestViewModel _viewModel;
    
    private ViewBase _view;
    
    protected override string info {
        get {
            return "Set Name On TestViewModel";
        }
    }
    
    protected override string OnInit() {
        _view = agent.GetComponent<ViewBase>();
        return base.OnInit();
    }
    
    protected override void OnExecute() {
        if (_view.IsBound) {
            if (_viewModel == null) {
                _viewModel = _view.ViewModelObject as TestViewModel;
            }
        }
        else {
            EndAction(false); return;
        }
        _viewModel.Name = NewValue.value;
        EndAction(true);
    }
}

[ParadoxNotion.Design.CategoryAttribute("ViewModels/TestViewModel")]
[ParadoxNotion.Design.NameAttribute("Get Name")]
public class GetNameAction : NodeCanvas.Framework.ActionTask {
    
    [NodeCanvas.Framework.BlackboardOnlyAttribute()]
    public BBParameter<String> CurrentValue;
    
    private TestViewModel _viewModel;
    
    private ViewBase _view;
    
    protected override string info {
        get {
            return "Get Name From TestViewModel";
        }
    }
    
    protected override string OnInit() {
        _view = agent.GetComponent<ViewBase>();
        return base.OnInit();
    }
    
    protected override void OnExecute() {
        if (_view.IsBound) {
            if (_viewModel == null) {
                _viewModel = _view.ViewModelObject as TestViewModel;
            }
        }
        else {
            EndAction(false); return;
        }
        CurrentValue.value = _viewModel.Name;
        EndAction(true);
    }
}

[ParadoxNotion.Design.CategoryAttribute("ViewModels/TestViewModel")]
[ParadoxNotion.Design.NameAttribute("Execute DoSomething")]
public class ExecuteDoSomethingAction : NodeCanvas.Framework.ActionTask {
    
    private TestViewModel _viewModel;
    
    private ViewBase _view;
    
    protected override string info {
        get {
            return "Execute DoSomething On TestViewModel";
        }
    }
    
    protected override string OnInit() {
        _view = agent.GetComponent<ViewBase>();
        return base.OnInit();
    }
    
    protected override void OnExecute() {
        if (_view.IsBound) {
            if (_viewModel == null) {
                _viewModel = _view.ViewModelObject as TestViewModel;
            }
        }
        else {
            EndAction(false); return;
        }
        _viewModel.DoSomething.OnNext(new DoSomethingCommand { Sender = _viewModel });
        EndAction(true);
    }
}

[ParadoxNotion.Design.CategoryAttribute("ViewModels/TestViewModel")]
[ParadoxNotion.Design.NameAttribute("Execute DoSomethingElse")]
public class ExecuteDoSomethingElseAction : NodeCanvas.Framework.ActionTask {
    
    private TestViewModel _viewModel;
    
    private ViewBase _view;
    
    [ParadoxNotion.Design.RequiredFieldAttribute()]
    public BBParameter<Boolean> CommandArgument;
    
    protected override string info {
        get {
            return "Execute DoSomethingElse On TestViewModel";
        }
    }
    
    protected override string OnInit() {
        _view = agent.GetComponent<ViewBase>();
        return base.OnInit();
    }
    
    protected override void OnExecute() {
        if (_view.IsBound) {
            if (_viewModel == null) {
                _viewModel = _view.ViewModelObject as TestViewModel;
            }
        }
        else {
            EndAction(false); return;
        }
        _viewModel.DoSomethingElse.OnNext(new DoSomethingElseCommand { Sender = _viewModel, Argument = CommandArgument.value });
        EndAction(true);
    }
}

[ParadoxNotion.Design.CategoryAttribute("ViewModels/TestViewModel")]
[ParadoxNotion.Design.NameAttribute("Set IsAmazing")]
public class SetIsAmazingAction : NodeCanvas.Framework.ActionTask {
    
    [ParadoxNotion.Design.RequiredFieldAttribute()]
    public BBParameter<Boolean> NewValue;
    
    private TestViewModel _viewModel;
    
    private ViewBase _view;
    
    protected override string info {
        get {
            return "Set IsAmazing On TestViewModel";
        }
    }
    
    protected override string OnInit() {
        _view = agent.GetComponent<ViewBase>();
        return base.OnInit();
    }
    
    protected override void OnExecute() {
        if (_view.IsBound) {
            if (_viewModel == null) {
                _viewModel = _view.ViewModelObject as TestViewModel;
            }
        }
        else {
            EndAction(false); return;
        }
        _viewModel.IsAmazing = NewValue.value;
        EndAction(true);
    }
}

[ParadoxNotion.Design.CategoryAttribute("ViewModels/TestViewModel")]
[ParadoxNotion.Design.NameAttribute("Get IsAmazing")]
public class GetIsAmazingAction : NodeCanvas.Framework.ActionTask {
    
    [NodeCanvas.Framework.BlackboardOnlyAttribute()]
    public BBParameter<Boolean> CurrentValue;
    
    private TestViewModel _viewModel;
    
    private ViewBase _view;
    
    protected override string info {
        get {
            return "Get IsAmazing From TestViewModel";
        }
    }
    
    protected override string OnInit() {
        _view = agent.GetComponent<ViewBase>();
        return base.OnInit();
    }
    
    protected override void OnExecute() {
        if (_view.IsBound) {
            if (_viewModel == null) {
                _viewModel = _view.ViewModelObject as TestViewModel;
            }
        }
        else {
            EndAction(false); return;
        }
        CurrentValue.value = _viewModel.IsAmazing;
        EndAction(true);
    }
}

[ParadoxNotion.Design.CategoryAttribute("ViewModels/TestViewModel")]
[ParadoxNotion.Design.NameAttribute("Check IsAmazing")]
public class CheckIsAmazingAction : NodeCanvas.Framework.ConditionTask {
    
    private TestViewModel _viewModel;
    
    private ViewBase _view;
    
    protected override string info {
        get {
            return "TestViewModel's IsAmazing";
        }
    }
    
    protected override string OnInit() {
        _view = agent.GetComponent<ViewBase>();
        return base.OnInit();
    }
    
    protected override bool OnCheck() {
        if (_view.IsBound) {
            if (_viewModel == null) {
                _viewModel = _view.ViewModelObject as TestViewModel;
            }
        }
        else {
            return false;
        }
        return _viewModel.IsAmazing;
    }
}

[ParadoxNotion.Design.CategoryAttribute("ViewModels/TestViewModel")]
[ParadoxNotion.Design.NameAttribute("Set Complex")]
public class SetComplexAction : NodeCanvas.Framework.ActionTask {
    
    [ParadoxNotion.Design.RequiredFieldAttribute()]
    public BBParameter<AmazingClass> NewValue;
    
    private TestViewModel _viewModel;
    
    private ViewBase _view;
    
    protected override string info {
        get {
            return "Set Complex On TestViewModel";
        }
    }
    
    protected override string OnInit() {
        _view = agent.GetComponent<ViewBase>();
        return base.OnInit();
    }
    
    protected override void OnExecute() {
        if (_view.IsBound) {
            if (_viewModel == null) {
                _viewModel = _view.ViewModelObject as TestViewModel;
            }
        }
        else {
            EndAction(false); return;
        }
        _viewModel.Complex = NewValue.value;
        EndAction(true);
    }
}

[ParadoxNotion.Design.CategoryAttribute("ViewModels/TestViewModel")]
[ParadoxNotion.Design.NameAttribute("Get Complex")]
public class GetComplexAction : NodeCanvas.Framework.ActionTask {
    
    [NodeCanvas.Framework.BlackboardOnlyAttribute()]
    public BBParameter<AmazingClass> CurrentValue;
    
    private TestViewModel _viewModel;
    
    private ViewBase _view;
    
    protected override string info {
        get {
            return "Get Complex From TestViewModel";
        }
    }
    
    protected override string OnInit() {
        _view = agent.GetComponent<ViewBase>();
        return base.OnInit();
    }
    
    protected override void OnExecute() {
        if (_view.IsBound) {
            if (_viewModel == null) {
                _viewModel = _view.ViewModelObject as TestViewModel;
            }
        }
        else {
            EndAction(false); return;
        }
        CurrentValue.value = _viewModel.Complex;
        EndAction(true);
    }
}