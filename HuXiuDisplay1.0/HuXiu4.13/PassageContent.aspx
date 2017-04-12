<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PassageContent.aspx.cs" Inherits="PassageContent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta charset="UTF-8">
	<title>Document</title>
	<link rel="stylesheet" href="css/news content.css">
	<link rel="stylesheet" type="text/css" href="css/topnav.css">
	<link rel="stylesheet" href="css/footer.css">
	<script src="js/jquery.js"></script>
	<script type="text/javascript" src="js/topnav.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="click-to-close"></div>
	<!-- 这个只是用来关闭分享二维码的 -->
	<div class="top"><!--顶部导航栏-->
		<div class="topNav"><!--顶部导航栏居中部分-->
			<div class="informationNav"><!--资讯导航栏-->
				<div class="secondNav displaynone"><!--资讯二级菜单-->
					<ul>
						<li><a href="">电商消费</a></li>
						<li><a href="">娱乐淘金</a></li>
						<li><a href="">电商消费</a></li>
						<li><a href="">娱乐淘金</a></li>
						<li><a href="">电商消费</a></li>
						<li><a href="">娱乐淘金</a></li>
						<li><a href="">电商消费</a></li>
						<li><a href="">娱乐淘金</a></li>
					</ul>
				</div>
				<h1 id="information">资讯</h1>
			</div>
			<div class="logo"><!--虎嗅logo-->
				<a href="index.html">
					<img src="images/logo.jpg">
				</a>
			</div>
			<div class="activities"><!--活动按钮-->
				<a href="activity list.html">活动</a>
			</div>
			<div class="search"><!--手机+搜索-->
				<a href=""><button id="phone"></button></a><!--手机-->
				<button src="images/search.png" id="search"></button><!--搜索按钮-->
			</div>
		</div>
	</div>
	<div class="alert"><!--搜索弹窗-->
		<div class="alertInner">
			<input type="text" placeholder="请输入关键词">
			<div class="hotWords">
				<h1>热搜词</h1>
			</div>
		</div>
	</div>







	<div class="container">
		<div class="writer-and-content">
			<div class="writer-inf">
				<div class="writer-title clearfix">
					<a href="#">                        
                        <asp:Image runat="server" ID="authorimage" />
