<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Framework.aspx.cs" Inherits="aUTOMATION.Framework" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="margin: 0px;">
    <form id="form1" runat="server">
    <div style="background-image: url('Images/BG1.png'); background-attachment: fixed; background-repeat: no-repeat; height: 732px; width: 1600px;">
        
            <asp:ImageButton ID="ImageButton10" runat="server" ImageUrl="~/Images/LogoutBtn.png" style="z-index: 1; left: 922px; top: 443px; position: fixed; height: 14px; width: 15px" OnClick="ImageButton10_Click" ToolTip="Logout" />

        <asp:FileUpload ID="FileUpload1" runat="server" style="z-index: 1; left: 661px; top: 208px; position: fixed" />
        <asp:Button ID="Button2" runat="server" BackColor="White" ForeColor="Black" style="z-index: 1; left: 661px; top: 277px; position: fixed; width: 99px; height: 30px; right: 625px;" Text="Submit" Font-Size="Medium" OnClick="Button2_Click" />
        <asp:Button ID="Button1" runat="server" ForeColor="Black" style="z-index: 1; left: 445px; top: 277px; position: fixed; width: 99px; height: 30px; right: 508px;" Text="Download" Font-Size="Medium" OnClick="Button1_Click" />
        <asp:Label ID="Label1" runat="server" style="z-index: 1; left: 563px; top: 137px; position: fixed; right: 485px; width: 228px;" Text="Framework" Font-Size="X-Large" Font-Bold="True" Font-Underline="True"></asp:Label>

        <asp:Label ID="Label2" runat="server" Font-Size="X-Large" ForeColor="Black" style="z-index: 1; left: 445px; top: 203px; position: fixed; height: 29px; width: 167px" Text="Test Data" BorderStyle="None" Font-Bold="True" Font-Names="Centaur"></asp:Label>

        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" style="z-index: 1; left: 858px; top: 114px; position: fixed" Font-Size="Large" ForeColor="#3366CC">Template</asp:LinkButton>

        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/BackBtn.png" OnClick="ImageButton1_Click" style="z-index: 1; left: 334px; top: 109px; position: fixed; height: 28px; " />

    </div>
    </form>
</body>
</html>
