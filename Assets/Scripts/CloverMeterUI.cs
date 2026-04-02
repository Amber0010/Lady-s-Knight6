using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CloverMeterUI:MonoBehaviour
{
    public Image[] CloverImages;
    private int cloverCount = 0;
    private Coroutine popRoutine;
    private void OnEnable()
    {
        CloverLeaf.OnCloverCollect += UpdateCloverUI;

    }
    private void OnDisable()
    {
        CloverLeaf.OnCloverCollect -= UpdateCloverUI;

    }
    void Start()
    {
        for (int i= 0; i < CloverImages.Length; i++){
            CloverImages[i].enabled = false;
            CloverImages[i].rectTransform.localScale = Vector3.one;
        }
        CloverImages[0].enabled = true;
    }

    void UpdateCloverUI(int num)
    {
        Debug.Log("Clover UI updated");
        cloverCount += num;
        if (cloverCount >= CloverImages.Length)
        {
            cloverCount = CloverImages.Length - 1;
        }
        for (int i = 0; i < CloverImages.Length;i++) {
            CloverImages[i].enabled = false;
        }

        CloverImages[cloverCount].enabled = true;
        if (popRoutine != null)
        {

            StopCoroutine(popRoutine);
        }
        popRoutine=StartCoroutine(PopAnimation(CloverImages[cloverCount]));
               
     }
    
    private IEnumerator PopAnimation(Image img)
    {
        RectTransform rect = img.rectTransform;
        Vector3 normalSize = Vector3.one;
        Vector3 popSize = new Vector3(1.3f, 1.3f, 1f);
        float duration = .15f;
        float timer = 0f;
        rect.localScale = popSize;
        while (timer < duration)
        {
            timer += Time.deltaTime;
            float t = timer / duration;
            rect.localScale = Vector3.Lerp(popSize, normalSize, t);
            yield return null;
        }
        rect.localScale = normalSize;
        popRoutine = null;

    }
}
