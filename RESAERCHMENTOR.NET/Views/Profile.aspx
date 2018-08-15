<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="RESAERCHMENTOR.NET.Views.Profile" %>

<!DOCTYPE html>

<html lang="en">
<head>
    <meta charset="UTF-8" />
	<meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no" />
	<title>Researchprofile</title>
	<meta name="description" content="Jetson is a Dashboard & Admin Site Responsive Template by hencework." />
	<meta name="keywords" content="admin, admin dashboard, admin template, cms, crm, Jetson Admin, Jetsonadmin, premium admin templates, responsive admin, sass, panel, software, ui, visualization, web app, application" />
	<meta name="author" content="hencework"/>
	
	<!-- Favicon -->
	<link rel="shortcut icon" href="favicon.ico">
	<link rel="icon" href="favicon.ico" type="image/x-icon">
	
	<!-- Morris Charts CSS -->
    <style type="text/css">
.gridview {
        font-family:"arial";
        background-color:#FFFFFF;
        width: 100%;
        font-size: small;
}
.gridview th {
        background: #7AC142;
        padding: 5px;
        font-size:small;

}
.gridview th a{
        color: #003300;
        text-decoration: none;
}
.gridview th a:hover{
        color: #003300;
        text-decoration: underline;
}
.gridview td  {
        background: #D9EDC9;
        color: #333333;
        font: small "arial";
        padding: 4px;
        border:groove;
}
.gridview tr.even td {
        background: #FFFFFF;
}
.gridview td a{
        color: #003300;
        font: bold small "arial";
        padding: 2px;
        text-decoration: none;
}
.gridview td a:hover {
        color: red;
        font-weight: bold;
        text-decoration:underline;
}

