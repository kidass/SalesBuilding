<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="estate_rs_jgxz.aspx.vb" Inherits="Josco.JSOA.web.estate_rs_jgxz" %>
<%@ Register TagPrefix="ComponentArt" Namespace="ComponentArt.Web.UI" Assembly="ComponentArt.Web.UI" %>
<%@ Register TagPrefix="uwin" Namespace="Josco.Web" Assembly="Josco.Web.PopMessage" %>
<!DOCTYPE HTML PUBLIC "-//W3C//Dtd HTML 4.0 transitional//EN">

<html  >
    <head>
        <title>架构选择窗</title>    
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR" /> 
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE" />
		<meta content="JavaScript" name="vs_defaultClientScript" />
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema" />
		<link href="../../../styles01.css" type="text/css" rel="stylesheet" />
		<style>
			TD.grdZWLISTLocked { ; LEFT:expression(divZWLIST.scrollLeft); POSITION: relative }
			TH.grdZWLISTLocked { ; LEFT:expression(divZWLIST.scrollLeft); POSITION: relative }
			TH.grdZWLISTLocked { Z-INDEX: 99 }			
			TH { Z-INDEX: 10; POSITION: relative }
		</style>				
		<script src="../../../scripts/transkey.js"></script>
		<script language="javascript">
			function window_onresize() 
			{
				var dblHeight  = 0;
				var dblWidth   = 0;
				var strHeight  = "";
				var strWidth   = "";
				var dblDeltaY  = 20;
				
				if (document.all("divZWLIST") == null)
					return;
				
				dblHeight = 350 + dblDeltaY + document.body.clientHeight - 470; //default state : 350px
				strHeight = parseInt(dblHeight.toString(), 10).toString() + "px";
				strWidth  = divZWLIST.style.width;
				divZWLIST.style.height = strHeight;
				divZWLIST.style.clip = "rect(0px " + strWidth + " " + strHeight + " 0px)";
				
			}
			function document_onreadystatechange() 
			{
				window_onresize();
			}
		</script>
		<script language="javascript" for="document" event="onreadystatechange" />
		<!--
			return document_onreadystatechange()
		//-->
		</script>
    </head>
