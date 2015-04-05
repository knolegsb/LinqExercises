<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmLinqToSql.aspx.cs" Inherits="LinqExercise.FrmLinqToSql" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="btnSelect" runat="server" Text="출력" OnClick="btnSelect_Click" />
            <asp:Button ID="btnInsert" runat="server" Text="입력" OnClick="btnInsert_Click" />
            <asp:Button ID="btnUpdate" runat="server" Text="수정" OnClick="btnUpdate_Click" />
            <asp:Button ID="btnDelete" runat="server" Text="삭제" OnClick="btnDelete_Click" />

            <hr />
            <asp:GridView ID="ctrl" runat="server"></asp:GridView>
        </div>
    </form>
</body>
</html>
