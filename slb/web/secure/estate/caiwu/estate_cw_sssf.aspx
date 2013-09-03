<%@ Page Language="vb" AutoEventWireup="false" Codebehind="estate_cw_sssf.aspx.vb" Inherits="Josco.JSOA.web.estate_cw_sssf" %>
<%@ Register TagPrefix="uwin" Namespace="Josco.Web" Assembly="Josco.Web.PopMessage" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
    <HEAD>
        <title>�տ�򸶿��</title>
        <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
        <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
        <meta content="JavaScript" name="vs_defaultClientScript">
        <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <LINK href="../../../styles01.css" type="text/css" rel="stylesheet">
        <style>
		    TD.grdSJSZLocked { ; LEFT: expression(divSJSZ.scrollLeft); POSITION: relative }
		    TH.grdSJSZLocked { ; LEFT: expression(divSJSZ.scrollLeft); POSITION: relative }
		    TH.grdSJSZLocked { Z-INDEX: 99 }
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
				
				if (document.all("divSJSZ") == null)
					return;
				
				intWidth   = document.body.clientWidth;   //�ܿ��
				intWidth  -= 24;                          //������
				intWidth  -= 2 * 4;                       //���ҿհ�
				intWidth  -= 16;                          //������
				strWidth   = intWidth.toString() + "px";
				
				intHeight  = document.body.clientHeight;  //�ܸ߶�
				intHeight -= 24;                          //������
				intHeight -= trRow01.clientHeight;
				intHeight -= trRow02.clientHeight;
				intHeight -= trRow03.clientHeight;
				intHeight -= trRow04.clientHeight;
				intHeight -= trRow05.clientHeight;
				intHeight -= trRow06.clientHeight;
				intHeight -= trRow07.clientHeight;
				strHeight  = intHeight.toString() + "px";
				//if (document.readyState.toLowerCase() == "complete")
                //    alert(strWidth + " " + strHeight);

				divSJSZ.style.width  = strWidth;
				divSJSZ.style.height = strHeight;
				divSJSZ.style.clip   = "rect(0px " + strWidth + " " + strHeight + " 0px)";
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
        <form id="frmestate_cw_sssf" method="post" runat="server">
            <asp:panel id="panelMain" Runat="server">
                <TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
                    <TR>
                        <TD width="5"></TD>
                        <TD vAlign="top" align="center">
                            <TABLE cellSpacing="0" cellPadding="0" border="0">
                                <TR id="trRow01">
                                    <TD class="title" align="center" colSpan="3" height="30">�տ�򸶿��<asp:LinkButton id="lnkBlank" Runat="server" Width="0px"></asp:LinkButton></TD>
                                </TR>
                                <TR>
                                    <TD width="5"></TD>
                                    <TD vAlign="top">
                                        <DIV id="divMain">
                                            <TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
                                                <tr id="trRow02">
                                                    <td>
                                                        <% if propQRSH() <> "" then response.write("<div style='display:none'>") %>
                                                        <TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
                                                            <TR>
                                                                <TD class="label" align="left" bgColor="#ccff99" colspan="3"><B>&gt;&gt;&gt;&gt;ָ��ҵ����</B></TD>
                                                            </TR>
                                                            <TR>
                                                                <TD class="labelNotNull" align="right" nowrap>ҵ���ţ�</TD>
                                                                <td align="left" width="90%"><asp:TextBox id="txtJYBH" Runat="server" CssClass="textbox" Width="100%" ReadOnly="True"></asp:TextBox></td>
                                                                <td align="left"><asp:Button id="btnSelect_JYBH" Runat="server" CssClass="button" Text="��"></asp:Button></td>
                                                            </TR>
                                                        </table>
                                                        <% if propQRSH() <> "" then response.write("</div>") %>
                                                    </td>
                                                </tr>
                                                <tr id="trRow03">
                                                    <td>
                                                        <TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
                                                            <TR>
                                                                <TD class="label" align="left" bgColor="#ccff99"><B>&gt;&gt;&gt;&gt;������Ϣ</B></TD>
                                                            </TR>
                                                            <TR>
                                                                <TD>
                                                                    <TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
                                                                        <TR>
                                                                            <TD class="label" noWrap align="right">&nbsp;&nbsp;���ױ�ţ�&nbsp;&nbsp;</TD>
                                                                            <TD noWrap align="left" width="15%" style="BORDER-BOTTOM: #99cccc 1px solid">&nbsp;<asp:Label id="lblJYBH" Runat="server" CssClass="label"></asp:Label>&nbsp;</TD>
                                                                            <TD class="label" noWrap align="right">&nbsp;&nbsp;�������ڣ�&nbsp;&nbsp;</TD>
                                                                            <TD noWrap align="left" width="15%" style="BORDER-BOTTOM: #99cccc 1px solid">&nbsp;<asp:Label id="lblJYRQ" Runat="server" CssClass="label"></asp:Label>&nbsp;</TD>
                                                                            <TD class="label" noWrap align="right">&nbsp;&nbsp;�׷����ƣ�&nbsp;&nbsp;</TD>
                                                                            <TD noWrap align="left" width="18%" style="BORDER-BOTTOM: #99cccc 1px solid">&nbsp;<asp:Label id="lblJFMC" Runat="server" CssClass="label"></asp:Label>&nbsp;</TD>
                                                                            <TD class="label" noWrap align="right">&nbsp;&nbsp;���׼۸�(Ԫ)��&nbsp;&nbsp;</TD>
                                                                            <TD noWrap align="right" width="15%" style="BORDER-BOTTOM: #99cccc 1px solid">&nbsp;<asp:Label id="lblJYJG" Runat="server" CssClass="label"></asp:Label>&nbsp;</TD>
                                                                            <TD class="label" noWrap align="right">&nbsp;&nbsp;�׷������(Ԫ)��&nbsp;&nbsp;</TD>
                                                                            <TD noWrap align="right" width="15%" style="BORDER-BOTTOM: #99cccc 1px solid">&nbsp;<asp:Label id="lblJFDLF" Runat="server" CssClass="label"></asp:Label>&nbsp;</TD>
                                                                        </TR>
                                                                        <TR>
                                                                            <TD class="label" noWrap align="right">&nbsp;&nbsp;��ͬ��ţ�&nbsp;&nbsp;</TD>
                                                                            <TD noWrap align="left" style="BORDER-BOTTOM: #99cccc 1px solid">&nbsp;<asp:Label id="lblHTBH" Runat="server" CssClass="label"></asp:Label>&nbsp;</TD>
                                                                            <TD class="label" noWrap align="right">&nbsp;&nbsp;��ͬ���ڣ�&nbsp;&nbsp;</TD>
                                                                            <TD noWrap align="left" style="BORDER-BOTTOM: #99cccc 1px solid">&nbsp;<asp:Label id="lblHTRQ" Runat="server" CssClass="label"></asp:Label>&nbsp;</TD>
                                                                            <TD class="label" noWrap align="right">&nbsp;&nbsp;�ҷ����ƣ�&nbsp;&nbsp;</TD>
                                                                            <TD noWrap align="left" style="BORDER-BOTTOM: #99cccc 1px solid">&nbsp;<asp:Label id="lblYFMC" Runat="server" CssClass="label"></asp:Label>&nbsp;</TD>
                                                                            <TD class="label" noWrap align="right">&nbsp;&nbsp;�������(�O)��&nbsp;&nbsp;</TD>
                                                                            <TD noWrap align="right" style="BORDER-BOTTOM: #99cccc 1px solid">&nbsp;<asp:Label id="lblJYMJ" Runat="server" CssClass="label"></asp:Label>&nbsp;</TD>
                                                                            <TD class="label" noWrap align="right">&nbsp;&nbsp;�ҷ������(Ԫ)��&nbsp;&nbsp;</TD>
                                                                            <TD noWrap align="right" style="BORDER-BOTTOM: #99cccc 1px solid">&nbsp;<asp:Label id="lblYFDLF" Runat="server" CssClass="label"></asp:Label>&nbsp;</TD>
                                                                        </TR>
                                                                        <TR>
                                                                            <TD class="label" noWrap align="right">&nbsp;&nbsp;��ҵ��ַ��&nbsp;&nbsp;</TD>
                                                                            <TD noWrap align="left" colSpan="9" style="BORDER-BOTTOM: #99cccc 1px solid">&nbsp;<asp:Label id="lblWYDZ" Runat="server" CssClass="label"></asp:Label>&nbsp;</TD>
                                                                        </TR>
                                                                    </TABLE>
                                                                </TD>
                                                            </TR>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr id="trRow04">
                                                    <td>
                                                        <TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
                                                            <TR>
                                                                <TD class="label" align="left" bgColor="#ccff99">
                                                                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                                        <tr height="24" valign="middle">
                                                                            <td class="label" align="left"><B>&gt;&gt;&gt;&gt;ʵ���ո�����Ϣ</B></td>
                                                                            <td class="label" align="right">�׷����ý�<asp:TextBox ID="txtBYJ_JF" Runat="server" CssClass="textbox" Columns="14" ReadOnly="True"></asp:TextBox>&nbsp;&nbsp;�ҷ����ý�<asp:TextBox ID="txtBYJ_YF" Runat="server" CssClass="textbox" Columns="14" ReadOnly="True"></asp:TextBox>&nbsp;&nbsp;��ͬ���ý�<asp:TextBox ID="txtBYJ_HT" Runat="server" CssClass="textbox" Columns="14" ReadOnly="True"></asp:TextBox></td>
                                                                        </tr>
                                                                    </table>
                                                                </TD>
                                                            </TR>
                                                            <TR>
                                                                <TD>
                                                                    <TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
                                                                        <TR>
                                                                            <TD class="label" vAlign="middle" align="right">&nbsp;���&nbsp;</TD>
                                                                            <TD class="label" align="left"><asp:DropDownList ID="ddlSJSZSearch_SHBZ" Runat="server" CssClass="textbox"><asp:ListItem Value=""></asp:ListItem><asp:ListItem Value="0">��</asp:ListItem><asp:ListItem Value="1">��</asp:ListItem></asp:DropDownList></td>
                                                                            <TD class="label" vAlign="middle" align="right">&nbsp;��Ч&nbsp;</TD>
                                                                            <TD class="label" align="left"><asp:DropDownList ID="ddlSJSZSearch_SFSH" Runat="server" CssClass="textbox"><asp:ListItem Value=""></asp:ListItem><asp:ListItem Value="��">��</asp:ListItem><asp:ListItem Value="��">��</asp:ListItem></asp:DropDownList></td>
                                                                            <TD class="label" vAlign="middle" align="right">&nbsp;˰��&nbsp;</TD>
                                                                            <TD class="label" align="left"><asp:DropDownList id="ddlSJSZSearch_SFDM" runat="server" CssClass="textbox"></asp:DropDownList></TD>
                                                                            <TD class="label" vAlign="middle" align="right">&nbsp;����&nbsp;</TD>
                                                                            <TD class="label" align="left">
                                                                                <asp:DropDownList id="ddlSJSZSearch_SFDX" runat="server" CssClass="textbox">
                                                                                    <asp:ListItem Value=""></asp:ListItem>
                                                                                    <asp:ListItem Value="��">�׷�</asp:ListItem>
                                                                                    <asp:ListItem Value="��">�ҷ�</asp:ListItem>
                                                                                </asp:DropDownList>
                                                                            </TD>
                                                                            <TD class="label" vAlign="middle" align="right">&nbsp;�ո�&nbsp;</TD>
                                                                            <TD class="label" align="left">
                                                                                <asp:DropDownList id="ddlSJSZSearch_SFBZ" runat="server" CssClass="textbox">
                                                                                    <asp:ListItem Value=""></asp:ListItem>
                                                                                    <asp:ListItem Value="��">��</asp:ListItem>
                                                                                    <asp:ListItem Value="��">��</asp:ListItem>
                                                                                </asp:DropDownList>
                                                                            </TD>
                                                                            <TD class="label" vAlign="middle" align="right">&nbsp;����&nbsp;</TD>
                                                                            <TD class="label" align="left"><asp:TextBox id="txtSJSZSearch_FSRQMin" Runat="server" Columns="8" CssClass="textbox"></asp:TextBox>~<asp:TextBox id="txtSJSZSearch_FSRQMax" Runat="server" Columns="8" CssClass="textbox"></asp:TextBox></TD>
                                                                            <TD class="label" vAlign="middle" align="right">&nbsp;Ʊ�ݺ�&nbsp;</TD>
                                                                            <TD class="label" align="left"><asp:TextBox id="txtSJSZSearch_PJHM" Runat="server" Columns="6" CssClass="textbox"></asp:TextBox></TD>
                                                                            <TD class="label">&nbsp;<asp:button id="btnSJSZSearch" Runat="server" CssClass="button" Text="��������"></asp:button><asp:button id="btnSJSZSearch_Full" Runat="server" CssClass="button" Text="ȫ������"></asp:button></TD>
                                                                        </TR>
                                                                    </TABLE>
                                                                </TD>
                                                            </TR>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <TR>
                                                    <TD align="center">
                                                        <DIV id="divSJSZ" style="BORDER-RIGHT: #99cccc 1px solid; TABLE-LAYOUT: fixed; BORDER-TOP: #99cccc 1px solid; OVERFLOW: auto; BORDER-LEFT: #99cccc 1px solid; WIDTH: 964px; CLIP: rect(0px 964px 290px 0px); BORDER-BOTTOM: #99cccc 1px solid; HEIGHT: 290px">
                                                            <asp:datagrid id="grdSJSZ" runat="server" CssClass="label" Font-Names="����" CellPadding="4"
                                                                AllowSorting="True" BorderWidth="0px" BorderColor="#DEDFDE" PageSize="30" BorderStyle="None"
                                                                GridLines="Vertical" AutoGenerateColumns="False" AllowPaging="True" UseAccessibleHeader="True">
                                                                <SelectedItemStyle Font-Size="12px" Font-Names="����" Font-Bold="False" VerticalAlign="Middle" ForeColor="#CC0000" BackColor="#FFFFDD"></SelectedItemStyle>
                                                                <EditItemStyle Font-Size="12px" Font-Names="����" VerticalAlign="Middle" BackColor="#FFCC00"></EditItemStyle>
                                                                <AlternatingItemStyle Font-Size="12px" Font-Names="����" BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="White"></AlternatingItemStyle>
                                                                <ItemStyle Font-Size="12px" Font-Names="����" BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="#F7F7F7" ForeColor="Black"></ItemStyle>
                                                                <HeaderStyle Font-Size="12px" Font-Names="����" Font-Bold="True" ForeColor="White" VerticalAlign="Middle" BackColor="#6699cc" HorizontalAlign="Left"></HeaderStyle>
                                                                <FooterStyle BackColor="#CCCC99"></FooterStyle>
                                                                
                                                                <Columns>
                                                                    <asp:TemplateColumn HeaderText="ѡ" Visible="False" ItemStyle-Width="20px">
                                                                        <HeaderStyle HorizontalAlign="Center" Width="20px"></HeaderStyle>
                                                                        <ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox id="chkSJSZ" runat="server" AutoPostBack="False" Visible="False"></asp:CheckBox>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="Ψһ��ʶ" SortExpression="Ψһ��ʶ" HeaderText="Ψһ��ʶ" CommandName="Select">
                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="ȷ�����" SortExpression="ȷ�����" HeaderText="ȷ�����" CommandName="Select">
                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="˰�Ѵ���" SortExpression="˰�Ѵ���" HeaderText="˰�Ѵ���" CommandName="Select">
                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="�ո���־" SortExpression="�ո���־" HeaderText="�ո�" CommandName="Select">
                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn Visible="False" DataTextField="�������" SortExpression="�������" HeaderText="���(Ԫ)" CommandName="Select" DataTextFormatString="{0:#,###.00}" ItemStyle-HorizontalAlign="Right">
                                                                        <HeaderStyle Width="0px" HorizontalAlign="Right"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn  ItemStyle-Width="50px" DataTextField="�Ƿ����" SortExpression="�Ƿ����" HeaderText="��Ч" CommandName="Select">
                                                                        <HeaderStyle Width="50px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn  ItemStyle-Width="50px" DataTextField="��˱�־����" SortExpression="��˱�־����" HeaderText="���" CommandName="Select">
                                                                        <HeaderStyle Width="50px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn  ItemStyle-Width="140px" DataTextField="˰������" SortExpression="˰������" HeaderText="˰��" CommandName="Select">
                                                                        <HeaderStyle Width="140px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn  ItemStyle-Width="160px" DataTextField="���������" SortExpression="���������" HeaderText="��(Ԫ)" CommandName="Select" DataTextFormatString="{0:#,###.00}" ItemStyle-HorizontalAlign="Right">
                                                                        <HeaderStyle Width="160px" HorizontalAlign="Right"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn  ItemStyle-Width="160px" DataTextField="������" SortExpression="������" HeaderText="��(Ԫ)" CommandName="Select" DataTextFormatString="{0:#,###.00}" ItemStyle-HorizontalAlign="Right">
                                                                        <HeaderStyle Width="160px" HorizontalAlign="Right"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn  ItemStyle-Width="300px" DataTextField="ժҪ˵��" SortExpression="ժҪ˵��" HeaderText="ժҪ" CommandName="Select">
                                                                        <HeaderStyle Width="300px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn  ItemStyle-Width="140px" DataTextField="��������" SortExpression="��������" HeaderText="����" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd}">
                                                                        <HeaderStyle Width="140px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn  ItemStyle-Width="60px" DataTextField="�ո�����" SortExpression="�ո�����" HeaderText="����" CommandName="Select">
                                                                        <HeaderStyle Width="60px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn  ItemStyle-Width="120px" DataTextField="�ͻ�����" SortExpression="�ͻ�����" HeaderText="�ͻ�" CommandName="Select">
                                                                        <HeaderStyle Width="120px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn  ItemStyle-Width="180px" DataTextField="Ʊ�ݺ���" SortExpression="Ʊ�ݺ���" HeaderText="Ʊ�ݺ�" CommandName="Select">
                                                                        <HeaderStyle Width="180px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn  ItemStyle-Width="120px" DataTextField="������Ա����" SortExpression="������Ա����" HeaderText="������" CommandName="Select">
                                                                        <HeaderStyle Width="120px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn  ItemStyle-Width="220px" DataTextField="�����������" SortExpression="�����������" HeaderText="���쵥λ" CommandName="Select">
                                                                        <HeaderStyle Width="220px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn Visible="False" DataTextField="������Ա" SortExpression="������Ա" HeaderText="������Ա" CommandName="Select">
                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn Visible="False" DataTextField="�������" SortExpression="�������" HeaderText="�������" CommandName="Select">
                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn Visible="False" DataTextField="�������" SortExpression="�������" HeaderText="�������" CommandName="Select">
                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="�����������" SortExpression="�����������" HeaderText="�������" CommandName="Select">
                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="�������" SortExpression="�������" HeaderText="�������" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd}">
                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="��˱�־" SortExpression="��˱�־" HeaderText="��˱�־" CommandName="Select">
                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="�ƻ���ʶ" SortExpression="�ƻ���ʶ" HeaderText="�ƻ���ʶ" CommandName="Select">
                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                </Columns>
                                                                <PagerStyle Visible="False" NextPageText="��ҳ" Font-Size="12px" Font-Names="����" PrevPageText="��ҳ" HorizontalAlign="Right" ForeColor="Black" Position="TopAndBottom" BackColor="SkyBlue"></PagerStyle>
                                                            </asp:datagrid><INPUT id="htxtSJSZFixed" type="hidden" value="0" runat="server">
                                                        </DIV>
                                                    </TD>
                                                </TR>
                                                <TR id="trRow05">
                                                    <TD>
                                                        <TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
                                                            <TR>
                                                                <TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZSJSZDeSelectAll" runat="server">��ѡ</asp:linkbutton></TD>
                                                                <TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZSJSZSelectAll" runat="server">ȫѡ</asp:linkbutton></TD>
                                                                <TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZSJSZMoveFirst" runat="server">��ǰ</asp:linkbutton></TD>
                                                                <TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZSJSZMovePrev" runat="server">ǰҳ</asp:linkbutton></TD>
                                                                <TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZSJSZMoveNext" runat="server">��ҳ</asp:linkbutton></TD>
                                                                <TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZSJSZMoveLast" runat="server">���</asp:linkbutton></TD>
                                                                <TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZSJSZGotoPage" runat="server">ǰ��</asp:linkbutton><asp:textbox id="txtSJSZPageIndex" runat="server" Columns="3" CssClass="textbox">1</asp:textbox>ҳ</TD>
                                                                <TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZSJSZSetPageSize" runat="server">ÿҳ</asp:linkbutton><asp:textbox id="txtSJSZPageSize" runat="server" Columns="3" CssClass="textbox">30</asp:textbox>��</TD>
                                                                <TD class="label" vAlign="middle" noWrap align="right"><asp:label id="lblSJSZGridLocInfo" runat="server" CssClass="label">1/10 N/15</asp:label></TD>
                                                            </TR>
                                                        </TABLE>
                                                    </TD>
                                                </TR>
                                                <TR id="trRow06">
                                                    <td>
                                                        <% if propEditMode = false then response.write("<div style='display:none'>") %>
                                                        <TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
                                                            <tr>
                                                                <TD class="label" align="left" bgColor="#ccff99"><B>&gt;&gt;&gt;&gt;�����ո������ݱ༭��(ѡ��[Ʊ�ݺ�]��ϵͳ���Զ���䱾ƾ֤)</B><INPUT id="htxtJHBS" type="hidden" size="1" runat="server"><INPUT id="htxtWYBS" type="hidden" size="1" runat="server"><INPUT id="htxtQRSH" type="hidden" size="1" runat="server"><INPUT id="htxtCWSH" type="hidden" size="1" runat="server"><INPUT id="htxtSHRQ" type="hidden" size="1" runat="server"></TD>
                                                            </tr>
                                                            <TR>
                                                                <TD align="center">
                                                                    <TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
                                                                        <TR>
                                                                            <TD class="labelNotNull" noWrap align="right">&nbsp;&nbsp;����</TD>
                                                                            <TD class="label" style="BORDER-BOTTOM: #99cccc 1px solid" align="left" width="15%">
                                                                                <asp:RadioButtonList id="rblSFDX" Runat="server" CssClass="textbox" AutoPostBack="True" RepeatColumns="2" RepeatDirection="Vertical" RepeatLayout="Flow">
                                                                                    <asp:ListItem Value="��">�׷�</asp:ListItem>
                                                                                    <asp:ListItem Value="��">�ҷ�</asp:ListItem>
                                                                                </asp:RadioButtonList>
                                                                            </TD>
                                                                            <TD class="labelNotNull" align="right">&nbsp;&nbsp;����</TD>
                                                                            <TD class="label" style="BORDER-BOTTOM: #99cccc 1px solid" align="left" width="15%"><asp:TextBox id="txtFSRQ" Runat="server" Width="100%" CssClass="textbox"></asp:TextBox></TD>
                                                                            <!-- zengxianglin 2008-11-18-->
                                                                            <TD class="labelNotNull" noWrap align="right">&nbsp;&nbsp;Ʊ�ݺ�</TD>
                                                                            <TD class="label" style="BORDER-BOTTOM: #99cccc 1px solid" align="left" width="15%"><asp:TextBox id="txtPJHM" Runat="server" Width="100%" CssClass="textbox"></asp:TextBox></TD>
                                                                            <td align="left"><asp:Button id="btnSelect_PJHM" Runat="server" CssClass="button" Text="��"></asp:Button><INPUT id="Hidden1" type="hidden" size="1" runat="server" NAME="htxtJBRY"></td>
                                                                            <!-- zengxianglin 2008-11-18-->
                                                                            <TD class="labelNotNull" noWrap align="right">&nbsp;&nbsp;˰��</TD>
                                                                            <TD class="label" style="BORDER-BOTTOM: #99cccc 1px solid" align="left" width="30%" colspan="2"><asp:DropDownList id="ddlSFDM" Runat="server" Width="100%" CssClass="textbox"></asp:DropDownList></TD>
                                                                            <TD align="center"><asp:button id="btnSave" Runat="server" CssClass="button" Text=" ��    �� "></asp:button></TD>
                                                                        </TR>
                                                                        <TR>
                                                                            <TD class="labelNotNull" noWrap align="right">&nbsp;&nbsp;�ո�</TD>
                                                                            <TD class="label" style="BORDER-BOTTOM: #99cccc 1px solid" align="left" width="15%">
                                                                                <asp:RadioButtonList id="rblSFBZ" Runat="server" CssClass="textbox" RepeatColumns="2" RepeatDirection="Vertical" RepeatLayout="Flow">
                                                                                    <asp:ListItem Value="��">��</asp:ListItem>
                                                                                    <asp:ListItem Value="��">��</asp:ListItem>
                                                                                </asp:RadioButtonList>
                                                                            </TD>
                                                                            <TD class="label" noWrap align="right">&nbsp;&nbsp;���(Ԫ)</TD>
                                                                            <TD class="label" style="BORDER-BOTTOM: #99cccc 1px solid" align="left" width="15%"><asp:textbox id="txtFSJE" Runat="server" Width="100%" CssClass="textbox"></asp:textbox></TD>
                                                                            <TD class="labelNotNull" noWrap align="right">&nbsp;&nbsp;������</TD>
                                                                            <TD class="label" style="BORDER-BOTTOM: #99cccc 1px solid" align="left" width="15%"><asp:TextBox id="txtJBRY" Runat="server" Width="100%" CssClass="textbox"></asp:TextBox></TD>
                                                                            <td align="left"><asp:Button id="btnSelect_JBRY" Runat="server" CssClass="button" Text="��"></asp:Button><INPUT id="htxtJBRY" type="hidden" size="1" runat="server" NAME="htxtJBRY"></td>
                                                                            <TD class="labelNotNull" noWrap align="right">&nbsp;&nbsp;���쵥λ</TD>
                                                                            <TD class="label" style="BORDER-BOTTOM: #99cccc 1px solid" align="left" width="30%"><asp:TextBox id="txtJBDW" Runat="server" Width="100%" CssClass="textbox"></asp:TextBox></TD>
                                                                            <td align="left"><asp:Button id="btnSelect_JBDW" Runat="server" CssClass="button" Text="��"></asp:Button><INPUT id="htxtJBDW" type="hidden" size="1" runat="server" NAME="htxtJBDW"></td>
                                                                            <TD align="center"></TD>
                                                                        </TR>
                                                                        <TR>
                                                                            <TD class="label" align="right">&nbsp;&nbsp;�ͻ�</TD>
                                                                            <TD class="label" style="BORDER-BOTTOM: #99cccc 1px solid" align="left"><asp:textbox id="txtKHMC" Runat="server" Width="100%" CssClass="textbox"></asp:textbox></TD>
                                                                            <TD class="label" align="right">&nbsp;&nbsp;ժҪ</TD>
                                                                            <TD class="label" style="BORDER-BOTTOM: #99cccc 1px solid" align="left" colspan="7"><asp:textbox id="txtZYSM" Runat="server" Width="100%" CssClass="textbox"></asp:textbox></TD>
                                                                            <TD align="center"><asp:button id="btnCancel" Runat="server" CssClass="button" Text=" ȡ    �� "></asp:button></TD>
                                                                        </TR>
                                                                    </TABLE>
                                                                </TD>
                                                            </TR>
                                                        </table>
                                                        <% if propEditMode = false then response.write("</div>") %>
                                                    </td>
                                                </TR>
                                            </TABLE>
                                        </DIV>
                                    </TD>
                                    <TD width="5"></TD>
                                </TR>
                                <TR>
                                    <TD colSpan="5" height="3"></TD>
                                </TR>
                            </TABLE>
                        </TD>
                        <TD width="5"></TD>
                    </TR>
                    <TR>
                        <TD colSpan="3" height="3"></TD>
                    </TR>
                    <TR id="trRow07">
                        <TD align="center" colSpan="3">
                            <asp:Button id="btnAddNew"   Runat="server" CssClass="button" Text=" ֱ�ӵ��µĿ��� " Height="36px"></asp:Button>
                            <asp:Button id="btnAddJH"    Runat="server" CssClass="button" Text=" ���ƻ��ո��� "   Height="36px"></asp:Button>
                            <asp:Button id="btnJiezhuan" Runat="server" CssClass="button" Text=" ���ý�ת "       Height="36px"></asp:Button>
                            <asp:Button id="btnDelete"   Runat="server" CssClass="button" Text=" ɾ��δ����� "   Height="36px"></asp:Button>
                            <asp:Button id="btnPrint"    Runat="server" CssClass="button" Text=" ��    ӡ "       Height="36px"></asp:Button>
                            <asp:Button id="btnClose"    Runat="server" CssClass="button" Text=" ��    �� "       Height="36px"></asp:Button>
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
                                    <TD id="tdErrInfo" style="FONT-SIZE: 32pt; COLOR: black; LINE-HEIGHT: 40pt; FONT-FAMILY: ����; LETTER-SPACING: 2pt" align="center"><asp:Label id="lblMessage" Runat="server"></asp:Label><P>&nbsp;&nbsp;</P><P><asp:Button ID="btnGoBack" Runat="server" Font-Size="24pt" Text=" ���� "></asp:Button></P></TD>
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
                        <input id="htxtCurrentPage" type="hidden" runat="server">
                        <input id="htxtCurrentRow" type="hidden" runat="server">
                        <input id="htxtEditMode" type="hidden" runat="server">
                        <input id="htxtEditType" type="hidden" runat="server">
                        <input id="htxtSJSZSessionIdQuery" type="hidden" runat="server">
                        <input id="htxtSJSZQuery" type="hidden" runat="server">
                        <input id="htxtSJSZRows" type="hidden" runat="server">
                        <input id="htxtSJSZSort" type="hidden" runat="server">
                        <input id="htxtSJSZSortColumnIndex" type="hidden" runat="server">
                        <input id="htxtSJSZSortType" type="hidden" runat="server">
                        <input id="htxtDivLeftSJSZ" type="hidden" runat="server">
                        <input id="htxtDivTopSJSZ" type="hidden" runat="server">
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
							function ScrollProc_divSJSZ() {
								var oText;
								oText=null;
								oText=document.getElementById("htxtDivTopSJSZ");
								if (oText != null) oText.value = divSJSZ.scrollTop;
								oText=null;
								oText=document.getElementById("htxtDivLeftSJSZ");
								if (oText != null) oText.value = divSJSZ.scrollLeft;
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
								oText=document.getElementById("htxtDivTopSJSZ");
								if (oText != null) divSJSZ.scrollTop = oText.value;
								oText=null;
								oText=document.getElementById("htxtDivLeftSJSZ");
								if (oText != null) divSJSZ.scrollLeft = oText.value;

								document.body.onscroll = ScrollProc_Body;
								divMain.onscroll = ScrollProc_divMain;
								divSJSZ.onscroll = ScrollProc_divSJSZ;
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
