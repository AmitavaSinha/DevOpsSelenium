<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FillForm.aspx.cs" Inherits="WebSelenium.FillForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <input type="text" id="firstName" />
            <input type="text" id="lastName" />
            <input type="text" id="address1" />
            <input type="text" id="city" />
            <input type="text" id="state" />
            <input type="submit" name="btnSubmit" value="Submit" />
        </div>
    </form>
</body>
</html>
