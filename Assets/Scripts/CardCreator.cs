using UnityEngine;

public class CardCreator : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    
    public Card SpawnCard()
    {
        // GameObject card = Instantiate(prefab) as GameObject;
        GameObject card = Instantiate(prefab, BaccaratConstants.CARD_START_POSITION, new Quaternion(), GameObject.Find("MainCanvas").GetComponent<Canvas>().transform) as GameObject;
        
        return card.GetComponent<Card>(); 
    }
}
