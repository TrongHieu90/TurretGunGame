using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reticle_Mouse_Input : MonoBehaviour {

    [SerializeField] Camera _camera;

    private Vector3 _reticlePos;
    public Vector3 ReticlePos { get { return _reticlePos; } }
    private Vector3 _reticleNormal;
    public Vector3 ReticleNormal { get { return _reticleNormal; } }

    public Transform _reticleTransform;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(_camera)
        {
            HandleInputs();
        }
        if(_reticleTransform)
        {
            HandleReticle();
        }
		
	}

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(_reticlePos, 0.5f);
    }

    protected virtual void HandleInputs()
    {
        Ray screenRay = _camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(screenRay, out hit))
        {
            _reticlePos = hit.point;
            _reticleNormal = hit.normal;
        }
    }

    protected virtual void HandleReticle()
    {
        _reticleTransform.position = _reticlePos;
    }
}
