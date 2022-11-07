using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory {

    private List<Objects> objectList;

    public Inventory() {
        objectList = new List<Objects>();

        AddObject(new Objects { objectType = Objects.ObjectType.ChumBucket, amount = 1});

        //Debug.Log(objectList.Count);
    }

    public void AddObject(Objects obj) {
        objectList.Add(obj);
    }

}
