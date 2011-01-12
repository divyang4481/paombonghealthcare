﻿<%@ Page Title="" Language="C#" MasterPageFile="~/SiteTemplate4.master" AutoEventWireup="true" CodeFile="DeleteMedicine.aspx.cs" Inherits="Medicine_Inventory_DeleteMedicine" %>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <p>
        <br />
    </p>
    <p>
        <a href="#modalwindow" name="modal" style="color: #990033; font-weight: bold;">
        Show List Of Medicines</a>
    </p>
    <p>
        <asp:TextBox ID="txtMedicineId" runat="server" 
            
            onkeydown="return isNumeric(event.keyCode);" onkeyup="keyUP(event.keyCode)" 
                        onpaste="return false;"
            
            style="top: 261px; left: 480px; position: absolute; height: 20px; width: 128px"></asp:TextBox>
    </p>
    <p>
        <asp:Label ID="Label3" runat="server" 
            style="top: 260px; left: 361px; position: absolute; height: 27px; width: 112px" 
            Text="Medicine ID"></asp:Label>
        <asp:Button ID="btn_delMedicine" runat="server" onclick="btn_delMedicine_Click" 
            style="top: 301px; position: absolute; height: 26px; width: 114px; left: 425px" 
            Text="Delete Medicine" />
    </p>
    <p>
        &nbsp;</p>
    <p>
        <asp:SqlDataSource ID="Medicine" runat="server" 
            ConnectionString="<%$ ConnectionStrings:CategoryConnectionString %>" 
            SelectCommand="SELECT DISTINCT [MedicineName] FROM [Medicine] ORDER BY [MedicineName]">
        </asp:SqlDataSource>
    </p>
    <div id="boxes">
           <!-- div for Search Medicine-->
            <div id="modalwindow" class="window">
                <br />
                <table border="1" style="width: 46%;">
                    <tr>
                        <td class="stylecenter" style="width: 385px">
                            &nbsp; &nbsp;&nbsp; List of Medicines</td>
                    </tr>
                    <tr>
                        <td style="width: 385px">
                            <asp:GridView ID="gridViewMedicine" runat="server" AutoGenerateColumns="False" 
                                AutoGenerateSelectButton="True" BackColor="White" BorderColor="#336666" 
                                BorderStyle="Double" BorderWidth="3px" CellPadding="4" 
                                DataKeyNames="MedicineId" DataSourceID="MedicineDataSource" 
                                GridLines="Horizontal" Height="124px" HorizontalAlign="Center" 
                                onselectedindexchanged="gridViewMedicine_SelectedIndexChanged" Width="331px">
                                <Columns>
                                    <asp:BoundField DataField="MedicineId" HeaderText="MedicineId" 
                                        InsertVisible="False" ReadOnly="True" SortExpression="MedicineId" />
                                    <asp:BoundField DataField="MedicineName" HeaderText="MedicineName" 
                                        SortExpression="MedicineName" />
                                    <asp:BoundField DataField="Quantity" HeaderText="Quantity" 
                                        SortExpression="Quantity" />
                                </Columns>
                                <FooterStyle BackColor="White" ForeColor="#333333" />
                                <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="White" ForeColor="#333333" />
                                <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                                <SortedAscendingCellStyle BackColor="#F7F7F7" />
                                <SortedAscendingHeaderStyle BackColor="#487575" />
                                <SortedDescendingCellStyle BackColor="#E5E5E5" />
                                <SortedDescendingHeaderStyle BackColor="#275353" />
                            </asp:GridView>
                            <asp:SqlDataSource ID="MedicineDataSource" runat="server" 
                                ConnectionString="<%$ ConnectionStrings:paombongdbConnectionString %>" 
                                SelectCommand="SELECT DISTINCT [MedicineId],[MedicineName],[Quantity] FROM [Medicine] ORDER BY [MedicineName]">
                            </asp:SqlDataSource>
                        </td>
                    </tr>
                </table>
        </div>
            
            
            <!-- Mask to cover the whole screen -->
            <div id="mask">
        </div>
    </div>
    <p>
        &nbsp;</p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
    <p>
    </p>
</asp:Content>
