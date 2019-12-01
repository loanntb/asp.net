<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="PTB2.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="Label1" runat="server" Text="Nhập a: "></asp:Label>
        <asp:TextBox ID="txta" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Nhập b"></asp:Label>
        <asp:TextBox ID="txtb" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label3" runat="server" Text="Nhập c"></asp:Label>
        <asp:TextBox ID="txtc" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Giải" />
        <input id="Reset1" type="reset" value="Xóa" /><br />
        <br />
        <asp:Label ID="Label4" runat="server" Text="Kết quả"></asp:Label>
        <asp:TextBox ID="txtkq" runat="server"></asp:TextBox>
    
    </div>
    </form>
</body>
</html>
