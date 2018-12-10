using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    [HideInInspector]
    public bool mPTurn = false;
    [HideInInspector]
    public bool Setup = true;

    public void StartGame()
    {
        Setup = false;
        mPTurn = true;
    }
    public void EndGame()
    {
        mPTurn = false;
        Setup = true;
    }
	// Update is called once per frame
	void Update ()
    {
		
	}
}
