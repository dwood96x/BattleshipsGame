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

    // TODO: See if removing the dictionary and making ship order simply types of ships is better/superior
    // Creates the order the ships will be created in
    private string[] mShipOrder = new string[6]
    {
        "P","P", "D", "D", "C", "B"
    };
    // Dictionary of what each
    private Dictionary<string, Type> mShipLibrary = new Dictionary<string, Type>
    {
        {"P", typeof(Patrol_Boat) },
        {"D", typeof(Destroyer) },
        {"C", typeof(Carrier) },
        {"B", typeof(Battleship) }
    };

    // The initial setup the game does. Doesn't create the other players ships until the a game begins
    public void InitialSetup(GameBoard board, Player player)
    {
        //Create the player ones pieces
        mPlayerOneShips = CreateShips(Color.white, new Color32(0, 0, 0, 255), board, player);

        //Place ships
        PlaceShips(mPlayerOneShips, board);
    }
    public void SetupEnemy(GameBoard board, Player player)
    {
        //TODO : Randomsize the enemy ships locations
        //Create the player twos pieces
        mPlayerTwoShips = CreateShips(Color.blue, new Color32(0, 0, 0, 0), board, player);

        //Place ships
        PlaceShipsRandom(mPlayerTwoShips, board);
    }
    private List<Ship> CreateShips(Color color, Color32 spriteColor, GameBoard board, Player player)
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
            newShip.Setup(color, spriteColor, this, player);
        }
        return newShips;
    }

    private void PlaceShips(List<Ship> ships, GameBoard board)
    {
        for (int i = 0; i < 6; i++)
        {
            ships[i].Place(board.mPOneCoords[i,i+1]);
        }
    }
    private void PlaceShipsRandom(List<Ship> ships, GameBoard board)
    {
        System.Random random = new System.Random();

        for (int i = 0; i < 6;)
        {
            int randx = random.Next(1, 10);
            int randy = random.Next(1, 10);
            if (board.mPTwoCoords[randx, randy].mCurrentShip == null)
            {
                ships[i].Place(board.mPTwoCoords[randx, randy]);
                i++;
            }
        }
    }
}
