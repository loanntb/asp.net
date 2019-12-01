<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="hoten.aspx.cs" Inherits="Chuanhoaxau.hoten" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            text-align: center;
        }
        .auto-style2 {
            margin-left: 44px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style1">
    <div>
    
    </div>
            <asp:Label ID="Label1" runat="server" Text="Họ tên:"></asp:Label>
&nbsp;<input id="txtHoten" type="text" />
            <asp:Label ID="Label2" runat="server" Text="Xâu sao khi chuẩn hóa: "></asp:Label>
            <input id="txtChuanHoa" type="text" /><br />
            <asp:Button ID="btnChuanhoa" runat="server" CssClass="auto-style2" OnClick="btnChuanhoa_Click" Text="Chuẩn hóa" Width="108px" />
        </div>
    </form>
</body>
</html>
