

//热文/短趣切换
$(document).ready(function(){//加载整个DOM元素
	$(".hot").hover(function(){
		$(".content").eq(1).addClass("displayNone");
		$(".content").eq(0).removeClass("displayNone");
		$(".hot").addClass("hover");
		$(".interesting").removeClass("hover");
	});
	$(".interesting").hover(function(){
		$(".content").eq(0).addClass("displayNone");
		$(".content").eq(1).removeClass("displayNone");
		$(".interesting").addClass("hover");
		$(".hot").removeClass("hover");
	});
});

//短趣弹窗
$(document).ready(function(){
	$("#content").children(".issay").children("h1").click(function(){
		$(".shortA").css({"display":"block","position":"fixed"});
	});
	$(".close").mouseover(function(){
		$(".close").css({"background":"url(images/close-orange.png)"});
	})
	$(".close").mouseout(function(){
		$(".close").css({"background":"url(images/close.png)"});
	})
	$(".close").click(function(){
		$(".shortA").css({"display":"none"});
	})
})


//轮播按钮hover
$(document).ready(function(){
	//左切换按钮
	$(".turnLeft").mouseover(function(){
		$(".turnLeft").css({"background":"url(images/arrow-left-orange.png)"});
	});
	$(".turnLeft").mouseout(function(){
		$(".turnLeft").css({"background":"url(images/arrow-left-black.png)"});
	});
	//右切换按钮
	$(".turnRight").mouseover(function(){
		$(".turnRight").css({"background":"url(images/arrow-right-orange.png)"});
	});
	$(".turnRight").mouseout(function(){
		$(".turnRight").css({"background":"url(images/arrow-right-black.png)"});
	});
});


//轮播效果
$(document).ready(function(){
	//初始化
	$(".turnImg").children("li").eq(0).css({"left":"0px"});
	$(".turnImg").children("li").eq(1).css({"left":"1000px"});
	$(".turnImg").children("li").eq(2).css({"left":"2000px"});
	$(".turnImg").children("li").eq(3).css({"left":"3000px"});
	//轮播事件-右
	$(".turnRight").click(function(){
		//防止连续多按页面崩溃
		$(".turnImg").children("li").stop(true,true);
		$(".turnImg").children("li").eq(0).animate({left:'-1000px'},350);
		$(".turnImg").children("li").eq(1).animate({left:'0px'},350);
		$(".turnImg").children("li").eq(2).animate({left:'1000px'},350);
		$(".turnImg").children("li").eq(3).animate({left:'2000px'},350,function(){//调换li标签顺序
			$(".turnImg").children("li").eq(3).after($(".turnImg").children("li").eq(0));
			$(".turnImg").children("li").eq(3).css({"left":"3000px"});
		});
	});

	//轮播事件-左
	$(".turnLeft").click(function(){
		//防止连续多按页面崩溃
		$(".turnImg").children("li").stop(true,true);
		$(".turnImg").children("li").eq(3).css({"left":"-1000px"});
		$(".turnImg").children("li").eq(0).animate({left:'1000px'},350);
		$(".turnImg").children("li").eq(1).animate({left:'2000px'},350);
		$(".turnImg").children("li").eq(2).animate({left:'3000px'},350);
		$(".turnImg").children("li").eq(3).animate({left:'0px'},350,function(){//调换li标签顺序
			$(".turnImg").children("li").eq(0).before($(".turnImg").children("li").eq(3));
		});
	});
})

$(document).ready(function(){
	$(".share").mouseover(function(){
		$(this).css({"background":"url(images/share-orange.png) no-repeat"});
	});
	$(".share").mouseout(function(){
		$(this).css({"background":"url(images/share-gray.png) no-repeat"});
	});
	$(".collect").mouseover(function(){
		$(this).css({"background":"url(images/collect-orange.png) no-repeat"});
	});
	$(".collect").mouseout(function(){
		$(this).css({"background":"url(images/collect-gray.png) no-repeat"});
	});
})



