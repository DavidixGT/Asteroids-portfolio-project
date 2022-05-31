using UnityEngine;
using Asteroids;

[CreateAssetMenu(fileName = "Player creator", menuName = "Creators/Player creator", order = 1)]
public class PlayerCreator : GameBehaviourCreator<Player>, IPlayerCreator
{
    [SerializeField]
    private PlayerData _playerData;
    public Player CreatePlayer()
    {
        Player playerInstance = base.CreateInstance();
        playerInstance.Initialize(_playerData);
        return playerInstance;
    }
}