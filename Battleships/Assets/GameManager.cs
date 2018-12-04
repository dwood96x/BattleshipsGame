using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public GameBoard mBoard;
    public ShipManager mShipManager;
    private Resolution GetResolution;

    // Use this for initialization
    void Start ()
    {
        GetResolution = Screen.currentResolution;
        //mBoard.CreateBoardOne(mBoard.GetHeightMod(GetResolution));       
        //mBoard.CreateBoardTwo(mBoard.GetHeightMod(GetResolution));
        mBoard.CreateBoardOneNormal();
        mBoard.CreateBoardTwoNormal();
        mShipManager.Setup(mBoard);
	}
}
