$(function(){
	$(".operate-click").click(function(){
		$(".operate-click-2").css({"display":"block","opacity":0.7})
		.animate({bottom:"+=30px"},300,afterZan);
	})
	function afterZan(){
		$(".operate-click-2").css({
			"display":"none",
			"bottom":"-=30px",
			"opacity":1
		});
		$(".operate-click").css({
			"backgroundPosition":"0px -1px"
		});
	}
	//点赞飞起效果
	$(".click-to-close").css({
		"width":$(document).width(),
		"height":"2000px",
		"zIndex":-5
	});
	$(".operate-share").click(function(){
		$(".wechat-weibo")
		.css({"display":"block","opacity":0})
		.stop()
		.animate({opacity:1},200);
		$(".click-to-close").css({
			"zIndex":3
		});
	})
	$(".click-to-close").click(function(){
		$(".wechat-weibo")
		.stop()
		.animate({opacity:0},200);
		$(".click-to-close").css({
			"zIndex":-5
		});
	})
	$(".weibo").click(function(){
		$(".wechat-2d").css({
			"display":"none",
			"top":"60px",
		});
		$(".weibo-2d").css({
			"display":"block",
		})
		.stop()
		.animate({"top":"50px"},100);
	})
	$(".wechat").click(function(){
		$(".weibo-2d").css({
			"display":"none",
			"top":"60px",
		});
		$(".wechat-2d").css({
			"display":"block",
		})
		.stop()
		.animate({"top":"50px"},100);
	})


/*	$(".share-first").hover(appendShare,removeShare);
	function appendShare(){
		$(".wechat-weibo")
		.css({"display":"block","opacity":0})
		.stop()
		.animate({opacity:1},200);
	}
	function removeShare(){
		$(".wechat-weibo")
		.stop()
		.animate({opacity:0},200);
	}
	$(".weibo").hover(aWeibo2d,rWeibo2d);
	function aWeibo2d(){
		$(".weibo-2d").css({
			"display":"block",
		})
		.stop()
		.animate({"top":"55px"});
		$(".weibo").css({"backgroundPosition":"0 0"});
	}
	function rWeibo2d(){
		$(".weibo-2d").css({
			"display":"none",
			"top":"65px",
		});
		$(".weibo").css({"backgroundPosition":"0 -35px"});
	}
	$(".wechat").hover(aWechat2d,rWechat2d);
	function aWechat2d(){
		$(".wechat-2d").css({
			"display":"block",
		})
		.stop()
		.animate({"top":"55px"});
		$(".wechat").css({"backgroundPosition":"-65px 0"});
	}
	function rWechat2d(){
		$(".wechat-2d").css({
			"display":"none",
			"top":"65px",
		});
		$(".wechat").css({"backgroundPosition":"-65px -35px"});
	}*/
	//二维码效果

	/*$(".activity-mouseover-img").click(function(){
		window.location="http://www.ouc.edu.cn";
		//注意此处，一定要把网址换掉！！
	})*/
	var actChange;
	var actchangeNow;
	$(".activity-more").hover(actOn,actOut);
	function actOn(){
		$(this).find(".activity-mouseover-img").css({
			"visibility":"visible",
			"opacity":0
		})
		.stop(false,true).animate({opacity:1},100);
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
		/*.css({
			"visibility":"hidden"
		});*/
		.animate({opacity:0},100);
		//$(this).find("a")
		$(".activity-more a")
		.css({
			"visibility":"hidden",
			"bottom":-40
		});
	}
	//相关活动 相关文章效果
})