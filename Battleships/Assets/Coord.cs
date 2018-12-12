using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class Coord : EventTrigger, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
{
    public Image mOutlineImage;

    [HideInInspector]
    public Vector2Int mBoardPosition = Vector2Int.zero;
    [HideInInspector]
    public GameBoard mBoard = null;
    [HideInInspector]
    public RectTransform mRectTransform = null;
    [HideInInspector]
    public Ship mCurrentShip = null;
    [HideInInspector]
    public int PlayerNumBoard;

    // Created a delegate and event that will raise when a shot is missed. Purpose is to signal when to switch turns and keep the 
    // game more decoupled
    [HideInInspector]
    public delegate void MissHandler(object source, EventArgs args);
    public event MissHandler MissedEvent;

    public void Setup(Vector2Int newBoardPos, GameBoard newBoard)
    {
        mBoardPosition = newBoardPos;
        mBoard = newBoard;

        mRectTransform = GetComponent<RectTransform>();
    }
    public void Fire()
    {
        //Checks if the enemy board is fired on by checking position
        if (PlayerNumBoard == 2 && TurnManager.PlayersTurn == 1)
        {
            if (mCurrentShip == null)
            {
                Miss();
            }
            else
            {
                if (mCurrentShip.mPlayer.PlayerNum != 1 && mCurrentShip.mPlayer.MyTurn == true)
                {
                    mCurrentShip.Hit();
                }
            }
        }
    }
    public void Miss()
    {
        GetComponent<Image>().color = Color.cyan;

        OnMissed();
    }
    protected virtual void OnMissed()
    {
        if (MissedEvent != null)
        {
            MissedEvent(this, EventArgs.Empty);
        }
    }
    public override void OnPointerClick(PointerEventData eventData)
    {
        base.OnPointerClick(eventData);

        Fire();
    }
}
