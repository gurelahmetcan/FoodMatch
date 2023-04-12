using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateScriptableObjects : MonoBehaviour
{
    public List<FoodItem> FoodItems;
    private int instantiateCount;
 
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            for (int i = 0; i < 3; i++)
            {
                var prefabItem = Instantiate(FoodItems[instantiateCount].itemPrefab, Vector3.zero, Quaternion.Euler(-90f, 0f, 0f));
                prefabItem.FoodItemType = FoodItems[instantiateCount].foodType;
            }

            instantiateCount++;
        }
    }
}