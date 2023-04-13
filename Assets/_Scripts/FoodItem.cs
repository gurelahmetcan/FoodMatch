using System.Collections;
using System.Collections.Generic;
using FoodMatch;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Game Item")]
public class FoodItem : ScriptableObject {
    public Constants.FoodTypes foodType;
    public FoodPrefabItem itemPrefab;
    public Vector3 clickedSize;
    public Vector3 clickedPos;
}
