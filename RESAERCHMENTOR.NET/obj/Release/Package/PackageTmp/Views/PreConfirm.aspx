﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PreConfirm.aspx.cs" Inherits="RESAERCHMENTOR.NET.Views.PreConfirm" %>

<!DOCTYPE html>

<html lang="en" runat ="server">
	<head>
		<meta charset="UTF-8" />
		<meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no" />
		<title>Research Registration</title>
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
							<span class="brand-text">Research Gate</span>
						</a>
					</div>
				</div>
				
				
			</div>
			
            
            <div>
				<ul class="nav navbar-right top-nav pull-right">
					<li  class="active"><a href="HomePage.aspx"><i class=" ti-home"> Research</i></a></li>
                    <li  class="active"><a href="Register.aspx"><i class=" ti-user"> Sign Up</i> </a></li>
					<li  class="active"><a href="Login.aspx"><i class="ti-lock"> Log In</i> </a></li>
				</ul>
			</div>	
				
		</nav>
		<!-- /Top Menu Items -->
			
			<!-- Main Content -->
			<div class="page-wrapper pa-0 ma-0 auth-page">
				<div class="container-fluid">
                   
				
				<!-- /Title -->
					<!-- Row -->
					<div class="table-struct full-width full-height">
						<div class="table-cell vertical-align-middle auth-form-wrap">
                                
							<div class="auth-form  ml-auto mr-auto no-float">
                                
								<div class="row">
									<div class="col-sm-12 col-xs-12">

										<div class="mb-30">
											<h3 class="text-center txt-dark mb-10">Account Confirmation</h3>
                                            <h5 class="text-center txt-dark mb-10">Please enter the confirmation code that was sent to your mail.</h5>
										</div>	
										<div class="form-wrap">
											<form action="#" runat ="server">
                                                <asp:Panel ID="Panel1" runat="server">
                                                    	<input type="text" runat="server" id="ConCode" class="form-control" placeholder="Enter Confirmation Code">
                                  <br /> <div align ="center">
                                                 <asp:Button ID="Confirm_User" runat="server" OnClick="Confirm_Click" Text="Confirm" class="btn btn-success btn-icon left-icon mr-10 pull-left" CausesValidation="False" OnClientClick="Confirm_Click"/>
                                                  <asp:Button ID="Resend_Confirm" runat="server" OnClick="ResendConfirm_Click" Text="Resend Mail" BackColor ="Blue" ForeColor ="White" CausesValidation="False" OnClientClick="ResendConfirm_Click"/>                                  </div>
										
                                                </asp:Panel>
                                                <asp:Panel ID="Panel2" runat="server">
                                                    	<input type="text" required="required" runat="server" id="Email" class="form-control" placeholder="Enter Email Address">
                                  <br /> <div align ="center">
                                                 <asp:Button ID="ResendMail" runat="server" OnClick="ResendMail_Click" Text="Send Code" class="btn btn-success btn-icon left-icon mr-10 pull-left" CausesValidation="False" OnClientClick="ResendMail_Click"/>
                                                </asp:Panel>
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

