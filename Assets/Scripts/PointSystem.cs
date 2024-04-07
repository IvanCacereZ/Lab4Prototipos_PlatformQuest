using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PointSystem : MonoBehaviour
{
    public static Action<int> modifyPoints;
    public static Action<int> updatePoints;
    public UnityEvent OnWin;
    public int totalCoins = 0;
    public int _Points;
    public UI_Manager uiCurrent;
    private void Start()
    {
        modifyPoints = (a) => { UpdateCurrentPoints(a); };
        updatePoints = uiCurrent.UpdateCoins;
        updatePoints(_Points);
    }
    private void UpdateCurrentPoints(int points)
    {
        _Points = Math.Clamp(_Points + points, 0, totalCoins);
        updatePoints(_Points);
        if (_Points == totalCoins)
        {
            OnWin.Invoke();
        }
    }
}
