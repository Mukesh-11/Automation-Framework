<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="aUTOMATION.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="margin: 0px;">
    <form id="form1" runat="server">
        <div style="background-image: url('Images/LBG1.png'); background-attachment: fixed; background-repeat: no-repeat; height: 732px; width: 1600px;">

            <asp:TextBox ID="TextBox1" runat="server" Style="z-index: 1; left: 526px; top: 245px; position: fixed; width: 213px; height: 24px" MaxLength="15" BackColor="#FFFFCC" ToolTip="Enter the Password" ForeColor="Black" TextMode="Password" Font-Size="Larger"></asp:TextBox>
            <asp:ImageButton ID="ImageButton1" runat="server" Style="z-index: 1; left: 718px; top: 246px; position: fixed; height: 28px" ImageUrl="~/Images/GoBtn.png" OnClick="ImageButton1_Click" />

            <asp:Label ID="Label1" runat="server" Font-Size="XX-Large" Style="height: 23px; width: 166px; z-index: 1; left: 556px; top: 199px;font-variant-caps:all-petite-caps; position: fixed" Text="AUTOMATION"></asp:Label>

            <asp:ImageButton ID="ImageButton10" runat="server" ImageUrl="~/Images/LogoutBtn.png" style="z-index: 1; left: 922px; top: 443px; position: fixed; height: 14px; width: 15px" OnClick="ImageButton10_Click" ToolTip="Logout" />

        </div>
    </form>
</body>
</html>
