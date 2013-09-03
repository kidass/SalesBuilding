<%@ Page Language="vb" AutoEventWireup="false" Codebehind="estate_cw_sztz.aspx.vb" Inherits="Josco.JSOA.web.estate_cw_sztz" %>
<%@ Register TagPrefix="uwin" Namespace="Josco.Web" Assembly="Josco.Web.PopMessage" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
    <HEAD>
        <title>��ͬ��̨֧�ʴ���</title>
        <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
        <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
        <meta content="JavaScript" name="vs_defaultClientScript">
        <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <LINK href="../../../styles01.css" type="text/css" rel="stylesheet">
        <style>
		    TD.grdZJFLocked { ; LEFT: expression(divZJF.scrollLeft); POSITION: relative }
		    TH.grdZJFLocked { ; LEFT: expression(divZJF.scrollLeft); POSITION: relative }
		    TH.grdZJFLocked { Z-INDEX: 99 }
		    TD.grdFKLocked { ; LEFT: expression(divFK.scrollLeft); POSITION: relative }
		    TH.grdFKLocked { ; LEFT: expression(divFK.scrollLeft); POSITION: relative }
		    TH.grdFKLocked { Z-INDEX: 99 }
		    TD.grdQTFYLocked { ; LEFT: expression(divQTFY.scrollLeft); POSITION: relative }
		    TH.grdQTFYLocked { ; LEFT: expression(divQTFY.scrollLeft); POSITION: relative }
		    TH.grdQTFYLocked { Z-INDEX: 99 }
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
				
				if (document.all("divMain") == null)
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
				strHeight  = intHeight.toString() + "px";

				divMain.style.width  = strWidth;
				divMain.style.height = strHeight;
				divMain.style.clip = "rect(0px " + strWidth + " " + strHeight + " 0px)";

				divFK.style.width = (intWidth - 24).toString() + "px";
				divZJF.style.width = (intWidth - 24).toString() + "px";
				divQTFY.style.width = (intWidth - 24).toString() + "px";
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
        <form id="frmestate_cw_sztz" method="post" runat="server">
            <asp:panel id="panelMain" Runat="server">
                <TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
                    <TR>
                        <TD width="5"></TD>
                        <TD vAlign="top" align="center">
                            <TABLE cellSpacing="0" cellPadding="0" border="0">
                                <TR id="trRow01">
                                    <TD class="title" align="center" colSpan="3" height="30">��ͬ��̨֧��<asp:LinkButton id="lnkBlank" Runat="server" Width="0px"></asp:LinkButton></TD>
                                </TR>
                                <TR>
                                    <TD width="5"></TD>
                                    <TD vAlign="top">
                                        <DIV id="divMain" style="BORDER-TOP: #99cccc 2px solid; OVERFLOW: auto; WIDTH: 964px; CLIP: rect(0px 964px 456px 0px); BORDER-BOTTOM: #99cccc 2px solid; HEIGHT: 456px">
                                            <TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
                                                <TR>
                                                    <TD><% if propQRSH() <> "" then response.write("<div style='display:none'>") %>
                                                        <TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
                                                            <TR>
                                                                <TD class="label" align="left" bgColor="#ccff99" colSpan="3"><B>&gt;&gt;&gt;&gt;ָ��ҵ����</B></TD>
                                                            </TR>
                                                            <TR>
                                                                <TD class="labelNotNull" noWrap align="right">ҵ���ţ�</TD>
                                                                <TD align="left" width="90%">
                                                                    <asp:TextBox id="txtJYBH" Runat="server" Width="100%" ReadOnly="True" CssClass="textbox"></asp:TextBox></TD>
                                                                <TD align="left">
                                                                    <asp:Button id="btnSelect_JYBH" Runat="server" CssClass="button" Text="��"></asp:Button></TD>
                                                            </TR>
                                                        </TABLE>
                                                        <% if propQRSH() <> "" then response.write("</div>") %>
                                                    </TD>
                                                </TR>
                                                <TR>
                                                    <TD>
                                                        <TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
                                                            <TR>
                                                                <TD class="label" align="left" bgColor="#ccff99"><B>&gt;&gt;&gt;&gt;������Ϣ</B></TD>
                                                            </TR>
                                                            <TR>
                                                                <TD>
                                                                    <TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
                                                                        <TR>
                                                                            <TD class="label" noWrap align="right">&nbsp;&nbsp;���ױ�ţ�&nbsp;&nbsp;</TD>
                                                                            <TD style="BORDER-BOTTOM: #99cccc 1px solid" noWrap align="left" width="15%">&nbsp;<asp:Label id="lblJYBH" Runat="server" CssClass="label"></asp:Label>&nbsp;</TD>
                                                                            <TD class="label" noWrap align="right">&nbsp;&nbsp;�������ڣ�&nbsp;&nbsp;</TD>
                                                                            <TD style="BORDER-BOTTOM: #99cccc 1px solid" noWrap align="left" width="15%">&nbsp;<asp:Label id="lblJYRQ" Runat="server" CssClass="label"></asp:Label>&nbsp;</TD>
                                                                            <TD class="label" noWrap align="right">&nbsp;&nbsp;�׷����ƣ�&nbsp;&nbsp;</TD>
                                                                            <TD style="BORDER-BOTTOM: #99cccc 1px solid" noWrap align="left" width="18%">&nbsp;<asp:Label id="lblJFMC" Runat="server" CssClass="label"></asp:Label>&nbsp;</TD>
                                                                            <TD class="label" noWrap align="right">&nbsp;&nbsp;���׼۸�(Ԫ)��&nbsp;&nbsp;</TD>
                                                                            <TD style="BORDER-BOTTOM: #99cccc 1px solid" noWrap align="right" width="15%">&nbsp;<asp:Label id="lblJYJG" Runat="server" CssClass="label"></asp:Label>&nbsp;</TD>
                                                                            <TD class="label" noWrap align="right">&nbsp;&nbsp;�׷������(Ԫ)��&nbsp;&nbsp;</TD>
                                                                            <TD style="BORDER-BOTTOM: #99cccc 1px solid" noWrap align="right" width="15%">&nbsp;<asp:Label id="lblJFDLF" Runat="server" CssClass="label"></asp:Label>&nbsp;</TD>
                                                                        </TR>
                                                                        <TR>
                                                                            <TD class="label" noWrap align="right">&nbsp;&nbsp;��ͬ��ţ�&nbsp;&nbsp;</TD>
                                                                            <TD style="BORDER-BOTTOM: #99cccc 1px solid" noWrap align="left">&nbsp;<asp:Label id="lblHTBH" Runat="server" CssClass="label"></asp:Label>&nbsp;</TD>
                                                                            <TD class="label" noWrap align="right">&nbsp;&nbsp;��ͬ���ڣ�&nbsp;&nbsp;</TD>
                                                                            <TD style="BORDER-BOTTOM: #99cccc 1px solid" noWrap align="left">&nbsp;<asp:Label id="lblHTRQ" Runat="server" CssClass="label"></asp:Label>&nbsp;</TD>
                                                                            <TD class="label" noWrap align="right">&nbsp;&nbsp;�ҷ����ƣ�&nbsp;&nbsp;</TD>
                                                                            <TD style="BORDER-BOTTOM: #99cccc 1px solid" noWrap align="left">&nbsp;<asp:Label id="lblYFMC" Runat="server" CssClass="label"></asp:Label>&nbsp;</TD>
                                                                            <TD class="label" noWrap align="right">&nbsp;&nbsp;�������(�O)��&nbsp;&nbsp;</TD>
                                                                            <TD style="BORDER-BOTTOM: #99cccc 1px solid" noWrap align="right">&nbsp;<asp:Label id="lblJYMJ" Runat="server" CssClass="label"></asp:Label>&nbsp;</TD>
                                                                            <TD class="label" noWrap align="right">&nbsp;&nbsp;�ҷ������(Ԫ)��&nbsp;&nbsp;</TD>
                                                                            <TD style="BORDER-BOTTOM: #99cccc 1px solid" noWrap align="right">&nbsp;<asp:Label id="lblYFDLF" Runat="server" CssClass="label"></asp:Label>&nbsp;</TD>
                                                                        </TR>
                                                                        <TR>
                                                                            <TD class="label" noWrap align="right">&nbsp;&nbsp;��ҵ��ַ��&nbsp;&nbsp;</TD>
                                                                            <TD style="BORDER-BOTTOM: #99cccc 1px solid" noWrap align="left" colSpan="9">&nbsp;<asp:Label id="lblWYDZ" Runat="server" CssClass="label"></asp:Label>&nbsp;</TD>
                                                                        </TR>
                                                                    </TABLE>
                                                                </TD>
                                                            </TR>
                                                        </TABLE>
                                                    </TD>
                                                </TR>
                                                <TR>
                                                    <TD>
                                                        <TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
                                                            <TR>
                                                                <TD class="label" align="left">
                                                                    <TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
                                                                        <TR>
                                                                            <TD class="label" align="left" bgColor="#ccff99" colspan="18"><B>&gt;&gt;&gt;&gt;�н��������֧�����</B></TD>
                                                                        </TR>
                                                                        <TR>
                                                                            <TD class="label" align="right" nowrap>����</td>
                                                                            <td align="left"><asp:TextBox id="txtZJF_JF_SR" Runat="server" ReadOnly="True" CssClass="textbox" Columns="7"></asp:TextBox></td>
                                                                            <TD class="label" align="right" nowrap>�׸�</td>
                                                                            <td align="left"><asp:TextBox id="txtZJF_JF_ZC" Runat="server" ReadOnly="True" CssClass="textbox" Columns="7"></asp:TextBox></td>
                                                                            <TD class="label" align="right" nowrap>�����</td>
                                                                            <td align="left"><asp:TextBox id="txtZJF_JF_YE" Runat="server" ReadOnly="True" CssClass="textbox" Columns="7"></asp:TextBox></td>
                                                                            <TD class="label" align="right" nowrap>����</td>
                                                                            <td align="left"><asp:TextBox id="txtZJF_YF_SR" Runat="server" ReadOnly="True" CssClass="textbox" Columns="7"></asp:TextBox></td>
                                                                            <TD class="label" align="right" nowrap>�Ҹ�</td>
                                                                            <td align="left"><asp:TextBox id="txtZJF_YF_ZC" Runat="server" ReadOnly="True" CssClass="textbox" Columns="7"></asp:TextBox></td>
                                                                            <TD class="label" align="right" nowrap>�����</td>
                                                                            <td align="left"><asp:TextBox id="txtZJF_YF_YE" Runat="server" ReadOnly="True" CssClass="textbox" Columns="7"></asp:TextBox></td>
                                                                            <TD class="label" align="right" nowrap>����</td>
                                                                            <td align="left"><asp:TextBox id="txtZJF_HT_SR" Runat="server" ReadOnly="True" CssClass="textbox" Columns="7"></asp:TextBox></td>
                                                                            <TD class="label" align="right" nowrap>�ܸ�</td>
                                                                            <td align="left"><asp:TextBox id="txtZJF_HT_ZC" Runat="server" ReadOnly="True" CssClass="textbox" Columns="7"></asp:TextBox></td>
                                                                            <TD class="label" align="right" nowrap>���</td>
                                                                            <td align="left"><asp:TextBox id="txtZJF_HT_YE" Runat="server" ReadOnly="True" CssClass="textbox" Columns="7"></asp:TextBox></td>
                                                                        </TR>
                                                                        <TR>
                                                                            <TD align="center" colspan="18">
                                                                                <DIV id="divZJF" style="BORDER-RIGHT: #99cccc 1px solid; TABLE-LAYOUT: fixed; BORDER-TOP: #99cccc 1px solid; OVERFLOW: auto; BORDER-LEFT: #99cccc 1px solid; WIDTH: 924px; CLIP: rect(0px 924px 160px 0px); BORDER-BOTTOM: #99cccc 1px solid; HEIGHT: 160px">
                                                                                    <asp:datagrid id="grdZJF" runat="server" CssClass="label" UseAccessibleHeader="True" AllowPaging="False"
                                                                                        AutoGenerateColumns="False" GridLines="Vertical" BorderStyle="None" PageSize="30" BorderColor="#DEDFDE"
                                                                                        BorderWidth="0px" AllowSorting="True" CellPadding="4" Font-Names="����">
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
                                                                                                    <asp:CheckBox id="chkZJF" runat="server" AutoPostBack="False"></asp:CheckBox>
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
                                                                                            <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="�������" SortExpression="�������" HeaderText="���(Ԫ)" CommandName="Select" DataTextFormatString="{0:#,###.00}" ItemStyle-HorizontalAlign="Right">
                                                                                                <HeaderStyle Width="0px" HorizontalAlign="Right"></HeaderStyle>
                                                                                            </asp:ButtonColumn>
                                                                                            <asp:ButtonColumn ItemStyle-Width="50px" DataTextField="�Ƿ����" SortExpression="�Ƿ����" HeaderText="��Ч" CommandName="Select">
                                                                                                <HeaderStyle Width="50px"></HeaderStyle>
                                                                                            </asp:ButtonColumn>
                                                                                            <asp:ButtonColumn ItemStyle-Width="50px" DataTextField="��˱�־����" SortExpression="��˱�־����" HeaderText="���" CommandName="Select">
                                                                                                <HeaderStyle Width="50px"></HeaderStyle>
                                                                                            </asp:ButtonColumn>
                                                                                            <asp:ButtonColumn ItemStyle-Width="140px" DataTextField="˰������" SortExpression="˰������" HeaderText="˰��" CommandName="Select">
                                                                                                <HeaderStyle Width="140px"></HeaderStyle>
                                                                                            </asp:ButtonColumn>
                                                                                            <asp:ButtonColumn ItemStyle-Width="160px" DataTextField="���������" SortExpression="���������" HeaderText="��(Ԫ)" CommandName="Select" DataTextFormatString="{0:#,###.00}" ItemStyle-HorizontalAlign="Right">
                                                                                                <HeaderStyle Width="160px" HorizontalAlign="Right"></HeaderStyle>
                                                                                            </asp:ButtonColumn>
                                                                                            <asp:ButtonColumn ItemStyle-Width="160px" DataTextField="������" SortExpression="������" HeaderText="��(Ԫ)" CommandName="Select" DataTextFormatString="{0:#,###.00}" ItemStyle-HorizontalAlign="Right">
                                                                                                <HeaderStyle Width="160px" HorizontalAlign="Right"></HeaderStyle>
                                                                                            </asp:ButtonColumn>
                                                                                            <asp:ButtonColumn ItemStyle-Width="300px" DataTextField="ժҪ˵��" SortExpression="ժҪ˵��" HeaderText="ժҪ" CommandName="Select">
                                                                                                <HeaderStyle Width="300px"></HeaderStyle>
                                                                                            </asp:ButtonColumn>
                                                                                            <asp:ButtonColumn ItemStyle-Width="140px" DataTextField="��������" SortExpression="��������" HeaderText="����" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd}">
                                                                                                <HeaderStyle Width="140px"></HeaderStyle>
                                                                                            </asp:ButtonColumn>
                                                                                            <asp:ButtonColumn ItemStyle-Width="60px" DataTextField="�ո�����" SortExpression="�ո�����" HeaderText="����" CommandName="Select">
                                                                                                <HeaderStyle Width="60px"></HeaderStyle>
                                                                                            </asp:ButtonColumn>
                                                                                            <asp:ButtonColumn ItemStyle-Width="120px" DataTextField="�ͻ�����" SortExpression="�ͻ�����" HeaderText="�ͻ�" CommandName="Select">
                                                                                                <HeaderStyle Width="120px"></HeaderStyle>
                                                                                            </asp:ButtonColumn>
                                                                                            <asp:ButtonColumn ItemStyle-Width="180px" DataTextField="Ʊ�ݺ���" SortExpression="Ʊ�ݺ���" HeaderText="Ʊ�ݺ�" CommandName="Select">
                                                                                                <HeaderStyle Width="180px"></HeaderStyle>
                                                                                            </asp:ButtonColumn>
                                                                                            <asp:ButtonColumn ItemStyle-Width="120px" DataTextField="������Ա����" SortExpression="������Ա����" HeaderText="������" CommandName="Select">
                                                                                                <HeaderStyle Width="120px"></HeaderStyle>
                                                                                            </asp:ButtonColumn>
                                                                                            <asp:ButtonColumn ItemStyle-Width="220px" DataTextField="�����������" SortExpression="�����������" HeaderText="���쵥λ" CommandName="Select">
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
                                                                                    </asp:datagrid><INPUT id="htxtZJFFixed" type="hidden" value="0" runat="server">
                                                                                </DIV>
                                                                            </TD>
                                                                        </TR>
                                                                    </TABLE>
                                                                </TD>
                                                            </TR>
                                                        </TABLE>
                                                    </TD>
                                                </TR>
                                                <TR>
                                                    <TD>
                                                        <TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
                                                            <TR>
                                                                <TD class="label" align="left">
                                                                    <TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
                                                                        <TR>
                                                                            <TD class="label" align="left" bgColor="#ccff99" colspan="18"><B>&gt;&gt;&gt;&gt;����������֧�����</B></TD>
                                                                        </TR>
                                                                        <tr>
                                                                            <TD class="label" align="right" nowrap>����</td>
                                                                            <td align="left"><asp:TextBox id="txtFK_JF_SR" Runat="server" ReadOnly="True" CssClass="textbox" Columns="7"></asp:TextBox></td>
                                                                            <TD class="label" align="right" nowrap>�׸�</td>
                                                                            <td align="left"><asp:TextBox id="txtFK_JF_ZC" Runat="server" ReadOnly="True" CssClass="textbox" Columns="7"></asp:TextBox></td>
                                                                            <TD class="label" align="right" nowrap>�����</td>
                                                                            <td align="left"><asp:TextBox id="txtFK_JF_YE" Runat="server" ReadOnly="True" CssClass="textbox" Columns="7"></asp:TextBox></td>
                                                                            <TD class="label" align="right" nowrap>����</td>
                                                                            <td align="left"><asp:TextBox id="txtFK_YF_SR" Runat="server" ReadOnly="True" CssClass="textbox" Columns="7"></asp:TextBox></td>
                                                                            <TD class="label" align="right" nowrap>�Ҹ�</td>
                                                                            <td align="left"><asp:TextBox id="txtFK_YF_ZC" Runat="server" ReadOnly="True" CssClass="textbox" Columns="7"></asp:TextBox></td>
                                                                            <TD class="label" align="right" nowrap>�����</td>
                                                                            <td align="left"><asp:TextBox id="txtFK_YF_YE" Runat="server" ReadOnly="True" CssClass="textbox" Columns="7"></asp:TextBox></td>
                                                                            <TD class="label" align="right" nowrap>����</td>
                                                                            <td align="left"><asp:TextBox id="txtFK_HT_SR" Runat="server" ReadOnly="True" CssClass="textbox" Columns="7"></asp:TextBox></td>
                                                                            <TD class="label" align="right" nowrap>�ܸ�</td>
                                                                            <td align="left"><asp:TextBox id="txtFK_HT_ZC" Runat="server" ReadOnly="True" CssClass="textbox" Columns="7"></asp:TextBox></td>
                                                                            <TD class="label" align="right" nowrap>���</td>
                                                                            <td align="left"><asp:TextBox id="txtFK_HT_YE" Runat="server" ReadOnly="True" CssClass="textbox" Columns="7"></asp:TextBox></td>
                                                                        </tr>
                                                                        <TR>
                                                                            <TD align="center" colspan="18">
                                                                                <DIV id="divFK" style="BORDER-RIGHT: #99cccc 1px solid; TABLE-LAYOUT: fixed; BORDER-TOP: #99cccc 1px solid; OVERFLOW: auto; BORDER-LEFT: #99cccc 1px solid; WIDTH: 924px; CLIP: rect(0px 924px 160px 0px); BORDER-BOTTOM: #99cccc 1px solid; HEIGHT: 160px">
                                                                                    <asp:datagrid id="grdFK" runat="server" CssClass="label" UseAccessibleHeader="True" AllowPaging="False"
                                                                                        AutoGenerateColumns="False" GridLines="Vertical" BorderStyle="None" PageSize="30" BorderColor="#DEDFDE"
                                                                                        BorderWidth="0px" AllowSorting="True" CellPadding="4" Font-Names="����">
                                                                                        <SelectedItemStyle Font-Size="12px" Font-Names="����" Font-Bold="False" VerticalAlign="Middle" ForeColor="#CC0000" BackColor="#FFFFDD"></SelectedItemStyle>
                                                                                        <EditItemStyle Font-Size="12px" Font-Names="����" VerticalAlign="Middle" BackColor="#FFCC00"></EditItemStyle>
                                                                                        <AlternatingItemStyle Font-Size="12px" Font-Names="����" BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="White"></AlternatingItemStyle>
                                                                                        <ItemStyle Font-Size="12px" Font-Names="����" BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="#F7F7F7" ForeColor="Black"></ItemStyle>
                                                                                        <HeaderStyle Font-Size="12px" Font-Names="����" Font-Bold="True" ForeColor="White" VerticalAlign="Middle" BackColor="#6699cc" HorizontalAlign="Left"></HeaderStyle>
                                                                                        <FooterStyle BackColor="#CCCC99"></FooterStyle>
                                                                                        <Columns>
                                                                                            <asp:TemplateColumn HeaderText="ѡ">
                                                                                                <HeaderStyle HorizontalAlign="Center" Width="20px"></HeaderStyle>
                                                                                                <ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
                                                                                                <ItemTemplate>
                                                                                                    <asp:CheckBox id="chkFK" runat="server" AutoPostBack="False"></asp:CheckBox>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateColumn>
                                                                                            
                                                                                            <asp:ButtonColumn Visible="False" DataTextField="Ψһ��ʶ" SortExpression="Ψһ��ʶ" HeaderText="Ψһ��ʶ" CommandName="Select">
                                                                                                <HeaderStyle Width="0px"></HeaderStyle>
                                                                                            </asp:ButtonColumn>
                                                                                            <asp:ButtonColumn Visible="False" DataTextField="ȷ�����" SortExpression="ȷ�����" HeaderText="ȷ�����" CommandName="Select">
                                                                                                <HeaderStyle Width="0px"></HeaderStyle>
                                                                                            </asp:ButtonColumn>
                                                                                            <asp:ButtonColumn Visible="False" DataTextField="˰�Ѵ���" SortExpression="˰�Ѵ���" HeaderText="˰�Ѵ���" CommandName="Select">
                                                                                                <HeaderStyle Width="0px"></HeaderStyle>
                                                                                            </asp:ButtonColumn>
                                                                                            <asp:ButtonColumn Visible="False" DataTextField="�ո���־" SortExpression="�ո���־" HeaderText="�ո�" CommandName="Select">
                                                                                                <HeaderStyle Width="0px"></HeaderStyle>
                                                                                            </asp:ButtonColumn>
                                                                                            <asp:ButtonColumn Visible="False" DataTextField="�������" SortExpression="�������" HeaderText="���(Ԫ)" CommandName="Select" DataTextFormatString="{0:#,###.00}" ItemStyle-HorizontalAlign="Right">
                                                                                                <HeaderStyle Width="0px" HorizontalAlign="Right"></HeaderStyle>
                                                                                            </asp:ButtonColumn>
                                                                                            <asp:ButtonColumn DataTextField="�Ƿ����" SortExpression="�Ƿ����" HeaderText="��Ч" CommandName="Select">
                                                                                                <HeaderStyle Width="50px"></HeaderStyle>
                                                                                            </asp:ButtonColumn>
                                                                                            <asp:ButtonColumn DataTextField="��˱�־����" SortExpression="��˱�־����" HeaderText="���" CommandName="Select">
                                                                                                <HeaderStyle Width="50px"></HeaderStyle>
                                                                                            </asp:ButtonColumn>
                                                                                            <asp:ButtonColumn DataTextField="˰������" SortExpression="˰������" HeaderText="˰��" CommandName="Select">
                                                                                                <HeaderStyle Width="140px"></HeaderStyle>
                                                                                            </asp:ButtonColumn>
                                                                                            <asp:ButtonColumn DataTextField="���������" SortExpression="���������" HeaderText="��(Ԫ)" CommandName="Select" DataTextFormatString="{0:#,###.00}" ItemStyle-HorizontalAlign="Right">
                                                                                                <HeaderStyle Width="160px" HorizontalAlign="Right"></HeaderStyle>
                                                                                            </asp:ButtonColumn>
                                                                                            <asp:ButtonColumn DataTextField="������" SortExpression="������" HeaderText="��(Ԫ)" CommandName="Select" DataTextFormatString="{0:#,###.00}" ItemStyle-HorizontalAlign="Right">
                                                                                                <HeaderStyle Width="160px" HorizontalAlign="Right"></HeaderStyle>
                                                                                            </asp:ButtonColumn>
                                                                                            <asp:ButtonColumn DataTextField="ժҪ˵��" SortExpression="ժҪ˵��" HeaderText="ժҪ" CommandName="Select">
                                                                                                <HeaderStyle Width="300px"></HeaderStyle>
                                                                                            </asp:ButtonColumn>
                                                                                            <asp:ButtonColumn DataTextField="��������" SortExpression="��������" HeaderText="����" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd}">
                                                                                                <HeaderStyle Width="140px"></HeaderStyle>
                                                                                            </asp:ButtonColumn>
                                                                                            <asp:ButtonColumn DataTextField="�ո�����" SortExpression="�ո�����" HeaderText="����" CommandName="Select">
                                                                                                <HeaderStyle Width="60px"></HeaderStyle>
                                                                                            </asp:ButtonColumn>
                                                                                            <asp:ButtonColumn DataTextField="�ͻ�����" SortExpression="�ͻ�����" HeaderText="�ͻ�" CommandName="Select">
                                                                                                <HeaderStyle Width="120px"></HeaderStyle>
                                                                                            </asp:ButtonColumn>
                                                                                            <asp:ButtonColumn DataTextField="Ʊ�ݺ���" SortExpression="Ʊ�ݺ���" HeaderText="Ʊ�ݺ�" CommandName="Select">
                                                                                                <HeaderStyle Width="180px"></HeaderStyle>
                                                                                            </asp:ButtonColumn>
                                                                                            <asp:ButtonColumn DataTextField="������Ա����" SortExpression="������Ա����" HeaderText="������" CommandName="Select">
                                                                                                <HeaderStyle Width="120px"></HeaderStyle>
                                                                                            </asp:ButtonColumn>
                                                                                            <asp:ButtonColumn DataTextField="�����������" SortExpression="�����������" HeaderText="���쵥λ" CommandName="Select">
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
                                                                                            <asp:ButtonColumn Visible="False" DataTextField="�����������" SortExpression="�����������" HeaderText="�������" CommandName="Select">
                                                                                                <HeaderStyle Width="0px"></HeaderStyle>
                                                                                            </asp:ButtonColumn>
                                                                                            <asp:ButtonColumn Visible="False" DataTextField="�������" SortExpression="�������" HeaderText="�������" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd}">
                                                                                                <HeaderStyle Width="0px"></HeaderStyle>
                                                                                            </asp:ButtonColumn>
                                                                                            <asp:ButtonColumn Visible="False" DataTextField="��˱�־" SortExpression="��˱�־" HeaderText="��˱�־" CommandName="Select">
                                                                                                <HeaderStyle Width="0px"></HeaderStyle>
                                                                                            </asp:ButtonColumn>
                                                                                            <asp:ButtonColumn Visible="False" DataTextField="�ƻ���ʶ" SortExpression="�ƻ���ʶ" HeaderText="�ƻ���ʶ" CommandName="Select">
                                                                                                <HeaderStyle Width="0px"></HeaderStyle>
                                                                                            </asp:ButtonColumn>
                                                                                        </Columns>
                                                                                        <PagerStyle Visible="False" NextPageText="��ҳ" Font-Size="12px" Font-Names="����" PrevPageText="��ҳ" HorizontalAlign="Right" ForeColor="Black" Position="TopAndBottom" BackColor="SkyBlue"></PagerStyle>
                                                                                    </asp:datagrid><INPUT id="htxtFKFixed" type="hidden" value="0" runat="server">
                                                                                </DIV>
                                                                            </TD>
                                                                        </TR>
                                                                    </TABLE>
                                                                </TD>
                                                            </TR>
                                                        </TABLE>
                                                    </TD>
                                                </TR>
                                                <TR>
                                                    <TD>
                                                        <TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
                                                            <TR>
                                                                <TD class="label" align="left">
                                                                    <TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
                                                                        <TR>
                                                                            <TD class="label" align="left" bgColor="#ccff99" colspan="18"><B>&gt;&gt;&gt;&gt;��������������֧�����</B></TD>
                                                                        </TR>
                                                                        <tr>
                                                                            <TD class="label" align="right" nowrap>����</td>
                                                                            <td align="left"><asp:TextBox id="txtQTFY_JF_SR" Runat="server" ReadOnly="True" CssClass="textbox" Columns="7"></asp:TextBox></td>
                                                                            <TD class="label" align="right" nowrap>�׸�</td>
                                                                            <td align="left"><asp:TextBox id="txtQTFY_JF_ZC" Runat="server" ReadOnly="True" CssClass="textbox" Columns="7"></asp:TextBox></td>
                                                                            <TD class="label" align="right" nowrap>�����</td>
                                                                            <td align="left"><asp:TextBox id="txtQTFY_JF_YE" Runat="server" ReadOnly="True" CssClass="textbox" Columns="7"></asp:TextBox></td>
                                                                            <TD class="label" align="right" nowrap>����</td>
                                                                            <td align="left"><asp:TextBox id="txtQTFY_YF_SR" Runat="server" ReadOnly="True" CssClass="textbox" Columns="7"></asp:TextBox></td>
                                                                            <TD class="label" align="right" nowrap>�Ҹ�</td>
                                                                            <td align="left"><asp:TextBox id="txtQTFY_YF_ZC" Runat="server" ReadOnly="True" CssClass="textbox" Columns="7"></asp:TextBox></td>
                                                                            <TD class="label" align="right" nowrap>�����</td>
                                                                            <td align="left"><asp:TextBox id="txtQTFY_YF_YE" Runat="server" ReadOnly="True" CssClass="textbox" Columns="7"></asp:TextBox></td>
                                                                            <TD class="label" align="right" nowrap>����</td>
                                                                            <td align="left"><asp:TextBox id="txtQTFY_HT_SR" Runat="server" ReadOnly="True" CssClass="textbox" Columns="7"></asp:TextBox></td>
                                                                            <TD class="label" align="right" nowrap>�ܸ�</td>
                                                                            <td align="left"><asp:TextBox id="txtQTFY_HT_ZC" Runat="server" ReadOnly="True" CssClass="textbox" Columns="7"></asp:TextBox></td>
                                                                            <TD class="label" align="right" nowrap>���</td>
                                                                            <td align="left"><asp:TextBox id="txtQTFY_HT_YE" Runat="server" ReadOnly="True" CssClass="textbox" Columns="7"></asp:TextBox></td>
                                                                        </tr>
                                                                        <TR>
                                                                            <TD align="center" colspan="18">
                                                                                <DIV id="divQTFY" style="BORDER-RIGHT: #99cccc 1px solid; TABLE-LAYOUT: fixed; BORDER-TOP: #99cccc 1px solid; OVERFLOW: auto; BORDER-LEFT: #99cccc 1px solid; WIDTH: 924px; CLIP: rect(0px 924px 160px 0px); BORDER-BOTTOM: #99cccc 1px solid; HEIGHT: 160px">
                                                                                    <asp:datagrid id="grdQTFY" runat="server" CssClass="label" UseAccessibleHeader="True" AllowPaging="False"
                                                                                        AutoGenerateColumns="False" GridLines="Vertical" BorderStyle="None" PageSize="30" BorderColor="#DEDFDE"
                                                                                        BorderWidth="0px" AllowSorting="True" CellPadding="4" Font-Names="����">
                                                                                        <SelectedItemStyle Font-Size="12px" Font-Names="����" Font-Bold="False" VerticalAlign="Middle" ForeColor="#CC0000" BackColor="#FFFFDD"></SelectedItemStyle>
                                                                                        <EditItemStyle Font-Size="12px" Font-Names="����" VerticalAlign="Middle" BackColor="#FFCC00"></EditItemStyle>
                                                                                        <AlternatingItemStyle Font-Size="12px" Font-Names="����" BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="White"></AlternatingItemStyle>
                                                                                        <ItemStyle Font-Size="12px" Font-Names="����" BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="#F7F7F7" ForeColor="Black"></ItemStyle>
                                                                                        <HeaderStyle Font-Size="12px" Font-Names="����" Font-Bold="True" ForeColor="White" VerticalAlign="Middle" BackColor="#6699cc" HorizontalAlign="Left"></HeaderStyle>
                                                                                        <FooterStyle BackColor="#CCCC99"></FooterStyle>
                                                                                        <Columns>
                                                                                            <asp:TemplateColumn HeaderText="ѡ">
                                                                                                <HeaderStyle HorizontalAlign="Center" Width="20px"></HeaderStyle>
                                                                                                <ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
                                                                                                <ItemTemplate>
                                                                                                    <asp:CheckBox id="chkQTFY" runat="server" AutoPostBack="False"></asp:CheckBox>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateColumn>
                                                                                            
                                                                                            <asp:ButtonColumn Visible="False" DataTextField="Ψһ��ʶ" SortExpression="Ψһ��ʶ" HeaderText="Ψһ��ʶ" CommandName="Select">
                                                                                                <HeaderStyle Width="0px"></HeaderStyle>
                                                                                            </asp:ButtonColumn>
                                                                                            <asp:ButtonColumn Visible="False" DataTextField="ȷ�����" SortExpression="ȷ�����" HeaderText="ȷ�����" CommandName="Select">
                                                                                                <HeaderStyle Width="0px"></HeaderStyle>
                                                                                            </asp:ButtonColumn>
                                                                                            <asp:ButtonColumn Visible="False" DataTextField="˰�Ѵ���" SortExpression="˰�Ѵ���" HeaderText="˰�Ѵ���" CommandName="Select">
                                                                                                <HeaderStyle Width="0px"></HeaderStyle>
                                                                                            </asp:ButtonColumn>
                                                                                            <asp:ButtonColumn Visible="False" DataTextField="�ո���־" SortExpression="�ո���־" HeaderText="�ո�" CommandName="Select">
                                                                                                <HeaderStyle Width="0px"></HeaderStyle>
                                                                                            </asp:ButtonColumn>
                                                                                            <asp:ButtonColumn Visible="False" DataTextField="�������" SortExpression="�������" HeaderText="���(Ԫ)" CommandName="Select" DataTextFormatString="{0:#,###.00}" ItemStyle-HorizontalAlign="Right">
                                                                                                <HeaderStyle Width="0px" HorizontalAlign="Right"></HeaderStyle>
                                                                                            </asp:ButtonColumn>
                                                                                            <asp:ButtonColumn DataTextField="�Ƿ����" SortExpression="�Ƿ����" HeaderText="��Ч" CommandName="Select">
                                                                                                <HeaderStyle Width="50px"></HeaderStyle>
                                                                                            </asp:ButtonColumn>
                                                                                            <asp:ButtonColumn DataTextField="��˱�־����" SortExpression="��˱�־����" HeaderText="���" CommandName="Select">
                                                                                                <HeaderStyle Width="50px"></HeaderStyle>
                                                                                            </asp:ButtonColumn>
                                                                                            <asp:ButtonColumn DataTextField="˰������" SortExpression="˰������" HeaderText="˰��" CommandName="Select">
                                                                                                <HeaderStyle Width="140px"></HeaderStyle>
                                                                                            </asp:ButtonColumn>
                                                                                            <asp:ButtonColumn DataTextField="���������" SortExpression="���������" HeaderText="��(Ԫ)" CommandName="Select" DataTextFormatString="{0:#,###.00}" ItemStyle-HorizontalAlign="Right">
                                                                                                <HeaderStyle Width="160px" HorizontalAlign="Right"></HeaderStyle>
                                                                                            </asp:ButtonColumn>
                                                                                            <asp:ButtonColumn DataTextField="������" SortExpression="������" HeaderText="��(Ԫ)" CommandName="Select" DataTextFormatString="{0:#,###.00}" ItemStyle-HorizontalAlign="Right">
                                                                                                <HeaderStyle Width="160px" HorizontalAlign="Right"></HeaderStyle>
                                                                                            </asp:ButtonColumn>
                                                                                            <asp:ButtonColumn DataTextField="ժҪ˵��" SortExpression="ժҪ˵��" HeaderText="ժҪ" CommandName="Select">
                                                                                                <HeaderStyle Width="300px"></HeaderStyle>
                                                                                            </asp:ButtonColumn>
                                                                                            <asp:ButtonColumn DataTextField="��������" SortExpression="��������" HeaderText="����" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd}">
                                                                                                <HeaderStyle Width="140px"></HeaderStyle>
                                                                                            </asp:ButtonColumn>
                                                                                            <asp:ButtonColumn DataTextField="�ո�����" SortExpression="�ո�����" HeaderText="����" CommandName="Select">
                                                                                                <HeaderStyle Width="60px"></HeaderStyle>
                                                                                            </asp:ButtonColumn>
                                                                                            <asp:ButtonColumn DataTextField="�ͻ�����" SortExpression="�ͻ�����" HeaderText="�ͻ�" CommandName="Select">
                                                                                                <HeaderStyle Width="120px"></HeaderStyle>
                                                                                            </asp:ButtonColumn>
                                                                                            <asp:ButtonColumn DataTextField="Ʊ�ݺ���" SortExpression="Ʊ�ݺ���" HeaderText="Ʊ�ݺ�" CommandName="Select">
                                                                                                <HeaderStyle Width="180px"></HeaderStyle>
                                                                                            </asp:ButtonColumn>
                                                                                            <asp:ButtonColumn DataTextField="������Ա����" SortExpression="������Ա����" HeaderText="������" CommandName="Select">
                                                                                                <HeaderStyle Width="120px"></HeaderStyle>
                                                                                            </asp:ButtonColumn>
                                                                                            <asp:ButtonColumn DataTextField="�����������" SortExpression="�����������" HeaderText="���쵥λ" CommandName="Select">
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
                                                                                            <asp:ButtonColumn Visible="False" DataTextField="�����������" SortExpression="�����������" HeaderText="�������" CommandName="Select">
                                                                                                <HeaderStyle Width="0px"></HeaderStyle>
                                                                                            </asp:ButtonColumn>
                                                                                            <asp:ButtonColumn Visible="False" DataTextField="�������" SortExpression="�������" HeaderText="�������" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd}">
                                                                                                <HeaderStyle Width="0px"></HeaderStyle>
                                                                                            </asp:ButtonColumn>
                                                                                            <asp:ButtonColumn Visible="False" DataTextField="��˱�־" SortExpression="��˱�־" HeaderText="��˱�־" CommandName="Select">
                                                                                                <HeaderStyle Width="0px"></HeaderStyle>
                                                                                            </asp:ButtonColumn>
                                                                                            <asp:ButtonColumn Visible="False" DataTextField="�ƻ���ʶ" SortExpression="�ƻ���ʶ" HeaderText="�ƻ���ʶ" CommandName="Select">
                                                                                                <HeaderStyle Width="0px"></HeaderStyle>
                                                                                            </asp:ButtonColumn>
                                                                                        </Columns>
                                                                                        <PagerStyle Visible="False" NextPageText="��ҳ" Font-Size="12px" Font-Names="����" PrevPageText="��ҳ" HorizontalAlign="Right" ForeColor="Black" Position="TopAndBottom" BackColor="SkyBlue"></PagerStyle>
                                                                                    </asp:datagrid><INPUT id="htxtQTFYFixed" type="hidden" value="0" runat="server">
                                                                                </DIV>
                                                                            </TD>
                                                                        </TR>
                                                                    </TABLE>
                                                                </TD>
                                                            </TR>
                                                        </TABLE>
                                                    </TD>
                                                </TR>
                                                <TR>
                                                    <TD>
                                                        <TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
                                                            <TR>
                                                                <TD class="label" align="left">
                                                                    <TABLE cellSpacing="0" cellPadding="0" width="100%" border="1" bordercolordark="#99cccc" bordercolorlight="White">
                                                                        <TR>
                                                                            <TD class="label" align="left" colSpan="10" bgColor="#ccff99"><B>&gt;&gt;&gt;&gt;�ۿ�������</B></TD>
                                                                        </TR>
                                                                        <TR>
                                                                            <TD class="label" align="center" valign="middle" rowspan="2">�շѱ�׼</TD>
                                                                            <TD class="label" align="center" valign="middle" rowspan="2">��ͬӦ��</TD>
                                                                            <TD class="label" align="center" valign="middle" rowspan="2">�ۿ�(%)</TD>
                                                                            <TD class="label" align="center" valign="middle" rowspan="2">�ۼƽ���</TD>
                                                                            <TD class="label" align="center" valign="middle" rowspan="2">�������</TD>
                                                                            <TD class="label" align="center">һ�����(%)</TD>
                                                                            <TD class="label" align="center">�������(%)</TD>
                                                                            <TD class="label" align="center">�������(%)</TD>
                                                                            <TD class="label" align="center" valign="middle" rowspan="2">�᰸</TD>
                                                                            <TD class="label" align="center" valign="middle" rowspan="2">��ע</TD>
                                                                        </TR>
                                                                        <TR>
                                                                            <TD class="label" align="center"><asp:TextBox id="txtZKSH_YJKS" Runat="server" ReadOnly="True" CssClass="textbox" Columns="4"></asp:TextBox>~<asp:TextBox id="txtZKSH_YJZZ" Runat="server" ReadOnly="True" CssClass="textbox" Columns="4"></asp:TextBox></TD>
                                                                            <TD class="label" align="center"><asp:TextBox id="txtZKSH_EJKS" Runat="server" ReadOnly="True" CssClass="textbox" Columns="4"></asp:TextBox>~<asp:TextBox id="txtZKSH_EJZZ" Runat="server" ReadOnly="True" CssClass="textbox" Columns="4"></asp:TextBox></TD>
                                                                            <TD class="label" align="center"><asp:TextBox id="txtZKSH_SJKS" Runat="server" ReadOnly="True" CssClass="textbox" Columns="4"></asp:TextBox>~<asp:TextBox id="txtZKSH_SJZZ" Runat="server" ReadOnly="True" CssClass="textbox" Columns="4"></asp:TextBox></TD>
                                                                        </TR>
                                                                        <TR>
                                                                            <TD><asp:TextBox id="txtZKSH_SFBZ" Runat="server" Width="100%" ReadOnly="True" CssClass="textbox"></asp:TextBox></TD>
                                                                            <TD><asp:TextBox id="txtZKSH_HTYS" Runat="server" Width="100%" ReadOnly="True" CssClass="textbox"></asp:TextBox></TD>
                                                                            <TD><asp:TextBox id="txtZKSH_HTZK" Runat="server" Width="100%" ReadOnly="True" CssClass="textbox"></asp:TextBox></TD>
                                                                            <TD><asp:TextBox id="txtZKSH_LJSS" Runat="server" Width="100%" ReadOnly="True" CssClass="textbox"></asp:TextBox></TD>
                                                                            <TD><asp:TextBox id="txtZKSH_YE"   Runat="server" Width="100%" ReadOnly="True" CssClass="textbox"></asp:TextBox></TD>
                                                                            <TD><asp:TextBox id="txtZKSH_YJSH" Runat="server" Width="100%" ReadOnly="True" CssClass="textbox"></asp:TextBox></TD>
                                                                            <TD><asp:TextBox id="txtZKSH_EJSH" Runat="server" Width="100%" ReadOnly="True" CssClass="textbox"></asp:TextBox></TD>
                                                                            <TD><asp:TextBox id="txtZKSH_SJSH" Runat="server" Width="100%" ReadOnly="True" CssClass="textbox"></asp:TextBox></TD>
                                                                            <TD>
                                                                                <asp:RadioButtonList id="rblZKSH_JA" Runat="server" CssClass="textbox" Enabled="False" RepeatLayout="Flow" RepeatDirection="Vertical" RepeatColumns="2">
                                                                                    <asp:ListItem Value="��">δ��</asp:ListItem>
                                                                                    <asp:ListItem Value="��">�᰸</asp:ListItem>
                                                                                </asp:RadioButtonList>
                                                                            </TD>
                                                                            <TD><asp:TextBox id="txtZKSH_BZXX" Runat="server" Width="100%" ReadOnly="True" CssClass="textbox"></asp:TextBox></TD>
                                                                        </TR>
                                                                    </TABLE>
                                                                </TD>
                                                            </TR>
                                                        </TABLE>
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
                    <TR>
                        <TD colSpan="3" height="4"></TD>
                    </TR>
                    <TR id="trRow02">
                        <TD align="center" colSpan="3">
                            <asp:Button id="btnSJSZ"  Runat="server" CssClass="button" Text="ʵ����֧" Height="36px"></asp:Button>
                            <asp:Button id="btnSZSH"  Runat="server" CssClass="button" Text="��֧���" Height="36px"></asp:Button>
                            <asp:Button id="btnPLSH"  Runat="server" CssClass="button" Text="�������" Height="36px"></asp:Button>
                            <asp:Button id="btnZKSH"  Runat="server" CssClass="button" Text="�ۿ����" Height="36px"></asp:Button>
                            <asp:Button id="btnJSQK"  Runat="server" CssClass="button" Text="�������" Height="36px"></asp:Button>
                            <asp:Button id="btnClose" Runat="server" CssClass="button" Text="��    ��" Height="36px"></asp:Button>
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
                        <input id="htxtQTFYQuery" type="hidden" runat="server">
                        <input id="htxtQTFYRows" type="hidden" runat="server">
                        <input id="htxtQTFYSort" type="hidden" runat="server">
                        <input id="htxtQTFYSortColumnIndex" type="hidden" runat="server">
                        <input id="htxtQTFYSortType" type="hidden" runat="server">
                        <input id="htxtDivLeftQTFY" type="hidden" runat="server">
                        <input id="htxtDivTopQTFY" type="hidden" runat="server">
                        <input id="htxtFKQuery" type="hidden" runat="server">
                        <input id="htxtFKRows" type="hidden" runat="server">
                        <input id="htxtFKSort" type="hidden" runat="server">
                        <input id="htxtFKSortColumnIndex" type="hidden" runat="server">
                        <input id="htxtFKSortType" type="hidden" runat="server">
                        <input id="htxtDivLeftFK" type="hidden" runat="server">
                        <input id="htxtDivTopFK" type="hidden" runat="server">
                        <input id="htxtZJFQuery" type="hidden" runat="server">
                        <input id="htxtZJFRows" type="hidden" runat="server">
                        <input id="htxtZJFSort" type="hidden" runat="server">
                        <input id="htxtZJFSortColumnIndex" type="hidden" runat="server">
                        <input id="htxtZJFSortType" type="hidden" runat="server">
                        <input id="htxtDivLeftZJF" type="hidden" runat="server">
                        <input id="htxtDivTopZJF" type="hidden" runat="server">
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
							function ScrollProc_divZJF() {
								var oText;
								oText=null;
								oText=document.getElementById("htxtDivTopZJF");
								if (oText != null) oText.value = divZJF.scrollTop;
								oText=null;
								oText=document.getElementById("htxtDivLeftZJF");
								if (oText != null) oText.value = divZJF.scrollLeft;
								return;
							}
							function ScrollProc_divFK() {
								var oText;
								oText=null;
								oText=document.getElementById("htxtDivTopFK");
								if (oText != null) oText.value = divFK.scrollTop;
								oText=null;
								oText=document.getElementById("htxtDivLeftFK");
								if (oText != null) oText.value = divFK.scrollLeft;
								return;
							}
							function ScrollProc_divQTFY() {
								var oText;
								oText=null;
								oText=document.getElementById("htxtDivTopQTFY");
								if (oText != null) oText.value = divQTFY.scrollTop;
								oText=null;
								oText=document.getElementById("htxtDivLeftQTFY");
								if (oText != null) oText.value = divQTFY.scrollLeft;
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
								oText=document.getElementById("htxtDivTopZJF");
								if (oText != null) divZJF.scrollTop = oText.value;
								oText=null;
								oText=document.getElementById("htxtDivLeftZJF");
								if (oText != null) divZJF.scrollLeft = oText.value;

								oText=null;
								oText=document.getElementById("htxtDivTopFK");
								if (oText != null) divFK.scrollTop = oText.value;
								oText=null;
								oText=document.getElementById("htxtDivLeftFK");
								if (oText != null) divFK.scrollLeft = oText.value;

								oText=null;
								oText=document.getElementById("htxtDivTopQTFY");
								if (oText != null) divQTFY.scrollTop = oText.value;
								oText=null;
								oText=document.getElementById("htxtDivLeftQTFY");
								if (oText != null) divQTFY.scrollLeft = oText.value;

								document.body.onscroll = ScrollProc_Body;
								divMain.onscroll = ScrollProc_divMain;
								divZJF.onscroll = ScrollProc_divZJF;
								divFK.onscroll = ScrollProc_divFK;
								divQTFY.onscroll = ScrollProc_divQTFY;
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
