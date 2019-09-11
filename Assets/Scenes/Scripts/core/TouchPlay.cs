using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HedgehogTeam.EasyTouch;
using System;

public class TouchPlay : MonoBehaviour
{

    public BoxCollider BoxCollider;
    public Transform MapBoxRoot;

    public Transform min, max;

    public static TouchPlay Instance;

    public Prop Prop;

    private void Awake()
    {

        Instance = this;

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

    MapBox_TypeOne box_start, box_end;

    private void On_DragStart(Gesture gesture)
    {
        var currrent_obj = gesture.GetCurrentPickedObject();
        if (currrent_obj != null)
        {
            box_start = currrent_obj?.GetComponent<MapBox_TypeOne>();
            print("On_DragStart : pick obj is " + currrent_obj + " | Pos : " + box_start.Pos);
        }

    }

    private void On_Drag(Gesture gesture)
    {
        var currrent_obj = gesture.GetCurrentPickedObject();
        box_end = currrent_obj?.GetComponent<MapBox_TypeOne>();
        CreatArea(box_start, box_end);
        CaliculateBoxsInArea();
    }

    private void On_DragEnd(Gesture gesture)
    {
        var currrent_obj = gesture.GetCurrentPickedObject();
        if (currrent_obj != null)
        {
            box_end = currrent_obj?.GetComponent<MapBox_TypeOne>();
            CreatArea(box_start, box_end);
            CaliculateBoxsInArea();
            print("On_DragEnd : pick obj is " + currrent_obj + " | Pos : " + box_end.Pos);
        }
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

    #region Collider

    public void SetAreaColliderBoundsSize(MapBox_TypeOne start_box, MapBox_TypeOne end_box)
    {
        var bounds = BoxCollider.bounds;
        bounds.SetMinMax(start_box.Pos, end_box.Pos);

        BoxCollider.transform.position = bounds.center;
        BoxCollider.transform.localScale = bounds.size;

        bounds.center = Vector3.zero;
        bounds.size = Vector3.one;
    }

    #endregion




    private void CreatArea(MapBox_TypeOne start_box, MapBox_TypeOne end_box)
    {
        SetAreaColliderBoundsSize(start_box, end_box);
    }


    private void CaliculateBoxsInArea()
    {
        for (int i = 0; i < MapBoxRoot.childCount; i++)
        {
            Box box = MapBoxRoot.GetChild(i).GetComponent<Box>();

            if (CheckIntersects(box.BoxCollider.bounds))
            {
                box.Swipe_In();
            }
            else
            {
                box.Swipe_Out();
            }
        }
    }



    private bool CheckSingleBoxInCurrentArea(MapBox_TypeOne boxPos)
    {
        var bounds = BoxCollider.bounds;
        return bounds.Contains(boxPos.Pos);
    }

    private bool CheckIntersects(Bounds bounds)
    {
        var _bounds = BoxCollider.bounds;
        return _bounds.Intersects(bounds);

    }

}



