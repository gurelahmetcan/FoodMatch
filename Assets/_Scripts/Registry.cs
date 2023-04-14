using UnityEngine;

namespace FoodMatch
{
    public static class Registry
    {
        private const string CurrentLevelKey = "currentLevel";
        private const string CurrentLevelItemCount = "levelItemCount";

        public static int CurrentLevel
        {
            get
            {
                return PlayerPrefs.GetInt(CurrentLevelKey, 1);
            }
            set
            {
                PlayerPrefs.SetInt(CurrentLevelKey, value);
                PlayerPrefs.Save();
            }
        }
        
        public static int CurrentItemCount
        {
            get
            {
                return PlayerPrefs.GetInt(CurrentLevelItemCount, 1);
            }
            set
            {
                PlayerPrefs.SetInt(CurrentLevelItemCount, value);
                PlayerPrefs.Save();
            }
        }
    }
}