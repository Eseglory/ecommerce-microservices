<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DashBoard.aspx.cs" Inherits="RESAERCHMENTOR.NET.Views.DashBoard" %>

<!DOCTYPE html>

<html lang="en">
<head>
    <meta charset="UTF-8" />
	<meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no" />
	<title>ResearchGate</title>
	<meta name="description" content="Jetson is a Dashboard & Admin Site Responsive Template by hencework." />
	<meta name="keywords" content="admin, admin dashboard, admin template, cms, crm, Jetson Admin, Jetsonadmin, premium admin templates, responsive admin, sass, panel, software, ui, visualization, web app, application" />
	<meta name="author" content="hencework"/>
	
	<!-- Favicon -->
	<link rel="shortcut icon" href="favicon.ico">
	<link rel="icon" href="favicon.ico" type="image/x-icon">
    

	<!-- Data table CSS -->
	<link href="vendors/bower_components/datatables/media/css/jquery.dataTables.min.css" rel="stylesheet" type="text/css"/>
	
	<!-- Owl CSS -->
		<link href="vendors/bower_components/owl.carousel/dist/assets/owl.carousel.min.css" rel="stylesheet" type="text/css">
		<link href="vendors/bower_components/owl.carousel/dist/assets/owl.theme.default.min.css" rel="stylesheet" type="text/css">
		
	
	<!-- Custom CSS -->
	<link href="dist/css/style.css" rel="stylesheet" type="text/css">
    <link href="dist/css/custom-style.css" rel="stylesheet" type="text/css">
</head>

