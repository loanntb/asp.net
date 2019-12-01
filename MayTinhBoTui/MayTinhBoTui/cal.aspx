<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="cal.aspx.cs" Inherits="MayTinhBoTui.cal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="auto-style1">
    
        Máy tính bỏ túi<br />
        <asp:TextBox ID="txtResult" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="btn0" runat="server" OnClick="btn0_Click" Text="0" />
        <asp:Button ID="btn1" runat="server" OnClick="btn1_Click" Text="1" />
        <asp:Button ID="btn2" runat="server" OnClick="btn2_Click" Text="2" />
        <asp:Button ID="btn3" runat="server" OnClick="btn3_Click" Text="3" />
        <asp:Button ID="btn4" runat="server" OnClick="btn4_Click" Text="4" />
        <asp:Button ID="btn5" runat="server" OnClick="btn5_Click" Text="5" />
        <asp:Button ID="btn6" runat="server" OnClick="btn6_Click" Text="6" />
        <asp:Button ID="btn7" runat="server" OnClick="btn7_Click" Text="7" />
        <asp:Button ID="btn8" runat="server" OnClick="btn8_Click" Text="8" />
        <asp:Button ID="btn9" runat="server" OnClick="btn9_Click" Text="9" />
        <br />
        <asp:Button ID="btnE" runat="server" Text="=" OnClick="btnE_Click" />
&nbsp;<asp:Button ID="btnClear" runat="server" OnClick="btnClear_Click" Text="C" />
        <br />
        <asp:Button ID="btnSum" runat="server" OnClick="btnSum_Click" Text="+" />
        <asp:Button ID="btnSub" runat="server" Text="-" OnClick="btnSub_Click" style="height: 26px" />
        <asp:Button ID="btnMul" runat="server" Text="*" OnClick="btnMul_Click" />
        <asp:Button ID="btnDiv" runat="server" Text="/" OnClick="btnDiv_Click" />
    
    </div>
    </form>
</body>
</html>