</style>

    <link href="vendors/bower_components/morris.js/morris.css" rel="stylesheet" type="text/css"/>
    <link href="src/scss/GridStyle.css" rel="stylesheet" />
	<!-- vector map CSS -->
	<link href="vendors/vectormap/jquery-jvectormap-2.0.2.css" rel="stylesheet" type="text/css"/>
	
	<!-- Calendar CSS -->
	<link href="vendors/bower_components/fullcalendar/dist/fullcalendar.css" rel="stylesheet" type="text/css"/>
		
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
    <div class="wrapper theme-1-active pimary-color-pink">
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
				<a id="toggle_nav_btn" class="toggle-left-nav-btn inline-block ml-20 pull-left" href="javascript:void(0);"><i class=""></i></a>
				<a id="toggle_mobile_search" data-toggle="collapse" data-target="#search_form" class="mobile-only-view" href="javascript:void(0);"><i class="zmdi zmdi-search"></i></a>
				<a id="toggle_mobile_nav" class="mobile-only-view" href="javascript:void(0);"><i class="zmdi zmdi-more"></i></a>
				<form id="search_form" role="search" class="top-nav-search collapse pull-left">
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
						<a id="open_right_sidebar" href="#"><i class="zmdi zmdi-settings top-nav-icon"></i></a>
					</li>
					<li class="dropdown app-drp">
						<a href="#" class="dropdown-toggle" data-toggle="dropdown"><i class="zmdi zmdi-apps top-nav-icon"></i></a>
						<ul class="dropdown-menu app-dropdown" data-dropdown-in="slideInRight" data-dropdown-out="flipOutX">
							<li>
								<div class="app-nicescroll-bar">
									<ul class="app-icon-wrap pa-10">
										<li>
											<a href="researchweather.html" class="connection-item">
											<i class="zmdi zmdi-cloud-outline txt-info"></i>
											<span class="block">weather</span>
											</a>
										</li>
										<li>
											<a href="researchinbox.html" class="connection-item">
											<i class="zmdi zmdi-email-open txt-success"></i>
											<span class="block">e-mail</span>
											</a>
										</li>
										<li>
											<a href="researchcalendar.html" class="connection-item">
											<i class="zmdi zmdi-calendar-check txt-primary"></i>
											<span class="block">calendar</span>
											</a>
										</li>
										<li>
											<a href="researchvectormap.html" class="connection-item">
											<i class="zmdi zmdi-map txt-danger"></i>
											<span class="block">map</span>
											</a>
										</li>
										<li>
											<a href="researchchats.html" class="connection-item">
											<i class="zmdi zmdi-comment-outline txt-warning"></i>
											<span class="block">chat</span>
											</a>
										</li>
										<li>
											<a href="researchcontactcard.html" class="connection-item">
											<i class="zmdi zmdi-assignment-account"></i>
											<span class="block">contact</span>
											</a>
										</li>
									</ul>
								</div>	
							</li>
							<li>
								<div class="app-box-bottom-wrap">
									<hr class="light-grey-hr ma-0"/>
									<a class="block text-center read-all" href="javascript:void(0)"> more </a>
								</div>
							</li>
						</ul>
					</li>
					
					<li class="dropdown alert-drp">
						<a href="#" class="dropdown-toggle" data-toggle="dropdown"><i class="zmdi zmdi-notifications top-nav-icon"></i><span class="top-nav-icon-badge">5</span></a>
						<ul  class="dropdown-menu alert-dropdown" data-dropdown-in="bounceIn" data-dropdown-out="bounceOut">
							<li>
								<div class="notification-box-head-wrap">
									<span class="notification-box-head pull-left inline-block">notifications</span>
									<a class="txt-danger pull-right clear-notifications inline-block" href="javascript:void(0)"> clear all </a>
									<div class="clearfix"></div>
									<hr class="light-grey-hr ma-0"/>
								</div>
							</li>
							<li>
								<div class="streamline message-nicescroll-bar">
									<div class="sl-item">
										<a href="javascript:void(0)">
											<div class="icon bg-green">
												<i class="zmdi zmdi-flag"></i>
											</div>
											<div class="sl-content">
												<span class="inline-block capitalize-font  pull-left truncate head-notifications">
												New subscription created</span>
												<span class="inline-block font-11  pull-right notifications-time">2pm</span>
												<div class="clearfix"></div>
												<p class="truncate">Your customer subscribed for the basic plan. The customer will pay $25 per month.</p>
											</div>
										</a>	
									</div>
									<hr class="light-grey-hr ma-0"/>
									<div class="sl-item">
										<a href="javascript:void(0)">
											<div class="icon bg-yellow">
												<i class="zmdi zmdi-trending-down"></i>
											</div>
											<div class="sl-content">
												<span class="inline-block capitalize-font  pull-left truncate head-notifications txt-warning">Server #2 not responding</span>
												<span class="inline-block font-11 pull-right notifications-time">1pm</span>
												<div class="clearfix"></div>
												<p class="truncate">Some technical error occurred needs to be resolved.</p>
											</div>
										</a>	
									</div>
									<hr class="light-grey-hr ma-0"/>
									<div class="sl-item">
										<a href="javascript:void(0)">
											<div class="icon bg-blue">
												<i class="zmdi zmdi-email"></i>
											</div>
											<div class="sl-content">
												<span class="inline-block capitalize-font  pull-left truncate head-notifications">2 new messages</span>
												<span class="inline-block font-11  pull-right notifications-time">4pm</span>
												<div class="clearfix"></div>
												<p class="truncate"> The last payment for your G Suite Basic subscription failed.</p>
											</div>
										</a>	
									</div>
									<hr class="light-grey-hr ma-0"/>
									<div class="sl-item">
										<a href="javascript:void(0)">
											<div class="sl-avatar">
												<img class="img-responsive" src="dist/img/avatar.jpg" alt="avatar"/>
											</div>
											<div class="sl-content">
												<span class="inline-block capitalize-font  pull-left truncate head-notifications">Sandy Doe</span>
												<span class="inline-block font-11  pull-right notifications-time">1pm</span>
												<div class="clearfix"></div>
												<p class="truncate">Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit</p>
											</div>
										</a>	
									</div>
									<hr class="light-grey-hr ma-0"/>
									<div class="sl-item">
										<a href="javascript:void(0)">
											<div class="icon bg-red">
												<i class="zmdi zmdi-storage"></i>
											</div>
											<div class="sl-content">
												<span class="inline-block capitalize-font  pull-left truncate head-notifications txt-danger">99% server space occupied.</span>
												<span class="inline-block font-11  pull-right notifications-time">1pm</span>
												<div class="clearfix"></div>
												<p class="truncate">consectetur, adipisci velit.</p>
											</div>
										</a>	
									</div>
								</div>
							</li>
							<li>
								<div class="notification-box-bottom-wrap">
									<hr class="light-grey-hr ma-0"/>
									<a class="block text-center read-all" href="javascript:void(0)"> read all </a>
									<div class="clearfix"></div>
								</div>
							</li>
						</ul>
					</li>
					<li class="dropdown auth-drp">
						<a href="#" class="dropdown-toggle pr-0" data-toggle="dropdown"><img src="dist/img/user1.png" alt="user_auth" class="user-auth-img img-circle"/><span class="user-online-status"></span></a>
						<ul class="dropdown-menu user-auth-dropdown" data-dropdown-in="flipInX" data-dropdown-out="flipOutX">
							<li>
								<a href="researchprofile.html"><i class="zmdi zmdi-account"></i><span>Profile</span></a>
							</li>
							<li>
								<a href="researchinbox.html"><i class="zmdi zmdi-email"></i><span>Inbox</span></a>
							</li>
							<li>
								<a href="researchprofile.html"><i class="zmdi zmdi-settings"></i><span>Settings</span></a>
							</li>
							<li class="divider"></li>
							<li class="sub-menu show-on-hover">
								<a href="#" class="dropdown-toggle pr-0 level-2-drp"><i class="zmdi zmdi-check text-success"></i> available</a>
								<ul class="dropdown-menu open-left-side">
									<li>
										<a href="#"><i class="zmdi zmdi-check text-success"></i><span>available</span></a>
									</li>
									<li>
										<a href="#"><i class="zmdi zmdi-circle-o text-warning"></i><span>busy</span></a>
									</li>
									<li>
										<a href="#"><i class="zmdi zmdi-minus-circle-outline text-danger"></i><span>offline</span></a>
									</li>
								</ul>	
							</li>
							<li class="divider"></li>
							<li>
								<a href="researchlogin.html"><i class="zmdi zmdi-power"></i><span>Log Out</span></a>
							</li>
						</ul>
					</li>
                    <li class="dropdown full-width-drp">
						<a href="AddResearch.aspx" class="dropdown-toggle" data-toggle=""><button class="btnmenuresearch">Add Research</button></a>
                        
						<ul class="dropdown-menu mega-menu pa-0" data-dropdown-in="fadeIn" data-dropdown-out="fadeOut">
							<li class="product-nicescroll-bar row">
								<ul class="pa-20">
									
                                    <div class="container-fluid">
					<!-- Title -->
					<div class="row heading-bg">
						<div class="col-lg-3 col-md-4 col-sm-4 col-xs-12">
						  <h5 class="txt-dark">file manager</h5>
						</div>
						<!-- Breadcrumb -->
						<div class="col-lg-9 col-sm-8 col-md-8 col-xs-12">
						  <ol class="breadcrumb">
							<li><a href="HomePage.aspx">Home</a></li>
							<li><a href="researchinbox.html"><span>Inbox</span></a></li>
							<li class="active"><span>Researchcalendar</span></li>
						  </ol>
						</div>
						<!-- /Breadcrumb -->
					</div>
					<!-- /Title -->
					<!-- Row -->
					<div class="row">
						<div class="col-md-12">
							<div class="panel panel-default card-view pa-0">
								<div class="panel-wrapper collapse in">
									<div class="panel-body pa-0">
										<div class="">
											<div class="col-lg-3 col-md-4 file-directory pa-0">
												<div class="ibox float-e-margins">
													<div class="ibox-content">
														<div class="file-manager">
															<div class="mt-20 mb-20 ml-15 mr-15">
																<div class="fileupload btn btn-success btn-anim btn-block"><i class="fa fa-upload"></i><span class="btn-text">Upload files</span>
																	<input type="file" class="upload">
																</div>
															</div>
															<div class="pl-15 mb-30">
																<a href="#" class="file-control active">All</a>
																<a href="#" class="file-control">Documents</a>
																<a href="#" class="file-control">Audio</a>
																<a href="#" class="file-control">Images</a>
															</div>	
															
															<h6 class="mb-10 pl-15">Folders</h6>
															<ul class="folder-list mb-30">
																<li class="active"><a href=""><i class="zmdi zmdi-folder"></i> Files</a></li>
																<li><a href=""><i class="zmdi zmdi-folder"></i> Pictures</a></li>
																<li><a href=""><i class="zmdi zmdi-folder"></i> Web pages</a></li>
																<li><a href=""><i class="zmdi zmdi-folder"></i> Illustrations</a></li>
																<li><a href=""><i class="zmdi zmdi-folder"></i> Films</a></li>
																<li><a href=""><i class="zmdi zmdi-folder"></i> Books</a></li>
															</ul>
															<h6 class="pl-15 mb-10">Tags</h6>
															<ul class="tag-list pl-15 pr-15">
																<li><a href="">Family</a></li>
																<li><a href="">Work</a></li>
																<li><a href="">Home</a></li>
																<li><a href="">Children</a></li>
																<li><a href="">Holidays</a></li>
																<li><a href="">Music</a></li>
																<li><a href="">Photography</a></li>
																<li><a href="">Film</a></li>
															</ul>
															<div class="clearfix"></div>
														</div>
													</div>
												</div>
											</div>
											<div class="col-lg-9 col-md-8 file-sec pt-20">
												<div class="row">
													<div class="col-lg-12">
														<div class="row">
															<div class="col-lg-3 col-md-4 col-sm-6 col-xs-12  file-box">
																<div class="file">
																	<a href="#">
																		
																		<div class="icon">
																			<i class="zmdi zmdi-file-text"></i>
																		</div>
																		<div class="file-name">
																			Document_2016.doc
																			<br>
																			<span>Added: Jan 11, 2016</span>
																		</div>
																	</a>
																</div>
															</div>
															<div class="col-lg-3 col-md-4 col-sm-6 col-xs-12  file-box">
																<div class="file">
																	<a href="#">
																		
																		<div class="image" style="background-image:url(dist/img/gallery/mock1.jpg)">
																		</div>
																		<div class="file-name">
																			Italy street.jpg
																			<br>
																			<span>Added: Jan 6, 2016</span>
																		</div>
																	</a>
																</div>
															</div>
															<div class="col-lg-3 col-md-4 col-sm-6 col-xs-12  file-box">
																<div class="file">
																	<a href="#">
																		
																		<div class="image" style="background-image:url(dist/img/gallery/mock2.jpg)">
																		</div>
																		<div class="file-name">
																			My feel.png
																			<br>
																			<span>Added: Jan 7, 2016</span>
																		</div>
																	</a>
																</div>
															</div>
															<div class="col-lg-3 col-md-4 col-sm-6 col-xs-12  file-box">
																<div class="file">
																	<a href="#">
																		
																		<div class="icon">
																			<i class="zmdi zmdi-collection-music"></i>
																		</div>
																		<div class="file-name">
																			Michal Jackson.mp3
																			<br>
																			<span>Added: Jan 22, 2016</span>
																		</div>
																	</a>
																</div>
															</div>
															<div class="col-lg-3 col-md-4 col-sm-6 col-xs-12  file-box">
																<div class="file">
																	<a href="#">
																		
																		<div class="image" style="background-image:url(dist/img/gallery/mock3.jpg)">
																		</div>
																		<div class="file-name">
																			Document_2016.doc
																			<br>
																			<span>Added: Fab 11, 2016</span>
																		</div>
																	</a>
																</div>
															</div>
															<div class="col-lg-3 col-md-4 col-sm-6 col-xs-12  file-box">
																<div class="file">
																	<a href="#">
																		
																		<div class="icon">
																			<i class="img-responsive zmdi zmdi-collection-video"></i>
																		</div>
																		<div class="file-name">
																			Monica's birthday.mpg4
																			<br>
																			<span>Added: Fab 18, 2016</span>
																		</div>
																	</a>
																</div>
															</div>
															<div class="col-lg-3 col-md-4 col-sm-6 col-xs-12  file-box">
																<a href="#">
																	<div class="file">
																		
																		<div class="icon">
																			<i class="zmdi zmdi-chart"></i>
																		</div>
																		<div class="file-name">
																			Annual report 2016.xls
																			<br>
																			<span>Added: Fab 22, 2016</span>
																		</div>
																	</div>
																</a>
															</div>
															<div class="col-lg-3 col-md-4 col-sm-6 col-xs-12  file-box">
																<div class="file">
																	<a href="#">
																		
																		<div class="icon">
																			<i class="zmdi zmdi-file-text"></i>
																		</div>
																		<div class="file-name">
																			Document_2016.doc
																			<br>
																			<span>Added: Jan 11, 2016</span>
																		</div>
																	</a>
																</div>
															</div>
															<div class="col-lg-3 col-md-4 col-sm-6 col-xs-12  file-box">
																<div class="file">
																	<a href="#">
																		
																		<div class="image" style="background-image:url(dist/img/gallery/equal-size/mock6.jpg)">
																		</div>
																		<div class="file-name">
																			Italy street.jpg
																			<br>
																			<span>Added: Jan 6, 2016</span>
																		</div>
																	</a>
																</div>
															</div>
															<div class="col-lg-3 col-md-4 col-sm-6 col-xs-12  file-box">
																<div class="file">
																	<a href="#">
																		
																		<div class="image" style="background-image:url(dist/img/gallery/equal-size/mock3.jpg)">
																		</div>
																		<div class="file-name">
																			My feel.png
																			<br>
																			<span>Added: Jan 7, 2016</span>
																		</div>
																	</a>
																</div>
															</div>
															<div class="col-lg-3 col-md-4 col-sm-6 col-xs-12  file-box">
																<div class="file">
																	<a href="#">
																		
																		<div class="icon">
																			<i class="zmdi zmdi-collection-music"></i>
																		</div>
																		<div class="file-name">
																			Michal Jackson.mp3
																			<br>
																			<span>Added: Jan 22, 2016</span>
																		</div>
																	</a>
																</div>
															</div>
															<div class="col-lg-3 col-md-4 col-sm-6 col-xs-12  file-box">
																<div class="file">
																	<a href="#">
																		
																		<div class="image" style="background-image:url(dist/img/gallery/equal-size/mock2.jpg)">
																		</div>
																		<div class="file-name">
																			Document_2016.doc
																			<br>
																			<span>Added: Fab 11, 2016</span>
																		</div>
																	</a>
																</div>
															</div>
															<div class="col-lg-3 col-md-4 col-sm-6 col-xs-12  file-box">
																<div class="file">
																	<a href="#">
																		
																		<div class="icon">
																			<i class="img-responsive zmdi zmdi-collection-video"></i>
																		</div>
																		<div class="file-name">
																			Monica's birthday.mpg4
																			<br>
																			<span>Added: Fab 18, 2016</span>
																		</div>
																	</a>
																</div>
															</div>
															<div class="col-lg-3 col-md-4 col-sm-6 col-xs-12  file-box">
																<a href="#">
																	<div class="file">
																		
																		<div class="icon">
																			<i class="zmdi zmdi-chart"></i>
																		</div>
																		<div class="file-name">
																			Annual report 2016.xls
																			<br>
																			<span>Added: Fab 22, 2016</span>
																		</div>
																	</div>
																</a>
															</div>
															<div class="col-lg-3 col-md-4 col-sm-6 col-xs-12  file-box">
																<div class="file">
																	<a href="#">
																		
																		<div class="icon">
																			<i class="zmdi zmdi-file-text"></i>
																		</div>
																		<div class="file-name">
																			Document_2016.doc
																			<br>
																			<span>Added: Jan 11, 2016</span>
																		</div>
																	</a>
																</div>
															</div>
															<div class="col-lg-3 col-md-4 col-sm-6 col-xs-12  file-box">
																<div class="file">
																	<a href="#">
																		
																		<div class="image" style="background-image:url(dist/img/gallery/mock6.jpg)">
																		</div>
																		<div class="file-name">
																			Italy street.jpg
																			<br>
																			<span>Added: Jan 6, 2016</span>
																		</div>
																	</a>
																</div>
															</div>
															<div class="col-lg-3 col-md-4 col-sm-6 col-xs-12  file-box">
																<div class="file">
																	<a href="#">
																		
																		<div class="image" style="background-image:url(dist/img/gallery/equal-size/mock5.jpg)">
																		</div>
																		<div class="file-name">
																			My feel.png
																			<br>
																			<span>Added: Jan 7, 2016</span>
																		</div>
																	</a>
																</div>
															</div>
															<div class="col-lg-3 col-md-4 col-sm-6 col-xs-12  file-box">
																<div class="file">
																	<a href="#">
																		
																		<div class="icon">
																			<i class="zmdi zmdi-collection-music"></i>
																		</div>
																		<div class="file-name">
																			Michal Jackson.mp3
																			<br>
																			<span>Added: Jan 22, 2016</span>
																		</div>
																	</a>
																</div>
															</div>
															<div class="col-lg-3 col-md-4 col-sm-6 col-xs-12  file-box">
																<div class="file">
																	<a href="#">
																		
																		<div class="image" style="background-image:url(dist/img/gallery/equal-size/mock4.jpg)">
																		</div>
																		<div class="file-name">
																			Document_2016.doc
																			<br>
																			<span>Added: Fab 11, 2016</span>
																		</div>
																	</a>
																</div>
															</div>
															<div class="col-lg-3 col-md-4 col-sm-6 col-xs-12  file-box">
																<div class="file">
																	<a href="#">
																		
																		<div class="icon">
																			<i class="img-responsive zmdi zmdi-collection-video"></i>
																		</div>
																		<div class="file-name">
																			Monica's birthday.mpg4
																			<br>
																			<span>Added: Fab 18, 2016</span>
																		</div>
																	</a>
																</div>
															</div>
															<div class="col-lg-3 col-md-4 col-sm-6 col-xs-12  file-box">
																<a href="#">
																	<div class="file">
																		
																		<div class="icon">
																			<i class="zmdi zmdi-chart"></i>
																		</div>
																		<div class="file-name">
																			Annual report 2016.xls
																			<br>
																			<span>Added: Fab 22, 2016</span>
																		</div>
																	</div>
																</a>
															</div>
														</div>
													</div>
												</div>
											</div>
										</div>
									</div>
								</div>
							</div>
						</div>
					</div>
					<!-- /Row -->

				</div>
                                    
								</ul>
							</li>	
						</ul>
					</li>
				</ul>
			</div>	
		</nav>
		<!-- /Top Menu Items -->
		
		
		<!-- Right Sidebar Menu -->
		<div class="fixed-sidebar-right">
			<ul class="right-sidebar">
				<li>
					<div  class="tab-struct custom-tab-1">
						<ul role="tablist" class="nav nav-tabs" id="right_sidebar_tab">
							<li class="active" role="presentation"><a aria-expanded="true"  data-toggle="tab" role="tab" id="chat_tab_btn" href="#chat_tab">chat</a></li>
							<li role="presentation" class=""><a  data-toggle="tab" id="messages_tab_btn" role="tab" href="#messages_tab" aria-expanded="false">messages</a></li>
							<li role="presentation" class=""><a  data-toggle="tab" id="todo_tab_btn" role="tab" href="#todo_tab" aria-expanded="false">todo</a></li>
						</ul>
						<div class="tab-content" id="right_sidebar_content">
							<div  id="chat_tab" class="tab-pane fade active in" role="tabpanel">
								<div class="chat-cmplt-wrap">
									<div class="chat-box-wrap">
										<div class="add-friend">
											<a href="javascript:void(0)" class="inline-block txt-grey">
												<i class="zmdi zmdi-more"></i>
											</a>	
											<span class="inline-block txt-dark">users</span>
											<a href="javascript:void(0)" class="inline-block text-right txt-grey"><i class="zmdi zmdi-plus"></i></a>
											<div class="clearfix"></div>
										</div>
										<form role="search" class="chat-search pl-15 pr-15 pb-15">
											<div class="input-group">
												<input type="text" id="example-input1-group2" name="example-input1-group2" class="form-control" placeholder="Search">
												<span class="input-group-btn">
												<button type="button" class="btn  btn-default"><i class="zmdi zmdi-search"></i></button>
												</span>
											</div>
										</form>
										<div id="chat_list_scroll">
											<div class="nicescroll-bar">
												<ul class="chat-list-wrap">
													<li class="chat-list">
														<div class="chat-body">
															<a href="javascript:void(0)">
																<div class="chat-data">
																	<img class="user-img img-circle"  src="dist/img/user.png" alt="user"/>
																	<div class="user-data">
																		<span class="name block capitalize-font">Clay Masse</span>
																		<span class="time block truncate txt-grey">No one saves us but ourselves.</span>
																	</div>
																	<div class="status away"></div>
																	<div class="clearfix"></div>
																</div>
															</a>
															<a href="javascript:void(0)">
																<div class="chat-data">
																	<img class="user-img img-circle"  src="dist/img/user1.png" alt="user"/>
																	<div class="user-data">
																		<span class="name block capitalize-font">Evie Ono</span>
																		<span class="time block truncate txt-grey">Unity is strength</span>
																	</div>
																	<div class="status offline"></div>
																	<div class="clearfix"></div>
																</div>
															</a>
															<a href="javascript:void(0)">
																<div class="chat-data">
																	<img class="user-img img-circle"  src="dist/img/user2.png" alt="user"/>
																	<div class="user-data">
																		<span class="name block capitalize-font">Madalyn Rascon</span>
																		<span class="time block truncate txt-grey">Respect yourself if you would have others respect you.</span>
																	</div>
																	<div class="status online"></div>
																	<div class="clearfix"></div>
																</div>
															</a>
															<a href="javascript:void(0)">
																<div class="chat-data">
																	<img class="user-img img-circle"  src="dist/img/user3.png" alt="user"/>
																	<div class="user-data">
																		<span class="name block capitalize-font">Mitsuko Heid</span>
																		<span class="time block truncate txt-grey">I’m thankful.</span>
																	</div>
																	<div class="status online"></div>
																	<div class="clearfix"></div>
																</div>
															</a>
															<a href="javascript:void(0)">
																<div class="chat-data">
																	<img class="user-img img-circle"  src="dist/img/user.png" alt="user"/>
																	<div class="user-data">
																		<span class="name block capitalize-font">Ezequiel Merideth</span>
																		<span class="time block truncate txt-grey">Patience is bitter.</span>
																	</div>
																	<div class="status offline"></div>
																	<div class="clearfix"></div>
																</div>
															</a>
															<a href="javascript:void(0)">
																<div class="chat-data">
																	<img class="user-img img-circle"  src="dist/img/user1.png" alt="user"/>
																	<div class="user-data">
																		<span class="name block capitalize-font">Jonnie Metoyer</span>
																		<span class="time block truncate txt-grey">Genius is eternal patience.</span>
																	</div>
																	<div class="status online"></div>
																	<div class="clearfix"></div>
																</div>
															</a>
															<a href="javascript:void(0)">
																<div class="chat-data">
																	<img class="user-img img-circle"  src="dist/img/user2.png" alt="user"/>
																	<div class="user-data">
																		<span class="name block capitalize-font">Angelic Lauver</span>
																		<span class="time block truncate txt-grey">Every burden is a blessing.</span>
																	</div>
																	<div class="status away"></div>
																	<div class="clearfix"></div>
																</div>
															</a>
															<a href="javascript:void(0)">
																<div class="chat-data">
																	<img class="user-img img-circle"  src="dist/img/user3.png" alt="user"/>
																	<div class="user-data">
																		<span class="name block capitalize-font">Priscila Shy</span>
																		<span class="time block truncate txt-grey">Wise to resolve, and patient to perform.</span>
																	</div>
																	<div class="status online"></div>
																	<div class="clearfix"></div>
																</div>
															</a>
															<a href="javascript:void(0)">
																<div class="chat-data">
																	<img class="user-img img-circle"  src="dist/img/user4.png" alt="user"/>
																	<div class="user-data">
																		<span class="name block capitalize-font">Linda Stack</span>
																		<span class="time block truncate txt-grey">Our patience will achieve more than our force.</span>
																	</div>
																	<div class="status away"></div>
																	<div class="clearfix"></div>
																</div>
															</a>
														</div>
													</li>
												</ul>
											</div>
										</div>
									</div>
									<div class="recent-chat-box-wrap">
										<div class="recent-chat-wrap">
											<div class="panel-heading ma-0">
												<div class="goto-back">
													<a  id="goto_back" href="javascript:void(0)" class="inline-block txt-grey">
														<i class="zmdi zmdi-chevron-left"></i>
													</a>	
													<span class="inline-block txt-dark">ryan</span>
													<a href="javascript:void(0)" class="inline-block text-right txt-grey"><i class="zmdi zmdi-more"></i></a>
													<div class="clearfix"></div>
												</div>
											</div>
											<div class="panel-wrapper collapse in">
												<div class="panel-body pa-0">
													<div class="chat-content">
														<ul class="nicescroll-bar pt-20">
															<li class="friend">
																<div class="friend-msg-wrap">
																	<img class="user-img img-circle block pull-left"  src="dist/img/user.png" alt="user"/>
																	<div class="msg pull-left">
																		<p>Hello Jason, how are you, it's been a long time since we last met?</p>
																		<div class="msg-per-detail text-right">
																			<span class="msg-time txt-grey">2:30 PM</span>
																		</div>
																	</div>
																	<div class="clearfix"></div>
																</div>	
															</li>
															<li class="self mb-10">
																<div class="self-msg-wrap">
																	<div class="msg block pull-right"> Oh, hi Sarah I'm have got a new job now and is going great.
																		<div class="msg-per-detail text-right">
																			<span class="msg-time txt-grey">2:31 pm</span>
																		</div>
																	</div>
																	<div class="clearfix"></div>
																</div>	
															</li>
															<li class="self">
																<div class="self-msg-wrap">
																	<div class="msg block pull-right">  How about you?
																		<div class="msg-per-detail text-right">
																			<span class="msg-time txt-grey">2:31 pm</span>
																		</div>
																	</div>
																	<div class="clearfix"></div>
																</div>	
															</li>
															<li class="friend">
																<div class="friend-msg-wrap">
																	<img class="user-img img-circle block pull-left"  src="dist/img/user.png" alt="user"/>
																	<div class="msg pull-left"> 
																		<p>Not too bad.</p>
																		<div class="msg-per-detail  text-right">
																			<span class="msg-time txt-grey">2:35 pm</span>
																		</div>
																	</div>
																	<div class="clearfix"></div>
																</div>	
															</li>
														</ul>
													</div>
													<div class="input-group">
														<input type="text" id="input_msg_send" name="send-msg" class="input-msg-send form-control" placeholder="Type something">
														<div class="input-group-btn emojis">
															<div class="dropup">
																<button type="button" class="btn  btn-default  dropdown-toggle" data-toggle="dropdown" ><i class="zmdi zmdi-mood"></i></button>
																<ul class="dropdown-menu dropdown-menu-right">
																	<li><a href="javascript:void(0)">Action</a></li>
																	<li><a href="javascript:void(0)">Another action</a></li>
																	<li class="divider"></li>
																	<li><a href="javascript:void(0)">Separated link</a></li>
																</ul>
															</div>
														</div>
														<div class="input-group-btn attachment">
															<div class="fileupload btn  btn-default"><i class="zmdi zmdi-attachment-alt"></i>
																<input type="file" class="upload">
															</div>
														</div>
													</div>
												</div>
											</div>
										</div>
									</div>
								</div>
							</div>
								
							<div id="messages_tab" class="tab-pane fade" role="tabpanel">
								<div class="message-box-wrap">
									<div class="msg-search">
										<a href="javascript:void(0)" class="inline-block txt-grey">
											<i class="zmdi zmdi-more"></i>
										</a>	
										<span class="inline-block txt-dark">messages</span>
										<a href="javascript:void(0)" class="inline-block text-right txt-grey"><i class="zmdi zmdi-search"></i></a>
										<div class="clearfix"></div>
									</div>
									<div class="set-height-wrap">
										<div class="streamline message-box nicescroll-bar">
											<a href="javascript:void(0)">
												<div class="sl-item unread-message">
													<div class="sl-avatar avatar avatar-sm avatar-circle">
														<img class="img-responsive img-circle" src="dist/img/user.png" alt="avatar"/>
													</div>
													<div class="sl-content">
														<span class="inline-block capitalize-font   pull-left message-per">Clay Masse</span>
														<span class="inline-block font-11  pull-right message-time">12:28 AM</span>
														<div class="clearfix"></div>
														<span class=" truncate message-subject">Themeforest message sent via your envato market profile</span>
														<p class="txt-grey truncate">Neque porro quisquam est qui dolorem ipsu messm quia dolor sit amet, consectetur, adipisci velit</p>
													</div>
												</div>
											</a>
											<a href="javascript:void(0)">
												<div class="sl-item">
													<div class="sl-avatar avatar avatar-sm avatar-circle">
														<img class="img-responsive img-circle" src="dist/img/user1.png" alt="avatar"/>
													</div>
													<div class="sl-content">
														<span class="inline-block capitalize-font   pull-left message-per">Evie Ono</span>
														<span class="inline-block font-11  pull-right message-time">1 Feb</span>
														<div class="clearfix"></div>
														<span class=" truncate message-subject">Pogody theme support</span>
														<p class="txt-grey truncate">Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit</p>
													</div>
												</div>
											</a>
											<a href="javascript:void(0)">
												<div class="sl-item">
													<div class="sl-avatar avatar avatar-sm avatar-circle">
														<img class="img-responsive img-circle" src="dist/img/user2.png" alt="avatar"/>
													</div>
													<div class="sl-content">
														<span class="inline-block capitalize-font   pull-left message-per">Madalyn Rascon</span>
														<span class="inline-block font-11  pull-right message-time">31 Jan</span>
														<div class="clearfix"></div>
														<span class=" truncate message-subject">Congratulations from design nominees</span>
														<p class="txt-grey truncate">Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit</p>
													</div>
												</div>
											</a>
											<a href="javascript:void(0)">
												<div class="sl-item unread-message">
													<div class="sl-avatar avatar avatar-sm avatar-circle">
														<img class="img-responsive img-circle" src="dist/img/user3.png" alt="avatar"/>
													</div>
													<div class="sl-content">
														<span class="inline-block capitalize-font   pull-left message-per">Ezequiel Merideth</span>
														<span class="inline-block font-11  pull-right message-time">29 Jan</span>
														<div class="clearfix"></div>
														<span class=" truncate message-subject">Themeforest item support message</span>
														<p class="txt-grey truncate">Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit</p>
													</div>
												</div>
											</a>
											<a href="javascript:void(0)">
												<div class="sl-item unread-message">
													<div class="sl-avatar avatar avatar-sm avatar-circle">
														<img class="img-responsive img-circle" src="dist/img/user4.png" alt="avatar"/>
													</div>
													<div class="sl-content">
														<span class="inline-block capitalize-font   pull-left message-per">Jonnie Metoyer</span>
														<span class="inline-block font-11  pull-right message-time">27 Jan</span>
														<div class="clearfix"></div>
														<span class=" truncate message-subject">Help with beavis contact form</span>
														<p class="txt-grey truncate">Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit</p>
													</div>
												</div>
											</a>
											<a href="javascript:void(0)">
												<div class="sl-item">
													<div class="sl-avatar avatar avatar-sm avatar-circle">
														<img class="img-responsive img-circle" src="dist/img/user.png" alt="avatar"/>
													</div>
													<div class="sl-content">
														<span class="inline-block capitalize-font   pull-left message-per">Priscila Shy</span>
														<span class="inline-block font-11  pull-right message-time">19 Jan</span>
														<div class="clearfix"></div>
														<span class=" truncate message-subject">Your uploaded theme is been selected</span>
														<p class="txt-grey truncate">Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit</p>
													</div>
												</div>
											</a>
											<a href="javascript:void(0)">
												<div class="sl-item">
													<div class="sl-avatar avatar avatar-sm avatar-circle">
														<img class="img-responsive img-circle" src="dist/img/user1.png" alt="avatar"/>
													</div>
													<div class="sl-content">
														<span class="inline-block capitalize-font   pull-left message-per">Linda Stack</span>
														<span class="inline-block font-11  pull-right message-time">13 Jan</span>
														<div class="clearfix"></div>
														<span class=" truncate message-subject"> A new rating has been received</span>
														<p class="txt-grey truncate">Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit</p>
													</div>
												</div>
											</a>
										</div>
									</div>
								</div>
							</div>
							<div  id="todo_tab" class="tab-pane fade" role="tabpanel">
								<div class="todo-box-wrap">
									<div class="add-todo">
										<a href="javascript:void(0)" class="inline-block txt-grey">
											<i class="zmdi zmdi-more"></i>
										</a>	
										<span class="inline-block txt-dark">todo list</span>
										<a href="javascript:void(0)" class="inline-block text-right txt-grey"><i class="zmdi zmdi-plus"></i></a>
										<div class="clearfix"></div>
									</div>
									<div class="set-height-wrap">
										<!-- Todo-List -->
										<ul class="todo-list nicescroll-bar">
											<li class="todo-item">
												<div class="checkbox checkbox-default">
													<input type="checkbox" id="checkbox01"/>
													<label for="checkbox01">Record The First Episode</label>
												</div>
											</li>
											<li>
												<hr class="light-grey-hr"/>
											</li>
											<li class="todo-item">
												<div class="checkbox checkbox-pink">
													<input type="checkbox" id="checkbox02"/>
													<label for="checkbox02">Prepare The Conference Schedule</label>
												</div>
											</li>
											<li>
												<hr class="light-grey-hr"/>
											</li>
											<li class="todo-item">
												<div class="checkbox checkbox-warning">
													<input type="checkbox" id="checkbox03" checked/>
													<label for="checkbox03">Decide The Live Discussion Time</label>
												</div>
											</li>
											<li>
												<hr class="light-grey-hr"/>
											</li>
											<li class="todo-item">
												<div class="checkbox checkbox-success">
													<input type="checkbox" id="checkbox04" checked/>
													<label for="checkbox04">Prepare For The Next Project</label>
												</div>
											</li>
											<li>
												<hr class="light-grey-hr"/>
											</li>
											<li class="todo-item">
												<div class="checkbox checkbox-danger">
													<input type="checkbox" id="checkbox05" checked/>
													<label for="checkbox05">Finish Up AngularJs Tutorial</label>
												</div>
											</li>
											<li>
												<hr class="light-grey-hr"/>
											</li>
											<li class="todo-item">
												<div class="checkbox checkbox-purple">
													<input type="checkbox" id="checkbox06" checked/>
													<label for="checkbox06">Finish Infinity Project</label>
												</div>
											</li>
											<li>
												<hr class="light-grey-hr"/>
											</li>
										</ul>
										<!-- /Todo-List -->
									</div>
								</div>
							</div>
						</div>
					</div>
				</li>
			</ul>
		</div>
		<!-- /Right Sidebar Menu -->
		
		

        <!-- Main Content -->
		<form action="#" runat="server">
		<div class="page-wrapper">
            <div class="container-fluid pt-25">
					<!-- Title -->
				<div class="row heading-bg">
					<div class="col-lg-3 col-md-4 col-sm-4 col-xs-12">
					  <h5 class="txt-dark">Profile</h5>
					</div>
					<!-- Breadcrumb -->
					<div class="col-lg-9 col-sm-8 col-md-8 col-xs-12">
					  <ol class="breadcrumb">
						<li><a href="researchindex.html">Home</a></li>
						<li><a href="researchinbox.html"><span>Inbox</span></a></li>
						<li class="active"><span>profile</span></li>
					  </ol>
					</div>
					<!-- /Breadcrumb -->
				</div>
				<!-- /Title -->
				<!-- Row -->
				<div class="row">
					<div class="col-lg-3 col-xs-12">
						<div class="panel panel-default card-view  pa-0">
							<div class="panel-wrapper collapse in">
								<div class="panel-body  pa-0">
									<div class="profile-box">
										<div class="profile-cover-pic">
											<div class="fileupload btn btn-default">
												<span class="btn-text">edit</span>
												<input class="upload" type="file">
											</div>
											<div class="profile-image-overlay"></div>
										</div>
										<div class="profile-info text-center">
											<div class="profile-img-wrap">
												<img class="inline-block mb-10" src="dist/img/mock1.jpg" alt="user"/>
												<div class="fileupload btn btn-default">
													<span class="btn-text">edit</span>
													<input class="upload" type="file">
												</div>
											</div>	
											<h5 class="block mt-10 mb-5 weight-500 capitalize-font txt-info">
