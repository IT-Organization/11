
//资讯内容hover效果
$(document).ready(function(){
	$(".lists").on("mouseover",".informations",function(){
		$(this).children(".detail").stop(false,false);
		$(this).children(".detail").animate({top:'0'},450);
	})
	$(".lists").on("mouseout",".informations",function(){
		$(this).children(".detail").stop(false,false);
		$(this).children(".detail").animate({top:'222px'},450);
	})
})


//导航展开
$(document).ready(function(){
	$(".listTitle").click(function(){
		$(".listTitle").css({'display':'none'});
		$(".listNav").css({'display':'block'});
	})
	$(".listNav").children("button").click(function(){
		$(".listNav").css({'display':'none'});
		$(".listTitle").css({'display':'block'});
	})
})


//瀑布流
$(document).ready(function(){
    var i=0,j,jsonObj;
    var judge=false;
    appendAct();
   $(".loading").click(function(){
        appendAct();
   })
   function appendAct(){
        console.log(1);
        i++;
        $.ajax({
            type:"GET",
            url:"ajax/news.txt",
            data:{pageNumber:i,pageSize:4},
            //发送给后台，请求第几页信息，每页信息多大
            //dataType:"json",
            async:true,
            success:function(dat){
                console.log(dat);
                jsonObj=JSON.parse(dat);
                console.log(jsonObj);
                //将json字符串解析为json对象
                for(j=0;j<jsonObj.length;j++){
                    var infor = $("<div>").addClass("informations").attr("id", jsonObj[j].id).appendTo($(".lists"));
                    var detail = $("<div>").addClass("detail").appendTo(infor);
                    var detailLeft = $("<div>").addClass("detailLeft").appendTo(detail);
                    var icon = $("<img>").attr("src",jsonObj[j].icon).appendTo(detailLeft);
                    var writer = $("<p>").text(jsonObj[j].id).appendTo(detailLeft);
                    var detailRight = $("<div>").addClass("detailRight").appendTo(detail);
                    var title = $("<h1>").text(jsonObj[j].title).appendTo(detailRight);
                    var read = $("<p>").text(jsonObj[j].read).appendTo(detailRight);
                    var time = $("<p>").text(jsonObj[j].time).appendTo(detailRight);
                    var hide = $("<div>").addClass("hide").appendTo(detail);
                    var content = $("<p>").text(jsonObj[j].content).appendTo(hide);
                    $(".informations").css({"background":"url(" + jsonObj[j].background + ") no-repeat"});

                    if(j%2==0){
                        infor.addClass("left")
                    }
                    if(j%2==1){
                        infor.addClass("right");
                    }
                }
            },
            //根据后台发来的数据动态添加元素
            error:function(xhr){
            $(".loading").css({
                "background":"none",
                "cursor":"auto"
            })
            .text("已经到底了");
            }
        })
   }
   //资讯点击事件跳转链接
   $(".lists").on("click",".detail",function(){
        var j = $(this).parent(".informations").index();
        window.open("new content.html" + "?" + "id=" + $(this).parent(".informations").attr("id"));
    })
})

