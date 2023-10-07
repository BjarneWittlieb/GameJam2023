using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.AI.Navigation;

public class NavMeshUpdater : MonoBehaviour
{
    NavMeshSurface[] _surfaces;

    private void Awake()
    {
        _surfaces = GetComponents<NavMeshSurface>();
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var surface in _surfaces)
        {
            if (surface.navMeshData != null)
            {
                surface.UpdateNavMesh(surface.navMeshData);
            }
            else
            {
                surface.BuildNavMesh();
            }
        }
    }
}
