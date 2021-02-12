<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainPage.aspx.cs" Inherits="aUTOMATION.MainPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="margin: 0px;">
    <form id="form1" runat="server">
        <div style="background-image: url('Images/BG11.png'); background-attachment: fixed; background-repeat: no-repeat; height: 732px; width: 1600px;">

            <asp:ImageButton ID="ImageButton10" runat="server" ImageUrl="~/Images/LogoutBtn.png" style="z-index: 1; left: 922px; top: 443px; position: fixed; height: 14px; width: 15px" OnClick="ImageButton10_Click" ToolTip="Logout" />

            <asp:ImageButton ID="ImageButton2" runat="server" Style="z-index: 1; left: 332px; top: 106px; position: fixed; width: 68px; height: 54px; margin-bottom: 0px; right: 877px;" ImageUrl="~/Images/VbsIcon.png"/>
            <asp:Label ID="Label3" runat="server" ForeColor="White" Style="z-index: 1; left: 346px; top: 165px; position: fixed; height: 17px; width: 60px; right: 885px;" Text="Reports" Font-Names="Miriam Fixed" Font-Overline="False" Font-Size="Smaller"></asp:Label>
            <asp:Label ID="Label4" runat="server" ForeColor="White" Style="z-index: 1; left: 350px; top: 152px; position: fixed; height: 17px; width: 46px; right: 893px;" Text="Blend" Font-Names="Miriam Fixed" Font-Overline="False" Font-Size="Smaller"></asp:Label>
            <asp:ImageButton ID="ImageButton4" runat="server" ImageUrl="~/Images/Blank.png" Style="z-index: 1; left: 331px; top: 106px; position: fixed; height: 74px; width: 74px" OnClick="ImageButton4_Click" />

            <asp:ImageButton ID="ImageButton3" runat="server" Style="z-index: 1; left: 332px; top: 195px; position: fixed; width: 68px; height: 54px; margin-bottom: 0px; right: 877px;" ImageUrl="~/Images/VbsIcon.png" />
            <asp:Label ID="Label1" runat="server" ForeColor="White" Style="z-index: 1; left: 344px; top: 254px; position: fixed; height: 17px; width: 76px; right: 869px;" Text="Iteration" Font-Names="Miriam Fixed" Font-Overline="False" Font-Size="Smaller"></asp:Label>
            <asp:Label ID="Label2" runat="server" ForeColor="White" Style="z-index: 1; left: 345px; top: 241px; position: fixed; height: 17px; width: 46px; right: 892px;" Text="Replace" Font-Names="Miriam Fixed" Font-Overline="False" Font-Size="Smaller"></asp:Label>
            <asp:ImageButton ID="ImageButton5" runat="server" ImageUrl="~/Images/Blank.png" Style="z-index: 1; left: 331px; top: 195px; position: fixed; height: 74px; width: 74px" OnClick="ImageButton5_Click" />

            <asp:ImageButton ID="ImageButton6" runat="server" Style="z-index: 1; left: 332px; top: 278px; position: fixed; width: 68px; height: 54px; margin-bottom: 0px; right: 877px;" ImageUrl="~/Images/VbsIcon.png" />
            <asp:Label ID="Label5" runat="server" ForeColor="White" Style="z-index: 1; left: 341px; top: 337px; position: fixed; height: 17px; width: 76px; right: 869px;" Text="Iteration" Font-Names="Miriam Fixed" Font-Overline="False" Font-Size="Smaller"></asp:Label>
            <asp:Label ID="Label6" runat="server" ForeColor="White" Style="z-index: 1; left: 342px; top: 324px; position: fixed; height: 17px; width: 46px; right: 896px;" Text="Seperate" Font-Names="Miriam Fixed" Font-Overline="False" Font-Size="Smaller"></asp:Label>
            <asp:ImageButton ID="ImageButton7" runat="server" ImageUrl="~/Images/Blank.png" Style="z-index: 1; left: 331px; top: 278px; position: fixed; height: 74px; width: 74px" OnClick="ImageButton7_Click" />

            <asp:ImageButton ID="ImageButton8" runat="server" Style="z-index: 1; left: 332px; top: 367px; position: fixed; width: 68px; height: 54px; margin-bottom: 0px; right: 877px;" ImageUrl="~/Images/VbsIcon.png" />
            <asp:Label ID="Label7" runat="server" ForeColor="White" Style="z-index: 1; left: 336px; top: 419px; position: fixed; height: 17px; width: 76px; right: 868px;" Text="Framework" Font-Names="Miriam Fixed" Font-Overline="False" Font-Size="Smaller"></asp:Label>
            <asp:ImageButton ID="ImageButton9" runat="server" ImageUrl="~/Images/Blank.png" Style="z-index: 1; left: 331px; top: 367px; position: fixed; height: 74px; width: 74px" OnClick="ImageButton9_Click" />

        </div>
    </form>
</body>
</html>
