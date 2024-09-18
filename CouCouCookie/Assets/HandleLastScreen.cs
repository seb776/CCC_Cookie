using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HandleLastScreen : MonoBehaviour
{
    public TMP_Text Text;
    public float Speed = 1.0f;
    public bool Button;
    private RectTransform _rectTransform;
    // Start is called before the first frame update
    void Start()
    {
        var text = System.IO.File.ReadAllText("Credits.txt");
        Text.text = text;
        //Text.GetComponent<RectTransform>().localPosition = new Vector3(1, 10, 0);
        _rectTransform = Text.GetComponent<RectTransform>();
        _rectTransform.offsetMax = new Vector2(_rectTransform.offsetMax.x, -12);
    }

    public IEnumerator _creditsCorout()
    {
        float step = 1.0f / 30.0f;
        while (true)
        {
            _rectTransform.offsetMax = new Vector2(_rectTransform.offsetMax.x, _rectTransform.offsetMax.y+Speed);

            yield return new WaitForSeconds(step);
        }
    }
    public void StartCredits()
    {
        StartCoroutine(_creditsCorout());
    }

    // Update is called once per frame
    void Update()
    {
        if (Button)
        {
            StartCredits();
            Button = false;
        }
    }
}
