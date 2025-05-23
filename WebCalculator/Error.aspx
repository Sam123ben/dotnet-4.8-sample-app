<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="WebCalculator.Error" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Error - Web Calculator</title>
    <link href="~/Content/Site.css" rel="stylesheet" />
    <style>
        .error-container {
            max-width: 600px;
            margin: 50px auto;
            padding: 40px;
            text-align: center;
            background: white;
            border-radius: 20px;
            box-shadow: 0 20px 60px rgba(0,0,0,0.1);
        }
        
        .error-icon {
            font-size: 4rem;
            color: #dc3545;
            margin-bottom: 20px;
        }
        
        .error-title {
            color: #333;
            font-size: 2rem;
            margin-bottom: 15px;
        }
        
        .error-message {
            color: #666;
            font-size: 1.1rem;
            margin-bottom: 30px;
            line-height: 1.6;
        }
        
        .btn-home {
            display: inline-block;
            background: linear-gradient(145deg, #007bff, #0056b3);
            color: white;
            padding: 12px 30px;
            text-decoration: none;
            border-radius: 25px;
            font-weight: 600;
            transition: all 0.3s ease;
            box-shadow: 0 5px 15px rgba(0,123,255,0.3);
        }
        
        .btn-home:hover {
            transform: translateY(-2px);
            box-shadow: 0 10px 25px rgba(0,123,255,0.4);
            color: white;
            text-decoration: none;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="error-container">
            <div class="error-icon">⚠️</div>
            <h1 class="error-title">Oops! Something went wrong</h1>
            <p class="error-message">
                We're sorry, but an unexpected error has occurred. 
                Don't worry, our calculator is usually very reliable!
            </p>
            <asp:HyperLink ID="lnkHome" runat="server" NavigateUrl="~/Default.aspx" CssClass="btn-home">
                Return to Calculator
            </asp:HyperLink>
        </div>
    </form>
</body>
</html>