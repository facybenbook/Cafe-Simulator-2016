#pragma strict


function Start () {
	var mousePos = Event.current.mousePosition;
	mousePos.x = Mathf.Clamp(mousePos.x, 300, 1200);
	mousePos.y = Mathf.Clamp(mousePos.y, 150, 800);
	Begin();
}

function Update () {
	
}

function Begin (){
	Cursor.visible = false; 
	Screen.lockCursor = true;
}