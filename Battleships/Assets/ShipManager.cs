using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class ShipManager : MonoBehaviour
{
    public GameObject mShipPrefab;

    private List<Ship> mPlayerOneShips = null;
    private List<Ship> mPlayerTwoShips = null;

    private string[] mShipOrder = new string[6]
    {
        "P", "P", "D", "D", "C", "B"
    };

    private Dictionary<string, Type> mShipLibrary = new Dictionary<string, Type>
    {
        {"P", typeof(Patrol_Boat) },
        {"D", typeof(Destroyer) },
        {"C", typeof(Carrier) },
        {"B", typeof(Battleship) }
    };

    public void Setup(GameBoard board)
    {
        //Create the player ones pieces
        mPlayerOneShips = CreateShips(Color.white, new Color32(80, 124, 159, 255), board);

        //Place ships
        PlaceShips(1, 0, mPlayerOneShips, board);

    }
    private List<Ship> CreateShips(Color color, Color32 spriteColor, GameBoard board)
    {
        List<Ship> newShips = new List<Ship>();

        for (int i = 0; i < mShipOrder.Length; i++)
        {
            //Create a new object
            GameObject newShipObject = Instantiate(mShipPrefab);
            newShipObject.transform.SetParent(transform);

            //Set scale and position
            newShipObject.transform.localScale = new Vector3(1, 1, 1);
            newShipObject.transform.localRotation = Quaternion.identity;

            //Get the type, apply to new object
            string key = mShipOrder[i];
            Type shipType = mShipLibrary[key];

            //Store new piece
            Ship newShip = (Ship)newShipObject.AddComponent(shipType);
            newShips.Add(newShip);

            //Setup piece
            newShip.Setup(color, spriteColor, this);
        }
        return newShips;
    }

    private void PlaceShips(List<Ship> ships, GameBoard board)
    {
        for (int i = 0; i < 10; i++)
        {
            ships[i].Place(board.mAllCoords[i])
        }
    }
}
