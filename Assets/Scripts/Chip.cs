using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Chip : MonoBehaviour 
{
     
    public int value {get; set;}
    private Image image;
    public DropZone dropZone {get; set;}
    private Vector3 origin;

    public void SetOrigin(Vector3 origin)
    {
        this.origin = origin;
    }
    
    public void RemoveFromDropZone()
    {
        if (dropZone != null) {
            dropZone.RemoveChip(this);
            dropZone = null;
        }
    }

    public void SetSprite(Sprite sprite)
    {
        gameObject.GetComponent<Image>().overrideSprite = sprite;
    }

    public void Return() 
    {
        transform.DOMove(origin, 0.5f);
    }
}