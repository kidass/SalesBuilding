<%@ Page Language="vb" AutoEventWireup="false" Codebehind="estate_es_yjjt.aspx.vb" Inherits="Josco.JSOA.web.estate_es_yjjt" %>
<%@ Register TagPrefix="uwin" Namespace="Josco.Web" Assembly="Josco.Web.PopMessage" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
    <HEAD>
        <title>查看佣金计提情况</title>
        <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR"/>
        <meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE"/>
        <meta content="JavaScript" name="vs_defaultClientScript"/>
        <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
        <LINK href="../../../styles01.css" type="text/css" rel="stylesheet"/>
        <style>
		    TD.grdYJLocked { ; LEFT: expression(divYJ.scrollLeft); POSITION: relative }
		    TH.grdYJLocked { ; LEFT: expression(divYJ.scrollLeft); POSITION: relative }
		    TH.grdYJLocked { Z-INDEX: 99 }
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
				
				if (document.all("divYJ") == null)
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
				strHeight  = intHeight.toString() + "px";

				divYJ.style.width  = strWidth;
				divYJ.style.height = strHeight;
				divYJ.style.clip   = "rect(0px " + strWidth + " " + strHeight + " 0px)";
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
        <form id="frmestate_es_yjjt" method="post" runat="server">
            <asp:panel id="panelMain" Runat="server">
                <TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
                    <TR>
                        <TD width="5"></TD>
                        <TD vAlign="top" align="center">
                            <TABLE cellSpacing="0" cellPadding="0" border="0">
                                <TR id="trRow01">
                                    <TD class="title" align="center" colSpan="3" height="30">查看佣金计提情况<asp:LinkButton id="lnkBlank" Runat="server" Width="0px"></asp:LinkButton></TD>
                                </TR>
                                <TR>
                                    <TD width="5"></TD>
                                    <TD vAlign="top">
                                        <TABLE cellSpacing="0" cellPadding="0" border="0">
                                            <TR>
                                                <TD>
                                                    <TABLE cellSpacing="0" cellPadding="0" align="center" border="0">
                                                        <TR id="trRow02">
                                                            <TD align="left">
                                                                <TABLE cellSpacing="0" cellPadding="0" border="0">
                                                                    <TR>
                                                                        <td class="label" vAlign="middle" align="right">&nbsp;&nbsp;人员代码&nbsp;<asp:TextBox ID="txtYJSearch_RYDM" runat="server" CssClass="textbox" Columns="18"></asp:TextBox></td>
                                                                        <td class="label" vAlign="middle" align="right">&nbsp;&nbsp;人员名称&nbsp;<asp:TextBox ID="txtYJSearch_RYMC" runat="server" CssClass="textbox" Columns="12"></asp:TextBox></td>
                                                                        <TD class="label" vAlign="middle" align="right">&nbsp;&nbsp;计佣年月&nbsp;<asp:textbox id="txtYJSearch_JYNYMin" runat="server" Columns="6" CssClass="textbox"></asp:textbox>-<asp:textbox id="txtYJSearch_JYNYMax" runat="server" Columns="6" CssClass="textbox"></asp:textbox></TD>
                                                                        <TD class="label" vAlign="middle" align="right">&nbsp;&nbsp;接案年月&nbsp;<asp:textbox id="txtYJSearch_JANYMin" runat="server" Columns="6" CssClass="textbox"></asp:textbox>-<asp:textbox id="txtYJSearch_JANYMax" runat="server" Columns="6" CssClass="textbox"></asp:textbox></TD>
                                                                        <TD class="label" align="right">&nbsp;&nbsp;<asp:button id="btnYJSearch" Runat="server" CssClass="button" Text="快速搜索"></asp:button><asp:button id="btnYJSearch_Full" Runat="server" CssClass="button" Text="全文搜索"></asp:button></TD>
                                                                    </TR>
                                                                </TABLE>
                                                            </TD>
                                                        </TR>
                                                        <TR>
                                                            <TD>
                                                                <DIV id="divYJ" style="BORDER-RIGHT: #99cccc 1px solid; TABLE-LAYOUT: fixed; BORDER-TOP: #99cccc 1px solid; OVERFLOW: auto; BORDER-LEFT: #99cccc 1px solid; WIDTH: 964px; CLIP: rect(0px 964px 406px 0px); BORDER-BOTTOM: #99cccc 1px solid; HEIGHT: 406px">
                                                                    <asp:datagrid id="grdYJ" runat="server" Width="2000px" CssClass="label" UseAccessibleHeader="True"
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
                                                                                    <asp:CheckBox id="chkYJ" runat="server" AutoPostBack="False" Visible="False"></asp:CheckBox>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateColumn>
                                                                            
                                                                            <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="唯一标识" SortExpression="唯一标识" HeaderText="唯一标识" CommandName="Select">
                                                                                <HeaderStyle Width="0px"></HeaderStyle>
                                                                            </asp:ButtonColumn>
                                                                            
                                                                            <asp:ButtonColumn ItemStyle-Width="100px" DataTextField="计佣年月" SortExpression="计佣年月" HeaderText="计佣年月" CommandName="Select">
                                                                                <HeaderStyle Width="100px"></HeaderStyle>
                                                                            </asp:ButtonColumn>
                                                                            <asp:ButtonColumn ItemStyle-Width="100px" DataTextField="接案年月" SortExpression="接案年月" HeaderText="接案年月" CommandName="Select">
                                                                                <HeaderStyle Width="100px"></HeaderStyle>
                                                                            </asp:ButtonColumn>
                                                                            <asp:ButtonColumn ItemStyle-Width="100px" DataTextField="计佣标准" SortExpression="计佣标准" HeaderText="计佣标准" CommandName="Select">
                                                                                <HeaderStyle Width="100px"></HeaderStyle>
                                                                            </asp:ButtonColumn>
                                                                            <asp:ButtonColumn ItemStyle-Width="100px" DataTextField="业绩标记" SortExpression="业绩标记" HeaderText="业绩类型" CommandName="Select">
                                                                                <HeaderStyle Width="100px"></HeaderStyle>
                                                                            </asp:ButtonColumn>
                                                                            
                                                                            <asp:ButtonColumn ItemStyle-Width="160px" DataTextField="月初业绩" SortExpression="月初业绩" HeaderText="月初业绩" CommandName="Select" DataTextFormatString="{0:#,###.00}" ItemStyle-HorizontalAlign="Right">
                                                                                <HeaderStyle Width="160px" HorizontalAlign="Right"></HeaderStyle>
                                                                            </asp:ButtonColumn>
                                                                            <asp:ButtonColumn ItemStyle-Width="160px" DataTextField="本月业绩" SortExpression="本月业绩" HeaderText="本月业绩" CommandName="Select" DataTextFormatString="{0:#,###.00}" ItemStyle-HorizontalAlign="Right">
                                                                                <HeaderStyle Width="160px" HorizontalAlign="Right"></HeaderStyle>
                                                                            </asp:ButtonColumn>
                                                                            <asp:ButtonColumn ItemStyle-Width="160px" DataTextField="计提佣金" SortExpression="计提佣金" HeaderText="计提佣金" CommandName="Select" DataTextFormatString="{0:#,###.00}" ItemStyle-HorizontalAlign="Right">
                                                                                <HeaderStyle Width="160px" HorizontalAlign="Right"></HeaderStyle>
                                                                            </asp:ButtonColumn>
                                                                            
                                                                            <asp:ButtonColumn ItemStyle-Width="120px" DataTextField="经办人员" SortExpression="经办人员" HeaderText="经办人员代码" CommandName="Select">
                                                                                <HeaderStyle Width="120px"></HeaderStyle>
                                                                            </asp:ButtonColumn>
                                                                            <asp:ButtonColumn ItemStyle-Width="120px" DataTextField="经办人员名称" SortExpression="经办人员名称" HeaderText="经办人员" CommandName="Select">
                                                                                <HeaderStyle Width="120px"></HeaderStyle>
                                                                            </asp:ButtonColumn>
                                                                            <asp:ButtonColumn Visible="false" ItemStyle-Width="0px" DataTextField="经办单位" SortExpression="经办单位" HeaderText="经办单位代码" CommandName="Select">
                                                                                <HeaderStyle Width="0px"></HeaderStyle>
                                                                            </asp:ButtonColumn>
                                                                            <asp:ButtonColumn ItemStyle-Width="200px" DataTextField="经办单位名称" SortExpression="经办单位名称" HeaderText="经办单位" CommandName="Select">
                                                                                <HeaderStyle Width="200px"></HeaderStyle>
                                                                            </asp:ButtonColumn>
                                                                            <asp:ButtonColumn ItemStyle-Width="100px" DataTextField="团队编号" SortExpression="团队编号" HeaderText="团队编号" CommandName="Select">
                                                                                <HeaderStyle Width="100px"></HeaderStyle>
                                                                            </asp:ButtonColumn>
                                                                            <asp:ButtonColumn ItemStyle-Width="100px" DataTextField="直管标记" SortExpression="直管标记" HeaderText="直管标记" CommandName="Select">
                                                                                <HeaderStyle Width="100px"></HeaderStyle>
                                                                            </asp:ButtonColumn>
                                                                            
                                                                            <asp:ButtonColumn Visible="false" ItemStyle-Width="0px" DataTextField="人员职级" SortExpression="人员职级" HeaderText="人员职级代码" CommandName="Select">
                                                                                <HeaderStyle Width="0px"></HeaderStyle>
                                                                            </asp:ButtonColumn>
                                                                            <asp:ButtonColumn ItemStyle-Width="200px" DataTextField="人员职级名称" SortExpression="人员职级名称" HeaderText="人员职级" CommandName="Select">
                                                                                <HeaderStyle Width="200px"></HeaderStyle>
                                                                            </asp:ButtonColumn>
                                                                            
                                                                            <asp:ButtonColumn ItemStyle-Width="140px" DataTextField="计佣开始" SortExpression="计佣开始" HeaderText="计佣开始" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd}">
                                                                                <HeaderStyle Width="140px"></HeaderStyle>
                                                                            </asp:ButtonColumn>
                                                                            <asp:ButtonColumn ItemStyle-Width="140px" DataTextField="计佣结束" SortExpression="计佣结束" HeaderText="计佣结束" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd}">
                                                                                <HeaderStyle Width="140px"></HeaderStyle>
                                                                            </asp:ButtonColumn>
                                                                        </Columns>
                                                                        <PagerStyle Visible="False" NextPageText="下页" PrevPageText="上页" HorizontalAlign="Right" ForeColor="Black" Position="TopAndBottom" BackColor="SkyBlue"></PagerStyle>
                                                                    </asp:datagrid><INPUT id="htxtYJFixed" type="hidden" value="0" runat="server"/>
                                                                </DIV>
                                                            </TD>
                                                        </TR>
                                                        <TR id="trRow03">
                                                            <TD class="label">
                                                                <TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
                                                                    <TR>
                                                                        <TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZYJDeSelectAll" runat="server">不选</asp:linkbutton></TD>
                                                                        <TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZYJSelectAll" runat="server">全选</asp:linkbutton></TD>
                                                                        <TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZYJMoveFirst" runat="server">最前</asp:linkbutton></TD>
                                                                        <TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZYJMovePrev" runat="server">前页</asp:linkbutton></TD>
                                                                        <TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZYJMoveNext" runat="server">下页</asp:linkbutton></TD>
                                                                        <TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZYJMoveLast" runat="server">最后</asp:linkbutton></TD>
                                                                        <TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZYJGotoPage" runat="server">前往</asp:linkbutton><asp:textbox id="txtYJPageIndex" runat="server" Columns="3" CssClass="textbox">1</asp:textbox>页</TD>
                                                                        <TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZYJSetPageSize" runat="server">每页</asp:linkbutton><asp:textbox id="txtYJPageSize" runat="server" Columns="3" CssClass="textbox">30</asp:textbox>条</TD>
                                                                        <TD class="label" vAlign="middle" noWrap align="right"><asp:label id="lblYJGridLocInfo" runat="server" CssClass="label">1/10 N/15</asp:label></TD>
                                                                    </TR>
                                                                </TABLE>
                                                            </TD>
                                                        </TR>
                                                    </TABLE>
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
                    <TR id="trRow04">
                        <TD align="center" colSpan="3">
                            <TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
                                <TR>
                                    <TD height="4"></TD>
                                </TR>
                                <TR>
                                    <TD align="center">
							            <asp:Button id="btnPrint" Runat="server" CssClass="button" Text=" 打    印 " Height="36px"></asp:Button>
                                        <asp:Button id="btnClose" Runat="server" CssClass="button" Text=" 返    回 " Height="36px"></asp:Button>
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
                        <input id="htxtSessionIdQueryYJ" type="hidden" runat="server"/>
                        <input id="htxtYJQuery" type="hidden" runat="server"/>
                        <input id="htxtYJRows" type="hidden" runat="server"/>
                        <input id="htxtYJSort" type="hidden" runat="server"/>
                        <input id="htxtYJSortColumnIndex" type="hidden" runat="server"/>
                        <input id="htxtYJSortType" type="hidden" runat="server"/>
                        <input id="htxtDivLeftYJ" type="hidden" runat="server"/>
                        <input id="htxtDivTopYJ" type="hidden" runat="server"/>
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
							function ScrollProc_divYJ() {
								var oText;
								oText=null;
								oText=document.getElementById("htxtDivTopYJ");
								if (oText != null) oText.value = divYJ.scrollTop;
								oText=null;
								oText=document.getElementById("htxtDivLeftYJ");
								if (oText != null) oText.value = divYJ.scrollLeft;
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
								oText=document.getElementById("htxtDivTopYJ");
								if (oText != null) divYJ.scrollTop = oText.value;
								oText=null;
								oText=document.getElementById("htxtDivLeftYJ");
								if (oText != null) divYJ.scrollLeft = oText.value;

								document.body.onscroll = ScrollProc_Body;
								divYJ.onscroll = ScrollProc_divYJ;
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
