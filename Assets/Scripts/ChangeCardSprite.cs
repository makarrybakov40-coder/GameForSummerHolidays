using System.Collections.Generic;
using UnityEngine;

public class ChangeCardSprite : MonoBehaviour
{
    [SerializeField] private List<GameObject> CardFace;
    [SerializeField] private List<GameObject> CardBack;
    void Start()
    {
        ChangeSpriteToSmile();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeSpriteToSmile()
    {
        for (int i = 0; i < CardFace.Count; i++)
        {
            CardFace[i].SetActive(true);
            CardBack[i].SetActive(false);
        }
    }
    public void ChangeSpriteToOriginal()
    {
        for (int i = 0; i < CardFace.Count; i++)
        {
            CardFace[i].SetActive(false);
            CardBack[i].SetActive(true);
        }
    }
}
