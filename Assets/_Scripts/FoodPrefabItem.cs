using UnityEngine;

namespace FoodMatch
{
    public class FoodPrefabItem : MonoBehaviour
    {
        #region Fields
    
        private Constants.FoodTypes m_foodItemType;
        public Constants.FoodTypes FoodItemType 
        { 
            get => m_foodItemType; 
            set => m_foodItemType = value; 
        }
        
        private Vector3 m_clickedSize;
        public Vector3 ClickedSize 
        { 
            get => m_clickedSize; 
            set => m_clickedSize = value; 
        }
        
        private Vector3 m_clickedPos;
        public Vector3 ClickedPos 
        { 
            get => m_clickedPos; 
            set => m_clickedPos = value; 
        }
    
        #endregion
    }
}

