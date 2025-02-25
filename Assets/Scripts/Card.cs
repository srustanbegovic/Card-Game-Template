using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public Card_data data;
    public TextMeshProUGUI tcardText = null;
    public TextMeshProUGUI bcardText = null;

    private Image cardImage; 

    public int suit;
    public string tcard;
    public int value;
    public int color;
    //public Sprite sprite;
    public Sprite sprite;
    public bool flipped;

    public void Initialize(Card_data data)
    {
        this.data = data;
        suit = data.suit;
        tcard = data.tcard;
        value = data.value;
        color = data.color;
        sprite = data.sprite;
        flipped = data.flipped;
        tcardText = transform.GetChild(3).GetComponent<TextMeshProUGUI>();
        bcardText = transform.GetChild(5).GetComponent<TextMeshProUGUI>();

        UpdateCardDisplay();
    }

    public void UpdateCardDisplay()
    {
        if (flipped) 
        {
            string cardText = GetCardText();
            //print(cardText);
            print(cardText);
            tcardText.text = cardText;
            bcardText.text = cardText;
           
        }
        else
        {
            tcardText.text = "";
            bcardText.text = "";
            sprite = null; 
        }
    }

    private  string GetCardText()
    {
        string [] cardText = { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };
        return (cardText[(value - 1)]);
    }
}
