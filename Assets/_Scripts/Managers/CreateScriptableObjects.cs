using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateScriptableObjects : MonoBehaviour
{
    #region Fields
    
    public List<FoodItem> FoodItems;
    
    private int instantiateCount;
 
    private float xMin = -1.5f;
    private float xMax = 1.5f;
    private float yMin = -1.8f;
    private float yMax = 2.5f;
    
    #endregion

    #region Unity Methods

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            for (int i = 0; i < 3; i++)
            {
                float x = Random.Range(xMin, xMax);
                float y = Random.Range(yMin, yMax);
                Vector3 position = new Vector3(x, y, 0f);

                var prefabItem = Instantiate(FoodItems[instantiateCount].itemPrefab);
                prefabItem.transform.position = position;
                prefabItem.FoodItemType = FoodItems[instantiateCount].foodType;
                prefabItem.ClickedSize = FoodItems[instantiateCount].clickedSize;
                prefabItem.ClickedPos = FoodItems[instantiateCount].clickedPos;
            }

            instantiateCount++;
        }
    }

    #endregion
}