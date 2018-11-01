using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameBoard : MonoBehaviour
{
    public GameObject mCoordPrefab;

    [HideInInspector]
    public Coord[,] mAllCoords = new Coord[10, 10];

    public void CreateBoard()
    {
        for (int x = 0; x < 10; x++)
        {
            for (int y = 0; y < 10; y++)
            {
                // Creates Coord
                GameObject newCoord = Instantiate(mCoordPrefab, transform);

                // Position
                RectTransform rectTransform = newCoord.GetComponent<RectTransform>();
                rectTransform.anchoredPosition = new Vector2((x * 50) + 25, (y * 50) + 25);

                // Setup
                mAllCoords[x, y] = newCoord.GetComponent<Coord>();
                mAllCoords[x, y].Setup(new Vector2Int(x, y), this);
            }
        }
        // Colors the coords
        /*
        for (int x = 0; x < 10; x += 2)
        {
            for (int y = 0; y < 10; y++)
            {
                int offset = (y % 2 != 0) ? 0 : 1;
                int finalX = x + offset;

                mAllCoords[finalX, y].GetComponent<Image>().color = new Color32(090, 210, 097, 255);
            }
        }
        */
    }
}