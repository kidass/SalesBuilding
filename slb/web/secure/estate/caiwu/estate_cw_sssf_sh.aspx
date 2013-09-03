<%@ Page Language="vb" AutoEventWireup="false" Codebehind="estate_cw_sssf_sh.aspx.vb" Inherits="Josco.JSOA.web.estate_cw_sssf_sh" %>
<%@ Register TagPrefix="uwin" Namespace="Josco.Web" Assembly="Josco.Web.PopMessage" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
    <HEAD>
        <title>������˴���</title>
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
        <form id="frmestate_cw_sssf_sh" method="post" runat="server">
            <asp:panel id="panelMain" Runat="server">
                <TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
                    <TR>
                        <TD width="5"></TD>
                        <TD vAlign="top" align="center">
                            <TABLE cellSpacing="0" cellPadding="0" border="0">
                                <TR id="trRow01">
                                    <TD class="title" align="center" colSpan="3" height="30">������˴���<asp:LinkButton id="lnkBlank" Runat="server" Width="0px"></asp:LinkButton></TD>
                                </TR>
                                <TR>
                                    <TD width="5"></TD>
                                    <TD vAlign="top">
                                        <DIV id="divMain">
                                            <TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
                                                <tr id="trRow02">
                                                    <td>
                                                        <TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
                                                            <TR>
                                                                <TD>
                                                                    <TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
                                                                        <TR>
                                                                            <TD class="label" vAlign="middle" align="right">&nbsp;����&nbsp;</TD>
                                                                            <TD class="label" align="left"><asp:TextBox id="txtSJSZSearch_JBDW" Runat="server" Columns="8" CssClass="textbox"></asp:TextBox></TD>
                                                                            <TD class="label" vAlign="middle" align="right">&nbsp;����&nbsp;</TD>
                                                                            <TD class="label" align="left"><asp:TextBox id="txtSJSZSearch_FSRQMin" Runat="server" Columns="8" CssClass="textbox"></asp:TextBox>~<asp:TextBox id="txtSJSZSearch_FSRQMax" Runat="server" Columns="8" CssClass="textbox"></asp:TextBox></TD>
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
                                                                            <TD class="label" vAlign="middle" align="right">&nbsp;Ʊ�ݺ�&nbsp;</TD>
                                                                            <TD class="label" align="left"><asp:TextBox id="txtSJSZSearch_PJHM" Runat="server" Columns="8" CssClass="textbox"></asp:TextBox></TD>
                                                                            <TD class="label">&nbsp;<asp:button id="btnSJSZSearch" Runat="server" CssClass="button" Text="����"></asp:button><asp:button id="btnSJSZSearch_Full" Runat="server" CssClass="button" Text="ȫ��"></asp:button></TD>
                                                                        </TR>
                                                                    </TABLE>
                                                                </TD>
                                                            </TR>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <TR>
                                                    <TD align="center">
                                                        <DIV id="divSJSZ" style="BORDER-RIGHT: #99cccc 1px solid; TABLE-LAYOUT: fixed; BORDER-TOP: #99cccc 1px solid; OVERFLOW: auto; BORDER-LEFT: #99cccc 1px solid; WIDTH: 964px; CLIP: rect(0px 964px 370px 0px); BORDER-BOTTOM: #99cccc 1px solid; HEIGHT: 370px">
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
                                                                    <asp:TemplateColumn HeaderText="ѡ" ItemStyle-Width="20px">
                                                                        <HeaderStyle HorizontalAlign="Center" Width="20px"></HeaderStyle>
                                                                        <ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox id="chkSJSZ" runat="server" AutoPostBack="False"></asp:CheckBox>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="Ψһ��ʶ" SortExpression="Ψһ��ʶ" HeaderText="Ψһ��ʶ" CommandName="Select">
                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="˰�Ѵ���" SortExpression="˰�Ѵ���" HeaderText="˰�Ѵ���" CommandName="Select">
                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="�ո���־" SortExpression="�ո���־" HeaderText="�ո�" CommandName="Select">
                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="�������" SortExpression="�������" HeaderText="���(Ԫ)" CommandName="Select" DataTextFormatString="{0:#,###.00}" ItemStyle-HorizontalAlign="Right">
                                                                        <HeaderStyle Width="0px" HorizontalAlign="Right"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="40px" DataTextField="��˱�־����" SortExpression="��˱�־����" HeaderText="���" CommandName="Select">
                                                                        <HeaderStyle Width="40px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="40px" DataTextField="�Ƿ����" SortExpression="�Ƿ����" HeaderText="��Ч" CommandName="Select">
                                                                        <HeaderStyle Width="40px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="120px" DataTextField="ȷ�����" SortExpression="ȷ�����" HeaderText="ȷ�����" CommandName="Select">
                                                                        <HeaderStyle Width="120px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="100px" DataTextField="˰������" SortExpression="˰������" HeaderText="˰��" CommandName="Select">
                                                                        <HeaderStyle Width="100px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="140px" DataTextField="���������" SortExpression="���������" HeaderText="��(Ԫ)" CommandName="Select" DataTextFormatString="{0:#,###.00}" ItemStyle-HorizontalAlign="Right">
                                                                        <HeaderStyle Width="140px" HorizontalAlign="Right"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="140px" DataTextField="������" SortExpression="������" HeaderText="��(Ԫ)" CommandName="Select" DataTextFormatString="{0:#,###.00}" ItemStyle-HorizontalAlign="Right">
                                                                        <HeaderStyle Width="140px" HorizontalAlign="Right"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="300px" DataTextField="ժҪ˵��" SortExpression="ժҪ˵��" HeaderText="ժҪ" CommandName="Select">
                                                                        <HeaderStyle Width="300px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="140px" DataTextField="��������" SortExpression="��������" HeaderText="����" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd}">
                                                                        <HeaderStyle Width="140px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="50px" DataTextField="�ո�����" SortExpression="�ո�����" HeaderText="����" CommandName="Select">
                                                                        <HeaderStyle Width="50px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="100px" DataTextField="�ͻ�����" SortExpression="�ͻ�����" HeaderText="�ͻ�" CommandName="Select">
                                                                        <HeaderStyle Width="100px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="120px" DataTextField="Ʊ�ݺ���" SortExpression="Ʊ�ݺ���" HeaderText="Ʊ�ݺ�" CommandName="Select">
                                                                        <HeaderStyle Width="120px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="120px" DataTextField="�����������" SortExpression="�����������" HeaderText="�������" CommandName="Select">
                                                                        <HeaderStyle Width="120px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="140px" DataTextField="�������" SortExpression="�������" HeaderText="�������" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd}">
                                                                        <HeaderStyle Width="140px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="120px" DataTextField="������Ա����" SortExpression="������Ա����" HeaderText="������" CommandName="Select">
                                                                        <HeaderStyle Width="120px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="220px" DataTextField="�����������" SortExpression="�����������" HeaderText="����" CommandName="Select">
                                                                        <HeaderStyle Width="220px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="������Ա" SortExpression="������Ա" HeaderText="������Ա" CommandName="Select">
                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="�������" SortExpression="�������" HeaderText="�������" CommandName="Select">
                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="�������" SortExpression="�������" HeaderText="�������" CommandName="Select">
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
                                                <TR id="trRow03">
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
                                                <TR id="trRow04">
                                                    <td>
                                                        <TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
                                                            <TR>
                                                                <TD class="label" align="left" bgColor="#ccff99">
                                                                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                                        <tr height="24" valign="middle">
                                                                            <td class="label" align="left"><B>&gt;&gt;&gt;&gt;���ʱ����Ķ���Ķ���������</B></td>
                                                                            <td class="label" align="right">�׷����ý�<asp:TextBox ID="txtBYJ_JF" Runat="server" CssClass="textbox" Columns="14" ReadOnly="True"></asp:TextBox>&nbsp;&nbsp;�ҷ����ý�<asp:TextBox ID="txtBYJ_YF" Runat="server" CssClass="textbox" Columns="14" ReadOnly="True"></asp:TextBox>&nbsp;&nbsp;��ͬ���ý�<asp:TextBox ID="txtBYJ_HT" Runat="server" CssClass="textbox" Columns="14" ReadOnly="True"></asp:TextBox></td>
                                                                        </tr>
                                                                    </table>
                                                                </TD>
                                                            </TR>
                                                            <TR>
                                                                <TD align="center">
                                                                    <TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
                                                                        <TR>
                                                                            <TD class="labelNotNull" noWrap align="right">&nbsp;&nbsp;����</TD>
                                                                            <TD class="label" style="BORDER-BOTTOM: #99cccc 1px solid" align="left" width="12%">
                                                                                <asp:RadioButtonList id="rblSFDX" Runat="server" CssClass="textbox" RepeatColumns="2" RepeatDirection="Vertical" RepeatLayout="Flow">
                                                                                    <asp:ListItem Value="��">�׷�</asp:ListItem>
                                                                                    <asp:ListItem Value="��">�ҷ�</asp:ListItem>
                                                                                </asp:RadioButtonList>
                                                                            </TD>
                                                                            <TD class="labelNotNull" noWrap align="right">&nbsp;&nbsp;�ո�</TD>
                                                                            <TD class="label" style="BORDER-BOTTOM: #99cccc 1px solid" align="left" width="12%">
                                                                                <asp:RadioButtonList id="rblSFBZ" Runat="server" CssClass="textbox" RepeatColumns="2" RepeatDirection="Vertical" RepeatLayout="Flow">
                                                                                    <asp:ListItem Value="��">��</asp:ListItem>
                                                                                    <asp:ListItem Value="��">��</asp:ListItem>
                                                                                </asp:RadioButtonList>
                                                                            </TD>
                                                                            <TD class="labelNotNull" noWrap align="right">&nbsp;&nbsp;˰��</TD>
                                                                            <TD class="label" style="BORDER-BOTTOM: #99cccc 1px solid" align="left" width="30%"><asp:DropDownList id="ddlSFDM" Runat="server" Width="100%" CssClass="textbox"></asp:DropDownList></TD>
                                                                            <TD class="labelNotNull" noWrap align="right">&nbsp;&nbsp;���(Ԫ)</TD>
                                                                            <TD class="label" style="BORDER-BOTTOM: #99cccc 1px solid" align="left" width="12%"><asp:textbox id="txtFSJE" Runat="server" Width="100%" CssClass="textbox"></asp:textbox></TD>
                                                                            <TD class="labelNotNull" noWrap align="right">&nbsp;&nbsp;Ʊ�ݺ�</TD>
                                                                            <TD class="label" style="BORDER-BOTTOM: #99cccc 1px solid" align="left" width="12%"><asp:textbox id="txtPJHM" Runat="server" Width="100%" CssClass="textbox"></asp:textbox></TD>
                                                                        </TR>
                                                                    </TABLE>
                                                                </TD>
                                                            </TR>
                                                        </table>
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
                    <TR id="trRow05">
                        <TD align="center" colSpan="3">
                            <asp:Button id="btnPLSDKX" Runat="server" CssClass="button" Text=" �����󶨿��� " Height="36px"></asp:Button>
                            <asp:Button id="btnOK"     Runat="server" CssClass="button" Text=" ������Ϣ�� " Height="36px"></asp:Button>
                            <asp:Button id="btnModify" Runat="server" CssClass="button" Text=" ������Ϣ�� " Height="36px"></asp:Button>
                            <asp:Button id="btnDelete" Runat="server" CssClass="button" Text=" ɾ����Ч���� " Height="36px"></asp:Button>
                            <asp:Button id="btnReject" Runat="server" CssClass="button" Text=" ���  ��ͨ�� " Height="36px"></asp:Button>
                            <asp:Button id="btnClose"  Runat="server" CssClass="button" Text=" ��        �� " Height="36px"></asp:Button>
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
