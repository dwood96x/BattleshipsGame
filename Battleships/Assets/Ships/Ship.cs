﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Ship : EventTrigger
{
    [HideInInspector]
    public Color mColor = Color.clear;

    public Player mPlayer = null;

    protected Coord mOriginalCoord = null;
    protected Coord mCurrentCoord = null;
    protected Coord mNextCoord = null;

    protected RectTransform mRectTransform = null;
    protected ShipManager mShipManager;

    protected Vector3Int mMovement = Vector3Int.one;
    protected List<Coord> mHighlightedCoords = new List<Coord>();

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
    //Highlights possible coords a ship can be put in
    private void ShowPossMoves()
    {
        //Where to go
        int currentX = mCurrentCoord.mBoardPosition.x;
        int currentY = mCurrentCoord.mBoardPosition.y;

        // Check each coord
        for (int i = 0; i < 10 ; i++)
        {
            for (int y = 0; y < 10; y++)
            {
                //Add possible locations to list
                if(mCurrentCoord.mBoard.mPOneCoords[i,y].mCurrentShip == null)
                {
                    mHighlightedCoords.Add(mCurrentCoord.mBoard.mPOneCoords[i, y]);
                }
            }
        }
    }
    protected void ShowCoords()
    {
        foreach(Coord coord in mHighlightedCoords)
        {
            coord.mOutlineImage.color = Color.green;
        }
    }
    protected void ClearCoords()
    {
        foreach (Coord coord in mHighlightedCoords)
        {
            coord.mOutlineImage.color = Color.grey;
        }
        mHighlightedCoords.Clear();
    }
    protected void Move()
    {
        mCurrentCoord.mCurrentShip = null;

        mCurrentCoord = mNextCoord;
        mCurrentCoord.mCurrentShip = this;

        transform.position = mCurrentCoord.transform.position;
        mNextCoord = null;
    }
    public void Hit()
    {
        mColor = Color.red;
    }
    public void Remove()
    {
        // Removes the ship from the coord
        mCurrentCoord.mCurrentShip = null;
        //Removes the ship from the game
        gameObject.SetActive(false);
    }
    public void Reset()
    {
        Remove();

        Place(mOriginalCoord);
    }
    public override void OnBeginDrag(PointerEventData eventData)
    {
        base.OnBeginDrag(eventData);

        ShowPossMoves();
        ShowCoords();
    }
    public override void OnDrag(PointerEventData eventData)
    {
        base.OnDrag(eventData);
        //Makes the ship move with the cursor
        transform.position += (Vector3)eventData.delta;

        foreach (Coord coord in mHighlightedCoords)
        {
            if (RectTransformUtility.RectangleContainsScreenPoint(coord.mRectTransform, Input.mousePosition))
            {
                mNextCoord = coord;
                break;
            }

            mNextCoord = null;
        }
    }
    public override void OnEndDrag(PointerEventData eventData)
    {
        base.OnEndDrag(eventData);

        ClearCoords();

        if (!mNextCoord)
        {
            transform.position = mCurrentCoord.gameObject.transform.position;
            return;
        }

        Move();
    }
}
