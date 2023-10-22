<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="ValView.indexx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <meta charset="utf-8">
        <meta name="viewport" content="width=device-width, initial-scale=1">

        <!-- Bootstrap CSS -->
        <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous" />
	
        <!-- Custom CSS -->
        <link rel="stylesheet" href="css/styles.css" />
	
        <!-- Bootstrap JS -->
        <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-MrcW6ZMFYlzcLA8Nl+NtUVF0sA7MsXsP1UyJoMp4YLEuNSfAP+JcXn/tWtIaxVXM" crossorigin="anonymous"></script>
        
		<!-- Custom JS -->
		<script src="js/javascript.js"></script>
		<title>ValoView</title>
    </head>
    
    <body>
        <form id="form1" runat="server">
                <div id="welcome">
                    <h1>Your home for Valorant E-Sports.</h1>
                    <p><br />Want to know the results from the most recent match? Or maybe just view your favourite teams stats? How about each individual players agents and performance? You can view it all here, in one simple and easy-to-use site.</p>
                </div>

				<header>
					<nav class="navbar navbar-expand-md navbar-dark bg-dark">
						<a class="navbar-brand" href="#welcome">ValoView</a>
						<button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
							<span class="navbar-toggler-icon"></span>
						</button>

						<div class="collapse navbar-collapse" id="navbarSupportedContent">
							<!-- First Unordered List showing sections in page to jump to-->
							<ul class="navbar-nav me-auto">
								<li class="nav-item">
								  <a class="nav-link"  href="#section1">Temp1</a>
								</li>

								<li class="nav-item">
								  <a class="nav-link" href="#section2">Temp2</a>
								</li>

								<li class="nav-item">
								  <a class="nav-link" href="#section3">Temp3</a>
								</li>
							</ul>

							<!-- Second list; dynamic content for user sign-in and admin control -->
							<div class="dropdown">
								<button class="btn btn-primary dropdown-toggle" type="button" data-bs-toggle="dropdown">Dropdown Example
									<span class="caret"></span>
								</button>
								<ul class="dropdown-menu">
									<li>
										<asp:LinkButton class="nav-link" ID="lbtnLogin" runat="server" PostBackUrl="~/Login.aspx">Login</asp:LinkButton>
									</li>
									
									<li>
										<asp:LinkButton class="nav-link" ID="lbtnUserProfile" runat="server">User</asp:LinkButton>
									</li>

									<li>
										<asp:LinkButton class="nav-link" ID="lbtnTournaments" runat="server" PostBackUrl="~/ViewTournaments.aspx">View Tournaments</asp:LinkButton>
									</li>

									<li>
										<asp:LinkButton class="nav-link" ID="lbtnTeams" runat="server" PostBackUrl="~/ViewTeams.aspx">View Teams</asp:LinkButton>
									</li>

									<li>
										<asp:LinkButton class="nav-link" ID="lbtnPlayers" runat="server" PostBackUrl="~/ViewPlayers.aspx">View Players</asp:LinkButton>
									</li>
									
									<li>
										<asp:LinkButton class="nav-link" ID="lbtnLogOut" runat="server">Log Out</asp:LinkButton>
									</li>
								</ul>
							</div>
						</div>
					</nav>
			</header>

				<main>
					<div id="section1">
						<div id="section1-text" class="right-text">
							<h1>Lorem Ipsum</h1>
							<p>Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Quis enim lobortis scelerisque fermentum dui faucibus.</p>
						</div>
					</div>

					<div id="section2">
						<div id="section2-text" class="left-text">
							<h1>Dolor Sit</h1>
							<p>Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Euismod elementum nisi quis eleifend quam adipiscing vitae proin. Habitasse platea dictumst quisque sagittis. Ut consequat semper viverra nam libero justo.</p>
						</div>
					</div>

					<div id="section3">
						<div id="section3-text" class="right-text">
							<h1>Amet</h1>
							<p>aaaaaa</p>
						</div>
					</div>
				</main>

				<footer class="bg-dark">
					<p>Designed, produced and developed by Kat Kipling. All rights reserved.<p>
				</footer>
		</form>
    </body>
</html>
