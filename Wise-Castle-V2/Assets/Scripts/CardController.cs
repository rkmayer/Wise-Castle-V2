/*
* Script File: CardController.cs
* Developer: Jenna Magbanua (for Wise Castle)
* Purpose: Chemsitry Game Component
* Description: 
*      This script is attached to the card prefabs. 
*      It stores all the card's information --> ID, values (text), images
*      It controls card actions --> flipping 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardController : MonoBehaviour
{
    public string _cardID = "";//the card's identifier (for matching) -- i.e. the element's atomic number 
    public string cardVal1 = "";//the card's text value 1 -- i.e. the element's name
    public string cardVal2 = "";//the card's text value 2 -- i.e. the element's symbol
    public int cardPair;// integer used to determine which card value to display (either name or symbol)
    
    [SerializeField]
    private TextMesh cardText; //the card's text object --> how the card's value will be displayed
    
    private bool isFlipped = false; //the card's current position (back or front of card showing)
    
    [SerializeField]
    private Sprite frontOfCard; //sprite for front of card
    private Sprite backOfCard; //sprite for back of card
    
    private SpriteRenderer spriteRenderer;
    private GameManager _gameManager; //game manager -- handles the game mechanics (matching, selecting cards, scores, etc.)
    
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        backOfCard = spriteRenderer.sprite;
        _gameManager = FindObjectOfType<GameManager>();
    }
    
    public string cardID
    {
        get 
        {
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
            _gameManager.AddCard(gameObject);
            FlipCard();
        }
    }
    
    public void FlipCard()
    {
        if(!isFlipped)
        {
            spriteRenderer.sprite = frontOfCard;
            isFlipped = true;
            
            if(cardPair == 1)
            {
                cardText.text = cardVal1; 
            }
            else
            {
                cardText.text = cardVal2; 
            }
            
        }
        else
        {
            spriteRenderer.sprite = backOfCard;
            isFlipped = false;
            cardText.text = "???";
        }
    }
}
