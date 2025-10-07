<%@ Page Language="C#" AutoEventWireup="true" CodeFile="default.aspx.cs"
Inherits="_Default" %>

<!DOCTYPE html>
<html>
  <head>
    <title>Hello Web Form</title>
  </head>
  <body>
    <form id="test" runat="server">
      <h1>Just a sample ASP.NET Form</h1>
      <asp:Label
        ID="lblMessage"
        runat="server"
        Text="This is a label control."
      ></asp:Label>
      <asp:Button
        ID="btnClick"
        runat="server"
        Text="Click Me"
        OnClick="btnClick_Click"
      />
    </form>
  </body>
</html>
