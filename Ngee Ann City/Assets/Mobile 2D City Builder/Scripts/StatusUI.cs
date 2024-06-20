using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatusUI : MonoBehaviour
{
    [Header("UI Objects")]
    public TextMeshProUGUI pointText;
    public TextMeshProUGUI coinText;
    public TextMeshProUGUI turnText;

    public void SetPointText(int newPoint)
    {
        pointText.text = newPoint.ToString();
    }

    public void SetCoinText(int newCoin)
    {
        coinText.text = newCoin.ToString();
    }

    public void SetTurnText(int newTurn)
    {
        pointText.text = newTurn.ToString();
    }
}
