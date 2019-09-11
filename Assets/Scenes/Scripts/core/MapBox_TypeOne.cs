using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public class MapBox_TypeOne : Box
{
    private GameObject attach_prop_obj;
    private Prop attach_prop;
    internal override void Swipe_In()
    {
        if (attach_prop_obj == null)
        {
            attach_prop_obj = Instantiate<GameObject>(TouchPlay.Instance.Prop.gameObject);
            attach_prop = attach_prop_obj.GetComponent<Prop>();
        }

        attach_prop_obj.SetActive(true);

        attach_prop_obj.transform.SetParent(this.transform, false);
        attach_prop_obj.transform.localPosition = new Vector3(0, 1, 0);

        attach_prop.PropShow();

    }

    internal override void Swipe_Out()
    {
        attach_prop?.PropHidden();
        attach_prop_obj?.SetActive(false);
    }

}
