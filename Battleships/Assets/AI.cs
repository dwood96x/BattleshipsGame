using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    private Coord[,] AITargetCoords;
    public void Searching()
    {

    }
    public void Finishing()
    {

    }
    public void Random()
    {
        do
        {
            System.Random rand = new System.Random();
            int xtarget = rand.Next(0, 9);
            int ytarget = rand.Next(0, 9);
            AITargetCoords[xtarget, ytarget].AIFire();
        } while (TurnManager.PlayersTurn == 2);
    }
    public void SetAITargetCoords(Coord[,] coords)
    {
        AITargetCoords = coords;
    }

    // TODO : Add AI deciding what to search for
    public void AIStart()
    {
        Random();
    }
    private void Update()
    {
        if(TurnManager.PlayersTurn == 2)
        {
            AIStart();
        }
    }

}