<%--<img src="images/writer-photo.png" alt="">--%></a>
					<h1><asp:Label runat="server" ID="title"></asp:Label></h1>
				</div>
				
				<div class="about-writer clearfix">
					<a href="#">
						<img src="images/find-writer.png" alt="">
						<p><asp:Label runat="server" ID="authorname"></asp:Label></p>
					</a>
					<p ><asp:Label runat="server" ID="authorsummary"></asp:Label></p>
					<p></p>
					<p >20篇文章</p>
				</div>
			</div>
			<div class="just-border"></div>
			<div class="inf-operate clearfix">
				<div class="infor">
					<p><asp:Label runat="server" ID="time"></asp:Label></p>
					<p><asp:Label runat="server" ID="views"></asp:Label></p>
					<p>评论6</p>
				</div>
				<div class="operate">
					<div class="operate-click" ></div>
					<div class="operate-click operate-click-2"></div>
					<div class="operate-collect"></div>
					<div class="operate-share share-first"></div>
				</div>
			</div>
			<div class="article-content">
			<!-- 	<div class="wechat-weibo share-first">
				<div class="weibo"></div>
				<div class="wechat"></div>
			</div> -->
		<!-- 	<div class="weibo-2d">
				<div></div>
				<div></div>
			</div>
			<div class="wechat-2d">
				<div></div>
				<div></div>
		</div> -->
					<div class="wechat-weibo share-first">
						<div class="weibo"></div>
						<div class="wechat"></div>
						<div class="weibo-2d">
							<div></div>
							<div></div>
						</div>
						<div class="wechat-2d">
							<div></div>
							<div></div>
						</div> 
					</div>
                <asp:Image runat="server" ID="image" />
				<div>
                    
                    <asp:Label runat="server" ID="content"></asp:Label>
                    <%--这年头，创业导师太多了，创业者都快不够用了。尤其是互联网领域，BAT和TMD这类企业的在职和离职员工也有大几十万人了吧，跑出来到处讲课指导年轻人的也大有人在。只要你愿意，各种线上线下课程任你选，学半年不重样，正如我之前写过的，不管你创业赚没赚到钱，他们反正是赚到了。</div>
				<img src="images/contentimg2.png" alt="">
				<div class="article-2">这年头，创业导师太多了，创业者都快不够用了。尤其是互联网领域，BAT和TMD这类企业的在职和离职员工也有大几十万人了吧，跑出来到处讲课指导年轻人的也大有人在。只要你愿意，各种线上线下课程任你选，学半年不重样，正如我之前写过的，不管你创业赚没赚到钱，他们反正是赚到了。
				<br>
				<br>
				<!-- 2个br是换行的，可以直接删掉 -->
				作为十四年职场浮沉，外企合资国企民企个体走过一圈的老司机，很惭愧的是，我还是不太懂得怎么讲成功学，况且成功经验这种东西，大都是天时地利人和使然，难以复制，不如和大家聊聊，怎么做会死的比较快。项目不靠谱，死得快未必是坏事，毕竟时间才是最昂贵的成本，我们姑且把这个作死系列，叫做“早死早超生”创业指南好了。</div>
			--%></div>
		</div>
		<div class="activity-related">
			<h1>相关文章</h1>
			<div class="activity-related-main clearfix">
				<div class="activity-more-left">
					<div class="activity-more">
						<img src="images/activity-icon.png" alt="">
						<h1>虎嗅活动</h1>
						<p><asp:Label ID="title1" runat="server"></asp:Label></p>
						<div class="act-change">
                            <asp:ImageButton runat="server" class="activity-mouseover-img" ID="image1" />
							<%--<img class="activity-mouseover-img" src="images/more-activity.png" alt="">--%>
							<a href="">了解更多</a>
						</div>
					</div>
				</div>
				<div class="activity-more-center">
					<div class="activity-more">
						<img src="images/activity-icon.png" alt="">
						<h1>虎嗅活动</h1>
						<p><asp:Label ID="title2" runat="server"></asp:Label></p>
						<div class="act-change">
							<%--<img class="activity-mouseover-img" src="images/more-activity.png" alt="">--%>
                            <asp:ImageButton runat="server" class="activity-mouseover-img" ID="image2" />
							<a href="">了解更多</a>
						</div>
					</div>
				</div>
				<div class="activity-more-right">
					<div class="activity-more">
						<img src="images/activity-icon.png" alt="">
						<h1>虎嗅活动</h1>
		                <p><asp:Label ID="title3" runat="server"></asp:Label></p>
						<div class="act-change">
							<%--<img class="activity-mouseover-img" src="images/more-activity.png" alt="">--%>
                            <asp:ImageButton runat="server" class="activity-mouseover-img" ID="image3" />
							<a href="">了解更多</a>
						</div>
					</div>
				</div>
			</div>
		</div>
	</div>




	<div class="footer">
		<ul class="footer-inf clearfix">
			<li><a href="">关于我们</a></li>
			<li><a href="">加入我们</a></li>
			<li><a href="">合作伙伴</a></li>
			<li><a href="">广告及服务</a></li>
			<li><a href="">常见问题解答</a></li>
			<li><a href="">防网络诈骗专题</a></li>
		</ul>
		<div class="weibo-wechat-qqzone clearfix">
			<div class="footer-weibo"><a href=""></a></div>
			<div class="footer-wechat"><a href=""></a></div>
			<div class="footer-qqzone"><a href=""></a></div>
		</div>
		<div class="footer-login">
			<div>
				<p>All Rights Reserved. </p>
				<a href="login.html">管理员登录</a>
			</div>
		</div>
	</div >
	<script src="js/news content.js"></script>
	<script src="js/footer.js"></script>
    </form>
</body>
</html>
