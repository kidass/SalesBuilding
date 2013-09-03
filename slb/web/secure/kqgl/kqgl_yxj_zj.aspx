<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="kqgl_yxj_zj.aspx.vb" Inherits="Josco.JSOA.web.kqgl_yxj_zj" %>
<%@ Register TagPrefix="ComponentArt" Namespace="ComponentArt.Web.UI" Assembly="ComponentArt.Web.UI" %>
<%@ Register TagPrefix="uwin" Namespace="Josco.Web" Assembly="Josco.Web.PopMessage" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>月应休假职级设置</title>            
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR" />
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE" />
		<meta content="JavaScript" name="vs_defaultClientScript" />
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
		<link href="../../styles01.css" type="text/css" rel="stylesheet" />
		<link href="../../mnuStyle01.css" type="text/css" rel="stylesheet" />
		<style>
			TD.grdRSLYGLLocked { ; LEFT: expression(divRSLYGL.scrollLeft); POSITION: relative }
			TH.grdRSLYGLLocked { ; LEFT: expression(divRSLYGL.scrollLeft); POSITION: relative }
			TH.grdRSLYGLLocked { Z-INDEX: 99 }
			TH { Z-INDEX: 10; POSITION: relative }
		</style>
		 
		<script language="javascript" src="../../scripts/Calendar.js" type="text/javascript"></script>
		<script language="javascript">  
		<!--
			
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
                        <TD id="trRow0" height="30" class="title" vAlign="middle" align="left">当前位置：考勤管理&nbsp;&gt;&gt;&gt;&gt;&nbsp;月休假单位—职级标准设置</TD>
                        <TD width="4">
                    </TR>	
					<TR>
						<TD width="4"><asp:LinkButton id="lnkBlank" Runat="server" Width="0px"></asp:LinkButton><asp:LinkButton id="lnkMenu" Runat="server" Width="0px"></asp:LinkButton><INPUT id="htxtSelectMenuID" type="hidden" size="1" runat="server"><INPUT id="htxtMenuParam00" type="hidden" size="1" runat="server"></TD>
						<TD style="BORDER-RIGHT: #99cccc 1px solid; BORDER-TOP: #99cccc 1px solid; BORDER-LEFT: #99cccc 1px solid; BORDER-BOTTOM: #99cccc 1px solid" vAlign="top" align="center">
							<TABLE cellSpacing="0" cellPadding="0" border="0">
								<TR>
									<TD colSpan="3" height="4"></TD>
								</TR>
								
								<TR>
									<TD width="5"></TD>
									<TD vAlign="top">
										<TABLE cellSpacing="0" cellPadding="0" border="0">
										     <tr>
                                                <td vAlign="middle" align="center" height="32" colspan="4">
                                                    <SPAN style="FONT-WEIGHT: bold; FONT-SIZE: 28px; COLOR: red; FONT-FAMILY: 宋体"><%=Year(Now).ToString%>月应休部门职级假表</SPAN></td>
                                            </tr>
											<TR>
												<TD class="label" align="left" colspan="3">
													<TABLE cellSpacing="0" cellPadding="0" border="0" width="100%">
														<TR id="trRow3">
														    <td align="left" style="font-size:14px">&nbsp;</td>
															<td align="right"><asp:Button id="btnClose" Runat="server" CssClass="button"  Text=" 返回 " ></asp:Button></td> 
														</TR> 														
													</TABLE>
												</TD>
											</TR>
											<TR>
												<td style="BORDER-RIGHT: #99cccc 1px solid; TABLE-LAYOUT: fixed; BORDER-TOP: #99cccc 1px solid; OVERFLOW: auto; BORDER-LEFT: #99cccc 1px solid;">
												    <table >
												        <tr>
    												        <td align="right">部门名称：</td>
    												        <td align="left"><asp:textbox id="txtBM" runat="server" CssClass="textbox"  Font-Size="14px" Columns="12" Font-Names="宋体"></asp:textbox> </td>
    												        <td><asp:button id="btnSearchBm" Runat="server" CssClass="button"  Text="搜索"></asp:button></td>
								                      	 </tr>
								                      	  <tr>
								                      	    <td colspan="3">            								                      	        
													            <div id="divKQJLGL" style="BORDER-RIGHT: #99cccc 1px solid; TABLE-LAYOUT: fixed; BORDER-TOP: #99cccc 1px solid; OVERFLOW: auto; BORDER-LEFT: #99cccc 1px solid; WIDTH: 280px; CLIP: rect(0px 280px 220px 0px); BORDER-BOTTOM: #99cccc 1px solid; HEIGHT: 220px">
														             <asp:datagrid id="grdKQJLG" runat="server" Width="260px" CssClass="textbox_list" 
                                                                            AllowPaging="false" AutoGenerateColumns="False" GridLines="Both" BackColor="White"
                                                                            PageSize="1000" BorderColor="#dfdfdf" BorderWidth="1px" AllowSorting="True" CellPadding="4"  UseAccessibleHeader="True" BorderStyle="Solid">
									                                         <SelectedItemStyle  Font-Bold="False" VerticalAlign="Middle" HorizontalAlign="Center" ForeColor="blue" ></SelectedItemStyle>
                                                                            <EditItemStyle   BackColor="#FFCC00" VerticalAlign="Middle" HorizontalAlign="Center" ></EditItemStyle>
                                                                            <AlternatingItemStyle  BorderWidth="1px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="White"></AlternatingItemStyle>
                                                                            <ItemStyle  BorderWidth="1px" HorizontalAlign="Center" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="#F7F7F7" ForeColor="Black"></ItemStyle>
                                                                            <HeaderStyle   Font-Bold="True" HorizontalAlign="Center"  ForeColor="White" VerticalAlign="Middle" BackColor="#6699cc" ></HeaderStyle>
                                                                            <FooterStyle BackColor="#CCCC99" HorizontalAlign="Center"></FooterStyle>                                                                                        
															            <Columns>
																            <asp:TemplateColumn HeaderText="选" ItemStyle-Width="20px">
																	            <HeaderStyle HorizontalAlign="Center" Width="20px" ></HeaderStyle>
																	            <HeaderTemplate>
																	                <asp:CheckBox id="chkALL" runat="server" AutoPostBack="true" OnCheckedChanged="chkALL_CheckedChanged" Width="30px"></asp:CheckBox>
																	            </HeaderTemplate>
																	            <ItemStyle Wrap="False" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
																	            <ItemTemplate>
																		            <asp:CheckBox id="chkKQJLG"  runat="server" AutoPostBack="False" Width="30px"></asp:CheckBox>
																	            </ItemTemplate>
																            </asp:TemplateColumn>
																            <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="组织代码" SortExpression="组织代码" HeaderText="组织代码" CommandName="Select">
																	            <HeaderStyle Width="0px"></HeaderStyle>
																            </asp:ButtonColumn>
																            <asp:ButtonColumn  ItemStyle-Width="240px" DataTextField="组织名称" SortExpression="组织名称" HeaderText="部门名称" CommandName="Select">
																	            <HeaderStyle Width="240px"></HeaderStyle>
																            </asp:ButtonColumn>																
															             </Columns>
            															
															            <PagerStyle Visible="False" NextPageText="下页" Font-Size="12px" Font-Names="宋体" PrevPageText="上页" HorizontalAlign="Right" ForeColor="Black" Position="TopAndBottom" BackColor="SkyBlue"></PagerStyle>
														            </asp:datagrid><input id="htxtRSLYGLFixed" type="hidden" size="1" value="0" runat="server" />
													            </div>
								                      	    </td>
								                      	  </tr>
												    </table>
												</td>
												<td style="BORDER-RIGHT: #99cccc 1px solid; TABLE-LAYOUT: fixed; BORDER-TOP: #99cccc 1px solid; OVERFLOW: auto; BORDER-LEFT: #99cccc 1px solid;"> 
												    <table >
												        <tr>
    												        <td align="right">职级名称：</td>
    												        <td align="left"><asp:textbox id="txtZJ" runat="server" CssClass="textbox"  Font-Size="14px" Columns="12" Font-Names="宋体"></asp:textbox> </td>
								                      	    <td><asp:button id="btnSearchZJ" Runat="server" CssClass="button"  Text="搜索"></asp:button></td>
								                      	 </tr>
								                      	 <tr>
							                      	          <td colspan="3">    							                      	            
													            <div id="divKQZJ" style="BORDER-RIGHT: #99cccc 1px solid; TABLE-LAYOUT: fixed; BORDER-TOP: #99cccc 1px solid; OVERFLOW: auto; BORDER-LEFT: #99cccc 1px solid; WIDTH: 280px; CLIP: rect(0px 280px 220px 0px); BORDER-BOTTOM: #99cccc 1px solid; HEIGHT: 220px">
														             <asp:datagrid id="grdKQZJ" runat="server" Width="260px" CssClass="textbox_list" 
                                                                            AllowPaging="false" AutoGenerateColumns="False" GridLines="Both" BackColor="White"
                                                                            PageSize="1000" BorderColor="#dfdfdf" BorderWidth="1px" AllowSorting="True" CellPadding="4"  UseAccessibleHeader="True" BorderStyle="Solid">
									                                         <SelectedItemStyle  Font-Bold="False" VerticalAlign="Middle" HorizontalAlign="Center" ForeColor="blue" ></SelectedItemStyle>
                                                                            <EditItemStyle   BackColor="#FFCC00" VerticalAlign="Middle" HorizontalAlign="Center" ></EditItemStyle>
                                                                            <AlternatingItemStyle  BorderWidth="1px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="White"></AlternatingItemStyle>
                                                                            <ItemStyle  BorderWidth="1px" HorizontalAlign="Center" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="#F7F7F7" ForeColor="Black"></ItemStyle>
                                                                            <HeaderStyle   Font-Bold="True" HorizontalAlign="Center"  ForeColor="White" VerticalAlign="Middle" BackColor="#6699cc" ></HeaderStyle>
                                                                            <FooterStyle BackColor="#CCCC99" HorizontalAlign="Center"></FooterStyle>                                                                                        
															            <Columns>
																            <asp:TemplateColumn HeaderText="选" ItemStyle-Width="20px">
																	            <HeaderStyle HorizontalAlign="Center" Width="20px" ></HeaderStyle>
																	            <HeaderTemplate>
																	                <asp:CheckBox id="chkZJALL" runat="server" AutoPostBack="TRUE" OnCheckedChanged="chkZJALL_CheckedChanged" Width="30px"></asp:CheckBox>
																	            </HeaderTemplate>
																	            <ItemStyle Wrap="False" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
																	            <ItemTemplate>
																		            <asp:CheckBox id="chkKQZJ" runat="server" AutoPostBack="False" Width="30px"></asp:CheckBox>
																	            </ItemTemplate>
																            </asp:TemplateColumn>
																            <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="职级代码" SortExpression="职级代码" HeaderText="职级代码" CommandName="Select">
																	            <HeaderStyle Width="0px"></HeaderStyle>
																            </asp:ButtonColumn>
																            <asp:ButtonColumn  ItemStyle-Width="240px" DataTextField="职级名称" SortExpression="职级名称" HeaderText="职级名称" CommandName="Select">
																	            <HeaderStyle Width="240px"></HeaderStyle>
																            </asp:ButtonColumn>																
															             </Columns>
            															
															            <PagerStyle Visible="False" NextPageText="下页" Font-Size="12px" Font-Names="宋体" PrevPageText="上页" HorizontalAlign="Right" ForeColor="Black" Position="TopAndBottom" BackColor="SkyBlue"></PagerStyle>
														            </asp:datagrid><input id="Hidden1" type="hidden" size="1" value="0" runat="server" />
													            </div>
							                      	          </td>
								                      	 </tr>
												    </table>
											    </td>
											    <td style="BORDER-RIGHT: #99cccc 1px solid;  BORDER-TOP: #99cccc 1px solid; BORDER-LEFT: #99cccc 1px solid;">
												    <table cellspacing="0" cellpadding="0" border="0">
												        <tr>
												            <td align="right">部门名称：</td>
    												        <td align="left"><asp:textbox id="txtBMZJ_BM" runat="server" CssClass="textbox"  Font-Size="14px" Columns="10" Font-Names="宋体"></asp:textbox> </td>
								                      	    <td align="right">职级名称</td>
    												        <td align="left"><asp:textbox id="txtBMZJ_ZJ" runat="server" CssClass="textbox"  Font-Size="14px" Columns="10" Font-Names="宋体"></asp:textbox> </td>
								                      	    <td align="left"><asp:button id="btnSearchBMZJ" Runat="server" CssClass="button"  Text="搜索"></asp:button>
								                      	     <asp:button id="btnDelete" Runat="server" CssClass="button" Text="删除"></asp:button></td>
								                      	 </tr>
								                      	 <tr>
							                      	          <td colspan="5">
    							                      	            <DIV id="divZJKQ" style="BORDER-RIGHT: #99cccc 1px solid; TABLE-LAYOUT: fixed; BORDER-TOP: #99cccc 1px solid; OVERFLOW: auto; BORDER-LEFT: #99cccc 1px solid; WIDTH: 460px; CLIP: rect(0px 460px 220px 0px); BORDER-BOTTOM: #99cccc 1px solid; HEIGHT: 220px">
														             <asp:datagrid id="grdZJKQ" runat="server" Width="440px" CssClass="textbox_list" 
                                                                            AllowPaging="false" AutoGenerateColumns="False" GridLines="Both" BackColor="White"
                                                                            PageSize="1000" BorderColor="#dfdfdf" BorderWidth="1px" AllowSorting="True" CellPadding="4"  UseAccessibleHeader="True" BorderStyle="Solid">
									                                         <SelectedItemStyle  Font-Bold="False" VerticalAlign="Middle" HorizontalAlign="Center" ForeColor="blue" ></SelectedItemStyle>
                                                                            <EditItemStyle   BackColor="#FFCC00" VerticalAlign="Middle" HorizontalAlign="Center" ></EditItemStyle>
                                                                            <AlternatingItemStyle  BorderWidth="1px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="White"></AlternatingItemStyle>
                                                                            <ItemStyle  BorderWidth="1px" HorizontalAlign="Center" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="#F7F7F7" ForeColor="Black"></ItemStyle>
                                                                            <HeaderStyle   Font-Bold="True" HorizontalAlign="Center"  ForeColor="White" VerticalAlign="Middle" BackColor="#6699cc" ></HeaderStyle>
                                                                            <FooterStyle BackColor="#CCCC99" HorizontalAlign="Center"></FooterStyle>                                                                                        
															            <Columns>
															                <asp:TemplateColumn HeaderText="选" ItemStyle-Width="20px">
																	            <HeaderStyle HorizontalAlign="Center" Width="20px"></HeaderStyle>
																	            <HeaderTemplate>
																	                <asp:CheckBox id="chkDEALL" runat="server" AutoPostBack="TRUE" OnCheckedChanged="chkDEALL_CheckedChanged" Width="20px"></asp:CheckBox>
																	            </HeaderTemplate>
																	            <ItemStyle Wrap="False" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
																	            <ItemTemplate>
																		            <asp:CheckBox id="chkDEZJ" runat="server" AutoPostBack="False" Width="20px"></asp:CheckBox>
																	            </ItemTemplate>
																            </asp:TemplateColumn>																
																            <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="组织代码" SortExpression="组织代码" HeaderText="组织代码" CommandName="Select">
																	            <HeaderStyle Width="0px"></HeaderStyle>
																            </asp:ButtonColumn>
																            <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="职级代码" SortExpression="职级代码" HeaderText="职级代码" CommandName="Select">
																	            <HeaderStyle Width="0px"></HeaderStyle>
																            </asp:ButtonColumn>
																            <asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="标准标识" SortExpression="标准标识" HeaderText="标准标识" CommandName="Select">
																	            <HeaderStyle Width="0px"></HeaderStyle>
																            </asp:ButtonColumn>
																            <asp:ButtonColumn  ItemStyle-Width="100px" DataTextField="组织名称" SortExpression="组织名称" HeaderText="部门名称" CommandName="Select">
																	            <HeaderStyle Width="100px"></HeaderStyle>
																            </asp:ButtonColumn>
																            <asp:ButtonColumn  ItemStyle-Width="120px" DataTextField="职级名称" SortExpression="职级名称" HeaderText="职级名称" CommandName="Select">
																	            <HeaderStyle Width="120px"></HeaderStyle>
																            </asp:ButtonColumn>
																            <asp:ButtonColumn  ItemStyle-Width="20px" DataTextField="标准序列" SortExpression="标准序列" HeaderText="标准" CommandName="Select">
																	            <HeaderStyle Width="20px"></HeaderStyle>
																            </asp:ButtonColumn>																		
																            <asp:ButtonColumn  ItemStyle-Width="100px" DataTextField="生效时间" SortExpression="生效时间" HeaderText="生效时间" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd}">
																	            <HeaderStyle Width="100px"></HeaderStyle>
																            </asp:ButtonColumn>
																            <asp:ButtonColumn  ItemStyle-Width="100px" DataTextField="失效时间" SortExpression="失效时间" HeaderText="失效时间" CommandName="Select" DataTextFormatString="{0:yyyy-MM-dd}">
																	            <HeaderStyle Width="100px"></HeaderStyle>
																            </asp:ButtonColumn>
															            </Columns>															
															            <PagerStyle Visible="False" NextPageText="下页" Font-Size="12px" Font-Names="宋体" PrevPageText="上页" HorizontalAlign="Right" ForeColor="Black" Position="TopAndBottom" BackColor="SkyBlue"></PagerStyle>
														            </asp:datagrid>
													            </DIV>
							                      	          </td>
								                      	 </tr>
												    </table>
												 </td>  												
											</TR>												
											<tr>
											    <td colspan="4">
											        <table cellspacing="0" cellpadding="0" border="1" width="100%">
											            <tr>
								                      	    <td align="right">节假日放假：</td>
								                      	    <td align="left" colspan="3">
								                      	        <asp:DropDownList ID="ddlYF" Runat="server" CssClass="textbox" >	
														            <asp:ListItem Value="1">一月</asp:ListItem>
														            <asp:ListItem Value="2">二月</asp:ListItem>
														            <asp:ListItem Value="3">三月</asp:ListItem>
														            <asp:ListItem Value="4">四月</asp:ListItem>
														            <asp:ListItem Value="5">五月</asp:ListItem>
														            <asp:ListItem Value="6">六月</asp:ListItem>
														            <asp:ListItem Value="7">七月</asp:ListItem>
														            <asp:ListItem Value="8">八月</asp:ListItem>
														            <asp:ListItem Value="9">九月</asp:ListItem>
														            <asp:ListItem Value="10">十月</asp:ListItem>
														            <asp:ListItem Value="11">十一月</asp:ListItem>
														            <asp:ListItem Value="12">十二月</asp:ListItem>
													            </asp:DropDownList>
													            <asp:textbox id="txtYF" runat="server" CssClass="textbox" Font-Size="14px" Columns="6" Font-Names="宋体"></asp:textbox>天
								                      	        <asp:button id="btnSet" Runat="server" CssClass="button"  Text="设置"></asp:button>
								                      	     </td>												                      	    								                            											                        
								                     	</tr>
											             <tr>
								                            <td align="right"  >月应休假标准：</td>
								                            <td align="left">
							                                    <asp:RadioButtonList id="rblRYLX" Runat="server"  CssClass="textbox_list"  RepeatColumns="4" RepeatDirection="Horizontal" RepeatLayout="Table" AutoPostBack="True">
								                                    <asp:ListItem Value="1">标准1</asp:ListItem>
								                                    <asp:ListItem Value="2">标准2</asp:ListItem>
								                                    <asp:ListItem Value="3" Selected="True">标准3</asp:ListItem>
								                                    <asp:ListItem Value="4">标准4</asp:ListItem>
							                                    </asp:RadioButtonList>
							                                    <asp:textbox id="txtJQ" runat="server" CssClass="textbox" onclick="calendar();" Font-Size="14px" Columns="20" Font-Names="宋体"></asp:textbox>
								                      	        <asp:button id="btnUpdate" Runat="server" CssClass="button"  Text="更新"></asp:button>
						                                    </td>							                      	    								                            											                        
								                      	</tr>			 
											            <tr >
											                 <td >&nbsp;</td>	
											                <td valign="top" colspan="3">
											                    <table width="650px" >
											                        <tr>
											                            <td>注意:</td>
											                        </tr>
											                        <tr>
											                            <td>标准1：规定每个月周六、周日为固定休假日。&nbsp;&nbsp;<b>(例如：公司总部人员)</b></td>
											                        </tr>											                       
											                         <tr>
											                            <td>标准2：单月的休假总数为7天,双月为6天,时间由部门自行安排。&nbsp;&nbsp;<b>(例如：一手销售人员、二手分行行政助理)</b></td>
											                        </tr>
											                        <tr>
											                            <td>标准3：按每月月历上的总周日数为当月的休假总数,时间由部门自行安排。&nbsp;&nbsp;<b>(例如：二手分行业务人员)</b></td>
											                        </tr>	
											                        <tr>
											                            <td>标准4：按每月月历上的周六半天、周日全天的天数为当月的休假总数,时间由部门自行安排。&nbsp;&nbsp;<b>(例如：工商铺)</b></td>
											                        </tr>										                        
											                    </table>											                
											                </td>
											            </tr>
											            	
											        </table>
											    </td>
											</tr>
											<TR>
											    <TD colspan="3">
													<DIV id="divYXJ" style="BORDER-RIGHT: #99cccc 1px solid; TABLE-LAYOUT: fixed; BORDER-TOP: #99cccc 1px solid; OVERFLOW: auto; BORDER-LEFT: #99cccc 1px solid; WIDTH: 860px; CLIP: rect(0px 860px 220px 0px); BORDER-BOTTOM: #99cccc 1px solid; HEIGHT: 220px">
														 <asp:datagrid id="grdYXJ" runat="server" Width="800px" CssClass="textbox_list" 
                                                                AllowPaging="false" AutoGenerateColumns="False" GridLines="Both" BackColor="White"
                                                                PageSize="1000" BorderColor="#dfdfdf" BorderWidth="1px" AllowSorting="True" CellPadding="4"  UseAccessibleHeader="True" BorderStyle="Solid">
									                             <SelectedItemStyle  Font-Bold="False" VerticalAlign="Middle" HorizontalAlign="Center" ForeColor="blue" ></SelectedItemStyle>
                                                                <EditItemStyle   BackColor="#FFCC00" VerticalAlign="Middle" HorizontalAlign="Center" ></EditItemStyle>
                                                                <AlternatingItemStyle  BorderWidth="1px" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="White"></AlternatingItemStyle>
                                                                <ItemStyle  BorderWidth="1px" HorizontalAlign="Center" BorderStyle="Solid" BorderColor="Gold" VerticalAlign="Middle" BackColor="#F7F7F7" ForeColor="Black"></ItemStyle>
                                                                <HeaderStyle   Font-Bold="True" HorizontalAlign="Center"  ForeColor="White" VerticalAlign="Middle" BackColor="#6699cc" ></HeaderStyle>
                                                                <FooterStyle BackColor="#CCCC99" HorizontalAlign="Center"></FooterStyle>                                                                                        
															<Columns>
															    <asp:TemplateColumn HeaderText="选" ItemStyle-Width="20px">
																	<HeaderStyle HorizontalAlign="Center" Width="20px"></HeaderStyle>
																	<HeaderTemplate>
																	    <asp:CheckBox id="chkYXJALL" runat="server" AutoPostBack="TRUE" OnCheckedChanged="chkYXJALL_CheckedChanged" Width="20px"></asp:CheckBox>
																	</HeaderTemplate>
																	<ItemStyle Wrap="False" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
																	<ItemTemplate>
																		<asp:CheckBox id="chkDEYXJ" runat="server" AutoPostBack="False" Width="20px"></asp:CheckBox>
																	</ItemTemplate>
																</asp:TemplateColumn>																
																<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="组织代码" SortExpression="组织代码" HeaderText="组织代码" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn  ItemStyle-Width="160px" DataTextField="组织名称" SortExpression="组织名称" HeaderText="部门名称" CommandName="Select">
																	<HeaderStyle Width="160px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="职级代码" SortExpression="职级代码" HeaderText="职级代码" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn  ItemStyle-Width="100px" DataTextField="职级名称" SortExpression="职级名称" HeaderText="职级名称" CommandName="Select">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn  ItemStyle-Width="100px" DataTextField="标准序列" SortExpression="标准序列" HeaderText="标准" CommandName="Select">
																	<HeaderStyle Width="100px"></HeaderStyle>
																</asp:ButtonColumn>																		
																<asp:ButtonColumn  ItemStyle-Width="30px" DataTextField="yi" SortExpression="yi" HeaderText="1月" CommandName="Select">
																	<HeaderStyle Width="30px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn  ItemStyle-Width="30px" DataTextField="er" SortExpression="er" HeaderText="2月" CommandName="Select">
																	<HeaderStyle Width="30px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn  ItemStyle-Width="30px" DataTextField="san" SortExpression="san" HeaderText="3月" CommandName="Select">
																	<HeaderStyle Width="30px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="30px" DataTextField="si" SortExpression="si" HeaderText="4月" CommandName="Select">
																	<HeaderStyle Width="30px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn  ItemStyle-Width="30px" DataTextField="wu" SortExpression="wu" HeaderText="5月" CommandName="Select">
																	<HeaderStyle Width="30px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn  ItemStyle-Width="30px" DataTextField="liu" SortExpression="liu" HeaderText="6月" CommandName="Select">
																	<HeaderStyle Width="30px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn   ItemStyle-Width="30px" DataTextField="qi" SortExpression="qi" HeaderText="7月" CommandName="Select">
																	<HeaderStyle Width="30px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn   ItemStyle-Width="30px" DataTextField="ba" SortExpression="ba" HeaderText="8月" CommandName="Select">
																	<HeaderStyle Width="30px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn  ItemStyle-Width="30px" DataTextField="jiu" SortExpression="jiu" HeaderText="9月" CommandName="Select">
																	<HeaderStyle Width="30px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="30px" DataTextField="shi" SortExpression="shi" HeaderText="10月" CommandName="Select">
																	<HeaderStyle Width="30px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="30px" DataTextField="shiyi" SortExpression="shiyi" HeaderText="11月" CommandName="Select">
																	<HeaderStyle Width="30px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="30px" DataTextField="shier" SortExpression="shier" HeaderText="12月" CommandName="Select">
																	<HeaderStyle Width="30px"></HeaderStyle>
																</asp:ButtonColumn>
															</Columns>															
															<PagerStyle Visible="False" NextPageText="下页" Font-Size="12px" Font-Names="宋体" PrevPageText="上页" HorizontalAlign="Right" ForeColor="Black" Position="TopAndBottom" BackColor="SkyBlue"></PagerStyle>
														</asp:datagrid><input id="Hidden2" type="hidden" size="1" value="0" runat="server" />
													</DIV>
												</TD>
											</TR>																					
										</TABLE>
									</TD>
									<TD width="5"></TD>
								</TR>
								<TR>
									<TD colspan="3" height="4"></TD>
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
						<input id="htxtYear" type="hidden" runat="server">
						<input id="htxtMonth" type="hidden" runat="server">
						<input id="htxtMonthMin" type="hidden" runat="server">
						<input id="htxtMonthMax" type="hidden" runat="server">
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

