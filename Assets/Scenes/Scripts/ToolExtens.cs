using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ToolExtens : MonoBehaviour
{
    [MenuItem("GameObject/Box/CreatMeshRoot",false,10)]
    public static void CreatBoxShowRoot(MenuCommand menuCommand)
    {
        GameObject select_obj = menuCommand.context as GameObject;

        if (select_obj.transform.Find("MeshShowRoot")==null)
        {
            GameObject mesh_root = new GameObject("MeshShowRoot");
            GameObjectUtility.SetParentAndAlign(mesh_root, select_obj);
            Undo.RegisterCreatedObjectUndo(mesh_root, "Creat_" + mesh_root.GetInstanceID());
        }
      
          if (select_obj.transform.Find("Root_AttachProp") == null)
        {
            GameObject prop_root = new GameObject("Root_AttachProp");
            GameObjectUtility.SetParentAndAlign(prop_root, menuCommand.context as GameObject);
            Undo.RegisterCreatedObjectUndo(prop_root, "Creat_" + prop_root.GetInstanceID());
        }
        

        //Selection.activeObject = mesh_root;
    }
    
}