<body background="../../../images/oabk.gif" bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" onresize="return window_onresize()">
    <form id="frmestate_rs_jgxz" runat="server" method="post" >
        <asp:Panel id="panelMain" Runat="server">
            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                <tr>
                    <td colspan="3" height="3"></td>
                </tr>
                <tr>
                    <td width="5"></td>
                    <td align="center">
                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
                            <tr>
                                <td class="label" vAlign="middle" align="center"><asp:Label id="lblTitle" Runat="server" Font-Bold="True" Font-Size="12px" Font-Name="宋体">架构人员选择窗</asp:Label><asp:LinkButton id="lnkBlank" runat="server" with="0px"></asp:LinkButton></td>
                            </tr>
                        </table>
                    </td>
                    <td with="5"></td>
                </tr>
                
                <tr>
                     <td colspan="3" height="3"></td>
                </tr>
                <tr>
                    <td with="5"></td>
                    <td valign="top" align="center">
                        <table cellspacing="0" cellpadding="0" border="0">
                            <tr>
                                <td colspan="3" height="3"></td>
                            </tr>
                            <tr>
                                <td valign="top" style="BORDER-RIGHT: #99cccc 1px solid; BORDER-TOP: #99cccc 1px solid; BORDER-LEFT: #99cccc 1px solid; BORDER-BOTTOM: #99cccc 1px solid">
							        <table cellSpacing="0" cellPadding="0" border="0">
							           
							            <tr>
											<td class="label" align="left" height="24">&nbsp;&nbsp;人员名称：<asp:TextBox id="txtSearchZWMC" Runat="server" Columns="16" CssClass="textbox"></asp:TextBox><asp:Button id="btnSearch" Runat="server" CssClass="button" Text=" 搜索 "></asp:Button></td>
							            </tr>
							            <tr>
											<td valign="top" align="left">
												<div id="divZWLIST" style="TABLE-LAYOUT: fixed; OVERFLOW: auto; WIDTH: 900px; CLIP: rect(0px 900px 550px 0px); HEIGHT: 550px;">
													<asp:datagrid id="grdZWLIST"  runat="server" Width="900px" CssClass="labelGrid" 
                                                        AllowPaging="True" AutoGenerateColumns="False" GridLines="Both" BackColor="White"
                                                        PageSize="900" BorderColor="#dfdfdf" BorderWidth="1px" AllowSorting="True" CellPadding="4"  UseAccessibleHeader="True" BorderStyle="Solid">
							                             <SelectedItemStyle  Font-Bold="False" VerticalAlign="Middle" HorizontalAlign="Center" ForeColor="blue" ></SelectedItemStyle>
                                                        <EditItemStyle   BackColor="#FFCC00" VerticalAlign="Middle" HorizontalAlign="Center" ></EditItemStyle>
                                                        <AlternatingItemStyle  BorderWidth="1px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="White"></AlternatingItemStyle>
                                                        <ItemStyle  BorderWidth="1px" HorizontalAlign="Center" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="#F7F7F7" ForeColor="Black"></ItemStyle>
                                                        <HeaderStyle   Font-Bold="True" HorizontalAlign="Center"  ForeColor="White" VerticalAlign="Middle" BackColor="#6699cc" ></HeaderStyle>
                                                        <FooterStyle BackColor="#CCCC99" HorizontalAlign="Center" ></FooterStyle>
                                                           <Columns>
														<asp:TemplateColumn HeaderText="选" ItemStyle-Width="0px" Visible="False">
															<HeaderStyle HorizontalAlign="Center" Width="0px"></HeaderStyle>
															<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
															<ItemTemplate>
																<asp:CheckBox id="chkRY" runat="server" AutoPostBack="False"></asp:CheckBox>
															</ItemTemplate>
														</asp:TemplateColumn>													
														<asp:ButtonColumn Visible="False" ItemStyle-Width="40px" DataTextField="人员类型" SortExpression="人员类型" HeaderText="类型" CommandName="Select">
															<HeaderStyle Width="40px"></HeaderStyle>
														</asp:ButtonColumn>														
														<asp:ButtonColumn ItemStyle-Width="100px" DataTextField="人员代码" SortExpression="人员代码" HeaderText="人员代码" CommandName="Select">
															<HeaderStyle Width="100px"></HeaderStyle>
														</asp:ButtonColumn>
														<asp:ButtonColumn ItemStyle-Width="80px" DataTextField="人员名称" SortExpression="人员名称" HeaderText="人员名称" CommandName="Select">
															<HeaderStyle Width="80px"></HeaderStyle>
														</asp:ButtonColumn>
														<asp:ButtonColumn ItemStyle-Width="100px" DataTextField="职级代码" SortExpression="职级代码" HeaderText="职级代码" CommandName="Select">
															<HeaderStyle Width="100px"></HeaderStyle>
														</asp:ButtonColumn>
														<asp:ButtonColumn ItemStyle-Width="120px" DataTextField="职级名称" SortExpression="职级名称" HeaderText="职级名称" CommandName="Select">
															<HeaderStyle Width="120px"></HeaderStyle>
														</asp:ButtonColumn>
														<asp:ButtonColumn ItemStyle-Width="170px" DataTextField="所属单位名称" SortExpression="所属单位名称" HeaderText="单位名称" CommandName="Select">
															<HeaderStyle Width="170px"></HeaderStyle>
														</asp:ButtonColumn>
														<asp:ButtonColumn ItemStyle-Width="60px" DataTextField="团队编号" SortExpression="团队编号" HeaderText="团队" CommandName="Select">
															<HeaderStyle Width="60px"></HeaderStyle>
														</asp:ButtonColumn>
														<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="所属分组" SortExpression="所属分组" HeaderText="所属分组" CommandName="Select">
															<HeaderStyle Width="0px"></HeaderStyle>
														</asp:ButtonColumn>
														<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="直管单位名称" SortExpression="直管单位名称" HeaderText="直管单位" CommandName="Select">
															<HeaderStyle Width="0px"></HeaderStyle>
														</asp:ButtonColumn>
														<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="上级领导名称" SortExpression="上级领导名称" HeaderText="上级领导" CommandName="Select">
															<HeaderStyle Width="0px"></HeaderStyle>
														</asp:ButtonColumn>
														<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="变动原因名称" SortExpression="变动原因名称" HeaderText="变动原因" CommandName="Select">
															<HeaderStyle Width="0px"></HeaderStyle>
														</asp:ButtonColumn>
														<asp:ButtonColumn ItemStyle-Width="90px" DataTextField="生效时间" SortExpression="生效时间" HeaderText="生效时间" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd}">
															<HeaderStyle Width="90px"></HeaderStyle>
														</asp:ButtonColumn>
														<asp:ButtonColumn ItemStyle-Width="40px" DataTextField="人员状态名称" SortExpression="人员状态名称" HeaderText="状态" CommandName="Select">
															<HeaderStyle Width="40px"></HeaderStyle>
														</asp:ButtonColumn>
														<asp:ButtonColumn ItemStyle-Width="40px" DataTextField="是否占编" SortExpression="是否占编" HeaderText="占编" CommandName="Select">
															<HeaderStyle Width="40px"></HeaderStyle>
														</asp:ButtonColumn>
														<asp:ButtonColumn ItemStyle-Width="40px" DataTextField="是否兼职" SortExpression="是否兼职" HeaderText="兼职" CommandName="Select">
															<HeaderStyle Width="40px"></HeaderStyle>
														</asp:ButtonColumn>														
														<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="唯一标识" SortExpression="唯一标识" HeaderText="唯一标识" CommandName="Select">
															<HeaderStyle Width="0px"></HeaderStyle>
														</asp:ButtonColumn>
														<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="人员状态" SortExpression="人员状态" HeaderText="人员状态代码" CommandName="Select">
															<HeaderStyle Width="0px"></HeaderStyle>
														</asp:ButtonColumn>
														<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="所属单位" SortExpression="所属单位" HeaderText="所属单位" CommandName="Select">
															<HeaderStyle Width="0px"></HeaderStyle>
														</asp:ButtonColumn>
														<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="直管单位" SortExpression="直管单位" HeaderText="直管单位码" CommandName="Select">
															<HeaderStyle Width="0px"></HeaderStyle>
														</asp:ButtonColumn>
														<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="上级领导" SortExpression="上级领导" HeaderText="上级领导代码" CommandName="Select">
															<HeaderStyle Width="0px"></HeaderStyle>
														</asp:ButtonColumn>
														<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="失效时间" SortExpression="失效时间" HeaderText="失效时间" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd HH:mm:ss}">
															<HeaderStyle Width="0px"></HeaderStyle>
														</asp:ButtonColumn>
														<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="变动原因" SortExpression="变动原因" HeaderText="变动原因代码" CommandName="Select">
															<HeaderStyle Width="0px"></HeaderStyle>
														</asp:ButtonColumn>														
														<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="标准序列" SortExpression="标准序列" HeaderText="标准序列" CommandName="Select">
															<HeaderStyle Width="0px"></HeaderStyle>
														</asp:ButtonColumn>
														<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="直管团队" SortExpression="直管团队" HeaderText="直管团队" CommandName="Select">
															<HeaderStyle Width="0px"></HeaderStyle>
														</asp:ButtonColumn>
														<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="协管团队" SortExpression="协管团队" HeaderText="协管团队" CommandName="Select">
															<HeaderStyle Width="0px"></HeaderStyle>
														</asp:ButtonColumn>
													</Columns>													
														<PagerStyle Visible="False" NextPageText="下页" Font-Size="12px" Font-Names="宋体" PrevPageText="上页" HorizontalAlign="Right" ForeColor="Black" Position="TopAndBottom" BackColor="SkyBlue"></PagerStyle>
													</asp:datagrid><input id="htxtZWLISTFixed" type="hidden" value="0" runat="server" name="htxtZWLISTFixed" /><asp:label id="lblZWLISTGridLocInfo" Visible=false runat="server" CssClass="label" Font-Name="宋体" Font-Size="12px"></asp:label>
											</td>
							            </tr>
							        </table>
							    </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="3">
								    <asp:button id="btnOK" Runat="server" Font-Size="12px" Font-Name="宋体" CssClass="button" Text=" 确  定 " Height="36px" Width="96px"></asp:button>
								    <asp:button id="btnCancel" Runat="server" Font-Size="12px" Font-Name="宋体" CssClass="button" Text=" 取  消 " Height="36px" Width="96px"></asp:button>
							    </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <asp:Panel id="panelError" Runat="server">
            <table id="tabErrMain" height="98%" cellSpacing="0" cellPadding="0" width="100%" border="0">
					<tr>
						<td width="5%"></td>
						<td>
							<table height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
								<tr>
									<td>&nbsp;&nbsp;&nbsp;&nbsp;</td>
									<td id="tdErrInfo" style="FONT-SIZE: 32pt; COLOR: black; LINE-HEIGHT: 40pt; FONT-FAMILY: 宋体; LETTER-SPACING: 2pt" align="center"><asp:Label id="lblMessage" Runat="server"></asp:Label><p>&nbsp;&nbsp;</p><p><input type="button" id="btnGoBack" value=" 返回 " style="FONT-SIZE: 24pt; FONT-FAMILY: 宋体" onclick="javascript:history.back();"></p></td>
									<td>&nbsp;&nbsp;&nbsp;&nbsp;</td>
								</tr>
							</table>
						</td>
						<td width="5%"></td>
					</tr>
				</table>
        </asp:Panel>
        <table cellSpacing="0" cellPadding="0" align="center" border="0">
				<tr>
					<td>
						<input id="htxtSessionIdZWSEL" type="hidden" runat="server">
						<input id="htxtZWSELSort" type="hidden" runat="server">
						<input id="htxtZWSELSortColumnIndex" type="hidden" runat="server">
						<input id="htxtZWSELSortType" type="hidden" runat="server">
						<input id="htxtZWLISTQuery" type="hidden" runat="server">
						<input id="htxtZWLISTSort" type="hidden" runat="server">
						<input id="htxtZWLISTSortColumnIndex" type="hidden" runat="server">
						<input id="htxtZWLISTSortType" type="hidden" runat="server">
						<input id="htxtZWLISTRows" type="hidden" runat="server">
						<input id="htxtdivLeftZWSEL" type="hidden" runat="server">
						<input id="htxtdivTopZWSEL" type="hidden" runat="server">
						<input id="htxtdivLeftZWLIST" type="hidden" runat="server">
						<input id="htxtdivTopZWLIST" type="hidden" runat="server">
						<input id="htxtdivLeftBody" type="hidden" runat="server">
						<input id="htxtdivTopBody" type="hidden" runat="server">
					</td>
				</tr>
				<tr>
					<td>
						<script language="javascript">
							function ScrollProc_Body() {
								var oText;
								oText=null;
								oText=document.getElementById("htxtdivTopBody");
								if (oText != null) oText.value = document.body.scrollTop;
								oText=null;
								oText=document.getElementById("htxtdivLeftBody");
								if (oText != null) oText.value = document.body.scrollLeft;
								return;
							}
							function ScrollProc_divZWLIST() {
								var oText;
								oText=null;
								oText=document.getElementById("htxtdivTopZWLIST");
								if (oText != null) oText.value = divZWLIST.scrollTop;
								oText=null;
								oText=document.getElementById("htxtdivLeftZWLIST");
								if (oText != null) oText.value = divZWLIST.scrollLeft;
								return;
							}						
							try {
								var Text;

								oText=null;
								oText=document.getElementById("htxtdivTopBody");
								if (oText != null) document.body.scrollTop = oText.value;
								oText=null;
								oText=document.getElementById("htxtdivLeftBody");
								if (oText != null) document.body.scrollLeft = oText.value;

								oText=null;
								oText=document.getElementById("htxtdivTopZWLIST");
								if (oText != null) divZWLIST.scrollTop = oText.value;
								oText=null;
								oText=document.getElementById("htxtdivLeftZWLIST");
								if (oText != null) divZWLIST.scrollLeft = oText.value;

								document.body.onscroll = ScrollProc_Body;
								divZWLIST.onscroll = ScrollProc_divZWLIST;
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
</html>
