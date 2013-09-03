<%@ Page Language="vb" AutoEventWireup="false" Codebehind="estate_es_hetong_zksh.aspx.vb" Inherits="Josco.JSOA.web.estate_es_hetong_zksh" %>
<%@ Register TagPrefix="uwin" Namespace="Josco.Web" Assembly="Josco.Web.PopMessage" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
    <HEAD>
        <title>��ͬ�ۿ���˴���</title>
        <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
        <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
        <meta content="JavaScript" name="vs_defaultClientScript">
        <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <LINK href="../../../styles01.css" type="text/css" rel="stylesheet">
        <style>
		    TD.grdHTLocked { ; LEFT: expression(divHT.scrollLeft); POSITION: relative }
		    TH.grdHTLocked { ; LEFT: expression(divHT.scrollLeft); POSITION: relative }
		    TH.grdHTLocked { Z-INDEX: 99 }
		    TD.grdSHQKLocked { ; LEFT: expression(divSHQK.scrollLeft); POSITION: relative }
		    TH.grdSHQKLocked { ; LEFT: expression(divSHQK.scrollLeft); POSITION: relative }
		    TH.grdSHQKLocked { Z-INDEX: 99 }
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
				
				if (document.all("divSHQK") == null)
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
				strHeight  = intHeight.toString() + "px";
				//if (document.readyState.toLowerCase() == "complete")
                //    alert(strWidth + " " + strHeight);
				divHT.style.width = strWidth;

				divSHQK.style.width = strWidth;
				divSHQK.style.height = strHeight;
				divSHQK.style.clip   = "rect(0px " + strWidth + " " + strHeight + " 0px)";
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
        <form id="frmestate_es_hetong_zksh" method="post" runat="server">
            <asp:panel id="panelMain" Runat="server">
                <TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
                    <TR>
                        <TD width="5"></TD>
                        <TD vAlign="top" align="center">
                            <TABLE cellSpacing="0" cellPadding="0" border="0">
                                <TR id="trRow1">
                                    <TD class="title" align="center" colSpan="3" height="30">��ͬ�ۿ���˴���<asp:LinkButton id="lnkBlank" Runat="server" Width="0px"></asp:LinkButton></TD>
                                </TR>
                                <TR>
                                    <TD width="5"></TD>
                                    <TD vAlign="top">
                                        <TABLE cellSpacing="0" cellPadding="0" border="0">
                                            <TR id="trRow2">
                                                <TD>
                                                    <% if propQRSH <> "" then response.write("<div style='display:none'>") %>
                                                    <TABLE cellSpacing="0" cellPadding="0" align="center" border="0">
                                                        <TR>
                                                            <TD class="label" align="left" bgColor="#ccff99"><B>&gt;&gt;&gt;&gt;ȷ��Ҫ��˵ĺ�ͬ</B></TD>
                                                        </TR>
                                                        <TR>
                                                            <TD align="left">
                                                                <TABLE cellSpacing="0" cellPadding="0" border="0">
                                                                    <TR>
                                                                        <TD class="label" vAlign="middle" align="right">&nbsp;&nbsp;ȷ�����&nbsp;</TD>
                                                                        <TD class="label" align="left"><asp:textbox id="txtHTSearch_QRSH" runat="server" Columns="6" CssClass="textbox"></asp:textbox></TD>
                                                                        <TD class="label" vAlign="middle" align="right">&nbsp;&nbsp;��ͬ���&nbsp;</TD>
                                                                        <TD class="label" align="left"><asp:textbox id="txtHTSearch_HTBH" runat="server" Columns="6" CssClass="textbox"></asp:textbox></TD>
                                                                        <TD class="label" vAlign="middle" align="right">&nbsp;&nbsp;��ͬ����&nbsp;</TD>
                                                                        <TD class="label" align="left"><asp:textbox id="txtHTSearch_HTRQMin" runat="server" Columns="7" CssClass="textbox"></asp:textbox>~<asp:textbox id="txtHTSearch_HTRQMax" runat="server" Columns="7" CssClass="textbox"></asp:textbox></TD>
                                                                        <TD class="label" vAlign="middle" align="right">&nbsp;&nbsp;״̬&nbsp;</TD>
                                                                        <TD class="label" align="left">
                                                                            <asp:DropDownList id="ddlHTSearch_HTZT" runat="server" CssClass="textbox">
                                                                                <asp:ListItem Value=""></asp:ListItem>
                                                                                <asp:ListItem Value="&1=0">δ��</asp:ListItem>
                                                                                <asp:ListItem Value="&1=1">����</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </TD>
                                                                        <TD class="label" vAlign="middle" align="right">&nbsp;&nbsp;�׷�&nbsp;</TD>
                                                                        <TD class="label" align="left"><asp:textbox id="txtHTSearch_JFMC" runat="server" Columns="6" CssClass="textbox"></asp:textbox></TD>
                                                                        <TD class="label" vAlign="middle" align="right">&nbsp;&nbsp;�ҷ�&nbsp;</TD>
                                                                        <TD class="label" align="left"><asp:textbox id="txtHTSearch_YFMC" runat="server" Columns="6" CssClass="textbox"></asp:textbox></TD>
                                                                        <TD class="label" vAlign="middle" align="right">&nbsp;&nbsp;���ݵ�ַ&nbsp;</TD>
                                                                        <TD class="label" align="left"><asp:textbox id="txtHTSearch_FWDZ" runat="server" Columns="10" CssClass="textbox"></asp:textbox></TD>
                                                                        <TD class="label" align="right" colSpan="2">&nbsp;&nbsp;<asp:button id="btnHTSearch" Runat="server" CssClass="button" Text="����"></asp:button><asp:button id="btnHTSearch_Full" Runat="server" CssClass="button" Text="ȫ��"></asp:button></TD>
                                                                    </TR>
                                                                </TABLE>
                                                            </TD>
                                                        </TR>
                                                        <TR>
                                                            <TD>
                                                                <DIV id="divHT" style="BORDER-RIGHT: #99cccc 1px solid; TABLE-LAYOUT: fixed; BORDER-TOP: #99cccc 1px solid; OVERFLOW: auto; BORDER-LEFT: #99cccc 1px solid; WIDTH: 964px; CLIP: rect(0px 964px 200px 0px); BORDER-BOTTOM: #99cccc 1px solid; HEIGHT: 200px">
                                                                    <asp:datagrid id="grdHT" runat="server" Width="7450px" CssClass="label" UseAccessibleHeader="True"
                                                                        AllowPaging="True" AutoGenerateColumns="False" GridLines="Vertical" BackColor="White" BorderStyle="None"
                                                                        PageSize="30" BorderColor="#DEDFDE" BorderWidth="0px" AllowSorting="True" CellPadding="4">
                                                                        <SelectedItemStyle Font-Bold="False" VerticalAlign="Middle" ForeColor="#CC0000" BackColor="#FFFFDD"></SelectedItemStyle>
                                                                        <EditItemStyle VerticalAlign="Middle" BackColor="#FFCC00"></EditItemStyle>
                                                                        <AlternatingItemStyle BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="White"></AlternatingItemStyle>
                                                                        <ItemStyle BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="#F7F7F7" ForeColor="Black"></ItemStyle>
                                                                        <HeaderStyle Font-Bold="True" ForeColor="White" VerticalAlign="Middle" BackColor="#6699cc" HorizontalAlign="Left"></HeaderStyle>
                                                                        <FooterStyle BackColor="#CCCC99"></FooterStyle>
                                                                        
                                                                        <Columns>
                                                                            <asp:TemplateColumn HeaderText="ѡ" Visible="False" ItemStyle-Width="20px">
                                                                                <HeaderStyle HorizontalAlign="Center" Width="20px"></HeaderStyle>
                                                                                <ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
                                                                                <ItemTemplate>
                                                                                    <asp:CheckBox id="chkHT" runat="server" AutoPostBack="False" Visible="False"></asp:CheckBox>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateColumn>
                                                                            <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="Ψһ��ʶ" SortExpression="Ψһ��ʶ" HeaderText="Ψһ��ʶ" CommandName="Select">
                                                                                <HeaderStyle Width="0px"></HeaderStyle>
                                                                            </asp:ButtonColumn>
                                                                            <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="��ͬΨһ��ʶ" SortExpression="��ͬΨһ��ʶ" HeaderText="��ͬΨһ��ʶ" CommandName="Select">
                                                                                <HeaderStyle Width="0px"></HeaderStyle>
                                                                            </asp:ButtonColumn>
                                                                            <asp:ButtonColumn ItemStyle-Width="100px" DataTextField="��������" SortExpression="��������" HeaderText="����" CommandName="Select">
                                                                                <HeaderStyle Width="100px"></HeaderStyle>
                                                                            </asp:ButtonColumn>
                                                                            <asp:ButtonColumn ItemStyle-Width="120px" DataTextField="���ױ��" SortExpression="���ױ��" HeaderText="ȷ�����" CommandName="OpenDocument">
                                                                                <HeaderStyle Width="120px"></HeaderStyle>
                                                                            </asp:ButtonColumn>
                                                                            <asp:ButtonColumn ItemStyle-Width="120px" DataTextField="��ͬ���" SortExpression="��ͬ���" HeaderText="��ͬ���" CommandName="OpenDocument">
                                                                                <HeaderStyle Width="120px"></HeaderStyle>
                                                                            </asp:ButtonColumn>
                                                                            <asp:ButtonColumn ItemStyle-Width="140px" DataTextField="��������" SortExpression="��������" HeaderText="��������" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd}">
                                                                                <HeaderStyle Width="140px"></HeaderStyle>
                                                                            </asp:ButtonColumn>
                                                                            <asp:ButtonColumn ItemStyle-Width="140px" DataTextField="��ͬ����" SortExpression="��ͬ����" HeaderText="��ͬ����" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd}">
                                                                                <HeaderStyle Width="140px"></HeaderStyle>
                                                                            </asp:ButtonColumn>
                                                                            <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="����״̬" SortExpression="����״̬" HeaderText="����״̬" CommandName="Select">
                                                                                <HeaderStyle Width="0px"></HeaderStyle>
                                                                            </asp:ButtonColumn>
                                                                            <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="��ͬ״̬" SortExpression="��ͬ״̬" HeaderText="��ͬ״̬��" CommandName="Select">
                                                                                <HeaderStyle Width="0px"></HeaderStyle>
                                                                            </asp:ButtonColumn>
                                                                            <asp:ButtonColumn ItemStyle-Width="100px" DataTextField="��ͬ״̬����" SortExpression="��ͬ״̬����" HeaderText="��ͬ״̬" CommandName="Select">
                                                                                <HeaderStyle Width="100px"></HeaderStyle>
                                                                            </asp:ButtonColumn>
                                                                            <asp:ButtonColumn ItemStyle-Width="160px" DataTextField="ҵ������" SortExpression="ҵ������" HeaderText="�׷�" CommandName="Select">
                                                                                <HeaderStyle Width="160px"></HeaderStyle>
                                                                            </asp:ButtonColumn>
                                                                            <asp:ButtonColumn ItemStyle-Width="160px" DataTextField="�ͻ�����" SortExpression="�ͻ�����" HeaderText="�ҷ�" CommandName="Select">
                                                                                <HeaderStyle Width="160px"></HeaderStyle>
                                                                            </asp:ButtonColumn>
                                                                            <asp:ButtonColumn ItemStyle-Width="700px" DataTextField="��ҵ��ַ" SortExpression="��ҵ��ַ" HeaderText="���ݵ�ַ" CommandName="Select">
                                                                                <HeaderStyle Width="700px"></HeaderStyle>
                                                                            </asp:ButtonColumn>
                                                                            <asp:ButtonColumn ItemStyle-Width="160px" DataTextField="���׼۸�" SortExpression="���׼۸�" HeaderText="���׽��" CommandName="Select" DataTextFormatString="{0:#,###.00}" ItemStyle-HorizontalAlign="Right">
                                                                                <HeaderStyle Width="160px" HorizontalAlign="Right"></HeaderStyle>
                                                                            </asp:ButtonColumn>
                                                                            <asp:ButtonColumn ItemStyle-Width="160px" DataTextField="�������" SortExpression="�������" HeaderText="�������" CommandName="Select" DataTextFormatString="{0:#,###.00}" ItemStyle-HorizontalAlign="Right">
                                                                                <HeaderStyle Width="160px" HorizontalAlign="Right"></HeaderStyle>
                                                                            </asp:ButtonColumn>
                                                                            <asp:ButtonColumn ItemStyle-Width="160px" DataTextField="�׷������" SortExpression="�׷������" HeaderText="�׷������" CommandName="Select" DataTextFormatString="{0:#,###.00}" ItemStyle-HorizontalAlign="Right">
                                                                                <HeaderStyle Width="160px" HorizontalAlign="Right"></HeaderStyle>
                                                                            </asp:ButtonColumn>
                                                                            <asp:ButtonColumn ItemStyle-Width="160px" DataTextField="�ҷ������" SortExpression="�ҷ������" HeaderText="�ҷ������" CommandName="Select" DataTextFormatString="{0:#,###.00}" ItemStyle-HorizontalAlign="Right">
                                                                                <HeaderStyle Width="160px" HorizontalAlign="Right"></HeaderStyle>
                                                                            </asp:ButtonColumn>
                                                                            <asp:ButtonColumn ItemStyle-Width="160px" DataTextField="������ۿ�" SortExpression="������ۿ�" HeaderText="������ۿ�" CommandName="Select" DataTextFormatString="{0:#.00%}" ItemStyle-HorizontalAlign="Right">
                                                                                <HeaderStyle Width="160px" HorizontalAlign="Right"></HeaderStyle>
                                                                            </asp:ButtonColumn>
                                                                            <asp:ButtonColumn ItemStyle-Width="200px" DataTextField="�׷���ϵ�绰" SortExpression="�׷���ϵ�绰" HeaderText="�׷���ϵ�绰" CommandName="Select">
                                                                                <HeaderStyle Width="200px"></HeaderStyle>
                                                                            </asp:ButtonColumn>
                                                                            <asp:ButtonColumn ItemStyle-Width="300px" DataTextField="�׷���ϵ��ַ" SortExpression="�׷���ϵ��ַ" HeaderText="�׷���ϵ��ַ" CommandName="Select">
                                                                                <HeaderStyle Width="300px"></HeaderStyle>
                                                                            </asp:ButtonColumn>
                                                                            <asp:ButtonColumn ItemStyle-Width="200px" DataTextField="�ҷ���ϵ�绰" SortExpression="�ҷ���ϵ�绰" HeaderText="�ҷ���ϵ�绰" CommandName="Select">
                                                                                <HeaderStyle Width="200px"></HeaderStyle>
                                                                            </asp:ButtonColumn>
                                                                            <asp:ButtonColumn ItemStyle-Width="300px" DataTextField="�ҷ���ϵ��ַ" SortExpression="�ҷ���ϵ��ַ" HeaderText="�ҷ���ϵ��ַ" CommandName="Select">
                                                                                <HeaderStyle Width="300px"></HeaderStyle>
                                                                            </asp:ButtonColumn>
                                                                            <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="�׷�֤������" SortExpression="�׷�֤������" HeaderText="�׷�֤������" CommandName="Select">
                                                                                <HeaderStyle Width="0px"></HeaderStyle>
                                                                            </asp:ButtonColumn>
                                                                            <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="�׷�֤�պ���" SortExpression="�׷�֤�պ���" HeaderText="�׷�֤�պ���" CommandName="Select">
                                                                                <HeaderStyle Width="0px"></HeaderStyle>
                                                                            </asp:ButtonColumn>
                                                                            <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="�׷�������" SortExpression="�׷�������" HeaderText="�׷�������" CommandName="Select">
                                                                                <HeaderStyle Width="0px"></HeaderStyle>
                                                                            </asp:ButtonColumn>
                                                                            <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="�ҷ�֤������" SortExpression="�ҷ�֤������" HeaderText="�ҷ�֤������" CommandName="Select">
                                                                                <HeaderStyle Width="0px"></HeaderStyle>
                                                                            </asp:ButtonColumn>
                                                                            <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="�ҷ�֤�պ���" SortExpression="�ҷ�֤�պ���" HeaderText="�ҷ�֤�պ���" CommandName="Select">
                                                                                <HeaderStyle Width="0px"></HeaderStyle>
                                                                            </asp:ButtonColumn>
                                                                            <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="�ҷ�������" SortExpression="�ҷ�������" HeaderText="�ҷ�������" CommandName="Select">
                                                                                <HeaderStyle Width="0px"></HeaderStyle>
                                                                            </asp:ButtonColumn>

																            <asp:ButtonColumn ItemStyle-Width="160px" DataTextField="��Դ���" SortExpression="��Դ���" HeaderText="��Դ���" CommandName="Select">
																	            <HeaderStyle Width="160px"></HeaderStyle>
																            </asp:ButtonColumn>
																            <asp:ButtonColumn ItemStyle-Width="160px" DataTextField="����ַ" SortExpression="����ַ" HeaderText="����ַ" CommandName="Select">
																	            <HeaderStyle Width="160px"></HeaderStyle>
																            </asp:ButtonColumn>
																            <asp:ButtonColumn ItemStyle-Width="160px" DataTextField="����" SortExpression="����" HeaderText="����" CommandName="Select" DataTextFormatString="{0:#,###.00}" ItemStyle-HorizontalAlign="Right">
																	            <HeaderStyle Width="160px" HorizontalAlign="Right"></HeaderStyle>
																            </asp:ButtonColumn>
																            <asp:ButtonColumn ItemStyle-Width="160px" DataTextField="ʵ��Ӷ��" SortExpression="ʵ��Ӷ��" HeaderText="ʵ��Ӷ��" CommandName="Select" DataTextFormatString="{0:#,###.00}" ItemStyle-HorizontalAlign="Right">
																	            <HeaderStyle Width="160px" HorizontalAlign="Right"></HeaderStyle>
																            </asp:ButtonColumn>
																            <asp:ButtonColumn ItemStyle-Width="160px" DataTextField="����Ӷ��" SortExpression="����Ӷ��" HeaderText="����Ӷ��" CommandName="Select" DataTextFormatString="{0:#,###.00}" ItemStyle-HorizontalAlign="Right">
																	            <HeaderStyle Width="160px" HorizontalAlign="Right"></HeaderStyle>
																            </asp:ButtonColumn>
																            <asp:ButtonColumn ItemStyle-Width="160px" DataTextField="���һ���" SortExpression="���һ���" HeaderText="���һ���" CommandName="Select">
																	            <HeaderStyle Width="160px"></HeaderStyle>
																            </asp:ButtonColumn>
																            <asp:ButtonColumn ItemStyle-Width="160px" DataTextField="��������" SortExpression="��������" HeaderText="��������" CommandName="Select">
																	            <HeaderStyle Width="160px"></HeaderStyle>
																            </asp:ButtonColumn>
																            <asp:ButtonColumn ItemStyle-Width="160px" DataTextField="���ҳ���" SortExpression="���ҳ���" HeaderText="���ҳ���" CommandName="Select" DataTextFormatString="{0:#,###.00}" ItemStyle-HorizontalAlign="Right">
																	            <HeaderStyle Width="160px" HorizontalAlign="Right"></HeaderStyle>
																            </asp:ButtonColumn>
																            <asp:ButtonColumn ItemStyle-Width="160px" DataTextField="��������" SortExpression="��������" HeaderText="��������" CommandName="Select" DataTextFormatString="{0:#,###.00}" ItemStyle-HorizontalAlign="Right">
																	            <HeaderStyle Width="160px" HorizontalAlign="Right"></HeaderStyle>
																            </asp:ButtonColumn>
																            <asp:ButtonColumn ItemStyle-Width="160px" DataTextField="ҵ������" SortExpression="ҵ������" HeaderText="ҵ������" CommandName="Select">
																	            <HeaderStyle Width="160px"></HeaderStyle>
																            </asp:ButtonColumn>
																            <asp:ButtonColumn ItemStyle-Width="160px" DataTextField="ҵ������" SortExpression="ҵ������" HeaderText="ҵ����������" CommandName="Select">
																	            <HeaderStyle Width="160px"></HeaderStyle>
																            </asp:ButtonColumn>
																            <asp:ButtonColumn ItemStyle-Width="160px" DataTextField="ҵ����Դ" SortExpression="ҵ����Դ" HeaderText="ҵ����Դ" CommandName="Select">
																	            <HeaderStyle Width="160px"></HeaderStyle>
																            </asp:ButtonColumn>
																            <asp:ButtonColumn ItemStyle-Width="160px" DataTextField="ҵԴ����" SortExpression="ҵԴ����" HeaderText="ҵ����Դ����" CommandName="Select">
																	            <HeaderStyle Width="160px"></HeaderStyle>
																            </asp:ButtonColumn>
																            <asp:ButtonColumn ItemStyle-Width="160px" DataTextField="ҵ������" SortExpression="ҵ������" HeaderText="ҵ������" CommandName="Select">
																	            <HeaderStyle Width="160px"></HeaderStyle>
																            </asp:ButtonColumn>
																            <asp:ButtonColumn ItemStyle-Width="160px" DataTextField="�ۺ�����" SortExpression="�ۺ�����" HeaderText="�ۺ�����" CommandName="Select">
																	            <HeaderStyle Width="160px"></HeaderStyle>
																            </asp:ButtonColumn>
																            <asp:ButtonColumn ItemStyle-Width="160px" DataTextField="ʣ����ҵ" SortExpression="ʣ����ҵ" HeaderText="ʣ����ҵ" CommandName="Select">
																	            <HeaderStyle Width="160px"></HeaderStyle>
																            </asp:ButtonColumn>
																            <asp:ButtonColumn ItemStyle-Width="160px" DataTextField="�������" SortExpression="�������" HeaderText="��ҵ���" CommandName="Select">
																	            <HeaderStyle Width="160px"></HeaderStyle>
																            </asp:ButtonColumn>
																            <asp:ButtonColumn ItemStyle-Width="160px" DataTextField="�������" SortExpression="�������" HeaderText="��ҵ�������" CommandName="Select">
																	            <HeaderStyle Width="160px"></HeaderStyle>
																            </asp:ButtonColumn>
																            <asp:ButtonColumn ItemStyle-Width="160px" DataTextField="�ͻ���Դ" SortExpression="�ͻ���Դ" HeaderText="�ͻ���Դ" CommandName="Select">
																	            <HeaderStyle Width="160px"></HeaderStyle>
																            </asp:ButtonColumn>
																            <asp:ButtonColumn ItemStyle-Width="160px" DataTextField="��Դ����" SortExpression="��Դ����" HeaderText="�ͻ���Դ����" CommandName="Select">
																	            <HeaderStyle Width="160px"></HeaderStyle>
																            </asp:ButtonColumn>
																            <asp:ButtonColumn ItemStyle-Width="160px" DataTextField="�ͻ�����" SortExpression="�ͻ�����" HeaderText="�ͻ�����" CommandName="Select">
																	            <HeaderStyle Width="160px"></HeaderStyle>
																            </asp:ButtonColumn>
																            <asp:ButtonColumn ItemStyle-Width="160px" DataTextField="����Ŀ��" SortExpression="����Ŀ��" HeaderText="����Ŀ��" CommandName="Select">
																	            <HeaderStyle Width="160px"></HeaderStyle>
																            </asp:ButtonColumn>

																            <asp:ButtonColumn ItemStyle-Width="100px" DataTextField="��ͬ��־" SortExpression="��ͬ��־" HeaderText="��ͬ��־" CommandName="Select">
																	            <HeaderStyle Width="100px"></HeaderStyle>
																            </asp:ButtonColumn>
																            <asp:ButtonColumn ItemStyle-Width="140px" DataTextField="�������" SortExpression="�������" HeaderText="�������" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd}">
																	            <HeaderStyle Width="140px"></HeaderStyle>
																            </asp:ButtonColumn>
																            <asp:ButtonColumn ItemStyle-Width="140px" DataTextField="��������" SortExpression="��������" HeaderText="��������" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd}">
																	            <HeaderStyle Width="140px"></HeaderStyle>
																            </asp:ButtonColumn>
																            <asp:ButtonColumn ItemStyle-Width="160px" DataTextField="���˽��" SortExpression="���˽��" HeaderText="���˽��" CommandName="Select" DataTextFormatString="{0:#,##0.00}">
																	            <HeaderStyle Width="160px"></HeaderStyle>
																            </asp:ButtonColumn>
																            <asp:ButtonColumn ItemStyle-Width="100px" DataTextField="��ͬ���" SortExpression="��ͬ���" HeaderText="��ͬ���" CommandName="Select">
																	            <HeaderStyle Width="100px"></HeaderStyle>
																            </asp:ButtonColumn>
																            <asp:ButtonColumn ItemStyle-Width="100px" DataTextField="���˺�ͬ" SortExpression="���˺�ͬ" HeaderText="���˺�ͬ" CommandName="Select">
																	            <HeaderStyle Width="100px"></HeaderStyle>
																            </asp:ButtonColumn>

																            <asp:ButtonColumn ItemStyle-Width="140px" DataTextField="���޿�ʼ" SortExpression="���޿�ʼ" HeaderText="���޿�ʼ" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd}">
																	            <HeaderStyle Width="140px"></HeaderStyle>
																            </asp:ButtonColumn>
																            <asp:ButtonColumn ItemStyle-Width="140px" DataTextField="���޽���" SortExpression="���޽���" HeaderText="���޽���" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd}">
																	            <HeaderStyle Width="140px"></HeaderStyle>
																            </asp:ButtonColumn>
																            <asp:ButtonColumn ItemStyle-Width="140px" DataTextField="ˮ��ú��" SortExpression="ˮ��ú��" HeaderText="ˮ��ú��" CommandName="Select">
																	            <HeaderStyle Width="140px"></HeaderStyle>
																            </asp:ButtonColumn>
																            <asp:ButtonColumn ItemStyle-Width="140px" DataTextField="�绰��" SortExpression="�绰��" HeaderText="�绰��" CommandName="Select">
																	            <HeaderStyle Width="140px"></HeaderStyle>
																            </asp:ButtonColumn>
																            <asp:ButtonColumn ItemStyle-Width="140px" DataTextField="�����" SortExpression="�����" HeaderText="�����" CommandName="Select">
																	            <HeaderStyle Width="140px"></HeaderStyle>
																            </asp:ButtonColumn>
																            <asp:ButtonColumn ItemStyle-Width="140px" DataTextField="���޷�Ʊ" SortExpression="���޷�Ʊ" HeaderText="���޷�Ʊ" CommandName="Select">
																	            <HeaderStyle Width="140px"></HeaderStyle>
																            </asp:ButtonColumn>
                                                                        </Columns>
                                                                        
                                                                        <PagerStyle Visible="False" NextPageText="��ҳ" PrevPageText="��ҳ" HorizontalAlign="Right" ForeColor="Black" Position="TopAndBottom" BackColor="SkyBlue"></PagerStyle>
                                                                    </asp:datagrid><INPUT id="htxtHTFixed" type="hidden" value="0" runat="server" NAME="htxtHTFixed">
                                                                </DIV>
                                                            </TD>
                                                        </TR>
                                                        <TR>
                                                            <TD class="label">
                                                                <TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
                                                                    <TR>
                                                                        <TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZHTDeSelectAll" runat="server">��ѡ</asp:linkbutton></TD>
                                                                        <TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZHTSelectAll" runat="server">ȫѡ</asp:linkbutton></TD>
                                                                        <TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZHTMoveFirst" runat="server">��ǰ</asp:linkbutton></TD>
                                                                        <TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZHTMovePrev" runat="server">ǰҳ</asp:linkbutton></TD>
                                                                        <TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZHTMoveNext" runat="server">��ҳ</asp:linkbutton></TD>
                                                                        <TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZHTMoveLast" runat="server">���</asp:linkbutton></TD>
                                                                        <TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZHTGotoPage" runat="server">ǰ��</asp:linkbutton><asp:textbox id="txtHTPageIndex" runat="server" Columns="3" CssClass="textbox">1</asp:textbox>ҳ</TD>
                                                                        <TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZHTSetPageSize" runat="server">ÿҳ</asp:linkbutton><asp:textbox id="txtHTPageSize" runat="server" Columns="3" CssClass="textbox">30</asp:textbox>��</TD>
                                                                        <TD class="label" vAlign="middle" noWrap align="right"><asp:label id="lblHTGridLocInfo" runat="server" CssClass="label">1/10 N/15</asp:label></TD>
                                                                    </TR>
                                                                </TABLE>
                                                            </TD>
                                                        </TR>
                                                    </TABLE>
                                                    <% if propQRSH <> "" then response.write("</div>") %>
                                                </TD>
                                            </TR>
                                            <tr id="trRow3">
                                                <td>
                                                    <% if propQRSH = "" then response.write("<div style='display:none'>") %>
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
                                                    <% if propQRSH = "" then response.write("</div>") %>
                                                </td>
                                            </tr>
                                            <tr id="trRow4">
                                                <td>
                                                    <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                        <tr>
                                                            <td class="label" align="left" bgColor="#ccff99" colspan="8"><B>&gt;&gt;&gt;&gt;ָ����ͬ���ۿ��Լ������ۿ���˷�Χ</B></TD>
                                                        </tr>
                                                        <tr>
                                                            <td class="label" align="right" nowrap>��ͬ�ۿ�(%)</td>
                                                            <td align="left"><asp:TextBox ID="txtHTZK" Runat="server" CssClass="textbox" Columns="6" ReadOnly="True"></asp:TextBox></td>
                                                            <td class="label" align="right" nowrap>һ����˷�Χ(%)</td>
                                                            <td class="label" align="left"><asp:TextBox ID="txtYJ_Min" Runat="server" CssClass="textbox" Columns="6" ReadOnly="True"></asp:TextBox>~<asp:TextBox ID="txtYJ_Max" Runat="server" CssClass="textbox" Columns="6" ReadOnly="True"></asp:TextBox></td>
                                                            <td class="label" align="right" nowrap>������˷�Χ(%)</td>
                                                            <td class="label" align="left"><asp:TextBox ID="txtEJ_Min" Runat="server" CssClass="textbox" Columns="6" ReadOnly="True"></asp:TextBox>~<asp:TextBox ID="txtEJ_Max" Runat="server" CssClass="textbox" Columns="6" ReadOnly="True"></asp:TextBox></td>
                                                            <td class="label" align="right" nowrap>������˷�Χ(%)</td>
                                                            <td class="label" align="left"><asp:TextBox ID="txtSJ_Min" Runat="server" CssClass="textbox" Columns="6" ReadOnly="True"></asp:TextBox>~<asp:TextBox ID="txtSJ_Max" Runat="server" CssClass="textbox" Columns="6" ReadOnly="True"></asp:TextBox></td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <TR id="trRow5">
                                                <TD class="label" align="left" bgColor="#ccff99"><B>&gt;&gt;&gt;&gt;��ͬ�ۿ�������</B></TD>
                                            </TR>
                                            <TR>
                                                <TD>
                                                    <DIV id="divSHQK" style="BORDER-RIGHT: #99cccc 1px solid; TABLE-LAYOUT: fixed; BORDER-TOP: #99cccc 1px solid; OVERFLOW: auto; BORDER-LEFT: #99cccc 1px solid; WIDTH: 964px; CLIP: rect(0px 964px 134px 0px); BORDER-BOTTOM: #99cccc 1px solid; HEIGHT: 134px">
                                                        <asp:datagrid id="grdSHQK" runat="server" CssClass="label" UseAccessibleHeader="True" AllowPaging="False"
                                                            AutoGenerateColumns="False" GridLines="Vertical" BackColor="White" BorderStyle="None" PageSize="30"
                                                            BorderColor="#DEDFDE" BorderWidth="0px" AllowSorting="False" CellPadding="4">
                                                            <SelectedItemStyle Font-Bold="False" VerticalAlign="Middle" ForeColor="#CC0000" BackColor="#FFFFDD"></SelectedItemStyle>
                                                            <EditItemStyle VerticalAlign="Middle" BackColor="#FFCC00"></EditItemStyle>
                                                            <AlternatingItemStyle BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="White"></AlternatingItemStyle>
                                                            <ItemStyle BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="#F7F7F7" ForeColor="Black"></ItemStyle>
                                                            <HeaderStyle Font-Bold="True" ForeColor="White" VerticalAlign="Middle" BackColor="#6699cc" HorizontalAlign="Left"></HeaderStyle>
                                                            <FooterStyle BackColor="#CCCC99"></FooterStyle>
                                                            
                                                            <Columns>
                                                                <asp:TemplateColumn HeaderText="ѡ" Visible="False" ItemStyle-Width="20px">
                                                                    <HeaderStyle HorizontalAlign="Center" Width="20px"></HeaderStyle>
                                                                    <ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
                                                                    <ItemTemplate>
                                                                        <asp:CheckBox id="chkSHQK" runat="server" AutoPostBack="False" Visible="False"></asp:CheckBox>
                                                                    </ItemTemplate>
                                                                </asp:TemplateColumn>
                                                                <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="Ψһ��ʶ" SortExpression="Ψһ��ʶ" HeaderText="Ψһ��ʶ" CommandName="Select">
                                                                    <HeaderStyle Width="0px"></HeaderStyle>
                                                                </asp:ButtonColumn>
                                                                <asp:ButtonColumn ItemStyle-Width="320px" DataTextField="ȷ�����" SortExpression="ȷ�����" HeaderText="ȷ�����" CommandName="Select">
                                                                    <HeaderStyle Width="320px"></HeaderStyle>
                                                                </asp:ButtonColumn>
                                                                <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="�������" SortExpression="�������" HeaderText="���������" CommandName="Select">
                                                                    <HeaderStyle Width="0px"></HeaderStyle>
                                                                </asp:ButtonColumn>
                                                                <asp:ButtonColumn ItemStyle-Width="140px" DataTextField="�����������" SortExpression="�����������" HeaderText="�������" CommandName="Select">
                                                                    <HeaderStyle Width="140px"></HeaderStyle>
                                                                </asp:ButtonColumn>
                                                                <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="�������" SortExpression="�������" HeaderText="�������" CommandName="Select">
                                                                    <HeaderStyle Width="0px"></HeaderStyle>
                                                                </asp:ButtonColumn>
                                                                <asp:ButtonColumn ItemStyle-Width="240px" DataTextField="�������" SortExpression="�������" HeaderText="ǩ����" CommandName="Select">
                                                                    <HeaderStyle Width="240px"></HeaderStyle>
                                                                </asp:ButtonColumn>
                                                                <asp:ButtonColumn ItemStyle-Width="240px" DataTextField="�������" SortExpression="�������" HeaderText="ǩ������" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd}">
                                                                    <HeaderStyle Width="240px"></HeaderStyle>
                                                                </asp:ButtonColumn>
                                                            </Columns>
                                                            
                                                            <PagerStyle Visible="False" NextPageText="��ҳ" PrevPageText="��ҳ" HorizontalAlign="Right" ForeColor="Black" Position="TopAndBottom" BackColor="SkyBlue"></PagerStyle>
                                                        </asp:datagrid><INPUT id="htxtSHQKFixed" type="hidden" value="0" runat="server">
                                                    </DIV>
                                                </TD>
                                            </TR>
                                        </TABLE>
                                    </TD>
                                    <TD width="5"></TD>
                                </TR>
                            </TABLE>
                        </TD>
                        <TD width="5"></TD>
                    </TR>
                    <TR>
                        <TD colSpan="3" height="3"></TD>
                    </TR>
                    <TR id="trRow6">
                        <TD align="center" colSpan="3">
                            <TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
                                <TR>
                                    <TD height="4"></TD>
                                </TR>
                                <TR>
                                    <TD align="center">
                                        <asp:Button id="btnYJSH"   Runat="server" CssClass="button" Text="һ�����" Height="36px"></asp:Button>
                                        <asp:Button id="btnEJSH"   Runat="server" CssClass="button" Text="�������" Height="36px"></asp:Button>
                                        <asp:Button id="btnSJSH"   Runat="server" CssClass="button" Text="�������" Height="36px"></asp:Button>
                                        <asp:Button id="btnClose"  Runat="server" CssClass="button" Text="��    ��" Height="36px"></asp:Button>
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
                        <input id="htxtSessionIdQueryHT" type="hidden" runat="server">
                        <input id="htxtHTQuery" type="hidden" runat="server">
                        <input id="htxtHTRows" type="hidden" runat="server">
                        <input id="htxtHTSort" type="hidden" runat="server">
                        <input id="htxtHTSortColumnIndex" type="hidden" runat="server">
                        <input id="htxtHTSortType" type="hidden" runat="server">
                        <input id="htxtDivLeftSHQK" type="hidden" runat="server">
                        <input id="htxtDivTopSHQK" type="hidden" runat="server">
                        <input id="htxtDivLeftHT" type="hidden" runat="server">
                        <input id="htxtDivTopHT" type="hidden" runat="server">
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
							function ScrollProc_divHT() {
								var oText;
								oText=null;
								oText=document.getElementById("htxtDivTopHT");
								if (oText != null) oText.value = divHT.scrollTop;
								oText=null;
								oText=document.getElementById("htxtDivLeftHT");
								if (oText != null) oText.value = divHT.scrollLeft;
								return;
							}
							function ScrollProc_divSHQK() {
								var oText;
								oText=null;
								oText=document.getElementById("htxtDivTopSHQK");
								if (oText != null) oText.value = divSHQK.scrollTop;
								oText=null;
								oText=document.getElementById("htxtDivLeftSHQK");
								if (oText != null) oText.value = divSHQK.scrollLeft;
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
								oText=document.getElementById("htxtDivTopHT");
								if (oText != null) divHT.scrollTop = oText.value;
								oText=null;
								oText=document.getElementById("htxtDivLeftHT");
								if (oText != null) divHT.scrollLeft = oText.value;

								oText=null;
								oText=document.getElementById("htxtDivTopSHQK");
								if (oText != null) divSHQK.scrollTop = oText.value;
								oText=null;
								oText=document.getElementById("htxtDivLeftSHQK");
								if (oText != null) divSHQK.scrollLeft = oText.value;

								document.body.onscroll = ScrollProc_Body;
								divHT.onscroll = ScrollProc_divHT;
								divSHQK.onscroll = ScrollProc_divSHQK;
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
