<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebCalculator.Default" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Simple Web Calculator</title>
    <style>
        body {
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
            background: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
            margin: 0;
            padding: 20px;
            display: flex;
            justify-content: center;
            align-items: center;
            min-height: 100vh;
        }
        
        .calculator {
            background: white;
            padding: 30px;
            border-radius: 20px;
            box-shadow: 0 20px 60px rgba(0,0,0,0.2);
            width: 300px;
        }
        
        .display {
            width: 100%;
            height: 60px;
            font-size: 24px;
            text-align: right;
            padding: 10px;
            border: 2px solid #ddd;
            border-radius: 10px;
            margin-bottom: 20px;
            background: #f8f9fa;
        }
        
        .button-grid {
            display: grid;
            grid-template-columns: repeat(4, 1fr);
            gap: 10px;
        }
        
        .btn {
            height: 60px;
            font-size: 18px;
            border: none;
            border-radius: 10px;
            cursor: pointer;
            transition: all 0.2s;
        }
        
        .btn:hover {
            transform: translateY(-2px);
            box-shadow: 0 5px 15px rgba(0,0,0,0.2);
        }
        
        .btn-number {
            background: #f8f9fa;
            color: #333;
        }
        
        .btn-operator {
            background: #007bff;
            color: white;
        }
        
        .btn-function {
            background: #6c757d;
            color: white;
        }
        
        .btn-equals {
            background: #28a745;
            color: white;
        }
        
        .btn-zero {
            grid-column: span 2;
        }
        
        h1 {
            text-align: center;
            color: white;
            margin-bottom: 30px;
        }
    </style>
</head>
<body>
    <div>
        <h1>Simple Web Calculator</h1>
        <form id="form1" runat="server">
            <div class="calculator">
                <asp:TextBox ID="txtDisplay" runat="server" CssClass="display" ReadOnly="true" Text="0"></asp:TextBox>
                
                <div class="button-grid">
                    <asp:Button ID="btnClear" runat="server" Text="C" CssClass="btn btn-function" OnClick="BtnFunction_Click" />
                    <asp:Button ID="btnSign" runat="server" Text="±" CssClass="btn btn-function" OnClick="BtnFunction_Click" />
                    <asp:Button ID="btnPercent" runat="server" Text="%" CssClass="btn btn-function" OnClick="BtnFunction_Click" />
                    <asp:Button ID="btnDivide" runat="server" Text="÷" CssClass="btn btn-operator" OnClick="BtnOperator_Click" />
                    
                    <asp:Button ID="btn7" runat="server" Text="7" CssClass="btn btn-number" OnClick="BtnNumber_Click" />
                    <asp:Button ID="btn8" runat="server" Text="8" CssClass="btn btn-number" OnClick="BtnNumber_Click" />
                    <asp:Button ID="btn9" runat="server" Text="9" CssClass="btn btn-number" OnClick="BtnNumber_Click" />
                    <asp:Button ID="btnMultiply" runat="server" Text="×" CssClass="btn btn-operator" OnClick="BtnOperator_Click" />
                    
                    <asp:Button ID="btn4" runat="server" Text="4" CssClass="btn btn-number" OnClick="BtnNumber_Click" />
                    <asp:Button ID="btn5" runat="server" Text="5" CssClass="btn btn-number" OnClick="BtnNumber_Click" />
                    <asp:Button ID="btn6" runat="server" Text="6" CssClass="btn btn-number" OnClick="BtnNumber_Click" />
                    <asp:Button ID="btnSubtract" runat="server" Text="-" CssClass="btn btn-operator" OnClick="BtnOperator_Click" />
                    
                    <asp:Button ID="btn1" runat="server" Text="1" CssClass="btn btn-number" OnClick="BtnNumber_Click" />
                    <asp:Button ID="btn2" runat="server" Text="2" CssClass="btn btn-number" OnClick="BtnNumber_Click" />
                    <asp:Button ID="btn3" runat="server" Text="3" CssClass="btn btn-number" OnClick="BtnNumber_Click" />
                    <asp:Button ID="btnAdd" runat="server" Text="+" CssClass="btn btn-operator" OnClick="BtnOperator_Click" />
                    
                    <asp:Button ID="btn0" runat="server" Text="0" CssClass="btn btn-number btn-zero" OnClick="BtnNumber_Click" />
                    <asp:Button ID="btnDecimal" runat="server" Text="." CssClass="btn btn-number" OnClick="BtnDecimal_Click" />
                    <asp:Button ID="btnEquals" runat="server" Text="=" CssClass="btn btn-equals" OnClick="BtnEquals_Click" />
                </div>
            </div>
        </form>
    </div>
</body>
</html>