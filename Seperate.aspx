<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Seperate.aspx.cs" Inherits="aUTOMATION.Seperate" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="margin: 0px;">
    <form id="form1" runat="server">
        <div style="background-image: url('Images/BG1.png'); background-attachment: fixed; background-repeat: no-repeat; height: 732px; width: 1600px;">
            
            <asp:ImageButton ID="ImageButton10" runat="server" ImageUrl="~/Images/LogoutBtn.png" style="z-index: 1; left: 922px; top: 443px; position: fixed; height: 14px; width: 15px" OnClick="ImageButton10_Click" ToolTip="Logout" />

            <asp:FileUpload ID="FileUpload1" runat="server" Style="z-index: 1; left: 661px; top: 186px; width:180px; position: fixed" />
            <asp:FileUpload ID="FileUpload2" runat="server" Style="z-index: 1; left: 661px; top: 238px; width:180px; position: fixed" />
            <asp:TextBox ID="TextBox1" runat="server" Style="z-index: 1; left: 661px; top: 288px; position: fixed" MaxLength="2">12</asp:TextBox>
            <asp:TextBox ID="TextBox2" runat="server" Style="z-index: 1; left: 661px; top: 339px; position: fixed">Rerun</asp:TextBox>

            <asp:Button ID="Button1" runat="server" ForeColor="Black" Style="z-index: 1; left: 445px; top: 389px; position: fixed; width: 99px; right: 508px;" Text="Download" Font-Size="Medium" OnClick="Button1_Click" />
            <asp:Button ID="Button2" runat="server" ForeColor="Black" Style="z-index: 1; left: 661px; top: 389px; position: fixed; width: 99px; right: 508px;" Text="Submit" Font-Size="Medium" OnClick="Button2_Click" />
            <asp:Label ID="Label1" runat="server" Style="z-index: 1; left: 530px; top: 127px; position: fixed; right: 215px; width: 228px;" Text="Seperate Iterations" Font-Size="X-Large" Font-Bold="True" Font-Underline="True"></asp:Label>

            <asp:Label ID="Label2" runat="server" Font-Size="X-Large" ForeColor="Black" Style="z-index: 1; left: 445px; top: 181px; position: fixed; height: 29px; width: 193px" Text="Report" BorderStyle="None" Font-Bold="True" Font-Names="Centaur"></asp:Label>
            <asp:Label ID="Label3" runat="server" Font-Size="X-Large" ForeColor="Black" Style="z-index: 1; left: 445px; top: 232px; position: fixed; height: 29px; width: 193px; bottom: 279px;" Text="Test Data" BorderStyle="None" Font-Bold="True" Font-Names="Centaur"></asp:Label>
            <asp:Label ID="Label4" runat="server" Font-Size="X-Large" ForeColor="Black" Style="z-index: 1; left: 445px; top: 283px; position: fixed; height: 29px; width: 193px" Text="Column No." BorderStyle="None" Font-Bold="True" Font-Names="Centaur"></asp:Label>
            <asp:Label ID="Label5" runat="server" Font-Size="X-Large" ForeColor="Black" Style="z-index: 1; left: 445px; top: 334px; position: fixed; height: 29px; width: 193px; right: 647px;" Text="Cell Value" BorderStyle="None" Font-Bold="True" Font-Names="Centaur"></asp:Label>

            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" Style="z-index: 1; left: 858px; top: 114px; position: fixed" Font-Size="Large" ForeColor="#3366CC">Template</asp:LinkButton>

            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/BackBtn.png" OnClick="ImageButton1_Click" Style="z-index: 1; left: 334px; top: 109px; position: fixed; height: 28px; width: 28px" />

        </div>
    </form>
</body>
</html>