<body>
	<!--Preloader-->
	<div class="preloader-it">
		<div class="la-anim-1"></div>
	</div>
	<!--/Preloader-->
    <div class="wrapper theme-1-active pimary-color-green">

        <!-- Top Menu Items -->
		<nav class="navbar navbar-inverse navbar-fixed-top">
			<div class="mobile-only-brand pull-left">
				<div class="nav-header pull-left">
					<div class="logo-wrap">
						<a href="researchindex.html">
							<img class="brand-img" src="dist/img/logo.png" alt="brand"/>
							<span class="brand-text">Research Mentor</span>
						</a>
					</div>
				</div>
				
				
			</div>
            
            <div>
				<ul class="nav navbar-right top-nav pull-right">
					<li  class="active"><a href="#">Research</a></li>
					<li><a href="researchlogin.html"><span>Login</span></a></li>
					<li><a href="researchsignup.html"><span>Signup</span></a></li>
				</ul>
			</div>	
            
            
			<div id="mobile_only_nav" class="mobile-only-nav pull-right">
				<ul class="nav navbar-right top-nav pull-right">
					<li>
		<a id="open_right_sidebar" href="#"><i class="zmdi zmdi-apps top-nav-icon"></i></a>
					</li>
				</ul>
			</div>	
		</nav>
		<!-- /Top Menu Items -->
		
		
       
		<!-- Main Content -->
		<div class="page-wrapper">
            <div class="container-fluid">
			<br><br><br>
                <!-- Added by saka -->
                <div class="news-feed col-lg-7">
            	<div class="row">
                    <!-- /story-cont -->
                   <%foreach (var item in GetLoginUser()){%>
                    <div class="story-cont col-lg-12 p-b-m">
                    	<div class="row story-cont2">
                            <div class="profile-pic col-lg-1 col-xs-2 pg-up">
                                <div class="row">
                                    <img runat="server" id="RProfileImg" class="img-responsive">
                                </div><!-- /profile-pic -->
                            </div>
                        	<!--div class="row"-->
                            <div class="news-feed-header col-lg-10 col-xs-10 pg-up bg-white">
                                <div class="username-newsfeed p-tb-xs"> 
                                    <span class="txt-green"><strong><asp:Label ID="ROwner" runat="server" Text="Label"></asp:Label> </strong></span> 
                                    <div class="visible-xs"><br></div>
                                    <%DateTime RDate = Convert.ToDateTime(item.RDateCreated);
                                        string MDate = RDate.ToLongDateString();
                                         %>
                                    <span class="txt-grey pull-right">Posted <%HttpContext.Current.Response.Write(MDate); %></span>
                                    <br>
                                    
                                    <span class="txt-grey"><%HttpContext.Current.Response.Write(item.RType); %> was added</span> 
                                </div><!-- /username-newsfeed -->
                            </div><!-- /news-feed-header -->
                            <div class="write-up col-lg-10 bg-white border-top p-b-s">
                                <div class="news-feed-title_img col-lg-7">
                                	
                                        <div class="row">
                                            <div class="post-heading col-lg-12">
                                                <h6><%HttpContext.Current.Response.Write(item.Description); %> </h6>
                                            </div><!-- /post-heading -->
                                            <div class="row">
                                                    
                                <br><br><br><br><br><br>
                                                    
                                                </div>
                                        </div><!-- /row -->
                                    <div class="row">
                                        <div class="post-img col-lg-12">
                                        
                                        <div class="row">
                                            <div class="col-lg-8 col-xs-9 view-top">
                                                <div class="row">
                          <a href="#" class="p-l-s txt-green">View </a>
                         <a href="#" class="p-l-s txt-green">Download </a>
                                                </div>
                                            </div><!-- /col-6 -->
                                            <div class="col-lg-4 col-xs-3 pull-right view-top">
                                                <div class="row">
                                                <div class="col-lg-6 col-xs-6"><img src="dist/img/big/like.png" width="15"></div>
                                                <div class="col-lg-6 col-xs-6"><img src="dist/img/big/share.png" width="15"></div>
                                                </div>
                                            </div>
                                        </div><!-- /row -->
                                    
                                         
                                        </div><!-- /post-img -->
                                    </div><!-- /row -->
                                    
                                </div><!-- /news-feed-title_img -->
                                <div class="news-feed-text col-lg-5 p-t-s">
                                <img src="dist/img/big/kids.png" class="img-responsive" width="100" height="600">
									
                                </div><!-- /news-feed-text -->
                            </div><!-- /write-up -->
                            <!--/div-->
                            
                        </div><!-- /row -->
                    </div>
                    <%} %>
                    <!-- /story-cont -->
                    <div class="col-lg-1"></div>
            
            <div class="col-lg-4 bg-white static pull-right">
                <div class="p-t-xs"><img src="dist/img/big/ad-1.png" class="img-responsive" width="250"></div>
                <div class="p-tb-xs"><img src="dist/img/big/ad-2.png" class="img-responsive" width="250"></div>
                
            </div><!-- /.col-3 -->
            </div>
                    
                    
                </div><!-- /row -->
                
                 
            
				  <!-- Added by saka -->
				<!-- Footer -->
				<footer class="footer container-fluid pl-30 pr-30">
					<div class="row">
						<div class="col-sm-12">
							<p><a href="#">News</a><a href="#">About us</a>
                              <a href="#">Privacy</a><a href="#">Terms</a><a href="#">Copyright</a><a href="#">Careers</a><a href="#">Help Center</a><a href="#">Researchers</a><a href="#">FAQ</a><a href="#">Publications</a><a href="#">Job</a><a href="#">Recruiters</a><a href="#">Advertisers</a> &nbsp; &nbsp; &nbsp; &nbsp; <a href="#">2018 &copy; ResearchMentor All rights reserved</a></p> 
						</div>
					</div>
				</footer>
                <div class="clearfix"></div>
				<!-- /Footer -->
                
                
			</div>
		</div>
        <!-- /Main Content -->

    </div>
    <!-- /#wrapper -->
	
	<!-- JavaScript -->
	
    <!-- jQuery -->
    <script src="vendors/bower_components/jquery/dist/jquery.min.js"></script>

    <!-- Bootstrap Core JavaScript -->
    <script src="vendors/bower_components/bootstrap/dist/js/bootstrap.min.js"></script>
    
	<!-- Data table JavaScript -->
	<script src="vendors/bower_components/datatables/media/js/jquery.dataTables.min.js"></script>
	<script src="dist/js/dataTables-data.js"></script>
	
	<!-- Slimscroll JavaScript -->
	<script src="dist/js/jquery.slimscroll.js"></script>
	
	<!-- Owl JavaScript -->
	<script src="vendors/bower_components/owl.carousel/dist/owl.carousel.min.js"></script>
	
	<!-- Switchery JavaScript -->
	<script src="vendors/bower_components/switchery/dist/switchery.min.js"></script>
	
	<!-- Fancy Dropdown JS -->
	<script src="dist/js/dropdown-bootstrap-extended.js"></script>
	
	<!-- Init JavaScript -->
	<script src="dist/js/init.js"></script>
	
	
	
	
</body>

</html>
