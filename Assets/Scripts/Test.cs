using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class Test : MonoBehaviour
{
    private LaserBeamRenderer _laserBeamRenderer;
    [SerializeField]
    private float _beamLength;
    [SerializeField]
    private float _beamWidth;
    private void Awake()
    {
        _laserBeamRenderer = new LaserBeamRenderer(GetComponent<MeshFilter>());
        _laserBeamRenderer.RenderLaserBeam(_beamLength, _beamWidth);

    }
    private void Update()
    {
        _laserBeamRenderer.RenderLaserBeam(_beamLength, _beamWidth);
    }
}
