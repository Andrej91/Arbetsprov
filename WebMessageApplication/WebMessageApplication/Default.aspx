<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebMessageApplication.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Message History</title>

    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link rel="stylesheet" href="styles.css" />
</head>
<body>
    <form id="form1" runat="server">

    <!-- Jumbatron -->
        <div class="jumbotron">
            <div class="container">
                <div class="row">
                    <div class="text-center">
                        <h1>Message History</h1>
                        <p>To clear the message history, press the button</p>
                        <asp:Button ID="btnClearMessages" runat="server" Text="Clear Messages" class="btn btn-lg btn-default" OnClick="btnClearMessages_Click"/>
                    </div>
                </div>
            </div>
        </div>

        <div class="container">
            <div class="row">

                <asp:Repeater ID="rptRetrievedMessages" runat="server" DataSourceID="SqlDataSource">       
                    <ItemTemplate>
                        <div class="smal-container">
  
                                <p class="p-time">Published:<asp:Label ID="lblTime" runat="server" Text='<%# Eval("time")%>' CssClass="label"></asp:Label></p>

                                <p class="p-message">Message:</p><asp:Label ID="lblMessage" runat="server" Text='<%# Eval("message")%>' CssClass="label"></asp:Label>
                        
                        </div>
                    </ItemTemplate>     
                </asp:Repeater>
                <asp:SqlDataSource ID="SqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:MessageDatabaseConnectionString %>" SelectCommand="SELECT [message], [time] FROM [Messages] ORDER BY [time] DESC"></asp:SqlDataSource>
            </div>
        </div>
    </form>
</body>
</html>
