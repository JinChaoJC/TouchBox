using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

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



    internal virtual void Swipe_In() { }
    internal virtual void Swipe_Out() { }

}
