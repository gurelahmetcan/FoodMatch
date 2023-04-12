using UnityEngine;

namespace FoodMatch
{
    public class FoodPrefabItem : MonoBehaviour
    {
        #region Fields
    
        private Constants.FoodTypes foodItemType;
    
        public Constants.FoodTypes FoodItemType 
        { 
            get => foodItemType; 
            set => foodItemType = value; 
        }
    
        #endregion

        #region Public Methods
    
        #endregion
    }
}

