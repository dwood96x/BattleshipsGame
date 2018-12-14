using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public GameManager gamemanager;
    public static int PlayersTurn;

    public void StartGame(GameManager manager)
    {
        if (manager.PlayerOne.Setup == true)
        {
            manager.PlayerOne.Setup = false;
            PlayersTurn = 1;
        }
    }
    public void EndGame(GameManager manager)
    {
        manager.PlayerOne.MyTurn = false;
        manager.PlayerOne.Setup = true;
    }
    public void POneTurnStart(GameManager manager)
    {
        PlayersTurn = 1;
    }
    public void PTwoTurnStart(GameManager manager)
    {
        PlayersTurn = 2;
    }
    public void OnMissed(object source, EventArgs e)
    {
        if(PlayersTurn != 1)
        {
            POneTurnStart(gamemanager);
        }
        else
        {
            PTwoTurnStart(gamemanager);
        }
    }

}
