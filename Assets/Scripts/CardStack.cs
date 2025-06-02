using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardStack : MonoBehaviour
{
    [Header("Stack Properties")]
    public string stackName;
    public float verticalOffset = 30f; // Distance between cards in the stack
    public bool isTableau = false; // Is this a tableau stack with cascading cards?
    //V2
    
    [Header("References")]
    public List<Card> cardsInStack = new List<Card>();
    
    // Add a card to this stack
    public void AddCard(Card card)
    {
        // Make the card a child of this stack
        card.transform.SetParent(transform);
        
        // Add to our list
        cardsInStack.Add(card);
        
        // Bring the card to the front visually
        card.BringToFront();
        
        // Position the card appropriately in the stack
        RepositionCards();
    }
    public void Update()
    {
    
    }
    
    // Remove a card from this stack
    public Card RemoveCard(Card card)
    {
        if (cardsInStack.Contains(card))
        {
            cardsInStack.Remove(card);
            
            // If this was the top card, flip the new top card if needed
            if (cardsInStack.Count > 0 && isTableau)
            {
                Card topCard = cardsInStack[cardsInStack.Count - 1];
                if (!topCard.flipped)
                {
                    topCard.flipped = true;
                    topCard.UpdateCardDisplay();
                }
            }
            
            // Reposition the remaining cards
            RepositionCards();
            
            return card;
        }
        return null;
    }
    
    // Remove the top card from the stack
    
    
    // Get the top card without removing it
    
    // Reposition all cards in the stack with proper layering
    public void RepositionCards()
    {
        Vector3 basePosition = transform.position;
        
        for (int i = 0; i < cardsInStack.Count; i++)
        {
            Card card = cardsInStack[i];
            
            if (card != null)
            {
                float yOffset = isTableau ? verticalOffset * i : 0.5f * i;
                
                card.transform.position = new Vector3(
                    basePosition.x,
                    basePosition.y - yOffset,
                    basePosition.z - (0.01f * i) // Tiny Z-offset for visual clarity
                );
                card.transform.SetSiblingIndex(i);
            }
        }
    }
    public void DeclareTop()
    {
        if (cardsInStack.Count > 0)
        {
            Card topCard = cardsInStack[cardsInStack.Count - 1];
            topCard.topCard = true;
            topCard.UpdateCardDisplay();
        }
    }
    
    
}
