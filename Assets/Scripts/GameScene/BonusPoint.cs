using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;
using System.Collections;

public class BonusPoint : Point
{
    [SerializeField] private int _scene;
    [SerializeField] private SceneChanger _sceneChanger;
    public override void PointAction()
    {
        _sceneChanger.ChangeScene(_scene);
    }
}
