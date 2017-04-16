$(function(){
	$(".main-buy-now").mouseover(function(){
		//if(!$(".main-buy-vip").is(":animated"))
		$(".main-buy-vip img").stop(false,false).animate({width:23},300,vipoutNext);
	})
	function vipoutNext(){
		//$(".main-buy-vip p").css({"display":"block"});
		$(".main-buy-vip p").stop(false,false).animate({width:176},400);
	}
	/*$(".main-buy-now").mouseout(function(){
		$(".main-buy-vip img").stop().css({"width":0});
		$(".main-buy-vip p").stop().css({"width":0});
		//$(".main-buy-vip p").stop(false,true).animate({width:0},400,vipinNext);
	})*/
	//VIP优惠滑出效果
/*	$(".activity-mouseover-img").click(function(){
		window.location="http://www.ouc.edu.cn";
		//注意此处，一定要把网址换掉！！
	})*/
	$(window).scroll(function(){
        if($(document).scrollTop()==0)
        {
            $(".return-top").animate({opacity:0},300);
            return false;
        }
         $(".return-top").css({
            "opacity":1,
            "position":"fixed",
            "right":($("body").width()-$(".container").width())/2-$(".return-top").width()-2,
            "top":$(window).height()-$(".return-top").height()-45
            
        });
         //if($("body").height()-$(".return-top").offset().top<193)
         if($("body").height()-$(".footer").innerHeight()-$(".return-top").offset().top-$(".return-top").height()<0)
         {
            $(".return-top").css({
                "position":"absolute",
                "top":$("body").height()-$(".footer").innerHeight()-$(".return-top").height()
            });
         }
          else{
            $(".return-top").css({
                "position":"fixed",
                "top":$(window).height()-$(".return-top").height()-45
            });
         }
    })

	var actChange;
	var actchangeNow;
	$(".activity-more").hover(actOn,actOut);
	function actOn(){
		$(this).find(".activity-mouseover-img").stop(false,true).css({
			"visibility":"visible"
		});
		actChange=$(".activity-more").index(this);
		//$(this).find("a")
		actchangeNow=$(".activity-more a:eq("+actChange+")");
		actchangeNow
		.css({"visibility":"visible"})
		.animate({bottom:0},200);
		$(".activity-more a").not(actchangeNow)
		.css({
			"visibility":"hidden",
			"bottom":-40
		});
	}
	function actOut(){
		$(this).find(".activity-mouseover-img").stop(false,true)
		.css({
			"visibility":"hidden"
		});
		//$(this).find("a")
		$(".activity-more a")
		.css({
			"visibility":"hidden",
			"bottom":-40
		});
	}
	//相关活动 相关文章效果
})