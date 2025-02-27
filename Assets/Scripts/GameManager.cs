using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   #region variables
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

    public CardStack deckStack;
    public CardStack tableau1;
    public CardStack tableau2;
    public CardStack tableau3;
    public CardStack tableau4;
    public CardStack tableau5;
    public CardStack tableau6;
    public CardStack tableau7;
    public CardStack foundation1;
    public CardStack foundation2;
    public CardStack foundation3;
    public CardStack foundation4;
    public CardStack wastePile;
    public Sprite[] cardSuits;
    #endregion
    
   
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
        //InitializeStackPositions();
        CreateDeck();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

            ShuffleDeck();
            DealCards();
        }
    }

    void InitializeStackPositions()
    {
        // Set positions of all stacks
        //deckStack.transform.position = DeckPosition;
        
        // Set tableau positions
        tableau1.transform.position = c1pos;
        tableau2.transform.position = c2pos;
        tableau3.transform.position = c3pos;
        tableau4.transform.position = c4pos;
        tableau5.transform.position = c5pos;
        tableau6.transform.position = c6pos;
        tableau7.transform.position = c7pos;
        
        // Set foundation positions (wherever you want them)
        // foundation1.transform.position = ...
        // ...
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
        
        // Add them to the deck stack instead of the deck list
        /*
        for (int i = 0; i < 52; i++)
        {
            Card card = Instantiate(tempCard, DeckPosition, Quaternion.identity);
            
            // Initialize card data
            Card_data cardData = ScriptableObject.CreateInstance<Card_data>();
            cardData.suit = suit;
            cardData.value = value;
            cardData.color = color;
            card.Initialize(cardData);
            
            // Add directly to the deck stack
            deckStack.AddCard(card);
        }
        */
        // Shuffle the deck
        ShuffleDeck();
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
        cardData.sprite = cardSuits[suit];
        deckStack.AddCard(card);
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
    
    void ShuffleDeck()
    {
        // Create a temporary list of cards
        List<Card> tempDeckList = new List<Card>(deckStack.cardsInStack);
        
        // Clear the deck stack
        deckStack.cardsInStack.Clear();
        
        // Fisher-Yates shuffle
        for (int i = 0; i < tempDeckList.Count; i++)
        {
            int randomIndex = Random.Range(i, tempDeckList.Count);
            Card temp = tempDeckList[i];
            tempDeckList[i] = tempDeckList[randomIndex];
            tempDeckList[randomIndex] = temp;
        }
        
        // Add cards back to deck stack in shuffled order
        foreach (Card card in tempDeckList)
        {
            deckStack.AddCard(card);
        }
    }

    void DealCards()
    {
        // Deal to tableau 1 (1 card)
        DealToTableau(tableau1, 1);
        
        // Deal to tableau 2 (2 cards)
        DealToTableau(tableau2, 2);
        
        // And so on...
        DealToTableau(tableau3, 3);
        DealToTableau(tableau4, 4);
        DealToTableau(tableau5, 5);
        DealToTableau(tableau6, 6);
        DealToTableau(tableau7, 7);
    }

    void DealToTableau(CardStack tableau, int numCards)
    {
        for (int i = 0; i < numCards; i++)
        {
            if (deckStack.cardsInStack.Count > 0)
            {
                // Get top card from deck
                Card card = deckStack.RemoveTopCard();
                
                // Only flip the top card of each tableau
                card.flipped = (i == numCards - 1);
                card.UpdateCardDisplay();
                
                // Add to tableau
                tableau.AddCard(card);
            }
        }
    }

    // Method to move a card between stacks
    public void MoveCard(Card card, CardStack sourceStack, CardStack targetStack)
    {
        // Remove from source
        sourceStack.RemoveCard(card);
        
        // Add to target
        targetStack.AddCard(card);
    }
}
