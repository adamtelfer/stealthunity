using System;
using UnityEngine;
using System.Collections.Generic;

class Helper
{
    public static Vector3 MousePositionToWorldPosition ( Vector2 mousePosition )
    {
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, 0f));
        return new Vector3(worldPosition.x, worldPosition.y, 0f);
    }
}
