 using UnityEngine;
 using System.Collections;
 using System.Collections.Generic;
 using FoodMatch;

 public class GameManager : MonoBehaviour 
 {
     Ray ray;
     RaycastHit hit;

     public List<Transform> targetPos;
     private int m_targetCount = 0;
     private List<FoodPrefabItem> m_ClickedItems = new List<FoodPrefabItem>();

     void Update()
     {
         if (Camera.main != null) ray = Camera.main.ScreenPointToRay(Input.mousePosition);
         if(Physics.Raycast(ray, out hit))
         {
             if (Input.GetMouseButtonDown(0) && hit.collider.gameObject.CompareTag("Clickable"))
             {
                 if (m_targetCount <= targetPos.Count - 1)
                 {
                     hit.transform.position = targetPos[m_targetCount].position;
                     m_ClickedItems.Add(hit.transform.GetComponent<FoodPrefabItem>());
                     CheckMatch(hit.transform.GetComponent<FoodPrefabItem>().FoodItemType);
                     m_targetCount++;
                 }
                 else
                 {
                     //Finish Game, full target pos
                 }
             }
         }
     }

     #region Private Methods

     private void CheckMatch(Constants.FoodTypes foodType)
     {
         int matchCount = 0;
         foreach (var item in m_ClickedItems)
         {
             if (item.FoodItemType == foodType)
             {
                 matchCount++;
             }
         }

         if (matchCount >= 3)
         {
             Debug.Log("Matched");
             var matchedItems = m_ClickedItems.FindAll(x => x.FoodItemType == foodType);
             m_ClickedItems.RemoveAll(x => x.FoodItemType == foodType);
             foreach (var item in matchedItems)
             {
                 Destroy(item.gameObject);
             }

             m_targetCount = 0;
         }
         
         //check for matches
     }

     #endregion
 }
 