using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PointSystem : MonoBehaviour
{
    public static Action<int> modifyPoints;
    public static Action<int> updatePoints;
    //public UnityEvent OnWin;
    public int totalCoins = 0;
    public int _Points;
    public UI_Manager uiCurrent;
    [SerializeField] private GameIntEvent EventUpdateCoins;
    [SerializeField] private GameIntEvent EventOnWin;
    private void Start()
    {
        modifyPoints = (a) => { UpdateCurrentPoints(a); };
        updatePoints = uiCurrent.UpdateCoins;
        updatePoints(_Points);
    }
    public void UpdateCurrentPoints(int points)
    {
        _Points = Math.Clamp(_Points + points, 0, totalCoins);
        EventUpdateCoins.Raise(_Points);
        //updatePoints(_Points);
        if (_Points == totalCoins)
        {
            EventOnWin.Raise(1);
            //OnWin.Invoke();
        }
    }
}
