using UnityEngine;

public class CardCreator : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    
    public Card SpawnCard()
    {
        GameObject card = Instantiate(prefab) as GameObject;
        
        return card.GetComponent<Card>(); 
    }
}
