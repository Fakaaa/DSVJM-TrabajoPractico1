using UnityEngine;
using TMPro;

public class FinalScoreMulti : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scorePlayer1;
    [SerializeField] TextMeshProUGUI scorePlayer2;
    [SerializeField] TextMeshProUGUI winner;

    TransferScores transferData;
    void Start()
    {
        transferData = FindObjectOfType<TransferScores>();

        if(transferData.GetWinner() == transferData.GetPlayer1Money())
            winner.text = "¡Winner Player 1!";
        else
            winner.text = "¡Winner Player 2!";

        scorePlayer1.text = "$ " + transferData?.GetPlayer1Money().ToString();
        scorePlayer2.text = "$ " + transferData?.GetPlayer2Money().ToString();
    }
}
