<%@ Page Language="vb" AutoEventWireup="false" Codebehind="estate_rs_renyuanjiagou_del.aspx.vb" Inherits="Josco.JSOA.web.estate_rs_renyuanjiagou_del" %>
<%@ Register TagPrefix="uwin" Namespace="Josco.Web" Assembly="Josco.Web.PopMessage" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
    <HEAD>
        <title>��Ա�뿪��λ����</title>
        <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
        <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
        <meta content="JavaScript" name="vs_defaultClientScript">
        <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <LINK href="../../../stylesw.css" type="text/css" rel="stylesheet">
        <script src="../../../scripts/transkey.js"></script>
		<style>
			TD.grdRYLocked { ; LEFT: expression(divRY.scrollLeft); POSITION: relative }
			TH.grdRYLocked { ; LEFT: expression(divRY.scrollLeft); POSITION: relative }
			TH.grdRYLocked { Z-INDEX: 99 }
			TD.grdXJLocked { ; LEFT: expression(divXJ.scrollLeft); POSITION: relative }
			TH.grdXJLocked { ; LEFT: expression(divXJ.scrollLeft); POSITION: relative }
			TH.grdXJLocked { Z-INDEX: 99 }
			TH { Z-INDEX: 10; POSITION: relative }
		</style>
		<script language="javascript">
		<!--
			//zengxianglin 2008-10-14
			function onclick_btnViewJG()
			{
				var strParams = "";
				strParams = strParams + "height=" + (screen.availHeight - 40).toString() +",";
				strParams = strParams + "width="  + (screen.availWidth  - 12).toString() +",";
				strParams = strParams + "top=0,";
				strParams = strParams + "left=0,";
				strParams = strParams + "location=no,";
				strParams = strParams + "menubar=no,";
				strParams = strParams + "toolbar=no,";
				strParams = strParams + "status=no,";
				strParams = strParams + "resizable=yes,";
				strParams = strParams + "scrollbars=yes,";
				strParams = strParams + "titlebar=yes";
				window.open("estate_rs_renyuanjiagou_bdls.aspx", "_blank", strParams);
			}
			//zengxianglin 2008-10-14
		
			function window_onresize() 
			{
				var dblHeight = 0;
				var dblWidth  = 0;
				var strHeight = "";
				var strWidth  = "";
				
				if (document.all("divMain") == null)
					return;
				
				intWidth   = document.body.clientWidth;   //�ܿ��
				intWidth  -= 16;                          //������
				strWidth   = intWidth.toString() + "px";
				
				intHeight  = document.body.clientHeight;  //�ܸ߶�
				intHeight -= 16;                          //������
				intHeight -= 30;                          //trRow1.clientHeight;
				intHeight -= 36;                          //trRow2.clientHeight;
				strHeight  = intHeight.toString() + "px";
				
				document.all("divMain").style.width  = strWidth;
				document.all("divMain").style.height = strHeight;
				document.all("divMain").style.clip   = "rect(0px " + strWidth + " " + strHeight + " 0px)";
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
    <body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" background="../../../images/bgmain.gif" onresize="javascript:window_onresize()">
        <form id="frmestate_rs_renyuanjiagou_del" method="post" runat="server">
            <asp:panel id="panelMain" Runat="server">
                <TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
                    <TR>
                        <TD id="trRow1" height="30" class="title" style="BORDER-BOTTOM: #99cccc 2px solid" vAlign="middle" align="left">��ǰλ�ã����¹���&nbsp;&gt;&gt;&gt;&gt;&nbsp;����ҵ����Ա�ܹ�����&nbsp;&gt;&gt;&gt;&gt;&nbsp;�뿪��λ<asp:LinkButton id="lnkBlank" Runat="server" Width="0px"></asp:LinkButton></TD>
                    </TR>
                    <TR>
                        <TD vAlign="top" align="center">
                            <DIV id="divMain" style="OVERFLOW: auto; WIDTH: 996px; CLIP: rect(0px 464px 996px 0px); HEIGHT: 464px">
                                <TABLE cellSpacing="0" cellPadding="0" border="0">
                                    <TR>
                                        <TD class="title" align="left" bgcolor="#ccff99">>>>>�ܹ���������Աһ���� (���� <asp:Label ID="lblRYSM_RY" Runat="server" CssClass="label"></asp:Label> ��)</TD>
                                    </TR>
                                    <TR>
                                        <TD align="center">
                                            <DIV id="divRY" style="BORDER-RIGHT: #99cccc 1px solid; BORDER-TOP: #99cccc 1px solid; OVERFLOW: auto; BORDER-LEFT: #99cccc 1px solid; WIDTH: 940px; CLIP: rect(0px 940px 250px 0px); BORDER-BOTTOM: #99cccc 1px solid; HEIGHT: 250px">
                                                <asp:datagrid id="grdRY" runat="server" CssClass="label" UseAccessibleHeader="True"
                                                    AutoGenerateColumns="False" GridLines="Vertical" BackColor="White" BorderStyle="None" CellPadding="2"
                                                    AllowPaging="True" PageSize="10" BorderColor="#DEDFDE" BorderWidth="0px" AllowSorting="False" Width="1100px">
                                                    <SelectedItemStyle Font-Bold="False" VerticalAlign="Middle" ForeColor="#CC0000" BackColor="#FFFFDD"></SelectedItemStyle>
                                                    <EditItemStyle VerticalAlign="Middle" BackColor="#FFCC00"></EditItemStyle>
                                                    <AlternatingItemStyle BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="White"></AlternatingItemStyle>
                                                    <ItemStyle BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="#F7F7F7" ForeColor="Black"></ItemStyle>
                                                    <HeaderStyle Font-Bold="True" ForeColor="White" VerticalAlign="Middle" BackColor="#87cefa" HorizontalAlign="Left"></HeaderStyle>
                                                    <FooterStyle BackColor="#CCCC99"></FooterStyle>
                                                    
                                                    <Columns>
                                                        <asp:TemplateColumn HeaderText="ѡ" Visible="False">
                                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                            <ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
                                                            <ItemTemplate>
                                                                <asp:CheckBox id="chkRY" runat="server" AutoPostBack="False" Visible="False"></asp:CheckBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateColumn>
                                                        
                                                        <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="��Ա����" SortExpression="��Ա����" HeaderText="����" CommandName="Select">
                                                            <HeaderStyle Width="0px"></HeaderStyle>
                                                        </asp:ButtonColumn>
                                                        <asp:ButtonColumn ItemStyle-Width="100px" DataTextField="��Ա����" SortExpression="��Ա����" HeaderText="��Ա����" CommandName="Select">
                                                            <HeaderStyle Width="100px"></HeaderStyle>
                                                        </asp:ButtonColumn>
                                                        <asp:ButtonColumn ItemStyle-Width="80px" DataTextField="��Ա����" SortExpression="��Ա����" HeaderText="��Ա����" CommandName="Select">
                                                            <HeaderStyle Width="80px"></HeaderStyle>
                                                        </asp:ButtonColumn>
                                                        <asp:ButtonColumn ItemStyle-Width="100px" DataTextField="ְ������" SortExpression="ְ������" HeaderText="ְ������" CommandName="Select">
                                                            <HeaderStyle Width="100px"></HeaderStyle>
                                                        </asp:ButtonColumn>
                                                        <asp:ButtonColumn ItemStyle-Width="120px" DataTextField="ְ������" SortExpression="ְ������" HeaderText="ְ������" CommandName="Select">
                                                            <HeaderStyle Width="120px"></HeaderStyle>
                                                        </asp:ButtonColumn>
                                                        <asp:ButtonColumn ItemStyle-Width="170px" DataTextField="������λ����" SortExpression="������λ����" HeaderText="��λ����" CommandName="Select">
                                                            <HeaderStyle Width="170px"></HeaderStyle>
                                                        </asp:ButtonColumn>
														<asp:ButtonColumn ItemStyle-Width="110px" DataTextField="��������" SortExpression="��������" HeaderText="��������" CommandName="Select">
															<HeaderStyle Width="110px"></HeaderStyle>
														</asp:ButtonColumn>
                                                        <asp:ButtonColumn ItemStyle-Width="170px" DataTextField="ֱ�ܵ�λ����" SortExpression="ֱ�ܵ�λ����" HeaderText="ֱ�ܵ�λ" CommandName="Select">
                                                            <HeaderStyle Width="170px"></HeaderStyle>
                                                        </asp:ButtonColumn>
                                                        <asp:ButtonColumn ItemStyle-Width="80px" DataTextField="�ϼ��쵼����" SortExpression="�ϼ��쵼����" HeaderText="�ϼ��쵼" CommandName="Select">
                                                            <HeaderStyle Width="80px"></HeaderStyle>
                                                        </asp:ButtonColumn>
                                                        <asp:ButtonColumn ItemStyle-Width="90px" DataTextField="��Чʱ��" SortExpression="��Чʱ��" HeaderText="��Чʱ��" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd}">
                                                            <HeaderStyle Width="90px"></HeaderStyle>
                                                        </asp:ButtonColumn>
                                                        <asp:ButtonColumn ItemStyle-Width="40px" DataTextField="��Ա״̬����" SortExpression="��Ա״̬����" HeaderText="״̬" CommandName="Select">
                                                            <HeaderStyle Width="40px"></HeaderStyle>
                                                        </asp:ButtonColumn>
                                                        <asp:ButtonColumn ItemStyle-Width="40px" DataTextField="�Ƿ�ռ��" SortExpression="�Ƿ�ռ��" HeaderText="ռ��" CommandName="Select">
                                                            <HeaderStyle Width="40px"></HeaderStyle>
                                                        </asp:ButtonColumn>
                                                        
                                                        <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="�䶯ԭ������" SortExpression="�䶯ԭ������" HeaderText="�䶯ԭ��" CommandName="Select">
                                                            <HeaderStyle Width="0px"></HeaderStyle>
                                                        </asp:ButtonColumn>
                                                        <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="Ψһ��ʶ" SortExpression="Ψһ��ʶ" HeaderText="Ψһ��ʶ" CommandName="Select">
                                                            <HeaderStyle Width="0px"></HeaderStyle>
                                                        </asp:ButtonColumn>
                                                        <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="��Ա״̬" SortExpression="��Ա״̬" HeaderText="��Ա״̬����" CommandName="Select">
                                                            <HeaderStyle Width="0px"></HeaderStyle>
                                                        </asp:ButtonColumn>
                                                        <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="������λ" SortExpression="������λ" HeaderText="������λ" CommandName="Select">
                                                            <HeaderStyle Width="0px"></HeaderStyle>
                                                        </asp:ButtonColumn>
                                                        <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="ֱ�ܵ�λ" SortExpression="ֱ�ܵ�λ" HeaderText="ֱ�ܵ�λ��" CommandName="Select">
                                                            <HeaderStyle Width="0px"></HeaderStyle>
                                                        </asp:ButtonColumn>
                                                        <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="�ϼ��쵼" SortExpression="�ϼ��쵼" HeaderText="�ϼ��쵼����" CommandName="Select">
                                                            <HeaderStyle Width="0px"></HeaderStyle>
                                                        </asp:ButtonColumn>
                                                        <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="ʧЧʱ��" SortExpression="ʧЧʱ��" HeaderText="ʧЧʱ��" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd HH:mm:ss}">
                                                            <HeaderStyle Width="0px"></HeaderStyle>
                                                        </asp:ButtonColumn>
                                                        <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="�䶯ԭ��" SortExpression="�䶯ԭ��" HeaderText="�䶯ԭ�����" CommandName="Select">
                                                            <HeaderStyle Width="0px"></HeaderStyle>
                                                        </asp:ButtonColumn>
                                                        
                                                        <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="�Ŷӱ��" SortExpression="�Ŷӱ��" HeaderText="�Ŷ�" CommandName="Select">
                                                            <HeaderStyle Width="0px"></HeaderStyle>
                                                        </asp:ButtonColumn>
                                                        <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="��׼����" SortExpression="��׼����" HeaderText="��׼����" CommandName="Select">
                                                            <HeaderStyle Width="0px"></HeaderStyle>
                                                        </asp:ButtonColumn>
                                                        <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="ֱ���Ŷ�" SortExpression="ֱ���Ŷ�" HeaderText="ֱ���Ŷ�" CommandName="Select">
                                                            <HeaderStyle Width="0px"></HeaderStyle>
                                                        </asp:ButtonColumn>
                                                        <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="Э���Ŷ�" SortExpression="Э���Ŷ�" HeaderText="Э���Ŷ�" CommandName="Select">
                                                            <HeaderStyle Width="0px"></HeaderStyle>
                                                        </asp:ButtonColumn>
                                                        <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="�Ƿ��ְ" SortExpression="�Ƿ��ְ" HeaderText="��ְ" CommandName="Select">
                                                            <HeaderStyle Width="0px"></HeaderStyle>
                                                        </asp:ButtonColumn>
                                                    </Columns>
                                                    
                                                    <PagerStyle Visible="False" NextPageText="��ҳ" PrevPageText="��ҳ" HorizontalAlign="Right" ForeColor="Black" Position="TopAndBottom" BackColor="SkyBlue"></PagerStyle>
                                                </asp:datagrid><INPUT id="htxtRYFixed" type="hidden" value="0" runat="server">
                                            </DIV>
                                        </TD>
                                    </TR>
									<!-- zengxianglin 2008-10-14 -->
									<tr>
										<td class="label">
											<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
												<TR>
													<TD class="label" vAlign="baseline" align="left">��<asp:linkbutton id="lnkCZRYDeSelectAll" runat="server">��ѡ</asp:linkbutton>��</TD>
													<TD class="label" vAlign="baseline" align="left">��<asp:linkbutton id="lnkCZRYSelectAll" runat="server">ȫѡ</asp:linkbutton>��</TD>
													<TD class="label" vAlign="baseline" align="left">��<asp:linkbutton id="lnkCZRYMoveFirst" runat="server">��ǰ</asp:linkbutton>��</TD>
													<TD class="label" vAlign="baseline" align="left">��<asp:linkbutton id="lnkCZRYMovePrev" runat="server">ǰҳ</asp:linkbutton>��</TD>
													<TD class="label" vAlign="baseline" align="left">��<asp:linkbutton id="lnkCZRYMoveNext" runat="server">��ҳ</asp:linkbutton>��</TD>
													<TD class="label" vAlign="baseline" align="left">��<asp:linkbutton id="lnkCZRYMoveLast" runat="server">���</asp:linkbutton>��</TD>
													<TD class="label" vAlign="middle" align="left">��<asp:linkbutton id="lnkCZRYGotoPage" runat="server">ǰ��</asp:linkbutton>��<asp:textbox id="txtRYPageIndex" runat="server" CssClass="textbox_center" Columns="1">1</asp:textbox>ҳ</TD>
													<TD class="label" vAlign="middle" align="left">��<asp:linkbutton id="lnkCZRYSetPageSize" runat="server">ÿҳ</asp:linkbutton>��<asp:textbox id="txtRYPageSize" runat="server" CssClass="textbox_center" Columns="1">10</asp:textbox>��</TD>
													<TD class="label" vAlign="baseline" noWrap align="right"><asp:label id="lblRYGridLocInfo" runat="server" CssClass="label">1/10 N/15</asp:label></TD>
												</TR>
											</TABLE>
										</td>
									</tr>
									<!-- zengxianglin 2008-10-14 -->
                                    <tr>
                                        <td height="2"></td>
                                    </tr>
                                    <TR>
                                        <TD align="right" valign="middle">
                                            &nbsp;��Ա����&nbsp;<asp:TextBox ID="txtSearch_RY_RYDM" Runat="server" CssClass="textbox" Columns="8"></asp:TextBox>
                                            &nbsp;��Ա����&nbsp;<asp:TextBox ID="txtSearch_RY_RYMC" Runat="server" CssClass="textbox" Columns="8"></asp:TextBox>
                                            &nbsp;��λ����&nbsp;<asp:TextBox ID="txtSearch_RY_DWMC" Runat="server" CssClass="textbox" Columns="8"></asp:TextBox>
                                            &nbsp;ְ������&nbsp;<asp:TextBox ID="txtSearch_RY_ZJDM" Runat="server" CssClass="textbox" Columns="8"></asp:TextBox>
                                            <asp:Button id="btnSearch_RY" Runat="server" Text="����" CssClass="button"></asp:Button>
                                            <asp:Button id="btnSearchFull_RY" Runat="server" Text="ȫ������" CssClass="button"></asp:Button>
                                        </TD>
                                    </TR>
                                    <tr>
                                        <td height="2"></td>
                                    </tr>
                                    <TR>
                                        <TD class="title" align="left" bgcolor="#ccff99">>>>>��Ա���ʱ��Ҫ��д������</TD>
                                    </TR>
                                    <tr>
                                        <td align="center" style="BORDER-RIGHT: #99cccc 1px solid; BORDER-TOP: #99cccc 1px solid; BORDER-LEFT: #99cccc 1px solid; BORDER-BOTTOM: #99cccc 1px solid">
                                            <table cellpadding="0" cellspacing="0" border="0">
                                                <tr>
                                                    <td align="right" class="labelNotNull">���ʱ��[����]��</td>
                                                    <td align="left" colspan="5"><asp:TextBox ID="txtSXSJ" Runat="server" CssClass="textbox" Width="360px"></asp:TextBox>(�������<asp:TextBox ID="txtKSSJ" Runat="server" CssClass="textbox" Width="90px" ReadOnly="True"></asp:TextBox>)</td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="labelNotNull">�䶯ԭ��[����]��</td>
                                                    <td align="left" colspan="5"><asp:DropDownList ID="ddlYDYY" Runat="server" CssClass="textbox" Width="360px"></asp:DropDownList></td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="labelNotNull">�䶯����[����]��</td>
                                                    <td align="left" colspan="5"><asp:RadioButtonList ID="rblBDLX" Runat="server" CssClass="textbox" RepeatColumns="3" RepeatDirection="Vertical" RepeatLayout="Table"><asp:ListItem Value="0">�뿪��λ</asp:ListItem><asp:ListItem Value="1">�뿪ҵ���λ</asp:ListItem><asp:ListItem Value="2">�뿪ѡ����λ</asp:ListItem></asp:RadioButtonList></td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="2"></td>
                                    </tr>
                                    <TR>
                                        <TD class="title" align="left" bgcolor="#ccff99">>>>>��Ա���ʱ��Ӱ���ֱ������ (���� <asp:Label ID="lblRYSM_XJ" Runat="server" CssClass="label"></asp:Label> ��)</TD>
                                    </TR>
                                    <TR>
                                        <TD align="center">
                                            <DIV id="divXJ" style="BORDER-RIGHT: #99cccc 1px solid; BORDER-TOP: #99cccc 1px solid; OVERFLOW: auto; BORDER-LEFT: #99cccc 1px solid; WIDTH: 940px; CLIP: rect(0px 940px 250px 0px); BORDER-BOTTOM: #99cccc 1px solid; HEIGHT: 250px">
                                                <asp:datagrid id="grdXJ" runat="server" CssClass="label" UseAccessibleHeader="True"
                                                    AutoGenerateColumns="False" GridLines="Vertical" BackColor="White" BorderStyle="None" CellPadding="2"
                                                    AllowPaging="True" PageSize="10" BorderColor="#DEDFDE" BorderWidth="0px" AllowSorting="False" 
                                                    Width="1100px">
                                                    <SelectedItemStyle Font-Bold="False" VerticalAlign="Middle" ForeColor="#CC0000" BackColor="#FFFFDD"></SelectedItemStyle>
                                                    <EditItemStyle VerticalAlign="Middle" BackColor="#FFCC00"></EditItemStyle>
                                                    <AlternatingItemStyle BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="White"></AlternatingItemStyle>
                                                    <ItemStyle BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="#F7F7F7" ForeColor="Black"></ItemStyle>
                                                    <HeaderStyle Font-Bold="True" ForeColor="White" VerticalAlign="Middle" BackColor="#87cefa" HorizontalAlign="Left"></HeaderStyle>
                                                    <FooterStyle BackColor="#CCCC99"></FooterStyle>
                                                    
                                                    <Columns>
                                                        <asp:TemplateColumn HeaderText="ѡ" Visible="False">
                                                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                            <ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
                                                            <ItemTemplate>
                                                                <asp:CheckBox id="chkXJ" runat="server" AutoPostBack="False"></asp:CheckBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateColumn>
                                                        <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="��Ա����" SortExpression="��Ա����" HeaderText="����" CommandName="Select">
                                                            <HeaderStyle Width="0px"></HeaderStyle>
                                                        </asp:ButtonColumn>
                                                        <asp:ButtonColumn ItemStyle-Width="100px" DataTextField="��Ա����" SortExpression="��Ա����" HeaderText="��Ա����" CommandName="Select">
                                                            <HeaderStyle Width="100px"></HeaderStyle>
                                                        </asp:ButtonColumn>
                                                        <asp:ButtonColumn ItemStyle-Width="80px" DataTextField="��Ա����" SortExpression="��Ա����" HeaderText="��Ա����" CommandName="Select">
                                                            <HeaderStyle Width="80px"></HeaderStyle>
                                                        </asp:ButtonColumn>
                                                        <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="ְ������" SortExpression="ְ������" HeaderText="ְ������" CommandName="Select">
                                                            <HeaderStyle Width="0px"></HeaderStyle>
                                                        </asp:ButtonColumn>
                                                        <asp:ButtonColumn ItemStyle-Width="120px" DataTextField="ְ������" SortExpression="ְ������" HeaderText="ְ������" CommandName="Select">
                                                            <HeaderStyle Width="120px"></HeaderStyle>
                                                        </asp:ButtonColumn>
                                                        <asp:ButtonColumn ItemStyle-Width="170px" DataTextField="������λ����" SortExpression="������λ����" HeaderText="��λ����" CommandName="Select">
                                                            <HeaderStyle Width="170px"></HeaderStyle>
                                                        </asp:ButtonColumn>
														<asp:ButtonColumn ItemStyle-Width="110px" DataTextField="��������" SortExpression="��������" HeaderText="��������" CommandName="Select">
															<HeaderStyle Width="110px"></HeaderStyle>
														</asp:ButtonColumn>
                                                        <asp:ButtonColumn ItemStyle-Width="170px" DataTextField="ֱ�ܵ�λ����" SortExpression="ֱ�ܵ�λ����" HeaderText="ֱ�ܵ�λ" CommandName="Select">
                                                            <HeaderStyle Width="170px"></HeaderStyle>
                                                        </asp:ButtonColumn>
                                                        <asp:ButtonColumn ItemStyle-Width="80px" DataTextField="�ϼ��쵼����" SortExpression="�ϼ��쵼����" HeaderText="�ϼ��쵼" CommandName="Select">
                                                            <HeaderStyle Width="80px"></HeaderStyle>
                                                        </asp:ButtonColumn>
                                                        <asp:ButtonColumn ItemStyle-Width="100px" DataTextField="�䶯ԭ������" SortExpression="�䶯ԭ������" HeaderText="�䶯ԭ��" CommandName="Select">
                                                            <HeaderStyle Width="100px"></HeaderStyle>
                                                        </asp:ButtonColumn>
                                                        <asp:ButtonColumn ItemStyle-Width="90px" DataTextField="��Чʱ��" SortExpression="��Чʱ��" HeaderText="��Чʱ��" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd}">
                                                            <HeaderStyle Width="90px"></HeaderStyle>
                                                        </asp:ButtonColumn>
                                                        <asp:ButtonColumn ItemStyle-Width="40px" DataTextField="��Ա״̬����" SortExpression="��Ա״̬����" HeaderText="״̬" CommandName="Select">
                                                            <HeaderStyle Width="40px"></HeaderStyle>
                                                        </asp:ButtonColumn>
                                                        <asp:ButtonColumn ItemStyle-Width="40px" DataTextField="�Ƿ�ռ��" SortExpression="�Ƿ�ռ��" HeaderText="ռ��" CommandName="Select">
                                                            <HeaderStyle Width="40px"></HeaderStyle>
                                                        </asp:ButtonColumn>
                                                        <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="�䶯ԭ������" SortExpression="�䶯ԭ������" HeaderText="�䶯ԭ��" CommandName="Select">
                                                            <HeaderStyle Width="0px"></HeaderStyle>
                                                        </asp:ButtonColumn>
                                                        <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="Ψһ��ʶ" SortExpression="Ψһ��ʶ" HeaderText="Ψһ��ʶ" CommandName="Select">
                                                            <HeaderStyle Width="0px"></HeaderStyle>
                                                        </asp:ButtonColumn>
                                                        <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="��Ա״̬" SortExpression="��Ա״̬" HeaderText="��Ա״̬����" CommandName="Select">
                                                            <HeaderStyle Width="0px"></HeaderStyle>
                                                        </asp:ButtonColumn>
                                                        <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="������λ" SortExpression="������λ" HeaderText="������λ" CommandName="Select">
                                                            <HeaderStyle Width="0px"></HeaderStyle>
                                                        </asp:ButtonColumn>
                                                        <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="ֱ�ܵ�λ" SortExpression="ֱ�ܵ�λ" HeaderText="ֱ�ܵ�λ��" CommandName="Select">
                                                            <HeaderStyle Width="0px"></HeaderStyle>
                                                        </asp:ButtonColumn>
                                                        <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="�ϼ��쵼" SortExpression="�ϼ��쵼" HeaderText="�ϼ��쵼����" CommandName="Select">
                                                            <HeaderStyle Width="0px"></HeaderStyle>
                                                        </asp:ButtonColumn>
                                                        <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="ʧЧʱ��" SortExpression="ʧЧʱ��" HeaderText="ʧЧʱ��" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd HH:mm:ss}">
                                                            <HeaderStyle Width="0px"></HeaderStyle>
                                                        </asp:ButtonColumn>
                                                        <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="�䶯ԭ��" SortExpression="�䶯ԭ��" HeaderText="�䶯ԭ�����" CommandName="Select">
                                                            <HeaderStyle Width="0px"></HeaderStyle>
                                                        </asp:ButtonColumn>
                                                    </Columns>
                                                    
                                                    <PagerStyle Visible="False" NextPageText="��ҳ" PrevPageText="��ҳ" HorizontalAlign="Right" ForeColor="Black" Position="TopAndBottom" BackColor="SkyBlue"></PagerStyle>
                                                </asp:datagrid><INPUT id="htxtXJFixed" type="hidden" value="0" runat="server">
                                            </DIV>
                                        </TD>
                                    </TR>
									<!-- zengxianglin 2008-10-14 -->
									<tr>
										<td class="label" style="BORDER-BOTTOM: #33cccc 1px solid">
											<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
												<TR>
													<TD class="label" vAlign="baseline" align="left">��<asp:linkbutton id="lnkCZXJDeSelectAll" runat="server">��ѡ</asp:linkbutton>��</TD>
													<TD class="label" vAlign="baseline" align="left">��<asp:linkbutton id="lnkCZXJSelectAll" runat="server">ȫѡ</asp:linkbutton>��</TD>
													<TD class="label" vAlign="baseline" align="left">��<asp:linkbutton id="lnkCZXJMoveFirst" runat="server">��ǰ</asp:linkbutton>��</TD>
													<TD class="label" vAlign="baseline" align="left">��<asp:linkbutton id="lnkCZXJMovePrev" runat="server">ǰҳ</asp:linkbutton>��</TD>
													<TD class="label" vAlign="baseline" align="left">��<asp:linkbutton id="lnkCZXJMoveNext" runat="server">��ҳ</asp:linkbutton>��</TD>
													<TD class="label" vAlign="baseline" align="left">��<asp:linkbutton id="lnkCZXJMoveLast" runat="server">���</asp:linkbutton>��</TD>
													<TD class="label" vAlign="middle" align="left">��<asp:linkbutton id="lnkCZXJGotoPage" runat="server">ǰ��</asp:linkbutton>��<asp:textbox id="txtXJPageIndex" runat="server" CssClass="textbox_center" Columns="1">1</asp:textbox>ҳ</TD>
													<TD class="label" vAlign="middle" align="left">��<asp:linkbutton id="lnkCZXJSetPageSize" runat="server">ÿҳ</asp:linkbutton>��<asp:textbox id="txtXJPageSize" runat="server" CssClass="textbox_center" Columns="1">10</asp:textbox>��</TD>
													<TD class="label" vAlign="baseline" noWrap align="right"><asp:label id="lblXJGridLocInfo" runat="server" CssClass="label">1/10 N/15</asp:label></TD>
												</TR>
											</TABLE>
										</td>
									</tr>
									<!-- zengxianglin 2008-10-14 -->
									<tr>
										<td height="2"></td>
									</tr>
                                    <tr>
                                        <td align="right">
                                            <!-- zengxianglin 2008-10-14 -->
											<table cellpadding="0" cellspacing="0" border="0" width="100%">
												<tr>
													<td align="center" colspan="5"><font style="FONT-WEIGHT: bold; COLOR: red; TEXT-DECORATION: underline">���µ���Ŀ���������б��еĵ�ǰ�е���Աʵ�������д����д������סִ��&lt;&lt;д�뵱ǰ��&gt;&gt;������</font></td>
												</tr>
												<tr>
													<td class="label">���쵼<asp:TextBox ID="txtSJLD_XJ" Runat="server" CssClass="textbox" Columns="12" ReadOnly="True"></asp:TextBox><input id="htxtSJLD_XJ" runat="server" type="hidden" size="1"><asp:Button ID="btnSelectSJLD_XJ" Runat="server" CssClass="button" Text="��"></asp:Button></td>
													<td class="label">��ְ��<asp:DropDownList ID="ddlZJDM_XJ" Runat="server" CssClass="textbox"></asp:DropDownList></td>
													<td class="label">
														<asp:RadioButtonList ID="rblRYZT_XJ" Runat="server" CssClass="textbox" RepeatColumns="2" RepeatDirection="Vertical" RepeatLayout="Flow">
															<asp:ListItem Value="1">������Ա</asp:ListItem>
															<asp:ListItem Value="2" Selected="True">��ʽְ��</asp:ListItem>
														</asp:RadioButtonList>
													</td>
													<td class="label" align="right">�䶯ԭ��<asp:DropDownList ID="ddlYDYY_XJ" Runat="server" CssClass="textbox" Width="243px"></asp:DropDownList></td>
													<td><!--zengxianglin 2008-10-14 --><div style="display:none"><asp:Button id="btnSelAll_XJ" Runat="server" Text="ȫѡ" CssClass="button"></asp:Button></div></td>
												</tr>
												<tr>
													<td class="label">�²���<asp:TextBox ID="txtZZDM_XJ" Runat="server" CssClass="textbox" Columns="12" ReadOnly="True"></asp:TextBox><input id="htxtZZDM_XJ" runat="server" type="hidden" size="1"><asp:Button ID="btnSelectZZDM_XJ" Runat="server" CssClass="button" Text="��"></asp:Button></td>
													<td class="label">�·���<asp:DropDownList ID="ddlSSFZ_XJ" Runat="server" CssClass="textbox" Width="180px"></asp:DropDownList><asp:Button ID="btnJSFZLB_XJ" Runat="server" CssClass="button" Text="��"></asp:Button></td>
													<td class="label">
														<asp:RadioButtonList ID="rblSFZB_XJ" Runat="server" CssClass="textbox" RepeatColumns="2" RepeatDirection="Vertical" RepeatLayout="Flow">
															<asp:ListItem Value="0">������Ա</asp:ListItem>
															<asp:ListItem Value="1" Selected="True">������Ա</asp:ListItem>
														</asp:RadioButtonList>
													</td>
													<td class="label" align="right">ֱ�ܵ�λ<asp:TextBox ID="txtZGDW_XJ" Runat="server" CssClass="textbox" ReadOnly="True" Width="220px"></asp:TextBox><input id="htxtZGDW_XJ" runat="server" type="hidden" size="1" NAME="htxtZGDW"><asp:Button ID="btnSelectZGDW_XJ" Runat="server" CssClass="button" Text="��"></asp:Button></td>
													<td><!--zengxianglin 2008-10-14 --><div style="display:none"><asp:Button id="btnDeSelAll_XJ" Runat="server" Text="��ѡ" CssClass="button"></asp:Button></div></td>
												</tr>
												<tr>
													<td colspan="5" align="right"><asp:Button ID="btnSaveSJLD_XJ" Runat="server" CssClass="button" Text="д�뵱ǰ��"></asp:Button>&nbsp;&nbsp;<asp:Button ID="btnGetSJLD_XJ" Runat="server" CssClass="button" Text="��ʾ��ǰ��"></asp:Button></td>
												</tr>
											</table>
                                            <!-- zengxianglin 2008-10-14 -->
                                        </td>
                                    </tr>
                                </TABLE>
                            </DIV>
                        </TD>
                    </TR>
                    <tr>
                        <td height="2"></td>
                    </tr>
                    <TR id="trRow2">
                        <TD style="BORDER-TOP: #99cccc 2px solid" vAlign="middle" align="center" height="36">
							<!-- zengxianglin 2008-10-14-->
							<!--<asp:Button id="btnViewJG" Runat="server" CssClass="button" Text=" ��Ա�ܹ� " Height="32px"></asp:Button>-->
							<input id="btnViewJG" type="button" class="button" value=" ��Ա�ܹ� " style="HEIGHT: 32px" onclick="onclick_btnViewJG()">
							<!-- zengxianglin 2008-10-14-->
                            <asp:Button id="btnOK" Runat="server" Text=" ȷ  �� " CssClass="button" Height="32px"></asp:Button>
                            <asp:Button id="btnCancel" Runat="server" Text=" ȡ  �� " CssClass="button" Height="32px"></asp:Button>
                        </TD>
                    </TR>
                </TABLE>
            </asp:panel>
            <asp:Panel id="panelError" Runat="server">
                <TABLE height="98%" cellSpacing="0" cellPadding="0" width="100%" border="0">
                    <TR>
                        <TD width="5%"></TD>
                        <TD>
                            <TABLE height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
                                <TR>
                                    <TD>&nbsp;&nbsp;&nbsp;&nbsp;</TD>
                                    <TD style="FONT-SIZE: 32pt; COLOR: black; LINE-HEIGHT: 40pt; FONT-FAMILY: ����; LETTER-SPACING: 2pt" align="center"><asp:Label id="lblMessage" Runat="server"></asp:Label><P>&nbsp;&nbsp;</P><P><asp:Button ID="btnGoBack" Runat="server" Font-Size="24pt" Text=" ���� "></asp:Button></P></TD>
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
						<!-- zengxianglin 2008-11-22 -->
						<input id="htxtBDYY_RYJS" type="hidden" runat="server" NAME="htxtBDYY_RYJS" value="002">
						<input id="htxtBDYY_NBTZ" type="hidden" runat="server" NAME="htxtBDYY_NBTZ" value="003">
						<!-- zengxianglin 2008-11-22 -->
						<!-- zengxianglin 2008-10-14 -->
						<input id="htxtRYRows" type="hidden" runat="server">
						<input id="htxtXJRows" type="hidden" runat="server">
						<!-- zengxianglin 2008-10-14 -->
                        <input id="htxtSessionIdQuery_RY" type="hidden" runat="server">
                        <input id="htxtSessionId_XJ" type="hidden" runat="server">
						<input id="htxtQuery_RY" type="hidden" runat="server">
                        <input id="htxtDivLeftXJ" type="hidden" runat="server">
                        <input id="htxtDivTopXJ" type="hidden" runat="server">
                        <input id="htxtDivLeftRY" type="hidden" runat="server">
                        <input id="htxtDivTopRY" type="hidden" runat="server">
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
							function ScrollProc_divRY() {
								var oText;
								oText=null;
								oText=document.getElementById("htxtDivTopRY");
								if (oText != null) oText.value = divRY.scrollTop;
								oText=null;
								oText=document.getElementById("htxtDivLeftRY");
								if (oText != null) oText.value = divRY.scrollLeft;
								return;
							}
							function ScrollProc_divXJ() {
								var oText;
								oText=null;
								oText=document.getElementById("htxtDivTopXJ");
								if (oText != null) oText.value = divXJ.scrollTop;
								oText=null;
								oText=document.getElementById("htxtDivLeftXJ");
								if (oText != null) oText.value = divXJ.scrollLeft;
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
								oText=document.getElementById("htxtDivTopRY");
								if (oText != null) divRY.scrollTop = oText.value;
								oText=null;
								oText=document.getElementById("htxtDivLeftRY");
								if (oText != null) divRY.scrollLeft = oText.value;

								oText=null;
								oText=document.getElementById("htxtDivTopXJ");
								if (oText != null) divXJ.scrollTop = oText.value;
								oText=null;
								oText=document.getElementById("htxtDivLeftXJ");
								if (oText != null) divXJ.scrollLeft = oText.value;

								document.body.onscroll = ScrollProc_Body;
								divMain.onscroll = ScrollProc_divMain;
								divRY.onscroll = ScrollProc_divRY;
								divXJ.onscroll = ScrollProc_divXJ;
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
