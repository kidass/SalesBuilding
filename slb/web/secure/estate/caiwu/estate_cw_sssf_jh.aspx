<%@ Page Language="vb" AutoEventWireup="false" Codebehind="estate_cw_sssf_jh.aspx.vb" Inherits="Josco.JSOA.web.estate_cw_sssf_jh" %>
<%@ Register TagPrefix="uwin" Namespace="Josco.Web" Assembly="Josco.Web.PopMessage" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
    <HEAD>
        <title>���ݼƻ������ո����</title>
        <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
        <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
        <meta content="JavaScript" name="vs_defaultClientScript">
        <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <LINK href="../../../styles01.css" type="text/css" rel="stylesheet">
        <style>
		    TD.grdJHSZLocked { ; LEFT: expression(divJHSZ.scrollLeft); POSITION: relative }
		    TH.grdJHSZLocked { ; LEFT: expression(divJHSZ.scrollLeft); POSITION: relative }
		    TH.grdJHSZLocked { Z-INDEX: 99 }
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
				
				if (document.all("divJHSZ") == null)
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
				intHeight -= trRow08.clientHeight;
				intHeight -= trRow09.clientHeight;
				strHeight  = intHeight.toString() + "px";
				//if (document.readyState.toLowerCase() == "complete")
                //    alert(strWidth + " " + strHeight);

				divJHSZ.style.width  = strWidth;
				divJHSZ.style.height = strHeight;
				divJHSZ.style.clip   = "rect(0px " + strWidth + " " + strHeight + " 0px)";
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
        <form id="frmestate_cw_sssf_jh" method="post" runat="server">
            <asp:panel id="panelMain" Runat="server">
                <TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
                    <TR>
                        <TD width="5"></TD>
                        <TD vAlign="top" align="center">
                            <TABLE cellSpacing="0" cellPadding="0" border="0">
                                <TR id="trRow01">
                                    <TD class="title" align="center" colSpan="3" height="30">���ݼƻ������ո����<asp:LinkButton id="lnkBlank" Runat="server" Width="0px"></asp:LinkButton></TD>
                                </TR>
                                <TR>
                                    <TD width="5"></TD>
                                    <TD vAlign="top">
                                        <DIV id="divMain">
                                            <TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
                                                <TR id="trRow02">
                                                    <TD class="label" align="left" bgColor="#ccff99"><B>&gt;&gt;&gt;&gt;������Ϣ</B></TD>
                                                </TR>
                                                <TR id="trRow03">
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
                                                <TR id="trRow04">
                                                    <TD class="label" align="left" bgColor="#ccff99">
                                                        <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                            <tr height="24" valign="middle">
                                                                <td class="label" align="left"><B>&gt;&gt;&gt;&gt;�ո���ƻ���Ϣ</B></td>
                                                                <td class="label" align="right">�׷����ý�<asp:TextBox ID="txtBYJ_JF" Runat="server" CssClass="textbox" Columns="14" ReadOnly="True"></asp:TextBox>&nbsp;&nbsp;�ҷ����ý�<asp:TextBox ID="txtBYJ_YF" Runat="server" CssClass="textbox" Columns="14" ReadOnly="True"></asp:TextBox>&nbsp;&nbsp;��ͬ���ý�<asp:TextBox ID="txtBYJ_HT" Runat="server" CssClass="textbox" Columns="14" ReadOnly="True"></asp:TextBox></td>
                                                            </tr>
                                                        </table>
                                                    </TD>
                                                </TR>
                                                <TR id="trRow05">
                                                    <TD>
                                                        <TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
                                                            <TR>
                                                                <TD class="label" vAlign="middle" align="right">&nbsp;&nbsp;˰��&nbsp;</TD>
                                                                <TD class="label" align="left"><asp:DropDownList id="ddlJHSZSearch_SFDM" runat="server" CssClass="textbox"></asp:DropDownList></TD>
                                                                <TD class="label" vAlign="middle" align="right">&nbsp;&nbsp;����&nbsp;</TD>
                                                                <TD class="label" align="left">
                                                                    <asp:DropDownList id="ddlJHSZSearch_SFDX" runat="server" CssClass="textbox">
                                                                        <asp:ListItem Value=""></asp:ListItem>
                                                                        <asp:ListItem Value="��">�׷�</asp:ListItem>
                                                                        <asp:ListItem Value="��">�ҷ�</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </TD>
                                                                <TD class="label" vAlign="middle" align="right">&nbsp;&nbsp;�ո�&nbsp;</TD>
                                                                <TD class="label" align="left">
                                                                    <asp:DropDownList id="ddlJHSZSearch_SFBZ" runat="server" CssClass="textbox">
                                                                        <asp:ListItem Value=""></asp:ListItem>
                                                                        <asp:ListItem Value="��">��</asp:ListItem>
                                                                        <asp:ListItem Value="��">��</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </TD>
                                                                <TD class="label" vAlign="middle" align="right">&nbsp;&nbsp;����&nbsp;</TD>
                                                                <TD class="label" align="left"><asp:TextBox id="txtJHSZSearch_YSRQMin" Runat="server" Columns="10" CssClass="textbox"></asp:TextBox>~<asp:TextBox id="txtJHSZSearch_YSRQMax" Runat="server" Columns="10" CssClass="textbox"></asp:TextBox></TD>
                                                                <TD class="label">&nbsp;&nbsp;<asp:button id="btnJHSZSearch" Runat="server" CssClass="button" Text=" �������� "></asp:button><asp:button id="btnJHSZSearch_Full" Runat="server" CssClass="button" Text=" ȫ������ "></asp:button></TD>
                                                            </TR>
                                                        </TABLE>
                                                    </TD>
                                                </TR>
                                                <TR>
                                                    <TD align="center">
                                                        <DIV id="divJHSZ" style="BORDER-RIGHT: #99cccc 1px solid; TABLE-LAYOUT: fixed; BORDER-TOP: #99cccc 1px solid; OVERFLOW: auto; BORDER-LEFT: #99cccc 1px solid; WIDTH: 964px; CLIP: rect(0px 964px 263px 0px); BORDER-BOTTOM: #99cccc 1px solid; HEIGHT: 263px">
                                                            <asp:datagrid id="grdJHSZ" runat="server" CssClass="label" Font-Names="����" CellPadding="4" AllowSorting="True"
                                                                BorderWidth="0px" BorderColor="#DEDFDE" PageSize="30" BorderStyle="None" GridLines="Vertical"
                                                                AutoGenerateColumns="False" AllowPaging="True" UseAccessibleHeader="True" Font-Size="12px">
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
                                                                            <asp:CheckBox id="chkJHSZ" runat="server" AutoPostBack="False" Visible="False"></asp:CheckBox>
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
                                                                    <asp:ButtonColumn  ItemStyle-Width="180px" DataTextField="˰������" SortExpression="˰������" HeaderText="˰��" CommandName="Select">
                                                                        <HeaderStyle Width="180px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn  ItemStyle-Width="60px" DataTextField="�ո�����" SortExpression="�ո�����" HeaderText="����" CommandName="Select">
                                                                        <HeaderStyle Width="60px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="�ո���־" SortExpression="�ո���־" HeaderText="�ո�" CommandName="Select">
                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn  ItemStyle-Width="140px" DataTextField="Ӧ������" SortExpression="Ӧ������" HeaderText="Ӧ������" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd}">
                                                                        <HeaderStyle Width="140px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="Ӧ�ս��" SortExpression="Ӧ�ս��" HeaderText="Ӧ�ս��(Ԫ)" CommandName="Select" DataTextFormatString="{0:#,###.00}" ItemStyle-HorizontalAlign="Right">
                                                                        <HeaderStyle Width="0px" HorizontalAlign="Right"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn  ItemStyle-Width="160px" DataTextField="Ӧ�ս����" SortExpression="Ӧ�ս����" HeaderText="��(Ԫ)" CommandName="Select" DataTextFormatString="{0:#,###.00}" ItemStyle-HorizontalAlign="Right">
                                                                        <HeaderStyle Width="160px" HorizontalAlign="Right"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn  ItemStyle-Width="160px" DataTextField="Ӧ�ս�" SortExpression="Ӧ�ս�" HeaderText="��(Ԫ)" CommandName="Select" DataTextFormatString="{0:#,###.00}" ItemStyle-HorizontalAlign="Right">
                                                                        <HeaderStyle Width="160px" HorizontalAlign="Right"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn  ItemStyle-Width="160px" DataTextField="ʵ�ս��" SortExpression="ʵ�ս��" HeaderText="����˶�(Ԫ)" CommandName="Select" DataTextFormatString="{0:#,###.00}" ItemStyle-HorizontalAlign="Right">
                                                                        <HeaderStyle Width="160px" HorizontalAlign="Right"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn Visible="False" DataTextField="�ո�״̬" SortExpression="�ո�״̬" HeaderText="�ո�״̬" CommandName="Select">
                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn  ItemStyle-Width="300px" DataTextField="��������" SortExpression="��������" HeaderText="ժҪ" CommandName="Select">
                                                                        <HeaderStyle Width="300px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="��ʼ����" SortExpression="��ʼ����" HeaderText="��ʼ����" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd}">
                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="��������" SortExpression="��������" HeaderText="��������" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd}">
                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="�����·�" SortExpression="�����·�" HeaderText="�����·�" CommandName="Select">
                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="��������" SortExpression="��������" HeaderText="��������" CommandName="Select">
                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                </Columns>
                                                                
                                                                <PagerStyle Visible="False" NextPageText="��ҳ" Font-Size="12px" Font-Names="����" PrevPageText="��ҳ" HorizontalAlign="Right" ForeColor="Black" Position="TopAndBottom" BackColor="SkyBlue"></PagerStyle>
                                                            </asp:datagrid><INPUT id="htxtJHSZFixed" type="hidden" value="0" runat="server">
                                                        </DIV>
                                                    </TD>
                                                </TR>
                                                <TR id="trRow06">
                                                    <TD>
                                                        <TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
                                                            <TR>
                                                                <TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZJHSZDeSelectAll" runat="server">��ѡ</asp:linkbutton></TD>
                                                                <TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZJHSZSelectAll" runat="server">ȫѡ</asp:linkbutton></TD>
                                                                <TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZJHSZMoveFirst" runat="server">��ǰ</asp:linkbutton></TD>
                                                                <TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZJHSZMovePrev" runat="server">ǰҳ</asp:linkbutton></TD>
                                                                <TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZJHSZMoveNext" runat="server">��ҳ</asp:linkbutton></TD>
                                                                <TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZJHSZMoveLast" runat="server">���</asp:linkbutton></TD>
                                                                <TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZJHSZGotoPage" runat="server">ǰ��</asp:linkbutton><asp:textbox id="txtJHSZPageIndex" runat="server" Columns="3" CssClass="textbox">1</asp:textbox>ҳ</TD>
                                                                <TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZJHSZSetPageSize" runat="server">ÿҳ</asp:linkbutton><asp:textbox id="txtJHSZPageSize" runat="server" Columns="3" CssClass="textbox">30</asp:textbox>��</TD>
                                                                <TD class="label" vAlign="middle" noWrap align="right"><asp:label id="lblJHSZGridLocInfo" runat="server" CssClass="label">1/10 N/15</asp:label></TD>
                                                            </TR>
                                                        </TABLE>
                                                    </TD>
                                                </TR>
                                                <TR id="trRow07">
                                                    <TD class="label" align="left" bgColor="#ccff99"><B>&gt;&gt;&gt;&gt;���ƻ��ո����貹��������Ϣ</B></TD>
                                                </TR>
                                                <TR id="trRow08">
                                                    <TD align="left">
                                                        <TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
                                                            <TR>
                                                                <TD class="labelNotNull" noWrap align="right">Ʊ�ݺţ�</TD>
                                                                <TD align="left" style="BORDER-BOTTOM: #99cccc 1px solid" width="15%"><asp:TextBox id="txtJHPJHM" Runat="server" CssClass="textbox" Width="100%"></asp:TextBox></TD>
                                                                <TD class="labelNotNull" noWrap align="right">���(Ԫ)��</TD>
                                                                <TD align="left" style="BORDER-BOTTOM: #99cccc 1px solid" width="15%"><asp:TextBox id="txtJHFSJE" Runat="server" CssClass="textbox" Width="100%"></asp:TextBox></TD>
                                                                <TD class="labelNotNull" noWrap align="right">�����ˣ�</TD>
                                                                <TD align="left" style="BORDER-BOTTOM: #99cccc 1px solid" width="15%"><asp:TextBox id="txtJHJBRY" Runat="server" CssClass="textbox" Width="100%"></asp:TextBox></TD>
                                                                <td align="left"><asp:Button id="btnSelect_JHJBRY" Runat="server" CssClass="button" Text="��"></asp:Button><INPUT id="htxtJHJBRY" type="hidden" size="1" runat="server" NAME="htxtJHJBRY"></td>
                                                                <TD class="labelNotNull" noWrap align="right">���쵥λ��</TD>
                                                                <TD align="left" style="BORDER-BOTTOM: #99cccc 1px solid" width="35%"><asp:TextBox id="txtJHJBDW" Runat="server" CssClass="textbox" Width="100%"></asp:TextBox></TD>
                                                                <td align="left"><asp:Button id="btnSelect_JHJBDW" Runat="server" CssClass="button" Text="��"></asp:Button><INPUT id="htxtJHJBDW" type="hidden" size="1" runat="server" NAME="htxtJHJBDW"></td>
                                                            </TR>
                                                            <TR>
                                                                <TD class="label" noWrap align="right">�ͻ���</TD>
                                                                <TD align="left" style="BORDER-BOTTOM: #99cccc 1px solid" width="15%"><asp:TextBox id="txtJHKHMC" Runat="server" CssClass="textbox" Width="100%"></asp:TextBox></TD>
                                                                <TD class="label" noWrap align="right">ժҪ��</TD>
                                                                <TD align="left" style="BORDER-BOTTOM: #99cccc 1px solid" colspan="7"><asp:TextBox id="txtJHZYSM" Runat="server" CssClass="textbox" Width="100%"></asp:TextBox></TD>
                                                                <td></td>
                                                                <td></td>
                                                            </TR>
                                                        </TABLE>
                                                    </TD>
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
                    <TR id="trRow09">
                        <TD align="center" colSpan="3">
                            <asp:Button id="btnOK" Runat="server" CssClass="button" Text=" ȷ    �� " Height="36px"></asp:Button>
                            <asp:Button id="btnClose" Runat="server" CssClass="button" Text=" ��    �� " Height="36px"></asp:Button>
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
                        <input id="htxtJHSZSessionIdQuery" type="hidden" runat="server">
                        <input id="htxtJHSZQuery" type="hidden" runat="server">
                        <input id="htxtJHSZRows" type="hidden" runat="server">
                        <input id="htxtJHSZSort" type="hidden" runat="server">
                        <input id="htxtJHSZSortColumnIndex" type="hidden" runat="server">
                        <input id="htxtJHSZSortType" type="hidden" runat="server">
                        <input id="htxtDivLeftJHSZ" type="hidden" runat="server">
                        <input id="htxtDivTopJHSZ" type="hidden" runat="server">
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
							function ScrollProc_divJHSZ() {
								var oText;
								oText=null;
								oText=document.getElementById("htxtDivTopJHSZ");
								if (oText != null) oText.value = divJHSZ.scrollTop;
								oText=null;
								oText=document.getElementById("htxtDivLeftJHSZ");
								if (oText != null) oText.value = divJHSZ.scrollLeft;
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
								oText=document.getElementById("htxtDivTopJHSZ");
								if (oText != null) divJHSZ.scrollTop = oText.value;
								oText=null;
								oText=document.getElementById("htxtDivLeftJHSZ");
								if (oText != null) divJHSZ.scrollLeft = oText.value;

								document.body.onscroll = ScrollProc_Body;
								divMain.onscroll = ScrollProc_divMain;
								divJHSZ.onscroll = ScrollProc_divJHSZ;
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
