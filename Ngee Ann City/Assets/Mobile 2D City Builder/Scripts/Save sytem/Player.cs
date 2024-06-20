using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Attributes
    private int coins;
    private int points;
    private int turns;

    // Constructors
    public int Coins { 
        get { return coins; } 
        set { coins = value; }
    }
    public int Points { 
        get { return points; } 
        set { points = value; }
    }
    public int Turns
    {
        get { return turns; }
        set { turns = value; }
    }
    
    public void AddCoin(int coin)
    {
        coins += coin;
    }

    public void RemoveCoin(int coin)
    {
        coins -= coin;
    }

    public void AddPoint(int point)
    {
        points += point;
    }
    public void AddTurn(int turn)
    {
        turns += turn;
    }
}
