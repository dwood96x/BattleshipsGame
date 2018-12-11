using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public void StartGame(GameManager manager)
    {
        manager.PlayerOne.Setup = false;
        manager.PlayerOne.MyTurn = true;
    }
    public void EndGame(GameManager manager)
    {
        manager.PlayerOne.MyTurn = false;
        manager.PlayerOne.Setup = true;
    }
    public void POneTurnStart(GameManager manager)
    {
        manager.PlayerOne.MyTurn = true;
        manager.PlayerTwo.MyTurn = false;
    }
    public void PTwoTurnStart(GameManager manager)
    {
        manager.PlayerTwo.MyTurn = true;
        manager.PlayerOne.MyTurn = false;
    }
}
