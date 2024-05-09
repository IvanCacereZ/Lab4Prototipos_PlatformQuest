using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEventListeners : MonoBehaviour
{
    public GameIntEvent gameIntEvent;
    public UnityEvent<int> responde;
    private void OnEnable()
    {
        gameIntEvent.RegistryListaner(this);
    }
    private void OnDisable()
    {
        gameIntEvent.UnRegistryListaner(this);
    }
    public void OnRaiseNotified(int value)
    {
        responde?.Invoke(value);
    }

}
