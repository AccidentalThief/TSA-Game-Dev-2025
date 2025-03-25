using UnityEngine;
using TMPro; // Important!
using System.Collections;

public class Opacity : MonoBehaviour
{
    public float cycleSpeed = 1.0f;
    public float minOpacity = 0.2f;
    public float maxOpacity = 1.0f;

    private TextMeshProUGUI textComponent; // Or TextMeshPro for 3D Text.
    private float timeElapsed = 0.0f;
    private bool okStart = false;

    IEnumerator Start()
    {
        textComponent = GetComponent<TextMeshProUGUI>(); //Or TextMeshPro for 3D Text
        yield return StartCoroutine("Wait");
    }

    void Update()
    {
        if(okStart) {
            timeElapsed += Time.deltaTime * cycleSpeed;
        }
        float opacity = Mathf.Sin(timeElapsed);
        opacity = Mathf.Lerp(minOpacity, maxOpacity, opacity);
        Color currentColor = textComponent.color;
        currentColor.a = opacity;
        textComponent.color = currentColor;
    }

    IEnumerator Wait() {
        yield return new WaitForSeconds(2);
        okStart = true;
    }
}