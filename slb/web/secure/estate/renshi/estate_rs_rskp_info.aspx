<%@ Page Language="vb" AutoEventWireup="false" Codebehind="estate_rs_rskp_info.aspx.vb" Inherits="Josco.JSOA.web.estate_rs_rskp_info" %>
<%@ Register TagPrefix="uwin" Namespace="Josco.Web" Assembly="Josco.Web.PopMessage" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
    <HEAD>
        <title>�������ϲ鿴��༭��</title>
        <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
        <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
        <meta content="JavaScript" name="vs_defaultClientScript">
        <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <LINK href="../../../styles01.css" type="text/css" rel="stylesheet">
        <style>
			TD.grdJTCYLocked { ; LEFT: expression(divJTCY.scrollLeft); POSITION: relative }
			TH.grdJTCYLocked { ; LEFT: expression(divJTCY.scrollLeft); POSITION: relative }
			TH.grdJTCYLocked { Z-INDEX: 99 }
			TD.grdXXJLLocked { ; LEFT: expression(divXXJL.scrollLeft); POSITION: relative }
			TH.grdXXJLLocked { ; LEFT: expression(divXXJL.scrollLeft); POSITION: relative }
			TH.grdXXJLLocked { Z-INDEX: 99 }
			TD.grdGZJLLocked { ; LEFT: expression(divGZJL.scrollLeft); POSITION: relative }
			TH.grdGZJLLocked { ; LEFT: expression(divGZJL.scrollLeft); POSITION: relative }
			TH.grdGZJLLocked { Z-INDEX: 99 }
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
				intWidth  -= 16;                          //������
				strWidth   = intWidth.toString() + "px";
				
				intHeight  = document.body.clientHeight;  //�ܸ߶�
				intHeight -= 16;                          //������
				intHeight -= trRow1.clientHeight;
				intHeight -= trRow2.clientHeight;
				strHeight  = intHeight.toString() + "px";
				//if (document.readyState.toLowerCase() == "complete")
                //    alert(strWidth + " " + strHeight);

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
        <script language="javascript" event="onreadystatechange" for="document">
		<!--
			return document_onreadystatechange()
		//-->
        </script>
    </HEAD>
    <body onresize="javascript:window_onresize()" bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0">
        <form id="frmestate_rs_rskp_info" method="post" runat="server">
            <asp:panel id="panelMain" Runat="server">
                <TABLE cellSpacing="0" cellPadding="0" border="0">
                    <TR>
                        <TD class="title" id="trRow1" vAlign="middle" align="center" height="30">���¿�Ƭ����<asp:LinkButton id="lnkBlank" Runat="server" Width="0px"></asp:LinkButton></TD>
                    </TR>
                    <TR>
                        <TD vAlign="top" align="center">
                            <DIV id="divMain" style="BORDER-RIGHT: #99cccc 1px solid; BORDER-TOP: #99cccc 1px solid; OVERFLOW: auto; BORDER-LEFT: #99cccc 1px solid; WIDTH: 996px; CLIP: rect(0px 444px 996px 0px); BORDER-BOTTOM: #99cccc 1px solid; HEIGHT: 444px">
                                <TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
                                    <TR>
                                        <TD height="6"></TD>
                                    </TR>
                                    <TR>
                                        <TD align="center">
                                            <TABLE cellSpacing="0" cellPadding="0" border="1" bordercolordark="#66cccc" bordercolorlight="#ffffff">
                                                <TR>
                                                    <TD class="label" align="left" bgColor="#ccff99" colspan="14">>>>><b>��������</b></TD>
                                                </TR>
                                                <tr>
                                                    <td></td>
                                                    <td></td>
                                                    <td></td>
                                                    <td></td>
                                                    <td></td>
                                                    <td></td>
                                                    <td></td>
                                                    <td></td>
                                                    <td></td>
                                                    <td width="24"></td>
                                                    <td></td>
                                                    <td></td>
                                                    <td></td>
                                                    <td></td>
                                                </tr>
                                                <TR>
                                                    <TD vAlign="middle" align="center" rowSpan="11"><% response.write("<IMG height='240' src='" + propTPWZ + "' width='160' border='0'>") %><br><INPUT id="filePicture" type="file" runat="server" style="FONT-SIZE: 12px;" size="12"><br><asp:LinkButton id="lnkUpload" Runat="server" CssClass="button">�ϴ�ͼƬ</asp:LinkButton><INPUT id="htxtUploadFile" type="hidden" size="1" runat="server"><INPUT id="htxtRYXPWZ" type="hidden" size="1" runat="server"></TD>
                                                    <TD class="labelAuto" nowrap align="right">Ա����</TD>
                                                    <TD><asp:TextBox id="txtRYDM" Runat="server" Columns="10" ReadOnly="True" CssClass="textbox"></asp:TextBox><asp:Button id="btnSelect_RYDM" Runat="server" CssClass="button" Text="��"></asp:Button><input id="htxtWYBS" type="hidden" runat="server" size="1"></TD>
                                                    <TD class="labelNotNull" nowrap align="right">����</TD>
                                                    <TD colspan="2"><asp:TextBox id="txtRYXM" Runat="server" CssClass="textbox" Columns="10"></asp:TextBox></TD>
                                                    <TD class="labelNotNull" nowrap>�Ա�</TD>
                                                    <TD nowrap><asp:RadioButtonList id="rblRYXB" Runat="server" CssClass="textbox" RepeatLayout="Flow" RepeatDirection="Horizontal"
                                                            RepeatColumns="2">
                                                            <asp:ListItem Value="��">��</asp:ListItem>
                                                            <asp:ListItem Value="Ů">Ů</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </TD>
                                                    <TD class="labelNotNull" colSpan="2" nowrap align="right">��������</TD>
                                                    <TD><asp:TextBox id="txtCSNY" Runat="server" CssClass="textbox" Columns="10"></asp:TextBox></TD>
                                                    <TD class="label" nowrap align="right">����״��</TD>
                                                    <TD nowrap><asp:RadioButtonList id="rblHYZK" Runat="server" CssClass="textbox" RepeatLayout="Flow" RepeatDirection="Horizontal" RepeatColumns="2"><asp:ListItem Value="1">δ��</asp:ListItem><asp:ListItem Value="2">�ѻ�</asp:ListItem></asp:RadioButtonList></TD>
                                                    <td><asp:CheckBox id="chkHYZK" Runat="server" CssClass="textbox" Text="����" ></asp:CheckBox></td>
                                                </TR>
                                                <tr>
                                                    <td class="labelNotNull" align="right">����ʱ��</td>
                                                    <td><asp:TextBox ID="txtRBDWSJ" Runat="server" CssClass="textbox" Width="100%"></asp:TextBox></td>
                                                    <td class="label" align="right" nowrap>Ӣ����</td>
                                                    <td colspan="2"><asp:TextBox ID="txtYWM" Runat="server" CssClass="textbox" Width="100%"></asp:TextBox></td>
                                                    <td class="label">�ֻ�</td>
                                                    <td><asp:TextBox ID="txtSJHM" Runat="server" CssClass="textbox" Width="100%"></asp:TextBox></td>
                                                    <td class="label" colspan="2" align="right">סլ�绰</td>
                                                    <td><asp:TextBox ID="txtZZDH" Runat="server" CssClass="textbox" Width="100%"></asp:TextBox></td>
                                                    <td class="label" align="right">����״��</td>
                                                    <td colspan="2">
                                                        <asp:RadioButtonList id="rblSYZK" Runat="server" CssClass="textbox" RepeatLayout="Flow" RepeatDirection="Horizontal" RepeatColumns="2">
                                                            <asp:ListItem Value="1">δ��</asp:ListItem>
                                                            <asp:ListItem Value="2">����</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </td>
                                                </tr>
                                                <TR>
                                                    <TD class="label" nowrap align="right">ѧ��</TD>
                                                    <TD><asp:DropDownList id="ddlXL" Runat="server" CssClass="textbox" Width="100%"></asp:DropDownList></TD>
                                                    <TD class="label" nowrap align="right">ѧλ</TD>
                                                    <TD colspan="2"><asp:DropDownList id="ddlXW" Runat="server" CssClass="textbox" Width="100%"></asp:DropDownList></TD>
                                                    <TD class="label" nowrap>����</TD>
                                                    <TD><asp:TextBox id="txtMZ" Runat="server" CssClass="textbox" Width="100%"></asp:TextBox></TD>
                                                    <TD class="label" nowrap align="right">����</TD>
                                                    <TD colspan="2"><asp:TextBox id="txtJG" Runat="server" CssClass="textbox" Width="100%"></asp:TextBox></TD>
                                                    <TD class="label" align="right">������ַ</TD>
                                                    <TD colspan="2"><asp:TextBox id="txtHJDZ" Runat="server" CssClass="textbox" Width="100%"></asp:TextBox></TD>
                                                </TR>
                                                <TR>
                                                    <TD class="label" nowrap align="right">������Ŀ</TD>
                                                    <TD><asp:DropDownList id="ddlZZMM" Runat="server" CssClass="textbox" Width="100%"></asp:DropDownList></TD>
                                                    <TD class="label" colspan="2" nowrap align="right">�뵳��ʱ��</TD>
                                                    <TD colspan="2"><asp:TextBox id="txtRDSJ" Runat="server" CssClass="textbox" Width="100%"></asp:TextBox></TD>
                                                    <TD colspan="2" align="right">�μӹ���ʱ��</TD>
                                                    <TD colSpan="2"><asp:TextBox id="txtCJGZSJ" Runat="server" CssClass="textbox" Width="100%"></asp:TextBox></TD>
                                                    <TD align="right">���֤��</TD>
                                                    <td colspan="2"><asp:TextBox id="txtSFZH" Runat="server" CssClass="textbox" Width="100%"></asp:TextBox></td>
                                                </TR>
                                                <tr>
                                                    <td class="label" align="right">����ְ��</td>
                                                    <td><asp:DropDownList id="ddlJSZC" Runat="server" CssClass="textbox" Width="100%"></asp:DropDownList></td>
                                                    <td class="label" colspan="2" align="right">��֯��ϵ</td>
                                                    <td colspan="2"><asp:TextBox id="txtZZGX" Runat="server" CssClass="textbox" Width="100%"></asp:TextBox></td>
                                                    <td class="label" colspan="2" align="right">ְ��ȡ��ʱ��</td>
                                                    <td colspan="2"><asp:TextBox id="txtZCQDSJ" Runat="server" CssClass="textbox" Width="100%"></asp:TextBox></td>
                                                    <td class="label" align="right">��ְ��λ</td>
                                                    <td colspan="2"><asp:TextBox id="txtBM" Runat="server" Columns="20" ReadOnly="True" CssClass="textbox"></asp:TextBox><asp:Button id="btnSelect_BM" Runat="server" CssClass="button" Text="��"></asp:Button><input id="htxtBM" type="hidden" runat="server" size="1"></td>
                                                </tr>
                                                <TR>
                                                    <TD class="label" nowrap align="right">��������</TD>
                                                    <TD>
                                                        <asp:DropDownList id="ddlXXLX" Runat="server" CssClass="textbox" Width="100%">
                                                            <asp:ListItem Value="����">����</asp:ListItem>
                                                            <asp:ListItem Value="ְ��">ְ��</asp:ListItem>
                                                            <asp:ListItem Value="��ר">��ר</asp:ListItem>
                                                            <asp:ListItem Value="ȫ���ƴ�ר">ȫ���ƴ�ר</asp:ListItem>
                                                            <asp:ListItem Value="ҵ���ר">ҵ���ר</asp:ListItem>
                                                            <asp:ListItem Value="ȫ���ƴ�ѧ">ȫ���ƴ�ѧ</asp:ListItem>
                                                            <asp:ListItem Value="ҵ��ר����">ҵ��ר����</asp:ListItem>
                                                            <asp:ListItem Value="ȫ�����о���">ȫ�����о���</asp:ListItem>
                                                            <asp:ListItem Value="ҵ�๥���о���">ҵ�๥���о���</asp:ListItem>
                                                            <asp:ListItem Value="����">����</asp:ListItem>
                                                            <asp:ListItem Value="">����</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </TD>
                                                    <td class="label" colspan="2" align="right">��ҵԺУ</td>
                                                    <td colspan="3"><asp:TextBox id="txtBYYX" Runat="server" CssClass="textbox" Width="100%"></asp:TextBox></td>
                                                    <TD class="label" nowrap align="right">רҵ</TD>
                                                    <TD colspan="2"><asp:TextBox id="txtBYZY" Runat="server" CssClass="textbox" Width="100%"></asp:TextBox></TD>
                                                    <TD class="label" nowrap align="right">��ҵʱ��</TD>
                                                    <TD colspan="2"><asp:TextBox id="txtBYSJ" Runat="server" CssClass="textbox" Width="100%"></asp:TextBox></TD>
                                                </TR>
                                                <tr>
                                                    <td class="label" align="right">�����ʸ�</td>
                                                    <td colspan="5"><asp:DropDownList id="ddlZYZG" Runat="server" CssClass="textbox" Width="100%"></asp:DropDownList></td>
                                                    <TD class="label" colspan="2" nowrap align="right">�ʸ�ȡ��ʱ��</TD>
                                                    <TD colspan="2"><asp:TextBox id="txtZGQDSJ" Runat="server" CssClass="textbox" Width="100%"></asp:TextBox></TD>
                                                    <td class="label" nowrap align="right">�ʸ�֤��</td>
                                                    <td colspan="2"><asp:TextBox id="txtZJZG" Runat="server" CssClass="textbox" Width="100%"></asp:TextBox></td>
                                                </tr>
                                                <TR>
                                                    <TD class="label" nowrap align="right">�־ӵ�ַ</TD>
                                                    <TD colSpan="8"><asp:TextBox id="txtXZDZ" Runat="server" CssClass="textbox" Width="100%"></asp:TextBox></TD>
                                                    <TD class="label" nowrap align="right" rowspan="2">��ס���</TD>
                                                    <TD colSpan="3">
                                                        <asp:RadioButtonList id="rblZZQK1" Runat="server" CssClass="textbox" RepeatLayout="Flow" RepeatDirection="Horizontal" RepeatColumns="2">
                                                            <asp:ListItem Value="1">������ҵ</asp:ListItem>
                                                            <asp:ListItem Value="2">����</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </TD>
                                                </TR>
                                                <tr>
                                                    <td class="label" align="right">�������</td>
                                                    <td colspan="8">
                                                        <asp:RadioButtonList ID="rblHKZT" Runat="server" CssClass="textbox" RepeatColumns="4" RepeatDirection="Horizontal" RepeatLayout="Flow" Width="100%">
                                                            <asp:ListItem Value="0">ʡ�ڳ���</asp:ListItem>
                                                            <asp:ListItem Value="1">ʡ��ũ��</asp:ListItem>
                                                            <asp:ListItem Value="2">ʡ�����</asp:ListItem>
                                                            <asp:ListItem Value="3">ʡ��ũ��</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </td>
                                                    <td colspan="3">
                                                        <asp:RadioButtonList id="rblZZQK2" Runat="server" CssClass="textbox" RepeatLayout="Flow" RepeatDirection="Horizontal" RepeatColumns="2">
                                                            <asp:ListItem Value="4">��</asp:ListItem>
                                                            <asp:ListItem Value="8">�񰴽�</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="label" align="right">��������</td>
                                                    <td colspan="8">
                                                        <asp:RadioButtonList id="rblRYQYTX" Runat="server" CssClass="textbox" RepeatLayout="Flow" RepeatDirection="Horizontal" RepeatColumns="6" Width="100%">
                                                            <asp:ListItem Value="0">����</asp:ListItem>
                                                            <asp:ListItem Value="1">����</asp:ListItem>
                                                            <asp:ListItem Value="2">���</asp:ListItem>
                                                            <asp:ListItem Value="3">����</asp:ListItem>
                                                            <asp:ListItem Value="4">̨��</asp:ListItem>
                                                            <asp:ListItem Value="5">�⼮��Ա</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </td>
                                                    <td align="center"><asp:CheckBox id="chkSFGHCY" Runat="server" CssClass="textbox" Text="�����Ա"></asp:CheckBox></td>
                                                    <td colspan="3"><asp:CheckBox id="chkSFSGGB" Runat="server" CssClass="textbox" Text="�йܸɲ�"></asp:CheckBox>&nbsp;&nbsp;<asp:CheckBox id="chkSFJZGB" Runat="server" CssClass="textbox" Text="��ת�ɲ�"></asp:CheckBox></td>
                                                </tr>
                                                <TR>
                                                    <TD class="label" nowrap align="right">�ʼĵ�ַ</TD>
                                                    <TD colSpan="8"><asp:TextBox id="txtYJDZ" Runat="server" CssClass="textbox" Width="100%"></asp:TextBox></TD>
                                                    <td class="label" align="right">��������ʱ��</TD>
                                                    <td class="label" align="left" colspan="3"><asp:TextBox ID="txtTXSJ" Runat="server" CssClass="textbox" Columns="14"></asp:TextBox></td>
                                                </TR>
                                                <TR>
                                                    <TD class="label" align="left" bgColor="#ccff99" colspan="14">>>>><b>��ͥ��Ա</b></TD>
                                                </TR>
                                                <TR>
                                                    <TD colspan="14">
                                                        <TABLE cellSpacing="0" cellPadding="0" border="0">
                                                            <TR>
                                                                <TD width="140"><asp:CheckBox id="chkBRSDSZ" Runat="server" CssClass="textbox" Text="�����Ƕ�����Ů"></asp:CheckBox></TD>
                                                                <TD width="140"><asp:CheckBox id="chkSFLDSZ" Runat="server" CssClass="textbox" Text="����ȡ������Ů"></asp:CheckBox></TD>
                                                            </TR>
                                                        </TABLE>
                                                    </TD>
                                                </TR>
                                                <TR>
                                                    <TD align="left" colspan="14">
                                                        <DIV id="divJTCY" style="OVERFLOW: auto; WIDTH: 962px; CLIP: rect(0px 962px 240px 0px); HEIGHT: 240px">
                                                            <asp:datagrid id="grdJTCY" runat="server" CssClass="label" Font-Size="11pt" UseAccessibleHeader="True"
                                                                AutoGenerateColumns="False" GridLines="Vertical" BorderStyle="None" CellPadding="4"
                                                                AllowPaging="False" PageSize="30" BorderColor="#DEDFDE" BorderWidth="0px" AllowSorting="False"
                                                                Font-Names="����" Width="100%">
                                                                <SelectedItemStyle Font-Size="11pt" Font-Names="����" Font-Bold="False" VerticalAlign="Middle" ForeColor="#CC0000" BackColor="#FFFFDD"></SelectedItemStyle>
                                                                <EditItemStyle Font-Size="11pt" Font-Names="����" VerticalAlign="Middle" BackColor="#FFCC00"></EditItemStyle>
                                                                <AlternatingItemStyle Font-Size="11pt" Font-Names="����" BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="White"></AlternatingItemStyle>
                                                                <ItemStyle Font-Size="11pt" Font-Names="����" BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="#F7F7F7" ForeColor="Black"></ItemStyle>
                                                                <HeaderStyle Font-Size="11pt" Font-Names="����" Font-Bold="True" ForeColor="White" VerticalAlign="Middle" BackColor="#87cefa" HorizontalAlign="Left"></HeaderStyle>
                                                                <FooterStyle BackColor="#CCCC99"></FooterStyle>
                                                                
                                                                <Columns>
                                                                    <asp:TemplateColumn HeaderText="ѡ" ItemStyle-Width="20px">
                                                                        <HeaderStyle HorizontalAlign="Center" Width="20px"></HeaderStyle>
                                                                        <ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox id="chkJTCY" runat="server" AutoPostBack="False"></asp:CheckBox>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="Ψһ��ʶ" SortExpression="Ψһ��ʶ" HeaderText="Ψһ��ʶ" CommandName="Select">
                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="��Ա����" SortExpression="��Ա����" HeaderText="��Ա����" CommandName="Select">
                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:TemplateColumn HeaderText="�뱾�˹�ϵ" ItemStyle-Width="100px">
                                                                        <HeaderStyle HorizontalAlign="Center" Width="100px"></HeaderStyle>
                                                                        <ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
                                                                        <ItemTemplate>
                                                                            <asp:DropDownList ID="ddlJTCY_XYGX" Runat="server" CssClass="textbox" Width="100%">
                                                                                <asp:ListItem Value="��ż">��ż</asp:ListItem>
                                                                                <asp:ListItem Value="ĸ��">ĸ��</asp:ListItem>
                                                                                <asp:ListItem Value="����">����</asp:ListItem>
                                                                                <asp:ListItem Value="����">����</asp:ListItem>
                                                                                <asp:ListItem Value="Ů��">Ů��</asp:ListItem>
                                                                                <asp:ListItem Value="�ֳ�">�ֳ�</asp:ListItem>
                                                                                <asp:ListItem Value="�ܵ�">�ܵ�</asp:ListItem>
                                                                                <asp:ListItem Value="���">���</asp:ListItem>
                                                                                <asp:ListItem Value="����">����</asp:ListItem>
                                                                                <asp:ListItem Value="">����</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn HeaderText="����" ItemStyle-Width="90px">
                                                                        <HeaderStyle HorizontalAlign="Center" Width="90px"></HeaderStyle>
                                                                        <ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
                                                                        <ItemTemplate>
                                                                            <asp:TextBox ID="txtJTCY_CYXM" Runat="server" CssClass="textbox" Width="100%"></asp:TextBox>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn HeaderText="��������" ItemStyle-Width="90px">
                                                                        <HeaderStyle HorizontalAlign="Center" Width="90px"></HeaderStyle>
                                                                        <ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
                                                                        <ItemTemplate>
                                                                            <asp:TextBox ID="txtJTCY_CSNY" Runat="server" CssClass="textbox" Width="100%"></asp:TextBox>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn HeaderText="��(������/�ѹ�ǰ)����λ" ItemStyle-Width="260px">
                                                                        <HeaderStyle HorizontalAlign="Center" Width="260px"></HeaderStyle>
                                                                        <ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
                                                                        <ItemTemplate>
                                                                            <asp:TextBox ID="txtJTCY_FWDW" Runat="server" CssClass="textbox" Width="100%"></asp:TextBox>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn HeaderText="ְ�񣨻�����/�ѹʣ�" ItemStyle-Width="220px">
                                                                        <HeaderStyle HorizontalAlign="Center" Width="220px"></HeaderStyle>
                                                                        <ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
                                                                        <ItemTemplate>
                                                                            <asp:TextBox ID="txtJTCY_DRZW" Runat="server" CssClass="textbox" Width="100%"></asp:TextBox>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn HeaderText="�־�ס��" ItemStyle-Width="130px">
                                                                        <HeaderStyle HorizontalAlign="Center" Width="130px"></HeaderStyle>
                                                                        <ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
                                                                        <ItemTemplate>
                                                                            <asp:TextBox ID="txtJTCY_XZDZ" Runat="server" CssClass="textbox" Width="100%"></asp:TextBox>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                </Columns>
                                                                <PagerStyle Visible="False" NextPageText="��ҳ" Font-Size="11pt" Font-Names="����" PrevPageText="��ҳ" HorizontalAlign="Right" ForeColor="Black" Position="TopAndBottom" BackColor="SkyBlue"></PagerStyle>
                                                            </asp:datagrid><INPUT id="htxtJTCYFixed" type="hidden" value="0" runat="server">
                                                        </DIV>
                                                    </TD>
                                                </TR>
                                                <TR>
                                                    <TD align="right" colspan="14"><asp:Button id="btnAddNew_JTCY" Runat="server" CssClass="button" Text="�����µļ�ͥ��Ա"></asp:Button><asp:Button id="btnDelete_JTCY" Runat="server" CssClass="button" Text="ɾ��ѡ����ͥ��Ա"></asp:Button></TD>
                                                </TR>
                                                <TR>
                                                    <TD colspan="14" width="100%">
                                                        <TABLE cellSpacing="0" cellPadding="0" border="1" bordercolordark="#66cccc" bordercolorlight="#ffffff">
                                                            <TR>
                                                                <TD class="label" width="140" nowrap>���˷������</TD>                                                               
                                                                
                                                                <TD class="label" nowrap>&nbsp;&nbsp;��������</td>
                                                                 <TD class="label" nowrap>
                                                                    <asp:RadioButtonList id="rblGRFYZT" Runat="server" CssClass="textbox" RepeatColumns="4" RepeatDirection="Horizontal" RepeatLayout="Flow" Width="100%">
                                                                        <asp:ListItem Value="0">��</asp:ListItem>
                                                                        <asp:ListItem Value="1">����</asp:ListItem>
                                                                        <asp:ListItem Value="2">תҵ</asp:ListItem>
                                                                        <asp:ListItem Value="3">��Ա</asp:ListItem>
                                                                    </asp:RadioButtonList>
                                                                </TD>
                                                                
                                                                <TD class="label" nowrap>&nbsp;&nbsp;����ʱ��</td>
                                                                <TD class="label" width="240" nowrap><asp:TextBox id="txtGRFYKS" Runat="server" CssClass="textbox" Width="110px"></asp:TextBox>~<asp:TextBox id="txtGRFYJS" Runat="server" CssClass="textbox" Width="110px"></asp:TextBox></TD>
                                                                
                                                                <TD class="label" nowrap>&nbsp;&nbsp;����˵��</td>
                                                                <TD class="label" width="100%"><asp:TextBox id="txtGRFYSM" Runat="server" CssClass="textbox" Width="100%"></asp:TextBox></TD>
                                                            </TR>
                                                            <TR>
                                                                <TD class="label" width="140" nowrap>��ͥ��Ҫ��Ա�������</TD>
                                                                <TD class="label" nowrap>&nbsp;&nbsp;��������</td>
                                                                <TD class="label" nowrap>
                                                                    <asp:RadioButtonList id="rblCYFYZT" Runat="server" CssClass="textbox" RepeatColumns="4" RepeatDirection="Horizontal" RepeatLayout="Flow" Width="100%">
                                                                        <asp:ListItem Value="0">��</asp:ListItem>
                                                                        <asp:ListItem Value="1">����</asp:ListItem>
                                                                        <asp:ListItem Value="2">תҵ</asp:ListItem>
                                                                        <asp:ListItem Value="3">��Ա</asp:ListItem>
                                                                    </asp:RadioButtonList>
                                                                </TD>
                                                                <TD class="label" nowrap>&nbsp;&nbsp;����˵��</td>
                                                                <TD colspan =3><asp:TextBox id="txtCYFYSM" Runat="server" CssClass="textbox" Width="100%"></asp:TextBox></TD>
                                                            </TR>
                                                        </TABLE>
                                                    </TD>
                                                </TR>
                                                <TR>
                                                    <TD class="label" align="left" bgColor="#ccff99" colspan="14">>>>><b>ѧϰ����</b></TD>
                                                </TR>
                                                <TR>
                                                    <TD align="left" colspan="14">
                                                        <DIV id="divXXJL" style="OVERFLOW: auto; WIDTH: 962px; CLIP: rect(0px 962px 240px 0px); HEIGHT: 240px">
                                                            <asp:datagrid id="grdXXJL" runat="server" CssClass="label" Font-Size="11pt" UseAccessibleHeader="True"
                                                                AutoGenerateColumns="False" GridLines="Vertical" BorderStyle="None" CellPadding="4"
                                                                AllowPaging="False" PageSize="30" BorderColor="#DEDFDE" BorderWidth="0px" AllowSorting="False"
                                                                Font-Names="����" Width="100%">
                                                                <SelectedItemStyle Font-Size="11pt" Font-Names="����" Font-Bold="False" VerticalAlign="Middle" ForeColor="#CC0000" BackColor="#FFFFDD"></SelectedItemStyle>
                                                                <EditItemStyle Font-Size="11pt" Font-Names="����" VerticalAlign="Middle" BackColor="#FFCC00"></EditItemStyle>
                                                                <AlternatingItemStyle Font-Size="11pt" Font-Names="����" BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="White"></AlternatingItemStyle>
                                                                <ItemStyle Font-Size="11pt" Font-Names="����" BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="#F7F7F7" ForeColor="Black"></ItemStyle>
                                                                <HeaderStyle Font-Size="11pt" Font-Names="����" Font-Bold="True" ForeColor="White" VerticalAlign="Middle" BackColor="#87cefa" HorizontalAlign="Left"></HeaderStyle>
                                                                <FooterStyle BackColor="#CCCC99"></FooterStyle>
                                                                <Columns>
                                                                    <asp:TemplateColumn HeaderText="ѡ" ItemStyle-Width="20px">
                                                                        <HeaderStyle HorizontalAlign="Center" Width="20px"></HeaderStyle>
                                                                        <ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox id="chkXXJL" runat="server" AutoPostBack="False"></asp:CheckBox>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="0px" Visible="False" DataTextField="Ψһ��ʶ" SortExpression="Ψһ��ʶ" HeaderText="Ψһ��ʶ" CommandName="Select">
                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="0px" Visible="False" DataTextField="��Ա����" SortExpression="��Ա����" HeaderText="��Ա����" CommandName="Select">
                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:TemplateColumn HeaderText="ѧϰ����" ItemStyle-Width="140px">
                                                                        <HeaderStyle HorizontalAlign="Center" Width="140px"></HeaderStyle>
                                                                        <ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
                                                                        <ItemTemplate>
                                                                            <asp:DropDownList ID="ddlXXJL_XXLX" Runat="server" CssClass="textbox" Width="100%">
                                                                                <asp:ListItem Value="����">����</asp:ListItem>
                                                                                <asp:ListItem Value="ְ��">ְ��</asp:ListItem>
                                                                                <asp:ListItem Value="��ר">��ר</asp:ListItem>
                                                                                <asp:ListItem Value="ȫ���ƴ�ר">ȫ���ƴ�ר</asp:ListItem>
                                                                                <asp:ListItem Value="ҵ���ר">ҵ���ר</asp:ListItem>
                                                                                <asp:ListItem Value="ȫ���ƴ�ѧ">ȫ���ƴ�ѧ</asp:ListItem>
                                                                                <asp:ListItem Value="ҵ��ר����">ҵ��ר����</asp:ListItem>
                                                                                <asp:ListItem Value="ȫ�����о���">ȫ�����о���</asp:ListItem>
                                                                                <asp:ListItem Value="ҵ�๥���о���">ҵ�๥���о���</asp:ListItem>
                                                                                <asp:ListItem Value="����">����</asp:ListItem>
                                                                                <asp:ListItem Value="">����</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn HeaderText="��ʼ����" ItemStyle-Width="100px">
                                                                        <HeaderStyle HorizontalAlign="Center" Width="100px"></HeaderStyle>
                                                                        <ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
                                                                        <ItemTemplate>
                                                                            <asp:TextBox ID="txtXXJL_KSSJ" Runat="server" CssClass="textbox" Width="100%"></asp:TextBox>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn HeaderText="��ֹ����" ItemStyle-Width="100px">
                                                                        <HeaderStyle HorizontalAlign="Center" Width="100px"></HeaderStyle>
                                                                        <ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
                                                                        <ItemTemplate>
                                                                            <asp:TextBox ID="txtXXJL_JSSJ" Runat="server" CssClass="textbox" Width="100%"></asp:TextBox>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn HeaderText="ѧϰԺУ" ItemStyle-Width="240px">
                                                                        <HeaderStyle HorizontalAlign="Center" Width="240px"></HeaderStyle>
                                                                        <ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
                                                                        <ItemTemplate>
                                                                            <asp:TextBox ID="txtXXJL_XXYX" Runat="server" CssClass="textbox" Width="100%"></asp:TextBox>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn HeaderText="רҵ" ItemStyle-Width="180px">
                                                                        <HeaderStyle HorizontalAlign="Center" Width="180px"></HeaderStyle>
                                                                        <ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
                                                                        <ItemTemplate>
                                                                            <asp:TextBox ID="txtXXJL_XXZY" Runat="server" CssClass="textbox" Width="100%"></asp:TextBox>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn HeaderText="���" ItemStyle-Width="100px">
                                                                        <HeaderStyle HorizontalAlign="Center" Width="100px"></HeaderStyle>
                                                                        <ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
                                                                        <ItemTemplate>
                                                                            <asp:DropDownList ID="ddlXXJL_XXJG" Runat="server" CssClass="textbox" Width="100%">
                                                                                <asp:ListItem Value="��ҵ">��ҵ</asp:ListItem>
                                                                                <asp:ListItem Value="��ҵ">��ҵ</asp:ListItem>
                                                                                <asp:ListItem Value="ȫ�����ڶ�">ȫ�����ڶ�</asp:ListItem>
                                                                                <asp:ListItem Value="ҵ���ڶ�">ҵ���ڶ�</asp:ListItem>
                                                                                <asp:ListItem Value="">����</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                </Columns>
                                                                <PagerStyle Visible="False" NextPageText="��ҳ" Font-Size="11pt" Font-Names="����" PrevPageText="��ҳ" HorizontalAlign="Right" ForeColor="Black" Position="TopAndBottom" BackColor="SkyBlue"></PagerStyle>
                                                            </asp:datagrid><INPUT id="htxtXXJLFixed" type="hidden" value="0" runat="server">
                                                        </DIV>
                                                    </TD>
                                                </TR>
                                                <TR>
                                                    <TD align="right" colspan="14"><asp:Button id="btnAddNew_XXJL" Runat="server" CssClass="button" Text="�����µ�ѧϰ����"></asp:Button><asp:Button id="btnDelete_XXJL" Runat="server" CssClass="button" Text="ɾ��ѡ��ѧϰ����"></asp:Button></TD>
                                                </TR>
                                                <TR>
                                                    <TD class="label" align="left" bgColor="#ccff99" colspan="14">>>>><b>��������</b></TD>
                                                </TR>
                                                <TR>
                                                    <TD align="left" colspan="14">
                                                        <DIV id="divGZJL" style="OVERFLOW: auto; WIDTH: 962px; CLIP: rect(0px 962px 240px 0px); HEIGHT: 240px">
                                                            <asp:datagrid id="grdGZJL" runat="server" CssClass="label" Font-Size="11pt" UseAccessibleHeader="True"
                                                                AutoGenerateColumns="False" GridLines="Vertical" BackColor="White" BorderStyle="None" CellPadding="4"
                                                                AllowPaging="False" PageSize="30" BorderColor="#DEDFDE" BorderWidth="0px" AllowSorting="False"
                                                                Font-Names="����" Width="100%">
                                                                <SelectedItemStyle Font-Size="11pt" Font-Names="����" Font-Bold="False" VerticalAlign="Middle" ForeColor="#CC0000" BackColor="#FFFFDD"></SelectedItemStyle>
                                                                <EditItemStyle Font-Size="11pt" Font-Names="����" VerticalAlign="Middle" BackColor="#FFCC00"></EditItemStyle>
                                                                <AlternatingItemStyle Font-Size="11pt" Font-Names="����" BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="White"></AlternatingItemStyle>
                                                                <ItemStyle Font-Size="11pt" Font-Names="����" BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="#F7F7F7" ForeColor="Black"></ItemStyle>
                                                                <HeaderStyle Font-Size="11pt" Font-Names="����" Font-Bold="True" ForeColor="White" VerticalAlign="Middle" BackColor="#87cefa" HorizontalAlign="Left"></HeaderStyle>
                                                                <FooterStyle BackColor="#CCCC99"></FooterStyle>
                                                                <Columns>
                                                                    <asp:TemplateColumn HeaderText="ѡ" ItemStyle-Width="20px">
                                                                        <HeaderStyle HorizontalAlign="Center" Width="20px"></HeaderStyle>
                                                                        <ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox id="chkGZJL" runat="server" AutoPostBack="False"></asp:CheckBox>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="0px" Visible="False" DataTextField="Ψһ��ʶ" SortExpression="Ψһ��ʶ" HeaderText="Ψһ��ʶ" CommandName="Select">
                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:ButtonColumn ItemStyle-Width="0px" Visible="False" DataTextField="��Ա����" SortExpression="��Ա����" HeaderText="��Ա����" CommandName="Select">
                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                    </asp:ButtonColumn>
                                                                    <asp:TemplateColumn HeaderText="��ʼ����" ItemStyle-Width="120px">
                                                                        <HeaderStyle HorizontalAlign="Center" Width="120px"></HeaderStyle>
                                                                        <ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
                                                                        <ItemTemplate>
                                                                            <asp:TextBox ID="txtGZJL_KSSJ" Runat="server" CssClass="textbox" Width="100%"></asp:TextBox>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn HeaderText="��ֹ����" ItemStyle-Width="120px">
                                                                        <HeaderStyle HorizontalAlign="Center" Width="120px"></HeaderStyle>
                                                                        <ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
                                                                        <ItemTemplate>
                                                                            <asp:TextBox ID="txtGZJL_JSSJ" Runat="server" CssClass="textbox" Width="100%"></asp:TextBox>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn HeaderText="����λ" ItemStyle-Width="360px">
                                                                        <HeaderStyle HorizontalAlign="Center" Width="360px"></HeaderStyle>
                                                                        <ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
                                                                        <ItemTemplate>
                                                                            <asp:TextBox ID="txtGZJL_FWDW" Runat="server" CssClass="textbox" Width="100%"></asp:TextBox>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                    <asp:TemplateColumn HeaderText="����ְ��" ItemStyle-Width="260px">
                                                                        <HeaderStyle HorizontalAlign="Center" Width="260px"></HeaderStyle>
                                                                        <ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
                                                                        <ItemTemplate>
                                                                            <asp:TextBox ID="txtGZJL_DRZW" Runat="server" CssClass="textbox" Width="100%"></asp:TextBox>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateColumn>
                                                                </Columns>
                                                                <PagerStyle Visible="False" NextPageText="��ҳ" Font-Size="11pt" Font-Names="����" PrevPageText="��ҳ" HorizontalAlign="Right" ForeColor="Black" Position="TopAndBottom" BackColor="SkyBlue"></PagerStyle>
                                                            </asp:datagrid><INPUT id="htxtGZJLFixed" type="hidden" value="0" runat="server">
                                                        </DIV>
                                                    </TD>
                                                </TR>
                                                <TR>
                                                    <TD align="right" colspan="14"><asp:Button id="btnAddNew_GZJL" Runat="server" CssClass="button" Text="�����µĹ�������"></asp:Button><asp:Button id="btnDelete_GZJL" Runat="server" CssClass="button" Text="ɾ��ѡ����������"></asp:Button></TD>
                                                </TR>
                                            </TABLE>
                                        </TD>
                                    </TR>
                                    <TR>
                                        <TD height="6"></TD>
                                    </TR>
                                </TABLE>
                            </DIV>
                        </TD>
                    </TR>
                    <TR id="trRow2">
                        <TD style="BORDER-TOP: #99cccc 2px solid" vAlign="middle" align="center">
                            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                <tr>
                                    <td colspan="4" height="3"></td>
                                </tr>
                                <tr height="20" valign="middle">
                                    <td><asp:LinkButton ID="lnkML_PXJL" Runat="server" CssClass="button">��Ա��ѵ��¼</asp:LinkButton></td>
                                    <td><asp:LinkButton ID="lnkML_YDJL" Runat="server" CssClass="button">��Ա��ְ��¼</asp:LinkButton></td>
                                    <td><asp:LinkButton ID="lnkML_LDHT" Runat="server" CssClass="button">��Ա�Ͷ���ͬ</asp:LinkButton></td>
                                </tr>
                                <tr height="36">
                                    <td align="center" colspan="3">
                                        <asp:Button id="btnOK"     Runat="server" CssClass="button" Text=" ��  �� " Height="32px" Font-Name="����" Font-Size="11pt"></asp:Button>
                                        <asp:Button id="btnCancel" Runat="server" CssClass="button" Text=" ȡ  �� " Height="32px" Font-Name="����" Font-Size="11pt"></asp:Button>
                                        <asp:Button id="btnClose"  Runat="server" CssClass="button" Text=" ��  �� " Height="32px" Font-Name="����" Font-Size="11pt"></asp:Button>
                                    </td>
                                </tr>
                            </table>
                        </TD>
                    </TR>
                </TABLE>
            </asp:panel>
            <asp:panel id="panelError" Runat="server">
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
            </asp:panel>
            <table cellSpacing="0" cellPadding="0" align="center" border="0">
                <tr>
                    <td>
                        <input id="htxtSessionId_GZJL" type="hidden" runat="server">
                        <input id="htxtSessionId_XXJL" type="hidden" runat="server">
                        <input id="htxtSessionId_JTCY" type="hidden" runat="server">
                        <input id="htxtDivLeftGZJL" type="hidden" runat="server">
                        <input id="htxtDivTopGZJL" type="hidden" runat="server">
                        <input id="htxtDivLeftXXJL" type="hidden" runat="server">
                        <input id="htxtDivTopXXJL" type="hidden" runat="server">
                        <input id="htxtDivLeftJTCY" type="hidden" runat="server">
                        <input id="htxtDivTopJTCY" type="hidden" runat="server">
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
							function ScrollProc_divJTCY() {
								var oText;
								oText=null;
								oText=document.getElementById("htxtDivTopJTCY");
								if (oText != null) oText.value = divJTCY.scrollTop;
								oText=null;
								oText=document.getElementById("htxtDivLeftJTCY");
								if (oText != null) oText.value = divJTCY.scrollLeft;
								return;
							}
							function ScrollProc_divXXJL() {
								var oText;
								oText=null;
								oText=document.getElementById("htxtDivTopXXJL");
								if (oText != null) oText.value = divXXJL.scrollTop;
								oText=null;
								oText=document.getElementById("htxtDivLeftXXJL");
								if (oText != null) oText.value = divXXJL.scrollLeft;
								return;
							}
							function ScrollProc_divGZJL() {
								var oText;
								oText=null;
								oText=document.getElementById("htxtDivTopGZJL");
								if (oText != null) oText.value = divGZJL.scrollTop;
								oText=null;
								oText=document.getElementById("htxtDivLeftGZJL");
								if (oText != null) oText.value = divGZJL.scrollLeft;
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
								oText=document.getElementById("htxtDivTopJTCY");
								if (oText != null) divJTCY.scrollTop = oText.value;
								oText=null;
								oText=document.getElementById("htxtDivLeftJTCY");
								if (oText != null) divJTCY.scrollLeft = oText.value;

								oText=null;
								oText=document.getElementById("htxtDivTopXXJL");
								if (oText != null) divXXJL.scrollTop = oText.value;
								oText=null;
								oText=document.getElementById("htxtDivLeftXXJL");
								if (oText != null) divXXJL.scrollLeft = oText.value;

								oText=null;
								oText=document.getElementById("htxtDivTopGZJL");
								if (oText != null) divGZJL.scrollTop = oText.value;
								oText=null;
								oText=document.getElementById("htxtDivLeftGZJL");
								if (oText != null) divGZJL.scrollLeft = oText.value;

								document.body.onscroll = ScrollProc_Body;
								divMain.onscroll = ScrollProc_divMain;
								divJTCY.onscroll = ScrollProc_divJTCY;
								divXXJL.onscroll = ScrollProc_divXXJL;
								divGZJL.onscroll = ScrollProc_divGZJL;
							}
							catch (e) {}
                        </script>
                    </td>
                </tr>
                <tr>
                    <td>
                        <script language="javascript">window_onresize();</script>
                        <uwin:popmessage id="popMessageObject" runat="server" EnableViewState="False" PopupWindowType="Normal" ActionType="OpenWindow" Visible="False" width="96px" height="48px"></uwin:popmessage></td>
                </tr>
            </table>
        </form>
    </body>
</HTML>
