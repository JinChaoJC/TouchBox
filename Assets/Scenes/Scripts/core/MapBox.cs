using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using DG.Tweening;


public class MapBox : Box
{
    private GameObject show_box_mesh { get; set; }
    private GameObject attach_prop_clone;

    private PropType mPropType { get; set; }

    internal override void InitData()
    {
        base.InitData();
    }

    internal override void CreatShowMesh_OnLoad()
    {
        show_box_mesh = GameObject.Instantiate<GameObject>(
           Resources.Load<GameObject>("Prefabs/Prop/BoxMeshShow"));
        show_box_mesh.transform.SetParent(Root_MeshShow.transform, false);
        show_box_mesh.transform.localPosition = Vector3.zero;
    }

    internal override void Swipe_In()
    {
        base.Swipe_In();

        show_box_mesh.transform.localScale = Vector3.one;



        mPropType = TouchPlay.Instance.GetCurrentProp();
        Debug.Log("PropType : " + mPropType.ToString());
        switch (mPropType)
        {
            case PropType.PoTao:
                Current_attach_prop = new Prop_PoTao();
                break;
            case PropType.Watermeion:
                Current_attach_prop = new Prop_Watermeion();
                break;
            case PropType.Remove:
                Current_attach_prop = new Prop_Remove();
                break;
            case PropType.Inversion:
                Current_attach_prop = new Prop_Inversion();
                break;
            default:
                break;
        }


    }

    internal override void Swipe_Out()
    {
        base.Swipe_Out();
        show_box_mesh.transform.localScale = Vector3.one * 0.8f;
    }

    internal override void CheckOut()
    {
        base.CheckOut();
        Swipe_Out();

        if (IsSelected == true && Last_attach_prop != null)
        {
            Last_attach_prop.Clear();
        }

        Last_attach_prop = Current_attach_prop;
        switch (mPropType)
        {
            case PropType.PoTao:
            case PropType.Watermeion:
            case PropType.Remove:
                IsSelected = true;
                break;
            case PropType.Inversion:
                break;
            case PropType.none:
                break;
            default:
                break;
        }
        Last_attach_prop?.PropExecute(this);
    }

}
