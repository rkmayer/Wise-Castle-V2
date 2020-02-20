using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardController : MonoBehaviour
{
    [SerializeField]
    private string _cardID; //the card's value (for matching)
    private string cardText; //the card's text value (what is on the card)
    
    private bool isFlipped = false; //the card's current position (back or front of card showing)
    
    private Sprite backOfCard; //sprite for back of card
    [SerializeField]
    private Sprite frontOfCard; //sprite for front of card
    
    private SpriteRenderer spriteRenderer;
    
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        backOfCard = spriteRenderer.sprite;
    }
    
    public string cardID
    {
        get {
            return _cardID;
        }
        set
        {
            _cardID = value;
        }
    }
    
    private void OnMouseDown()
    {
        if(!isFlipped)
        {
            FlipCard();
        }
    }
    
    void FlipCard()
    {
        if(!isFlipped)
        {
            spriteRenderer.sprite = frontOfCard;
            isFlipped = true;
        }
        else
        {
            spriteRenderer.sprite = backOfCard;
            isFlipped = false;
        }
    }
}
