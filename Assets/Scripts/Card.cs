using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    #region variables
    public Card_data data;
    public TextMeshProUGUI tcardText = null;
    public TextMeshProUGUI bcardText = null;
    GameManager gm;

    private Image cardImage; 

    public int suit;
    public string tcard;
    public int value;
    public int color;
    //public Sprite sprite;
    public Sprite sprite;
    public bool flipped;
    public bool topCard = false; // Is this card the top card in a stack?

    // Add these variables for drag and drop
    private bool isDragging = false;
    private Vector3 dragOffset = new Vector3(-400,-100,0);
    private Vector3 startPosition;
    private Transform startParent;
    private CardStack sourceStack;
    private GameManager gameManager;
    #endregion

    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
        //cardImage = GetComponent<Image>();
        gameManager = FindObjectOfType<GameManager>();
    }

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
    public void BringToFront()
    {
        transform.SetAsLastSibling();
    }
    public void Update()
    {
        
        
    }
    public void UpdateCardDisplay()
    {
        CheckifFlipped();
        if (flipped) 
        {
            string cardText = GetCardText();
            //print(cardText);
            print(cardText);
            tcardText.text = cardText;
            bcardText.text = cardText;
            //we need to get the image, not the sprite component
            //sprite.GetComponent<Image>() = gm.cardSuits[suit];
            if(suit == 0 || suit == 1)
            {
                tcardText.color = Color.black;
                bcardText.color = Color.black;
                
                

            }
            else
            {
                tcardText.color = Color.red;
                bcardText.color = Color.red;
            }
            sprite = gm.cardSuits[suit];
           
        }
        else
        {
            tcardText.text = "";
            bcardText.text = "";
            //sprite = null; 
        }
    }
    public void CheckifFlipped()
    {
        
    }
    
    private  string GetCardText()
    {
        string [] cardText = { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };
        return (cardText[(value - 1)]);
    }

    // Detect card click
    public void OnMouseDown()
    {
        
    }



    // Find which stack is under the mouse position
    /*private CardStack FindTargetStack()
    {
        // Raycast to find what's under the mouse
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        
        if (hit.collider != null)
        {
            // Check if we hit a stack
            CardStack stack = hit.collider.GetComponent<CardStack>();
            if (stack != null)
                return stack;
                
            // Check if we hit another card
            Card card = hit.collider.GetComponent<Card>();
            if (card != null)
                return card.GetComponentInParent<CardStack>();
        }
        
        // Try finding nearby stacks (since precise hits can be difficult)
        CardStack[] allStacks = FindObjectsOfType<CardStack>();
        float closestDistance = float.MaxValue;
        CardStack closestStack = null;
        
        foreach (CardStack stack in allStacks)
        {
            float distance = Vector3.Distance(stack.transform.position, transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestStack = stack;
            }
        }
        
        // Only return if it's close enough
        if (closestDistance < 100f) // Adjust this threshold as needed
            return closestStack;
            
        return null;
    }*/

    // Check if this card can be moved to the target stack
    private bool CanMoveToStack(CardStack targetStack)
    {
        // Can't move to the same stack
        if (targetStack == sourceStack)
            return false;

        // Check if the move is valid according to solitaire rules
        return true;
    }
}
