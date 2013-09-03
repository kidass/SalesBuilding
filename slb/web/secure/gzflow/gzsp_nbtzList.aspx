<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="gzsp_nbtzList.aspx.vb" Inherits="Josco.JSOA.web.gzsp_nbtzList" %>
<%@ Register TagPrefix="ComponentArt" Namespace="ComponentArt.Web.UI" Assembly="ComponentArt.Web.UI" %>
<%@ Register TagPrefix="uwin" Namespace="Josco.Web" Assembly="Josco.Web.PopMessage" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>人事内部调整人员一览表</title>            
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles01.css" type="text/css" rel="stylesheet">
		<link href="../../mnuStyle01.css" type="text/css" rel="stylesheet">
		<style>
			TD.grdRSLYGLLocked { ; LEFT: expression(divRSLYGL.scrollLeft); POSITION: relative }
			TH.grdRSLYGLLocked { ; LEFT: expression(divRSLYGL.scrollLeft); POSITION: relative }
			TH.grdRSLYGLLocked { Z-INDEX: 99 }
			TH { Z-INDEX: 10; POSITION: relative }
		</style>
		<script src="../../scripts/transkey.js"></script>
		<script language="javascript">  
		<!--
			function doMenuItemClick(menuItemId, param00) 
			{
				try {
					document.all("htxtSelectMenuID").value = menuItemId;
					document.all("htxtMenuParam00").value = param00;
					window.setTimeout("__doPostBack('lnkMenu', '');", 500);
				} catch (e) {}
			}
			function window_onresize() 
			{
				var dblHeight = 0;
				var dblWidth  = 0;
				var strHeight = "";
				var strWidth  = "";
				
				if (document.all("divRSLYGL") == null)
					return;

				intWidth   = document.body.clientWidth;   //总宽度
				intWidth  -= 24;                          //滚动条
				intWidth  -= 2 * 4;                       //左、右空白
				intWidth  -= 16;                          //调整数
				strWidth   = intWidth.toString() + "px";
				
				intHeight  = document.body.clientHeight;  //总高度
				intHeight -= 24;                          //调整数
				intHeight -= trRow0.clientHeight;
				intHeight -= trRow1.clientHeight;
				intHeight -= trRow2.clientHeight;
				intHeight -= trRow3.clientHeight;
				strHeight  = intHeight.toString() + "px";

				document.all("divRSLYGL").style.width  = strWidth;
				document.all("divRSLYGL").style.height = strHeight;
				document.all("divRSLYGL").style.clip   = "rect(0px " + strWidth + " " + strHeight + " 0px)";
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
	<body onresize="return window_onresize()" bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" background="../../images/oabk.gif">
		<form id="frmestate_rs_luyong_main" method="post" runat="server">
			<asp:panel id="panelMain" Runat="server">
				<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
					<TR>
						<TD width="4">
                        <TD id="trRow0" height="30" class="title" vAlign="middle" align="left">当前位置：人事管理&nbsp;&gt;&gt;&gt;&gt;&nbsp;综合流程管理&nbsp;&gt;&gt;&gt;&gt;&nbsp;人事内部调整人员一览表</TD>
                        <TD width="4">
                    </TR>					
                    <TR id="trRow1">
						<TD width="4"><asp:LinkButton id="lnkBlank" Runat="server" Width="0px"></asp:LinkButton><asp:LinkButton id="lnkMenu" Runat="server" Width="0px"></asp:LinkButton><INPUT id="htxtSelectMenuID" type="hidden" size="1" runat="server"><INPUT id="htxtMenuParam00" type="hidden" size="1" runat="server"></TD>
						<TD align="center">
							<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
								<TR>
									<TD>
						                <ComponentArt:Menu id="mnuMain" runat="server" width="100%" Orientation="Horizontal" CssClass="TopGroup"
								            DefaultGroupCssClass="MenuGroup" DefaultSubGroupExpandOffsetX="-10" DefaultSubGroupExpandOffsetY="-5"
								            DefaultItemLookID="DefaultItemLook" TopGroupItemSpacing="1" DefaultGroupItemSpacing="2" ImagesBaseUrl="../images/"
								            EnableViewState="false" ExpandDelay="100" DefaultTarget="mainFrame">
											<ITEMS>
											    <COMPONENTART:MENUITEM id="mnuOpen" DisabledLookId="MenuItemDisabledLook" Target="mainFrame" Text="打开文件" ClientSideCommand="doMenuItemClick('mnuOpen','');"></COMPONENTART:MENUITEM>																					
												<COMPONENTART:MENUITEM id="mnuPrint_DYQD" DisabledLookId="MenuItemDisabledLook" Target="mainFrame" Text="打印审批文件" ClientSideCommand="doMenuItemClick('mnuPrint_DYQD','');"></COMPONENTART:MENUITEM>													
												<COMPONENTART:MENUITEM id="mnuRefresh" DisabledLookId="MenuItemDisabledLook" Target="mainFrame" Text="刷新显示" ClientSideCommand="doMenuItemClick('mnuRefresh','');"></COMPONENTART:MENUITEM>
												<COMPONENTART:MENUITEM id="mnuClose" DisabledLookId="MenuItemDisabledLook" Target="mainFrame" Text="返回上级" ClientSideCommand="doMenuItemClick('mnuClose','');"></COMPONENTART:MENUITEM>
											</ITEMS>
											<ITEMLOOKS>
	        								  	<COMPONENTART:ItemLook LookID="TopItemLook" CssClass="TopMenuItem" HoverCssClass="TopMenuItemHover" LabelPaddingLeft="15" LabelPaddingRight="15" LabelPaddingTop="4" LabelPaddingBottom="4" />
									            <COMPONENTART:ItemLook LookID="DefaultItemLook" CssClass="MenuItem" HoverCssClass="MenuItemHover" ExpandedCssClass="MenuItemHover" LabelPaddingLeft="18" LabelPaddingRight="12" LabelPaddingTop="4" LabelPaddingBottom="4" />
									            <COMPONENTART:ItemLook LookID="MenuItemDisabledLook" CssClass="MenuItemDisabled" HoverCssClass="" ExpandedCssClass="" LabelPaddingLeft="18" LabelPaddingRight="12" LabelPaddingTop="4" LabelPaddingBottom="4" />
									            <COMPONENTART:ItemLook LookID="BreakItem" CssClass="MenuBreak" ImageHeight="2" ImageWidth="100%" ImageUrl="../images/menu01/break.gif" />
											</ITEMLOOKS>
										</ComponentArt:Menu>
									</TD>
								</TR>
							</TABLE>
						</TD>
						<TD width="4"></TD>
					</TR>
					<TR>
						<TD width="4"></TD>
						<TD style="BORDER-RIGHT: #99cccc 1px solid; BORDER-TOP: #99cccc 1px solid; BORDER-LEFT: #99cccc 1px solid; BORDER-BOTTOM: #99cccc 1px solid" vAlign="top" align="center">
							<TABLE cellSpacing="0" cellPadding="0" border="0">
								<TR>
									<TD colSpan="3" height="4"></TD>
								</TR>
								<TR>
									<TD width="5"></TD>
									<TD vAlign="top">
										<TABLE cellSpacing="0" cellPadding="0" border="0">
											<TR>
												<TD class="label" align="left">
													<TABLE cellSpacing="0" cellPadding="0" border="0">
														<TR id="trRow3">
														    <TD class="label" vAlign="middle" align="right">经办日期</TD>
															<TD class="label" align="left"><asp:textbox id="txtSearch_APRQMin" runat="server"  CssClass="textbox-text" Columns="10" ></asp:textbox>~<asp:textbox id="txtSearch_APRQMAX" runat="server"  CssClass="textbox-text" Columns="10" ></asp:textbox></TD>
															<TD class="label" vAlign="middle">人员代码&nbsp;</TD>
															<TD class="label" align="left"><asp:textbox id="txtRSLYGLSearch_WJBT" runat="server" CssClass="textbox" Font-Size="12px" Columns="15" Font-Names="宋体"></asp:textbox></TD>
															<TD class="label" vAlign="middle">&nbsp;&nbsp;人员姓名&nbsp;</TD>
															<TD class="label" align="left"><asp:textbox id="txtRYXM" runat="server" CssClass="textbox" Font-Size="12px" Columns="15" Font-Names="宋体"></asp:textbox></TD>
															<TD class="label" vAlign="middle">&nbsp;&nbsp;原单位&nbsp;</TD>
															<TD class="label" align="left"><asp:textbox id="txtRZDW" runat="server" CssClass="textbox" Font-Size="12px" Columns="15" Font-Names="宋体"></asp:textbox></TD>
															<TD class="label" vAlign="middle">&nbsp;&nbsp;调入单位&nbsp;</TD>
															<TD class="label" align="left"><asp:textbox id="txtDRDW" runat="server" CssClass="textbox" Font-Size="12px" Columns="15" Font-Names="宋体"></asp:textbox></TD>
															<TD class="label" vAlign="middle">&nbsp;&nbsp;审批状态&nbsp;</TD>
															<TD class="label" align="left"><asp:DropDownList ID="ddlRSLYGLSearch_BLZT" Runat="server" CssClass="textbox">
															        <asp:ListItem Value=""></asp:ListItem>
															        <asp:ListItem Value="已通过">已通过</asp:ListItem>
															        <asp:ListItem Value="未审批">未审批</asp:ListItem>
															    </asp:DropDownList>
															</td>
															<TD class="label">&nbsp;&nbsp;<asp:button id="btnRSLYGLSearch" Runat="server" CssClass="button" Font-Name="宋体" Font-Size="12px" Text="搜索"></asp:button></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
											<TR>
												<TD>
													<DIV id="divRSLYGL" style="BORDER-RIGHT: #99cccc 1px solid; TABLE-LAYOUT: fixed; BORDER-TOP: #99cccc 1px solid; OVERFLOW: auto; BORDER-LEFT: #99cccc 1px solid; WIDTH: 800px; CLIP: rect(0px 800px 420px 0px); BORDER-BOTTOM: #99cccc 1px solid; HEIGHT: 420px">
														 <asp:datagrid id="grdRSLYGL" runat="server" Width="3060px" CssClass="labelGrid" 
                                                                AllowPaging="True" AutoGenerateColumns="False" GridLines="Both" BackColor="White"
                                                                PageSize="250" BorderColor="#dfdfdf" BorderWidth="1px" AllowSorting="True" CellPadding="4"  UseAccessibleHeader="True" BorderStyle="Solid">
									                             <SelectedItemStyle  Font-Bold="False" VerticalAlign="Middle" HorizontalAlign="Center" ForeColor="blue" ></SelectedItemStyle>
                                                                <EditItemStyle   BackColor="#FFCC00" VerticalAlign="Middle" HorizontalAlign="Center" ></EditItemStyle>
                                                                <AlternatingItemStyle  BorderWidth="1px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="White"></AlternatingItemStyle>
                                                                <ItemStyle  BorderWidth="1px" HorizontalAlign="Center" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="#F7F7F7" ForeColor="Black"></ItemStyle>
                                                                <HeaderStyle   Font-Bold="True" HorizontalAlign="Center"  ForeColor="White" VerticalAlign="Middle" BackColor="#6699cc" ></HeaderStyle>
                                                                <FooterStyle BackColor="#CCCC99" HorizontalAlign="Center"></FooterStyle>
                                                                                        
															<Columns>
																<asp:TemplateColumn HeaderText="选" ItemStyle-Width="20px">
																	<HeaderStyle HorizontalAlign="Center" Width="20px"></HeaderStyle>
																	<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
																	<ItemTemplate>
																		<asp:CheckBox id="chkRSLYGL" runat="server" AutoPostBack="False" Width="30px"></asp:CheckBox>
																	</ItemTemplate>
																</asp:TemplateColumn>
																<asp:ButtonColumn ItemStyle-Width="100px" DataTextField="办理状态" SortExpression="办理状态" HeaderText="办理状态" CommandName="Select">
                                                                    <HeaderStyle Width="100px"></HeaderStyle>
                                                                </asp:ButtonColumn>                                                                                                                                                                
                                                                <asp:ButtonColumn ItemStyle-Width="100px" DataTextField="人员姓名" SortExpression="人员姓名" HeaderText="姓名" CommandName="Select">
                                                                    <HeaderStyle Width="100px"></HeaderStyle>  
                                                                 </asp:ButtonColumn> 
                                                                 <asp:ButtonColumn ItemStyle-Width="120px" DataTextField="原职级名称" SortExpression="原职级名称" HeaderText="原职级名称" CommandName="Select">
                                                                    <HeaderStyle Width="120px"></HeaderStyle>
                                                                </asp:ButtonColumn>   
                                                                <asp:ButtonColumn ItemStyle-Width="120px" DataTextField="职级名称" SortExpression="职级名称" HeaderText="现职级名称" CommandName="Select">
                                                                    <HeaderStyle Width="120px"></HeaderStyle>
                                                                </asp:ButtonColumn>
                                                                <asp:ButtonColumn ItemStyle-Width="100px" DataTextField="原单位名称" SortExpression="原单位名称" HeaderText="原单位名称" CommandName="Select">
                                                                    <HeaderStyle Width="100px"></HeaderStyle>
                                                                </asp:ButtonColumn>
                                                                <asp:ButtonColumn ItemStyle-Width="100px" DataTextField="单位名称" SortExpression="单位名称" HeaderText="现单位名称" CommandName="OpenDocument">
                                                                    <HeaderStyle Width="100px"></HeaderStyle>
                                                                </asp:ButtonColumn>   
                                                                 <asp:ButtonColumn ItemStyle-Width="60px" DataTextField="原团队编号" SortExpression="原团队编号" HeaderText="原团队" CommandName="OpenDocument">
                                                                    <HeaderStyle Width="60px"></HeaderStyle>
                                                                </asp:ButtonColumn>
                                                                <asp:ButtonColumn ItemStyle-Width="60px" DataTextField="团队编号" SortExpression="团队编号" HeaderText="现团队" CommandName="Select">
                                                                    <HeaderStyle Width="60px"></HeaderStyle>
                                                                </asp:ButtonColumn>        
                                                                <asp:ButtonColumn  ItemStyle-Width="100px" DataTextField="上级经理" SortExpression="上级经理" HeaderText="原上级经理" CommandName="Select">
                                                                    <HeaderStyle Width="100px"></HeaderStyle>
                                                                </asp:ButtonColumn>  
                                                                 <asp:ButtonColumn  ItemStyle-Width="100px" DataTextField="上级领导名称" SortExpression="上级领导名称" HeaderText="新上级经理" CommandName="Select">
                                                                    <HeaderStyle Width="100px"></HeaderStyle>
                                                                </asp:ButtonColumn>                                                                                          
                                                                <asp:ButtonColumn  ItemStyle-Width="160px" DataTextField="原直管团队名称" SortExpression="原直管团队名称" HeaderText="原直管团队" CommandName="Select">
                                                                    <HeaderStyle Width="160px"></HeaderStyle>
                                                                </asp:ButtonColumn> 
                                                                <asp:ButtonColumn  ItemStyle-Width="160px" DataTextField="直管团队名称" SortExpression="直管团队名称" HeaderText="现直管团队" CommandName="Select">
                                                                    <HeaderStyle Width="160px"></HeaderStyle>
                                                                </asp:ButtonColumn>
                                                                <asp:ButtonColumn  ItemStyle-Width="160px" DataTextField="原协管团队名称" SortExpression="原协管团队名称" HeaderText="原协管团队" CommandName="Select">
                                                                    <HeaderStyle Width="160px"></HeaderStyle>
                                                                </asp:ButtonColumn> 
                                                                <asp:ButtonColumn  ItemStyle-Width="160px" DataTextField="协管团队名称" SortExpression="协管团队名称" HeaderText="现协管团队" CommandName="Select">
                                                                    <HeaderStyle Width="160px"></HeaderStyle>
                                                                </asp:ButtonColumn> 									                             
									                            <asp:ButtonColumn ItemStyle-Width="100px" DataTextField="原因名称" SortExpression="原因名称" HeaderText="变动名称" CommandName="Select">
                                                                    <HeaderStyle Width="100px"></HeaderStyle>
                                                                </asp:ButtonColumn>                                                                      
                                                                <asp:ButtonColumn ItemStyle-Width="80px" DataTextField="人员代码" SortExpression="人员代码" HeaderText="人员代码" CommandName="Select">
                                                                    <HeaderStyle Width="80px"></HeaderStyle>
                                                                </asp:ButtonColumn>   
                                                                <asp:ButtonColumn ItemStyle-Width="100px" DataTextField="原人员状态名称" SortExpression="原人员状态名称" HeaderText="原人员状态" CommandName="Select">
                                                                    <HeaderStyle Width="100px"></HeaderStyle>
                                                                </asp:ButtonColumn>                                                                                                   
                                                                <asp:ButtonColumn ItemStyle-Width="100px" DataTextField="人员状态名称" SortExpression="人员状态名称" HeaderText="现人员状态" CommandName="Select">
                                                                    <HeaderStyle Width="100px"></HeaderStyle>
                                                                </asp:ButtonColumn>  
                                                                <asp:ButtonColumn ItemStyle-Width="100px" DataTextField="原占编" SortExpression="原占编" HeaderText="原占编" CommandName="Select">
                                                                    <HeaderStyle Width="100px"></HeaderStyle>                                                                                                
                                                                </asp:ButtonColumn> 
                                                                <asp:ButtonColumn ItemStyle-Width="100px" DataTextField="占编" SortExpression="占编" HeaderText="占编" CommandName="Select">
                                                                    <HeaderStyle Width="100px"></HeaderStyle>
                                                                </asp:ButtonColumn>   
                                                                <asp:ButtonColumn ItemStyle-Width="100px" DataTextField="审批说明" SortExpression="审批说明" HeaderText="审核说明" CommandName="Select">
                                                                    <HeaderStyle Width="100px"></HeaderStyle>
                                                                </asp:ButtonColumn> 
                                                                 <asp:ButtonColumn ItemStyle-Width="120px" DataTextField="审批日期" SortExpression="审批日期" HeaderText="审核日期" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd}">
                                                                    <HeaderStyle Width="120px"></HeaderStyle>
                                                                </asp:ButtonColumn>   
                                                                 <asp:ButtonColumn ItemStyle-Width="80px" DataTextField="审批状态" SortExpression="审批状态" HeaderText="审核状态" CommandName="OpenDocument">
                                                                    <HeaderStyle Width="80px"></HeaderStyle>
                                                                </asp:ButtonColumn>
                                                                <asp:ButtonColumn ItemStyle-Width="80px" DataTextField="审批人" SortExpression="审批人" HeaderText="审核人" CommandName="OpenDocument">
                                                                    <HeaderStyle Width="80px"></HeaderStyle>
                                                                </asp:ButtonColumn>  
                                                                <asp:ButtonColumn ItemStyle-Width="120px" DataTextField="报到日期" SortExpression="报到日期" HeaderText="报到日期" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd}">
                                                                    <HeaderStyle Width="120px"></HeaderStyle>
                                                                </asp:ButtonColumn>   
                                                                  <asp:ButtonColumn ItemStyle-Width="100px" DataTextField="经办人员" SortExpression="经办人员" HeaderText="经办人员" CommandName="Select">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="200px" DataTextField="经办日期" SortExpression="经办日期" HeaderText="经办日期" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd}">
																	<HeaderStyle Width="200px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="200px" DataTextField="经办单位" SortExpression="经办单位" HeaderText="经办单位" CommandName="Select">
																	<HeaderStyle Width="200px"></HeaderStyle>   
																</asp:ButtonColumn>                                                                                                                                                                               
									                             <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="文件标识" SortExpression="文件标识" HeaderText="文件标识" CommandName="Select">
                                                                    <HeaderStyle Width="0px"></HeaderStyle>
                                                                </asp:ButtonColumn>
                                                                <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="唯一标识" SortExpression="唯一标识" HeaderText="唯一标识" CommandName="Select">
                                                                    <HeaderStyle Width="0px"></HeaderStyle>
                                                                </asp:ButtonColumn>  
                                                                 <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="原职级代码" SortExpression="原职级代码" HeaderText="原职级代码" CommandName="OpenDocument">
                                                                    <HeaderStyle Width="0px"></HeaderStyle>
                                                                </asp:ButtonColumn>   
                                                                 <asp:ButtonColumn  Visible="False" ItemStyle-Width="0px" DataTextField="职级代码" SortExpression="职级代码" HeaderText="职级代码" CommandName="Select">
                                                                    <HeaderStyle Width="0px"></HeaderStyle>
                                                                </asp:ButtonColumn>  
                                                                 <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="单位代码" SortExpression="单位代码" HeaderText="单位代码" CommandName="Select">
                                                                    <HeaderStyle Width="0px"></HeaderStyle>
                                                                </asp:ButtonColumn>   
                                                                 <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="原单位代码" SortExpression="原单位代码" HeaderText="原单位代码" CommandName="Select">
                                                                    <HeaderStyle Width="0px"></HeaderStyle>
                                                                </asp:ButtonColumn>  
                                                                 <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="原人员状态" SortExpression="原人员状态" HeaderText="原人员状态" CommandName="Select">
                                                                    <HeaderStyle Width="0px"></HeaderStyle>
                                                                </asp:ButtonColumn> 
                                                                  <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="人员状态" SortExpression="人员状态" HeaderText="人员状态" CommandName="Select">
                                                                    <HeaderStyle Width="0px"></HeaderStyle>
                                                                </asp:ButtonColumn> 
                                                                <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="原是否占编" SortExpression="原是否占编" HeaderText="原是否占编" CommandName="Select">
                                                                    <HeaderStyle Width="0px"></HeaderStyle>
                                                                </asp:ButtonColumn>   
                                                                 <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="是否占编" SortExpression="是否占编" HeaderText="是否占编" CommandName="Select">
                                                                    <HeaderStyle Width="0px"></HeaderStyle>
                                                                </asp:ButtonColumn>    
                                                                <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="原因代码" SortExpression="原因代码" HeaderText="原因代码" CommandName="Select">
                                                                    <HeaderStyle Width="0px"></HeaderStyle>
                                                                </asp:ButtonColumn>  
                                                                <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="原直管团队" SortExpression="原直管团队" HeaderText="原直管团队" CommandName="Select">
                                                                    <HeaderStyle Width="0px"></HeaderStyle>
                                                                </asp:ButtonColumn>   
                                                                <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="直管团队" SortExpression="直管团队" HeaderText="直管团队" CommandName="Select">
                                                                    <HeaderStyle Width="0px"></HeaderStyle>
                                                                </asp:ButtonColumn> 
                                                                 <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="原协管团队" SortExpression="原协管团队" HeaderText="原协管团队" CommandName="Select">
                                                                    <HeaderStyle Width="0px"></HeaderStyle>
                                                                </asp:ButtonColumn>   
                                                                <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="协管团队" SortExpression="协管团队" HeaderText="协管团队" CommandName="Select">
                                                                    <HeaderStyle Width="0px"></HeaderStyle>
                                                                </asp:ButtonColumn> 
                                                                <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="是否兼职" SortExpression="是否兼职" HeaderText="是否兼职" CommandName="Select">
                                                                    <HeaderStyle Width="0px"></HeaderStyle>
                                                                </asp:ButtonColumn> 
                                                                <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="人员类型" SortExpression="人员类型" HeaderText="人员类型" CommandName="Select">
                                                                    <HeaderStyle Width="0px"></HeaderStyle>
                                                                </asp:ButtonColumn> 
                                                                <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="标准序列" SortExpression="标准序列" HeaderText="标准序列" CommandName="Select">
                                                                    <HeaderStyle Width="0px"></HeaderStyle>
                                                                </asp:ButtonColumn> 
                                                                <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="人员类型名称" SortExpression="人员类型名称" HeaderText="人员类型名称" CommandName="Select">
                                                                    <HeaderStyle Width="0px"></HeaderStyle>
                                                                </asp:ButtonColumn> 
                                                                <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="直管单位代码" SortExpression="直管单位代码" HeaderText="直管单位代码" CommandName="Select">
                                                                    <HeaderStyle Width="0px"></HeaderStyle>
                                                                </asp:ButtonColumn> 
                                                                <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="直管单位名称" SortExpression="直管单位名称" HeaderText="直管单位名称" CommandName="Select">
                                                                    <HeaderStyle Width="0px"></HeaderStyle>
                                                                </asp:ButtonColumn> 
                                                                <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="上级领导" SortExpression="上级领导" HeaderText="上级领导" CommandName="Select">
                                                                    <HeaderStyle Width="0px"></HeaderStyle>
                                                                </asp:ButtonColumn>                                                               
                                                                <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="审批结果名称" SortExpression="审批结果名称" HeaderText="审核结果名称" CommandName="Select">
                                                                    <HeaderStyle Width="0px"></HeaderStyle>
                                                                </asp:ButtonColumn>    
															</Columns>
															
															<PagerStyle Visible="False" NextPageText="下页" Font-Size="12px" Font-Names="宋体" PrevPageText="上页" HorizontalAlign="Right" ForeColor="Black" Position="TopAndBottom" BackColor="SkyBlue"></PagerStyle>
														</asp:datagrid><INPUT id="htxtRSLYGLFixed" type="hidden" size="1" value="0" runat="server">
													</DIV>
												</TD>
											</TR>
											<TR>
												<TD class="label">
													<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
														<TR id="trRow2">
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZRSLYGLDeSelectAll" runat="server" Font-Name="宋体" Font-Size="12px">不选</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZRSLYGLSelectAll" runat="server" Font-Name="宋体" Font-Size="12px">全选</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZRSLYGLMoveFirst" runat="server" Font-Name="宋体" Font-Size="12px">最前</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZRSLYGLMovePrev" runat="server" Font-Name="宋体" Font-Size="12px">前页</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZRSLYGLMoveNext" runat="server" Font-Name="宋体" Font-Size="12px">下页</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZRSLYGLMoveLast" runat="server" Font-Name="宋体" Font-Size="12px">最后</asp:linkbutton></TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZRSLYGLGotoPage" runat="server" Font-Name="宋体" Font-Size="12px">前往</asp:linkbutton><asp:textbox id="txtRSLYGLPageIndex" runat="server" CssClass="textbox" Font-Name="宋体" Font-Size="12px" Columns="3">1</asp:textbox>页</TD>
															<TD class="label" vAlign="middle" align="left"><asp:linkbutton id="lnkCZRSLYGLSetPageSize" runat="server" Font-Name="宋体" Font-Size="12px">每页</asp:linkbutton><asp:textbox id="txtRSLYGLPageSize" runat="server" CssClass="textbox" Font-Name="宋体" Font-Size="12px" Columns="3">30</asp:textbox>条</TD>
															<TD class="label" vAlign="middle" noWrap align="right"><asp:label id="lblRSLYGLGridLocInfo" runat="server" CssClass="label" Font-Name="宋体" Font-Size="12px">1/10 N/15</asp:label></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
										</TABLE>
									</TD>
									<TD width="5"></TD>
								</TR>
								<TR>
									<TD colSpan="3" height="4"></TD>
								</TR>
							</TABLE>
						</TD>
						<TD width="4"></TD>
					</TR>
				</TABLE>
			</asp:panel>
			<asp:panel id="panelError" Runat="server">
				<TABLE id="tabErrMain" height="98%" cellSpacing="0" cellPadding="0" width="100%" border="0">
					<TR>
						<TD width="5%"></TD>
						<TD>
							<TABLE id="tabErrInfo" height="100%" cellSpacing="0" cellPadding="0" width="100%" border="0">
								<TR>
									<TD>&nbsp;&nbsp;&nbsp;&nbsp;</TD>
									<TD id="tdErrInfo" style="FONT-SIZE: 32pt; COLOR: black; LINE-HEIGHT: 40pt; FONT-FAMILY: 宋体; LETTER-SPACING: 2pt" align="center"><asp:Label id="lblMessage" Runat="server"></asp:Label><P>&nbsp;&nbsp;</P><P><asp:Button ID="btnGoBack" Runat="server" Font-Size="24pt" Text=" 返回 "></asp:Button></P></TD>
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
						<input id="htxtSessionIdQuery" type="hidden" runat="server">
						<input id="htxtRSLYGLQuery" type="hidden" runat="server">
						<input id="htxtRSLYGLRows" type="hidden" runat="server">
						<input id="htxtRSLYGLSort" type="hidden" runat="server">
						<input id="htxtRSLYGLSortColumnIndex" type="hidden" runat="server">
						<input id="htxtRSLYGLSortType" type="hidden" runat="server">
						<input id="htxtDivLeftRSLYGL" type="hidden" runat="server">
						<input id="htxtDivTopRSLYGL" type="hidden" runat="server">
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
							function ScrollProc_divRSLYGL() {
								var oText;
								oText=null;
								oText=document.getElementById("htxtDivTopRSLYGL");
								if (oText != null) oText.value = divRSLYGL.scrollTop;
								oText=null;
								oText=document.getElementById("htxtDivLeftRSLYGL");
								if (oText != null) oText.value = divRSLYGL.scrollLeft;
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
								oText=document.getElementById("htxtDivTopRSLYGL");
								if (oText != null) divRSLYGL.scrollTop = oText.value;
								oText=null;
								oText=document.getElementById("htxtDivLeftRSLYGL");
								if (oText != null) divRSLYGL.scrollLeft = oText.value;

								document.body.onscroll = ScrollProc_Body;
								divRSLYGL.onscroll = ScrollProc_divRSLYGL;
							}
							catch (e) {}
						</script>
					</td>
				</tr>
				<tr>
					<td>
						<script language="javascript">window_onresize();</script>
						<uwin:popmessage id="popMessageObject" runat="server" EnableViewState="False" PopupWindowType="Normal" ActionType="OpenWindow" Visible="False" width="96px" height="48px"></uwin:popmessage>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>


