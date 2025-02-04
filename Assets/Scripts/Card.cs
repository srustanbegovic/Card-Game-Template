using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public Card_data data;
    public int suit;
    public string tcard;
    public string bcard;
    public int value;
    public Sprite sprite;
    public TextMeshProUGUI bcardText;
    public TextMeshProUGUI tcardText;
    public TextMeshProUGUI valueText;
    public Image spriteImage;
        

    // Start is called before the first frame update
    void Start()
    {
        bcard = data.bcard;
        tcard = data.tcard;
        value = data.value;
        sprite = data.sprite;
        bcardText.text = bcard.ToString();
        tcardText.text = tcard.ToString();
        valueText.text = value.ToString();
        spriteImage.sprite = sprite;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
