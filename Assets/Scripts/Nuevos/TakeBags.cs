using UnityEngine;
using UnityEngine.UI;

public class TakeBags : MonoBehaviour
{
    Image uiInventory;
    [SerializeField] int counterBags;
    [SerializeField] Sprite [] stockImages;
    [SerializeField] Sprite maxStock;
    [SerializeField] Player camionPlayer;

    float timerLastStock;
    float timerMaxStock;
    float timer;

    void Start()
    {
        timerLastStock = 0.5f;
        timerMaxStock = 1.0f;
        timer = 0;

        uiInventory = gameObject.GetComponent<Image>();

        camionPlayer.agregarBolsa += AddBagOfMoney;
    }

    void Update()
    {
        if(counterBags < stockImages.Length-1)
        {
            uiInventory.sprite = stockImages[counterBags];
        }
        else if(counterBags == stockImages.Length - 1)
        {
            timer += Time.deltaTime;

            if(timer < timerLastStock && timer < timerMaxStock)
            {
                uiInventory.sprite = stockImages[counterBags];
            }
            if(timer > timerLastStock && timer < timerMaxStock)
            {
                uiInventory.sprite = maxStock;
            }

            if (timer > timerLastStock && timer > timerMaxStock)
                timer = 0;
        }
    }

    public void AddBagOfMoney()
    {
        counterBags += 1;
    }

    public void DepositBagOfMoney()
    {
        counterBags -= 1;
    }
}
