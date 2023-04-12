 using UnityEngine;
 using System.Collections;
 using System.Collections.Generic;
 using System.Linq;
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
                     m_targetCount++;
                     CheckMatch(hit.transform.GetComponent<FoodPrefabItem>().FoodItemType);
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

         // Use a lambda expression to count the number of items that match the given food type
         matchCount = m_ClickedItems.Count(x => x.FoodItemType == foodType);

         if (matchCount >= 3)
         {
             // Use LINQ to find all items that match the given food type and destroy them
             var matchedItems = m_ClickedItems.Where(x => x.FoodItemType == foodType);
             foreach (var item in matchedItems)
             {
                 Destroy(item.gameObject);
             }

             // Remove all items that match the given food type from the list
             m_ClickedItems.RemoveAll(x => x.FoodItemType == foodType);

             m_targetCount = 0;

             SetPositions();
         }
         
         //check for matches
     }
     
     private void SetPositions()
     {
         // Cache the Transform component for each item in the m_ClickedItems list
         var clickedTransforms = m_ClickedItems.Select(item => item.transform).ToList();

         // Iterate over each item and set its position to the corresponding target position
         for (int i = 0; i < clickedTransforms.Count; i++)
         {
             clickedTransforms[i].position = targetPos[i].position;
         }
     }

     #endregion
 }
 