<a runat="server" href="~/Views/Manage" title="Manage your account">Hello, <%: Context.User.Identity.GetUserName()  %> !</a>											</h5>
											<h6 class="block capitalize-font pb-20">
											</h6>
										</div>	
										<div class="social-info">
											<div class="row">
												<div class="col-xs-4 text-center">
													<span class="counts block head-font"><span class="counter-anim">345</span></span>
													<span class="counts-text block">post</span>
												</div>
												<div class="col-xs-4 text-center">
													<span class="counts block head-font"><span class="counter-anim">246</span></span>
													<span class="counts-text block">followers</span>
												</div>
												<div class="col-xs-4 text-center">
													<span class="counts block head-font"><span class="counter-anim">898</span></span>
													<span class="counts-text block">tweets</span>
												</div>
											</div>
											<button class="btn btn-info btn-block  btn-anim mt-30" data-toggle="modal" data-target="#myModal"><i class="fa fa-pencil"></i><span class="btn-text">edit profile</span></button>
											<div id="myModal" class="modal fade in" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
												<div class="modal-dialog">
													<div class="modal-content">
														<div class="modal-header">
															<button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
															<h5 class="modal-title" id="myModalLabel">Edit Profile</h5>
														</div>
														<div class="modal-body">
															<!-- Row -->
															<div class="row">
																<div class="col-lg-12">
																	<div class="">
																		<div class="panel-wrapper collapse in">
																			<div class="panel-body pa-0">
																				<div class="col-sm-12 col-xs-12">
																					<div class="form-wrap">
