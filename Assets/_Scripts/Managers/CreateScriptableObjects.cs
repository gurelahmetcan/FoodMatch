using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace FoodMatch
{
    public class CreateScriptableObjects : MonoBehaviour
    {
        #region Fields
    
        public List<FoodItem> FoodItems;
        
        private float xMin = -1f;
        private float xMax = 1f;
        private float yMin = -1.8f;
        private float yMax = 1.3f;
    
        #endregion

        #region Unity Methods

        void Start()
        {
            var count = 0;
            var type = 0;
            var instantiateCount = Registry.CurrentLevel < FoodItems.Count ? Registry.CurrentLevel : FoodItems.Count;

            for (int i = 0; i < instantiateCount; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    float x = Random.Range(xMin, xMax);
                    float y = Random.Range(yMin, yMax);
                    Vector3 position = new Vector3(x, y, 0f);

                    var prefabItem = Instantiate(FoodItems[type].itemPrefab);
                    prefabItem.transform.position = position;
                    prefabItem.FoodItemType = FoodItems[type].foodType;
                    prefabItem.ClickedSize = FoodItems[type].clickedSize;
                    prefabItem.ClickedPos = FoodItems[type].clickedPos;
                    count++;
                }

                type++;
            }

            Registry.CurrentItemCount = count;
        }

        #endregion
    }
}