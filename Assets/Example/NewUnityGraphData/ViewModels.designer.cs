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
using uFrame.IOC;
using uFrame.Kernel;
using uFrame.MVVM;
using uFrame.MVVM.Bindings;
using uFrame.Serialization;
using UnityEngine;
using UniRx;


public partial class TestViewModelBase : uFrame.MVVM.ViewModel {
    
    private System.IDisposable _IsNameFrankDisposable;
    
    private P<Boolean> _IsNameFrankProperty;
    
    private P<String> _NameProperty;
    
    private P<Boolean> _IsAmazingProperty;
    
    private P<AmazingClass> _ComplexProperty;
    
    private Signal<DoSomethingCommand> _DoSomething;
    
    private Signal<DoSomethingElseCommand> _DoSomethingElse;
    
    public TestViewModelBase(uFrame.Kernel.IEventAggregator aggregator) : 
            base(aggregator) {
    }
    
    public virtual P<Boolean> IsNameFrankProperty {
        get {
            return _IsNameFrankProperty;
        }
        set {
            _IsNameFrankProperty = value;
        }
    }
    
    public virtual P<String> NameProperty {
        get {
            return _NameProperty;
        }
        set {
            _NameProperty = value;
        }
    }
    
    public virtual P<Boolean> IsAmazingProperty {
        get {
            return _IsAmazingProperty;
        }
        set {
            _IsAmazingProperty = value;
        }
    }
    
    public virtual P<AmazingClass> ComplexProperty {
        get {
            return _ComplexProperty;
        }
        set {
            _ComplexProperty = value;
        }
    }
    
    public virtual Boolean IsNameFrank {
        get {
            return IsNameFrankProperty.Value;
        }
        set {
            IsNameFrankProperty.Value = value;
        }
    }
    
    public virtual String Name {
        get {
            return NameProperty.Value;
        }
        set {
            NameProperty.Value = value;
        }
    }
    
    public virtual Boolean IsAmazing {
        get {
            return IsAmazingProperty.Value;
        }
        set {
            IsAmazingProperty.Value = value;
        }
    }
    
    public virtual AmazingClass Complex {
        get {
            return ComplexProperty.Value;
        }
        set {
            ComplexProperty.Value = value;
        }
    }
    
    public virtual Signal<DoSomethingCommand> DoSomething {
        get {
            return _DoSomething;
        }
        set {
            _DoSomething = value;
        }
    }
    
    public virtual Signal<DoSomethingElseCommand> DoSomethingElse {
        get {
            return _DoSomethingElse;
        }
        set {
            _DoSomethingElse = value;
        }
    }
    
    public override void Bind() {
        base.Bind();
        this.DoSomething = new Signal<DoSomethingCommand>(this);
        this.DoSomethingElse = new Signal<DoSomethingElseCommand>(this);
        _IsNameFrankProperty = new P<Boolean>(this, "IsNameFrank");
        _NameProperty = new P<String>(this, "Name");
        _IsAmazingProperty = new P<Boolean>(this, "IsAmazing");
        _ComplexProperty = new P<AmazingClass>(this, "Complex");
        ResetIsNameFrank();
    }
    
    public virtual void ExecuteDoSomething() {
        this.DoSomething.OnNext(new DoSomethingCommand());
    }
    
    public virtual void ExecuteDoSomethingElse(Boolean argument) {
        this.DoSomethingElse.OnNext(new DoSomethingElseCommand(){Argument = argument});
    }
    
    public override void Read(ISerializerStream stream) {
        base.Read(stream);
        this.IsAmazing = stream.DeserializeBool("IsAmazing");;
    }
    
    public override void Write(ISerializerStream stream) {
        base.Write(stream);
        stream.SerializeBool("IsAmazing", this.IsAmazing);
    }
    
    protected override void FillCommands(System.Collections.Generic.List<uFrame.MVVM.ViewModelCommandInfo> list) {
        base.FillCommands(list);
        list.Add(new ViewModelCommandInfo("DoSomething", DoSomething) { ParameterType = typeof(void) });
        list.Add(new ViewModelCommandInfo("DoSomethingElse", DoSomethingElse) { ParameterType = typeof(Boolean) });
    }
    
    protected override void FillProperties(System.Collections.Generic.List<uFrame.MVVM.ViewModelPropertyInfo> list) {
        base.FillProperties(list);
        // ComputedPropertyNode
        list.Add(new ViewModelPropertyInfo(_IsNameFrankProperty, false, false, false, true));
        // PropertiesChildItem
        list.Add(new ViewModelPropertyInfo(_NameProperty, false, false, false, false));
        // PropertiesChildItem
        list.Add(new ViewModelPropertyInfo(_IsAmazingProperty, false, false, false, false));
        // PropertiesChildItem
        list.Add(new ViewModelPropertyInfo(_ComplexProperty, false, false, false, false));
    }
    
    public virtual System.Collections.Generic.IEnumerable<uFrame.MVVM.IObservableProperty> GetIsNameFrankDependents() {
        yield return NameProperty;
        yield break;
    }
    
    public virtual void ResetIsNameFrank() {
        if (_IsNameFrankDisposable != null) {
            _IsNameFrankDisposable.Dispose();
        }
        _IsNameFrankDisposable = _IsNameFrankProperty.ToComputed(ComputeIsNameFrank, this.GetIsNameFrankDependents().ToArray()).DisposeWith(this);
    }
    
    public virtual Boolean ComputeIsNameFrank() {
        return default(Boolean);
    }
}

public partial class TestViewModel {
    
    public TestViewModel(uFrame.Kernel.IEventAggregator aggregator) : 
            base(aggregator) {
    }
}
