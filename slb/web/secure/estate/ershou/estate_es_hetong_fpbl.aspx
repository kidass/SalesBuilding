<%@ Page Language="vb" AutoEventWireup="false" Codebehind="estate_es_hetong_fpbl.aspx.vb" Inherits="Josco.JSOA.web.estate_es_hetong_fpbl" %>
<%@ Register TagPrefix="uwin" Namespace="Josco.Web" Assembly="Josco.Web.PopMessage" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
    <HEAD>
        <title>ҵ�������������</title>
        <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
        <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
        <meta content="JavaScript" name="vs_defaultClientScript">
        <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <LINK href="../../../styles01.css" type="text/css" rel="stylesheet">
        <style>
		    TD.grdSYBLLocked { ; LEFT: expression(divSYBL.scrollLeft); POSITION: relative }
		    TH.grdSYBLLocked { ; LEFT: expression(divSYBL.scrollLeft); POSITION: relative }
		    TH.grdSYBLLocked { Z-INDEX: 99 }
		    TD.grdGYBLLocked { ; LEFT: expression(divGYBL.scrollLeft); POSITION: relative }
		    TH.grdGYBLLocked { ; LEFT: expression(divGYBL.scrollLeft); POSITION: relative }
		    TH.grdGYBLLocked { Z-INDEX: 99 }
		    TH { Z-INDEX: 10; POSITION: relative }
        </style>
        <script src="../../../scripts/transkey.js"></script>
        <script language="javascript">
		<!--
			function window_onresize() 
			{
				var dblHeight = 0;
				var dblWidth  = 0;
				var strHeight = "";
				var strWidth  = "";
				
				if (document.all("divGYBL") == null)
					return;
				
				intWidth   = document.body.clientWidth;   //�ܿ��
				intWidth  -= 24;                          //������
				intWidth  -= 2 * 4;                       //���ҿհ�
				intWidth  -= 16;                          //������
				strWidth   = intWidth.toString() + "px";
				
				intHeight  = document.body.clientHeight;  //�ܸ߶�
				intHeight -= 24;                          //������
				intHeight -= trRow1.clientHeight;
				intHeight -= trRow2.clientHeight;
				intHeight -= trRow3.clientHeight;
				intHeight -= trRow4.clientHeight;
				intHeight -= trRow5.clientHeight;
				intHeight -= trRow6.clientHeight;
				intHeight -= trRow7.clientHeight;
				strHeight  = intHeight.toString() + "px";
				//if (document.readyState.toLowerCase() == "complete")
                //    alert(strWidth + " " + strHeight);
				divGYBL.style.width  = strWidth;
				divGYBL.style.height = strHeight;
				divGYBL.style.clip   = "rect(0px " + strWidth + " " + strHeight + " 0px)";
				
				divSYBL.style.width  = strWidth;
				strHeight = divSYBL.style.height;
				divSYBL.style.clip   = "rect(0px " + strWidth + " " + strHeight + " 0px)";
			}
			function document_onreadystatechange() 
			{
				return window_onresize();
			}
		//-->
        </script>
        <script language="javascript" for="document" event="onreadystatechange">
		<!--
			return document_onreadystatechange()
		//-->
        </script>
    </HEAD>
    <body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" onresize="return window_onresize()">
        <form id="frmestate_es_hetong_fpbl" method="post" runat="server">
            <asp:panel id="panelMain" Runat="server">
                <TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
                    <TR>
                        <TD width="5"></TD>
                        <TD vAlign="top" align="center">
                            <TABLE cellSpacing="0" cellPadding="0" border="0">
                                <TR id="trRow1">
                                    <TD class="title" align="center" colSpan="3" height="30">ҵ�������������<asp:LinkButton id="lnkBlank" Runat="server" Width="0px"></asp:LinkButton></TD>
                                </TR>
                                <TR>
                                    <TD width="5"></TD>
                                    <TD vAlign="top">
                                        <DIV id="divMain" style="BORDER-TOP: #99cccc 2px solid; BORDER-BOTTOM: #99cccc 2px solid;">
                                            <TABLE cellSpacing="0" cellPadding="0" border="0" align="center">
                                                <TR id="trRow2">
                                                    <TD class="label" align="left" bgColor="#ccff99"><b>&gt;&gt;&gt;&gt;ҵ��Աҵ���������</b></TD>
                                                </TR>
                                                <TR id="trRow3">
                                                    <TD align="center">
                                                        <DIV id="divSYBL" style="BORDER-RIGHT: #99cccc 1px solid; TABLE-LAYOUT: fixed; BORDER-TOP: #99cccc 1px solid; OVERFLOW: auto; BORDER-LEFT: #99cccc 1px solid; WIDTH: 900px; CLIP: rect(0px 900px 120px 0px); BORDER-BOTTOM: #99cccc 1px solid; HEIGHT: 120px">
                                                            <asp:datagrid id="grdSYBL" runat="server" UseAccessibleHeader="True" AllowPaging="False" AutoGenerateColumns="False"
                                                                GridLines="Vertical" BackColor="White" BorderStyle="None" PageSize="30" BorderColor="#DEDFDE"
                                                                BorderWidth="0px" AllowSorting="False" CellPadding="4" CssClass="label">
                                                                <FooterStyle BackColor="#CCCC99"></FooterStyle>
                                                                <SelectedItemStyle ForeColor="#CC0000" VerticalAlign="Middle" BackColor="#FFFFDD"></SelectedItemStyle>
                                                                <EditItemStyle VerticalAlign="Middle" BackColor="#FFCC00"></EditItemStyle>
                                                                <AlternatingItemStyle BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="White"></AlternatingItemStyle>
                                                                <ItemStyle BorderWidth="0px" ForeColor="Black" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="#F7F7F7"></ItemStyle>
                                                                <HeaderStyle Font-Bold="True" HorizontalAlign="Left" ForeColor="White" VerticalAlign="Middle" BackColor="#6699cc"></HeaderStyle>
                                                               
                                                                <Columns>
                                                                    <asp:TemplateColumn HeaderText="ѡ" ItemStyle-Width="20px">
                                                                        <HeaderStyle HorizontalAlign="Center" Width="20px"></HeaderStyle>
                                                                        <ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox id="chkSYBL" runat="server" AutoPostBack="False"></asp:CheckBox>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    
                                                                    <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="Ψһ��ʶ" SortExpression="Ψһ��ʶ" HeaderText="Ψһ��ʶ" CommandName="Select">
                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="0px" Visible="False" DataTextField="ȷ�����" SortExpression="ȷ�����" HeaderText="ȷ�����" CommandName="Select">
                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="0px" Visible="False" DataTextField="��Ա����" SortExpression="��Ա����" HeaderText="��Ա����" CommandName="Select">
                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="100px" DataTextField="��Ա����" SortExpression="��Ա����" HeaderText="��Ա����" CommandName="Select">
                                                                        <HeaderStyle Width="100px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="��λ����" SortExpression="��λ����" HeaderText="��λ����" CommandName="Select">
                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="300px" DataTextField="��λ����" SortExpression="��λ����" HeaderText="��λ����" CommandName="Select">
                                                                        <HeaderStyle Width="300px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="200px" DataTextField="��������" SortExpression="��������" HeaderText="��������" CommandName="Select">
                                                                        <HeaderStyle Width="200px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="60px" DataTextField="�Ŷӱ��" SortExpression="�Ŷӱ��" HeaderText="�Ŷ�" CommandName="Select">
                                                                        <HeaderStyle Width="60px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="��Աְ��" SortExpression="��Աְ��" HeaderText="��Աְ����" CommandName="Select">
                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="240px" DataTextField="��Աְ������" SortExpression="��Աְ������" HeaderText="ְ��" CommandName="Select">
                                                                        <HeaderStyle Width="240px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="120px" DataTextField="�������" SortExpression="�������" HeaderText="�������" CommandName="Select" DataTextFormatString="{0:#.00%}" ItemStyle-HorizontalAlign="Right">
                                                                        <HeaderStyle Width="120px" HorizontalAlign="Right"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="ֱ�ܱ��" SortExpression="ֱ�ܱ��" HeaderText="ֱ�ܱ��" CommandName="Select">
                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="80px" DataTextField="ֱ�ܱ������" SortExpression="ֱ�ܱ������" HeaderText="ֱ��" CommandName="Select">
                                                                        <HeaderStyle Width="80px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="״̬��־" SortExpression="״̬��־" HeaderText="״̬��־" CommandName="Select">
                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="80px" DataTextField="״̬��־����" SortExpression="״̬��־����" HeaderText="״̬" CommandName="Select">
                                                                        <HeaderStyle Width="80px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                </Columns>
                                                                
                                                                <PagerStyle Visible="False" NextPageText="��ҳ" PrevPageText="��ҳ" HorizontalAlign="Right" ForeColor="Black" Position="TopAndBottom" BackColor="SkyBlue"></PagerStyle>
                                                            </asp:datagrid><INPUT id="htxtSYBLFixed" type="hidden" value="0" runat="server">
                                                        </DIV>
                                                    </TD>
                                                </TR>
                                                <TR id="trRow4">
                                                    <TD align="center">
                                                        <% if propEditMode()=false then response.write("<div style='display:none'>") %>
                                                        <TABLE cellSpacing="0" cellPadding="0" border="0" width="100%">
                                                            <TR>
                                                                <TD class="labelNotNull" noWrap align="right">��Ա</TD>
                                                                <TD align="left"><asp:TextBox id="txtSY_RYDM" Runat="server" CssClass="textbox" Columns="7"></asp:TextBox><asp:Button id="btnSelect_SY_RYDM" Runat="server" CssClass="button" Text="��"></asp:Button><INPUT id="htxtSY_RYDM" type="hidden" size="1" runat="server"></TD>
                                                                <TD class="labelNotNull" noWrap align="right">��λ</TD>
                                                                <TD align="left"><asp:TextBox id="txtSY_DWDM" Runat="server" CssClass="textbox" Columns="14"></asp:TextBox><asp:Button id="btnSelect_SY_DWDM" Runat="server" CssClass="button" Text="��"></asp:Button><INPUT id="htxtSY_DWDM" type="hidden" size="1" runat="server"></TD>
                                                                <!-- zengxianglin 2008-10-14-->
                                                                <TD class="label" noWrap align="right">����</TD>
                                                                <TD align="left"><asp:DropDownList id="ddlSY_SSFZ" Runat="server" CssClass="textbox" Width="90px"></asp:DropDownList></TD>
                                                                <!-- zengxianglin 2008-10-14-->
                                                                <!-- zengxianglin 2010-01-06-->
                                                                <TD class="label" noWrap align="right">�Ŷ�</TD>
                                                                <TD align="left"><asp:TextBox id="txtSY_TDBH" Runat="server" CssClass="textbox" Columns="2" ReadOnly="True"></asp:TextBox><asp:Button id="btnSelect_SY_TDBH" Runat="server" CssClass="button" Text="��"></asp:Button></TD>
                                                                <!-- zengxianglin 2010-01-06-->
                                                                <TD class="labelNotNull" noWrap align="right">ְ��</TD>
                                                                <TD align="left"><asp:DropDownList id="ddlSY_ZJDM" Runat="server" CssClass="textbox"></asp:DropDownList></TD>
                                                                <TD class="labelNotNull" noWrap align="right">����(%)</TD>
                                                                <TD align="left"><asp:TextBox id="txtSY_FPBL" Runat="server" CssClass="textbox" Columns="4"></asp:TextBox></TD>
                                                                <TD align="right">
                                                                    <asp:Button id="btnAddNew_SY" Runat="server" CssClass="button" Text="����"></asp:Button>
                                                                    <asp:Button id="btnUpdate_SY" Runat="server" CssClass="button" Text="�޸�"></asp:Button>
                                                                    <asp:Button id="btnDelete_SY" Runat="server" CssClass="button" Text="ɾ��"></asp:Button>
                                                                </TD>
                                                            </TR>
                                                        </TABLE>
                                                        <% if propEditMode()=false then response.write("</div>") %>
                                                    </TD>
                                                </TR>
                                                <TR id="trRow5">
                                                    <TD class="label" align="left" bgColor="#ccff99"><b>&gt;&gt;&gt;&gt;��ع�����Աҵ���������</b></TD>
                                                </TR>
                                                <TR>
                                                    <TD align="center">
                                                        <DIV id="divGYBL" style="BORDER-RIGHT: #99cccc 1px solid; TABLE-LAYOUT: fixed; BORDER-TOP: #99cccc 1px solid; OVERFLOW: auto; BORDER-LEFT: #99cccc 1px solid; WIDTH: 900px; CLIP: rect(0px 900px 240px 0px); BORDER-BOTTOM: #99cccc 1px solid; HEIGHT: 240px">
                                                            <asp:datagrid id="grdGYBL" runat="server" UseAccessibleHeader="True" AllowPaging="False" AutoGenerateColumns="False"
                                                                GridLines="Vertical" BackColor="White" BorderStyle="None" PageSize="30" BorderColor="#DEDFDE"
                                                                BorderWidth="0px" AllowSorting="False" CellPadding="4" CssClass="label">
                                                                <FooterStyle BackColor="#CCCC99"></FooterStyle>
                                                                <SelectedItemStyle ForeColor="#CC0000" VerticalAlign="Middle" BackColor="#FFFFDD"></SelectedItemStyle>
                                                                <EditItemStyle VerticalAlign="Middle" BackColor="#FFCC00"></EditItemStyle>
                                                                <AlternatingItemStyle BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="White"></AlternatingItemStyle>
                                                                <ItemStyle BorderWidth="0px" ForeColor="Black" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="#F7F7F7"></ItemStyle>
                                                                <HeaderStyle Font-Bold="True" HorizontalAlign="Left" ForeColor="White" VerticalAlign="Middle" BackColor="#6699cc"></HeaderStyle>
                                                                <Columns>
                                                                    <asp:TemplateColumn HeaderText="ѡ">
                                                                        <HeaderStyle HorizontalAlign="Center" Width="20px"></HeaderStyle>
                                                                        <ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox id="chkGYBL" runat="server" AutoPostBack="False"></asp:CheckBox>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="0px" Visible="False" DataTextField="Ψһ��ʶ" SortExpression="Ψһ��ʶ" HeaderText="Ψһ��ʶ" CommandName="Select">
                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="0px" Visible="False" DataTextField="ȷ�����" SortExpression="ȷ�����" HeaderText="ȷ�����" CommandName="Select">
                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="0px" Visible="False" DataTextField="��Ա����" SortExpression="��Ա����" HeaderText="��Ա����" CommandName="Select">
                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="100px" DataTextField="��Ա����" SortExpression="��Ա����" HeaderText="��Ա����" CommandName="Select">
                                                                        <HeaderStyle Width="100px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="0px" Visible="False" DataTextField="��λ����" SortExpression="��λ����" HeaderText="��λ����" CommandName="Select">
                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="300px" DataTextField="��λ����" SortExpression="��λ����" HeaderText="��λ����" CommandName="Select">
                                                                        <HeaderStyle Width="300px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="200px" DataTextField="��������" SortExpression="��������" HeaderText="��������" CommandName="Select">
                                                                        <HeaderStyle Width="200px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="60px" DataTextField="�Ŷӱ��" SortExpression="�Ŷӱ��" HeaderText="�Ŷ�" CommandName="Select">
                                                                        <HeaderStyle Width="60px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="0px" Visible="False" DataTextField="��Աְ��" SortExpression="��Աְ��" HeaderText="��Աְ����" CommandName="Select">
                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="240px" DataTextField="��Աְ������" SortExpression="��Աְ������" HeaderText="ְ��" CommandName="Select">
                                                                        <HeaderStyle Width="240px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="120px" DataTextField="�������" SortExpression="�������" HeaderText="�������" CommandName="Select" DataTextFormatString="{0:#.00%}" ItemStyle-HorizontalAlign="Right">
                                                                        <HeaderStyle Width="120px" HorizontalAlign="Right"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="0px" Visible="False" DataTextField="ֱ�ܱ��" SortExpression="ֱ�ܱ��" HeaderText="ֱ�ܱ��" CommandName="Select">
                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="80px" DataTextField="ֱ�ܱ������" SortExpression="ֱ�ܱ������" HeaderText="ֱ��" CommandName="Select">
                                                                        <HeaderStyle Width="80px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="0px" Visible="False" DataTextField="״̬��־" SortExpression="״̬��־" HeaderText="״̬��־" CommandName="Select">
                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="80px" DataTextField="״̬��־����" SortExpression="״̬��־����" HeaderText="״̬" CommandName="Select">
                                                                        <HeaderStyle Width="80px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                </Columns>
                                                                <PagerStyle Visible="False" NextPageText="��ҳ" PrevPageText="��ҳ" HorizontalAlign="Right" ForeColor="Black" Position="TopAndBottom" BackColor="SkyBlue"></PagerStyle>
                                                            </asp:datagrid><INPUT id="htxtGYBLFixed" type="hidden" value="0" runat="server">
                                                        </DIV>
                                                    </TD>
                                                </TR>
                                                <TR id="trRow6">
                                                    <TD align="center">
                                                        <% if propEditMode_GY()=false then response.write("<div style='display:none'>") %>
                                                        <TABLE cellSpacing="0" cellPadding="0" border="0" width="100%">
                                                            <TR>
                                                                <TD class="labelNotNull" noWrap align="right">��Ա</TD>
                                                                <TD align="left"><asp:TextBox id="txtGY_RYDM" Runat="server" CssClass="textbox" Columns="7"></asp:TextBox><asp:Button id="btnSelect_GY_RYDM" Runat="server" CssClass="button" Text="��"></asp:Button><INPUT id="htxtGY_RYDM" type="hidden" size="1" runat="server"></TD>
                                                                <TD class="labelNotNull" noWrap align="right">��λ</TD>
                                                                <TD align="left"><asp:TextBox id="txtGY_DWDM" Runat="server" CssClass="textbox" Columns="14"></asp:TextBox><asp:Button id="btnSelect_GY_DWDM" Runat="server" CssClass="button" Text="��"></asp:Button><INPUT id="htxtGY_DWDM" type="hidden" size="1" runat="server"></TD>
                                                                <!-- zengxianglin 2008-10-14-->
                                                                <TD class="label" noWrap align="right">����</TD>
                                                                <TD align="left"><asp:DropDownList id="ddlGY_SSFZ" Runat="server" CssClass="textbox" Width="90px"></asp:DropDownList></TD>
                                                                <!-- zengxianglin 2008-10-14-->
                                                                <!-- zengxianglin 2010-01-06-->
                                                                <TD class="label" noWrap align="right">�Ŷ�</TD>
                                                                <TD align="left"><asp:TextBox id="txtGY_TDBH" Runat="server" CssClass="textbox" Columns="2" ReadOnly="True"></asp:TextBox><asp:Button id="btnSelect_GY_TDBH" Runat="server" CssClass="button" Text="��"></asp:Button></TD>
                                                                <!-- zengxianglin 2010-01-06-->
                                                                <TD class="labelNotNull" noWrap align="right">ְ��</TD>
                                                                <TD align="left"><asp:DropDownList id="ddlGY_ZJDM" Runat="server" CssClass="textbox"></asp:DropDownList></TD>
                                                                <TD class="labelNotNull" noWrap align="right">����(%)</TD>
                                                                <TD align="left"><asp:TextBox id="txtGY_FPBL" Runat="server" CssClass="textbox" Columns="4"></asp:TextBox></TD>
                                                                <TD class="labelNotNull" noWrap align="right"></TD>
                                                                <TD align="left">
                                                                    <asp:RadioButtonList id="rblGY_ZGBZ" Runat="server" CssClass="textbox" RepeatLayout="Flow" RepeatDirection="Vertical" RepeatColumns="2">
                                                                        <asp:ListItem Value="0">Э��</asp:ListItem>
                                                                        <asp:ListItem Value="1">ֱ��</asp:ListItem>
                                                                    </asp:RadioButtonList>
                                                                </TD>
                                                                <TD align="right">
                                                                    <asp:Button id="btnAddNew_GY" Runat="server" CssClass="button" Text="����"></asp:Button>
                                                                    <asp:Button id="btnUpdate_GY" Runat="server" CssClass="button" Text="�޸�"></asp:Button>
                                                                    <asp:Button id="btnDelete_GY" Runat="server" CssClass="button" Text="ɾ��"></asp:Button>
                                                                </TD>
                                                            </TR>
                                                        </TABLE>
                                                        <% if propEditMode_GY()=false then response.write("</div>") %>
                                                    </TD>
                                                </TR>
                                            </TABLE>
                                        </DIV>
                                    </TD>
                                    <TD width="5"></TD>
                                </TR>
                            </TABLE>
                        </TD>
                        <TD width="5"></TD>
                    </TR>
                    <TR id="trRow7">
                        <TD align="center" colSpan="3">
                            <TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
                                <tr>
                                    <td height="4"></td>
                                </tr>
                                <TR>
                                    <TD align="center">
                                        <asp:Button id="btnMake"  Runat="server" CssClass="button" Text="�Զ�����" Height="36px"></asp:Button>
                                        <asp:Button id="btnSYBL"  Runat="server" CssClass="button" Text="ͬ��˽Ӷ" Height="36px"></asp:Button>
                                        <asp:Button id="btnOK"    Runat="server" CssClass="button" Text="ȷ    ��" Height="36px"></asp:Button>
                                        <asp:Button id="btnClose" Runat="server" CssClass="button" Text="��    ��" Height="36px"></asp:Button>
                                    </TD>
                                </TR>
                            </TABLE>
                        </TD>
                    </TR>
                </TABLE>
            </asp:panel>
            <asp:Panel id="panelError" Runat="server">
                <TABLE id="tabErrMain" height="98%" cellSpacing="0" cellPadding="0" width="100%" border="0">
                    <TR>
                        <TD width="5%"></TD>
                        <TD>
                            <TABLE id="tabErrInfo" height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
                                <TR>
                                    <TD>&nbsp;&nbsp;&nbsp;&nbsp;</TD>
                                    <TD id="tdErrInfo" style="FONT-SIZE: 32pt; COLOR: black; LINE-HEIGHT: 40pt; FONT-FAMILY: ����; LETTER-SPACING: 2pt" align="center"><asp:Label id="lblMessage" Runat="server"></asp:Label><P>&nbsp;&nbsp;</P><P><asp:Button id="btnGoBack" Runat="server" Text=" ���� " Font-Size="24pt"></asp:Button></P></TD>
                                    <TD>&nbsp;&nbsp;&nbsp;&nbsp;</TD>
                                </TR>
                            </TABLE>
                        </TD>
                        <TD width="5%"></TD>
                    </TR>
                </TABLE>
            </asp:Panel>
            <table cellSpacing="0" cellPadding="0" align="center" border="0">
                <tr>
                    <td>
                        <input id="htxtSessionIdGYBL" type="hidden" runat="server">
                        <input id="htxtSessionIdSYBL" type="hidden" runat="server">
                        <input id="htxtDivLeftGYBL" type="hidden" runat="server">
                        <input id="htxtDivTopGYBL" type="hidden" runat="server">
                        <input id="htxtDivLeftSYBL" type="hidden" runat="server">
                        <input id="htxtDivTopSYBL" type="hidden" runat="server">
                        <input id="htxtDivLeftMain" type="hidden" runat="server">
                        <input id="htxtDivTopMain" type="hidden" runat="server">
                        <input id="htxtDivLeftBody" type="hidden" runat="server">
                        <input id="htxtDivTopBody" type="hidden" runat="server">
                    </td>
                </tr>
                <tr>
                    <td>
                        <script language="javascript">
							function ScrollProc_Body() {
								var oText;
								oText=null;
								oText=document.getElementById("htxtDivTopBody");
								if (oText != null) oText.value = document.body.scrollTop;
								oText=null;
								oText=document.getElementById("htxtDivLeftBody");
								if (oText != null) oText.value = document.body.scrollLeft;
								return;
							}
							function ScrollProc_divMain() {
								var oText;
								oText=null;
								oText=document.getElementById("htxtDivTopMain");
								if (oText != null) oText.value = divMain.scrollTop;
								oText=null;
								oText=document.getElementById("htxtDivLeftMain");
								if (oText != null) oText.value = divMain.scrollLeft;
								return;
							}
							function ScrollProc_divSYBL() {
								var oText;
								oText=null;
								oText=document.getElementById("htxtDivTopSYBL");
								if (oText != null) oText.value = divSYBL.scrollTop;
								oText=null;
								oText=document.getElementById("htxtDivLeftSYBL");
								if (oText != null) oText.value = divSYBL.scrollLeft;
								return;
							}
							function ScrollProc_divGYBL() {
								var oText;
								oText=null;
								oText=document.getElementById("htxtDivTopGYBL");
								if (oText != null) oText.value = divGYBL.scrollTop;
								oText=null;
								oText=document.getElementById("htxtDivLeftGYBL");
								if (oText != null) oText.value = divGYBL.scrollLeft;
								return;
							}
							try {
								var Text;

								oText=null;
								oText=document.getElementById("htxtDivTopBody");
								if (oText != null) document.body.scrollTop = oText.value;
								oText=null;
								oText=document.getElementById("htxtDivLeftBody");
								if (oText != null) document.body.scrollLeft = oText.value;

								oText=null;
								oText=document.getElementById("htxtDivTopMain");
								if (oText != null) divMain.scrollTop = oText.value;
								oText=null;
								oText=document.getElementById("htxtDivLeftMain");
								if (oText != null) divMain.scrollLeft = oText.value;

								oText=null;
								oText=document.getElementById("htxtDivTopSYBL");
								if (oText != null) divSYBL.scrollTop = oText.value;
								oText=null;
								oText=document.getElementById("htxtDivLeftSYBL");
								if (oText != null) divSYBL.scrollLeft = oText.value;

								oText=null;
								oText=document.getElementById("htxtDivTopGYBL");
								if (oText != null) divGYBL.scrollTop = oText.value;
								oText=null;
								oText=document.getElementById("htxtDivLeftGYBL");
								if (oText != null) divGYBL.scrollLeft = oText.value;

								document.body.onscroll = ScrollProc_Body;
								divSYBL.onscroll = ScrollProc_divSYBL;
							}
							catch (e) {}
                        </script>
                    </td>
                </tr>
                <tr>
                    <td>
                        <script language="javascript">window_onresize();</script>
                        <uwin:popmessage id="popMessageObject" runat="server" height="48px" width="96px" Visible="False" ActionType="OpenWindow" PopupWindowType="Normal" EnableViewState="False"></uwin:popmessage>
                    </td>
                </tr>
            </table>
        </form>
    </body>
</HTML>
