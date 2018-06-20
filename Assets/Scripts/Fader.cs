using UnityEngine;
using System.Collections;

public class GUIFadeScript : MonoBehaviour {
	
	public CanvasGroup fadeCanvasGroup;
	
	public IEnumerator FadeToBlack(float speed)
	{
		while (fadeCanvasGroup.alpha < 1f)
		{
			fadeCanvasGroup.alpha += speed * Time.deltaTime;
			
			yield return null;
		}
	}
	
}