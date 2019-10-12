using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Prop_Remove : Prop
{
    public override void Clear()
    {
        //throw new NotImplementedException();
    }

    public override void PropExecute(Box attach_box)
    {
        attach_box.Last_attach_prop?.Clear();
    }
}
