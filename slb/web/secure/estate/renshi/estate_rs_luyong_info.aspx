<%@ Page Language="vb" AutoEventWireup="false" Codebehind="estate_rs_luyong_info.aspx.vb" Inherits="Josco.JSOA.web.estate_rs_luyong_info" %>
<%@ Register TagPrefix="ComponentArt" Namespace="ComponentArt.Web.UI" Assembly="ComponentArt.Web.UI" %>
<%@ Register TagPrefix="uwin" Namespace="Josco.Web" Assembly="Josco.Web.PopMessage" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
    <HEAD>
        <title>����¼������������ʾ��༭��</title>
        <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
        <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
        <meta content="JavaScript" name="vs_defaultClientScript">
        <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <LINK href="../../../styles01.css" type="text/css" rel="stylesheet">
        <link href="../../../mnuStyle01.css" type="text/css" rel="stylesheet">
        <style>
			TD.grdFJLocked { ; LEFT: expression(divFJ.scrollLeft); POSITION: relative }
			TH.grdFJLocked { ; LEFT: expression(divFJ.scrollLeft); POSITION: relative }
			TH.grdFJLocked { Z-INDEX: 99 }
			TD.grdXGWJLocked { ; LEFT: expression(divXGWJ.scrollLeft); POSITION: relative }
			TH.grdXGWJLocked { ; LEFT: expression(divXGWJ.scrollLeft); POSITION: relative }
			TH.grdXGWJLocked { Z-INDEX: 99 }
			TD.grdRYXXLocked { ; LEFT: expression(divRYXX.scrollLeft); POSITION: relative }
			TH.grdRYXXLocked { ; LEFT: expression(divRYXX.scrollLeft); POSITION: relative }
			TH.grdRYXXLocked { Z-INDEX: 99 }
			TH { Z-INDEX: 10; POSITION: relative }
        </style>
        <script src="../../../scripts/transkey.js"></script>
        <script language="javascript">
			function doMenuItemClick(menuItemId) 
			{
				try {
					document.all("htxtSelectMenuID").value = menuItemId;
					window.setTimeout("__doPostBack('lnkMenu', '');", 500);
				} catch (e) {}
			}
        </script>
        <script language="javascript">
		<!--
			function window_onresize() 
			{
				var dblHeight = 0;
				var dblWidth  = 0;
				var strHeight = "";
				var strWidth  = "";
				
				if (document.all("divContent") == null)
					return;
				
				intWidth   = document.body.clientWidth;   //�ܿ��
				intWidth  -= 16;                          //������
				strWidth   = intWidth.toString() + "px";
				
				intHeight  = document.body.clientHeight;  //�ܸ߶�
				intHeight -= 16;                          //������
				intHeight -= trRow1.clientHeight;
				intHeight -= trRow2.clientHeight;
				strHeight  = intHeight.toString() + "px";
				
				document.all("divContent").style.width  = strWidth;
				document.all("divContent").style.height = strHeight;
				document.all("divContent").style.clip   = "rect(0px " + strWidth + " " + strHeight + " 0px)";
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
        <form id="frmestate_rs_luyong_info" method="post" runat="server">
            <asp:panel id="panelMain" Runat="server">
                <TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
                    <TR id="trRow1">
                        <TD><asp:LinkButton id="lnkBlank" Runat="server" Width="0px"></asp:LinkButton><asp:LinkButton id="lnkMenu" Runat="server" Width="0px"></asp:LinkButton><INPUT id="htxtSelectMenuID" type="hidden" size="1" runat="server"></TD>
                        <TD align="center">
                            <TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
                                <TR>
                                    <TD>
                                        <ComponentArt:Menu id="mnuMain" runat="server" DefaultTarget="mainFrame" ExpandDelay="100" EnableViewState="false"
                                            ImagesBaseUrl="../../images/" DefaultGroupItemSpacing="2" TopGroupItemSpacing="1" DefaultItemLookID="DefaultItemLook"
                                            DefaultSubGroupExpandOffsetY="-5" DefaultSubGroupExpandOffsetX="-10" DefaultGroupCssClass="MenuGroup"
                                            CssClass="TopGroup" Orientation="Horizontal" width="100%">
                                            <Items>
                                                <componentart:MenuItem ID="mnuFILE" DisabledLookId="MenuItemDisabledLook" Text="�ļ��༭" Target="mainFrame">
                                                    <componentart:MenuItem ID="mnuFILE_XGWJ" DisabledLookId="MenuItemDisabledLook" Text="�޸��ļ�" ClientSideCommand="doMenuItemClick('mnuFILE_XGWJ');" Target="mainFrame"></componentart:MenuItem>
                                                    <componentart:MenuItem ID="mnuFILE_BCWJ" DisabledLookId="MenuItemDisabledLook" Text="�����ļ�" ClientSideCommand="doMenuItemClick('mnuFILE_BCWJ');" Target="mainFrame"></componentart:MenuItem>
                                                    <componentart:MenuItem ID="mnuFILE_QXXG" DisabledLookId="MenuItemDisabledLook" Text="ȡ���ļ�" ClientSideCommand="doMenuItemClick('mnuFILE_QXXG');" Target="mainFrame"></componentart:MenuItem>
                                                    <componentart:MenuItem ID="mnuFILE_SXWJ" DisabledLookId="MenuItemDisabledLook" Text="���»�ȡ����" ClientSideCommand="doMenuItemClick('mnuFILE_SXWJ');" Target="mainFrame"></componentart:MenuItem>
                                                </componentart:MenuItem>
                                                <componentart:MenuItem ID="mnuJJCL" DisabledLookId="MenuItemDisabledLook" Text="���Ӵ���" Target="mainFrame">
                                                    <componentart:MenuItem ID="mnuJJCL_FSWJ" DisabledLookId="MenuItemDisabledLook" Text="�����ļ�" ClientSideCommand="doMenuItemClick('mnuJJCL_FSWJ');" Target="mainFrame"></componentart:MenuItem>
                                                    <componentart:MenuItem ID="mnuJJCL_JSWJ" DisabledLookId="MenuItemDisabledLook" Text="�����ļ�" ClientSideCommand="doMenuItemClick('mnuJJCL_JSWJ');" Target="mainFrame"></componentart:MenuItem>
                                                    <componentart:MenuItem ID="mnuJJCL_SHWJ" DisabledLookId="MenuItemDisabledLook" Text="�ջ��ļ�" ClientSideCommand="doMenuItemClick('mnuJJCL_SHWJ');" Target="mainFrame"></componentart:MenuItem>
                                                    <componentart:MenuItem ID="mnuJJCL_THWJ" DisabledLookId="MenuItemDisabledLook" Text="�˻��ļ�" ClientSideCommand="doMenuItemClick('mnuJJCL_THWJ');" Target="mainFrame"></componentart:MenuItem>
                                                    <componentart:MenuItem ID="mnuJJCL_WTBL" DisabledLookId="MenuItemDisabledLook" Text="ί�����˰���" ClientSideCommand="doMenuItemClick('mnuJJCL_WTBL');" Target="mainFrame"></componentart:MenuItem>
                                                </componentart:MenuItem>
                                                <componentart:MenuItem ID="mnuSPCL" DisabledLookId="MenuItemDisabledLook" Text="��������" Target="mainFrame">
                                                    <componentart:MenuItem ID="mnuSPCL_TXYJ" DisabledLookId="MenuItemDisabledLook" Text="��д�ҵ����" ClientSideCommand="doMenuItemClick('mnuSPCL_TXYJ');" Target="mainFrame"></componentart:MenuItem>
                                                    <componentart:MenuItem ID="mnuSPCL_BDPS" DisabledLookId="MenuItemDisabledLook" Text="�����쵼��ʾ" ClientSideCommand="doMenuItemClick('mnuSPCL_BDPS');" Target="mainFrame"></componentart:MenuItem>
                                                    <componentart:MenuItem ID="mnuSPCL_BYBL" DisabledLookId="MenuItemDisabledLook" Text="�Ҳ���Ҫ����" ClientSideCommand="doMenuItemClick('mnuSPCL_BYBL');" Target="mainFrame"></componentart:MenuItem>
                                                    <componentart:MenuItem ID="mnuSPCL_BLWB" DisabledLookId="MenuItemDisabledLook" Text="���Ѱ������" ClientSideCommand="doMenuItemClick('mnuSPCL_BLWB');" Target="mainFrame"></componentart:MenuItem>
                                                    <componentart:MenuItem ID="mnuSPCL_WYYZ" DisabledLookId="MenuItemDisabledLook" Text="���ѿ����ļ�" ClientSideCommand="doMenuItemClick('mnuSPCL_WYYZ');" Target="mainFrame"></componentart:MenuItem>
                                                    <componentart:MenuItem ID="mnuSPCL_ZHBL" DisabledLookId="MenuItemDisabledLook" Text="�ļ��ݻ�����" ClientSideCommand="doMenuItemClick('mnuSPCL_ZHBL');" Target="mainFrame"></componentart:MenuItem>
                                                    <componentart:MenuItem ID="mnuSPCL_JXBL" DisabledLookId="MenuItemDisabledLook" Text="�����ļ��ܰ�" ClientSideCommand="doMenuItemClick('mnuSPCL_JXBL');" Target="mainFrame"></componentart:MenuItem>
                                                    <componentart:MenuItem ID="mnuSPCL_ZFWJ" DisabledLookId="MenuItemDisabledLook" Text="���ϵ�ǰ�ļ�" ClientSideCommand="doMenuItemClick('mnuSPCL_ZFWJ');" Target="mainFrame"></componentart:MenuItem>
                                                    <componentart:MenuItem ID="mnuSPCL_QYWJ" DisabledLookId="MenuItemDisabledLook" Text="���������ļ�" ClientSideCommand="doMenuItemClick('mnuSPCL_QYWJ');" Target="mainFrame"></componentart:MenuItem>
                                                </componentart:MenuItem>
                                                <componentart:MenuItem ID="mnuCBDB" DisabledLookId="MenuItemDisabledLook" Text="�߰춽��" Target="mainFrame">
                                                    <componentart:MenuItem ID="mnuCBDB_CBWJ" DisabledLookId="MenuItemDisabledLook" Text="�߰��ļ�" ClientSideCommand="doMenuItemClick('mnuCBDB_CBWJ');" Target="mainFrame"></componentart:MenuItem>
                                                    <componentart:MenuItem ID="mnuCBDB_DBWJ" DisabledLookId="MenuItemDisabledLook" Text="�����ļ�" ClientSideCommand="doMenuItemClick('mnuCBDB_DBWJ');" Target="mainFrame"></componentart:MenuItem>
                                                    <componentart:MenuItem ID="mnuCBDB_DBJG" DisabledLookId="MenuItemDisabledLook" Text="��д������" ClientSideCommand="doMenuItemClick('mnuCBDB_DBJG');" Target="mainFrame"></componentart:MenuItem>
                                                </componentart:MenuItem>
                                                <componentart:MenuItem ID="mnuXXCY" DisabledLookId="MenuItemDisabledLook" Text="������Ϣ" Target="mainFrame">
                                                    <componentart:MenuItem ID="mnuXXCY_CYYJ" DisabledLookId="MenuItemDisabledLook" Text="�鿴�쵼��ʾ" ClientSideCommand="doMenuItemClick('mnuXXCY_CYYJ');" Target="mainFrame"></componentart:MenuItem>
                                                    <componentart:MenuItem ID="mnuXXCY_CKLZ" DisabledLookId="MenuItemDisabledLook" Text="�鿴��ת���" ClientSideCommand="doMenuItemClick('mnuXXCY_CKLZ');" Target="mainFrame"></componentart:MenuItem>
                                                    <componentart:MenuItem ID="mnuXXCY_CKBY" DisabledLookId="MenuItemDisabledLook" Text="�鿴�������" ClientSideCommand="doMenuItemClick('mnuXXCY_CKBY');" Target="mainFrame"></componentart:MenuItem>
                                                    <componentart:MenuItem ID="mnuXXCY_CKRZ" DisabledLookId="MenuItemDisabledLook" Text="�鿴������־" ClientSideCommand="doMenuItemClick('mnuXXCY_CKRZ');" Target="mainFrame"></componentart:MenuItem>
                                                    <componentart:MenuItem ID="mnuXXCY_CKCB" DisabledLookId="MenuItemDisabledLook" Text="�鿴�߰����" ClientSideCommand="doMenuItemClick('mnuXXCY_CKCB');" Target="mainFrame"></componentart:MenuItem>
                                                    <componentart:MenuItem ID="mnuXXCY_CKDB" DisabledLookId="MenuItemDisabledLook" Text="�鿴�������" ClientSideCommand="doMenuItemClick('mnuXXCY_CKDB');" Target="mainFrame"></componentart:MenuItem>
                                                </componentart:MenuItem>
                                                <componentart:MenuItem ID="mnuXXDY" DisabledLookId="MenuItemDisabledLook" Text="��ӡ��Ϣ" Target="mainFrame">
                                                    <componentart:MenuItem ID="mnuXXDY_DYGZ" DisabledLookId="MenuItemDisabledLook" Text="��ӡ������ֽ" ClientSideCommand="doMenuItemClick('mnuXXDY_DYGZ');" Target="mainFrame"></componentart:MenuItem>
                                                    <componentart:MenuItem ID="mnuXXDY_DYBJ" DisabledLookId="MenuItemDisabledLook" Text="��ӡ����ֽ" ClientSideCommand="doMenuItemClick('mnuXXDY_DYBJ');" Target="mainFrame"></componentart:MenuItem>
                                                </componentart:MenuItem>
                                                <componentart:MenuItem ID="mnuQTCL" DisabledLookId="MenuItemDisabledLook" Text="��������" Target="mainFrame">
                                                    <componentart:MenuItem ID="mnuQTCL_WJBY" DisabledLookId="MenuItemDisabledLook" Text="�ļ����Ĵ���" ClientSideCommand="doMenuItemClick('mnuQTCL_WJBY');" Target="mainFrame"></componentart:MenuItem>
                                                    <componentart:MenuItem ID="mnuQTCL_BWTX" DisabledLookId="MenuItemDisabledLook" Text="���б�������" ClientSideCommand="doMenuItemClick('mnuQTCL_BWTX');" Target="mainFrame"></componentart:MenuItem>
                                                    <componentart:MenuItem ID="mnuQTCL_DRQP" DisabledLookId="MenuItemDisabledLook" Text="����ǩ���ļ�" ClientSideCommand="doMenuItemClick('mnuQTCL_DRQP');" Target="mainFrame"></componentart:MenuItem>
                                                    <componentart:MenuItem ID="mnuQTCL_DRZS" DisabledLookId="MenuItemDisabledLook" Text="����ɨ���ļ�" ClientSideCommand="doMenuItemClick('mnuQTCL_DRZS');" Target="mainFrame"></componentart:MenuItem>
                                                    <componentart:MenuItem ID="mnuQTCL_WJBJ" DisabledLookId="MenuItemDisabledLook" Text="�����ļ�����" ClientSideCommand="doMenuItemClick('mnuQTCL_WJBJ');" Target="mainFrame"></componentart:MenuItem>
                                                    <componentart:MenuItem ID="mnuQTCL_RYLY" DisabledLookId="MenuItemDisabledLook" Text="¼��ѡ����Ա" ClientSideCommand="doMenuItemClick('mnuQTCL_RYLY');" Target="mainFrame"></componentart:MenuItem>
                                                </componentart:MenuItem>
                                                <componentart:MenuItem ID="mnuFHSJ" DisabledLookId="MenuItemDisabledLook" Text="�����ϼ�" ClientSideCommand="doMenuItemClick('mnuFHSJ');" Target="mainFrame"></componentart:MenuItem>
                                            </Items>
                                            <ItemLooks>
                                                <COMPONENTART:ItemLook LookID="TopItemLook" CssClass="TopMenuItem" HoverCssClass="TopMenuItemHover" LabelPaddingLeft="15" LabelPaddingRight="15" LabelPaddingTop="4" LabelPaddingBottom="4" />
                                                <COMPONENTART:ItemLook LookID="DefaultItemLook" CssClass="MenuItem" HoverCssClass="MenuItemHover" ExpandedCssClass="MenuItemHover" LabelPaddingLeft="18" LabelPaddingRight="12" LabelPaddingTop="4" LabelPaddingBottom="4" />
                                                <COMPONENTART:ItemLook LookID="MenuItemDisabledLook" CssClass="MenuItemDisabled" HoverCssClass="" ExpandedCssClass="" LabelPaddingLeft="18" LabelPaddingRight="12" LabelPaddingTop="4" LabelPaddingBottom="4" />
                                                <COMPONENTART:ItemLook LookID="BreakItem" CssClass="MenuBreak" ImageHeight="2" ImageWidth="100%" ImageUrl="../../images/menu01/break.gif" />
                                            </ItemLooks>
                                        </ComponentArt:Menu>
                                    </TD>
                                </TR>
                            </TABLE>
                        </TD>
                        <TD></TD>
                    </TR>
                    <TR>
                        <TD></TD>
                        <TD vAlign="top" align="center">
                            <TABLE cellSpacing="0" cellPadding="0" border="0">
                                <TR>
                                    <TD height="3"></TD>
                                </TR>
                                <TR>
                                    <TD>
                                        <DIV id="divContent" style="OVERFLOW: auto; WIDTH: 820px; CLIP: rect(0px 820px 476px 0px); HEIGHT: 476px">
                                            <TABLE cellSpacing="0" cellPadding="0" align="center" border="0">
                                                <TR>
                                                    <TD>
                                                        <TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
                                                            <TR>
                                                                <TD vAlign="middle" align="center" height="32"><SPAN style="FONT-WEIGHT: bold; FONT-SIZE: 28px; COLOR: red; FONT-FAMILY: ����"><%=Josco.JsKernal.Common.jsoaConfiguration.LicencingTo%>�½���Ա������</SPAN></TD>
                                                            </TR>
                                                            <TR>
                                                                <TD height="10"></TD>
                                                            </TR>
                                                            <TR>
                                                                <TD>
                                                                    <TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
                                                                        <TR>
                                                                            <td width="30">&nbsp;</td>
                                                                            <TD class="labelAuto">���<asp:TextBox id="txtJGDZ" Runat="server" CssClass="textbox" Columns="10"></asp:TextBox>[<asp:TextBox id="txtWJNF" Runat="server" CssClass="textbox" Columns="4"></asp:TextBox>]��[<asp:TextBox id="txtWJXH" Runat="server" CssClass="textbox" Columns="4"></asp:TextBox>]��</TD>
                                                                            <TD class="label">����<asp:DropDownList id="ddlJJCD" Runat="server" CssClass="textbox"></asp:DropDownList></TD>
                                                                            <TD class="label">�ܼ�<asp:DropDownList id="ddlMMDJ" Runat="server" CssClass="textbox"></asp:DropDownList></TD>
                                                                            <TD noWrap align="right"><asp:CheckBox id="chkDDSZ" Runat="server" CssClass="textbox" Text="������ת����" Font-Name="����" Font-Size="12px"></asp:CheckBox></TD>
                                                                            <TD width="30">&nbsp;</TD>
                                                                        </TR>
                                                                    </TABLE>
                                                                </TD>
                                                            </TR>
                                                            <TR>
                                                                <TD align="center">
                                                                    <TABLE cellSpacing="0" cellPadding="0" border="1" bordercolordark="#99cccc" bordercolorlight="#ffffff">
                                                                        <TR>
                                                                            <TD></TD>
                                                                            <TD></TD>
                                                                            <TD></TD>
                                                                            <TD></TD>
                                                                            <TD></TD>
                                                                            <TD></TD>
                                                                        </TR>
                                                                        <TR>
                                                                            <TD colSpan="5">
                                                                                <DIV id="divRYXX" style="TABLE-LAYOUT: fixed; OVERFLOW: auto; WIDTH: 640px; CLIP: rect(0px 640px 300px 0px); HEIGHT: 300px">
                                                                                    <asp:datagrid id="grdRYXX" runat="server" CssClass="label" Font-Size="12px" UseAccessibleHeader="True"
                                                                                        AutoGenerateColumns="False" GridLines="Vertical" BorderStyle="None" CellPadding="4" AllowPaging="false"
                                                                                        PageSize="30" AllowSorting="False" BorderWidth="0px" BorderColor="#DEDFDE" Font-Names="����" Width="1400px">
                                                                                        <FooterStyle BackColor="#CCCC99"></FooterStyle>
                                                                                        <SelectedItemStyle Font-Size="12px" Font-Names="����" Font-Bold="False" VerticalAlign="Middle" ForeColor="#CC0000" BackColor="#FFFFDD"></SelectedItemStyle>
                                                                                        <EditItemStyle Font-Size="12px" Font-Names="����" VerticalAlign="Middle" BackColor="#FFCC00"></EditItemStyle>
                                                                                        <AlternatingItemStyle Font-Size="12px" Font-Names="����" VerticalAlign="Middle" BackColor="White"></AlternatingItemStyle>
                                                                                        <ItemStyle Font-Size="12px" Font-Names="����" BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="#F7F7F7" ForeColor="Black"></ItemStyle>
                                                                                        <HeaderStyle Font-Size="12px" Font-Names="����" Font-Bold="True" ForeColor="White" VerticalAlign="Middle" BackColor="#006699" HorizontalAlign="Left"></HeaderStyle>
                                                                                        
                                                                                        <Columns>
																                            <asp:TemplateColumn HeaderText="ѡ" ItemStyle-Width="20px">
																	                            <HeaderStyle HorizontalAlign="Center" Width="20px"></HeaderStyle>
																	                            <ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
																	                            <ItemTemplate>
																		                            <asp:CheckBox id="chkRYXX" runat="server" AutoPostBack="False" Width="20px"></asp:CheckBox>
																	                            </ItemTemplate>
																                            </asp:TemplateColumn>
                                                                                        
                                                                                            <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="�ļ���ʶ" SortExpression="�ļ���ʶ" HeaderText="�ļ���ʶ" CommandName="Select">
                                                                                                <HeaderStyle Width="0px"></HeaderStyle>
                                                                                            </asp:ButtonColumn>
                                                                                            <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="Ψһ��ʶ" SortExpression="Ψһ��ʶ" HeaderText="Ψһ��ʶ" CommandName="Select">
                                                                                                <HeaderStyle Width="0px"></HeaderStyle>
                                                                                            </asp:ButtonColumn>
                                                                                            <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="��Ա����" SortExpression="��Ա����" HeaderText="��Ա����" CommandName="Select">
                                                                                                <HeaderStyle Width="0px"></HeaderStyle>
                                                                                            </asp:ButtonColumn>
                                                                                            <asp:ButtonColumn ItemStyle-Width="80px" DataTextField="��Ա���" SortExpression="��Ա���" HeaderText="���" CommandName="Select">
                                                                                                <HeaderStyle Width="80px"></HeaderStyle>
                                                                                            </asp:ButtonColumn>
                                                                                            <asp:ButtonColumn ItemStyle-Width="80px" DataTextField="��Ա����" SortExpression="��Ա����" HeaderText="����" CommandName="OpenDocument">
                                                                                                <HeaderStyle Width="80px"></HeaderStyle>
                                                                                            </asp:ButtonColumn>
                                                                                            <asp:ButtonColumn ItemStyle-Width="60px" DataTextField="��Ա�Ա�" SortExpression="��Ա�Ա�" HeaderText="�Ա�" CommandName="Select">
                                                                                                <HeaderStyle Width="60px"></HeaderStyle>
                                                                                            </asp:ButtonColumn>
                                                                                            <asp:ButtonColumn ItemStyle-Width="60px" DataTextField="��Ա����" SortExpression="��Ա����" HeaderText="����" CommandName="Select">
                                                                                                <HeaderStyle Width="60px"></HeaderStyle>
                                                                                            </asp:ButtonColumn>
                                                                                            <asp:ButtonColumn ItemStyle-Width="100px" DataTextField="��Աѧ��" SortExpression="��Աѧ��" HeaderText="ѧ��" CommandName="Select">
                                                                                                <HeaderStyle Width="100px"></HeaderStyle>
                                                                                            </asp:ButtonColumn>
                                                                                            <asp:ButtonColumn ItemStyle-Width="100px" DataTextField="�������" SortExpression="�������" HeaderText="�������" CommandName="OpenDocument">
                                                                                                <HeaderStyle Width="100px"></HeaderStyle>
                                                                                            </asp:ButtonColumn>
                                                                                            <asp:ButtonColumn ItemStyle-Width="140px" DataTextField="����䲿��" SortExpression="����䲿��" HeaderText="����䲿��" CommandName="Select">
                                                                                                <HeaderStyle Width="140px"></HeaderStyle>
                                                                                            </asp:ButtonColumn>
                                                                                            <asp:ButtonColumn ItemStyle-Width="160px" DataTextField="�ⵣ��ְλ" SortExpression="�ⵣ��ְλ" HeaderText="�ⵣ��ְλ" CommandName="Select">
                                                                                                <HeaderStyle Width="160px"></HeaderStyle>
                                                                                            </asp:ButtonColumn>
                                                                                            <asp:ButtonColumn ItemStyle-Width="160px" DataTextField="��Ƹ˵��" SortExpression="��Ƹ˵��" HeaderText="��Ƹ˵��" CommandName="Select">
                                                                                                <HeaderStyle Width="160px"></HeaderStyle>
                                                                                            </asp:ButtonColumn>
                                                                                            <asp:ButtonColumn ItemStyle-Width="160px" DataTextField="������Ա��" SortExpression="������Ա��" HeaderText="����䲿��������Ա" CommandName="Select">
                                                                                                <HeaderStyle Width="160px"></HeaderStyle>
                                                                                            </asp:ButtonColumn>
                                                                                            <asp:ButtonColumn ItemStyle-Width="160px" DataTextField="������Ա��" SortExpression="������Ա��" HeaderText="����䲿�Ŷ�������" CommandName="Select">
                                                                                                <HeaderStyle Width="160px"></HeaderStyle>
                                                                                            </asp:ButtonColumn>
                                                                                            <asp:ButtonColumn ItemStyle-Width="140px" DataTextField="�ⱨ������" SortExpression="�ⱨ������" HeaderText="�ⱨ������" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd}">
                                                                                                <HeaderStyle Width="140px"></HeaderStyle>
                                                                                            </asp:ButtonColumn>
                                                                                        </Columns>
                                                                                        
                                                                                        <PagerStyle Visible="False" NextPageText="��ҳ" Font-Size="12px" Font-Names="����" PrevPageText="��ҳ" HorizontalAlign="Right" ForeColor="Black" Position="TopAndBottom" BackColor="SkyBlue"></PagerStyle>
                                                                                    </asp:datagrid><INPUT id="htxtRYXXFixed" type="hidden" value="0" runat="server">
                                                                                </DIV>
                                                                            </TD>
                                                                            <TD>
                                                                                <TABLE cellSpacing="0" cellPadding="0" border="0">
                                                                                    <TR>
                                                                                        <TD vAlign="middle" align="center" height="20"><asp:LinkButton id="lnkCZQSYJ_SH" Runat="server" CssClass="button"><img src="../../../images/gqsyj.ico" border="0" width="16" height="16" align="absmiddle">���ž������</asp:LinkButton><asp:LinkButton id="lnkCZQSYJ_SHBJ" Runat="server" CssClass="button">(�б��)</asp:LinkButton></TD>
                                                                                    </TR>
                                                                                    <TR>
                                                                                        <TD>
                                                                                            <DIV id="divSHYJ" style="TABLE-LAYOUT: fixed; OVERFLOW: auto; WIDTH: 240px; CLIP: rect(0px 240px 280px 0px); HEIGHT: 280px"><asp:label id="lblSHYJ" Runat="server" CssClass="label">lblSHYJ</asp:label></DIV>
                                                                                        </TD>
                                                                                    </TR>
                                                                                </TABLE>
                                                                            </TD>
                                                                        </TR>
                                                                        <tr>
                                                                            <td colspan="6">
                                                                                <% if propEditMode = False then response.write("<div style='display:none'>") %>
                                                                                <table cellpadding="0" cellspacing="0" width="100%" border="1" bordercolordark="#99cccc" bordercolorlight="#ffffff">
                                                                                    <tr>
                                                                                        <td class="labelNotNull" align="right" nowrap>�������</td>
                                                                                        <td align="left"><asp:TextBox ID="txtJLBH" Runat="server" CssClass="textbox" Columns="12"></asp:TextBox><asp:Button id="btnSelect_JLBH" Runat="server" CssClass="button" Text="��"></asp:Button></td>
                                                                                        <td class="labelNotNull" align="right" nowrap>��Ա����</td>
                                                                                        <td align="left"><asp:TextBox ID="txtRYDM" Runat="server" CssClass="textbox" Columns="12"></asp:TextBox></td>
                                                                                        <td class="label" align="right">����</td>
                                                                                        <td align="left"><asp:TextBox ID="txtRYXM" Runat="server" CssClass="textbox" Columns="12"></asp:TextBox></td>
                                                                                        <td class="label" align="right">�Ա�</td>
                                                                                        <td align="left"><asp:RadioButtonList ID="rblRYXB" Runat="server" CssClass="textbox" RepeatColumns="2" RepeatDirection="Vertical" RepeatLayout="Flow"><asp:ListItem Value="��">��</asp:ListItem><asp:ListItem Value="Ů">Ů</asp:ListItem></asp:RadioButtonList></td>
                                                                                        <td class="label" align="right">����</td>
                                                                                        <td align="left"><asp:TextBox ID="txtRYNN" Runat="server" CssClass="textbox" Columns="6"></asp:TextBox></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td class="label" align="right">ѧ��</td>
                                                                                        <td align="left"><asp:DropDownList ID="ddlXL" Runat="server" CssClass="textbox" Width="100%"></asp:DropDownList></td>
                                                                                        <td class="label" align="right">����䲿��</td>
                                                                                        <td align="left" colspan="3"><asp:TextBox ID="txtNFPBM" Runat="server" CssClass="textbox" Columns="30"></asp:TextBox><asp:Button id="btnSelect_ZZDM" Runat="server" CssClass="button" Text="��"></asp:Button></td>
                                                                                        <td class="label" align="right">�ⵣ��ְλ</td>
                                                                                        <td align="left" colspan="3"><asp:TextBox ID="txtNDRZW" Runat="server" CssClass="textbox" Width="100%"></asp:TextBox></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td class="label" align="right">�ⱨ������</td>
                                                                                        <td align="left"><asp:TextBox ID="txtNBDRQ" Runat="server" CssClass="textbox" Width="100%"></asp:TextBox></td>
                                                                                        <td class="label" align="right">��Ƹ˵��</td>
                                                                                        <td align="left" colspan="3"><asp:TextBox ID="txtZPSM" Runat="server" CssClass="textbox" Width="100%"></asp:TextBox>
                                                                                        <td class="label" align="right">������Ա��</td>
                                                                                        <td align="left"><asp:TextBox ID="txtXYRYS" Runat="server" CssClass="textbox" Width="100%"></asp:TextBox>
                                                                                        <td class="label" align="right">������Ա��</td>
                                                                                        <td align="left"><asp:TextBox ID="txtDBRYS" Runat="server" CssClass="textbox" Width="100%"></asp:TextBox>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td colspan="10" align="right"><asp:Button ID="btnRYXX_AddNew" Runat="server" CssClass="button" Text="������Ա"></asp:Button><asp:Button ID="btnRYXX_Update" Runat="server" CssClass="button" Text="������Ա"></asp:Button><asp:Button ID="btnRYXX_Delete" Runat="server" CssClass="button" Text="ɾ����Ա"></asp:Button></td>
                                                                                    </tr>
                                                                                </table>
                                                                                <% if propEditMode = False then response.write("</div>") %>
                                                                            </td>
                                                                        </tr>
                                                                        <TR>
                                                                            <TD align="center"><asp:LinkButton id="lnkCZQSYJ_FH" Runat="server" CssClass="button"><img src="../../../images/gqsyj.ico" border="0" width="16" height="16" align="absmiddle">���ܸ��ܾ������</asp:LinkButton><asp:LinkButton id="lnkCZQSYJ_FHBJ" Runat="server" CssClass="button">(�б��)</asp:LinkButton></TD>
                                                                            <TD align="center"><asp:LinkButton id="lnkCZQSYJ_QF" Runat="server" CssClass="button"><img src="../../../images/gqsyj.ico" border="0" width="16" height="16" align="absmiddle">�ܾ�������</asp:LinkButton><asp:LinkButton id="lnkCZQSYJ_QFBJ" Runat="server" CssClass="button">(�б��)</asp:LinkButton></TD>
                                                                            <TD class="label" vAlign="middle" align="center" colSpan="2" rowSpan="2">������Ա���������ʵ<BR>�ƻ�����������ʵ</TD>
                                                                            <TD vAlign="middle" align="center" rowSpan="3" nowrap><asp:LinkButton id="lnkCZQSYJ_HQ" Runat="server" CssClass="button"><img src="../../../images/gqsyj.ico" border="0" width="16" height="16" align="absmiddle">�칫���������</asp:LinkButton><br><asp:LinkButton id="lnkCZQSYJ_HQBJ" Runat="server" CssClass="button">(�б��)</asp:LinkButton></TD>
                                                                            <TD rowSpan="3" valign="top"><DIV id="divHQYJ" style="TABLE-LAYOUT: fixed; OVERFLOW: auto; WIDTH: 240px; CLIP: rect(0px 240px 260px 0px); HEIGHT: 260px"><asp:label id="lblHQYJ" Runat="server" CssClass="label">lblHQYJ</asp:label></DIV></TD>
                                                                        </TR>
                                                                        <TR>
                                                                            <TD vAlign="top" rowSpan="5"><DIV id="divFHYJ" style="TABLE-LAYOUT: fixed; OVERFLOW: auto; WIDTH: 180px; CLIP: rect(0px 180px 178px 0px); HEIGHT: 178px"><asp:label id="lblFHYJ" Runat="server" CssClass="label">lblFHYJ</asp:label></DIV></TD>
                                                                            <TD vAlign="top" rowSpan="4"><DIV id="divQFYJ" style="TABLE-LAYOUT: fixed; OVERFLOW: auto; WIDTH: 180px; CLIP: rect(0px 180px 160px 0px); HEIGHT: 160px"><asp:label id="lblQFYJ" Runat="server" CssClass="label">lblQFYJ</asp:label></DIV></TD>
                                                                        </TR>
                                                                        <TR>
                                                                            <TD class="label" noWrap align="center">�칫�Һ�ʵ</TD>
                                                                            <TD><asp:TextBox id="txtDBRS" Runat="server" CssClass="textbox" Columns="6"></asp:TextBox></TD>
                                                                        </TR>
                                                                        <TR>
                                                                            <TD class="label" colSpan="4">1���칫��֪ͨ�����������������������֪ͨ�����Ա���칫�Ұ�����ְ����</TD>
                                                                        </TR>
                                                                        <TR>
                                                                            <TD class="label" colSpan="4">2����ְʱ���԰�����ְ����Ϊ׼����ǰ������Ա�ĵ�н�������������������</TD>
                                                                        </TR>
                                                                        <TR>
                                                                            <TD style="FONT-FAMILY: ����" align="right" style="BORDER-TOP-STYLE: none">ǩ����<asp:Label id="lblQFR" Runat="server"></asp:Label></TD>
                                                                            <TD class="label" colSpan="4">3�������֤�����Ա������׺󷽿ɰ�����ְ����</TD>
                                                                        </TR>
                                                                    </TABLE>
                                                                </TD>
                                                            </TR>
                                                        </TABLE>
                                                    </TD>
                                                </TR>
                                                <TR>
                                                    <TD align="center">
                                                        <TABLE cellSpacing="0" cellPadding="0" width="100%" border="1" bordercolordark="#99cccc" bordercolorlight="#ffffff">
                                                            <tr>
                                                                <td></td>
                                                                <td></td>
                                                                <td></td>
                                                                <td></td>
                                                                <td></td>
                                                                <td></td>
                                                            </tr>
                                                            <TR>
                                                                <TD class="labelAuto" align="right">���쵥λ��</TD>
                                                                <TD align="left"><asp:TextBox id="txtJBDW" Runat="server" CssClass="textbox" Width="100%"></asp:TextBox></TD>
                                                                <TD class="labelAuto" align="right">������Ա��</TD>
                                                                <TD align="left"><asp:TextBox id="txtJBRY" Runat="server" CssClass="textbox" Width="100%"></asp:TextBox></TD>
                                                                <TD class="labelAuto" align="right">�������ڣ�</TD>
                                                                <TD align="left"><asp:TextBox id="txtJBRQ" Runat="server" CssClass="textbox" Width="100%"></asp:TextBox></TD>
                                                            </TR>
                                                            <TR>
                                                                <TD class="label" align="right">���⣺</TD>
                                                                <TD align="left" colSpan="5"><asp:TextBox id="txtWJBT" Runat="server" CssClass="textbox" Width="100%"></asp:TextBox></TD>
                                                            </TR>
                                                            <TR>
                                                                <TD class="label" align="right">��ע��</TD>
                                                                <TD align="left" colSpan="5"><asp:TextBox id="txtBZXX" Runat="server" CssClass="textbox" Width="100%"></asp:TextBox></TD>
                                                            </TR>
                                                        </TABLE>
                                                    </TD>
                                                </TR>
                                                <TR>
                                                    <TD align="center">
                                                        <DIV style="DISPLAY: none">
                                                            <TABLE cellSpacing="0" cellPadding="0" border="0">
                                                                <TR>
                                                                    <TD colSpan="4" height="3"></TD>
                                                                </TR>
                                                                <TR>
                                                                    <TD class="title" vAlign="middle" align="center" width="30">��<BR>��<BR>��<BR>��</TD>
                                                                    <TD>
                                                                        <DIV id="divFJ" style="TABLE-LAYOUT: fixed; OVERFLOW: auto; WIDTH: 370px; CLIP: rect(0px 370px 120px 0px); HEIGHT: 120px">
                                                                            <asp:datagrid id="grdFJ" runat="server" CssClass="label" Font-Size="12px" UseAccessibleHeader="True"
                                                                                AutoGenerateColumns="False" GridLines="Vertical" BorderStyle="None" CellPadding="4" AllowPaging="false"
                                                                                PageSize="30" AllowSorting="False" BorderWidth="0px" BorderColor="#DEDFDE" Font-Names="����">
                                                                                <FooterStyle BackColor="#CCCC99"></FooterStyle>
                                                                                <SelectedItemStyle Font-Size="12px" Font-Names="����" Font-Bold="False" VerticalAlign="Middle" ForeColor="#CC0000" BackColor="#FFFFDD"></SelectedItemStyle>
                                                                                <EditItemStyle Font-Size="12px" Font-Names="����" VerticalAlign="Middle" BackColor="#FFCC00"></EditItemStyle>
                                                                                <AlternatingItemStyle Font-Size="12px" Font-Names="����" VerticalAlign="Middle" BackColor="White"></AlternatingItemStyle>
                                                                                <ItemStyle Font-Size="12px" Font-Names="����" BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="#F7F7F7" ForeColor="Black"></ItemStyle>
                                                                                <HeaderStyle Font-Size="12px" Font-Names="����" Font-Bold="True" ForeColor="White" VerticalAlign="Middle" BackColor="#6699cc" HorizontalAlign="Left"></HeaderStyle>
                                                                                
                                                                                <Columns>
                                                                                    <asp:ButtonColumn ItemStyle-Width="40px" DataTextField="��ʾ���" SortExpression="��ʾ���" HeaderText="���" CommandName="Select">
                                                                                        <HeaderStyle Width="40px"></HeaderStyle>
                                                                                    </asp:ButtonColumn>
                                                                                    <asp:ButtonColumn ItemStyle-Width="340px" DataTextField="˵��" SortExpression="˵��" HeaderText="����" CommandName="OpenDocument">
                                                                                        <HeaderStyle Width="340px"></HeaderStyle>
                                                                                    </asp:ButtonColumn>
                                                                                    <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="�ļ���ʶ" SortExpression="�ļ���ʶ" HeaderText="�ļ���ʶ" CommandName="Select">
                                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                                    </asp:ButtonColumn>
                                                                                    <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="���" SortExpression="���" HeaderText="���" CommandName="Select">
                                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                                    </asp:ButtonColumn>
                                                                                    <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="ҳ��" SortExpression="ҳ��" HeaderText="ҳ��" CommandName="Select">
                                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                                    </asp:ButtonColumn>
                                                                                    <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="λ��" SortExpression="λ��" HeaderText="λ��" CommandName="Select">
                                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                                    </asp:ButtonColumn>
                                                                                    <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="�����ļ�" SortExpression="�����ļ�" HeaderText="�����ļ�" CommandName="Select">
                                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                                    </asp:ButtonColumn>
                                                                                    <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="���ر�־" SortExpression="���ر�־" HeaderText="���ر�־" CommandName="Select">
                                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                                    </asp:ButtonColumn>
                                                                                </Columns>
                                                                                
                                                                                <PagerStyle Visible="False" NextPageText="��ҳ" Font-Size="12px" Font-Names="����" PrevPageText="��ҳ" HorizontalAlign="Right" ForeColor="Black" Position="TopAndBottom" BackColor="SkyBlue"></PagerStyle>
                                                                            </asp:datagrid><INPUT id="htxtFJFixed" type="hidden" value="0" runat="server">
                                                                        </DIV>
                                                                    </TD>
                                                                    <TD class="title" vAlign="middle" align="center" width="30">��<BR>��<BR>��<BR>��</TD>
                                                                    <TD>
                                                                        <DIV id="divXGWJ" style="TABLE-LAYOUT: fixed; OVERFLOW: auto; WIDTH: 370px; CLIP: rect(0px 370px 120px 0px); HEIGHT: 120px">
                                                                            <asp:datagrid id="grdXGWJ" runat="server" CssClass="label" Font-Size="12px" UseAccessibleHeader="True"
                                                                                AutoGenerateColumns="False" GridLines="Vertical" BorderStyle="None" CellPadding="4" AllowPaging="false"
                                                                                PageSize="30" AllowSorting="False" BorderWidth="0px" BorderColor="#DEDFDE" Font-Names="����">
                                                                                <FooterStyle BackColor="#CCCC99"></FooterStyle>
                                                                                <SelectedItemStyle Font-Size="12px" Font-Names="����" Font-Bold="False" VerticalAlign="Middle" ForeColor="#CC0000" BackColor="#FFFFDD"></SelectedItemStyle>
                                                                                <EditItemStyle Font-Size="12px" Font-Names="����" VerticalAlign="Middle" BackColor="#FFCC00"></EditItemStyle>
                                                                                <AlternatingItemStyle Font-Size="12px" Font-Names="����" VerticalAlign="Middle" BackColor="White"></AlternatingItemStyle>
                                                                                <ItemStyle Font-Size="12px" Font-Names="����" BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="#F7F7F7" ForeColor="Black"></ItemStyle>
                                                                                <HeaderStyle Font-Size="12px" Font-Names="����" Font-Bold="True" ForeColor="White" VerticalAlign="Middle" BackColor="#6699cc" HorizontalAlign="Left"></HeaderStyle>
                                                                                
                                                                                <Columns>
                                                                                    <asp:ButtonColumn ItemStyle-Width="40px" DataTextField="��ʾ���" SortExpression="��ʾ���" HeaderText="���" CommandName="Select">
                                                                                        <HeaderStyle Width="40px"></HeaderStyle>
                                                                                    </asp:ButtonColumn>
                                                                                    <asp:ButtonColumn ItemStyle-Width="340px" DataTextField="�ļ�����" SortExpression="�ļ�����" HeaderText="����" CommandName="OpenDocument">
                                                                                        <HeaderStyle Width="340px"></HeaderStyle>
                                                                                    </asp:ButtonColumn>
                                                                                    <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="����ʶ" SortExpression="����ʶ" HeaderText="����ʶ" CommandName="Select">
                                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                                    </asp:ButtonColumn>
                                                                                    <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="�ļ���ʶ" SortExpression="�ļ���ʶ" HeaderText="�ļ���ʶ" CommandName="Select">
                                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                                    </asp:ButtonColumn>
                                                                                    <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="��ˮ��" SortExpression="��ˮ��" HeaderText="��ˮ��" CommandName="Select">
                                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                                    </asp:ButtonColumn>
                                                                                    <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="�ļ�����" SortExpression="�ļ�����" HeaderText="�ļ�����" CommandName="Select">
                                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                                    </asp:ButtonColumn>
                                                                                    <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="��������" SortExpression="��������" HeaderText="��������" CommandName="Select">
                                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                                    </asp:ButtonColumn>
                                                                                    <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="�ļ�����" SortExpression="�ļ�����" HeaderText="�ļ�����" CommandName="Select">
                                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                                    </asp:ButtonColumn>
                                                                                    <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="����״̬" SortExpression="����״̬" HeaderText="����״̬" CommandName="Select">
                                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                                    </asp:ButtonColumn>
                                                                                    <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="���͵�λ" SortExpression="���͵�λ" HeaderText="���͵�λ" CommandName="Select">
                                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                                    </asp:ButtonColumn>
                                                                                    <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="���ش���" SortExpression="���ش���" HeaderText="���ش���" CommandName="Select">
                                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                                    </asp:ButtonColumn>
                                                                                    <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="�ļ����" SortExpression="�ļ����" HeaderText="�ļ����" CommandName="Select">
                                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                                    </asp:ButtonColumn>
                                                                                    <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="�ļ����" SortExpression="�ļ����" HeaderText="�ļ����" CommandName="Select">
                                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                                    </asp:ButtonColumn>
                                                                                    <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="���쵥λ" SortExpression="���쵥λ" HeaderText="���쵥λ" CommandName="Select">
                                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                                    </asp:ButtonColumn>
                                                                                    <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="�����" SortExpression="�����" HeaderText="�����" CommandName="Select">
                                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                                    </asp:ButtonColumn>
                                                                                    <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="�������" SortExpression="�������" HeaderText="�������" CommandName="Select">
                                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                                    </asp:ButtonColumn>
                                                                                    <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="�����" SortExpression="�����" HeaderText="�����" CommandName="Select">
                                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                                    </asp:ButtonColumn>
                                                                                    <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="��������" SortExpression="��������" HeaderText="��������" CommandName="Select">
                                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                                    </asp:ButtonColumn>
                                                                                    <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="���" SortExpression="���" HeaderText="���" CommandName="Select">
                                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                                    </asp:ButtonColumn>
                                                                                    <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="ҳ��" SortExpression="ҳ��" HeaderText="ҳ��" CommandName="Select">
                                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                                    </asp:ButtonColumn>
                                                                                    <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="λ��" SortExpression="λ��" HeaderText="λ��" CommandName="Select">
                                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                                    </asp:ButtonColumn>
                                                                                    <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="�����ļ�" SortExpression="�����ļ�" HeaderText="�����ļ�" CommandName="Select">
                                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                                    </asp:ButtonColumn>
                                                                                    <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="���ر�־" SortExpression="���ر�־" HeaderText="���ر�־" CommandName="Select">
                                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                                    </asp:ButtonColumn>
                                                                                </Columns>
                                                                                
                                                                                <PagerStyle Visible="False" NextPageText="��ҳ" Font-Size="12px" Font-Names="����" PrevPageText="��ҳ" HorizontalAlign="Right" ForeColor="Black" Position="TopAndBottom" BackColor="SkyBlue"></PagerStyle>
                                                                            </asp:datagrid><INPUT id="htxtXGWJFixed" type="hidden" value="0" runat="server">
                                                                        </DIV>
                                                                    </TD>
                                                                </TR>
                                                            </TABLE>
                                                        </DIV>
                                                    </TD>
                                                </TR>
                                            </TABLE>
                                        </DIV>
                                    </TD>
                                </TR>
                                <TR>
                                    <TD height="3"></TD>
                                </TR>
                            </TABLE>
                        </TD>
                        <TD></TD>
                    </TR>
                    <TR id="trRow2">
                        <TD style="BORDER-TOP: #006699 2px solid" align="center" colSpan="3">
                            <TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
                                <TR>
                                    <TD align="center">
                                        <div style="display:">
                                            <TABLE cellSpacing="0" cellPadding="0" border="0">
                                                <TR>
                                                    <TD vAlign="baseline"><asp:LinkButton id="lnkCZCYGJ" Runat="server" CssClass="button" Visible="False">���ĸ��</asp:LinkButton></TD>
                                                    <TD vAlign="baseline"><asp:LinkButton id="lnkCZCYFJ" Runat="server" CssClass="button" Visible="False">���ĸ���</asp:LinkButton></TD>
                                                    <TD vAlign="baseline"><asp:LinkButton id="lnkCZCYXGWJ" Runat="server" CssClass="button" Visible="False">��������ļ�</asp:LinkButton></TD>
                                                    <TD vAlign="baseline"><asp:LinkButton id="lnkCZCYQPWJ" Runat="server" CssClass="button">���ĵ���ǩ����</asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;</TD>
                                                    <TD vAlign="baseline"><asp:LinkButton id="lnkCZCYZSWJ" Runat="server" CssClass="button">����ԭ��ɨ���</asp:LinkButton></TD>
                                                </TR>
                                            </TABLE>
                                        </div>
                                    </TD>
                                    <TD class="labelAuto" align="right">��ˮ��<asp:TextBox id="txtLSH" Runat="server" CssClass="textbox" Columns="14" Font-Name="����" Font-Size="12px"></asp:TextBox><INPUT id="htxtWJBS" type="hidden" size="1" runat="server"></TD>
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
                        <input id="htxtSessionIDRYXX" type="hidden" runat="server">
                        <input id="htxtSessionIDXGWJ" type="hidden" runat="server">
                        <input id="htxtSessionIDFJ" type="hidden" runat="server">
                        <input id="htxtEnforeEdit" type="hidden" runat="server">
                        <input id="htxtEditMode" type="hidden" runat="server">
                        <input id="htxtEditType" type="hidden" runat="server">
                        <input id="htxtZWNRFileName" type="hidden" runat="server">
                        <input id="htxtRYXXSort" type="hidden" runat="server">
                        <input id="htxtRYXXSortColumnIndex" type="hidden" runat="server">
                        <input id="htxtRYXXSortType" type="hidden" runat="server">
                        <input id="htxtXGWJSort" type="hidden" runat="server">
                        <input id="htxtXGWJSortColumnIndex" type="hidden" runat="server">
                        <input id="htxtXGWJSortType" type="hidden" runat="server">
                        <input id="htxtFJSort" type="hidden" runat="server">
                        <input id="htxtFJSortColumnIndex" type="hidden" runat="server">
                        <input id="htxtFJSortType" type="hidden" runat="server">
                        <input id="htxtDivLeftRYXX" type="hidden" runat="server">
                        <input id="htxtDivTopRYXX" type="hidden" runat="server">
                        <input id="htxtDivLeftXGWJ" type="hidden" runat="server">
                        <input id="htxtDivTopXGWJ" type="hidden" runat="server">
                        <input id="htxtDivLeftFJ" type="hidden" runat="server">
                        <input id="htxtDivTopFJ" type="hidden" runat="server">
                        <input id="htxtDivLeftSHYJ" type="hidden" runat="server">
                        <input id="htxtDivTopSHYJ" type="hidden" runat="server">
                        <input id="htxtDivLeftHQYJ" type="hidden" runat="server">
                        <input id="htxtDivTopHQYJ" type="hidden" runat="server">
                        <input id="htxtDivLeftFHYJ" type="hidden" runat="server">
                        <input id="htxtDivTopFHYJ" type="hidden" runat="server">
                        <input id="htxtDivLeftQFYJ" type="hidden" runat="server">
                        <input id="htxtDivTopQFYJ" type="hidden" runat="server">
                        <input id="htxtDivLeftContent" type="hidden" runat="server">
                        <input id="htxtDivTopContent" type="hidden" runat="server">
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
							function ScrollProc_divContent() {
								var oText;
								oText=null;
								oText=document.getElementById("htxtDivTopContent");
								if (oText != null) oText.value = divContent.scrollTop;
								oText=null;
								oText=document.getElementById("htxtDivLeftContent");
								if (oText != null) oText.value = divContent.scrollLeft;
								return;
							}
							function ScrollProc_divQFYJ() {
								var oText;
								oText=null;
								oText=document.getElementById("htxtDivTopQFYJ");
								if (oText != null) oText.value = divQFYJ.scrollTop;
								oText=null;
								oText=document.getElementById("htxtDivLeftQFYJ");
								if (oText != null) oText.value = divQFYJ.scrollLeft;
								return;
							}
							function ScrollProc_divFHYJ() {
								var oText;
								oText=null;
								oText=document.getElementById("htxtDivTopFHYJ");
								if (oText != null) oText.value = divFHYJ.scrollTop;
								oText=null;
								oText=document.getElementById("htxtDivLeftFHYJ");
								if (oText != null) oText.value = divFHYJ.scrollLeft;
								return;
							}
							function ScrollProc_divHQYJ() {
								var oText;
								oText=null;
								oText=document.getElementById("htxtDivTopHQYJ");
								if (oText != null) oText.value = divHQYJ.scrollTop;
								oText=null;
								oText=document.getElementById("htxtDivLeftHQYJ");
								if (oText != null) oText.value = divHQYJ.scrollLeft;
								return;
							}
							function ScrollProc_divSHYJ() {
								var oText;
								oText=null;
								oText=document.getElementById("htxtDivTopSHYJ");
								if (oText != null) oText.value = divSHYJ.scrollTop;
								oText=null;
								oText=document.getElementById("htxtDivLeftSHYJ");
								if (oText != null) oText.value = divSHYJ.scrollLeft;
								return;
							}
							function ScrollProc_divFJ() {
								var oText;
								oText=null;
								oText=document.getElementById("htxtDivTopFJ");
								if (oText != null) oText.value = divFJ.scrollTop;
								oText=null;
								oText=document.getElementById("htxtDivLeftFJ");
								if (oText != null) oText.value = divFJ.scrollLeft;
								return;
							}
							function ScrollProc_divXGWJ() {
								var oText;
								oText=null;
								oText=document.getElementById("htxtDivTopXGWJ");
								if (oText != null) oText.value = divXGWJ.scrollTop;
								oText=null;
								oText=document.getElementById("htxtDivLeftXGWJ");
								if (oText != null) oText.value = divXGWJ.scrollLeft;
								return;
							}
							function ScrollProc_divRYXX() {
								var oText;
								oText=null;
								oText=document.getElementById("htxtDivTopRYXX");
								if (oText != null) oText.value = divRYXX.scrollTop;
								oText=null;
								oText=document.getElementById("htxtDivLeftRYXX");
								if (oText != null) oText.value = divRYXX.scrollLeft;
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
								oText=document.getElementById("htxtDivTopContent");
								if (oText != null) divContent.scrollTop = oText.value;
								oText=null;
								oText=document.getElementById("htxtDivLeftContent");
								if (oText != null) divContent.scrollLeft = oText.value;

								oText=null;
								oText=document.getElementById("htxtDivTopQFYJ");
								if (oText != null) divQFYJ.scrollTop = oText.value;
								oText=null;
								oText=document.getElementById("htxtDivLeftQFYJ");
								if (oText != null) divQFYJ.scrollLeft = oText.value;

								oText=null;
								oText=document.getElementById("htxtDivTopFHYJ");
								if (oText != null) divFHYJ.scrollTop = oText.value;
								oText=null;
								oText=document.getElementById("htxtDivLeftFHYJ");
								if (oText != null) divFHYJ.scrollLeft = oText.value;

								oText=null;
								oText=document.getElementById("htxtDivTopHQYJ");
								if (oText != null) divHQYJ.scrollTop = oText.value;
								oText=null;
								oText=document.getElementById("htxtDivLeftHQYJ");
								if (oText != null) divHQYJ.scrollLeft = oText.value;

								oText=null;
								oText=document.getElementById("htxtDivTopSHYJ");
								if (oText != null) divSHYJ.scrollTop = oText.value;
								oText=null;
								oText=document.getElementById("htxtDivLeftSHYJ");
								if (oText != null) divSHYJ.scrollLeft = oText.value;

								oText=null;
								oText=document.getElementById("htxtDivTopFJ");
								if (oText != null) divFJ.scrollTop = oText.value;
								oText=null;
								oText=document.getElementById("htxtDivLeftFJ");
								if (oText != null) divFJ.scrollLeft = oText.value;

								oText=null;
								oText=document.getElementById("htxtDivTopXGWJ");
								if (oText != null) divXGWJ.scrollTop = oText.value;
								oText=null;
								oText=document.getElementById("htxtDivLeftXGWJ");
								if (oText != null) divXGWJ.scrollLeft = oText.value;

								oText=null;
								oText=document.getElementById("htxtDivTopRYXX");
								if (oText != null) divRYXX.scrollTop = oText.value;
								oText=null;
								oText=document.getElementById("htxtDivLeftRYXX");
								if (oText != null) divRYXX.scrollLeft = oText.value;

								document.body.onscroll = ScrollProc_Body;
								divContent.onscroll = ScrollProc_divContent;
								divQFYJ.onscroll = ScrollProc_divQFYJ;
								divFHYJ.onscroll = ScrollProc_divFHYJ;
								divHQYJ.onscroll = ScrollProc_divHQYJ;
								divSHYJ.onscroll = ScrollProc_divSHYJ;
								divFJ.onscroll = ScrollProc_divFJ;
								divXGWJ.onscroll = ScrollProc_divXGWJ;
								divRYXX.onscroll = ScrollProc_divRYXX;
							}
							catch (e) {}
                        </script>
                    </td>
                </tr>
                <tr>
                    <td>
                        <script language="javascript">window_onresize();</script>
                        <uwin:popmessage id="popMessageObject" runat="server" Visible="False" EnableViewState="False" PopupWindowType="Normal" ActionType="OpenWindow" height="48px" width="96px"></uwin:popmessage>
                    </td>
                </tr>
            </table>
        </form>
    </body>
</HTML>
