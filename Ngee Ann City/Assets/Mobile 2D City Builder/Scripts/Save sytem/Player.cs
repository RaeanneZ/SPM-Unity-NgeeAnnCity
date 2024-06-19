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

    // For freeplay mode
    public Player() 
    {
        points = 0;
        turns = 0;
    }

    // For arcade mode
    public Player(int coins)
    {
        points = 0;
        turns = 0;
        this.coins = coins;
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
