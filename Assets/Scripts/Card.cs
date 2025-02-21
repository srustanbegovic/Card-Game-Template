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
    public Sprite sprite;
    //public TextMeshProUGUI bcardText;
    //public TextMeshProUGUI tcardText;
    public Image spriteImage;
    public bool played;

    public void Initialize(Card_data data)
    {
        this.data = data;
        suit = data.suit;
        tcard = data.tcard;
        value = data.value;
        color = data.color;
        sprite = data.sprite;
        played = data.played;
        tcardText = transform.GetChild(3).GetComponent<TextMeshProUGUI>();
        bcardText = transform.GetChild(5).GetComponent<TextMeshProUGUI>();

        UpdateCardDisplay();
    }

    private void UpdateCardDisplay()
    {
        string cardText = GetCardText();
        //print(cardText);
        print(cardText);
        tcardText.text = cardText;
        bcardText.text = cardText;
    }

    private  string GetCardText()
    {
        string [] cardText = { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };
        return (cardText[(value - 1)]);
    }
}
