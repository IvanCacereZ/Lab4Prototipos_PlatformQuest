using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    float timer;
    int time = 0;
    public static Action<int> updateTimer;
    public UI_Manager uiCurrent;
    private void Start()
    {
        updateTimer = uiCurrent.UpdateTime;
    }
    private void Update()
    {
        UpdateTimer();
    }
    private void UpdateTimer()
    {
        timer += Time.deltaTime;
        if (timer >= 1.0f)
        {
            time++;
            updateTimer(time);
            timer = 0.0f;
        }
    }
}
