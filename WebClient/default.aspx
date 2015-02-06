﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="WebClient._default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            height: 47px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table class="style1">
            <tr>
                <td valign="top">
                    &nbsp;</td>
                <td>
                    <asp:Button ID="btnInsertSensorData" runat="server" onclick="BtnInsertSensorDataClick" 
                        Text="Insert Sensor Data" />
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td valign="top">
                    &nbsp;</td>
                <td>
                    <asp:TextBox ID="txtInsertSensorData" runat="server" Height="134px" TextMode="MultiLine" 
                        Width="773px"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td valign="top">
                    &nbsp;</td>
                <td>
                    <asp:Button ID="btnShowSensorData" runat="server" onclick="BtnShowSensorDataClick" 
                        Text="Show Sensor Data" />
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td valign="top">
                    &nbsp;</td>
                <td>
                    <asp:TextBox ID="SensorDataList" runat="server" Height="134px" TextMode="MultiLine" 
                        Width="773px"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
