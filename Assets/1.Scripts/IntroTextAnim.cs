using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class IntroTextAnim : MonoBehaviour
{
    TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        text = gameObject.GetComponent<TextMeshProUGUI>();

        StartCoroutine(FadeText(1f, 0f, 2f));
    }

    private IEnumerator FadeText(float startAlpha, float endAlpha, float duration)
    {
        float elapsedTime = 0f;

        Color textColor = text.color;
        textColor.a = startAlpha;
        text.color = textColor;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            textColor.a = Mathf.Lerp(startAlpha, endAlpha, elapsedTime / duration);
            text.color = textColor;

            yield return null;
        }

        textColor.a = endAlpha;
        text.color = textColor;
    }
    // Update is called once per frame
    void Update()
    {

    }
}
