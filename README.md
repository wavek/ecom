# ecom



https://codepen.io/sumanengbd/pen/vYBemNY
https://codepen.io/ivanlhz/pen/ExxZEYB
https://codepen.io/Okba-Design/pen/ExPpRLB
https://codepen.io/Mohaimenul/pen/wvozwpy
https://codepen.io/jaideejung007/pen/poreGOE




<!DOCTYPE html>
<html>
<head>
<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
<style>

body{
margin:0;
}

#navbar_div{
  width:100%;
  height:1000px;
  background-color:red;
  z-index:99;
}

#center{
	display: flex;
    justify-content: center;
}
.div_common{
  width:30%;
  height:500px;
  float:left;
  margin:0 1%;
  padding:1%;
}
#divA{

    z-index:-7;
    position: relative;
    top: 600px;
    transition:0.5s;
}
#divB{

    transform: scale(5);
    transition:0.5s;
    z-index:-5;
   
}
#divC{

    z-index:-7;
    position: relative;
    top: -600px;
    transition:0.5s;
}
#footer_div{
  width:100%;
  height:500px;
}

</style>
</head>
<body>

<div id="navbar_div">
	DADSAFDSAGFSAFSAFSAFSADAWS
</div>
<div id="divB_clear_div" style="margin-top:150px;"></div>
<div id="center">
	<div class="div_common" id="divA">
    	<img src="https://cdn.opstatics.com/store/20170907/assets/images/events/2021/03/9/2080a/camera-phone1-2080a-pc-2258aa.png.webp"  width="100%" height="100%" >
    </div>
    <div class="div_common" id="divB">
   	 <img src="https://cdn.opstatics.com/store/20170907/assets/images/events/2021/03/9/2080a/camera-phone2-2080a-pc-b4e4c6.jpg.webp"  width="100%" height="100%" >
    </div>
	<div class="div_common" id="divC">
    	<img src="https://cdn.opstatics.com/store/20170907/assets/images/events/2021/03/9/2080a/camera-phone3-2080a-pc-832bac.png.webp"  width="100%" height="100%" >
    </div>

</div>
<div  style="margin-top:30%;"></div>
<div id="section_div" style="width:100%;transform:scale(1.5);z-index:-15;">
	<img  id="section_div_img"  src="https://cdn.opstatics.com/store/20170907/assets/images/events/2021/03/9/2080a/camera-shot1-2080a-pc-1389cd.jpg.webp"  width="100%" height="100%" >
    <img style="margin-top:-50%;opacity:0;transition:1s;"  id="section_div_img2"  src="https://cdn.opstatics.com/store/20170907/assets/images/events/2021/03/9/2080a/camera-9zoom-2080a_pc-1-30db77.jpg.webp"  width="100%" height="100%" >
</div>
<div id="section_clear_div" style="margin-top:15%;"></div>
<div id="footer_div" style="z-index:15;height:1000px;">
	DADSAFDSAGFSAFSAFSAFSADAWS
</div>

<script>

$(window).scroll(function() {
   var hT = $('#section_clear_div').offset().top,
       hH = $('#section_clear_div').outerHeight(),
       wH = $(window).height(),
       wS = $(this).scrollTop();
    console.log((hT-wH) , wS);
   if (wS > (hT+hH-wH)){
     document.getElementById("section_div").style.position="fixed";
     document.getElementById("section_div").style.bottom="0%";

   }
   else{
    
   }
});


$(window).scroll(function() {
   var hT = $('#divB_clear_div').offset().top,
       hH = $('#divB_clear_div').outerHeight(),
       wH = $(window).height(),
       wS = $(this).scrollTop();
    console.log((hT-wH) , wS);
   if (wS > (hT+hH-wH)){
     isDivB=true;
   }
   else{
    isDivB=false;
   }
});
var isDivB=false;
var lastScrollValue=650;
$(window).scroll(function () {
	console.log("scrolling"+document.documentElement.scrollTop);
    var pageScrollValue=document.documentElement.scrollTop;
	//if(pageScrollValue>550)
    if(isDivB)
	{
		 var divB = document.getElementById("divB");
         var divBScaleValue = new WebKitCSSMatrix(window.getComputedStyle(divB).webkitTransform);
         
         //divB.style.transform='scale('+1+')';
		//100-580
    	 if(pageScrollValue>=850)
         {
         	divB.style.transform="scale(1)";
            divA.style.top="0px";
            divC.style.top="0px";
         }else if(pageScrollValue>=825)
         {
         	divB.style.transform="scale(1.25)";
            divA.style.top="50px";
            divC.style.top="-50px";
         }
         else if(pageScrollValue>=800)
         {
         	divB.style.transform="scale(1.5)";
            divA.style.top="100px";
            divC.style.top="-100px";
         }
         else if(pageScrollValue>=775)
         {
         	divB.style.transform="scale(1.75)";
            divA.style.top="150px";
            divC.style.top="-150px";
         }
         else if(pageScrollValue>=750)
         {
         	divB.style.transform="scale(2)";
            divA.style.top="200px";
            divC.style.top="-200px";
         }else if(pageScrollValue>=725)
         {
         	divB.style.transform="scale(2.25)";
            divA.style.top="250px";
            divC.style.top="-250px";
         }else if(pageScrollValue>=700)
         {
         	divB.style.transform="scale(2.5)";
            divA.style.top="300px";
            divC.style.top="-300px";
         }else if(pageScrollValue>=675)
         {
         	divB.style.transform="scale(2.75)";
            divA.style.top="350px";
            divC.style.top="-350px";
         }else if(pageScrollValue>=650)
         {
         	divB.style.transform="scale(3)";
            divA.style.top="400px";
            divC.style.top="-400px";
         }else if(pageScrollValue>=625)
         {
         	divB.style.transform="scale(3.5)";
            divA.style.top="450px";
            divC.style.top="-450px";
         }else if(pageScrollValue>=600)
         {
         	divB.style.transform="scale(4)";
            divA.style.top="500px";
            divC.style.top="-500px";
         }else if(pageScrollValue>=575)
         {
         	divB.style.transform="scale(4.5)";
            divA.style.top="550px";
            divC.style.top="-550px";
         }else if(pageScrollValue>=550)
         {
         	divB.style.transform="scale(5)";
            divA.style.top="600px";
            divC.style.top="-600px";
         }
         
         
         
         if(pageScrollValue<1800){
         document.getElementById("section_div").style.position="relative";
     document.getElementById("section_div").style.bottom="0%";
     document.getElementById("section_div_img2").style.opacity=0;
         }
         
         if(pageScrollValue>2000){
         document.getElementById("section_div_img2").style.opacity=1;
         console.log("sdgfsgdsgdsgdsfgdsfdsfds");
         }
      
	}

});

</script>



</body>
</html>


