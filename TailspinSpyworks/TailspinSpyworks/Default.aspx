<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Styles/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="HeadContent">
    <!--section class="featured"-->
        <div class="content-wrapper">
            <!--hgroup class="title"-->
                <h1><%: Title %>.</h1>
            <!--hgroup-->
        </div>
    <!--section-->
</asp:Content>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
	<p>This is meant to be the sample project for 
		<a href="https://docs.microsoft.com/en-us/aspnet/web-forms/overview/older-versions-getting-started/tailspin-spyworks">
			ASP.NET 4 - Tailspin Spyworks</a>
		but it is built as a web site and the relevant template for web sites seems to 
		have been removed from VS. I gave up trying to get this working.</p>
    <h3>We suggest the following:</h3>
            <h5>Getting Started</h5>
            <a href="https://go.microsoft.com/fwlink/?LinkId=245146">Learn more…</a>
</asp:Content>