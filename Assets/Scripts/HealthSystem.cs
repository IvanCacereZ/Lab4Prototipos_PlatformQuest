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
    public UI_Manager uiCurrent;
    [SerializeField] private GameIntEvent EventUpdateLife;
    [SerializeField] private GameIntEvent EventOnLose;

    //[SerializeField] GameIntEvent ModifyLife;
    private void Start()
    {
        //modifyHealth += UpdateCurrentHealth;
        updateHealth = uiCurrent.UpdateLife;
        updateHealth(Health);
    }
    public void UpdateCurrentHealth(int test)
    {
        Debug.Log("HoLA");
        Health = Math.Clamp(Health + test, 0, 10);
        EventUpdateLife.Raise(Health);
        //updateHealth(Health);
        if (Health == 0)
        {
            EventOnLose.Raise(1);
            //OnPlayerDeath.Invoke();
        }
    }
}
