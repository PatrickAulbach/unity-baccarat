using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChipManager : MonoBehaviour
{
    [SerializeField] List<Sprite> sprites;
    [SerializeField] GameObject prefab;


    private void Start() {
        SpawnInitialChips();
    }

    public void SpawnChips(int amount)
    {
        int[] denominations = { 100, 50, 20, 10 };

        foreach (int denomination in denominations)
        {
            int quantity = amount / denomination;
            amount %= denomination;

            for (int i = 0; i < quantity; i++)
            {
                var chip = SpawnChip();
                chip.value = denomination;
                chip.SetOrigin(BaccaratConstants.ORIGIN_POSITIONS[denomination]);
                switch (denomination)
                {
                    case 100:
                        chip.SetSprite(sprites[0]);
                        break;
                    case 50:
                        chip.SetSprite(sprites[1]);
                        break;
                    case 20:
                        chip.SetSprite(sprites[2]);
                        break;
                    case 10:
                        chip.SetSprite(sprites[3]);
                        break;
                    default:
                        chip.SetSprite(sprites[0]);
                        break;
                }
                chip.Return();
            }
        }
    }

    private Chip SpawnChip()
    {
        GameObject chip = Instantiate(prefab, BaccaratConstants.CHIP_POSITION, new Quaternion(), GameObject.Find("MainCanvas").GetComponent<Canvas>().transform) as GameObject;
        
        return chip.GetComponent<Chip>(); 
    }

    private void SpawnInitialChips()
    {
        SpawnChips(500);
        SpawnChips(50);
        SpawnChips(50);
        SpawnChips(50);
        SpawnChips(50);
        SpawnChips(50);
        SpawnChips(50);
        SpawnChips(20);
        SpawnChips(20);
        SpawnChips(20);
        SpawnChips(20);
        SpawnChips(20);
        SpawnChips(10);
        SpawnChips(10);
        SpawnChips(10);
        SpawnChips(10);
        SpawnChips(10);
        SpawnChips(10);
        SpawnChips(10);
        SpawnChips(10);
        SpawnChips(10);
        SpawnChips(10);
    }
    
}
