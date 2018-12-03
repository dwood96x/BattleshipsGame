using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Ship : EventTrigger
{
    [HideInInspector]
    public Color mColor = Color.clear;

    protected Coord mOriginalCoord = null;
    protected Coord mCurrentCoord = null;

    protected RectTransform mRectTransform = null;
    protected ShipManager mShipManager;

    public virtual void Setup(Color color, Color32 newSpriteColor, ShipManager newShipManager)
    {
        mShipManager = newShipManager;

        mColor = color;
        GetComponent<Image>().color = newSpriteColor;
        mRectTransform = GetComponent<RectTransform>();
    }

    public void Place(Coord newCoord)
    {
        mCurrentCoord = newCoord;
        mOriginalCoord = newCoord;
        mCurrentCoord.mCurrentShip = this;

        transform.position = newCoord.transform.position;
        gameObject.SetActive(true);

    }
}
