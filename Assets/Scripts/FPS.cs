using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Fps : MonoBehaviour
{
    private float count;
    public Text fpsText; // Reference to the Text component

    private IEnumerator Start()
    {
        while (true)
        {
            count = 1f / Time.unscaledDeltaTime;
            fpsText.text = "FPS: " + Mathf.Round(count); // Update the Text component
            yield return new WaitForSeconds(0.1f);
        }
    }
}
