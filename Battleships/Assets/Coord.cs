using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;

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
    public delegate void Missed();
    public static event Missed MissedEvent;

    public void Setup(Vector2Int newBoardPos, GameBoard newBoard)
    {
        mBoardPosition = newBoardPos;
        mBoard = newBoard;

        mRectTransform = GetComponent<RectTransform>();
    }
    public void Fire()
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
    public void Miss()
    {
        GetComponent<Image>().color = Color.cyan;
        //MissedEvent();
    }
    public override void OnPointerClick(PointerEventData eventData)
    {
        base.OnPointerClick(eventData);

        Fire();
    }
}
