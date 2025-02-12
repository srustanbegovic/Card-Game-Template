using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public Card_data data;
    [SerializeField] private TextMeshProUGUI tcardText;
    [SerializeField] private TextMeshProUGUI bcardText;

    [SerializeField] private Image cardImage; 

    /*public int suit;
    public string tcard;
    public int value;
    public int color;
    public Sprite sprite;
    public TextMeshProUGUI bcardText;
    public TextMeshProUGUI tcardText;
    public Image spriteImage;
    public bool played;*/


    public void Initialize(Card_data data)
    {
        this.data = data;
        UpdateCardDisplay();
    }

    private void UpdateCardDisplay()
    {
        string cardText = GetCardText();
        if (tcardText != null)
        {
            tcardText.text = cardText;
            bcardText.text = cardText;
        
        }
        if (cardImage != null)
        {
            cardImage.sprite = data.sprite;
        }
    }

    private  string GetCardText()
    {
        string [] cardText = { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };
        return (cardText[(data.value-1)]);
    }
}
