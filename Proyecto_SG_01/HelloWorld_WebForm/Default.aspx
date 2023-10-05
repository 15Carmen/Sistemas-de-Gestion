<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="HelloWorld_WebForm._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <section class="row" aria-labelledby="aspnetTitle">

            <h1 id="aspnetTitle">Hello World</h1>
                       
        </section>

        <div>
            <asp:TextBox ID="TextBox1" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" Text="Saludo" OnClick="Button1_Click" />
            <asp:Label ID="lblError" runat="server" Text="" ForeColor="red"></asp:Label>
        </div>
        <div>
            <asp:Label ID="lblSaludo" runat="server" Text=""></asp:Label>
        </div>
       
    </main>

</asp:Content>
