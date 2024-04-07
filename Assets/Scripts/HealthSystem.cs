using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthSystem : MonoBehaviour
{
    public static Action<int> modifyHealth;
    public static Action<int> updateHealth;
    public int Health = 10;
    public UnityEvent OnPlayerDeath;
    public UI_Manager uiCurrent;
    private void Start()
    {
        modifyHealth = (a) => { UpdateCurrentHealth(a); };
        updateHealth = uiCurrent.UpdateLife;
        updateHealth(Health);
    }
    private void UpdateCurrentHealth(int test)
    {
        Health = Math.Clamp(Health + test, 0, 10);
        updateHealth(Health);
        if (Health == 0)
        {
            OnPlayerDeath.Invoke();
        }
    }
}
