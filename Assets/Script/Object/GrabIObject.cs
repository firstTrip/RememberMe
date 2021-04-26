﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabIObject : MonoBehaviour
{
    protected GameObject player;
    protected GameObject objectPoint;

    public void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        objectPoint = GameObject.FindGameObjectWithTag("ObjectPoint");
    }



    public void Action()
    {
        //SetEquip(this.gameObject, this.gameObject);
        transform.SetParent(objectPoint.transform);
        gameObject.transform.localPosition = Vector3.zero;
        gameObject.transform.localRotation = new Quaternion(0, 0, 0, 0);
    }

    public void DisAction()
    {
        //SetEquip(this.gameObject, false);
        objectPoint.transform.DetachChildren();
    }

   
}