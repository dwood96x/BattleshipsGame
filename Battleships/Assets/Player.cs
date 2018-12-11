using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private string Username;
    private int PlayerID;
    public int PlayerNum;
    [HideInInspector]
    private bool HasShips;
    [HideInInspector]
    public bool MyTurn;
    [HideInInspector]
    public bool Setup = true;

    public Player(string newUsername, int newPlayerID, int newPlayerNum)
    {
        Username = newUsername;
        PlayerID = newPlayerID;
        PlayerNum = newPlayerNum;
    }
    // TODO : Create a way to insantiate the players
    // TODO : Make the game get information from the website on user details
    public void CreatePlayer()
    {

    }
    public void Ready()
    {
        Setup = false;
        MyTurn = true;
    }
    public void StartTurn()
    {
        MyTurn = true;
    }
    public void EndTurn()
    {
        MyTurn = false;
    }
}