<%--																						<form action="#" runat="server">--%>
																							<div class="form-body overflow-hide">
																								<div class="form-group">
																									<label class="control-label mb-10" for="exampleInputuname_1">Name</label>
																									<div class="input-group">
																										<div class="input-group-addon"><i class="icon-user"></i></div>
																										<input type="text" runat="server" required ="required" class="form-control" id="FName" placeholder="willard bryant">
																									</div>
																								</div>
																								<div class="form-group">
																									<label class="control-label mb-10" for="exampleInputEmail_1">Email address</label>
																									<div class="input-group">
																										<div class="input-group-addon"><i class="icon-envelope-open"></i></div>
																										<input type="email" class="form-control" runat="server" required ="required" id="Email" placeholder="xyz@gmail.com">
																									</div>
																								</div>
																								<div class="form-group">
																									<label class="control-label mb-10" for="exampleInputContact_1">Contact number</label>
																									<div class="input-group">
																										<div class="input-group-addon"><i class="icon-phone"></i></div>
																										<input type="email" class="form-control" runat="server" required ="required" id="CNumber" placeholder="+102 9388333">
																									</div>
																								</div>
																								<div class="form-group">
																									<label class="control-label mb-10" for="exampleInputpwd_1">Password</label>
																									<div class="input-group">
																										<div class="input-group-addon"><i class="icon-lock"></i></div>
																										<input type="password" runat="server" required ="required" class="form-control" id="Password" placeholder="Enter pwd" value="password">
																									</div>
																								</div>
																								<div class="form-group">
																									<label class="control-label mb-10">Gender</label>
																									<div>
																										<div class="radio">
																											<input type="radio" runat="server" name="radio1" id="Gender1" value="option1" checked="">
																											<label for="radio_1">
																											M
																											</label>
																										</div>
																										<div class="radio">
																											<input type="radio" runat="server" name="radio1" id="Gender2" value="option2">
																											<label for="radio_2">
																											F
																											</label>
																										</div>
																									</div>
																								</div>
																								<div class="form-group">
																									<label class="control-label mb-10">Country</label>
																									<select class="form-control" runat="server" id="Country" data-placeholder="Choose a Category" tabindex="1">
																										<option value="Category 1">USA</option>
																										<option value="Category 2">Austrailia</option>
																										<option value="Category 3">India</option>
																										<option value="Category 4">UK</option>
																									</select>
																								</div>
																							</div>
																							<div class="form-actions mt-10">
<%--                                                      <asp:Button ID="insert_research" runat="server" OnClick="AddResearch_Click" Text="save" class="btn btn-success btn-icon left-icon mr-10 pull-left" CausesValidation="False" OnClientClick="AddResearch_Click"/>--%>
																								<button type="submit" runat="server"  OnClientClick="UpdateProfile_Click" class="btn btn-success mr-10 mb-30">Update profile</button>
																							</div>				
