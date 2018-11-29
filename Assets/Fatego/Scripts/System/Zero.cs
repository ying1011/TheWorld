using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zero {
    public int time;
    public int ID;

    public Zero() {
        //当前时间
        time = 0;
    }
    
    public virtual Zero Create() {
        return null;
    }

    public virtual bool Destroy() {
        return false;
    }

    public virtual void Run(){

    }

    public virtual void Save() {

    }
}
