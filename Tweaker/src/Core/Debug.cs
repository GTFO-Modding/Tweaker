using System;
using Dex.Tweaker.Util;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;

namespace Dex.Tweaker.Core
{
    class Debug
    {
        public static void GenerateNavMesh()
        {
            if (!ConfigManager.UseDebugNavMesh.Value) return;

            var debugMesh = new Mesh();
            debugMesh.name = "DebugNavMesh";
            var triangulation = UnityEngine.AI.NavMesh.CalculateTriangulation();
            debugMesh.indexFormat = Mathf.Max(triangulation.vertices.Length, triangulation.indices.Length) >= 65534 ? IndexFormat.UInt32 : IndexFormat.UInt16;
            debugMesh.vertices = triangulation.vertices;
            debugMesh.triangles = triangulation.indices;


            var output = "Debug Nav Mesh";
            output = $"{output}\n\tvertices:{triangulation.vertices.Length}";
            output = $"{output}\n\ttriangles:{triangulation.indices.Length}";

            if (VisualNavMesh == null)
            {
                VisualNavMesh = new GameObject();
                GameObject.DontDestroyOnLoad(VisualNavMesh);
                var meshFilter = VisualNavMesh.AddComponent<MeshFilter>();
                var meshRenderer = VisualNavMesh.AddComponent<MeshRenderer>();
                meshFilter.mesh = debugMesh;
                meshRenderer.material = new Material(Shader.Find("Standard"));
                output = $"{output}\n\tMesh created";
            }
            else
            {
                var meshFilter = VisualNavMesh.GetComponent<MeshFilter>();
                meshFilter.mesh = debugMesh;
                output = $"{output}\n\tMesh already exists! updated information for it";
            }

            VisualNavMesh.SetActive(false);
            Log.Debug(output);
        }
        public static GameObject VisualNavMesh { get; private set; }
    }
}
