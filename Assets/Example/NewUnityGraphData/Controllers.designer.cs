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
using uFrame.Kernel;
using uFrame.MVVM;
using uFrame.IOC;
using uFrame.Serialization;
using UniRx;


public class TestControllerBase : uFrame.MVVM.Controller {
    
    private uFrame.MVVM.IViewModelManager _TestViewModelManager;
    
    [uFrame.IOC.InjectAttribute("Test")]
    public uFrame.MVVM.IViewModelManager TestViewModelManager {
        get {
            return _TestViewModelManager;
        }
        set {
            _TestViewModelManager = value;
        }
    }
    
    public IEnumerable<TestViewModel> TestViewModels {
        get {
            return TestViewModelManager.OfType<TestViewModel>();
        }
    }
    
    public override void Setup() {
        base.Setup();
        // This is called when the controller is created
    }
    
    public override void Initialize(uFrame.MVVM.ViewModel viewModel) {
        base.Initialize(viewModel);
        // This is called when a viewmodel is created
        this.InitializeTest(((TestViewModel)(viewModel)));
    }
    
    public virtual TestViewModel CreateTest() {
        return ((TestViewModel)(this.Create(Guid.NewGuid().ToString())));
    }
    
    public override uFrame.MVVM.ViewModel CreateEmpty() {
        return new TestViewModel(this.EventAggregator);
    }
    
    public virtual void InitializeTest(TestViewModel viewModel) {
        // This is called when a TestViewModel is created
        viewModel.DoSomething.Action = this.DoSomethingHandler;
        viewModel.DoSomethingElse.Action = this.DoSomethingElseHandler;
        TestViewModelManager.Add(viewModel);
    }
    
    public override void DisposingViewModel(uFrame.MVVM.ViewModel viewModel) {
        base.DisposingViewModel(viewModel);
        TestViewModelManager.Remove(viewModel);
    }
    
    public virtual void DoSomething(TestViewModel viewModel) {
    }
    
    public virtual void DoSomethingHandler(DoSomethingCommand command) {
        this.DoSomething(command.Sender as TestViewModel);
    }
    
    public virtual void DoSomethingElseHandler(DoSomethingElseCommand command) {
        this.DoSomethingElse(command.Sender as TestViewModel, command.Argument);
    }
    
    public virtual void DoSomethingElse(TestViewModel viewModel, Boolean arg) {
    }
}
