using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class PathConteiner : MonoBehaviour
{
    [SerializeField] private List<Path> _path;
    [SerializeField] private int i;
    private Dictionary<int, Path> paths = new Dictionary<int, Path>();


    private void Start()
    {
        FindComponentsInChildren(_path[i].PathPoints);
    }
    public void FindComponentsInChildren<T>(List<T> targetList) where T : Component
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);
            for (int j = 0; j < child.childCount; j++)
            {

            }
            int index = child.GetSiblingIndex();

            Debug.Log($"[{i}] {child.name} (SiblingIndex: {index})");
        }

        targetList.Clear();

        T[] childComponents = GetComponentsInChildren<T>();
        targetList.AddRange(childComponents);

        Debug.Log($"Найдено {targetList.Count} компонентов типа {typeof(T).Name} в потомках");
    }



    public void SetPathForPlayer(Player player)
    {
         player.SetPath(paths[player.PlayerID]);
    }
}
