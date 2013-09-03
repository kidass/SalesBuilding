<%@ Page Language="vb" AutoEventWireup="false" Codebehind="estate_es_hetong_jss_bjyj.aspx.vb" Inherits="Josco.JSOA.web.estate_es_hetong_jss_bjyj" %>
<%@ Register TagPrefix="uwin" Namespace="Josco.Web" Assembly="Josco.Web.PopMessage" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
    <HEAD>
        <title>结算书补计佣金</title>
        <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR"/>
        <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE"/>
        <meta content="JavaScript" name="vs_defaultClientScript"/>
        <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
        <LINK href="../../../styles01.css" type="text/css" rel="stylesheet"/>
        <style>
		    TD.grdJSSLocked { ; LEFT: expression(divJSS.scrollLeft); POSITION: relative }
		    TH.grdJSSLocked { ; LEFT: expression(divJSS.scrollLeft); POSITION: relative }
		    TH.grdJSSLocked { Z-INDEX: 99 }
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
				
				if (document.all("divJSS") == null)
					return;
				
				intWidth   = document.body.clientWidth;   //总宽度
				intWidth  -= 24;                          //滚动条
				intWidth  -= 2 * 4;                       //左、右空白
				intWidth  -= 16;                          //调整数
				strWidth   = intWidth.toString() + "px";
				
				intHeight  = document.body.clientHeight;  //总高度
				intHeight -= 24;                          //调整数
				intHeight -= trRow01.clientHeight;
				intHeight -= trRow02.clientHeight;
				intHeight -= trRow03.clientHeight;
				intHeight -= trRow04.clientHeight;
				intHeight -= trRow05.clientHeight;
				intHeight -= trRow06.clientHeight;
				strHeight = intHeight.toString() + "px";
				//if (document.readyState.toLowerCase() == "complete")
                //    alert(strWidth + " " + strHeight);
				divJSS.style.width = strWidth;
				divJSS.style.height = strHeight;
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
        <form id="frmestate_es_hetong_jss_bjyj" method="post" runat="server">
            <asp:panel id="panelMain" Runat="server">
                <TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
                    <TR>
                        <TD width="5"></TD>
                        <TD vAlign="top" align="center">
                            <TABLE cellSpacing="0" cellPadding="0" border="0">
                                <TR id="trRow01">
                                    <TD class="title" align="center" colSpan="3" height="30">结算书补计佣金<asp:LinkButton id="lnkBlank" Runat="server" Width="0px"></asp:LinkButton></TD>
                                </TR>
                                <TR>
                                    <TD width="5"></TD>
                                    <TD vAlign="top">
                                        <TABLE cellSpacing="0" cellPadding="0" border="0">
                                            <TR>
                                                <TD>
                                                    <% if propJSSH <> "" then response.write("<div style='display:none'>") %>
                                                    <TABLE cellSpacing="0" cellPadding="0" align="center" border="0">
                                                        <TR id="trRow02">
                                                            <TD class="label" align="left" bgColor="#ccff99"><B>&gt;&gt;&gt;&gt;搜索要补计佣金的结算书</B></TD>
                                                        </TR>
                                                        <TR id="trRow03">
                                                            <TD align="left">
                                                                <TABLE cellSpacing="0" cellPadding="0" border="0">
                                                                    <TR>
                                                                        <TD class="label" vAlign="middle" align="right">&nbsp;&nbsp;确认书号&nbsp;</TD>
                                                                        <TD class="label" align="left"><asp:textbox id="txtJSSSearch_QRSH" runat="server" Columns="12" CssClass="textbox"></asp:textbox></TD>
                                                                        <TD class="label" vAlign="middle" align="right">&nbsp;&nbsp;结算书号&nbsp;</TD>
                                                                        <TD class="label" align="left"><asp:textbox id="txtJSSSearch_JSSH" runat="server" Columns="12" CssClass="textbox"></asp:textbox></TD>
                                                                        <TD class="label" vAlign="middle" align="right">&nbsp;&nbsp;结算日期&nbsp;</TD>
                                                                        <TD class="label" align="left"><asp:textbox id="txtJSSSearch_HTRQMin" runat="server" Columns="10" CssClass="textbox"></asp:textbox>~<asp:textbox id="txtJSSSearch_HTRQMax" runat="server" Columns="10" CssClass="textbox"></asp:textbox></TD>
                                                                        <TD class="label" vAlign="middle" align="right">&nbsp;&nbsp;状态&nbsp;</TD>
                                                                        <TD class="label" align="left">
                                                                            <asp:DropDownList id="ddlJSSSearch_HTZT" runat="server" CssClass="textbox">
                                                                                <asp:ListItem Value=""></asp:ListItem>
                                                                                <asp:ListItem Value="&1=0">未审</asp:ListItem>
                                                                                <asp:ListItem Value="&1=1">已审</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </TD>
                                                                        <TD class="label" align="right">&nbsp;&nbsp;<asp:button id="btnJSSSearch" Runat="server" CssClass="button" Text="快速搜索"></asp:button><asp:button id="btnJSSSearch_Full" Runat="server" CssClass="button" Text="全文搜索"></asp:button></TD>
                                                                    </TR>
                                                                </TABLE>
                                                            </TD>
                                                        </TR>
                                                        <TR>
                                                            <TD>
                                                                <DIV id="divJSS" style="BORDER-RIGHT: #99cccc 1px solid; TABLE-LAYOUT: fixed; BORDER-TOP: #99cccc 1px solid; OVERFLOW: auto; BORDER-LEFT: #99cccc 1px solid; WIDTH: 964px; CLIP: rect(0px 964px 413px 0px); BORDER-BOTTOM: #99cccc 1px solid; HEIGHT: 413px">
                                                                    <asp:datagrid id="grdJSS" runat="server" Width="1900px" CssClass="label" UseAccessibleHeader="True"
                                                                        AllowPaging="True" AutoGenerateColumns="False" GridLines="Vertical" BackColor="White" BorderStyle="None"
                                                                        PageSize="30" BorderColor="#DEDFDE" BorderWidth="0px" AllowSorting="True" CellPadding="4">
                                                                        <SelectedItemStyle Font-Bold="False" VerticalAlign="Middle" ForeColor="#CC0000" BackColor="#FFFFDD"></SelectedItemStyle>
                                                                        <EditItemStyle VerticalAlign="Middle" BackColor="#FFCC00"></EditItemStyle>
                                                                        <AlternatingItemStyle BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="White"></AlternatingItemStyle>
                                                                        <ItemStyle BorderWidth="0px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="#F7F7F7" ForeColor="Black"></ItemStyle>
                                                                        <HeaderStyle Font-Bold="True" ForeColor="White" VerticalAlign="Middle" BackColor="#6699cc" HorizontalAlign="Left"></HeaderStyle>
                                                                        <FooterStyle BackColor="#CCCC99"></FooterStyle>
                                                                        <Columns>
                                                                            <asp:TemplateColumn HeaderText="选" Visible="False" ItemStyle-Width="20px">
                                                                                <HeaderStyle HorizontalAlign="Center" Width="20px"></HeaderStyle>
                                                                                <ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
                                                                                <ItemTemplate>
                                                                                    <asp:CheckBox id="chkJSS" runat="server" AutoPostBack="False" Visible="False"></asp:CheckBox>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateColumn>
                                                                            
                                                                            <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="唯一标识" SortExpression="唯一标识" HeaderText="唯一标识" CommandName="Select">
                                                                                <HeaderStyle Width="0px"></HeaderStyle>
                                                                            </asp:ButtonColumn>
                                                                            <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="结算类型" SortExpression="结算类型" HeaderText="结算类型码" CommandName="Select">
                                                                                <HeaderStyle Width="0px"></HeaderStyle>
                                                                            </asp:ButtonColumn>
                                                                            <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="状态标志" SortExpression="状态标志" HeaderText="状态标志" CommandName="Select">
                                                                                <HeaderStyle Width="0px"></HeaderStyle>
                                                                            </asp:ButtonColumn>
                                                                            <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="结算单位" SortExpression="结算单位" HeaderText="结算单位码" CommandName="Select">
                                                                                <HeaderStyle Width="0px"></HeaderStyle>
                                                                            </asp:ButtonColumn>
                                                                            <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="经办人员" SortExpression="经办人员" HeaderText="经办人员码" CommandName="Select">
                                                                                <HeaderStyle Width="0px"></HeaderStyle>
                                                                            </asp:ButtonColumn>
                                                                            
                                                                            <asp:ButtonColumn ItemStyle-Width="60px" DataTextField="状态标志名称" SortExpression="状态标志名称" HeaderText="审核" CommandName="Select">
                                                                                <HeaderStyle Width="60px"></HeaderStyle>
                                                                            </asp:ButtonColumn>
                                                                            <asp:ButtonColumn ItemStyle-Width="100px" DataTextField="结算类型名称" SortExpression="结算类型名称" HeaderText="结算类型" CommandName="Select">
                                                                                <HeaderStyle Width="100px"></HeaderStyle>
                                                                            </asp:ButtonColumn>
                                                                            <asp:ButtonColumn ItemStyle-Width="120px" DataTextField="确认书号" SortExpression="确认书号" HeaderText="确认书号" CommandName="OpenDocument">
                                                                                <HeaderStyle Width="120px"></HeaderStyle>
                                                                            </asp:ButtonColumn>
                                                                            <asp:ButtonColumn ItemStyle-Width="120px" DataTextField="结算书号" SortExpression="结算书号" HeaderText="结算书号" CommandName="OpenDocument">
                                                                                <HeaderStyle Width="120px"></HeaderStyle>
                                                                            </asp:ButtonColumn>
                                                                            <asp:ButtonColumn ItemStyle-Width="140px" DataTextField="结算日期" SortExpression="结算日期" HeaderText="结算日期" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd}">
                                                                                <HeaderStyle Width="140px"></HeaderStyle>
                                                                            </asp:ButtonColumn>
                                                                            <asp:ButtonColumn ItemStyle-Width="140px" DataTextField="计佣日期" SortExpression="计佣日期" HeaderText="计佣日期" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd}">
                                                                                <HeaderStyle Width="140px"></HeaderStyle>
                                                                            </asp:ButtonColumn>
                                                                            <asp:ButtonColumn ItemStyle-Width="180px" DataTextField="结算单位名称" SortExpression="结算单位名称" HeaderText="结算单位" CommandName="Select">
                                                                                <HeaderStyle Width="180px"></HeaderStyle>
                                                                            </asp:ButtonColumn>
                                                                            <asp:ButtonColumn ItemStyle-Width="120px" DataTextField="经办人员名称" SortExpression="经办人员名称" HeaderText="经办人员" CommandName="Select">
                                                                                <HeaderStyle Width="120px"></HeaderStyle>
                                                                            </asp:ButtonColumn>
                                                                            <asp:ButtonColumn ItemStyle-Width="160px" DataTextField="中介费额" SortExpression="中介费额" HeaderText="中介费额(元)" CommandName="Select" DataTextFormatString="{0:#,###.00}" ItemStyle-HorizontalAlign="Right">
                                                                                <HeaderStyle Width="160px" HorizontalAlign="Right"></HeaderStyle>
                                                                            </asp:ButtonColumn>
                                                                            <asp:ButtonColumn ItemStyle-Width="160px" DataTextField="结算额甲" SortExpression="结算额甲" HeaderText="结算额甲(元)" CommandName="Select" DataTextFormatString="{0:#,###.00}" ItemStyle-HorizontalAlign="Right">
                                                                                <HeaderStyle Width="160px" HorizontalAlign="Right"></HeaderStyle>
                                                                            </asp:ButtonColumn>
                                                                            <asp:ButtonColumn ItemStyle-Width="160px" DataTextField="结算额乙" SortExpression="结算额乙" HeaderText="结算额乙(元)" CommandName="Select" DataTextFormatString="{0:#,###.00}" ItemStyle-HorizontalAlign="Right">
                                                                                <HeaderStyle Width="160px" HorizontalAlign="Right"></HeaderStyle>
                                                                            </asp:ButtonColumn>
                                                                            <asp:ButtonColumn ItemStyle-Width="160px" DataTextField="实收额甲" SortExpression="实收额甲" HeaderText="实收额甲(元)" CommandName="Select" DataTextFormatString="{0:#,###.00}" ItemStyle-HorizontalAlign="Right">
                                                                                <HeaderStyle Width="160px" HorizontalAlign="Right"></HeaderStyle>
                                                                            </asp:ButtonColumn>
                                                                            <asp:ButtonColumn ItemStyle-Width="160px" DataTextField="实收额乙" SortExpression="实收额乙" HeaderText="实收额乙(元)" CommandName="Select" DataTextFormatString="{0:#,###.00}" ItemStyle-HorizontalAlign="Right">
                                                                                <HeaderStyle Width="160px" HorizontalAlign="Right"></HeaderStyle>
                                                                            </asp:ButtonColumn>
                                                                            <asp:ButtonColumn ItemStyle-Width="100px" DataTextField="备注信息" SortExpression="备注信息" HeaderText="备注信息" CommandName="Select">
                                                                                <HeaderStyle Width="100px"></HeaderStyle>
                                                                            </asp:ButtonColumn>
                                                                        </Columns>
                                                                        <PagerStyle Visible="False" NextPageText="下页" PrevPageText="上页" HorizontalAlign="Right" ForeColor="Black" Position="TopAndBottom" BackColor="SkyBlue"></PagerStyle>
                                                                    </asp:datagrid><INPUT id="htxtJSSFixed" type="hidden" value="0" runat="server"/>
                                                                </DIV>
                                                            </TD>
                                                        </TR>
                                                        <TR id="trRow04">
                                                            <TD class="label">
                                                                <TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
                                                                    <TR>
                                                                        <TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZJSSDeSelectAll" runat="server">不选</asp:linkbutton></TD>
                                                                        <TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZJSSSelectAll" runat="server">全选</asp:linkbutton></TD>
                                                                        <TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZJSSMoveFirst" runat="server">最前</asp:linkbutton></TD>
                                                                        <TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZJSSMovePrev" runat="server">前页</asp:linkbutton></TD>
                                                                        <TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZJSSMoveNext" runat="server">下页</asp:linkbutton></TD>
                                                                        <TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZJSSMoveLast" runat="server">最后</asp:linkbutton></TD>
                                                                        <TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZJSSGotoPage" runat="server">前往</asp:linkbutton><asp:textbox id="txtJSSPageIndex" runat="server" Columns="3" CssClass="textbox">1</asp:textbox>页</TD>
                                                                        <TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZJSSSetPageSize" runat="server">每页</asp:linkbutton><asp:textbox id="txtJSSPageSize" runat="server" Columns="3" CssClass="textbox">30</asp:textbox>条</TD>
                                                                        <TD class="label" vAlign="middle" noWrap align="right"><asp:label id="lblJSSGridLocInfo" runat="server" CssClass="label">1/10 N/15</asp:label></TD>
                                                                    </TR>
                                                                </TABLE>
                                                            </TD>
                                                        </TR>
                                                    </TABLE>
                                                    <% if propJSSH <> "" then response.write("</div>") %>
                                                </TD>
                                            </TR>
                                            <tr id="trRow05">
                                                <td>
                                                    <% if propJSSH = "" then response.write("<div style='display:none'>") %>
                                                    <TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
                                                        <TR>
                                                            <TD class="label" align="left" bgColor="#ccff99"><B>&gt;&gt;&gt;&gt;交易信息</B></TD>
                                                        </TR>
                                                        <TR>
                                                            <TD>
                                                                <TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
                                                                    <TR>
                                                                        <TD class="label" noWrap align="right">&nbsp;&nbsp;交易编号：&nbsp;&nbsp;</TD>
                                                                        <TD noWrap align="left" width="15%" style="BORDER-BOTTOM: #99cccc 1px solid">&nbsp;<asp:Label id="lblJYBH" Runat="server" CssClass="label"></asp:Label>&nbsp;</TD>
                                                                        <TD class="label" noWrap align="right">&nbsp;&nbsp;交易日期：&nbsp;&nbsp;</TD>
                                                                        <TD noWrap align="left" width="15%" style="BORDER-BOTTOM: #99cccc 1px solid">&nbsp;<asp:Label id="lblJYRQ" Runat="server" CssClass="label"></asp:Label>&nbsp;</TD>
                                                                        <TD class="label" noWrap align="right">&nbsp;&nbsp;甲方名称：&nbsp;&nbsp;</TD>
                                                                        <TD noWrap align="left" width="18%" style="BORDER-BOTTOM: #99cccc 1px solid">&nbsp;<asp:Label id="lblJFMC" Runat="server" CssClass="label"></asp:Label>&nbsp;</TD>
                                                                        <TD class="label" noWrap align="right">&nbsp;&nbsp;交易价格(元)：&nbsp;&nbsp;</TD>
                                                                        <TD noWrap align="right" width="15%" style="BORDER-BOTTOM: #99cccc 1px solid">&nbsp;<asp:Label id="lblJYJG" Runat="server" CssClass="label"></asp:Label>&nbsp;</TD>
                                                                        <TD class="label" noWrap align="right">&nbsp;&nbsp;甲方代理费(元)：&nbsp;&nbsp;</TD>
                                                                        <TD noWrap align="right" width="15%" style="BORDER-BOTTOM: #99cccc 1px solid">&nbsp;<asp:Label id="lblJFDLF" Runat="server" CssClass="label"></asp:Label>&nbsp;</TD>
                                                                    </TR>
                                                                    <TR>
                                                                        <TD class="label" noWrap align="right">&nbsp;&nbsp;合同编号：&nbsp;&nbsp;</TD>
                                                                        <TD noWrap align="left" style="BORDER-BOTTOM: #99cccc 1px solid">&nbsp;<asp:Label id="lblHTBH" Runat="server" CssClass="label"></asp:Label>&nbsp;</TD>
                                                                        <TD class="label" noWrap align="right">&nbsp;&nbsp;合同日期：&nbsp;&nbsp;</TD>
                                                                        <TD noWrap align="left" style="BORDER-BOTTOM: #99cccc 1px solid">&nbsp;<asp:Label id="lblHTRQ" Runat="server" CssClass="label"></asp:Label>&nbsp;</TD>
                                                                        <TD class="label" noWrap align="right">&nbsp;&nbsp;乙方名称：&nbsp;&nbsp;</TD>
                                                                        <TD noWrap align="left" style="BORDER-BOTTOM: #99cccc 1px solid">&nbsp;<asp:Label id="lblYFMC" Runat="server" CssClass="label"></asp:Label>&nbsp;</TD>
                                                                        <TD class="label" noWrap align="right">&nbsp;&nbsp;交易面积(㎡)：&nbsp;&nbsp;</TD>
                                                                        <TD noWrap align="right" style="BORDER-BOTTOM: #99cccc 1px solid">&nbsp;<asp:Label id="lblJYMJ" Runat="server" CssClass="label"></asp:Label>&nbsp;</TD>
                                                                        <TD class="label" noWrap align="right">&nbsp;&nbsp;乙方代理费(元)：&nbsp;&nbsp;</TD>
                                                                        <TD noWrap align="right" style="BORDER-BOTTOM: #99cccc 1px solid">&nbsp;<asp:Label id="lblYFDLF" Runat="server" CssClass="label"></asp:Label>&nbsp;</TD>
                                                                    </TR>
                                                                    <TR>
                                                                        <TD class="label" noWrap align="right">&nbsp;&nbsp;物业地址：&nbsp;&nbsp;</TD>
                                                                        <TD noWrap align="left" colSpan="9" style="BORDER-BOTTOM: #99cccc 1px solid">&nbsp;<asp:Label id="lblWYDZ" Runat="server" CssClass="label"></asp:Label>&nbsp;</TD>
                                                                    </TR>
                                                                </TABLE>
                                                            </TD>
                                                        </TR>
                                                    </table>
                                                    <% if propJSSH = "" then response.write("</div>") %>
                                                </td>
                                            </tr>
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
                    <TR id="trRow06">
                        <TD align="center" colSpan="3">
                            <TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
                                <TR>
                                    <TD height="4"></TD>
                                </TR>
                                <TR>
                                    <TD align="center">
                                        <asp:Button id="btnBJYJ"  Runat="server" CssClass="button" Text="补计佣金" Height="36px"></asp:Button>
                                        <asp:Button id="btnClose" Runat="server" CssClass="button" Text="返    回" Height="36px"></asp:Button>
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
                                    <TD id="tdErrInfo" style="FONT-SIZE: 32pt; COLOR: black; LINE-HEIGHT: 40pt; FONT-FAMILY: 宋体; LETTER-SPACING: 2pt" align="center"><asp:Label id="lblMessage" Runat="server"></asp:Label><P>&nbsp;&nbsp;</P><P><asp:Button id="btnGoBack" Runat="server" Text=" 返回 " Font-Size="24pt"></asp:Button></P></TD>
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
                        <input id="htxtSessionIdQueryJSS" type="hidden" runat="server"/>
                        <input id="htxtJSSQuery" type="hidden" runat="server"/>
                        <input id="htxtJSSRows" type="hidden" runat="server"/>
                        <input id="htxtJSSSort" type="hidden" runat="server"/>
                        <input id="htxtJSSSortColumnIndex" type="hidden" runat="server"/>
                        <input id="htxtJSSSortType" type="hidden" runat="server"/>
                        <input id="htxtDivLeftJSS" type="hidden" runat="server"/>
                        <input id="htxtDivTopJSS" type="hidden" runat="server"/>
                        <input id="htxtDivLeftBody" type="hidden" runat="server"/>
                        <input id="htxtDivTopBody" type="hidden" runat="server"/>
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
							function ScrollProc_divJSS() {
								var oText;
								oText=null;
								oText=document.getElementById("htxtDivTopJSS");
								if (oText != null) oText.value = divJSS.scrollTop;
								oText=null;
								oText=document.getElementById("htxtDivLeftJSS");
								if (oText != null) oText.value = divJSS.scrollLeft;
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
								oText=document.getElementById("htxtDivTopJSS");
								if (oText != null) divJSS.scrollTop = oText.value;
								oText=null;
								oText=document.getElementById("htxtDivLeftJSS");
								if (oText != null) divJSS.scrollLeft = oText.value;

								document.body.onscroll = ScrollProc_Body;
								divJSS.onscroll = ScrollProc_divJSS;
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
