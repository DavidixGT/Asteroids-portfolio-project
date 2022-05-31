using System;
using UnityEngine;

public abstract class GameBehaviourCreator<T> : ScriptableObject where T : GameBehaviour
{
    [SerializeField]
    protected T _gameBehaviourPrefab;
    public Action<GameBehaviour> GameBehaviourCreated;
    protected virtual T CreateInstance()
    {
        T gameBehaviour = Instantiate(_gameBehaviourPrefab);
        GameBehaviourCreated?.Invoke(gameBehaviour);
        return gameBehaviour;
    }
}
