using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePanel : MonoBehaviour 
{
   [SerializeField] private RectTransform underline;
   [SerializeField] private RectTransform[] headerElements;
   private RectTransform highlightedElement;

   private void Start()
   {
       highlightedElement = headerElements[0];
   }

  
   public void OnClickButton (int i)
   {
       highlightedElement = headerElements[i];
       StartCoroutine(HighlightHeaderElement());
   }

   IEnumerator HighlightHeaderElement()
   {
       underline.transform.SetParent(highlightedElement.transform);
       float timeOfTravel = 0.25f;
       float currentTime = 0.0f;
       float normalizedValue;
       Vector3 startPosition = underline.anchoredPosition;
       Vector3 endPosition = Vector3.zero;
       Vector2 startWidth = new Vector2(underline.rect.width, 20);
       Vector2 endWidth = new Vector2(highlightedElement.rect.width, 20);
       while(currentTime <= timeOfTravel)
       {
           currentTime += Time.deltaTime;
           normalizedValue = currentTime / timeOfTravel;
           underline.anchoredPosition = Vector3.Lerp(startPosition, endPosition, normalizedValue);
           underline.sizeDelta = Vector2.Lerp(startWidth, endWidth, normalizedValue);
           yield return null;
       }
   }

}


	

