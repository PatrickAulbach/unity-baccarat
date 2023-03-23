using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public SpriteValue spriteValue {get; set;}

    public void Reset() 
    {
        DestroyImmediate(this.gameObject);
    }

    public void SetSprite()
    {
        gameObject.GetComponent<Image>().sprite = spriteValue.sprite;
    }

    public void Rotate() 
    {
        Vector3 rotation = OptionValues.isRandomized == true ? new Vector3(0, 0, Random.Range(80, 100)) : BaccaratConstants.ROTATION;
        transform.DOBlendableLocalRotateBy(rotation, OptionValues.gameSpeed, RotateMode.Fast);
    }

    public void Move(Vector3 position)
    {
        transform.DOMove(position, OptionValues.gameSpeed);
        if (OptionValues.isRandomized) {
            transform.DOBlendableLocalRotateBy(new Vector3(0, 0, Random.Range(-10, 10)), OptionValues.gameSpeed, RotateMode.LocalAxisAdd);
        }
    }

}
