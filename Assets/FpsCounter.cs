using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FpsCounter : MonoBehaviour
{
    public TMP_Text fpsText;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(UpdateFPS), 0, 0.5f);
    }

    // Update is called once per frame
    void UpdateFPS()
    {
        fpsText.text = $"FPS: {(int)(1.0f/Time.unscaledDeltaTime)}";
    }
}
