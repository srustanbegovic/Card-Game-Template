using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager gm;
    
    public List<Card> deck = new List<Card>();
    public List<Card> c1 = new List<Card>();
    public Vector3 c1pos; 
    public List<Card> c2 = new List<Card>();
    public Vector3 c2pos;
    public List<Card> c3 = new List<Card>();
    public Vector3 c3pos;
    public List<Card> c4 = new List<Card>();
    public Vector3 c4pos;
    public List<Card> c5 = new List<Card>();
    public Vector3 c5pos;
    public List<Card> c6 = new List<Card>();
    public Vector3 c6pos;
    public List<Card> c7 = new List<Card>();
    public Vector3 c7pos;
    

    public List<Card> aces = new List<Card>();
    public List<Card> clubs = new List<Card>();
    public List<Card> hearts = new List<Card>();
    public List<Card> diamonds = new List<Card>();
    public List<Card> flippedcards = new List<Card>();
    public int suit;
    public int value;   
    public int color;
    public int cardnumber; 
    public Vector3 DeckPosition;
    public Card tempCard;
    public Transform canvas;

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
        if(Input.GetKeyDown(KeyCode.Space))
        {
            ShuffleDeck();
            Deal(c1pos, 1, c1);
            Deal(c2pos, 2, c2);
            Deal(c3pos, 3, c3);
            Deal(c4pos, 4, c4);
            Deal(c5pos, 5, c5);
            Deal(c6pos, 6, c6);
            Deal(c7pos, 7, c7);
            UpdateCardDisplay();
        }
    }

    void Deal(Vector3 deckpos, int numofcards, List<Card> deckdest)
    {
        for (int i = 0; i < numofcards; i++)
        {
            deckdest.Add(deck[i]);
            deckpos = new Vector3(deckpos.x, deckpos.y - (15*i), deckpos.z);
            deck[i].transform.position = deckpos;
            deck[i].transform.SetParent(canvas);
            deck.RemoveAt(i);
            Renderer cardRenderer = deckdest[i].GetComponent<Renderer>();
            cardRenderer.sortingOrder = numofcards - i;
            if (i == numofcards - 1)
            {
                deckdest[i].flipped = true;
            }
            else 
            {
                deckdest[i].flipped = false;
            }
        }
    }
    void ShuffleDeck()
    {
        for (int i = 0; i < deck.Count; i++)
        {
            Card temp = deck[i];
            int randomIndex = Random.Range(i, deck.Count);
            deck[i] = deck[randomIndex];
            deck[randomIndex] = temp;
        }
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
    
            //print("Suit: " + suit + " Value: " + value + " Color: " + color);
            CreateCard(suit, value, color);
            value++;
        }
    }
    
    void CreateCard(int suit, int value, int color)
    {
        Card_data cardData = ScriptableObject.CreateInstance<Card_data>();
        cardData.suit = suit;
        cardData.value = value;
        cardData.color = color;
        print(DeckPosition);
        Card card = Instantiate(tempCard, DeckPosition, Quaternion.identity);
        card.Initialize(cardData);
        card.name = cardData.suit + " " + cardData.value + " " + cardData.color;
        card.transform.SetParent(canvas);
    
        deck.Add(card);
    }
    void UpdateCardDisplay()
    {
        foreach (Card card in deck)
        {
            card.UpdateCardDisplay();
        }
        foreach (Card card in c1)
        {
            card.UpdateCardDisplay();
        }
        foreach (Card card in c2)
        {
            card.UpdateCardDisplay();
        }
        foreach (Card card in c3)
        {
            card.UpdateCardDisplay();
        }
        foreach (Card card in c4)
        {
            card.UpdateCardDisplay();
        }
        foreach (Card card in c5)
        {
            card.UpdateCardDisplay();
        }
        foreach (Card card in c6)
        {
            card.UpdateCardDisplay();
        }
        foreach (Card card in c7)
        {
            card.UpdateCardDisplay();
        }
    }
    
}
