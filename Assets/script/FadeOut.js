#pragma strict
 
 var color : Color;
 
 function Start(){
     
     color = Color.white;
     guiText.material.color.a = 0;
     
 }
 
 function Update(){
 
     Fade();
 }
  
 function Fade(){
 
     while (guiText.material.color.a < 1){
         guiText.material.color.a += 0.1 * Time.deltaTime * 0.05;
         print(guiText.material.color.a);
     yield;
     }
 }
