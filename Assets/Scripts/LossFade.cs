using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class LossFade : MonoBehaviour
{
    public Image fadeI;
    public float fadeDur = 1f;
    public IEnumerator FadeToBlack()
    {
        float num = 0f;
        while (num < fadeDur)
        {
            num += Time.deltaTime;
            float alpha = num / fadeDur;
            fadeI.color = new Color(0, 0, 0, alpha);
            yield return null;
        }
        fadeI.color = new Color(0, 0, 0, 1);
    }
}
