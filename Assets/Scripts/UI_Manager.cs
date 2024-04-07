using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI_Manager : MonoBehaviour
{
    public Text _Coins;
    public Text _Life;
    public Text _Time;
    public Canvas WinCanvas;
    public Canvas LooseCanvas;

    public void UpdateCoins(int coins)
    {
        _Coins.text = "Coins: " + coins;
    }
    public void UpdateLife(int life)
    {
        _Life.text = "Vidas: " + life;
    }
    public void UpdateTime(int time)
    {
        _Time.text = "Tiempo: " + time;
    }
    public void ActivateWin()
    {
        WinCanvas.gameObject.SetActive(true);
    }
    public void ActivateLoose()
    {
        LooseCanvas.gameObject.SetActive(true);
    }
}
