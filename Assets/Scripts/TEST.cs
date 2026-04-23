using DG.Tweening;
using System.Collections.Generic;
using UnityEditor.Rendering.LookDev;
using UnityEngine;
using UnityEngine.UI;

public class TEST : MonoBehaviour
{
    public List<Image> fadePanel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < fadePanel.Count; i++) 
        {
            fadePanel[i].DOFade(0f, 0.1f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TESTFunction()
    {
        for (int i = 0; i < fadePanel.Count; i++)
        {
            fadePanel[i].DOFade(1f, 0.1f);
        }
    }
}
