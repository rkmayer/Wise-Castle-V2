using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class CardSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject cardPrefab; 
    private List<GameObject> _cardsToSpawn;
    private List<GameObject> _cardsAvailableToSpawn;
    
    [SerializeField]
    private List<int> _cardsToSpawnCount;
    private int cardsToSpawnCount;
    
    [SerializeField]
    private Transform _startPoint;
    
    [SerializeField]
    private int _rows = 3;
    [SerializeField]
    private int _columns = 4;
    
    [SerializeField]
    private float _xDistance = 1.25f;
    [SerializeField]
    private float _yDistance = 1.75f;
    
    private GameManager _gameManager;
    
    [SerializeField]
    private TextAsset chemistryData;
    private List<List<string>> elements = new List<List<string>>(); 
    
    void Awake ()
    {
        _gameManager = FindObjectOfType<GameManager>();
        StartCoroutine(GenerateCards(cardPrefab));
    }
    
    void Start()
    {
        SpawningCards();
    }
    
    private List<string> TextAssetToList(TextAsset ta) 
    {
        return new List<string>(ta.text.Split('\n'));
    }
    
    IEnumerator GenerateCards(GameObject p)
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
    
    private List<GameObject> ChooseRandomCards(List<GameObject> list, int n)
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
    
    void Spawn()
    {
        cardsToSpawnCount = (_rows * _columns) /2; 
        List<GameObject> _cardsToSpawn = ChooseRandomCards(_cardsAvailableToSpawn, cardsToSpawnCount);
        
        for (int x = 0; x < _columns; x++)
        {
            for (int y = 0; y < _rows; y++)
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
