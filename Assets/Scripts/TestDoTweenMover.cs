using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;

public class TestDoTweenMover : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DG.Tweening.Sequence mySequence = DOTween.Sequence();

        mySequence.Append(transform.DOMove(new Vector3(0, 2, 0), 1f))
        .Append(transform.DOMove(new Vector3(5, 0, 0), 1f))
        .Append(transform.DOMove(new Vector3(-5, 0, 0), 1f))
        .SetLoops(-1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
