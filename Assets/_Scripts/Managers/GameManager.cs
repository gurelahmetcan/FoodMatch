 using System;
 using UnityEngine;
 using System.Collections;
 using System.Collections.Generic;
 using System.Linq;
 using FoodMatch;
 using UnityTimer;

 namespace FoodMatch
 {
     public class GameManager : MonoBehaviour 
     {
         Ray ray;
         RaycastHit hit;

         public List<Transform> targetPos;
         [SerializeField] private ParticleSystem m_MatchParticle;
         
         private List<FoodPrefabItem> m_ClickedItems = new List<FoodPrefabItem>();
         private bool m_IsGameFinished;

         public static event Action<bool, int> OnGameFinished;
         public static GameManager Instance;

         private void Awake()
         {
             if (Instance == null)
             {
                 Instance = this;
             }
             else
             {
                 Destroy(gameObject);
             }
         }

         void Update()
         {
             if (Camera.main != null) ray = Camera.main.ScreenPointToRay(Input.mousePosition);
             if(Physics.Raycast(ray, out hit))
             {
                 if (Input.GetMouseButtonDown(0) && hit.collider.gameObject.CompareTag("Clickable") && !m_IsGameFinished)
                 {
                     if (m_ClickedItems.Count <= targetPos.Count - 1)
                     {
                         var prefabItem = hit.transform.GetComponent<FoodPrefabItem>();

                         // Find the index of the last occurrence of the same FoodItemType in the list
                         int index = m_ClickedItems.FindLastIndex(x => x.FoodItemType == prefabItem.FoodItemType);

                         if (index == -1)
                         {
                             // If there are no items with the same FoodItemType, add the item at the end
                             m_ClickedItems.Add(prefabItem);
                         }
                         else
                         {
                             // Insert the item after the last occurrence of the same FoodItemType
                             m_ClickedItems.Insert(index + 1, prefabItem);
                         }

                         prefabItem.transform.localScale = prefabItem.ClickedSize;
                         
                         CheckMatch(prefabItem.FoodItemType);
                         SetPositions();
                     }
                 }
             }
         }

         #region Private Methods

         private void CheckMatch(Constants.FoodTypes foodType)
         {
             int matchCount = m_ClickedItems.Count(x => x.FoodItemType == foodType);
             if (matchCount >= 3)
             {
                 var lastIndex = m_ClickedItems.FindLastIndex(x => x.FoodItemType == foodType);

                 m_MatchParticle.transform.position = targetPos[lastIndex - 1].position;
                 m_MatchParticle.gameObject.SetActive(true);

                 Timer.Register(.5f, () =>
                 {
                     // Find all items that match the given food type and destroy them
                     var matchedItems = m_ClickedItems.Where(x => x.FoodItemType == foodType);
                     foreach (var item in matchedItems)
                     {
                         Destroy(item.gameObject);
                     }
                     
                     m_ClickedItems.RemoveAll(x => x.FoodItemType == foodType);
                     // Remove all items that match the given food type from the list
                     SetPositions();
                     m_MatchParticle.gameObject.SetActive(false);
                     Registry.CurrentItemCount -= 3;
                     CheckGameEnd();
                 });
             }
             else
             {
                 CheckGameEnd();
             }
         }
         
         private void SetPositions()
         {
             // Cache the Transform component for each item in the m_ClickedItems list
             var clickedTransforms = m_ClickedItems.Select(item => item).ToList();

             // Iterate over each item and set its position to the corresponding target position
             for (int i = 0; i < clickedTransforms.Count; i++)
             {
                 var position = clickedTransforms[i].transform.position;
                 position = new Vector3(targetPos[i].position.x, clickedTransforms[i].ClickedPos.y, clickedTransforms[i].ClickedPos.z);
                 clickedTransforms[i].transform.position = position;
             }
         }

         private void CheckGameEnd()
         {
             if (m_ClickedItems.Count == targetPos.Count && !m_IsGameFinished)
             {
                 //Lose condition
                 m_IsGameFinished = true;
                 OnGameFinished?.Invoke(false, Registry.CurrentLevel);
             }

             if (Registry.CurrentItemCount <= 0 && !m_IsGameFinished)
             {
                 //Win condition
                 m_IsGameFinished = true;
                 OnGameFinished?.Invoke(true, Registry.CurrentLevel);
                 Registry.CurrentLevel++;
             }
         }

         #endregion
     }
 }
 