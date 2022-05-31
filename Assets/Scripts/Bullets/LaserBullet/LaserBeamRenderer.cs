using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBeamRenderer
{
    private MeshFilter _laserMeshFilter;
    private Mesh _laserBeamMesh;
    public LaserBeamRenderer(MeshFilter laserMeshFilter)
    {
        _laserMeshFilter = laserMeshFilter;
        _laserBeamMesh = laserMeshFilter.mesh;
    }
    public void RenderLaserBeam(float beamLength, float beamWidth)
    {
        _laserBeamMesh.Clear();
        Vector3[] vertices = new Vector3[4]
        {
             new Vector3(beamWidth - 0.5f, 0f, 0),
             new Vector3(-beamWidth + 0.5f, 0f, 0),
             new Vector3(beamWidth -0.5f, beamLength, 0),
             new Vector3(-beamWidth + 0.5f, beamLength, 0)
        };
        Vector3[] normals = new Vector3[4]
        {
            -Vector3.forward,
            -Vector3.forward,
            -Vector3.forward,
            -Vector3.forward
        };
        Vector2[] uv = new Vector2[4]
        {
            new Vector2(0, 0),
            new Vector2(1, 0),
            new Vector2(0, 1),
            new Vector2(1, 1)
        };
        int[] triangles = { 0, 1, 2, 2, 1, 3 };
        _laserBeamMesh.vertices = vertices;
        _laserBeamMesh.uv = uv;
        _laserBeamMesh.normals = normals;
        _laserBeamMesh.triangles = triangles;
    }
}
