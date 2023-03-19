using System.Collections.Generic;
using UnityEngine;

public class BaccaratConstants
{
    public static readonly List<Vector3> PLAYER_CARD_POSITIONS = new List<Vector3> {new Vector3(-4, 2, 0), new Vector3(-2, 2, 0), new Vector3(-7, 2, 0)};
    public static readonly List<Vector3> BANKER_CARD_POSTIONS = new List<Vector3> {new Vector3(2, 2, 0), new Vector3(4, 2, 0), new Vector3(7, 2, 0)};
    public static readonly Vector3 ROTATION = new Vector3(0, 0, 90); 
    public const int speed = 1;
    public static readonly Vector3 CHIP_POSITION = new Vector3(-5, -2, 0);
    public static readonly Dictionary<int, Vector3> ORIGIN_POSITIONS = new Dictionary<int, Vector3>{
        {10, new Vector3(-12, -4, 0)},
        {20, new Vector3(-10.5f, -4, 0)},
        {50, new Vector3(-9f, -4, 0)},
        {100, new Vector3(-7.5f, -4, 0)},
    };
}