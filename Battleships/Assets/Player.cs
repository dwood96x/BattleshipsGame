using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private string Username;
    private int PlayerID;
    [HideInInspector]
    public int PlayerNum;
    //Player num might be unessissary as both players will be instantiated as objects
    private bool HasShips;
    [HideInInspector]
    public bool MyTurn;
    [HideInInspector]
    public bool Setup = true;
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
        throw new System.NotImplementedException();
    }
    public void EndTurn()
    {
        MyTurn = false;
    }
}
