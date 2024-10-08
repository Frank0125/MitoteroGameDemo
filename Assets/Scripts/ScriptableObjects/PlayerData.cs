using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu]
public class PlayerData : ScriptableObject
{
    private int[] _playerScores = new int[4];
    private int _playerCount;

    [System.NonSerialized]
    public UnityEvent<int> onPointsChanged = new UnityEvent<int>();
    public UnityEvent<int> onPlayerCountChanged = new UnityEvent<int>();

    private void OnEnable()
    {
        _playerCount = 0;
        for (int i = 0; i < _playerScores.Length; i++)
        {
            _playerScores[i] = 0;
        }

        if (onPointsChanged != null)
        {
            onPointsChanged = new UnityEvent<int>();
        }
    }

    public void AddPoints(int player, int points)
    {
        _playerScores[player] += points;
        onPointsChanged.Invoke(_playerScores[player]);
    }

    public void SetPlayerCount(int count)
    {
        _playerCount = count;
        onPlayerCountChanged.Invoke(_playerCount);
    }

    public int GetPlayerCount()
    {
        return _playerCount;
    }
    public int GetPlayerPoints(int player)
    {
        return _playerScores[player];
    }
}
