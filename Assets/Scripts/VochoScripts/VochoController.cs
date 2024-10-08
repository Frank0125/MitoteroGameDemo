using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class VochoController : MonoBehaviour
{
    [Header ("-------Player Prefab-------")]
    [SerializeField] private GameObject _playerPrefab;

    [Header ("-------Player Data-------")]
    [SerializeField] private PlayerData _playerData;

    [Header("-------Game First Selected tile-------")]
    [SerializeField] private GameObject _gameFirstSelectedTile;

    private int count;

    public void Start()
    {
        Debug.Log("Players:" + _playerData.GetPlayerCount());
        EventSystem.current.SetSelectedGameObject(_gameFirstSelectedTile);

    }
}
