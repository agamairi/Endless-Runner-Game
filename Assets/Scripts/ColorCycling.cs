using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorCycling : MonoBehaviour
{
    Color startColor;
    Color endColor = Color.white;
    private bool _canChangeColor = false;
    Color lerpedColor;
    private Camera _cam;
    private void Start()
    {
        _cam = GetComponent<Camera>();
        StartCoroutine(bgColorShifter());

    }
    void Update()
    {
        if (_canChangeColor == true)
        {
            if (startColor != Color.black)
            {
                lerpedColor = Color.Lerp(endColor, startColor, Time.deltaTime);
                _cam.backgroundColor = lerpedColor;
                endColor = startColor;
                _canChangeColor = false;
                StartCoroutine(bgColorShifter());
            }
            else
            {
                startColor = Color.white;
                StartCoroutine(bgColorShifter());
            }

        }

    }

    IEnumerator bgColorShifter()
    {
        startColor.r = Random.value;
        startColor.g = Random.value;
        startColor.b = Random.value;
        startColor.a = 0.5f;
        yield return new WaitForSeconds(10.0f);
        _canChangeColor = true;

    }
}
