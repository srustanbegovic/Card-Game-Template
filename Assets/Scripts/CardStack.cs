using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardStack : MonoBehaviour
{
    [Header("Stack Properties")]
    public string stackName;
    public float verticalOffset = 30f; // Distance between cards in the stack
    public bool isTableau = false; // Is this a tableau stack with cascading cards?
    
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
    public Card RemoveTopCard()
    {
        if (cardsInStack.Count > 0)
        {
            Card topCard = cardsInStack[cardsInStack.Count - 1];
            return RemoveCard(topCard);
        }
        return null;
    }
    
    // Get the top card without removing it
    public Card PeekTopCard()
    {
        if (cardsInStack.Count > 0)
            return cardsInStack[cardsInStack.Count - 1];
        return null;
    }
    
    // Reposition all cards in the stack with proper layering
    public void RepositionCards()
    {
        Vector3 basePosition = transform.position;
        
        for (int i = 0; i < cardsInStack.Count; i++)
        {
            Card card = cardsInStack[i];
            
            if (card != null)
            {
                // Position the card with proper vertical offset
                // If it's a tableau, we cascade down vertically
                // Otherwise, cards stack with minimal offset
                float yOffset = isTableau ? verticalOffset * i : 0.5f * i;
                
                card.transform.position = new Vector3(
                    basePosition.x,
                    basePosition.y - yOffset,
                    basePosition.z - (0.01f * i) // Tiny Z-offset for visual clarity
                );
                
                // Set sibling index to ensure proper layering - higher index appears on top
                card.transform.SetSiblingIndex(i);
            }
        }
    }
    
    // Check if a card can be added to this stack according to solitaire rules
    public bool CanAddCard(Card card)
    {
        // Foundation stacks (build up by suit)
        if (stackName.Contains("Foundation"))
        {
            // Empty foundation can only take Aces
            if (cardsInStack.Count == 0)
                return card.value == 1; // Ace
                
            Card topCard = PeekTopCard();
            // Same suit, one higher value
            return (card.suit == topCard.suit && card.value == topCard.value + 1);
        }
        
        // Tableau stacks (build down, alternating colors)
        if (isTableau)
        {
            // Empty tableau can take any card (traditionally a King, but we'll allow any)
            if (cardsInStack.Count == 0)
                return true;
                
            Card topCard = PeekTopCard();
            // Different color, one lower value
            return (card.color != topCard.color && card.value == topCard.value - 1);
        }
        
        // For other stacks, like waste pile, we don't have restrictions
        return true;
    }
    
    // For tableau stacks, we want to be able to move multiple cards at once
    public List<Card> GetCardsOnTop(Card startCard)
    {
        List<Card> cardsToMove = new List<Card>();
        
        if (cardsInStack.Contains(startCard))
        {
            int startIndex = cardsInStack.IndexOf(startCard);
            
            for (int i = startIndex; i < cardsInStack.Count; i++)
            {
                cardsToMove.Add(cardsInStack[i]);
            }
        }
        
        return cardsToMove;
    }
}
