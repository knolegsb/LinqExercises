<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmLinqDataSource.aspx.cs" Inherits="LinqExercise.FrmLinqDataSource" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
            AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="ProductID" 
            DataSourceID="ldsProducts">
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" 
                    ShowSelectButton="True" />
                <asp:BoundField DataField="ProductID" HeaderText="ProductID" 
                    InsertVisible="False" ReadOnly="True" SortExpression="ProductID" />
                <asp:BoundField DataField="ProductName" HeaderText="ProductName" 
                    SortExpression="ProductName" />
                <asp:TemplateField HeaderText="공급자">
                    <ItemTemplate>
                        <%# Eval("Supplier.CompanyName") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="카테고리">
                    <EditItemTemplate>
                        <asp:DropDownList ID="DropDownList1" runat="server" 
                            DataSourceID="ldsCategories" DataTextField="CategoryName" 
                            DataValueField="CategoryID" SelectedValue='<%# Bind("CategoryID") %>'>
                        </asp:DropDownList>
                        <asp:LinqDataSource ID="ldsCategories" runat="server" 
                            ContextTypeName="LinqExercise.NorthwindDataContext" EntityTypeName="" 
                            Select="new (CategoryID, CategoryName)" TableName="Categories">
                        </asp:LinqDataSource>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <%# Eval("Category.CategoryName") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="CategoryID" HeaderText="CategoryID" 
                    SortExpression="CategoryID" />
                <asp:BoundField DataField="QuantityPerUnit" HeaderText="QuantityPerUnit" 
                    SortExpression="QuantityPerUnit" />
                <asp:BoundField DataField="UnitPrice" HeaderText="UnitPrice" 
                    SortExpression="UnitPrice" />
                <asp:BoundField DataField="UnitsInStock" HeaderText="UnitsInStock" 
                    SortExpression="UnitsInStock" />
                <asp:BoundField DataField="UnitsOnOrder" HeaderText="UnitsOnOrder" 
                    SortExpression="UnitsOnOrder" />
                <asp:BoundField DataField="ReorderLevel" HeaderText="ReorderLevel" 
                    SortExpression="ReorderLevel" />
                <asp:CheckBoxField DataField="Discontinued" HeaderText="Discontinued" 
                    SortExpression="Discontinued" />
            </Columns>
        </asp:GridView>
        <asp:LinqDataSource ID="ldsProducts" runat="server" 
            ContextTypeName="LinqExercise.NorthwindDataContext" EnableDelete="True" 
            EnableInsert="True" EnableUpdate="True" EntityTypeName="" TableName="Products">
        </asp:LinqDataSource>
    </div>
    </form>
</body>
</html>
