﻿using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public GameBoard mBoard;
    public ShipManager mShipManager;
    private Resolution GetResolution;
    public TurnManager mTurnManager;
    public Player PlayerOne;
    public Player PlayerTwo;
    public AI AILogic;

    void Start ()
    {
        // The following commented out methods were for when my game didn't properly resize for different sceen sizes, will delete when I know I dont need it
        //GetResolution = Screen.currentResolution;
        //mBoard.CreateBoardOne(mBoard.GetHeightMod(GetResolution));       
        //mBoard.CreateBoardTwo(mBoard.GetHeightMod(GetResolution));
        mBoard.CreateBoardOne(mTurnManager);
        mBoard.CreateBoardTwo(mTurnManager);
        PlayerOne = new Player("dwood", 1, 1);
        PlayerTwo = new Player("AI", 9000, 2);
        mShipManager.InitialSetup(mBoard,PlayerOne, mTurnManager);
        AILogic.SetAITargetCoords(mBoard.mPOneCoords);
    }
    //Had to create this method here due to limitations of unity unable to have a function that takes two parameters (which the method does)
    public void CreateEnemy()
    {
        if (PlayerOne.Setup == true)
        {
            mShipManager.SetupEnemy(mBoard, PlayerTwo, mTurnManager);
        }
    }
}
