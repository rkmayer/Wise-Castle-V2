/*
* Script File: CardSpawner.cs
* Developer: Jenna Magbanua (for Wise Castle)
* Purpose: Chemsitry Game Component
* Description:  
*      It takes the data from the chemistry elements text file to make a list of card prefabs. 
*      From this list, 6 are randomly selected and put in a list.
*      From this new list, the cards are instatiated randonly on screen in rows/cols. 
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class CardSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject cardPrefab; 
    
    private List<GameObject> _cardsToSpawn;//the cards to be spawned on screen 
    private List<GameObject> _cardsAvailableToSpawn; //the complete list of all element cards 
    private int cardsToSpawnCount;
    
    [SerializeField]
    private Transform _startPoint;
    private int rows = 3;
    private int columns = 4;

    private float _xDistance = 3;
    private float _yDistance = 2;
    
    private GameManager _gameManager;
    
    [SerializeField]
    private TextAsset chemistryData;
    
    void Awake () //done before the game starts
    {
        _gameManager = FindObjectOfType<GameManager>();
        StartCoroutine(GenerateCards(cardPrefab)); //needs to be done first before spawning is allowed
    }
    
    void Start() //when the game starts 
    {
        SpawningCards();
    }
    
    private List<string> TextAssetToList(TextAsset ta)//transforms text asset to a list of strings  
    {
        return new List<string>(ta.text.Split('\n'));
    }
    
    IEnumerator GenerateCards(GameObject p)//generates the main list of card prefabs where cards are selected
    {   
        List<string> elementList = TextAssetToList(chemistryData);
        List<string> elementData; 
        _cardsAvailableToSpawn = new List<GameObject>(); 
        
        for(int i = 0; i < elementList.Count; i++)
        {
            elementData = elementList[i].Split(' ').ToList(); 
            GameObject clone = (GameObject)Instantiate(p);
            
            clone.name = elementData[1];
            clone.GetComponent<CardController>().cardID = elementData[0]; //atomic number
            clone.GetComponent<CardController>().cardVal1 = elementData[1]; //name
            clone.GetComponent<CardController>().cardVal2 = elementData[2]; //symbol
            clone.GetComponent<CardController>().cardPair = 1; 
            
            _cardsAvailableToSpawn.Add(clone);
            clone.SetActive(false);
        }
        
        yield return null;
    }
    
    private List<GameObject> ChooseRandomCards(List<GameObject> list, int n)//randomly selects 6 cards from list and returns new list
    {
        List<GameObject> genList = new List<GameObject>();
        
        while(genList.Count < n*2 && list.Count > 0)
        {
            int index = Random.Range(0, list.Count);
            
            GameObject clone = (GameObject)Instantiate(list[index]);
            clone.GetComponent<CardController>().cardPair = 2; 
            
            genList.Add(list[index]);
            genList.Add(clone);
            
            clone.SetActive(false);
            list.RemoveAt(index);
        }
        
        return genList; 
    }
    
    void Spawn() //spawns the cards and displays them on screen 
    {
        cardsToSpawnCount = (rows * columns) / 2; 
        List<GameObject> _cardsToSpawn = ChooseRandomCards(_cardsAvailableToSpawn, cardsToSpawnCount);
        
        for (int x = 0; x < columns; x++)
        {
            for (int y = 0; y < rows; y++)
            {
                int index = Random.Range(0, _cardsToSpawn.Count);
            
                Instantiate(_cardsToSpawn[index], new Vector3(_startPoint.position.x + _xDistance * x, _startPoint.position.y - _yDistance * y, _startPoint.position.z), Quaternion.Euler(0.0f, 0.0f, 0.0f)).SetActive(true);

                _cardsToSpawn.RemoveAt(index);
            }
        }
    }
    
    public void SpawningCards()
    {
        Spawn();
        gameObject.SetActive(false); //After spawning objects deactivate this gameObject
    }
}