<%--																						</form>--%>
																					</div>
																				</div>
																			</div>
																		</div>
																	</div>
																</div>
															</div>
														</div>
														<div class="modal-footer">
															<button type="button" class="btn btn-success waves-effect" data-dismiss="modal">Save</button>
															<button type="button" class="btn btn-default waves-effect" data-dismiss="modal">Cancel</button>
														</div>
													</div>
													<!-- /.modal-content -->
												</div>
												<!-- /.modal-dialog -->
											</div>
										</div>
									</div>
								</div>
							</div>
						</div>
					</div>
					<div class="col-lg-9 col-xs-12">
						<div class="panel panel-default card-view pa-0">
							<div class="panel-wrapper collapse in">
								<div  class="panel-body pb-0">
									<div  class="tab-struct custom-tab-1">
										<ul role="tablist" class="nav nav-tabs nav-tabs-responsive" id="myTabs_8">
											<li class="active" role="presentation"><a  data-toggle="tab" id="profile_tab_8" role="tab" href="#profile_8" aria-expanded="false"><span>Researches</span></a></li>
											<li  role="presentation" class="next"><a aria-expanded="true"  data-toggle="tab" role="tab" id="follo_tab_8" href="#follo_8"><span>followers<span class="inline-block">(246)</span></span></a></li>
											<li role="presentation" class=""><a  data-toggle="tab" id="photos_tab_8" role="tab" href="#photos_8" aria-expanded="false"><span>photos</span></a></li>
											<li role="presentation" class=""><a  data-toggle="tab" id="earning_tab_8" role="tab" href="#earnings_8" aria-expanded="false"><span>Timeline</span></a></li>
											<li role="presentation" class=""><a  data-toggle="tab" id="settings_tab_8" role="tab" href="#settings_8" aria-expanded="false"><span>settings</span></a></li>
                                            <li role="presentation" class=""><a  data-toggle="tab" id="filemanager_tab_8" role="tab" href="#filemanager_8" aria-expanded="false"><span>File Manager</span></a></li>
											<li class="dropdown" role="presentation">
												<a  data-toggle="dropdown" class="dropdown-toggle" id="myTabDrop_7" href="#" aria-expanded="false"><span>More</span> <span class="caret"></span></a>
												<ul id="myTabDrop_7_contents"  class="dropdown-menu">
													<li class=""><a  data-toggle="tab" id="dropdown_13_tab" role="tab" href="#dropdown_13" aria-expanded="true">About</a></li>
													<li class=""><a  data-toggle="tab" id="dropdown_14_tab" role="tab" href="#dropdown_14" aria-expanded="false">Followings</a></li>
													<li class=""><a  data-toggle="tab" id="dropdown_15_tab" role="tab" href="#dropdown_15" aria-expanded="false">Likes</a></li>
													<li class=""><a  data-toggle="tab" id="dropdown_16_tab" role="tab" href="#dropdown_16" aria-expanded="false">Reviews</a></li>
												</ul>
											</li>
										</ul>
										<div class="tab-content" id="myTabContent_8">
											<div  id="profile_8" class="tab-pane fade active in" role="tabpanel">
												<div class="col-md-12">
													<div class="pt-20">
														<div class="streamline user-activity">
															<h5>My Researches</h5>
                                                          <p><br /></p>
                                                            <div id="popup" style="max-height:600px;overflow-y:scroll;">
                                      <asp:GridView ID="GridView1" AllowSorting ="True" AllowPaging ="True"  CssClass="table1" runat="server" AutoGenerateColumns="False" DataKeyNames="id" Width="1062px">  
                    <Columns>  
                        <asp:TemplateField HeaderText="Title">  
                            <EditItemTemplate>  
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Title") %>'></asp:TextBox>  
                            </EditItemTemplate>  
                            <ItemTemplate>  
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("Title") %>'></asp:Label>  
                            </ItemTemplate>  
                        </asp:TemplateField>  
                        <asp:TemplateField HeaderText="Sub Title">  
                            <EditItemTemplate>  
                                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("SubTitle") %>'></asp:TextBox>  
                            </EditItemTemplate>  
                            <ItemTemplate>  
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("SubTitle") %>'></asp:Label>  
                            </ItemTemplate>  
                        </asp:TemplateField>  
                        <asp:TemplateField HeaderText="Authors Name">  
                            <EditItemTemplate>  
                                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("AuthorName") %>'></asp:TextBox>  
                            </EditItemTemplate>  
                            <ItemTemplate>  
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("AuthorName") %>'></asp:Label>  
                            </ItemTemplate>  
                        </asp:TemplateField>  
                        <asp:TemplateField HeaderText="Research Type">  
                            <EditItemTemplate>  
                                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("RType") %>'></asp:TextBox>  
                            </EditItemTemplate>  
                            <ItemTemplate>  
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("RType") %>'></asp:Label>  
                            </ItemTemplate>  
                        </asp:TemplateField>  
                        <asp:TemplateField HeaderText="Status">  
                            <EditItemTemplate>  
                                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Status") %>'></asp:TextBox>  
                            </EditItemTemplate>  
                            <ItemTemplate>  
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("Status") %>'></asp:Label>  
                            </ItemTemplate>  
                        </asp:TemplateField>  
                        <asp:TemplateField HeaderText="Description">  
                            <EditItemTemplate>  
                                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Description") %>'></asp:TextBox>  
                            </EditItemTemplate>  
                            <ItemTemplate>  
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("Description") %>'></asp:Label>  
                            </ItemTemplate>  
                        </asp:TemplateField>  
                        <asp:TemplateField HeaderText="Date Created">  
                            <EditItemTemplate>  
                                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("DateCreated") %>'></asp:TextBox>  
                            </EditItemTemplate>  
                            <ItemTemplate>  
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("DateCreated") %>'></asp:Label>  
                            </ItemTemplate>  
                        </asp:TemplateField>  
                    </Columns>  
                </asp:GridView>  
           </div>
														</div>
													</div>
												</div>
											</div>
											
											<div  id="follo_8" class="tab-pane fade" role="tabpanel">
												<div class="row">
													<div class="col-lg-12">
														<div class="followers-wrap">
															<ul class="followers-list-wrap">
																<li class="follow-list">
																	<div class="follo-body">
																		<div class="follo-data">
																			<img class="user-img img-circle"  src="dist/img/user.png" alt="user"/>
																			<div class="user-data">
																				<span class="name block capitalize-font">Clay Masse</span>
																				<span class="time block truncate txt-grey">No one saves us but ourselves.</span>
																			</div>
																			<button class="btn btn-success pull-right btn-xs fixed-btn">Follow</button>
																			<div class="clearfix"></div>
																		</div>
																		<div class="follo-data">
																			<img class="user-img img-circle"  src="dist/img/user1.png" alt="user"/>
																			<div class="user-data">
																				<span class="name block capitalize-font">Evie Ono</span>
																				<span class="time block truncate txt-grey">Unity is strength</span>
																			</div>
																			<button class="btn btn-success btn-outline pull-right btn-xs fixed-btn">following</button>
																			<div class="clearfix"></div>
																		</div>
																		<div class="follo-data">
																			<img class="user-img img-circle"  src="dist/img/user2.png" alt="user"/>
																			<div class="user-data">
																				<span class="name block capitalize-font">Madalyn Rascon</span>
																				<span class="time block truncate txt-grey">Respect yourself if you would have others respect you.</span>
																			</div>
																			<button class="btn btn-success btn-outline pull-right btn-xs fixed-btn">following</button>
																			<div class="clearfix"></div>
																		</div>
																		<div class="follo-data">
																			<img class="user-img img-circle"  src="dist/img/user3.png" alt="user"/>
																			<div class="user-data">
																				<span class="name block capitalize-font">Mitsuko Heid</span>
																				<span class="time block truncate txt-grey">I’m thankful.</span>
																			</div>
																			<button class="btn btn-success pull-right btn-xs fixed-btn">Follow</button>
																			<div class="clearfix"></div>
																		</div>
																		<div class="follo-data">
																			<img class="user-img img-circle"  src="dist/img/user.png" alt="user"/>
																			<div class="user-data">
																				<span class="name block capitalize-font">Ezequiel Merideth</span>
																				<span class="time block truncate txt-grey">Patience is bitter.</span>
																			</div>
																			<button class="btn btn-success pull-right btn-xs fixed-btn">Follow</button>
																			<div class="clearfix"></div>
																		</div>
																		<div class="follo-data">
																			<img class="user-img img-circle"  src="dist/img/user1.png" alt="user"/>
																			<div class="user-data">
																				<span class="name block capitalize-font">Jonnie Metoyer</span>
																				<span class="time block truncate txt-grey">Genius is eternal patience.</span>
																			</div>
																			<button class="btn btn-success btn-outline pull-right btn-xs fixed-btn">following</button>
																			<div class="clearfix"></div>
																		</div>
																	</div>
																</li>
															</ul>
														</div>
													</div>
												</div>
											</div>
											<div  id="photos_8" class="tab-pane fade" role="tabpanel">
												<div class="col-md-12 pb-20">
													<div class="gallery-wrap">
														<div class="portfolio-wrap project-gallery">
															<ul id="portfolio_1" class="portf auto-construct  project-gallery" data-col="4">
																<li  class="item"   data-src="dist/img/gallery/equal-size/mock1.jpg" data-sub-html="<h6>Bagwati</h6><p>Classic view from Rigwood Jetty on Coniston Water an old archive shot similar to an old post but a little later on.</p>" >
																	<a href="">
																	<img class="img-responsive" src="dist/img/gallery/equal-size/mock1.jpg"  alt="Image description" />
																	<span class="hover-cap">Bagwati</span>
																	</a>
																</li>
																<li class="item" data-src="dist/img/gallery/equal-size/mock2.jpg"   data-sub-html="<h6>Not a Keyboard</h6><p>Classic view from Rigwood Jetty on Coniston Water an old archive shot similar to an old post but a little later on.</p>">
																	<a href="">
																	<img class="img-responsive" src="dist/img/gallery/equal-size/mock2.jpg"  alt="Image description" />
																	<span class="hover-cap">Not a Keyboard</span>
																	</a>
																</li>
																<li class="item" data-src="dist/img/gallery/equal-size/mock3.jpg" data-sub-html="<h6>Into the Woods</h6><p>Classic view from Rigwood Jetty on Coniston Water an old archive shot similar to an old post but a little later on.</p>">
																	<a href="">
																	<img class="img-responsive" src="dist/img/gallery/equal-size/mock3.jpg"  alt="Image description" />
																	<span class="hover-cap">Into the Woods</span>
																	</a>
																</li>
																<li class="item" data-src="dist/img/gallery/equal-size/mock4.jpg"  data-sub-html="<h6>Ultra Saffire</h6><p>Classic view from Rigwood Jetty on Coniston Water an old archive shot similar to an old post but a little later on.</p>">
																	<a href="">
																	<img class="img-responsive" src="dist/img/gallery/equal-size/mock4.jpg"  alt="Image description" />
																	<span class="hover-cap"> Ultra Saffire</span>
																	</a>
																</li>
																
																<li class="item" data-src="dist/img/gallery/equal-size/mock5.jpg" data-sub-html="<h6>Happy Puppy</h6><p>Classic view from Rigwood Jetty on Coniston Water an old archive shot similar to an old post but a little later on.</p>">
																	<a href="">
																	<img class="img-responsive" src="dist/img/gallery/equal-size/mock5.jpg"  alt="Image description" />	
																	<span class="hover-cap">Happy Puppy</span>
																	</a>
																</li>
																<li class="item" data-src="dist/img/gallery/equal-size/mock6.jpg"  data-sub-html="<h6>Wooden Closet</h6><p>Classic view from Rigwood Jetty on Coniston Water an old archive shot similar to an old post but a little later on.</p>">
																	<a href="">
																	<img class="img-responsive" src="dist/img/gallery/equal-size/mock6.jpg"  alt="Image description" />
																	<span class="hover-cap">Wooden Closet</span>
																	</a>
																</li>
																<li class="item" data-src="dist/img/gallery/equal-size/mock7.jpg" data-sub-html="<h6>Happy Puppy</h6><p>Classic view from Rigwood Jetty on Coniston Water an old archive shot similar to an old post but a little later on.</p>">
																	<a href="">
																	<img class="img-responsive" src="dist/img/gallery/equal-size/mock7.jpg"  alt="Image description" />	
																	<span class="hover-cap">Happy Puppy</span>
																	</a>
																</li>
																<li class="item" data-src="dist/img/gallery/equal-size/mock8.jpg"  data-sub-html="<h6>Wooden Closet</h6><p>Classic view from Rigwood Jetty on Coniston Water an old archive shot similar to an old post but a little later on.</p>">
																	<a href="">
																	<img class="img-responsive" src="dist/img/gallery/equal-size/mock8.jpg"  alt="Image description" />
																	<span class="hover-cap">Wooden Closet</span>
																	</a>
																</li>
															</ul>
														</div>
													</div>
												</div>	
											</div>
											<div  id="earnings_8" class="tab-pane fade" role="tabpanel">
												<!-- Row -->
												<div class="row">
													<div class="col-lg-12">
														
                                                        <div class="panel panel-default card-view">
								<div class="panel-body">
									<ul class="timeline">
										<li>
											<div class="timeline-badge bg-yellow">
												<i class="icon-layers" ></i>
											</div>
											<div class="timeline-panel pa-30">
                                                <div class="panel-heading"  style="background-color:#0cb;">
												<div class="timeline-heading">
                                                    <div class="pull-left">
                                                        <div class="tmlphoto">
	                                                   <img src="dist/img/big/circle.jpg" alt="image" width="100" height="100" class="tmlphotoimg" />
                                                       </div><div class="clearfix"></div>
                                                    <h4 class="mb-5" style="color: #fff;"><strong>pogody</strong></h4>
													<h6 class="mb-15">1 september 15</h6>
										<h6 class="panel-title txt-dark"><p class="lead head-font mb-20" style="font-size:30px; color: #fff;">Responsive html5 template</p></h6>
									</div>
									<div class="pull-right">
										<div class="pull-left inline-block dropdown mr-15">
											<a class="dropdown-toggle" data-toggle="dropdown" href="#" aria-expanded="false" role="button"><i class="zmdi zmdi-more-vert"  style="color:#fff;"></i></a>
											<ul class="dropdown-menu bullet dropdown-menu-right"  role="menu">
												<li role="presentation"><a href="javascript:void(0)" role="menuitem"><i class="icon wb-reply" aria-hidden="true"></i>Edit</a></li>
												<li role="presentation"><a href="javascript:void(0)" role="menuitem"><i class="icon wb-share" aria-hidden="true"></i>Share</a></li>
												<li role="presentation"><a href="javascript:void(0)" role="menuitem"><i class="icon wb-trash" aria-hidden="true"></i>Delete</a></li>
											</ul>
										</div>
										
									</div>
                                                    </div><div class="clearfix"></div></div>
												<div class="timeline-body">
                                                    <div class="" style="height:auto; max-width: 100%;">
                                                    <img src="dist/img/big/circle.jpg" alt="image" width="500" height="500" class="tmlphotoimg2" />
                                                    </div>
                                                    <br>
													<p>Invitamus me testatur sed quod non dum animae tuae lacrimis ut libertatem deum rogus aegritudinis causet. Dicens hoc contra serpentibus isto.Invitamus me testatur sed quod non dum animae tuae lacrimis ut libertatem deum rogus aegritudinis causet. Dicens hoc contra serpentibus isto.</p><br>
                                                    <a href="#" class="dropdown-toggle" data-toggle="dropdown"><button class="btnmenuresearch">View</button></a>
                                                <a href="#" class="dropdown-toggle" data-toggle="dropdown"><button class="btnmenuresearch">Download</button></a>
                                                    
												</div>
											</div>
										</li>
										
										<li class="timeline-inverted">
											<div class="timeline-badge bg-pink">
												<i class="icon-layers" ></i>
											</div>
												<div class="timeline-panel pa-30">
                                                <div class="panel-heading"  style="background-color:#0cb;">
												<div class="timeline-heading">
                                                    <div class="pull-left">
                                                        <div class="tmlphoto">
	                                                   <img src="dist/img/big/circle.jpg" alt="image" width="100" height="100" class="tmlphotoimg" />
                                                       </div><div class="clearfix"></div>
                                                    <h4 class="mb-5" style="color: #fff;"><strong>pogody</strong></h4>
													<h6 class="mb-15">1 september 15</h6>
										<h6 class="panel-title txt-dark"><p class="lead head-font mb-20" style="font-size:30px; color: #fff;">Responsive html5 template</p></h6>
									</div>
									<div class="pull-right">
										<div class="pull-left inline-block dropdown mr-15">
											<a class="dropdown-toggle" data-toggle="dropdown" href="#" aria-expanded="false" role="button"><i class="zmdi zmdi-more-vert"  style="color:#fff;"></i></a>
											<ul class="dropdown-menu bullet dropdown-menu-right"  role="menu">
												<li role="presentation"><a href="javascript:void(0)" role="menuitem"><i class="icon wb-reply" aria-hidden="true"></i>Edit</a></li>
												<li role="presentation"><a href="javascript:void(0)" role="menuitem"><i class="icon wb-share" aria-hidden="true"></i>Share</a></li>
												<li role="presentation"><a href="javascript:void(0)" role="menuitem"><i class="icon wb-trash" aria-hidden="true"></i>Delete</a></li>
											</ul>
										</div>
										
									</div>
                                                    </div><div class="clearfix"></div></div>
												<div class="timeline-body">
                                                    <div class="" style="height:auto; max-width: 100%;">
                                                    <img src="dist/img/big/circle.jpg" alt="image" width="500" height="500" class="tmlphotoimg2" />
                                                    </div>
                                                    <br>
													<p>Invitamus me testatur sed quod non dum animae tuae lacrimis ut libertatem deum rogus aegritudinis causet. Dicens hoc contra serpentibus isto.Invitamus me testatur sed quod non dum animae tuae lacrimis ut libertatem deum rogus aegritudinis causet. Dicens hoc contra serpentibus isto.</p><br>
                                                    <a href="#" class="dropdown-toggle" data-toggle="dropdown"><button class="btnmenuresearch">View</button></a>
                                                <a href="#" class="dropdown-toggle" data-toggle="dropdown"><button class="btnmenuresearch">Download</button></a>
                                                    
												</div>
											</div>
										</li>
										
										<li>
											<div class="timeline-badge bg-red">
												<i class="icon-layers" ></i>
											</div>
											<div class="timeline-panel pa-30">
                                                <div class="panel-heading"  style="background-color:#0cb;">
												<div class="timeline-heading">
                                                    <div class="pull-left">
                                                        <div class="tmlphoto">
	                                                   <img src="dist/img/big/circle.jpg" alt="image" width="100" height="100" class="tmlphotoimg" />
                                                       </div><div class="clearfix"></div>
                                                    <h4 class="mb-5" style="color: #fff;"><strong>pogody</strong></h4>
													<h6 class="mb-15">1 september 15</h6>
										<h6 class="panel-title txt-dark"><p class="lead head-font mb-20" style="font-size:30px; color: #fff;">Responsive html5 template</p></h6>
									</div>
									<div class="pull-right">
										<div class="pull-left inline-block dropdown mr-15">
											<a class="dropdown-toggle" data-toggle="dropdown" href="#" aria-expanded="false" role="button"><i class="zmdi zmdi-more-vert"  style="color:#fff;"></i></a>
											<ul class="dropdown-menu bullet dropdown-menu-right"  role="menu">
												<li role="presentation"><a href="javascript:void(0)" role="menuitem"><i class="icon wb-reply" aria-hidden="true"></i>Edit</a></li>
												<li role="presentation"><a href="javascript:void(0)" role="menuitem"><i class="icon wb-share" aria-hidden="true"></i>Share</a></li>
												<li role="presentation"><a href="javascript:void(0)" role="menuitem"><i class="icon wb-trash" aria-hidden="true"></i>Delete</a></li>
											</ul>
										</div>
										
									</div>
                                                    </div><div class="clearfix"></div></div>
												<div class="timeline-body">
                                                    <div class="" style="height:auto; max-width: 100%;">
                                                    <img src="dist/img/big/circle.jpg" alt="image" width="500" height="500" class="tmlphotoimg2" />
                                                    </div>
                                                    <br>
													<p>Invitamus me testatur sed quod non dum animae tuae lacrimis ut libertatem deum rogus aegritudinis causet. Dicens hoc contra serpentibus isto.Invitamus me testatur sed quod non dum animae tuae lacrimis ut libertatem deum rogus aegritudinis causet. Dicens hoc contra serpentibus isto.</p><br>
                                                    <a href="#" class="dropdown-toggle" data-toggle="dropdown"><button class="btnmenuresearch">View</button></a>
                                                <a href="#" class="dropdown-toggle" data-toggle="dropdown"><button class="btnmenuresearch">Download</button></a>
                                                    
												</div>
											</div>
										</li>
										
										<li class="timeline-inverted">
											<div class="timeline-badge bg-blue">
												<i class="icon-layers" ></i>
											</div>
										<div class="timeline-panel pa-30">
                                                <div class="panel-heading"  style="background-color:#0cb;">
												<div class="timeline-heading">
                                                    <div class="pull-left">
                                                        <div class="tmlphoto">
	                                                   <img src="dist/img/big/circle.jpg" alt="image" width="100" height="100" class="tmlphotoimg" />
                                                       </div><div class="clearfix"></div>
                                                    <h4 class="mb-5" style="color: #fff;"><strong>pogody</strong></h4>
													<h6 class="mb-15">1 september 15</h6>
										<h6 class="panel-title txt-dark"><p class="lead head-font mb-20" style="font-size:30px; color: #fff;">Responsive html5 template</p></h6>
									</div>
									<div class="pull-right">
										<div class="pull-left inline-block dropdown mr-15">
											<a class="dropdown-toggle" data-toggle="dropdown" href="#" aria-expanded="false" role="button"><i class="zmdi zmdi-more-vert"  style="color:#fff;"></i></a>
											<ul class="dropdown-menu bullet dropdown-menu-right"  role="menu">
												<li role="presentation"><a href="javascript:void(0)" role="menuitem"><i class="icon wb-reply" aria-hidden="true"></i>Edit</a></li>
												<li role="presentation"><a href="javascript:void(0)" role="menuitem"><i class="icon wb-share" aria-hidden="true"></i>Share</a></li>
												<li role="presentation"><a href="javascript:void(0)" role="menuitem"><i class="icon wb-trash" aria-hidden="true"></i>Delete</a></li>
											</ul>
										</div>
										
									</div>
                                                    </div><div class="clearfix"></div></div>
												<div class="timeline-body">
                                                    <div class="" style="height:auto; max-width: 100%;">
                                                    <img src="dist/img/big/circle.jpg" alt="image" width="500" height="500" class="tmlphotoimg2" />
                                                    </div>
                                                    <br>
													<p>Invitamus me testatur sed quod non dum animae tuae lacrimis ut libertatem deum rogus aegritudinis causet. Dicens hoc contra serpentibus isto.Invitamus me testatur sed quod non dum animae tuae lacrimis ut libertatem deum rogus aegritudinis causet. Dicens hoc contra serpentibus isto.</p><br>
                                                    <a href="#" class="dropdown-toggle" data-toggle="dropdown"><button class="btnmenuresearch">View</button></a>
                                                <a href="#" class="dropdown-toggle" data-toggle="dropdown"><button class="btnmenuresearch">Download</button></a>
                                                    
												</div>
											</div>
										</li>
										
										<li>
											<div class="timeline-badge bg-green">
												<i class="icon-layers" ></i>
											</div>
											<div class="timeline-panel pa-30">
                                                <div class="panel-heading"  style="background-color:#0cb;">
												<div class="timeline-heading">
                                                    <div class="pull-left">
                                                        <div class="tmlphoto">
	                                                   <img src="dist/img/big/circle.jpg" alt="image" width="100" height="100" class="tmlphotoimg" />
                                                       </div><div class="clearfix"></div>
                                                    <h4 class="mb-5" style="color: #fff;"><strong>pogody</strong></h4>
													<h6 class="mb-15">1 september 15</h6>
										<h6 class="panel-title txt-dark"><p class="lead head-font mb-20" style="font-size:30px; color: #fff;">Responsive html5 template</p></h6>
									</div>
									<div class="pull-right">
										<div class="pull-left inline-block dropdown mr-15">
											<a class="dropdown-toggle" data-toggle="dropdown" href="#" aria-expanded="false" role="button"><i class="zmdi zmdi-more-vert"  style="color:#fff;"></i></a>
											<ul class="dropdown-menu bullet dropdown-menu-right"  role="menu">
												<li role="presentation"><a href="javascript:void(0)" role="menuitem"><i class="icon wb-reply" aria-hidden="true"></i>Edit</a></li>
												<li role="presentation"><a href="javascript:void(0)" role="menuitem"><i class="icon wb-share" aria-hidden="true"></i>Share</a></li>
												<li role="presentation"><a href="javascript:void(0)" role="menuitem"><i class="icon wb-trash" aria-hidden="true"></i>Delete</a></li>
											</ul>
										</div>
										
									</div>
                                                    </div><div class="clearfix"></div></div>
												<div class="timeline-body">
                                                    <div class="" style="height:auto; max-width: 100%;">
                                                    <img src="dist/img/big/circle.jpg" alt="image" width="500" height="500" class="tmlphotoimg2" />
                                                    </div>
                                                    <br>
													<p>Invitamus me testatur sed quod non dum animae tuae lacrimis ut libertatem deum rogus aegritudinis causet. Dicens hoc contra serpentibus isto.Invitamus me testatur sed quod non dum animae tuae lacrimis ut libertatem deum rogus aegritudinis causet. Dicens hoc contra serpentibus isto.</p><br>
                                                    <a href="#" class="dropdown-toggle" data-toggle="dropdown"><button class="btnmenuresearch">View</button></a>
                                                <a href="#" class="dropdown-toggle" data-toggle="dropdown"><button class="btnmenuresearch">Download</button></a>
                                                    
												</div>
											</div>
										</li>
										
										<li class="clearfix no-float"></li>
									</ul>
								</div>
							</div>
                                                        
													</div>
												</div>
											</div>
											<div  id="settings_8" class="tab-pane fade" role="tabpanel">
												<!-- Row -->
												<div class="row">
													<div class="col-lg-12">
														<div class="">
															<div class="panel-wrapper collapse in">
																<div class="panel-body pa-0">
																	<div class="col-sm-12 col-xs-12">
																		<div class="form-wrap">
