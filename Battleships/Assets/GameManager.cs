using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public GameBoard mBoard;

	// Use this for initialization
	void Start ()
    {
        mBoard.CreateBoard();
	}
}
