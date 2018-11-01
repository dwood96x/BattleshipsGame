using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameBoard : MonoBehaviour
{
    public GameObject mCoordPrefab;
    //private Resolution GetResolution = Screen.currentResolution;

    [HideInInspector]
    public Coord[,] mPOneCoords = new Coord[10, 10];
    public Coord[,] mPTwoCoords = new Coord[10, 10];

    // Creates top board
    public void CreateBoardOne(int Heightmod)
    {
        for (int x = 0; x < 10; x++)
        {
            for (int y = 0; y < 10; y++)
            {
                // Creates Coord
                GameObject newCoord = Instantiate(mCoordPrefab, transform);

                // Position
                RectTransform rectTransform = newCoord.GetComponent<RectTransform>();
                rectTransform.anchoredPosition = new Vector2((x * 50 * Heightmod) + (25 * Heightmod), (y * 50 * Heightmod) + (25 * Heightmod));

                // Setup
                mPOneCoords[x, y] = newCoord.GetComponent<Coord>();
                mPOneCoords[x, y].Setup(new Vector2Int(x, y), this);
            }
        }
    }
    // Creates top board for the enemy
    public void CreateBoardTwo(int Heigthmod)
    {
        for (int x = 0; x < 10; x++)
        {
            for (int y = 0; y < 10; y++)
            {
                // Creates Coord
                GameObject newCoord = Instantiate(mCoordPrefab, transform);

                // Position
                RectTransform rectTransform = newCoord.GetComponent<RectTransform>();
                rectTransform.anchoredPosition = new Vector2((x * 50 * Heigthmod) + (25 * Heigthmod), (y * 50 * Heigthmod) + (550 * Heigthmod));

                // Setup
                mPTwoCoords[x, y] = newCoord.GetComponent<Coord>();
                mPTwoCoords[x, y].Setup(new Vector2Int(x, y), this);
            }
        }
    }
    // Checks the height modifier for scaling board purposes. Assumes height of 1080 in canvas scaler
    public int GetHeightMod(Resolution GetResolution)
    {
        int mod = (GetResolution.height / 1080 );
        return mod;
    }
}