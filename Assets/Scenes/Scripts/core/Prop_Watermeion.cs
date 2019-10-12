using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Prop_Watermeion : Prop
{
    public override void PropExecute(Box attach_box)
    {
        //if (attach_prop_clone != null) return;
        attach_prop_clone = GameObject.Instantiate<GameObject>(
           Resources.Load<GameObject>("Prefabs/Prop/Watermeion"));


        attach_prop_clone.transform.SetParent(attach_box.Root_AttachProp.transform, false);
        attach_prop_clone.transform.localScale = Vector3.one * 0.9f;
        attach_prop_clone.transform.localPosition = new Vector3(0, 0.1f, 0);
    }
    
    public override void Clear()
    {
        GameObject.Destroy(attach_prop_clone);
    }
}
