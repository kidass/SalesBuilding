<%@ Page Language="vb" AutoEventWireup="false" Codebehind="estate_es_qrsqt_wuye.aspx.vb" Inherits="Josco.JSOA.web.estate_es_qrsqt_wuye" %>
<%@ Register TagPrefix="uwin" Namespace="Josco.Web" Assembly="Josco.Web.PopMessage" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
    <HEAD>
        <title>����ȷ������ҵ��Ϣ�鿴��༭</title>
        <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
        <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
        <meta content="JavaScript" name="vs_defaultClientScript">
        <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <LINK href="../../../styles01.css" type="text/css" rel="stylesheet">
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
				intHeight -= trRow1.clientHeight;
				intHeight -= trRow2.clientHeight;
				strHeight  = intHeight.toString() + "px";
				//if (document.readyState.toLowerCase() == "complete")
                //    alert(strWidth + " " + strHeight);

				divMain.style.width  = strWidth;
				divMain.style.height = strHeight;
				divMain.style.clip   = "rect(0px " + strWidth + " " + strHeight + " 0px)";
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
        <form id="frmestate_es_qrsqt_wuye" method="post" runat="server">
            <asp:panel id="panelMain" Runat="server">
                <TABLE cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
                    <TR id="trRow1">
                        <TD align="center">
                            <TABLE cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
                                <TR>
                                    <TD class="title" align="center">����ҵ���ȷ������ҵ��Ϣ�鿴��༭<asp:LinkButton id="lnkBlank" Runat="server" Width="0px"></asp:LinkButton></TD>
                                    <TD width="20">&nbsp;</TD>
                                </TR>
                                <TR>
                                    <TD class="labelNotNull" vAlign="middle" align="right">ȷ����ţ�<asp:TextBox id="txtQRSH" runat="server" CssClass="textbox" Columns="14"></asp:TextBox><INPUT id="htxtWYBS" type="hidden" size="1" runat="server" NAME="htxtWYBS"><INPUT id="htxtWYBM" type="hidden" size="1" runat="server" NAME="htxtWYBM"></TD>
                                    <TD width="20">&nbsp;</TD>
                                </TR>
                            </TABLE>
                        </TD>
                    </TR>
                    <TR>
                        <TD align="center">
                            <DIV id="divMain" style="BORDER-TOP: #99cccc 2px solid; OVERFLOW: auto; WIDTH: 964px; CLIP: rect(0px 964px 447px 0px); BORDER-BOTTOM: #99cccc 2px solid; HEIGHT: 447px">
                                <TABLE>
                                    <TR>
                                        <TD>
                                            <TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
                                                <tr height="26" valign="middle">
                                                    <td class="labelNotNull" align="right">��Դ��ţ�</td>
                                                    <TD width="8">&nbsp;</TD>
                                                    <TD align="left" colspan="4"><asp:TextBox id="txtFYBH" runat="server" CssClass="textbox" Width="300px"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;<span class="label">����֤�ţ�</span><asp:TextBox id="txtFCZH" runat="server" CssClass="textbox" Columns="54"></asp:TextBox></TD>
                                                </tr>
                                                <tr height="26" valign="middle">
                                                    <TD class="labelNotNull" align="right">���ݵ�ַ��</TD>
                                                    <TD width="8">&nbsp;</TD>
                                                    <TD align="left" colspan="4"><asp:TextBox id="txtFWDZ" runat="server" CssClass="textbox" Width="300px"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;<span class="label">��Ȩ��ַ��</span><asp:TextBox id="txtFCZDZ" runat="server" CssClass="textbox" Columns="54"></asp:TextBox></TD>
                                                </TR>
                                                <tr height="26" valign="middle">
                                                    <td class="labelNotNull" align="right">¥�����ƣ�</td>
                                                    <TD width="8">&nbsp;</TD>
                                                    <TD align="left" colspan="4"><asp:TextBox id="txtLP" runat="server" CssClass="textbox" Width="300px"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;<span class="labelNotNull">����</span><asp:TextBox id="txtLD" runat="server" CssClass="textbox" Columns="30"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;<span class="labelNotNull">��Ԫ��</span><asp:TextBox id="txtDY" runat="server" CssClass="textbox" Columns="24"></asp:TextBox></TD>
                                                </tr>
                                                <tr height="26" valign="middle">
                                                    <TD class="labelNotNull" align="right">��������</TD>
                                                    <TD width="8">&nbsp;</TD>
                                                    <TD align="left" colspan="4"><asp:DropDownList id="ddlSZQY" runat="server" CssClass="textbox" Width="300px"></asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp;<span class="labelNotNull">���������</span><asp:TextBox id="txtMJ" runat="server" CssClass="textbox" Columns="24"></asp:TextBox>ƽ����&nbsp;&nbsp;&nbsp;&nbsp;<span class="label">����ʱ�䣺</span><asp:TextBox id="txtJCSJ" runat="server" CssClass="textbox" Columns="12"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;<span class="label">¥�䣺</span><asp:TextBox id="txtLL" runat="server" CssClass="textbox" Columns="8"></asp:TextBox></TD>
                                                </TR>
                                                <tr height="26" valign="middle">
                                                    <TD class="label" align="right">�ռ����ͣ�</TD>
                                                    <TD width="8">&nbsp;</TD>
                                                    <td align="left">
                                                        <asp:RadioButtonList ID="rblKJLX" runat="server" CssClass="textbox" RepeatColumns="3" RepeatDirection="Vertical" RepeatLayout="Flow">
                                                            <asp:ListItem Value="ƽ��">ƽ��</asp:ListItem>
                                                            <asp:ListItem Value="��ʽ">��ʽ</asp:ListItem>
                                                            <asp:ListItem Value="���">���</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </td>
                                                    <TD width="8">&nbsp;</TD>
                                                    <TD class="label" align="right">�������ʣ�</td>
                                                    <td align="left">
                                                        <asp:RadioButtonList ID="rblFWXZ" runat="server" CssClass="textbox" RepeatColumns="3" RepeatDirection="Vertical" RepeatLayout="Flow">
                                                            <asp:ListItem Value="���ķ�">���ķ�</asp:ListItem>
                                                            <asp:ListItem Value="��Ʒ��">��Ʒ��</asp:ListItem>
                                                            <asp:ListItem Value="����">����</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </td>
                                                </tr>
                                                <tr height="26" valign="middle">
                                                    <TD class="label" align="right">¥�ߣ�</TD>
                                                    <TD width="8">&nbsp;</TD>
                                                    <td align="left" colspan="4">��<asp:TextBox id="txtLG" runat="server" CssClass="textbox" Columns="6"></asp:TextBox>��
                                                    &nbsp;&nbsp;&nbsp;&nbsp;������<asp:TextBox id="txtDTSL" runat="server" CssClass="textbox" Columns="6"></asp:TextBox>����
                                                    &nbsp;&nbsp;&nbsp;&nbsp;������<asp:TextBox id="txtLCHS" runat="server" CssClass="textbox" Columns="6"></asp:TextBox>��
                                                    &nbsp;&nbsp;&nbsp;&nbsp;��¥�̵�<asp:TextBox id="txtLPQS" runat="server" CssClass="textbox" Columns="6"></asp:TextBox>��(ɢ�̰���һ��)
                                                    </td>
                                                </tr>
                                                <tr height="26" valign="middle">
                                                    <TD class="label" align="right">����</TD>
                                                    <TD width="8">&nbsp;</TD>
                                                    <td align="left" colspan="4">
                                                        <asp:RadioButtonList ID="rblCX" runat="server" CssClass="textbox" RepeatColumns="11" RepeatDirection="Vertical" RepeatLayout="Flow">
                                                            <asp:ListItem Value="����">����</asp:ListItem>
                                                            <asp:ListItem Value="����">����</asp:ListItem>
                                                            <asp:ListItem Value="����">����</asp:ListItem>
                                                            <asp:ListItem Value="����">����</asp:ListItem>
                                                            <asp:ListItem Value="����">����</asp:ListItem>
                                                            <asp:ListItem Value="����">����</asp:ListItem>
                                                            <asp:ListItem Value="����">����</asp:ListItem>
                                                            <asp:ListItem Value="����">����</asp:ListItem>
                                                            <asp:ListItem Value="����">�ϱ�</asp:ListItem>
                                                            <asp:ListItem Value="����">����</asp:ListItem>
                                                            <asp:ListItem Value="����">���浥��</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                        <asp:DropDownList id="ddlZX" runat="server" CssClass="textbox" Visible="false">
                                                            <asp:ListItem Value=""></asp:ListItem>
                                                            <asp:ListItem Value="����">����</asp:ListItem>
                                                            <asp:ListItem Value="����">����</asp:ListItem>
                                                            <asp:ListItem Value="����">����</asp:ListItem>
                                                            <asp:ListItem Value="����">����</asp:ListItem>
                                                            <asp:ListItem Value="����">����</asp:ListItem>
                                                            <asp:ListItem Value="����">����</asp:ListItem>
                                                            <asp:ListItem Value="����">����</asp:ListItem>
                                                            <asp:ListItem Value="����">����</asp:ListItem>
                                                            <asp:ListItem Value="����">�ϱ�</asp:ListItem>
                                                            <asp:ListItem Value="����">����</asp:ListItem>
                                                            <asp:ListItem Value="����">���浥��</asp:ListItem>
                                                        </asp:DropDownList>                                                  
                                                    </td>
                                                </tr>
                                                <tr height="26" valign="middle">
                                                    <TD class="labelNotNull" align="right">��ҵ���ԣ�</TD>
                                                    <TD width="8">&nbsp;</TD>
                                                    <TD align="left" colspan="4">
                                                        <asp:RadioButtonList ID="rblWYSX" runat="server" CssClass="textbox" RepeatColumns="9" RepeatDirection="Vertical" RepeatLayout="Flow"></asp:RadioButtonList>
                                                        <asp:DropDownList id="ddlWYXZ" runat="server" CssClass="textbox" Visible="false"></asp:DropDownList>
                                                    </TD>
                                                </TR>
                                                <tr height="26" valign="middle">
                                                    <TD class="label" align="right">װ�޵��Σ�</TD>
                                                    <TD width="8">&nbsp;</TD>
                                                    <td align="left">
                                                        <asp:RadioButtonList ID="rblZXDC" runat="server" CssClass="textbox" RepeatColumns="3" RepeatDirection="Vertical" RepeatLayout="Flow">
                                                            <asp:ListItem Value="��ͨ">��ͨ</asp:ListItem>
                                                            <asp:ListItem Value="����">����</asp:ListItem>
                                                            <asp:ListItem Value="ë��">ë��</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </td>                                                      
                                                    <TD width="8">&nbsp;</TD>
                                                    <TD class="label" align="right">װ�����ޣ�</td>
                                                    <td align="left">
                                                        <asp:RadioButtonList ID="rblZXNX" runat="server" CssClass="textbox" RepeatColumns="3" RepeatDirection="Vertical" RepeatLayout="Flow">
                                                            <asp:ListItem Value="��ͨ">��ͨ</asp:ListItem>
                                                            <asp:ListItem Value="��">��</asp:ListItem>
                                                            <asp:ListItem Value="��">��</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </td>
                                                </tr>
                                                <tr height="26" valign="middle">
                                                    <TD class="label" align="right">����Ӱ�죺</TD>
                                                    <TD width="8">&nbsp;</TD>
                                                    <td align="left">
                                                        <asp:RadioButtonList ID="rblZYYX" runat="server" CssClass="textbox" RepeatColumns="3" RepeatDirection="Vertical" RepeatLayout="Flow">
                                                            <asp:ListItem Value="����">����</asp:ListItem>
                                                            <asp:ListItem Value="��ͨ">��ͨ</asp:ListItem>
                                                            <asp:ListItem Value="����">����</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </td>
                                                    <TD width="8">&nbsp;</TD>
                                                    <TD class="label" align="right">�Ҿ��豸��</td>
                                                    <td align="left">
                                                        <asp:RadioButtonList ID="rblJJSB" runat="server" CssClass="textbox" RepeatColumns="3" RepeatDirection="Vertical" RepeatLayout="Flow">
                                                            <asp:ListItem Value="��ͨ">��ͨ</asp:ListItem>
                                                            <asp:ListItem Value="����">����</asp:ListItem>
                                                            <asp:ListItem Value="����">����</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </td>
                                                </tr>
                                                <tr height="26" valign="middle">
                                                    <TD class="label" align="right">¥�ͨ��</TD>
                                                    <TD width="8">&nbsp;</TD>
                                                    <td align="left">
                                                        <asp:RadioButtonList ID="rblLYJT" runat="server" CssClass="textbox" RepeatColumns="3" RepeatDirection="Vertical" RepeatLayout="Flow">
                                                            <asp:ListItem Value="����">����</asp:ListItem>
                                                            <asp:ListItem Value="¥��">¥��</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </td>
                                                    <TD width="8">&nbsp;</TD>
                                                    <TD class="label" align="right">������ۣ�</td>
                                                    <td align="left">
                                                        <asp:RadioButtonList ID="rblFWJG" runat="server" CssClass="textbox" RepeatColumns="3" RepeatDirection="Vertical" RepeatLayout="Flow">
                                                            <asp:ListItem Value="��ͨ">��ͨ</asp:ListItem>
                                                            <asp:ListItem Value="����">����</asp:ListItem>
                                                            <asp:ListItem Value="�ϲ�">�ϲ�</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </td>
                                                </tr>
                                                <tr height="26" valign="middle">
                                                    <TD class="label" align="right">�������ͣ�</TD>
                                                    <TD width="8">&nbsp;</TD>
                                                    <td align="left" colspan="4">
                                                        <asp:RadioButtonList ID="rblJGLX" runat="server" CssClass="textbox" RepeatColumns="9" RepeatDirection="Vertical" RepeatLayout="Flow">
                                                            <asp:ListItem Value="԰��">԰��</asp:ListItem>
                                                            <asp:ListItem Value="һ�߽���">һ�߽���</asp:ListItem>
                                                            <asp:ListItem Value="���߽���">���߽���</asp:ListItem>
                                                            <asp:ListItem Value="ɽ��">ɽ��</asp:ListItem>
                                                            <asp:ListItem Value="��԰">��԰</asp:ListItem>
                                                            <asp:ListItem Value="��·">��·</asp:ListItem>
                                                            <asp:ListItem Value="¥��">¥��</asp:ListItem>
                                                            <asp:ListItem Value="��������">��������</asp:ListItem>
                                                            <asp:ListItem Value="��־�Խ���">��־�Խ���</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </td>
                                                </tr>
                                                <tr height="26" valign="middle">
                                                    <TD class="label" align="right"></TD>
                                                    <TD width="8">&nbsp;</TD>
                                                    <TD class="label" align="left" colspan="4">ӵ���������۵ķ��䣺<asp:TextBox id="txtJGFS" runat="server" CssClass="textbox" Columns="4"></asp:TextBox>��&nbsp;&nbsp;&nbsp;&nbsp;����¥�㣺��<asp:TextBox id="txtLC" runat="server" CssClass="textbox" Columns="8"></asp:TextBox>��&nbsp;&nbsp;&nbsp;&nbsp;����������<asp:TextBox id="txtWSSL" runat="server" CssClass="textbox" Columns="4"></asp:TextBox>��&nbsp;&nbsp;&nbsp;&nbsp;��̨������<asp:TextBox id="txtYTSL" runat="server" CssClass="textbox" Columns="4"></asp:TextBox>��</TD>
                                                </TR>
                                                <tr height="26" valign="middle">
                                                    <TD class="labelNotNull" align="right">�۸�</TD>
                                                    <TD width="8">&nbsp;</TD>
                                                    <TD align="left" colspan="4"><asp:TextBox id="txtJYJE" runat="server" CssClass="textbox" Columns="24"></asp:TextBox>Ԫ�����</TD>
                                                </TR>
                                                <tr height="26" valign="middle">
                                                    <TD class="label" align="right">���ͣ�</TD>
                                                    <TD width="8">&nbsp;</TD>
                                                    <TD align="left" colspan="4"><asp:DropDownList id="ddlJG" runat="server" CssClass="textbox" Width="300px"></asp:DropDownList></TD>
                                                </TR>
                                                <TR>
                                                    <TD class="label" align="right">��ע��</TD>
                                                    <TD width="8">&nbsp;</TD>
                                                    <TD align="left" colspan="4"><asp:TextBox id="txtBZXX" runat="server" Width="100%" CssClass="textbox" Rows="4" TextMode="MultiLine"></asp:TextBox></TD>
                                                </TR>
                                            </TABLE>
                                        </TD>
                                    </TR>
                                </TABLE>
                            </DIV>
                        </TD>
                    </TR>
                    <TR id="trRow2">
                        <TD align="center">
                            <asp:button id="btnOK" Runat="server" CssClass="button" Height="36px" Text=" ȷ    �� "></asp:button>
                            <asp:button id="btnCancel" Runat="server" CssClass="button" Height="36px" Text=" ȡ    �� "></asp:button>
                            <asp:button id="btnClose" Runat="server" CssClass="button" Height="36px" Text=" ��    �� "></asp:button>
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
            <TABLE cellSpacing="0" cellPadding="0" align="center" border="0">
                <TR>
                    <TD>
                        <INPUT id="htxtDivLeftMain" type="hidden" runat="server" NAME="htxtDivLeftMain">
                        <INPUT id="htxtDivTopMain" type="hidden" runat="server" NAME="htxtDivTopMain">
                        <INPUT id="htxtDivLeftBody" type="hidden" runat="server" NAME="htxtDivLeftBody">
                        <INPUT id="htxtDivTopBody" type="hidden" runat="server" NAME="htxtDivTopBody">
                    </TD>
                </TR>
                <TR>
                    <TD>
                        <SCRIPT language="javascript">
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

								document.body.onscroll = ScrollProc_Body;
								divMain.onscroll = ScrollProc_divMain;
							}
							catch (e) {}
                        </SCRIPT>
                    </TD>
                </TR>
                <TR>
                    <TD>
                        <SCRIPT language="javascript">window_onresize();</SCRIPT>
                        <UWIN:POPMESSAGE id="popMessageObject" runat="server" Visible="False" EnableViewState="False" PopupWindowType="Normal" ActionType="OpenWindow" height="48px" width="96px"></UWIN:POPMESSAGE>
                    </TD>
                </TR>
            </TABLE>
        </form>
    </body>
</HTML>
