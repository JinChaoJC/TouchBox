using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public abstract class Prop : IPropExecute
{
    public Prop() { }

    //internal abstract  void PropShow();
    //internal abstract void PropHidden();
    public abstract void PropExecute(Box attach_box);
    public abstract void Clear();


    internal GameObject attach_prop_clone;
}

public enum PropType
{
    PoTao,
    Watermeion,
    Remove,
    Inversion,
    none
}

