using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HedgehogTeam.EasyTouch;
using System;

public class TouchPlay : MonoBehaviour
{

    public BoxCollider BoxCollider;
    public Transform MapBoxRoot;

    private void Awake()
    {
        //---

        //EasyTouch.On_TouchStart += On_TouchStart;
        //EasyTouch.On_TouchDown += On_TouchDown;
        //EasyTouch.On_TouchUp += On_TouchUp;

        //---

        EasyTouch.On_DragStart += On_DragStart;
        EasyTouch.On_Drag += On_Drag;
        EasyTouch.On_DragEnd += On_DragEnd;

        //---

        // 发生在无pick object
        //EasyTouch.On_SwipeStart += On_SwipeStart;
        //EasyTouch.On_Swipe += On_Swipe;
        //EasyTouch.On_SwipeEnd += On_SwipeEnd;
    }

    //---
    #region TOUCH
    private void On_TouchStart(Gesture gesture)
    {
        print("On_TouchStart : pick obj is " + gesture.GetCurrentPickedObject());
    }

    private void On_TouchDown(Gesture gesture)
    {
        print("On_TouchDown : pick obj is " + gesture.GetCurrentPickedObject());
    }

    private void On_TouchUp(Gesture gesture)
    {
        print("On_TouchUp : pick obj is " + gesture.GetCurrentPickedObject());
    }
    #endregion
    //---
    #region DRAG

    MapBox box_start, box_end;

    private void On_DragStart(Gesture gesture)
    {
        var currrent_obj = gesture.GetCurrentPickedObject();
        box_start = currrent_obj?.GetComponent<MapBox>();
        print("On_DragStart : pick obj is " + currrent_obj + " | Pos : "+box_start.Pos);
    }

    private void On_Drag(Gesture gesture)
    {
        var currrent_obj = gesture.GetCurrentPickedObject();
        //print("On_Drag : pick obj is " + currrent_obj);
        box_end = currrent_obj?.GetComponent<MapBox>();
        CreatArea(box_start,box_end);
    }

    private void On_DragEnd(Gesture gesture)
    {
        var currrent_obj = gesture.GetCurrentPickedObject();
        box_end = currrent_obj?.GetComponent<MapBox>();
        CreatArea(box_start, box_end);
        print("On_DragEnd : pick obj is " + currrent_obj+" | Pos : "+box_end.Pos);
    }
    #endregion
    //---
    #region SWIPE
    private void On_SwipeStart(Gesture gesture)
    {
        print("On_SwipeStart : pick obj is " + gesture.pickedObject?.name);
    }
    private void On_Swipe(Gesture gesture)
    {
        print("On_Swipe : pick obj is " + gesture.pickedObject?.name);
    }

    private void On_SwipeEnd(Gesture gesture)
    {
        print("On_SwipeEnd : pick obj is " + gesture.pickedObject?.name);
    }
    #endregion
    //---


    private void CreatArea(MapBox start_box,MapBox end_box)
    {
        if (start_box == null || end_box == null) return;
        Vector3 data = end_box.Pos - start_box.Pos;
        data = start_box.Pos + data*0.5f;
        BoxCollider.transform.position = data;

        var scale_matrix = Math.Sqrt(Vector3.Distance(start_box.Pos,end_box.Pos));
        print("data pos : " + scale_matrix);

        CalculateAreaBoxs(start_box,end_box);
        //BoxCollider.transform.localScale = Vector3.one * (float)scale_matrix;
        

    }


    private void CalculateAreaBoxs(MapBox start_box,MapBox end_box)
    {
        float min_x = start_box.Pos.x < end_box.Pos.x ? start_box.Pos.x : end_box.Pos.x;
        float min_y = start_box.Pos.y > end_box.Pos.y ? end_box.Pos.y : start_box.Pos.y;
        float max_x= start_box.Pos.x < end_box.Pos.x ? end_box.Pos.x : start_box.Pos.x;
        float max_y=start_box.Pos.y > end_box.Pos.y ? start_box.Pos.y : end_box.Pos.y;
        
        for (int i = 0; i < MapBoxRoot.childCount; i++)
        {
            MapBox mapBox = MapBoxRoot.GetChild(i).GetComponent<MapBox>();
            if (!(mapBox.Pos.x<min_x||mapBox.Pos.x>max_x||mapBox.Pos.y<min_y||mapBox.Pos.y>max_y))
            {
                Debug.LogFormat("InArea : {0}", mapBox.name);
            }
        }
    }


    private bool CheckSingleBoxInCurrentArea(MapBox boxPos)
    {
        var bounds = BoxCollider.bounds;
        return bounds.Contains(boxPos.Pos);
    }

}



