using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MixedCamera : MonoBehaviour
{
    public Transform target;
    public float angle;
    public float distance;
    public float focusRadius;
    public float cameraSpeed;
    [Tooltip("When target objects rotation changes camera will also rotates")]	[HideInInspector]
    public Vector3 defaultRotation;
    public Vector3 defaultDistance;
		
   
    public bool fixedCamera = false;

    public bool autoCameraSpeed = false;
 
    public bool stopCamera = false;

    public bool lookAlwaysTarget;
 
    public bool lerpAngle = false;
		
    private Vector3 _lookDistance;
    private Vector3 _focusPoint;
    private Vector3 _lastFocusPoint;
    private float _time = 0;

    private Vector3 _hitNormal;
    private Camera _camera;
    private float _defaultCameraSpeed;
    public float _rotationTime=0;

    public bool canRotate = true;
    public bool followXRotation = true;
    public bool freezeZRotation = false;
    public bool followOnlyYDirection = false;
    public bool stopRotation;
    private void Start()
    {
	    _defaultCameraSpeed = cameraSpeed;
	    var position = target.position;
	    _focusPoint = position;
	    _lastFocusPoint = position;
	  
	    _lookDistance = new Vector3(0,distance*Mathf.Sin(angle*Mathf.Deg2Rad),-1*distance*Mathf.Cos(angle*Mathf.Deg2Rad));
	    transform.position = position + _lookDistance;
	    _camera = GetComponent<Camera>();

    }
    private void OnValidate()
    {
	    if(!lookAlwaysTarget)
		    _lookDistance = new Vector3(0,distance*Mathf.Sin(angle*Mathf.Deg2Rad),-1*distance*Mathf.Cos(angle*Mathf.Deg2Rad));
	    else
	    {
		  
				
		    _lookDistance = new Vector3(0,distance*Mathf.Sin(angle*Mathf.Deg2Rad),-1*distance*Mathf.Cos(angle*Mathf.Deg2Rad));
	    }
	    distance = distance < 0 ? 0 : distance;
    }
	
    private void LateUpdate()
    {
	    if (stopCamera) return;
	    
	    _lookDistance = new Vector3(0,distance*Mathf.Sin(angle*Mathf.Deg2Rad),-1*distance*Mathf.Cos(angle*Mathf.Deg2Rad));
	    UpdateFocusPoint();
	    UpdateTransform();
    }
    private void UpdateFocusPoint()
    {
	    _focusPoint = target.position;
		
	    float distance = Vector3.Distance(_focusPoint, _lastFocusPoint);
	    if ( distance>= focusRadius)
	    {
		    _lastFocusPoint = _focusPoint;
	    }
    }
    private void UpdateTransform()
    {
	    _time = Time.deltaTime;
	    
		 UpdateRotation();
		 if(!stopRotation)
		UpdatePosition();
    }
    
    private void UpdatePosition()
    {
	    if (autoCameraSpeed)
	    {
		    Vector2 isVisible =	_camera.WorldToViewportPoint(target.position);
				
		    if (isVisible.x > 0.75f || isVisible.y > 0.75f || isVisible.x < 0.25f || isVisible.y < 0.25f)
		    {
			    cameraSpeed += Time.deltaTime*1.5f;
		    }
	    }

	    Vector3 lookRotated = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0)*_lookDistance;
	   
	    Vector3 distance = _lastFocusPoint + lookRotated - transform.position+defaultDistance;
	    if (followOnlyYDirection)
	    {
		    distance.x = 0;
		    distance.z = 0;
	    }
	    if (!fixedCamera)
	    {
		    distance = distance * cameraSpeed*Time.deltaTime;
	    }
	    transform.position += distance;
    }
    
    private void UpdateRotation()
    {
			
	    //Vector3 targetRotation = defaultRotation + Vector3.right * (angle+target.rotation.eulerAngles.x) + target.rotation.eulerAngles.y*Vector3.up;
	    Vector3 rotation = defaultRotation + Vector3.right * (angle) + target.rotation.eulerAngles.y*Vector3.up;
	    if (followXRotation)
		    rotation += Vector3.right * target.rotation.eulerAngles.x;
	    Vector3 rotationDistance = rotation - transform.rotation.eulerAngles;
	    if(freezeZRotation)
			rotation.y = transform.rotation.eulerAngles.y;
	    if (rotationDistance.magnitude>1 && canRotate)
	    {
		    _rotationTime = 0;
		    canRotate = false;
	    }
	    else if (rotationDistance.magnitude < 1)
		    canRotate = true;
	    _rotationTime += Time.deltaTime;
	    Vector3 distance = transform.rotation.eulerAngles - rotation;
	    
		transform.rotation = !lerpAngle
		    ? Quaternion.Euler(rotation)
		    : Quaternion.Lerp(transform.rotation, Quaternion.Euler(rotation), Time.deltaTime*cameraSpeed);
	
    }

}