//瀑布流
   var i=1,j,jsonObj;
   var judge=false;
   var $mainDiv = $(".newsList");  
   var html = '';  
   $(".alink").click(function(){
        i++;
        $.ajax({
                type:"GET",
                url:"try.txt",
                data:{pageNumber:i,pageSize:4},
                //发送给后台，请求第几页信息，每页信息多大
                //dataType:"json",
                async:true,
                success:function(dat){
                    console.log(dat);
                    jsonObj=JSON.parse(dat);
                 //将json字符串解析为json对象
        		for (var j = 0; j < jsonObj.length; j++) {  
           			html += '<div class="news shadow">';  
            		html += '<div class="newsImage">' + '<a href="">' + '<img src=' + '"' + json[j].imgSrc + '">' + '</a>' + '</div>';  
            		html += '<div class="newsWriter">' + '<a href="">' + '<div class="newsLeft">' + '<img src=' + '"' + json[j].icon + '">' + '<p>' + json[j].id + '</p>' + '</div>' + '</a>' + '<a href="">' + '<h1>' + json[j].title + '</h1>' + '</a>' + '<div class="newsReading">' + '<button class="share"></button><button class="collect"></button>' + '<p>' + json[j].read + '</p>' + '<p>' + json[j].time + '</p>' + '</div>';  
            		html += '</div>';  
        		}  
        $mainDiv.append(html);
                },
                //根据后台发来的数据动态添加元素
                error:function(xhr){
                alert("发生错误"+xhr);
                }
        })

   })
/*endlesspage.js*/  
// var gPageSize = 5;  
// var i = 1; //设置当前页数，全局变量  
// $(function () {  
//     //根据页数读取数据
//     function getData(pagenumber) {  
//         i++; //页码自动增加，保证下次调用时为新的一页。  
//         $.get("/ajax/news.JSON", { pagesize: gPageSize, pagenumber: pagenumber }, function (data) {  
//             if (data.length > 0) {  
//                 var jsonObj = JSON.parse(data);  
//                 insertDiv(jsonObj);  
//             }  
//         });  
//         $.ajax({  
//             type: "post",  
//             url: "/ajax/news.JSON",  
//             data: { pagesize: gPageSize, pagenumber: pagenumber },  
//             dataType: "json",  
//             success: function (data) {  
//                 $(".loading").hide();  
//                 if (data.length > 0) {  
//                     var jsonObj = JSON.parse(data);  
//                     insertDiv(jsonObj);  
//                 }  
//             },  
//             beforeSend: function () {  
//                 $(".loading").show();  
//             },  
//             error: function () {  
//                 $(".loading").hide();  
//             }  
//         });  
//     }  
//     //初始化加载第一页数据  
//     getData(1);  
  
    //生成数据html,append到div中  
    // function insertDiv(json) {  
    //     var $mainDiv = $(".newsList");  
    //     var html = '';  
    //     for (var i = 0; i < json.length; i++) {  
    //         html += '<div class="news shadow">';  
    //         html += '<div class="newsImage">' + '<a href="">' + '<img src=' + '"' + json[i].imgSrc + '">' + '</a>' + '</div>';  
    //         html += '<div class="newsWriter">' + '<a href="">' + '<div class="newsLeft">' + '<img src=' + '"' + json[i].icon + '">' + '<p>' + id + '</p>' + '</div>' + '</a>' + '<a href="">' + '<h1>' + title + '</h1>' + '</a>' + '<div class="newsReading">' + '<button class="share"></button><button class="collect"></button>' + '<p>' + read + '</p>' + '<p>' + time + '</p>' + '</div>';  
    //         html += '</div>';  
    //     }  
    //     $mainDiv.append(html);  
    // }  
  
    // //==============核心代码=============  
    // var winH = $(window).height(); //页面可视区域高度   
  
    // var scrollHandler = function () {  
    //     var pageH = $(document.body).height();  
    //     var scrollT = $(window).scrollTop(); //滚动条top   
    //     var aa = (pageH - winH - scrollT) / winH;  
    //     if (aa < 0.02) {//0.02是个参数  
    //         if (i % 5 === 0) {//每5页做一次停顿！  
    //             getData(i);  
    //             $(window).unbind('scroll');  
    //             $("#btn_Page").show();  
    //         } else {  
    //             getData(i);  
    //             $("#btn_Page").hide();  
    //         }  
    //     }  
    // }  
    // //定义鼠标滚动事件  
    // $(window).scroll(scrollHandler);  
    // //==============核心代码=============  
  
    // //继续加载按钮事件  
    // $("#btn_Page").click(function () {  
    //     getData(i);  
    //     $(window).scroll(scrollHandler);  
    // });  
// });  