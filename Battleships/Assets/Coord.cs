using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Coord : EventTrigger
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

    public void Setup(Vector2Int newBoardPos, GameBoard newBoard)
    {
        mBoardPosition = newBoardPos;
        mBoard = newBoard;

        mRectTransform = GetComponent<RectTransform>();
    }
    public void Fire()
    {
        if (mCurrentShip != null)
        {
            mCurrentShip.Hit();
        }
        else
        {
            Miss();
        }
    }
    public void Miss()
    {
        Image.defaultGraphicMaterial.color = Color.cyan;
    }
    public override void OnPointerClick(PointerEventData eventData)
    {
        base.OnPointerClick(eventData);

        if (mCurrentShip.mPlayer.PlayerNum != 1 && mCurrentShip != null)
        {
            if(mCurrentShip.mPlayer.MyTurn == )
            mCurrentShip.Hit();
        }
    }
}
