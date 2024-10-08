using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StartManager : MonoBehaviour
{
    [Header("-------Player Select Canvas-------")]
    [SerializeField] private GameObject _playerSelectGO;

    [Header("-------First Button Select-------")]
    [SerializeField] private GameObject _playerSelectFirstButton;

    [Header("-------Player Data-------")]
    [SerializeField] private PlayerData _playerData;

    public void OpenPlayerSelect()
    {
        _playerSelectGO.SetActive(true);
        MoveCanvas();
        EventSystem.current.SetSelectedGameObject(_playerSelectFirstButton);

    }

    private void MoveCanvas()
    {
        _playerSelectGO.transform.position = new Vector3(9.0145f, 4.8833f, 0.0f);
    }

    public void StartGame(int numberOfPlayers)
    {
        //Create a queue of minigames based on index, we have 5 minigames
        int[] minigames = new int[5];
        for (int i = 1; i < 6; i++)
        {
            minigames[i - 1] = i;
        }

        _playerData.SetPlayerCount(numberOfPlayers);

    }
}
