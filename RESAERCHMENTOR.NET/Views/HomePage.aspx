﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="RESAERCHMENTOR.NET.Views.HomePage" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8" />
	<meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no" />
	<title>::Research Gate</title>
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
							<span class="brand-text">Research Gate</span>
						</a>
					</div>
				</div>
				<a id="toggle_mobile_search" data-toggle="collapse" data-target="#search_form" class="mobile-only-view" href="javascript:void(0);"><i class="zmdi zmdi-search"></i></a>
				<a id="toggle_mobile_nav" class="mobile-only-view" href="javascript:void(0);"><i class="zmdi zmdi-menu"></i></a>
				<form id="search_form" runat ="server" role="search" class="top-nav-search collapse pull-left">
					<div class="input-group">
						<input type="text" name="example-input1-group2" class="form-control" placeholder="Search">
						<span class="input-group-btn">
						<button type="button" class="btn  btn-default"  data-target="#search_form" data-toggle="collapse" aria-label="Close" aria-expanded="true"><i class="zmdi zmdi-search"></i></button>
						</span>
					</div>
                </form>
				
			</div>
			<div id="mobile_only_nav" class="mobile-only-nav pull-right">
				<ul class="nav navbar-right top-nav pull-right">
					<li>
<%--						<a id="open_right_sidebar" href="#"><i class="zmdi zmdi-apps top-nav-icon"></i></a>--%>
					</li>
				</ul>
			</div>	
		</nav>
		<!-- /Top Menu Items -->
       
		<!-- Main Content -->
		<div class="page-wrapper">
            <div class="container-fluid">
			
			
										<!-- Title -->
				<div class="row heading-bg">
					<div class="col-lg-3 col-md-4 col-sm-4 col-xs-12">
						<h5 class="txt-dark"></h5>
					</div>
					<!-- Breadcrumb -->
					<div class="col-lg-9 col-sm-8 col-md-8 col-xs-12">
						<ol class="breadcrumb">
							<li  class="active"><a href="HomePage.aspx">Research</a></li>
                       		<li  class="active"><a href="Register.aspx">Sign Up</a></li>
							<li  class="active"><a href="Login.aspx">Log In</a></li>
						</ol>
					</div>
					<!-- /Breadcrumb -->
				</div>
				<!-- /Title -->
				
				<!-- Slide -->
				
                <div class="wSlide">
                
                    <div class="wslideinner">
                    
                      <div class="wslideinnercontent">
                    <div class="headerdiv">
                      <h2 class="header">Discover scientific knowledge, and make your research visible.</h2>
                    </div>
                          <div class="clearfix"></div><br>
                          <a  href="Register.aspx"><div class="slidebutton">
                              <span class="slidebuttonbtn">Join for free</span>
                          </div></a>
                          <div class="clearfix"></div><br><br>
                          <div class="headerdiv1">
                              <a href="#"><div class="icon-container"> 
                                  <i class="ti-facebook"></i>
                                  </div></a>
                              <a href="#"><div class="icon-container">
                                  <i class="ti-instagram"></i>
                                  </div></a>
                              <a href="#"><div class="icon-container">
                                  <i class="ti-twitter-alt"></i>
                                  </div></a>
                               <a href="#"><div class="icon-container">
                                   <i class=" ti-youtube"></i>
                                   </div></a>
                              <a href="#"><div class="icon-container">
                                  <i class="ti-pinterest-alt"></i>
                          </div></a>
                              <div class="clearfix"></div>
                        </div>
                              
                    </div>
                    </div>
                    
                    </div>
                    
                
				<div class="clearfix"></div>
				<!-- Slide -->
				
                
                <!-- body1 -->
                
                <div class="body1">
                    <div class="body1inner">
                      <div class="body1content">
                        <span><q class="body1contenttext">Research Gate is changing how scientists share and advance research.</q></span>
			          </div>
		            </div>
	            </div>
                <!-- body1 -->
                
                <!-- body1 -->
                
                <div class="body2">
                    <div class="body2inner">
                      <div class="body2content">
                          <strong><h1 class="read1">Advance your research</h1></strong>
                        <div class="clearfix"></div>
                          <div class="body2contentcolumn2">
                              <ul class="left">
                                  <li><img src="dist/img/big/circle.jpg" alt="image" class="img-circle" width="170"></li>
                                  <li><h4>Read and discuss publications</h4></li>
                                  <li><p>Find the research you need to help your work and join open discussions with the authors and other experts.</p></li>
                              </ul>
                              <ul class="right">
                                  <li><img src="dist/img/big/circle.jpg" alt="image" class="img-circle" width="170"></li>
                                  <li><h4>Read and discuss publications</h4></li>
                                  <li><p>Find the research you need to help your work and join open discussions with the authors and other experts.</p></li>
                              </ul>
                              <ul class="left">
                                  <li><img src="dist/img/big/circle.jpg" alt="image" class="img-circle" width="170"></li>
                                  <li><h4>Read and discuss publications</h4></li>
                                  <li><p>Find the research you need to help your work and join open discussions with the authors and other experts.</p></li>
                              </ul>
                              <ul class="right">
                                  <li><img src="dist/img/big/circle.jpg" alt="image" class="img-circle" width="170"></li>
                                  <li><h4>Read and discuss publications</h4></li>
                                  <li><p>Find the research you need to help your work and join open discussions with the authors and other experts.</p></li>
                              </ul>
                          </div>
                <div class="clearfix"></div>
                          <strong><h2 class="read">Advance your research</h2></strong>
                          <div class="body2contentcolumn21">
                              <ul class="left1">
                                  <li><img src="dist/img/big/circle.jpg" alt="image" class="img-circle" width="170"></li>
                                  <li><h4>Read and discuss publications</h4></li>
                                  <li><p>Find the research you need to help your work and join open discussions with the authors and other experts.</p></li>
                                  <li><button class="btn  btn-info">Join us</button></li>
                              </ul>
                              <ul class="right1">
                                  <li><img src="dist/img/big/circle.jpg" alt="image" class="img-circle" width="170"></li>
                                  <li><h4>Read and discuss publications</h4></li>
                                  <li><p>Find the research you need to help your work and join open discussions with the authors and other experts.</p></li>
                                  <li><button class="btn  btn-info">Join us</button></li>
                              </ul>
                              <ul class="left1">
                                  <li><img src="dist/img/big/circle.jpg" alt="image" class="img-circle" width="170"></li>
                                  <li><h4>Read and discuss publications</h4></li>
                                  <li><p>Find the research you need to help your work and join open discussions with the authors and other experts.</p></li>
                                  <li><button class="btn  btn-info">Join us</button></li>
                              </ul>
                          </div><div class="clearfix"></div>
			          </div>
		            </div>
	            </div>
                
                <!-- body1 -->
				
				
				<!-- Footer -->
				<footer class="footer container-fluid pl-30 pr-30">
					<div class="row">
						<div class="col-sm-12">
							<p><a href="#">News</a><a href="#">About us</a>
                              <a href="#">Privacy</a><a href="#">Terms</a><a href="#">Copyright</a><a href="#">Careers</a><a href="#">Help Center</a><a href="#">Researchers</a><a href="#">FAQ</a><a href="#">Publications</a><a href="#">Job</a><a href="#">Recruiters</a><a href="#">Advertisers</a> &nbsp; &nbsp; &nbsp; &nbsp; <a href="#">2017 &copy; ResearchGate. Pampered by MEIS007</a></p> 
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
