using System;
using Unit;
using System.Collections.Generic;
using UnityEngine;
using TheWorld;


class Dog : CPlayer {
    public int fl = 0;

    public override void Run()
    {
        base.Run();
        fl++;
       
        
    }

    public override Zero Create()
    {
        if (fl > 999)
        {
            Zero d = new Dog();
            return d;
        }
        return null;
    }


}
