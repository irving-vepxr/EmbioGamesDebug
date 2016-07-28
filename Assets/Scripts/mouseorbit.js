#if UNITY_EDITOR

var target : Transform;
var distance = 5.0;
 
var xSpeed = 250.0;
var ySpeed = 120.0;
 
var yMinLimit = -20;
var yMaxLimit = 80;
 
var xMinLimit = -360;
var xMaxLimit = 360;
 
var yRatio = 0.03;
var xRatio = 0.03;
 
var maxdistance = 20;
var mindistance = 2;
 
var zoomRate = 20;
 
var translateSpeed = 0.1f;
var translateMinY = -5f;
var translateMaxY = 5f;
var translateMinX = -5f;
var translateMaxX = 5f;

var target2 : Transform;
var target2YSpeed = 75f;
var target2YAngleMin = -360;
var target2YAngleMax = 360;
var target2YUseShiftToRotate = true;
 
private var x = 0.0;
private var y = 0.0;
 
private var translation = Vector3.zero;
 
@script AddComponentMenu("Camera-Control/Mouse Orbit")
 
function Start () 
{
	var angles = transform.eulerAngles;
	x = angles.y;
	y = angles.x;
	 
	// Make the rigid body not change rotation
	if (GetComponent.<Rigidbody>())
		GetComponent.<Rigidbody>().freezeRotation = true;
}
 
function LateUpdate () 
{
	var shiftPressed = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);

	if (target) 
	{
		if (Input.GetMouseButton(0) && !(target2YUseShiftToRotate && shiftPressed))
		{
			x += Input.GetAxis("Mouse X") * xSpeed * xRatio;
			y -= Input.GetAxis("Mouse Y") * ySpeed * yRatio;
			var test = 0;
			test = y;
		}
		distance += -(Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime) * zoomRate * Mathf.Abs(distance);
		
		if (distance < 0.5)
		{
			distance = 1.0;
		}
		
		if (distance > maxdistance)
		{
			distance = maxdistance;
		}
		
		if (distance < mindistance)
		{
			distance = mindistance;
		}
		
		y = ClampAngle(y, yMinLimit, yMaxLimit);
		x = ClampAngle(x, xMinLimit, xMaxLimit);
		
		//Debug.Log("y: "+y+" test: "+test);
		if (Input.GetMouseButton(2)) 
		{
			translation.x = Mathf.Clamp(translation.x - Input.GetAxis("Mouse X") * translateSpeed, translateMinX, translateMaxX);
			translation.y = Mathf.Clamp(translation.y - Input.GetAxis("Mouse Y") * translateSpeed, translateMinY, translateMaxY);
		}
		
		var rotation = Quaternion.Euler(y, x, 0);
		var position = rotation * Vector3(0.0, 0.0, -distance) + target.position + rotation*translation;
		//Debug.Log("Distance: "+distance);
		transform.rotation = rotation;
		transform.position = position;
	}
	
	if (target2)
	{
		var rotateTarget2AtY = target2YUseShiftToRotate ? Input.GetMouseButton(0) && shiftPressed : Input.GetMouseButton(1);
		if (rotateTarget2AtY)
		{
			var targetYAngle = target2.transform.eulerAngles.y;
			targetYAngle = ClampAngle(targetYAngle - Input.GetAxis("Mouse X") * target2YSpeed, target2YAngleMin, target2YAngleMax);
			target2.transform.rotation = Quaternion.Euler(0f, targetYAngle, 0f);
		}
	}
}
 
static function ClampAngle (angle : float, min : float, max : float) 
{
	while (angle < -360) angle += 360;
	while (angle > 360) angle -= 360;
	return Mathf.Clamp (angle, min, max);
}

#endif