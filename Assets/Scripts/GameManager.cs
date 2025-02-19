using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager gm;
    
    public List<Card> deck = new List<Card>();
    public List<Card> c1 = new List<Card>();
    public List<Card> c2 = new List<Card>();
    public List<Card> c3 = new List<Card>();
    public List<Card> c4 = new List<Card>();
    public List<Card> c5 = new List<Card>();
    public List<Card> c6 = new List<Card>();
    public List<Card> c7 = new List<Card>();

    public List<Card> aces = new List<Card>();
    public List<Card> clubs = new List<Card>();
    public List<Card> hearts = new List<Card>();
    public List<Card> diamonds = new List<Card>();
    public List<Card> flippedcards = new List<Card>();
    public int suit;
    public int value;    public int color;
    public int cardnumber; 
    private Card tempCard;

    private void Awake()
    {
        if (gm != null && gm != this)
        {
            Destroy(gameObject);
        }
        else
        {
            gm = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        CreateDeck();
    }

    // Update is called once per frame
    void Update()
    {
        //print(deck.Count);  
        //print (deck);
    }

    void Deal()
    {
        
    }

    void CreateDeck()
    {
        value = 1;
        suit = 0;
        color =0; 
        for (int i = 1; i < 53; i++)
        {
            if (i % 13 == 0)
            {
                suit++;
                value = 1;
            }
            if (i % 26 == 0)
            {
                color++;
            }
    
            print("Suit: " + suit + " Value: " + value + " Color: " + color);
            CreateCard(suit, value, color);
            value++;
        }
    }
    
void CreateCard(int suit, int value, int color)
{
    // Instantiate the card GameObject
    //GameObject cardObject = Instantiate(tempCard, new Vector3(0, 0, 0), Quaternion.identity);

    // Create a new Card_data instance
    Card_data cardData = ScriptableObject.CreateInstance<Card_data>();
    //cardData.Initialize(suit, value, color, false, value.ToString(), null);
   
    Card card = Instantiate(tempCard, new Vector3(0, 0, 0), Quaternion.identity);
    
    deck.Add(card);
}
    /*
    void CreateCard(int _suit, int _value, int _color)
    {

        Card card = Instantiate(tempCard, new Vector3(0, 0, 0), Quaternion.identity);
        card.data = ScriptableObject.CreateInstance<Card_data>();
        //mr ansell wasnt sure about line 86, dont touch until hes helping me.

        card.suit = suit;
        card.value = value;
        card.color = color;
        deck.Add(card);

      
    /*  
        bcard = data.bcard;
        tcard = data.tcard;
        value = data.value;
        sprite = data.sprite;
        spriteImage.sprite = sprite;

        */
    //}
}
