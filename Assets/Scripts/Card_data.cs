using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Card_data", menuName = "Cards/Card_data", order = 1)]
public class Card_data : ScriptableObject
{
    public int suit;
    public string tcard;
    public int value;
    public int color; 
    public Sprite sprite;
    public bool played;

    public void Initialize(int suit, int value, int color, bool played, string tcard, Sprite sprite)
    {
        this.suit = suit;
        this.value = value;
        this.color = color;
        this.played = played;
        this.tcard = tcard;
        this.sprite = sprite;
    }
}
