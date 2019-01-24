using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheWorld;

public class CGame : MonoBehaviour {

    CTheWorld GameCore;

    // Use this for initialization
    void Start()
    {
        GameCore = CTheWorld.GetGameCore();
    }

    // Update is called once per frame
    void Update()
    {
        GameCore.Run();
    }
}
