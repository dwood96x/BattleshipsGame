using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public GameBoard mBoard;
    public ShipManager mShipManager;
    private Resolution GetResolution;

    void Start ()
    {
        // The following commented out methods were for when my game didn't properly resize for different sceen sizes, will delete when I know I dont need it
        //GetResolution = Screen.currentResolution;
        //mBoard.CreateBoardOne(mBoard.GetHeightMod(GetResolution));       
        //mBoard.CreateBoardTwo(mBoard.GetHeightMod(GetResolution));
        mBoard.CreateBoardOne();
        mBoard.CreateBoardTwo();
        mShipManager.Setup(mBoard);
	}
}