<%--																			<form action="#">--%>
																				<div class="form-body overflow-hide">
																					<div class="form-group">
																						<label class="control-label mb-10" for="exampleInputuname_01">Name</label>
																						<div class="input-group">
																							<div class="input-group-addon"><i class="icon-user"></i></div>
																							<input type="text" runat="server" required ="required" class="form-control" id="FName2" placeholder="willard bryant">
																						</div>
																					</div>
																					<div class="form-group">
																						<label class="control-label mb-10" for="exampleInputEmail_01">Email address</label>
																						<div class="input-group">
																							<div class="input-group-addon"><i class="icon-envelope-open"></i></div>
																							<input type="email" runat="server" required ="required" class="form-control" id="Email2" placeholder="xyz@gmail.com">
																						</div>
																					</div>
																					<div class="form-group">
																						<label class="control-label mb-10" for="exampleInputContact_01">Contact number</label>
																						<div class="input-group">
																							<div class="input-group-addon"><i class="icon-phone"></i></div>
																							<input type="email" runat="server" required ="required" class="form-control" id="CNumber2" placeholder="+102 9388333">
																						</div>
																					</div>
																					<div class="form-group">
																						<label class="control-label mb-10" for="exampleInputpwd_01">Password</label>
																						<div class="input-group">
																							<div class="input-group-addon"><i class="icon-lock"></i></div>
																							<input type="password" runat="server" required ="required" class="form-control" id="Password2" placeholder="Enter pwd" value="password">
																						</div>
																					</div>
																					<div class="form-group">
																						<label class="control-label mb-10">Gender</label>
																						<div>
																							<div class="radio">
																								<input type="radio" name="radio1" id="Gender11" value="option1" checked="">
																								<label for="radio_01">
																								M
																								</label>
																							</div>
																							<div class="radio">
																								<input type="radio" name="radio1" id="Gender22" value="option2">
																								<label for="radio_02">
																								F
																								</label>
																							</div>
																						</div>
																					</div>
																					<div class="form-group">
																						<label class="control-label mb-10">Country</label>
																						<select class="form-control" data-placeholder="Choose a Category" id="Country2" runat="server" required ="required" tabindex="1">
																							<option value="Category 1">USA</option>
																							<option value="Category 2">Austrailia</option>
																							<option value="Category 3">India</option>
																							<option value="Category 4">UK</option>
																						</select>
																					</div>
																				</div>
																				<div class="form-actions mt-10">			
																					<button type="submit" runat="server"  OnClientClick="UpdateProfile2_Click" class="btn btn-success mr-10 mb-30">Update profile</button>
																				</div>				
