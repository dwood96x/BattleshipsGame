using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private string Username;
    private int PlayerID;
    public int PlayerNum;
    //Player num might be unessissary as both players will be instantiated as objects
    private bool HasShips;
    public bool MyTurn;
    // TODO : Create a way to insantiate the players
    // TODO : Make the game get information from the website on user details
    public void CreatePlayer()
    {
        //
    }
    public void Ready()
    {
        throw new System.NotImplementedException();
    }
    public void StartTurn()
    {
        throw new System.NotImplementedException();
    }
    public void EndTurn()
    {
        throw new System.NotImplementedException();
    }
}
