﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SuccessPage.aspx.cs" Inherits="RESAERCHMENTOR.NET.Views.SuccessPage" %>

<!DOCTYPE html>

<html lang="en" runat ="server">
	<head>
		<meta charset="UTF-8" />
		<meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no" />
		<title>ResearchLogin</title>
		<meta name="description" content="Jetson is a Dashboard & Admin Site Responsive Template by hencework." />
		<meta name="keywords" content="admin, admin dashboard, admin template, cms, crm, Jetson Admin, Jetsonadmin, premium admin templates, responsive admin, sass, panel, software, ui, visualization, web app, application" />
		<meta name="author" content="hencework"/>
		
		<!-- Favicon -->
		<link rel="shortcut icon" href="favicon.ico">
		<link rel="icon" href="favicon.ico" type="image/x-icon">
		
		<!-- vector map CSS -->
		<link href="vendors/bower_components/jasny-bootstrap/dist/css/jasny-bootstrap.min.css" rel="stylesheet" type="text/css"/>
		
		<!-- Data table CSS -->
	<link href="vendors/bower_components/datatables/media/css/jquery.dataTables.min.css" rel="stylesheet" type="text/css"/>
	
		
		<!-- Custom CSS -->
		<link href="dist/css/style.css" rel="stylesheet" type="text/css">
	    <style type="text/css">
            .auto-style1 {
                width: 147px;
                height: 147px;
            }
        </style>
	</head>
	<body>
		<!--Preloader-->
		<div class="preloader-it">
			<div class="la-anim-1"></div>
		</div>
		<!--/Preloader-->
		
		<div class="wrapper pa-0">
			        <!-- Top Menu Items -->
		<nav class="navbar navbar-inverse navbar-fixed-top">
			<div class="mobile-only-brand pull-left">
				<div class="nav-header pull-left">
					<div class="logo-wrap">
						<a href="index.html">
							<img class="brand-img" src="dist/img/logo.png" alt="brand"/>
							<!--span class="brand-text">Ment</span-->
						</a>
					</div>
				</div>
				<a id="toggle_mobile_search" data-toggle="collapse" data-target="#search_form" class="mobile-only-view" href="javascript:void(0);"><i class="zmdi zmdi-search"></i></a>
				<a id="toggle_mobile_nav" class="mobile-only-view" href="javascript:void(0);"><i class="zmdi zmdi-menu"></i></a>
<%--				<form id="search_form" runat ="server" role="search" class="top-nav-search collapse pull-left">--%>
				
			</div>
				<div>
						<ul class="nav navbar-right top-nav pull-right">
							<li  class="active"><a href="HomePage.aspx"><i class=" ti-home"> Research</i></a></li>
							<li><a href="#"><span><i class=" ti-lock"> Login</i></span></a></li>
                            <li><i class=" ti-user"><asp:HyperLink runat="server" ID="RegisterHyperLink" ViewStateMode="Disabled"> Register</asp:HyperLink></i></li>
						</ul>
					</div>
		</nav>
		<!-- /Top Menu Items -->
			
			<!-- Main Content -->
			<div class="page-wrapper pa-0 ma-0 auth-page">
				<div class="container-fluid">
                
					<!-- Row -->
					<div class="table-struct full-width full-height">
						<div class="table-cell vertical-align-middle auth-form-wrap">
                                
							<div class="auth-form  ml-auto mr-auto no-float">
                                
								<div class="row">
									<div class="col-sm-12 col-xs-12">
                    <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                        <p class="text-danger">
                            <asp:Literal runat="server" ID="FailureText" />
                        </p>
                    </asp:PlaceHolder>
										<div class="mb-30">
                                           <p align ="center"><img src="dist/img/success.jpg" class="auto-style1" /></p>
											<h3 class="text-center txt-dark mb-10">Operation was successful</h3>
                                            <div align ="center">
											<h6 class="text-center nonecase-font txt-grey">
                                                 <a href="Profile.aspx">Go to profile page</a></h6>
                                                </div>
										</div>	
										<div class="form-wrap">
											<form action="#" runat ="server">												
											</form>
										</div>
									</div>	
								</div>
							</div>
						</div>
					</div>
					<!-- /Row -->
                    
                    
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
		<script src="vendors/bower_components/jasny-bootstrap/dist/js/jasny-bootstrap.min.js"></script>
		
		<!-- Slimscroll JavaScript -->
		<script src="dist/js/jquery.slimscroll.js"></script>
		
		<!-- Init JavaScript -->
		<script src="dist/js/init.js"></script>
	</body>
</html>
