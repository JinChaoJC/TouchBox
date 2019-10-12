using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Prop_Inversion : Prop
{
    public override void Clear()
    {
        //throw new NotImplementedException();
    }

    public override void PropExecute(Box attach_box)
    {
        if (attach_box.IsSelected==true&&attach_box.Last_attach_prop!=null)
        {
            attach_box.IsSelected = false;
            attach_box.Last_attach_prop.Clear();
        }
        else
        {
            attach_box.Last_attach_prop = new Prop_PoTao();
            attach_box.Last_attach_prop.PropExecute(attach_box);
            attach_box.IsSelected = true;
        }
    }
}

