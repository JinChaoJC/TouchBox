using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using DG.Tweening;

public abstract class Box : MonoBehaviour
{

    public Vector3 Pos { get { return transform.position; } }
    public BoxCollider BoxCollider
    {
        get
        {
            if (mBoxCollider==null)
            {
                mBoxCollider = this.GetComponent<BoxCollider>();
            }
            return mBoxCollider;
        } }

    private BoxCollider mBoxCollider;

    internal Prop Last_attach_prop;
    internal Prop Current_attach_prop;
    internal bool IsAreSelected;
    internal bool IsSelected;
    internal GameObject Root_MeshShow;
    internal GameObject Root_AttachProp;

    private void Awake()
    {
        InitData();
    }

    private void Start()
    {
        CreatShowMesh_OnLoad();
    }

    internal virtual void InitData()
    {
        Root_MeshShow = this.transform.Find("MeshShowRoot").gameObject;
        Root_AttachProp = this.transform.Find("Root_AttachProp").gameObject;
    }

    internal virtual void CreatShowMesh_OnLoad() { }

    internal virtual void Swipe_In() {
        //this.transform.DOShakeScale(0.2f);
    }
    internal virtual void Swipe_Out() { }
    internal virtual void CheckOut() { }

}
