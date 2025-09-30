using UnityEngine;
using NavMeshPlus.Components;
using System;
public class MavMEshRestart : MonoBehaviour
{
    public static MavMEshRestart Instansce {get; private set;}

    private NavMeshSurface _navMeshSurface;

    private void Awake()
    {
        Instansce = this;
        _navMeshSurface = GetComponent<NavMeshSurface>();
        _navMeshSurface.hideEditorLogs = true;
    }

    public void RebecNavMesh()
    {
        _navMeshSurface.BuildNavMesh();
    }
}
