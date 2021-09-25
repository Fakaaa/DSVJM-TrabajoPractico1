using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransferScores : MonoBehaviour
{
    public static TransferScores instance;

    public static TransferScores Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType<TransferScores>();
            return instance;
        }
    }

    public void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [SerializeField] int finalMoneyPJ1;
    [SerializeField] int finalMoneyPJ2;
    [SerializeField] int winnerAmountMoney;

    public void SaveScorePlayer1(int finalAmount)
    {
        finalMoneyPJ1 = finalAmount;
    }
    public void SaveScorePlayer2(int finalAmount)
    {
        finalMoneyPJ2 = finalAmount;
    }

    public void TransferWinnerMultiplayer(int winnerMoney)
    {
        winnerAmountMoney = winnerMoney;
    }

    public int GetWinner()
    {
        return winnerAmountMoney;
    }
    public int GetPlayer1Money()
    {
        return finalMoneyPJ1;
    }
    public int GetPlayer2Money()
    {
        return finalMoneyPJ2;
    }
}
