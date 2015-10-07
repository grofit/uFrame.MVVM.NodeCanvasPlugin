using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using uFrame.IOC;
using uFrame.Kernel;
using uFrame.MVVM;
using uFrame.Serialization;
using UnityEngine;


public class DummySceneLoader : DummySceneLoaderBase {
    
    protected override IEnumerator LoadScene(DummyScene scene, Action<float, string> progressDelegate) {
        yield break;
    }
    
    protected override IEnumerator UnloadScene(DummyScene scene, Action<float, string> progressDelegate) {
        yield break;
    }
}
