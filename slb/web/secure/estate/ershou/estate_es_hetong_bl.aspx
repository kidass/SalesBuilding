<%@ Page Language="vb" AutoEventWireup="false" Codebehind="estate_es_hetong_bl.aspx.vb" Inherits="Josco.JSOA.web.estate_es_hetong_bl" %>
<%@ Register TagPrefix="uwin" Namespace="Josco.Web" Assembly="Josco.Web.PopMessage" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
    <HEAD>
        <title>��ͬ�참����</title>
        <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
        <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
        <meta content="JavaScript" name="vs_defaultClientScript">
        <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <LINK href="../../../styles01.css" type="text/css" rel="stylesheet">
        <style>
		    TD.grdBAJHLocked { ; LEFT: expression(divBAJH.scrollLeft); POSITION: relative }
		    TH.grdBAJHLocked { ; LEFT: expression(divBAJH.scrollLeft); POSITION: relative }
		    TH.grdBAJHLocked { Z-INDEX: 99 }
		    TD.grdBLJLLocked { ; LEFT: expression(divBLJL.scrollLeft); POSITION: relative }
		    TH.grdBLJLLocked { ; LEFT: expression(divBLJL.scrollLeft); POSITION: relative }
		    TH.grdBLJLLocked { Z-INDEX: 99 }
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
				//if (document.readyState.toLowerCase() == "complete")
                //    alert(strWidth + " " + strHeight);

				divMain.style.width  = strWidth;
				divMain.style.height = strHeight;
				divMain.style.clip = "rect(0px " + strWidth + " " + strHeight + " 0px)";

				divBAJH.style.width = (intWidth - 24).toString() + "px";
				divBLJL.style.width = (intWidth - 24).toString() + "px";
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
        <form id="frmestate_es_hetong_bl" method="post" runat="server">
            <asp:panel id="panelMain" Runat="server">
                <TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
                    <TR>
                        <TD width="5"></TD>
                        <TD vAlign="top" align="center">
                            <TABLE cellSpacing="0" cellPadding="0" border="0">
                                <TR id="trRow01">
                                    <TD class="title" align="center" colSpan="3" height="30">��ͬ�참����<asp:LinkButton id="lnkBlank" Runat="server" Width="0px"></asp:LinkButton></TD>
                                </TR>
                                <TR>
                                    <TD width="5"></TD>
                                    <TD vAlign="top" align="center">
                                        <DIV id="divMain" style="BORDER-TOP: #99cccc 2px solid; OVERFLOW: auto; WIDTH: 964px; CLIP: rect(0px 964px 456px 0px); BORDER-BOTTOM: #99cccc 2px solid; HEIGHT: 456px">
                                            <TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
                                                <TR>
                                                    <TD>
                                                        <% if propOrgQRSH() <> "" then response.write("<div style='display:none'>") %>
                                                        <TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
                                                            <TR>
                                                                <TD class="label" align="left" bgColor="#ccff99" colSpan="3"><B>&gt;&gt;&gt;&gt;ָ��ҵ����</B></TD>
                                                            </TR>
                                                            <TR>
                                                                <TD class="labelNotNull" noWrap align="right">ҵ���ţ�</TD>
                                                                <TD align="left" width="85%"><asp:TextBox id="txtJYBH" Runat="server" Width="100%" ReadOnly="True" CssClass="textbox"></asp:TextBox></TD>
                                                                <TD align="left"><asp:Button id="btnSelect_JYBH" Runat="server" CssClass="button" Text="��"></asp:Button></TD>
                                                            </TR>
                                                        </TABLE>
                                                        <% if propOrgQRSH() <> "" then response.write("</div>") %>
                                                    </TD>
                                                </TR>
                                                <TR>
                                                    <TD class="label" align="left" bgColor="#ccff99"><B>&gt;&gt;&gt;&gt;������Ҫ�����ҵ��һ����(������ƻ����ݺ�������ǰ�����[����ƻ�])</B></TD>
                                                </TR>
                                                <TR>
                                                    <TD>
                                                        <TABLE cellSpacing="0" cellPadding="0" border="0" width="100%">
                                                            <TR>
                                                                <TD>
                                                                    <TABLE cellSpacing="0" cellPadding="0" border="0" width="100%">
                                                                        <TR>
                                                                            <TD class="label" vAlign="middle" align="right">����</TD>
                                                                            <TD class="label" align="left">
                                                                                <asp:DropDownList id="ddlBAJHSearch_TXBZ" Runat="server" CssClass="textbox">
                                                                                    <asp:ListItem Value=""></asp:ListItem>
                                                                                    <asp:ListItem Value="0">��</asp:ListItem>
                                                                                    <asp:ListItem Value="1">��</asp:ListItem>
                                                                                </asp:DropDownList>
                                                                            </TD>
                                                                            <TD class="label" vAlign="middle" align="right" nowrap>�ƻ���ʼ</TD>
                                                                            <TD class="label" align="left"><asp:TextBox id="txtBAJHSearch_JHKSMin" Runat="server" CssClass="textbox" Columns="8"></asp:TextBox>~<asp:TextBox id="txtBAJHSearch_JHKSMax" Runat="server" CssClass="textbox" Columns="8"></asp:TextBox></TD>
                                                                            <TD class="label" vAlign="middle" align="right" nowrap>�ƻ�����</TD>
                                                                            <TD class="label" align="left"><asp:TextBox id="txtBAJHSearch_JHJSMin" Runat="server" CssClass="textbox" Columns="8"></asp:TextBox>~<asp:TextBox id="txtBAJHSearch_JHJSMax" Runat="server" CssClass="textbox" Columns="8"></asp:TextBox></TD>
                                                                            <TD class="label" vAlign="middle" align="right" nowrap>������Ա</TD>
                                                                            <TD class="label" align="left"><asp:TextBox id="txtBAJHSearch_JBRY" Runat="server" CssClass="textbox" Columns="6"></asp:TextBox></TD>
                                                                            <TD class="label" vAlign="middle" align="right" nowrap>���쵥λ</TD>
                                                                            <TD class="label" align="left"><asp:TextBox id="txtBAJHSearch_JBDW" Runat="server" CssClass="textbox" Columns="6"></asp:TextBox></TD>
                                                                            <TD class="label" vAlign="middle" align="right" nowrap>��������</TD>
                                                                            <TD class="label" align="left"><asp:TextBox id="txtBAJHSearch_GZNR" Runat="server" CssClass="textbox" Columns="6"></asp:TextBox></TD>
                                                                            <TD class="label"><asp:button id="btnBAJHSearch" Runat="server" CssClass="button" Text="����"></asp:button><asp:button id="btnBAJHSearch_Full" Runat="server" CssClass="button" Text="ȫ��"></asp:button></TD>
                                                                        </TR>
                                                                    </TABLE>
                                                                </TD>
                                                            </TR>
                                                        </TABLE>
                                                    </TD>
                                                </TR>
                                                <TR>
                                                    <TD align="center">
                                                        <DIV id="divBAJH" style="BORDER-RIGHT: #99cccc 1px solid; TABLE-LAYOUT: fixed; BORDER-TOP: #99cccc 1px solid; OVERFLOW: auto; BORDER-LEFT: #99cccc 1px solid; WIDTH: 920px; CLIP: rect(0px 920px 200px 0px); BORDER-BOTTOM: #99cccc 1px solid; HEIGHT: 200px">
                                                            <asp:datagrid id="grdBAJH" runat="server" CssClass="label" UseAccessibleHeader="True" AllowPaging="True"
                                                                AutoGenerateColumns="False" GridLines="Vertical" BorderStyle="None" PageSize="30" BorderColor="#DEDFDE"
                                                                BorderWidth="0px" AllowSorting="True" CellPadding="2" Font-Names="����" Width="100%">
                                                                <SelectedItemStyle Font-Size="12px" Font-Names="����" Font-Bold="False" VerticalAlign="Middle" ForeColor="#CC0000" BackColor="#FFFFDD"></SelectedItemStyle>
                                                                <EditItemStyle Font-Size="12px" Font-Names="����" VerticalAlign="Middle" BackColor="#FFCC00"></EditItemStyle>
                                                                <AlternatingItemStyle Font-Size="12px" Font-Names="����" BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="White"></AlternatingItemStyle>
                                                                <ItemStyle Font-Size="12px" Font-Names="����" BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="#F7F7F7" ForeColor="Black"></ItemStyle>
                                                                <HeaderStyle Font-Size="12px" Font-Names="����" Font-Bold="True" ForeColor="White" VerticalAlign="Middle" BackColor="#6699cc" HorizontalAlign="Left"></HeaderStyle>
                                                                <FooterStyle BackColor="#CCCC99"></FooterStyle>
                                                                
                                                                <Columns>
                                                                    <asp:TemplateColumn HeaderText="ѡ" ItemStyle-Width="0px" Visible="False">
                                                                        <HeaderStyle HorizontalAlign="Center" Width="0px"></HeaderStyle>
                                                                        <ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox id="chkBAJH" runat="server" AutoPostBack="False" Visible="False"></asp:CheckBox>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:ButtonColumn Visible="False" DataTextField="Ψһ��ʶ" SortExpression="Ψһ��ʶ" HeaderText="Ψһ��ʶ" CommandName="Select">
                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="ȷ�����" SortExpression="ȷ�����" HeaderText="ȷ�����" CommandName="Select">
                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="������Ա" SortExpression="������Ա" HeaderText="������Ա��" CommandName="Select">
                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn Visible="False" DataTextField="�������" SortExpression="�������" HeaderText="���������" CommandName="Select">
                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="���ѱ�־" SortExpression="���ѱ�־" HeaderText="���ѱ�־" CommandName="Select">
                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    
                                                                    <asp:TemplateColumn HeaderText="" ItemStyle-Width="30px">
                                                                        <HeaderStyle HorizontalAlign="Center" Width="30px"></HeaderStyle>
                                                                        <ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
                                                                        <ItemTemplate>
                                                                            <asp:Button ID="btnJH_SelectRow" Runat="server" CssClass="button" Text="Go" CommandName="btnJH_SelectRow" Width="30px"></asp:Button>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn HeaderText="����" ItemStyle-Width="30px">
                                                                        <HeaderStyle HorizontalAlign="Center" Width="30px"></HeaderStyle>
                                                                        <ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox id="chkJH_TX" runat="server" AutoPostBack="False"></asp:CheckBox>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn HeaderText="�ƻ���ʼ" ItemStyle-Width="90px">
                                                                        <HeaderStyle HorizontalAlign="Center" Width="90px"></HeaderStyle>
                                                                        <ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
                                                                        <ItemTemplate>
                                                                            <asp:TextBox ID="txtJH_JHKS" Runat="server" CssClass="textbox" Width="90px"></asp:TextBox>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn HeaderText="�ƻ�����" ItemStyle-Width="90px">
                                                                        <HeaderStyle HorizontalAlign="Center" Width="90px"></HeaderStyle>
                                                                        <ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
                                                                        <ItemTemplate>
                                                                            <asp:TextBox ID="txtJH_JHJS" Runat="server" CssClass="textbox" Width="90px"></asp:TextBox>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn HeaderText="������Ա" ItemStyle-Width="120px">
                                                                        <HeaderStyle HorizontalAlign="Center" Width="120px"></HeaderStyle>
                                                                        <ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
                                                                        <ItemTemplate>
                                                                            <asp:TextBox ID="txtJH_JBRY" Runat="server" CssClass="textbox" Width="90px"></asp:TextBox><input id="htxtJH_JBRY" type="hidden" runat="server"><asp:Button ID="btnJH_SelectJBRY" Runat="server" CssClass="textbox" Text="��" CommandName="btnJH_SelectJBRY"></asp:Button>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn HeaderText="���쵥λ" ItemStyle-Width="180px">
                                                                        <HeaderStyle HorizontalAlign="Center" Width="180px"></HeaderStyle>
                                                                        <ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
                                                                        <ItemTemplate>
                                                                            <asp:TextBox ID="txtJH_JBDW" Runat="server" CssClass="textbox" Width="150px"></asp:TextBox><input id="htxtJH_JBDW" type="hidden" runat="server" NAME="htxtJH_JBDW"><asp:Button ID="btnJH_SelectJBDW" Runat="server" CssClass="textbox" Text="��" CommandName="btnJH_SelectJBDW"></asp:Button>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn HeaderText="��������" ItemStyle-Width="140px">
                                                                        <HeaderStyle HorizontalAlign="Center" Width="140px"></HeaderStyle>
                                                                        <ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
                                                                        <ItemTemplate>
                                                                            <asp:TextBox ID="txtJH_GZNR" Runat="server" CssClass="textbox" Width="140px"></asp:TextBox>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    
                                                                    <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="���ѱ�־����" SortExpression="���ѱ�־����" HeaderText="����" CommandName="Select">
                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="�ƻ���ʼ" SortExpression="�ƻ���ʼ" HeaderText="�ƻ���ʼ" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd}">
                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="�ƻ�����" SortExpression="�ƻ�����" HeaderText="�ƻ�����" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd}">
                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="90px" DataTextField="ʵ�ʿ�ʼ" SortExpression="ʵ�ʿ�ʼ" HeaderText="ʵ�ʿ�ʼ" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd}">
                                                                        <HeaderStyle Width="90px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="90px" DataTextField="ʵ�ʽ���" SortExpression="ʵ�ʽ���" HeaderText="ʵ�ʽ���" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd}">
                                                                        <HeaderStyle Width="120px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="��������" SortExpression="��������" HeaderText="��������" CommandName="Select">
                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="������Ա����" SortExpression="������Ա����" HeaderText="������Ա" CommandName="Select">
                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="�����������" SortExpression="�����������" HeaderText="���쵥λ" CommandName="Select">
                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="��������" SortExpression="��������" HeaderText="��������" CommandName="Select">
                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="��������" SortExpression="��������" HeaderText="��������" CommandName="Select">
                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                </Columns>
                                                                
                                                                <PagerStyle Visible="False" NextPageText="��ҳ" Font-Size="12px" Font-Names="����" PrevPageText="��ҳ" HorizontalAlign="Right" ForeColor="Black" Position="TopAndBottom" BackColor="SkyBlue"></PagerStyle>
                                                            </asp:datagrid><INPUT id="htxtBAJHFixed" type="hidden" value="0" runat="server">
                                                        </DIV>
                                                    </TD>
                                                </TR>
                                                <TR>
                                                    <TD>
                                                        <TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
                                                            <TR>
                                                                <TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZBAJHDeSelectAll" runat="server">��ѡ</asp:linkbutton></TD>
                                                                <TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZBAJHSelectAll" runat="server">ȫѡ</asp:linkbutton></TD>
                                                                <TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZBAJHMoveFirst" runat="server">��ǰ</asp:linkbutton></TD>
                                                                <TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZBAJHMovePrev" runat="server">ǰҳ</asp:linkbutton></TD>
                                                                <TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZBAJHMoveNext" runat="server">��ҳ</asp:linkbutton></TD>
                                                                <TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZBAJHMoveLast" runat="server">���</asp:linkbutton></TD>
                                                                <TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZBAJHGotoPage" runat="server">ǰ��</asp:linkbutton><asp:textbox id="txtBAJHPageIndex" runat="server" CssClass="textbox" Columns="3">1</asp:textbox>ҳ</TD>
                                                                <TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZBAJHSetPageSize" runat="server">ÿҳ</asp:linkbutton><asp:textbox id="txtBAJHPageSize" runat="server" CssClass="textbox" Columns="3">30</asp:textbox>��</TD>
                                                                <TD class="label" vAlign="middle" noWrap align="right"><asp:label id="lblBAJHGridLocInfo" runat="server" CssClass="label">1/10 N/15</asp:label></TD>
                                                            </TR>
                                                        </TABLE>
                                                    </TD>
                                                </TR>
                                                <TR>
                                                    <TD>
                                                        <% if propQRSH() = "" then response.write("<div style='display:none'>") %>
                                                        <TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
                                                            <TR>
                                                                <TD class="label" align="left" bgColor="#ccff99" colspan="3"><B>&gt;&gt;&gt;&gt;������Ҫָ���Ĳ���(���������²�����[��������])</B></TD>
                                                            </TR>
                                                            <TR>
                                                                <TD class="label" align="center">
                                                                    <asp:RadioButtonList id="rblJH_TX" Runat="server" CssClass="textbox" RepeatLayout="Flow" RepeatDirection="Vertical" RepeatColumns="2">
                                                                        <asp:ListItem Value="0">������</asp:ListItem>
                                                                        <asp:ListItem Value="1">����</asp:ListItem>
                                                                    </asp:RadioButtonList>
                                                                </TD>
                                                                <TD class="label" align="center" valign="middle">�ƻ���ʼ����ǰ<asp:textbox id="txtJH_KBTS" Runat="server" CssClass="textbox" Columns="2"></asp:textbox>�쿪ʼ����<b>����ʼ�������ѡ�</b></TD>
                                                                <TD class="label" align="center" valign="middle">�ƻ���������ǰ<asp:textbox id="txtJH_BWTS" Runat="server" CssClass="textbox" Columns="2"></asp:textbox>�쿪ʼ����<b>������������ѡ�</b></TD>
                                                            </TR>
                                                        </TABLE>
                                                        <% if propQRSH() = "" then response.write("</div>") %>
                                                    </TD>
                                                </TR>
                                                <TR>
                                                    <TD align="center">
                                                        <% if propQRSH() = "" or propEditMode() = true then response.write("<div style='display:none'>") %>
                                                        <TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
                                                            <TR>
                                                                <TD class="label" align="left" bgColor="#ccff99" colspan="3"><B>&gt;&gt;&gt;&gt;ʵ�ʰ��������Ϣ���봰(������ɺ󣬰��ұߵ�[����])</B><INPUT id="htxtSJ_WYBS" type="hidden" size="1" runat="server"><INPUT id="htxtSJ_QRSH" type="hidden" size="1" runat="server"><INPUT id="htxtSJ_JHBS" type="hidden" size="1" runat="server"></TD>
                                                            </TR>
                                                            <TR>
                                                                <TD class="labelNotNull" align="left" nowrap>��������<asp:TextBox id="txtSJ_BLRQ" Runat="server" CssClass="textbox" Width="120px"></asp:TextBox></TD>
                                                                <TD class="labelNotNull" align="left" nowrap>������Ա<asp:TextBox id="txtSJ_JBRY" Runat="server" CssClass="textbox" Width="180px"></asp:TextBox><asp:Button id="btnSelect_SJ_JBRY" Runat="server" CssClass="button" Text="��"></asp:Button><INPUT id="htxtSJ_JBRY" type="hidden" size="1" runat="server"></TD>
                                                                <TD class="labelNotNull" align="left" nowrap>���쵥λ<asp:TextBox id="txtSJ_JBDW" Runat="server" CssClass="textbox" Width="400px"></asp:TextBox><asp:Button id="btnSelect_SJ_JBDW" Runat="server" CssClass="button" Text="��"></asp:Button><INPUT id="htxtSJ_JBDW" type="hidden" size="1" runat="server"></TD>
                                                            </TR>
                                                            <TR>
                                                                <TD class="labelNotNull" align="left" colSpan="3" nowrap>�������<asp:TextBox id="txtSJ_BLQK" Runat="server" CssClass="textbox" Width="866px"></asp:TextBox></TD>
                                                            </TR>
                                                            <tr>
                                                                <td align="right" colspan="3">
                                                                    <asp:Button id="btnAddNew_SJ" Runat="server" CssClass="button" Text="�µļ�¼"></asp:Button>
                                                                    <asp:Button id="btnUpdate_SJ" Runat="server" CssClass="button" Text="���ļ�¼"></asp:Button>
                                                                    <asp:Button id="btnDelete_SJ" Runat="server" CssClass="button" Text="ɾ����¼"></asp:Button>
                                                                </td>
                                                            </tr>
                                                        </TABLE>
                                                        <% if propQRSH() = "" or propEditMode() = true then response.write("</div>") %>
                                                    </TD>
                                                </TR>
                                                <TR>
                                                    <TD class="label" align="left" bgColor="#ccff99"><B>&gt;&gt;&gt;&gt;��ǰҵ�������ϸ��¼һ����</B></TD>
                                                </TR>
                                                <TR>
                                                    <TD align="center">
                                                        <DIV id="divBLJL" style="BORDER-RIGHT: #99cccc 1px solid; TABLE-LAYOUT: fixed; BORDER-TOP: #99cccc 1px solid; OVERFLOW: auto; BORDER-LEFT: #99cccc 1px solid; WIDTH: 920px; CLIP: rect(0px 920px 200px 0px); BORDER-BOTTOM: #99cccc 1px solid; HEIGHT: 200px">
                                                            <asp:datagrid id="grdBLJL" runat="server" CssClass="label" UseAccessibleHeader="True" AllowPaging="False"
                                                                AutoGenerateColumns="False" GridLines="Vertical" BorderStyle="None" PageSize="30" BorderColor="#DEDFDE"
                                                                BorderWidth="0px" AllowSorting="True" CellPadding="4" Font-Names="����" Width="100%">
                                                                <SelectedItemStyle Font-Size="12px" Font-Names="����" Font-Bold="False" VerticalAlign="Middle" ForeColor="#CC0000" BackColor="#FFFFDD"></SelectedItemStyle>
                                                                <EditItemStyle Font-Size="12px" Font-Names="����" VerticalAlign="Middle" BackColor="#FFCC00"></EditItemStyle>
                                                                <AlternatingItemStyle Font-Size="12px" Font-Names="����" BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="White"></AlternatingItemStyle>
                                                                <ItemStyle Font-Size="12px" Font-Names="����" BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="#F7F7F7" ForeColor="Black"></ItemStyle>
                                                                <HeaderStyle Font-Size="12px" Font-Names="����" Font-Bold="True" ForeColor="White" VerticalAlign="Middle" BackColor="#6699cc" HorizontalAlign="Left"></HeaderStyle>
                                                                <FooterStyle BackColor="#CCCC99"></FooterStyle>
                                                                <Columns>
                                                                    <asp:TemplateColumn HeaderText="ѡ" Visible="False">
                                                                        <HeaderStyle HorizontalAlign="Center" Width="20px"></HeaderStyle>
                                                                        <ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox id="chkBLJL" runat="server" AutoPostBack="False" Visible="False"></asp:CheckBox>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:ButtonColumn Visible="False" DataTextField="Ψһ��ʶ" SortExpression="Ψһ��ʶ" HeaderText="Ψһ��ʶ" CommandName="Select">
                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn Visible="False" DataTextField="ȷ�����" SortExpression="ȷ�����" HeaderText="ȷ�����" CommandName="Select">
                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn Visible="False" DataTextField="������Ա" SortExpression="������Ա" HeaderText="������Ա��" CommandName="Select">
                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn Visible="False" DataTextField="�������" SortExpression="�������" HeaderText="���������" CommandName="Select">
                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn DataTextField="��������" SortExpression="��������" HeaderText="��������" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd HH:mm:ss}">
                                                                        <HeaderStyle Width="180px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn DataTextField="������Ա����" SortExpression="������Ա����" HeaderText="������Ա" CommandName="Select">
                                                                        <HeaderStyle Width="120px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn DataTextField="�����������" SortExpression="�����������" HeaderText="���쵥λ" CommandName="Select">
                                                                        <HeaderStyle Width="180px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn DataTextField="�������" SortExpression="�������" HeaderText="�������" CommandName="Select">
                                                                        <HeaderStyle Width="600px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    
                                                                     <asp:ButtonColumn Visible =False  DataTextField="�ƻ���ʶ" SortExpression="�ƻ���ʶ" HeaderText="�ƻ���ʶ" CommandName="Select">
                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                </Columns>
                                                                <PagerStyle Visible="False" NextPageText="��ҳ" Font-Size="12px" Font-Names="����" PrevPageText="��ҳ" HorizontalAlign="Right" ForeColor="Black" Position="TopAndBottom" BackColor="SkyBlue"></PagerStyle>
                                                            </asp:datagrid><INPUT id="htxtBLJLFixed" type="hidden" value="0" runat="server">
                                                        </DIV>
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
                            <asp:Button id="btnAddNew_JH" Runat="server" CssClass="button" Text="�ƶ��ƻ�" Height="36px"></asp:Button>
                            <asp:Button id="btnUpdate_JH" Runat="server" CssClass="button" Text="����ƻ�" Height="36px"></asp:Button>
                            <asp:Button id="btnDelete_JH" Runat="server" CssClass="button" Text="ɾ���ƻ�" Height="36px"></asp:Button>
                            <asp:Button id="btnKSBL"      Runat="server" CssClass="button" Text="��ǿ���" Height="36px"></asp:Button>
                            <asp:Button id="btnBLWB"      Runat="server" CssClass="button" Text="��ǰ���" Height="36px"></asp:Button>
                            <asp:Button id="btnGBTX"      Runat="server" CssClass="button" Text="�ر�����" Height="36px"></asp:Button>
                            <asp:Button id="btnSZTX"      Runat="server" CssClass="button" Text="��������" Height="36px"></asp:Button>
                            <asp:Button id="btnAJBJ"      Runat="server" CssClass="button" Text="��ͬ�᰸" Height="36px"></asp:Button>
                            <asp:Button id="btnClose"     Runat="server" CssClass="button" Text="��    ��" Height="36px"></asp:Button>
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
                        <input id="htxtBAXM_MM" type="hidden" runat="server" NAME="htxtBAXM_MM" value="001.">
                        <input id="htxtBAXM_ZL" type="hidden" runat="server" NAME="htxtBAXM_ZL" value="002.">
                        <input id="htxtBAXM_QT" type="hidden" runat="server" NAME="htxtBAXM_QT" value="003.">
                        <input id="htxtSessionIdBAJH" type="hidden" runat="server" NAME="htxtSessionIdBAJH">
                        <input id="htxtRowNoBAJH" type="hidden" runat="server" NAME="htxtRowNoBAJH">
                        <input id="htxtCurrentPage" type="hidden" runat="server">
                        <input id="htxtCurrentRow" type="hidden" runat="server">
                        <input id="htxtEditMode" type="hidden" runat="server">
                        <input id="htxtEditType" type="hidden" runat="server">
                        <input id="htxtBLJLSessionIdQuery" type="hidden" runat="server">
                        <input id="htxtBLJLQuery" type="hidden" runat="server">
                        <input id="htxtBLJLRows" type="hidden" runat="server">
                        <input id="htxtBLJLSort" type="hidden" runat="server">
                        <input id="htxtBLJLSortColumnIndex" type="hidden" runat="server">
                        <input id="htxtBLJLSortType" type="hidden" runat="server">
                        <input id="htxtBAJHSessionIdQuery" type="hidden" runat="server">
                        <input id="htxtBAJHQuery" type="hidden" runat="server">
                        <input id="htxtBAJHRows" type="hidden" runat="server">
                        <input id="htxtBAJHSort" type="hidden" runat="server">
                        <input id="htxtBAJHSortColumnIndex" type="hidden" runat="server">
                        <input id="htxtBAJHSortType" type="hidden" runat="server">
                        <input id="htxtDivLeftBLJL" type="hidden" runat="server">
                        <input id="htxtDivTopBLJL" type="hidden" runat="server">
                        <input id="htxtDivLeftBAJH" type="hidden" runat="server">
                        <input id="htxtDivTopBAJH" type="hidden" runat="server">
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
							function ScrollProc_divBAJH() {
								var oText;
								oText=null;
								oText=document.getElementById("htxtDivTopBAJH");
								if (oText != null) oText.value = divBAJH.scrollTop;
								oText=null;
								oText=document.getElementById("htxtDivLeftBAJH");
								if (oText != null) oText.value = divBAJH.scrollLeft;
								return;
							}
							function ScrollProc_divBLJL() {
								var oText;
								oText=null;
								oText=document.getElementById("htxtDivTopBLJL");
								if (oText != null) oText.value = divBLJL.scrollTop;
								oText=null;
								oText=document.getElementById("htxtDivLeftBLJL");
								if (oText != null) oText.value = divBLJL.scrollLeft;
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
								oText=document.getElementById("htxtDivTopBAJH");
								if (oText != null) divBAJH.scrollTop = oText.value;
								oText=null;
								oText=document.getElementById("htxtDivLeftBAJH");
								if (oText != null) divBAJH.scrollLeft = oText.value;

								oText=null;
								oText=document.getElementById("htxtDivTopBLJL");
								if (oText != null) divBLJL.scrollTop = oText.value;
								oText=null;
								oText=document.getElementById("htxtDivLeftBLJL");
								if (oText != null) divBLJL.scrollLeft = oText.value;

								document.body.onscroll = ScrollProc_Body;
								divMain.onscroll = ScrollProc_divMain;
								divBAJH.onscroll = ScrollProc_divBAJH;
								divBLJL.onscroll = ScrollProc_divBLJL;
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
