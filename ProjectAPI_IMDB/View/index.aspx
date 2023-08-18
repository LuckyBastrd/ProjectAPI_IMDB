<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="ProjectAPI_IMDB.View.index" Async="true" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Document</title>
    <link href="../bootstrap/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body class="bg-dark">
    <form runat="server">

        <div class="container text-center">
            <h1 class="pt-5 mb-0 fw-bold text-light">
                Movie
                <span class="text-primary">
                    Details
                </span>
            </h1>
            <p class="fw-bold text-secondary">USING IMDB API</p>
        </div>
    
        <div class="container d-flex justify-content-center mt-5 col-md-6">
            <div class="input-group">
                <input id="SearchInput" runat="server" type="text" class="form-control" placeholder="Search Movie Title..."/>
                <asp:Button ID="SearchButton" runat="server" Text="Search" CssClass="btn btn-primary" OnClick="SearchButton_Click"/>
            </div>
        </div>

        <div class="container justify-content-center mt-5" id="boxId"  runat="server">
            <div class="row justify-content-center">
                <div class="col-md-6 border border-white p-4 d-flex">

                    <div class="mr-3">
                        <img id="posterId" runat="server" src="placeholder_image_url.jpg" alt="Image" class="img-fluid" style="max-width: 140px; max-height: 220px;">
                    </div>

                    <div class="d-flex flex-column justify-content-center ml-5" style="margin-left: 32px;">
                        <p id="movieTitle" class="fw-bold text-primary fs-4 mb-3">TITLE: </p>
                        <asp:Label ID="titleLabel" runat="server" CssClass="text-light" EnableViewState="false"></asp:Label>

                        <p id="movieYear" class="fw-bold text-primary fs-4 mb-3">YEAR: </p>
                        <asp:Label ID="yearLabel" runat="server" CssClass="text-light" EnableViewState="false"></asp:Label>

                        <p id="movieDuration" class="fw-bold text-primary fs-4 mb-3">DURATION: </p>
                        <asp:Label ID="durationLabel" runat="server" CssClass="text-light" EnableViewState="false"></asp:Label>
                    </div>

                </div>
            </div>
        </div>
    </form>
    
    <script src="../bootstrap/js/bootstrap.min.js"></script>
</body>
</html>
