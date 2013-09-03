<%@ Page Language="vb" AutoEventWireup="false" Codebehind="grsw_jieshou.aspx.vb" Inherits="Josco.JsKernal.web.grsw_jieshou" %>
<%@ Register TagPrefix="uwin" Namespace="Josco.Web" Assembly="Josco.Web.PopMessage" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
    <HEAD>
        <title>接收移交的文件</title>
        <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
        <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
        <meta content="JavaScript" name="vs_defaultClientScript">
        <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
        <LINK href="../../styles01.css" type="text/css" rel="stylesheet">
        <style>
		    TD.grdFILELocked { ; LEFT: expression(divFILE.scrollLeft); POSITION: relative }
		    TH.grdFILELocked { ; LEFT: expression(divFILE.scrollLeft); POSITION: relative }
		    TH.grdFILELocked { Z-INDEX: 99 }
		    TH { Z-INDEX: 10; POSITION: relative }
        </style>
        <script src="../../scripts/transkey.js"></script>
        <script language="javascript">
		<!--
			function window_onresize() 
			{
				var dblHeight = 0;
				var dblWidth  = 0;
				var strHeight = "";
				var strWidth  = "";
				
				if (document.all("divFILE") == null)
					return;
				
				intWidth   = document.body.clientWidth;   //总宽度
				intWidth  -= 24;                          //滚动条
				intWidth  -= 2 * 4;                       //左、右空白
				intWidth  -= 10;                          //调整数
				strWidth   = intWidth.toString() + "px";
				
				intHeight  = document.body.clientHeight;  //总高度
				intHeight -= 10;                          //调整数
				intHeight -= trRow1.clientHeight;
				intHeight -= trRow2.clientHeight;
				intHeight -= trRow3.clientHeight;
				intHeight -= trRow4.clientHeight;
				intHeight -= trRow5.clientHeight;
				intHeight -= trRow6.clientHeight;
				strHeight  = intHeight.toString() + "px";

				divFILE.style.width  = strWidth;
				divFILE.style.height = strHeight;
				divFILE.style.clip   = "rect(0px " + strWidth + " " + strHeight + " 0px)";
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
    <body background="../../images/oabk.gif" bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" onresize="return window_onresize()">
        <form id="frmgrsw_jieshou" method="post" runat="server">
            <asp:panel id="panelMain" Runat="server">
                <TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
                    <TR>
                        <TD width="4"></TD>
                        <TD vAlign="top" align="center">
                            <TABLE cellSpacing="0" cellPadding="0" border="0">
                                <TR id="trRow1">
                                    <TD class="title" align="center" colSpan="3" height="30">接收移交的文件<asp:LinkButton id="lnkBlank" Runat="server" Width="0px"></asp:LinkButton></TD>
                                </TR>
                                <TR id="trRow2">
                                    <TD colspan="3">
                                        <TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
                                            <TR>
                                                <TD class="label" align="left" bgColor="#ccff99" colSpan="3"><B>&gt;&gt;&gt;&gt;步骤一：确定接收谁移交的文件？</B></TD>
                                            </TR>
                                            <TR>
                                                <TD class="labelNotNull" noWrap align="right">移交人：</TD>
                                                <TD align="left"><asp:DropDownList ID="ddlYJR" Runat="server" CssClass="textbox" Width="400px"></asp:DropDownList></TD>
                                                <td width="100%"></td>
                                            </TR>
                                        </TABLE>
                                    </TD>
                                </TR>
                                <TR id="trRow3">
                                    <TD class="label" align="left" bgColor="#ccff99" colSpan="3"><B>&gt;&gt;&gt;&gt;步骤二：确定要接收哪些文件？</B></TD>
                                </TR>
                                <TR>
                                    <TD width="4"></TD>
                                    <TD vAlign="top">
                                        <TABLE cellSpacing="0" cellPadding="0" border="0">
                                            <TR id="trRow4">
                                                <TD class="label" align="left">
                                                    <TABLE cellSpacing="0" cellPadding="0" border="0">
                                                        <TR>
                                                            <TD class="label" vAlign="middle">文件类型&nbsp;</TD>
                                                            <TD class="label" align="left"><asp:DropDownList id="ddlFILESearch_WJLX" Runat="server" CssClass="textbox"></asp:DropDownList></TD>
                                                            <TD class="label" vAlign="middle">&nbsp;&nbsp;已经接收&nbsp;</TD>
                                                            <TD class="label" align="left"><asp:DropDownList id="ddlFILESearch_SFJS" Runat="server" CssClass="textbox"><asp:ListItem Value=""></asp:ListItem><asp:ListItem Value="×">×</asp:ListItem><asp:ListItem Value="√">√</asp:ListItem></asp:DropDownList></TD>
                                                            <TD class="label" vAlign="middle">&nbsp;&nbsp;文件年度&nbsp;</TD>
                                                            <TD class="label" align="left"><asp:textbox id="txtFILESearch_WJNDMin" runat="server" CssClass="textbox" Columns="5"></asp:textbox>~<asp:textbox id="txtFILESearch_WJNDMax" runat="server" CssClass="textbox" Columns="5"></asp:textbox></TD>
                                                            <TD class="label">&nbsp;&nbsp;<asp:button id="btnFILESearch" Runat="server" CssClass="button" Text="快速搜索"></asp:button><asp:Button id="btnFILESearch_Full" Runat="server" CssClass="button" Text="全文检索"></asp:Button></TD>
                                                        </TR>
                                                    </TABLE>
                                                </TD>
                                            </TR>
                                            <TR>
                                                <TD>
                                                    <DIV id="divFILE" style="BORDER-RIGHT: #99cccc 1px solid; TABLE-LAYOUT: fixed; BORDER-TOP: #99cccc 1px solid; OVERFLOW: auto; BORDER-LEFT: #99cccc 1px solid; WIDTH: 800px; CLIP: rect(0px 800px 420px 0px); BORDER-BOTTOM: #99cccc 1px solid; HEIGHT: 420px">
                                                        <asp:datagrid id="grdFILE" runat="server" Width="2270px" CssClass="label" UseAccessibleHeader="True"
                                                            AllowPaging="True" AutoGenerateColumns="False" GridLines="Vertical" BackColor="White" BorderStyle="None"
                                                            PageSize="30" BorderColor="#DEDFDE" BorderWidth="0px" AllowSorting="True" CellPadding="4">
                                                            <SelectedItemStyle Font-Bold="False" VerticalAlign="Middle" ForeColor="#CC0000" BackColor="#FFFFDD"></SelectedItemStyle>
                                                            <EditItemStyle VerticalAlign="Middle" BackColor="#FFCC00"></EditItemStyle>
                                                            <AlternatingItemStyle BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="White"></AlternatingItemStyle>
                                                            <ItemStyle BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="#F7F7F7" ForeColor="Black"></ItemStyle>
                                                            <HeaderStyle Font-Bold="True" ForeColor="White" VerticalAlign="Middle" BackColor="#6699cc" HorizontalAlign="Left"></HeaderStyle>
                                                            <FooterStyle BackColor="#CCCC99"></FooterStyle>
                                                            <Columns>
                                                                <asp:TemplateColumn HeaderText="选">
                                                                    <HeaderStyle HorizontalAlign="Center" Width="20px"></HeaderStyle>
                                                                    <ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
                                                                    <ItemTemplate>
                                                                        <asp:CheckBox id="chkFILE" runat="server" AutoPostBack="False"></asp:CheckBox>
                                                                    </ItemTemplate>
                                                                </asp:TemplateColumn>
                                                                <asp:ButtonColumn Visible="False" DataTextField="文件标识" SortExpression="文件标识" HeaderText="文件标识" CommandName="Select">
                                                                    <HeaderStyle Width="0px"></HeaderStyle>
                                                                </asp:ButtonColumn>
                                                                <asp:ButtonColumn Visible="False" DataTextField="办理类型" SortExpression="办理类型" HeaderText="办理类型" CommandName="Select">
                                                                    <HeaderStyle Width="0px"></HeaderStyle>
                                                                </asp:ButtonColumn>
                                                                <asp:ButtonColumn Visible="False" DataTextField="文件子类" SortExpression="文件子类" HeaderText="文件子类" CommandName="Select">
                                                                    <HeaderStyle Width="0px"></HeaderStyle>
                                                                </asp:ButtonColumn>
                                                                <asp:ButtonColumn Visible="False" DataTextField="机关代字" SortExpression="机关代字" HeaderText="机关代字" CommandName="Select">
                                                                    <HeaderStyle Width="0px"></HeaderStyle>
                                                                </asp:ButtonColumn>
                                                                <asp:ButtonColumn Visible="False" DataTextField="文件年份" SortExpression="文件年份" HeaderText="文件年份" CommandName="Select">
                                                                    <HeaderStyle Width="0px"></HeaderStyle>
                                                                </asp:ButtonColumn>
                                                                <asp:ButtonColumn Visible="False" DataTextField="文件序号" SortExpression="文件序号" HeaderText="文件序号" CommandName="Select">
                                                                    <HeaderStyle Width="0px"></HeaderStyle>
                                                                </asp:ButtonColumn>
                                                                <asp:ButtonColumn DataTextField="文件类型" SortExpression="文件类型" HeaderText="类型" CommandName="Select">
                                                                    <HeaderStyle Width="100px"></HeaderStyle>
                                                                </asp:ButtonColumn>
                                                                <asp:ButtonColumn Visible="False" DataTextField="是否移交" SortExpression="是否移交" HeaderText="移交" CommandName="Select">
                                                                    <HeaderStyle Width="0px"></HeaderStyle>
                                                                </asp:ButtonColumn>
                                                                <asp:ButtonColumn DataTextField="是否接收" SortExpression="是否接收" HeaderText="接收" CommandName="Select">
                                                                    <HeaderStyle Width="50px"></HeaderStyle>
                                                                </asp:ButtonColumn>
                                                                <asp:ButtonColumn DataTextField="文件年度" SortExpression="文件年度" HeaderText="年度" CommandName="Select">
                                                                    <HeaderStyle Width="60px"></HeaderStyle>
                                                                </asp:ButtonColumn>
                                                                <asp:ButtonColumn DataTextField="流水号" SortExpression="流水号" HeaderText="流水号" CommandName="Select">
                                                                    <HeaderStyle Width="120px"></HeaderStyle>
                                                                </asp:ButtonColumn>
                                                                <asp:ButtonColumn DataTextField="文件字号" SortExpression="文件字号" HeaderText="文件字号" CommandName="Select">
                                                                    <HeaderStyle Width="180px"></HeaderStyle>
                                                                </asp:ButtonColumn>
                                                                <asp:ButtonColumn DataTextField="文件标题" SortExpression="文件标题" HeaderText="文件标题" CommandName="OpenDocument">
                                                                    <HeaderStyle Width="280px"></HeaderStyle>
                                                                </asp:ButtonColumn>
                                                                <asp:ButtonColumn DataTextField="紧急程度" SortExpression="紧急程度" HeaderText="紧急" CommandName="Select">
                                                                    <HeaderStyle Width="60px"></HeaderStyle>
                                                                </asp:ButtonColumn>
                                                                <asp:ButtonColumn DataTextField="秘密等级" SortExpression="秘密等级" HeaderText="密级" CommandName="Select">
                                                                    <HeaderStyle Width="60px"></HeaderStyle>
                                                                </asp:ButtonColumn>
                                                                <asp:ButtonColumn DataTextField="主送单位" SortExpression="主送单位" HeaderText="主送或来文单位" CommandName="Select">
                                                                    <HeaderStyle Width="160px"></HeaderStyle>
                                                                </asp:ButtonColumn>
                                                                <asp:ButtonColumn DataTextField="主办单位" SortExpression="主办单位" HeaderText="主办单位" CommandName="Select">
                                                                    <HeaderStyle Width="160px"></HeaderStyle>
                                                                </asp:ButtonColumn>
                                                                <asp:ButtonColumn DataTextField="拟稿人" SortExpression="拟稿人" HeaderText="主办人" CommandName="Select">
                                                                    <HeaderStyle Width="80px"></HeaderStyle>
                                                                </asp:ButtonColumn>
                                                                <asp:ButtonColumn DataTextField="拟稿日期" SortExpression="拟稿日期" HeaderText="主办日期" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd}">
                                                                    <HeaderStyle Width="120px"></HeaderStyle>
                                                                </asp:ButtonColumn>
                                                                <asp:ButtonColumn DataTextField="主题词" SortExpression="主题词" HeaderText="主题词" CommandName="Select">
                                                                    <HeaderStyle Width="100px"></HeaderStyle>
                                                                </asp:ButtonColumn>
                                                                <asp:ButtonColumn DataTextField="办理状态" SortExpression="办理状态" HeaderText="状态" CommandName="Select">
                                                                    <HeaderStyle Width="100px"></HeaderStyle>
                                                                </asp:ButtonColumn>
                                                                <asp:ButtonColumn Visible="False" DataTextField="快速收文" SortExpression="快速收文" HeaderText="快速收文" CommandName="Select">
                                                                    <HeaderStyle Width="0px"></HeaderStyle>
                                                                </asp:ButtonColumn>
                                                                <asp:ButtonColumn DataTextField="移交人" SortExpression="移交人" HeaderText="移交人" CommandName="Select">
                                                                    <HeaderStyle Width="80px"></HeaderStyle>
                                                                </asp:ButtonColumn>
                                                                <asp:ButtonColumn DataTextField="移交日期" SortExpression="移交日期" HeaderText="移交日期" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd}">
                                                                    <HeaderStyle Width="120px"></HeaderStyle>
                                                                </asp:ButtonColumn>
                                                                <asp:ButtonColumn DataTextField="移交说明" SortExpression="移交说明" HeaderText="移交说明" CommandName="Select">
                                                                    <HeaderStyle Width="180px"></HeaderStyle>
                                                                </asp:ButtonColumn>
                                                                <asp:ButtonColumn Visible="False" DataTextField="接收人" SortExpression="接收人" HeaderText="接收人" CommandName="Select">
                                                                    <HeaderStyle Width="0px"></HeaderStyle>
                                                                </asp:ButtonColumn>
                                                                <asp:ButtonColumn DataTextField="接收日期" SortExpression="接收日期" HeaderText="接收日期" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd}">
                                                                    <HeaderStyle Width="120px"></HeaderStyle>
                                                                </asp:ButtonColumn>
                                                            </Columns>
                                                            <PagerStyle Visible="False" NextPageText="下页" PrevPageText="上页" HorizontalAlign="Right" ForeColor="Black" Position="TopAndBottom" BackColor="SkyBlue"></PagerStyle>
                                                        </asp:datagrid><INPUT id="htxtFILEFixed" type="hidden" value="0" runat="server">
                                                    </DIV>
                                                </TD>
                                            </TR>
                                            <TR id="trRow5">
                                                <TD class="label">
                                                    <TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
                                                        <TR>
                                                            <TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZFILEDeSelectAll" runat="server">不选</asp:linkbutton></TD>
                                                            <TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZFILESelectAll" runat="server">全选</asp:linkbutton></TD>
                                                            <TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZFILEMoveFirst" runat="server">最前</asp:linkbutton></TD>
                                                            <TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZFILEMovePrev" runat="server">前页</asp:linkbutton></TD>
                                                            <TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZFILEMoveNext" runat="server">下页</asp:linkbutton></TD>
                                                            <TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZFILEMoveLast" runat="server">最后</asp:linkbutton></TD>
                                                            <TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZFILEGotoPage" runat="server">前往</asp:linkbutton><asp:textbox id="txtFILEPageIndex" runat="server" CssClass="textbox" Columns="3">1</asp:textbox>页</TD>
                                                            <TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZFILESetPageSize" runat="server">每页</asp:linkbutton><asp:textbox id="txtFILEPageSize" runat="server" CssClass="textbox" Columns="3">30</asp:textbox>条</TD>
                                                            <TD class="label" vAlign="middle" noWrap align="right"><asp:label id="lblFILEGridLocInfo" runat="server" CssClass="label">1/10 N/15</asp:label></TD>
                                                        </TR>
                                                    </TABLE>
                                                </TD>
                                            </TR>
                                        </TABLE>
                                    </TD>
                                    <TD width="4"></TD>
                                </TR>
                            </TABLE>
                        </TD>
                        <TD width="4"></TD>
                    </TR>
                    <TR id="trRow6">
                        <TD align="center" colSpan="3">
                            <asp:Button id="btnJieshou" Runat="server" CssClass="button" Text=" 接收文件 " Height="36px"></asp:Button>
                            <asp:Button id="btnClose"   Runat="server" CssClass="button" Text=" 返    回 " Height="36px"></asp:Button>
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
                                    <TD id="tdErrInfo" style="FONT-SIZE: 32pt; COLOR: black; LINE-HEIGHT: 40pt; FONT-FAMILY: 宋体; LETTER-SPACING: 2pt" align="center"><asp:Label id="lblMessage" Runat="server"></asp:Label><P>&nbsp;&nbsp;</P><P><INPUT id="btnGoBack" style="FONT-SIZE: 24pt; FONT-FAMILY: 宋体" onclick="javascript:history.back();" type="button" value=" 返回 "></P></TD>
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
                        <input id="htxtFILESessionIdQuery" type="hidden" runat="server">
                        <input id="htxtFILEQuery" type="hidden" runat="server">
                        <input id="htxtFILERows" type="hidden" runat="server">
                        <input id="htxtFILESort" type="hidden" runat="server">
                        <input id="htxtFILESortColumnIndex" type="hidden" runat="server">
                        <input id="htxtFILESortType" type="hidden" runat="server">
                        <input id="htxtDivLeftFILE" type="hidden" runat="server">
                        <input id="htxtDivTopFILE" type="hidden" runat="server">
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
							function ScrollProc_divFILE() {
								var oText;
								oText=null;
								oText=document.getElementById("htxtDivTopFILE");
								if (oText != null) oText.value = divFILE.scrollTop;
								oText=null;
								oText=document.getElementById("htxtDivLeftFILE");
								if (oText != null) oText.value = divFILE.scrollLeft;
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
								oText=document.getElementById("htxtDivTopFILE");
								if (oText != null) divFILE.scrollTop = oText.value;
								oText=null;
								oText=document.getElementById("htxtDivLeftFILE");
								if (oText != null) divFILE.scrollLeft = oText.value;

								document.body.onscroll = ScrollProc_Body;
								divFILE.onscroll = ScrollProc_divFILE;
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
