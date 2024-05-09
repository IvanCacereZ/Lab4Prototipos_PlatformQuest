using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "ScriptableObject", menuName = "ScriptableObjects/GameIntEvent", order = 1)]
public class GameIntEvent : ScriptableObject
{
    private List<GameEventListeners> gameListeners;

    public void Raise(int value)
    {
        foreach (var listener in gameListeners)
        {
            listener.OnRaiseNotified(value);
        }
    }
    public void RegistryListaner(GameEventListeners gameListener)
    {
        gameListeners.Add(gameListener);
    }
    public void UnRegistryListaner(GameEventListeners gameListener)
    {
        if (gameListeners.Contains(gameListener))
        {
            gameListeners.Remove(gameListener);
        }
    }
}
