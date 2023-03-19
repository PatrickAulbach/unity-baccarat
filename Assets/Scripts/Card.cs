using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Card : MonoBehaviour
{
    [SerializeField] Vector3 position;
    public SpriteValue spriteValue {get; set;}

    public void Reset() 
    {
        DestroyImmediate(this.gameObject);
    }

    public void SetSprite()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = spriteValue.sprite;
    }

    public void Rotate(Vector3 rotation) 
    {
        transform.DOBlendableLocalRotateBy(rotation, BaccaratConstants.speed, RotateMode.Fast);
    }

    public void Move(Vector3 position)
    {
        transform.DOMove(position, BaccaratConstants.speed);
    }

}
