#pragma strict

function Start () {

}

var startTime: float;
var startPos: Vector2;
var couldBeSwipe: boolean;
var comfortZone: float;
var minSwipeDist: float;
var maxSwipeTime: float;
 
 
function Update() {
    if (Input.touchCount > 0) {
        var touch = Input.touches[0];
       
        switch (touch.phase) {
            case TouchPhase.Began:
                couldBeSwipe = true;
                startPos = touch.position;
                startTime = Time.time;
                break;
           
            case TouchPhase.Moved:
                if (Mathf.Abs(touch.position.y - startPos.y) > comfortZone) {
                    couldBeSwipe = false;
                }
                break;
           
            case TouchPhase.Stationary:
                couldBeSwipe = false;
                break;
           
            case TouchPhase.Ended:
                var swipeTime = Time.time - startTime;
                var swipeDist = (touch.position - startPos).magnitude;
               
                if (couldBeSwipe && (swipeTime < maxSwipeTime) && (swipeDist > minSwipeDist)) {
                    // It's a swiiiiiiiiiiiipe!
                    var swipeDirection = Mathf.Sign(touch.position.y - startPos.y);
                   
                    // Do something here in reaction to the swipe.
                    GUI.Label(Rect(250,250 ,250 ,250), "ALLO");
                    
                }
                break;
        }
    }
}