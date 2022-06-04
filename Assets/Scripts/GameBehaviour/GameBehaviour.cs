using System;
using UnityEngine;

public abstract class GameBehaviour : MonoBehaviour, IPauseHandler
{
    protected bool IsPaused => _isPaused;
    private bool _isPaused = false;
    public virtual void GameUpdate() { }
    public virtual void GameFixedUpdate() { }
    public void SetPause(bool pause) => _isPaused = pause;
}