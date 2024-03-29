#pragma strict
//Written by Scott Kovacs via UnityAnswers.com; Oct 5th 2010
//2DCameraFollow - Platformer Script

var dampTime : float = 0.3; //offset from the viewport center to fix damping
private var velocity = Vector3.zero;
var target : Transform;

function FixedUpdate() {
    if(target) {
        var point : Vector3 = camera.WorldToViewportPoint(target.position);
        var delta : Vector3 = target.position - camera.ViewportToWorldPoint(Vector3(0.45, 0.25, point.z));
        var destination : Vector3 = transform.position + delta;

       // Set this to the Y position you want the camera locked to
        //destination.y = 22.5f; 

        transform.position = Vector3.SmoothDamp(transform.position, destination, velocity, dampTime);
    }
}