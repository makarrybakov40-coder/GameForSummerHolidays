using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PathConteiner : MonoBehaviour
{    
    [SerializeField] private List<Path> paths;    

    private void Start()
    {
        for (int i = 0; i < 2; i++) 
        {
            paths.Add(new Path(i, i));
        }

        List<PathPoint> _findedPathPoints;

        
    }

}
