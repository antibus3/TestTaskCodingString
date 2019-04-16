<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="TestTaskCodingString._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 200px;
        }
        .auto-style3 {
            width: 200px;
            height: 28px;
        }
        .auto-style4 {
            height: 28px;
            width: 573px;
        }
        .auto-style6 {
            width: 99%;
        }
        .auto-style7 {
            width: 573px;
        }
        .auto-style8 {
            width: 428px;
            height: 68px;
        }
        .auto-style9 {
            height: 68px;
        }
        .auto-style10 {
            width: 100%;
        }
        .auto-style11 {
            width: 428px;
        }
        .auto-style15 {
            width: 254px;
        }
        .auto-style17 {
            width: 286px;
        }
        .auto-style18 {
            width: 286px;
            height: 61px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">

        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <br />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:Label ID="GlobalError" runat="server" BackColor="#0066CC"></asp:Label>
                <br />
                Заполнение списка объектов (используется для пополнения списка объектов теплопотребления):&nbsp;<br />
                <table class="auto-style10">
                    <tr>
                        <td class="auto-style8">Наименование объекта:</td>
                        <td class="auto-style9" rowspan="3">
                            <asp:ListBox ID="ListObject" runat="server" Height="114px" Width="296px"></asp:ListBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style11">
                            <asp:TextBox ID="InputNameObject" runat="server" Width="164px"></asp:TextBox>
                        </td>

                    </tr>
                    <tr>
                        <td class="auto-style11">
                            <asp:Button ID="InputObjectButton" runat="server" Text="Записать" OnClick="InputObjectButton_Click" />
                        </td>

                    </tr>
                </table>
                <br />
                <br />
                <br />
                Для генерации кода к обьекту теплопотребления, запоните его поля и нажмите кнопку &quot;Кодирование&quot;<br /> 
                <table class="auto-style6">
                    <tr>
                        <td class="auto-style1">Обьект:</td>
                        <td class="auto-style7">
                            <asp:DropDownList ID="NameIDSelect" runat="server">
                            </asp:DropDownList>
                        </td>
                        <td rowspan ="5">
                            Список кодирований:
                            <asp:ListBox ID="HistoryCodingList" runat="server" Height="294px" Width="383px"></asp:ListBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style3">Номер л\с:</td>
                        <td class="auto-style4">
                            <asp:TextBox ID="PersonalAccount" runat="server"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorPersonalAccount" runat="server" ControlToValidate="PersonalAccount" ErrorMessage="Длина поля должны быть 8 цифр" ValidationExpression="[0-9]{8}" Display="Dynamic" EnableClientScript="False" BackColor="Red"></asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorPersonalAccount" runat="server" ControlToValidate="PersonalAccount" EnableClientScript="False" ErrorMessage="Поле не должно быть пустым" BackColor="Red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style1">Дата: </td>
                        <td class="auto-style7">
                            <asp:Calendar ID="Calendar" runat="server"></asp:Calendar>
                            <asp:Label ID="DataError" runat="server" Text="Выбранная дата за пределами допустимого диапазона" Visible="False" BackColor="Red"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:RadioButtonList ID="ChoiceGenerator" runat="server">
                                <asp:ListItem Selected="True">Алгоритм 1</asp:ListItem>
                                <asp:ListItem>Алгоритм 2</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                        <td class="auto-style7">
                            <asp:Button ID="CodingButton" runat="server" OnClick="CodingButton_Click" Text="Кодирование" />
                        </td>
                    </tr>
                    <tr>
                        <td>Закодированная строка:</td>
                        <td class="auto-style7">
                            <asp:TextBox ID="CodingString" runat="server" Width="237px"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <br />
                <br />
                <br />
                Для декодирования, введите код в строку и нажмите кнопку &quot;Декодировать&quot;<br />
                <table style="width:100%;">
                    <tr>
                        <td class="auto-style17">Строка декодирования:</td>
                        <td class="auto-style15">
                            <asp:TextBox ID="DecodingString" runat="server" Width="228px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Button ID="DecodingButton" runat="server" Text="Декодировать" OnClick="DecodingButton_Click" />
                            <asp:Label ID="DecodingError" runat="server" BackColor="Red" Text="Строка имеет неверный формат" Visible="False"></asp:Label>
                            <asp:Label ID="ObjectFiled" runat="server" BackColor="#CC0000" Text="Объект не найден" Visible="False"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style18">Имя объекта:&nbsp;
                            <asp:Label ID="NameObjectInput" runat="server"></asp:Label>
                            <br />
                            Л\С:
                            <asp:Label ID="PersonalAccountInput" runat="server"></asp:Label>
                            <br />
                            Дата:
                            <asp:Label ID="DateInput" runat="server"></asp:Label>
                        </td>
                    </tr>

                </table>
                <br />
            </ContentTemplate>
        </asp:UpdatePanel>

    </form>
</body>
</html>
