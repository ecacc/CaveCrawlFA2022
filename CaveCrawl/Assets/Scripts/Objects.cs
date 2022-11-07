using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objects
{
    public enum ObjectType {
        ChumBucket,
        GoldCoin,
        WaterBucket,
        HandSanitizer
    }

    public ObjectType objectType;
    public int amount;
}
