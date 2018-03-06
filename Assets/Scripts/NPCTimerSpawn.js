#pragma strict

 var Enemy:Transform;
 private var Timer:float;
 
 function Awake() {
     Timer = Time.time + 15;
 }
 
 function Update() {
     if (Timer < Time.time) { 
         Instantiate(Enemy, transform.position, transform.rotation); //This spawns the emeny
         Timer = Time.time + 15; //This sets the timer 3 seconds into the future
     }
 }