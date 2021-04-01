<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="testASPSQLC.webTest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta3/dist/css/bootstrap.min.css?parameter=1" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table style="width: 100%;">
                    <tr>
                        <td class ="c1">&nbsp;Name</td>
                        <td>&nbsp;
                            <input type="text" id ="Name" required="" name="name" />
                        </td>
                       
                    </tr>
                    <tr>
                        <td class ="c1">&nbsp;Email</td>
                        <td>&nbsp;
                            <input type="email" id="Email" required ="" name="email"/>
                        </td>
                       
                    </tr>
                    <tr>
                        <td class ="c1">&nbsp;Password</td>
                        <td>&nbsp;
                             <input type="password" id="Password" name="password" 
                             title="Must contain at least two uppercase letters, three special characters, and one number, and at least 8 characters" 
                             required =""/>
                             
                        </td>
                           
                    </tr>
                    

            
                </table>
            <div>
            </div>
            <br />
            <label for ="DropDownList1">City: </label>   
            <asp:DropDownList ID="DropDownList1" runat="server" required="">
                <asp:ListItem Value="0">--SELECT CITY--</asp:ListItem>
                <asp:ListItem Value="Surrey">Surrey</asp:ListItem>
                <asp:ListItem Value="Vancouver">Vancouver</asp:ListItem>
                <asp:ListItem Value="Richmond">Richmond</asp:ListItem>
                <asp:ListItem Value="Delta">Delta</asp:ListItem>
                <asp:ListItem Value="Langley">Langley</asp:ListItem>
            </asp:DropDownList>
            <br/>
            <br />
            <label for="start">Date:</label>

            <input type="date" id="Date" name="date"
                    value="2021-04-01"
                    min="2021-01-01" max="2021-12-31" required=""/>
            <br/>
            <br />
            <label>Gender</label>
            <br />
            <input type="radio" id="male" name="gender" value="Male" required=""/>
            <label for="male">Male</label>
            <br />
            <input type="radio" id="female" name="gender" value="Female" />
            <label for="female">Female</label>
            <br />
            <input type="radio" id="other" name="gender" value="Other" />
            <label for="other">Other</label>
            <br />
            <br />
            <label>What programming languages do you know?</label>
            <br />
            <asp:CheckBox ID="CheckBox1" runat="server" Text= "Java" name="java"/>
            <br />
            <asp:CheckBox ID="CheckBox2" runat="server" Text= "Python" name="python"/>
            <br />
            <asp:CheckBox ID="CheckBox3" runat="server" Text= "Cplus" name="cplus"/>
            <br />
            <br />
            <label for ="UpdateID">ID to update/delete</label>
            <div class="col-md-1">
                <input type="text" name ="updateID" id="UpdateID" class="form-control"/>
            </div>
            
            <br />
                <asp:Button ID="subm" runat="server" Text="Submit" OnClick="submit_Click" />
                <asp:Button ID="retrieve" runat="server" Text="Retrieve" onClick ="retrieve_Click" formnovalidate =""/>
                <asp:Button ID="update" runat="server" Text="Update" OnClick="update_Click" formnovalidate =""/>
                <asp:Button ID="delete" runat="server" Text="Delete" OnClick="delete_Click" formnovalidate =""/>
                <br />
                <br />
                <label for="searchName">Search ID</label>
            <div class="col-md-1">
                <input type="text" name="searchID" id ="searchID" class="form-control" />
            </div>
                
                <asp:Button ID="SearchButton" runat="server" Text="Search" onClick ="search_Click" formnovalidate =""/>
                
                <asp:GridView ID="GridView1" runat="server" HorizontalAlign="Center" AllowPaging="True" PageSize="5" OnPageIndexChanging ="gridView_PageIndexChanging" AllowSorting="true" OnSorting="gridView_Sorting">
                <PagerSettings Visible="true" Mode="NumericFirstLast" />
                </asp:GridView>
               
                
            </div>
 
    </form>
</body>
</html>
