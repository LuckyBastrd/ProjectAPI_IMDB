<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="ProjectAPI_IMDB.View.index" Async="true" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Movie Details</title>
    <link href="../bootstrap/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body class="bg-dark">
    <form runat="server">

        <%--WEBSITE TITLE--%>
        <div class="container text-center">
            <h1 class="pt-5 mb-0 fw-bold text-light">
                Movie
                <span class="text-primary">
                    Details
                </span>
            </h1>
            <p class="fw-bold text-secondary">USING IMDB API</p>
        </div>
        
        <%--SEARCH BOX AND SEARCH BUTTON--%>
        <div class="container d-flex justify-content-center mt-5 col-md-6">
            <div class="input-group">
                <input id="SearchInput" runat="server" type="text" class="form-control" placeholder="Search Movie Title..."/>
                <asp:Button ID="SearchButton" runat="server" Text="Search" CssClass="btn btn-primary" OnClick="SearchButton_Click"/>
            </div>
        </div>

        <%--STATUS LABEL--%>
        <div class="container text-center" id="statusId"  runat="server">
            <h3 class="pt-5 mb-0 fw-bold text-light">
                Data Not Found !!!
            </h3>
        </div>
        
        <%--BOX FOR THE CONTENT--%>
        <div class="container justify-content-center mt-5" id="boxId"  runat="server">
            <div class="row justify-content-center">
                <div class="col-md-5 border border-white p-4 d-flex justify-content-center align-items-center">
                    <div class="mr-3">
                        <asp:Label ID="posterLabel" runat="server" Text=""></asp:Label>
                    </div>
                    <div class="d-flex flex-column justify-content-center ml-5" style="margin-left: 32px;">
                        <div class="d-flex">
                            <p id="movieTitle" class="fw-bold text-primary fs-4 mb-3 me-3">TITLE: </p>
                            <asp:Label ID="titleLabel" runat="server" CssClass="text-light fs-4 mb-3" EnableViewState="false"></asp:Label>
                        </div>
                        
                        <div class="d-flex">
                             <p id="movieYear" class="fw-bold text-primary fs-4 mb-3 me-3">YEAR: </p>
                            <asp:Label ID="yearLabel" runat="server" CssClass="text-light fs-4 mb-3" EnableViewState="false"></asp:Label>
                        </div>

                        <div class="d-flex">
                            <p id="movieDuration" class="fw-bold text-primary fs-4 mb-3 me-3">DURATION: </p>
                            <asp:Label ID="durationLabel" runat="server" CssClass="text-light fs-4 mb-3" EnableViewState="false"></asp:Label>
                        </div>

                        <div class="d-flex" id="episodesId"  runat="server">
                            <p id="seriesEpisodes" class="fw-bold text-primary fs-4 mb-3 me-3">EPISODES: </p>
                            <asp:Label ID="episodesLabel" runat="server" CssClass="text-light fs-4 mb-3" EnableViewState="false"></asp:Label>
                        </div>

                        <div class="d-flex">
                            <asp:Button ID="detailsButton" runat="server" Text="VIEW ON IMDB" CssClass="btn btn-primary fw-bold fs-4 mb-3 me-3" OnClick="detailsButton_Click"/>
                        </div>

                    </div>
                </div>
            </div>
        </div>

    </form>
    
    <script src="../bootstrap/js/bootstrap.min.js"></script>
</body>
</html>
