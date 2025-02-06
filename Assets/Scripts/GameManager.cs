using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager gm;
    public class Card
    {
        public int suit;
        public int color; 
        public int value;
        public Sprite sprite;
    }
    public List<Card> deck = new List<Card>();
    public List<Card> flippedcards = new List<Card>();
    public GameObject cardPrefab;
    public int suit;
    public int value;
    public int color;
    public int cardnumber; 

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
        CreateCards();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Deal()
    {
        
    }

    void CreateCards()
    {
        value = 1;
        suit = 1;
        color =1; 
        for (int i = 1; i < 53) 
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
    
            GameObject cardObject = CreateCard(suit, value, color);
            
            value++;
        }
    }

    GameObject CreateCard()
    {
        GameObject cardObject = Instantiate(cardPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        Card card = new Card();
        card.suit = suit;
        card.value = value;
        card.color = color;
        card.sprite = cardObject.GetComponent<SpriteRenderer>().sprite;
        deck.Add(card);
        return cardObject;
    }



    
}
