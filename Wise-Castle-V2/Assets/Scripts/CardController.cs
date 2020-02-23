using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardController : MonoBehaviour
{
    public string _cardID = ""; //the card's value (for matching) -- say, 1, 2, 3...
    public string cardVal1 = "";
    public string cardVal2 = "";
    public int cardPair;
    
    [SerializeField]
    private TextMesh cardText; //the card's text value (what is on the card)
    
    private bool isFlipped = false; //the card's current position (back or front of card showing)
    
    [SerializeField]
    private Sprite frontOfCard; //sprite for front of card
    private Sprite backOfCard; //sprite for back of card
    
    private SpriteRenderer spriteRenderer;
    private GameManager _gameManager;
    
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
