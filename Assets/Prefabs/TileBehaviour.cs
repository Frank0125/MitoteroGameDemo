using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileBehaviour : MonoBehaviour
{
    private int _playersOnTile = 0;
    // 1 , 2
    // 3 , 4
    public int _tileIndex;
    public GameObject[] _playerTiles;
    public GameObject _tile;

    private string[] _tags = { "FirstPlayerTile", "SecPlayerTile", "ThirdPlayerTile", "FourthPlayerTile" };

    public void PaintPlayerOnTile(int playerIndex)
    {
        Debug.Log("Painting player on tile");
        BlankAllTiles(playerIndex);
        _playersOnTile++;
        _playerTiles[playerIndex].SetActive(true);
    }

    private void BlankAllTiles(int playerIndex)
    {
    
        Debug.Log("Blanking all tiles");
    }
}