<%--																			</form>--%>
																		</div>
																	</div>
																</div>
															</div>
														</div>
													</div>
												</div>
											</div>
                                            
                                            
                                            <div  id="filemanager_8" class="tab-pane fade" role="tabpanel">
												<!-- Row -->
												<div class="row">
													
                                                    	<div class="col-md-12">
							<div class="panel panel-default card-view pa-0">
								<div class="panel-wrapper collapse in">
									<div class="panel-body pa-0">
										<div class="">
											<div class="col-lg-3 col-md-4 file-directory pa-0">
												<div class="ibox float-e-margins">
													<div class="ibox-content">
														<div class="file-manager">
															<div class="mt-20 mb-20 ml-15 mr-15">
																<div class="fileupload btn btn-success btn-anim btn-block"><i class="fa fa-upload"></i><span class="btn-text">Upload files</span>
																	<input type="file" class="upload">
																</div>
															</div>
															<div class="pl-15 mb-30">
																<a href="#" class="file-control active">All</a>
																<a href="#" class="file-control">Documents</a>
																<a href="#" class="file-control">Audio</a>
																<a href="#" class="file-control">Images</a>
															</div>	
															
															<h6 class="mb-10 pl-15">Folders</h6>
															<ul class="folder-list mb-30">
																<li class="active"><a href=""><i class="zmdi zmdi-folder"></i> Files</a></li>
																<li><a href=""><i class="zmdi zmdi-folder"></i> Pictures</a></li>
																<li><a href=""><i class="zmdi zmdi-folder"></i> Web pages</a></li>
																<li><a href=""><i class="zmdi zmdi-folder"></i> Illustrations</a></li>
																<li><a href=""><i class="zmdi zmdi-folder"></i> Films</a></li>
																<li><a href=""><i class="zmdi zmdi-folder"></i> Books</a></li>
															</ul>
															<h6 class="pl-15 mb-10">Tags</h6>
															<ul class="tag-list pl-15 pr-15">
																<li><a href="">Family</a></li>
																<li><a href="">Work</a></li>
																<li><a href="">Home</a></li>
																<li><a href="">Children</a></li>
																<li><a href="">Holidays</a></li>
																<li><a href="">Music</a></li>
																<li><a href="">Photography</a></li>
																<li><a href="">Film</a></li>
															</ul>
															<div class="clearfix"></div>
														</div>
													</div>
												</div>
											</div>
											<div class="col-lg-9 col-md-8 file-sec pt-20">
												<div class="row">
													<div class="col-lg-12">
														<div class="row">
															<div class="col-lg-3 col-md-4 col-sm-6 col-xs-12  file-box">
																<div class="file">
																	<a href="#">
																		
																		<div class="icon">
																			<i class="zmdi zmdi-file-text"></i>
																		</div>
																		<div class="file-name">
																			Document_2016.doc
																			<br>
																			<span>Added: Jan 11, 2016</span>
																		</div>
																	</a>
																</div>
															</div>
															<div class="col-lg-3 col-md-4 col-sm-6 col-xs-12  file-box">
																<div class="file">
																	<a href="#">
																		
																		<div class="image" style="background-image:url(dist/img/gallery/mock1.jpg)">
																		</div>
																		<div class="file-name">
																			Italy street.jpg
																			<br>
																			<span>Added: Jan 6, 2016</span>
																		</div>
																	</a>
																</div>
															</div>
															<div class="col-lg-3 col-md-4 col-sm-6 col-xs-12  file-box">
																<div class="file">
																	<a href="#">
																		
																		<div class="image" style="background-image:url(dist/img/gallery/mock2.jpg)">
																		</div>
																		<div class="file-name">
																			My feel.png
																			<br>
																			<span>Added: Jan 7, 2016</span>
																		</div>
																	</a>
																</div>
															</div>
															<div class="col-lg-3 col-md-4 col-sm-6 col-xs-12  file-box">
																<div class="file">
																	<a href="#">
																		
																		<div class="icon">
																			<i class="zmdi zmdi-collection-music"></i>
																		</div>
																		<div class="file-name">
																			Michal Jackson.mp3
																			<br>
																			<span>Added: Jan 22, 2016</span>
																		</div>
																	</a>
																</div>
															</div>
															<div class="col-lg-3 col-md-4 col-sm-6 col-xs-12  file-box">
																<div class="file">
																	<a href="#">
																		
																		<div class="image" style="background-image:url(dist/img/gallery/mock3.jpg)">
																		</div>
																		<div class="file-name">
																			Document_2016.doc
																			<br>
																			<span>Added: Fab 11, 2016</span>
																		</div>
																	</a>
																</div>
															</div>
															<div class="col-lg-3 col-md-4 col-sm-6 col-xs-12  file-box">
																<div class="file">
																	<a href="#">
																		
																		<div class="icon">
																			<i class="img-responsive zmdi zmdi-collection-video"></i>
																		</div>
																		<div class="file-name">
																			Monica's birthday.mpg4
																			<br>
																			<span>Added: Fab 18, 2016</span>
																		</div>
																	</a>
																</div>
															</div>
															<div class="col-lg-3 col-md-4 col-sm-6 col-xs-12  file-box">
																<a href="#">
																	<div class="file">
																		
																		<div class="icon">
																			<i class="zmdi zmdi-chart"></i>
																		</div>
																		<div class="file-name">
																			Annual report 2016.xls
																			<br>
																			<span>Added: Fab 22, 2016</span>
																		</div>
																	</div>
																</a>
															</div>
															<div class="col-lg-3 col-md-4 col-sm-6 col-xs-12  file-box">
																<div class="file">
																	<a href="#">
																		
																		<div class="icon">
																			<i class="zmdi zmdi-file-text"></i>
																		</div>
																		<div class="file-name">
																			Document_2016.doc
																			<br>
																			<span>Added: Jan 11, 2016</span>
																		</div>
																	</a>
																</div>
															</div>
															<div class="col-lg-3 col-md-4 col-sm-6 col-xs-12  file-box">
																<div class="file">
																	<a href="#">
																		
																		<div class="image" style="background-image:url(dist/img/gallery/equal-size/mock6.jpg)">
																		</div>
																		<div class="file-name">
																			Italy street.jpg
																			<br>
																			<span>Added: Jan 6, 2016</span>
																		</div>
																	</a>
																</div>
															</div>
															<div class="col-lg-3 col-md-4 col-sm-6 col-xs-12  file-box">
																<div class="file">
																	<a href="#">
																		
																		<div class="image" style="background-image:url(dist/img/gallery/equal-size/mock3.jpg)">
																		</div>
																		<div class="file-name">
																			My feel.png
																			<br>
																			<span>Added: Jan 7, 2016</span>
																		</div>
																	</a>
																</div>
															</div>
															<div class="col-lg-3 col-md-4 col-sm-6 col-xs-12  file-box">
																<div class="file">
																	<a href="#">
																		
																		<div class="icon">
																			<i class="zmdi zmdi-collection-music"></i>
																		</div>
																		<div class="file-name">
																			Michal Jackson.mp3
																			<br>
																			<span>Added: Jan 22, 2016</span>
																		</div>
																	</a>
																</div>
															</div>
															<div class="col-lg-3 col-md-4 col-sm-6 col-xs-12  file-box">
																<div class="file">
																	<a href="#">
																		
																		<div class="image" style="background-image:url(dist/img/gallery/equal-size/mock2.jpg)">
																		</div>
																		<div class="file-name">
																			Document_2016.doc
																			<br>
																			<span>Added: Fab 11, 2016</span>
																		</div>
																	</a>
																</div>
															</div>
															<div class="col-lg-3 col-md-4 col-sm-6 col-xs-12  file-box">
																<div class="file">
																	<a href="#">
																		
																		<div class="icon">
																			<i class="img-responsive zmdi zmdi-collection-video"></i>
																		</div>
																		<div class="file-name">
																			Monica's birthday.mpg4
																			<br>
																			<span>Added: Fab 18, 2016</span>
																		</div>
																	</a>
																</div>
															</div>
															<div class="col-lg-3 col-md-4 col-sm-6 col-xs-12  file-box">
																<a href="#">
																	<div class="file">
																		
																		<div class="icon">
																			<i class="zmdi zmdi-chart"></i>
																		</div>
																		<div class="file-name">
																			Annual report 2016.xls
																			<br>
																			<span>Added: Fab 22, 2016</span>
																		</div>
																	</div>
																</a>
															</div>
															<div class="col-lg-3 col-md-4 col-sm-6 col-xs-12  file-box">
																<div class="file">
																	<a href="#">
																		
																		<div class="icon">
																			<i class="zmdi zmdi-file-text"></i>
																		</div>
																		<div class="file-name">
																			Document_2016.doc
																			<br>
																			<span>Added: Jan 11, 2016</span>
																		</div>
																	</a>
																</div>
															</div>
															<div class="col-lg-3 col-md-4 col-sm-6 col-xs-12  file-box">
																<div class="file">
																	<a href="#">
																		
																		<div class="image" style="background-image:url(dist/img/gallery/mock6.jpg)">
																		</div>
																		<div class="file-name">
																			Italy street.jpg
																			<br>
																			<span>Added: Jan 6, 2016</span>
																		</div>
																	</a>
																</div>
															</div>
															<div class="col-lg-3 col-md-4 col-sm-6 col-xs-12  file-box">
																<div class="file">
																	<a href="#">
																		
																		<div class="image" style="background-image:url(dist/img/gallery/equal-size/mock5.jpg)">
																		</div>
																		<div class="file-name">
																			My feel.png
																			<br>
																			<span>Added: Jan 7, 2016</span>
																		</div>
																	</a>
																</div>
															</div>
															<div class="col-lg-3 col-md-4 col-sm-6 col-xs-12  file-box">
																<div class="file">
																	<a href="#">
																		
																		<div class="icon">
																			<i class="zmdi zmdi-collection-music"></i>
																		</div>
																		<div class="file-name">
																			Michal Jackson.mp3
																			<br>
																			<span>Added: Jan 22, 2016</span>
																		</div>
																	</a>
																</div>
															</div>
															<div class="col-lg-3 col-md-4 col-sm-6 col-xs-12  file-box">
																<div class="file">
																	<a href="#">
																		
																		<div class="image" style="background-image:url(dist/img/gallery/equal-size/mock4.jpg)">
																		</div>
																		<div class="file-name">
																			Document_2016.doc
																			<br>
																			<span>Added: Fab 11, 2016</span>
																		</div>
																	</a>
																</div>
															</div>
															<div class="col-lg-3 col-md-4 col-sm-6 col-xs-12  file-box">
																<div class="file">
																	<a href="#">
																		
																		<div class="icon">
																			<i class="img-responsive zmdi zmdi-collection-video"></i>
																		</div>
																		<div class="file-name">
																			Monica's birthday.mpg4
																			<br>
																			<span>Added: Fab 18, 2016</span>
																		</div>
																	</a>
																</div>
															</div>
															<div class="col-lg-3 col-md-4 col-sm-6 col-xs-12  file-box">
																<a href="#">
																	<div class="file">
																		
																		<div class="icon">
																			<i class="zmdi zmdi-chart"></i>
																		</div>
																		<div class="file-name">
																			Annual report 2016.xls
																			<br>
																			<span>Added: Fab 22, 2016</span>
																		</div>
																	</div>
																</a>
															</div>
														</div>
													</div>
												</div>
											</div>
										</div>
									</div>
								</div>
							</div>
						</div>
                                                    
												</div>
											</div>
                                            
                                            
										</div>
									</div>
								</div>
							</div>
						</div>
						
							
					</div>
				</div>
				<!-- /Row -->
				
				<!-- Row -->
				<div class="row">
					<div class="col-lg-3 col-md-6 col-sm-6 col-xs-12">
								<div class="panel panel-default border-panel card-view">
									<div class="panel-heading">
										<div class="pull-left">
											<h6 class="panel-title pull-left">users</h6>
										</div>
										<div class="pull-right">
											<a href="#" class="pull-left inline-block mr-15">
												<i class="zmdi zmdi-search"></i>
											</a>
											<a class="pull-left inline-block" href="#" data-effect="fadeOut">
												<i class="zmdi zmdi-plus"></i>
											</a>
										</div>
										<div class="clearfix"></div>
									</div>
									<div class="panel-wrapper collapse in">
										<div class="panel-body row pa-0">
											<div class="chat-cmplt-wrap chat-for-widgets">
												<div class="chat-box-wrap">
													<div>
														<div class="users-nicescroll-bar">
															<ul class="chat-list-wrap">
																<li class="chat-list">
																	<div class="chat-body">
																		<a href="javascript:void(0)">
																			<div class="chat-data">
																				<img class="user-img img-circle"  src="dist/img/user.png" alt="user"/>
																				<div class="user-data">
																					<span class="name block capitalize-font">Clay Masse</span>
																					<span class="time block truncate txt-grey">No one saves us but ourselves.</span>
																				</div>
																				<div class="status away"></div>
																				<div class="clearfix"></div>
																			</div>
																		</a>
																		<a href="javascript:void(0)">
																			<div class="chat-data">
																				<img class="user-img img-circle"  src="dist/img/user1.png" alt="user"/>
																				<div class="user-data">
																					<span class="name block capitalize-font">Evie Ono</span>
																					<span class="time block truncate txt-grey">Unity is strength</span>
																				</div>
																				<div class="status offline"></div>
																				<div class="clearfix"></div>
																			</div>
																		</a>
																		<a href="javascript:void(0)">
																			<div class="chat-data">
																				<img class="user-img img-circle"  src="dist/img/user2.png" alt="user"/>
																				<div class="user-data">
																					<span class="name block capitalize-font">Madalyn Rascon</span>
																					<span class="time block truncate txt-grey">Respect yourself if you would have others respect you.</span>
																				</div>
																				<div class="status online"></div>
																				<div class="clearfix"></div>
																			</div>
																		</a>
																		<a href="javascript:void(0)">
																			<div class="chat-data">
																				<img class="user-img img-circle"  src="dist/img/user3.png" alt="user"/>
																				<div class="user-data">
																					<span class="name block capitalize-font">Mitsuko Heid</span>
																					<span class="time block truncate txt-grey">I’m thankful.</span>
																				</div>
																				<div class="status online"></div>
																				<div class="clearfix"></div>
																			</div>
																		</a>
																		<a href="javascript:void(0)">
																			<div class="chat-data">
																				<img class="user-img img-circle"  src="dist/img/user.png" alt="user"/>
																				<div class="user-data">
																					<span class="name block capitalize-font">Ezequiel Merideth</span>
																					<span class="time block truncate txt-grey">Patience is bitter.</span>
																				</div>
																				<div class="status offline"></div>
																				<div class="clearfix"></div>
																			</div>
																		</a>
																		<a href="javascript:void(0)">
																			<div class="chat-data">
																				<img class="user-img img-circle"  src="dist/img/user1.png" alt="user"/>
																				<div class="user-data">
																					<span class="name block capitalize-font">Jonnie Metoyer</span>
																					<span class="time block truncate txt-grey">Genius is eternal patience.</span>
																				</div>
																				<div class="status online"></div>
																				<div class="clearfix"></div>
																			</div>
																		</a>
																		<a href="javascript:void(0)">
																			<div class="chat-data">
																				<img class="user-img img-circle"  src="dist/img/user2.png" alt="user"/>
																				<div class="user-data">
																					<span class="name block capitalize-font">Angelic Lauver</span>
																					<span class="time block truncate txt-grey">Every burden is a blessing.</span>
																				</div>
																				<div class="status away"></div>
																				<div class="clearfix"></div>
																			</div>
																		</a>
																		<a href="javascript:void(0)">
																			<div class="chat-data">
																				<img class="user-img img-circle"  src="dist/img/user3.png" alt="user"/>
																				<div class="user-data">
																					<span class="name block capitalize-font">Priscila Shy</span>
																					<span class="time block truncate txt-grey">Wise to resolve, and patient to perform.</span>
																				</div>
																				<div class="status online"></div>
																				<div class="clearfix"></div>
																			</div>
																		</a>
																		<a href="javascript:void(0)">
																			<div class="chat-data">
																				<img class="user-img img-circle"  src="dist/img/user4.png" alt="user"/>
																				<div class="user-data">
																					<span class="name block capitalize-font">Linda Stack</span>
																					<span class="time block truncate txt-grey">Our patience will achieve more than our force.</span>
																				</div>
																				<div class="status away"></div>
																				<div class="clearfix"></div>
																			</div>
																		</a>
																	</div>
																</li>
															</ul>
														</div>
													</div>
												</div>
												<div class="recent-chat-box-wrap">
													<div class="recent-chat-wrap">
														<div class="panel-heading ma-0 pt-15">
															<div class="goto-back">
																<a  id="goto_back_widget" href="javascript:void(0)" class="inline-block txt-grey">
																	<i class="zmdi zmdi-chevron-left"></i>
																</a>	
																<span class="inline-block txt-dark">ryan</span>
																<a href="javascript:void(0)" class="inline-block text-right txt-grey"><i class="zmdi zmdi-more"></i></a>
																<div class="clearfix"></div>
															</div>
														</div>
														<div class="panel-wrapper collapse in">
															<div class="panel-body pa-0">
																<div class="chat-content">
																	<ul class="users-chat-nicescroll-bar pt-20">
																		<li class="friend">
																			<div class="friend-msg-wrap">
																				<img class="user-img img-circle block pull-left"  src="dist/img/user.png" alt="user"/>
																				<div class="msg pull-left">
																					<p>Hello Jason, how are you, it's been a long time since we last met?</p>
																					<div class="msg-per-detail text-right">
																						<span class="msg-time txt-grey">2:30 PM</span>
																					</div>
																				</div>
																				<div class="clearfix"></div>
																			</div>	
																		</li>
																		<li class="self mb-10">
																			<div class="self-msg-wrap">
																				<div class="msg block pull-right"> Oh, hi Sarah I'm have got a new job now and is going great.
																					<div class="msg-per-detail text-right">
																						<span class="msg-time txt-grey">2:31 pm</span>
																					</div>
																				</div>
																				<div class="clearfix"></div>
																			</div>	
																		</li>
																		<li class="self">
																			<div class="self-msg-wrap">
																				<div class="msg block pull-right">  How about you?
																					<div class="msg-per-detail text-right">
																						<span class="msg-time txt-grey">2:31 pm</span>
																					</div>
																				</div>
																				<div class="clearfix"></div>
																			</div>	
																		</li>
																		<li class="friend">
																			<div class="friend-msg-wrap">
																				<img class="user-img img-circle block pull-left"  src="dist/img/user.png" alt="user"/>
																				<div class="msg pull-left"> 
																					<p>Not too bad.</p>
																					<div class="msg-per-detail  text-right">
																						<span class="msg-time txt-grey">2:35 pm</span>
																					</div>
																				</div>
																				<div class="clearfix"></div>
																			</div>	
																		</li>
																	</ul>
																</div>
																<div class="input-group">
																	<input type="text" id="input_msg_send_widget" name="send-msg" class="input-msg-send form-control" placeholder="Type something">
																	<div class="input-group-btn emojis">
																		<div class="dropup">
																			<button type="button" class="btn  btn-default  dropdown-toggle" data-toggle="dropdown" ><i class="zmdi zmdi-mood"></i></button>
																			<ul class="dropdown-menu dropdown-menu-right">
																				<li><a href="javascript:void(0)">Action</a></li>
																				<li><a href="javascript:void(0)">Another action</a></li>
																				<li class="divider"></li>
																				<li><a href="javascript:void(0)">Separated link</a></li>
																			</ul>
																		</div>
																	</div>
																	<div class="input-group-btn attachment">
																		<div class="fileupload btn  btn-default"><i class="zmdi zmdi-attachment-alt"></i>
																			<input type="file" class="upload">
																		</div>
																	</div>
																</div>
															</div>
														</div>
													</div>
												</div>
											</div>
										</div>
									</div>
								</div>
							</div>
					<div class="col-lg-3 col-md-6 col-sm-6 col-xs-12">
						<div class="panel panel-default border-panel card-view">
							<div class="panel-heading">
								<div class="pull-left">
									<h6 class="panel-title txt-dark">todo</h6>
								</div>
								<div class="pull-right">
									<div class="pull-left inline-block dropdown mr-15">
										<a class="dropdown-toggle" data-toggle="dropdown" href="#" aria-expanded="false" role="button"><i class="zmdi zmdi-more-vert"></i></a>
										<ul class="dropdown-menu bullet dropdown-menu-right"  role="menu">
											<li role="presentation"><a href="javascript:void(0)" role="menuitem"><i class="icon wb-reply" aria-hidden="true"></i>Edit</a></li>
											<li role="presentation"><a href="javascript:void(0)" role="menuitem"><i class="icon wb-share" aria-hidden="true"></i>Clear All</a></li>
											<li role="presentation"><a href="javascript:void(0)" role="menuitem"><i class="icon wb-trash" aria-hidden="true"></i>Select All</a></li>
										</ul>
									</div>
									<a class="pull-left inline-block close-panel" href="#" data-effect="fadeOut">
										<i class="zmdi zmdi-close"></i>
									</a>
								</div>
								<div class="clearfix"></div>
							</div>
							<div class="panel-wrapper collapse in">
								<div class="panel-body row pa-0">
									<div class="todo-box-wrap">
										<!-- Todo-List -->
										<ul class="todo-list todo-box-nicescroll-bar">
											<li class="todo-item">
												<div class="checkbox checkbox-default">
													<input type="checkbox" id="checkbox001"/>
													<label for="checkbox001">Record The First Episode</label>
												</div>
											</li>
											<li>
												<hr class="light-grey-hr"/>
											</li>
											<li class="todo-item">
												<div class="checkbox checkbox-pink">
													<input type="checkbox" id="checkbox002"/>
													<label for="checkbox002">Prepare The Conference Schedule</label>
												</div>
											</li>
											<li>
												<hr class="light-grey-hr"/>
											</li>
											<li class="todo-item">
												<div class="checkbox checkbox-warning">
													<input type="checkbox" id="checkbox003" checked/>
													<label for="checkbox003">Decide The Live Discussion Time</label>
												</div>
											</li>
											<li>
												<hr class="light-grey-hr"/>
											</li>
											<li class="todo-item">
												<div class="checkbox checkbox-success">
													<input type="checkbox" id="checkbox004" checked/>
													<label for="checkbox004">Prepare For The Next Project</label>
												</div>
											</li>
											<li>
												<hr class="light-grey-hr"/>
											</li>
											<li class="todo-item">
												<div class="checkbox checkbox-danger">
													<input type="checkbox" id="checkbox005" checked/>
													<label for="checkbox005">Finish Up AngularJs Tutorial</label>
												</div>
											</li>
											<li>
												<hr class="light-grey-hr"/>
											</li>
											<li class="todo-item">
												<div class="checkbox checkbox-purple">
													<input type="checkbox" id="checkbox006" checked/>
													<label for="checkbox006">Finish Infinity Project</label>
												</div>
											</li>
											<li>
												<hr class="light-grey-hr"/>
											</li>
										</ul>
										<!-- /Todo-List -->
										
										<!-- New Todo -->
										<div class="new-todo">
											<div class="input-group">
												<input type="text" id="add_todo" name="example-input2-group2" class="form-control" placeholder="Add new task">
												<span class="input-group-btn">
												<button type="button" class="btn btn-success"><i class="zmdi zmdi-plus txt-success"></i></button>
												</span> 
											</div>
										</div>
										<!-- /New Todo -->
									</div>
								</div>
							</div>
						</div>
					</div>
					<div class="col-lg-3 col-md-6 col-sm-6 col-xs-12">
						<div class="panel panel-default card-view">
							<div class="panel-wrapper collapse in">
								<div class="panel-body">
									<div class="calendar-wrap">
									  <div id="calendar_small" class="small-calendar"></div>
									</div>
								</div>
							</div>
						</div>	
					</div>
					<div class="col-lg-3 col-md-6 col-sm-6 col-xs-12">
						<div class="panel panel-default card-view bg-twitter">
							<div class="panel-wrapper collapse in">
								<div  class="panel-body">
									<div class="twitter-icon-wrap text-center mb-15">
										<i class="fa fa-twitter"></i>
									</div>
									<!-- START carousel-->
									<div id="twitter_slider" data-ride="carousel" class="carousel slide twitter-slider-wrap text-slider">
										<ol class="carousel-indicators">
										   <li data-target="#twitter_slider" data-slide-to="0" class="active"></li>
										   <li data-target="#twitter_slider" data-slide-to="1"></li>
										</ol>
										<div id="tweets_fetch" role="listbox" class="carousel-inner mb-50">
										</div>
									</div>
									<!-- END carousel-->
								</div>
							</div>
						</div>
							<div class="panel panel-default card-view">
							<div class="panel-heading">
								<div class="pull-left">
									<h6 class="panel-title txt-dark">Madalyn Rascon</h6>
								</div>
								<div class="clearfix"></div>
							</div>
							<div class="panel-wrapper collapse in">
								<div  class="panel-body row pa-0">
									<!--Instagram-->
									<ul class="instagram-lite"></ul>
									<!--/Instagram-->
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
            </form>
        <!-- /Main Content -->

    </div>
    <!-- /#wrapper -->
	
	<!-- JavaScript -->
	
    <!-- jQuery -->
    <script src="vendors/bower_components/jquery/dist/jquery.min.js"></script>

    <!-- Bootstrap Core JavaScript -->
    <script src="vendors/bower_components/bootstrap/dist/js/bootstrap.min.js"></script>
    
	<!-- Vector Maps JavaScript -->
    <script src="vendors/vectormap/jquery-jvectormap-2.0.2.min.js"></script>
    <script src="vendors/vectormap/jquery-jvectormap-world-mill-en.js"></script>
	<script src="dist/js/vectormap-data.js"></script>
	
	<!-- Calender JavaScripts -->
	<script src="vendors/bower_components/moment/min/moment.min.js"></script>
	<script src="vendors/jquery-ui.min.js"></script>
	<script src="vendors/bower_components/fullcalendar/dist/fullcalendar.min.js"></script>
	<script src="dist/js/fullcalendar-data.js"></script>
	
	<!-- Counter Animation JavaScript -->
	<script src="vendors/bower_components/waypoints/lib/jquery.waypoints.min.js"></script>
	<script src="vendors/bower_components/jquery.counterup/jquery.counterup.min.js"></script>
	
	<!-- Data table JavaScript -->
	<script src="vendors/bower_components/datatables/media/js/jquery.dataTables.min.js"></script>
	
	<!-- Slimscroll JavaScript -->
	<script src="dist/js/jquery.slimscroll.js"></script>
	
	<!-- Fancy Dropdown JS -->
	<script src="dist/js/dropdown-bootstrap-extended.js"></script>
	
	<!-- Sparkline JavaScript -->
	<script src="vendors/jquery.sparkline/dist/jquery.sparkline.min.js"></script>
	
	<script src="vendors/bower_components/jquery.easy-pie-chart/dist/jquery.easypiechart.min.js"></script>
	<script src="dist/js/skills-counter-data.js"></script>
	
	<!-- Morris Charts JavaScript -->
    <script src="vendors/bower_components/raphael/raphael.min.js"></script>
    <script src="vendors/bower_components/morris.js/morris.min.js"></script>
    <script src="dist/js/morris-data.js"></script>
	
	<!-- Owl JavaScript -->
	<script src="vendors/bower_components/owl.carousel/dist/owl.carousel.min.js"></script>
	
	<!-- Switchery JavaScript -->
	<script src="vendors/bower_components/switchery/dist/switchery.min.js"></script>
	
	<!-- Data table JavaScript -->
	<script src="vendors/bower_components/datatables/media/js/jquery.dataTables.min.js"></script>
		
	<!-- Gallery JavaScript -->
	<script src="dist/js/isotope.js"></script>
	<script src="dist/js/lightgallery-all.js"></script>
	<script src="dist/js/froogaloop2.min.js"></script>
	<script src="dist/js/gallery-data.js"></script>
	
	<!-- twitter JavaScript -->
	<script src="dist/js/twitterFetcher.js"></script>
	
	<!-- Spectragram JavaScript -->
	<script src="dist/js/spectragram.min.js"></script>
	
	<!-- Init JavaScript -->
	<script src="dist/js/init.js"></script>
	<script src="dist/js/widgets-data.js"></script>

</body>

</html>
