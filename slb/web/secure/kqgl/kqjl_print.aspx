<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="kqjl_print.aspx.vb" Inherits="Josco.JSOA.web.kqjl_print" %>
<%@ Register TagPrefix="ComponentArt" Namespace="ComponentArt.Web.UI" Assembly="ComponentArt.Web.UI" %>
<%@ Register TagPrefix="uwin" Namespace="Josco.Web" Assembly="Josco.Web.PopMessage" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>考勤记录打印管理</title>            
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR" />
		<meta content="Visual Basic .NET 7.1" name="CODE_LANGUAGE" />
		<meta content="JavaScript" name="vs_defaultClientScript" />
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema"/>
		<LINK href="../../stylesGrsw.css" type="text/css" rel="stylesheet">
        <link href="../../StyleMnuGrsw.css" type="text/css" rel="stylesheet"> 
        <LINK href="../../styles01.css" type="text/css" rel="stylesheet">
        <link href="../../mnuStyle01.css" type="text/css" rel="stylesheet">  
      <link rel="stylesheet" type="text/css" href="../../css/jscal2.css" />
        <link rel="stylesheet" type="text/css" href="../../css/border-radius.css" />
        <link rel="stylesheet" type="text/css" href="../../css/steel/steel.css" />
		<style>
			TD.grdKQJLGLocked { ; LEFT: expression(divKQJLGL.scrollLeft); POSITION: relative }
			TH.grdKQJLGLocked { ; LEFT: expression(divKQJLGL.scrollLeft); POSITION: relative }
			TH.grdKQJLGLocked { Z-INDEX: 99 }
			TH { Z-INDEX: 10; POSITION: relative }
		</style>
		 <script src="../../scripts/js/jscal2.js"></script>
        <script src="../../scripts/js/lang/en.js"></script>
		<script src="../../scripts/transkey.js"></script>
		<script src="../../scripts/transkey.js"></script>
		<script src="../../scripts/js/lang/ru.js"></script>
        <script src="../../scripts/js/lang/de.js"></script>
        <script src="../../scripts/js/lang/fr.js"></script>
        <script src="../../scripts/js/lang/ro.js"></script>
        <script src="../../scripts/js/lang/es.js"></script>
        <script src="../../scripts/js/lang/cz.js"></script>
        <script src="../../scripts/js/lang/pl.js"></script>
        <script src="../../scripts/js/lang/pt.js"></script>
        <script src="../../scripts/js/lang/jp.js"></script>
        <script src="../../scripts/js/lang/cn.js"></script>
        <script language="javascript">
            function DateAdd(interval,number,date){
	            switch(interval.toLowerCase()){
		            case "y": return new Date(date.setFullYear(date.getFullYear()+number));
		            case "m": return new Date(date.setMonth(date.getMonth()+number));
		            case "d": return new Date(date.setDate(date.getDate()+number));
		            case "w": return new Date(date.setDate(date.getDate()+7*number));
		            case "h": return new Date(date.setHours(date.getHours()+number));
		            case "n": return new Date(date.setMinutes(date.getMinutes()+number));
		            case "s": return new Date(date.setSeconds(date.getSeconds()+number));
		            case "l": return new Date(date.setMilliseconds(date.getMilliseconds()+number));
	            } 
            }
          
        </script>
        <script language="javascript">
            function DateDiff(interval,date1,date2){
	            var long = date2.getTime() - date1.getTime(); //相差毫秒
	            switch(interval.toLowerCase()){
		            case "y": return parseInt(date2.getFullYear() - date1.getFullYear());
		            case "m": return parseInt((date2.getFullYear() - date1.getFullYear())*12 + (date2.getMonth()-date1.getMonth()));
		            case "d": return parseInt(long/1000/60/60/24);
		            case "w": return parseInt(long/1000/60/60/24/7);
		            case "h": return parseInt(long/1000/60/60);
		            case "n": return parseInt(long/1000/60);
		            case "s": return parseInt(long/1000);
		            case "l": return parseInt(long);
	            }
            }            
        </script>
        <script language="javascript">
            function IsDate(dateval){
	            var arr = new Array();
            	
	            if(dateval.indexOf("-") != -1){
		            arr = dateval.toString().split("-");
	            }else if(dateval.indexOf("/") != -1){
		            arr = dateval.toString().split("/");
	            }else{
		            return false;
	            }
            	
	            //yyyy-mm-dd || yyyy/mm/dd
	            if(arr[0].length==4){
		            var date = new Date(arr[0],arr[1]-1,arr[2]);
		            if(date.getFullYear()==arr[0] && date.getMonth()==arr[1]-1 && date.getDate()==arr[2]){
			            return true;
		            }
	            }
	            //dd-mm-yyyy || dd/mm/yyyy
	            if(arr[2].length==4){
		            var date = new Date(arr[2],arr[1]-1,arr[0]);
		            if(date.getFullYear()==arr[2] && date.getMonth()==arr[1]-1 && date.getDate()==arr[0]){
			            return true;
		            }
	            }
	            //mm-dd-yyyy || mm/dd/yyyy
	            if(arr[2].length==4){
		            var date = new Date(arr[2],arr[0]-1,arr[1]);
		            if(date.getFullYear()==arr[2] && date.getMonth()==arr[0]-1 && date.getDate()==arr[1]){
			            return true;
		            }
	            }
            	
	            return false;
            }            
        </script>
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
                        <TD id="trRow0" height="30" class="title" vAlign="middle" align="left">当前位置：考勤管理&nbsp;&gt;&gt;&gt;&gt;&nbsp;考勤记录</TD>
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
											<TR>
												<TD class="label" align="left">
													<TABLE cellSpacing="0" cellPadding="0" border="0" width="100%">
														<TR id="trRow3">
															<td class="label" valign="middle">&nbsp;&nbsp;部门&nbsp;</td>
															<td class="label" align="left"><asp:textbox id="txtBM" runat="server" CssClass="textbox" Font-Size="12px" Columns="24" Font-Names="宋体"></asp:textbox><input id="htxtBM" type="hidden" size="1" runat="server" name="htxtBM" />
															<asp:Button id="btnFPBM" Runat="server" CssClass="button" Text="…"></asp:Button></td>
															<td class="label" valign="middle">&nbsp;&nbsp;年份&nbsp;</td>
															<td class="label" align="left"><asp:DropDownList ID="ddlNF" Runat="server" CssClass="textbox" AutoPostBack="true"></asp:DropDownList></td>
															<td class="label" valign="middle">&nbsp;&nbsp;月份&nbsp;</td>
															<td class="label" align="left"><asp:DropDownList ID="ddlYF" Runat="server" CssClass="textbox"  AutoPostBack="true">										
																	<asp:ListItem Value="空">空</asp:ListItem>
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
															</td>	
															<td align="right"><asp:Button id="btnPrint" Runat="server" CssClass="button"  Text="打印考勤记录" ></asp:Button></td> 
															<td align="right"><asp:Button id="btnPrintAll" Runat="server" CssClass="button"  Text="打印全部考勤记录" ></asp:Button></td> 
															<td align="right"><asp:Button id="btnPrintWages" Runat="server" CssClass="button"  Text="打印工资考勤记录" ></asp:Button></td> 
															<td align="right"><asp:Button id="btnClose" Runat="server" CssClass="button"  Text=" 返回 " ></asp:Button></td> 
														</TR> 														
													</TABLE>
												</TD>
											</TR>
											<TR>
												<TD>
													<DIV id="divKQJLGL" style="BORDER-RIGHT: #99cccc 1px solid; TABLE-LAYOUT: fixed; BORDER-TOP: #99cccc 1px solid; OVERFLOW: auto; BORDER-LEFT: #99cccc 1px solid; WIDTH: 800px; CLIP: rect(0px 800px 420px 0px); BORDER-BOTTOM: #99cccc 1px solid; HEIGHT: 420px">
														 <asp:datagrid id="grdKQJLG" runat="server" Width="840px" CssClass="labelGrid" 
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
																		<asp:CheckBox id="chkKQJLG" runat="server" AutoPostBack="False" Width="30px"></asp:CheckBox>
																	</ItemTemplate>
																</asp:TemplateColumn>
																<asp:ButtonColumn  ItemStyle-Width="80px" DataTextField="人员名称" SortExpression="人员名称" HeaderText="人员" CommandName="Select">
																	<HeaderStyle Width="80px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn  ItemStyle-Width="20px" DataTextField="yi" SortExpression="yi" HeaderText="1" CommandName="Select">
																	<HeaderStyle Width="20px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn  ItemStyle-Width="20px" DataTextField="er" SortExpression="er" HeaderText="2" CommandName="Select">
																	<HeaderStyle Width="20px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn  ItemStyle-Width="20px" DataTextField="san" SortExpression="san" HeaderText="3" CommandName="Select">
																	<HeaderStyle Width="20px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="20px" DataTextField="si" SortExpression="si" HeaderText="4" CommandName="Select">
																	<HeaderStyle Width="20px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn  ItemStyle-Width="20px" DataTextField="wu" SortExpression="wu" HeaderText="5" CommandName="Select">
																	<HeaderStyle Width="20px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn  ItemStyle-Width="20px" DataTextField="liu" SortExpression="liu" HeaderText="6" CommandName="Select">
																	<HeaderStyle Width="20px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn   ItemStyle-Width="20px" DataTextField="qi" SortExpression="qi" HeaderText="7" CommandName="Select">
																	<HeaderStyle Width="20px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn   ItemStyle-Width="20px" DataTextField="ba" SortExpression="ba" HeaderText="8" CommandName="Select">
																	<HeaderStyle Width="20px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn  ItemStyle-Width="20px" DataTextField="jiu" SortExpression="jiu" HeaderText="9" CommandName="Select">
																	<HeaderStyle Width="20px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="20px" DataTextField="shi" SortExpression="shi" HeaderText="10" CommandName="Select">
																	<HeaderStyle Width="20px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="20px" DataTextField="shiyi" SortExpression="shiyi" HeaderText="11" CommandName="Select">
																	<HeaderStyle Width="20px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="20px" DataTextField="shier" SortExpression="shier" HeaderText="12" CommandName="Select">
																	<HeaderStyle Width="20px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="20px" DataTextField="shisan" SortExpression="shisan" HeaderText="13" CommandName="Select">
																	<HeaderStyle Width="20px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="20px" DataTextField="shisi" SortExpression="shisi" HeaderText="14" CommandName="Select">
																	<HeaderStyle Width="20px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn  ItemStyle-Width="20px" DataTextField="shiwu" SortExpression="shiwu" HeaderText="15" CommandName="Select">
																	<HeaderStyle Width="20px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn  ItemStyle-Width="20px" DataTextField="shiliu" SortExpression="shiliu" HeaderText="16" CommandName="Select">
																	<HeaderStyle Width="20px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn  ItemStyle-Width="20px" DataTextField="shiqi" SortExpression="shilqi" HeaderText="17" CommandName="Select">
																	<HeaderStyle Width="20px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn  ItemStyle-Width="20px" DataTextField="shiba" SortExpression="shilba" HeaderText="18" CommandName="Select">
																	<HeaderStyle Width="20px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn  ItemStyle-Width="20px" DataTextField="shijiu" SortExpression="shiljiu" HeaderText="19" CommandName="Select">
																	<HeaderStyle Width="20px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn  ItemStyle-Width="20px" DataTextField="ershi" SortExpression="ershi" HeaderText="20" CommandName="Select">
																	<HeaderStyle Width="20px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="20px" DataTextField="ershiyi" SortExpression="ershiyi" HeaderText="21" CommandName="Select">
																	<HeaderStyle Width="20px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="20px" DataTextField="ershier" SortExpression="ershier" HeaderText="22" CommandName="Select">
																	<HeaderStyle Width="20px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="20px" DataTextField="ershisan" SortExpression="ershisan" HeaderText="23" CommandName="Select">
																	<HeaderStyle Width="20px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn ItemStyle-Width="20px" DataTextField="ershisi" SortExpression="ershisi" HeaderText="24" CommandName="Select">
																	<HeaderStyle Width="20px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn  ItemStyle-Width="20px" DataTextField="ershiwu" SortExpression="ershiwu" HeaderText="25" CommandName="Select">
																	<HeaderStyle Width="20px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn  ItemStyle-Width="20px" DataTextField="ershiliu" SortExpression="ershiliu" HeaderText="26" CommandName="Select">
																	<HeaderStyle Width="20px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn  ItemStyle-Width="20px" DataTextField="ershiqi" SortExpression="ershilqi" HeaderText="27" CommandName="Select">
																	<HeaderStyle Width="20px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn  ItemStyle-Width="20px" DataTextField="ershiba" SortExpression="ershilba" HeaderText="28" CommandName="Select">
																	<HeaderStyle Width="20px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn  ItemStyle-Width="20px" DataTextField="ershijiu" SortExpression="ershiljiu" HeaderText="29" CommandName="Select">
																	<HeaderStyle Width="20px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn  ItemStyle-Width="20px" DataTextField="sanshi" SortExpression="sanshi" HeaderText="30" CommandName="Select">
																	<HeaderStyle Width="20px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn  ItemStyle-Width="20px" DataTextField="sanshiyi" SortExpression="sanshiyi" HeaderText="31" CommandName="Select">
																	<HeaderStyle Width="20px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn  ItemStyle-Width="60px" DataTextField="时段" SortExpression="时段" HeaderText="时段" CommandName="Select">
																	<HeaderStyle Width="60px"></HeaderStyle>
																</asp:ButtonColumn>																
																<asp:ButtonColumn  ItemStyle-Width="20px" DataTextField="年休假" SortExpression="年休假" HeaderText="年假" CommandName="Select">
																	<HeaderStyle Width="20px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn  ItemStyle-Width="20px" DataTextField="补休假" SortExpression="补休假" HeaderText="补休" CommandName="Select">
																	<HeaderStyle Width="20px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn  ItemStyle-Width="20px" DataTextField="月应休假" SortExpression="月应休假" HeaderText="应休" CommandName="Select">
																	<HeaderStyle Width="20px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="余年休假" SortExpression="余年休假" HeaderText="余年休假" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="余补休假" SortExpression="余补休假" HeaderText="余补休假" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="余月应休假" SortExpression="余月应休假" HeaderText="余月应休假" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>																
																<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="人员代码" SortExpression="人员代码" HeaderText="人员代码" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="时间类型" SortExpression="时间类型" HeaderText="时间类型" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="组织代码" SortExpression="组织代码" HeaderText="组织代码" CommandName="Select">
																	<HeaderStyle Width="0px"></HeaderStyle>
																</asp:ButtonColumn>
																<asp:ButtonColumn Visible="False" ItemStyle-Width="0px" DataTextField="类型" SortExpression="类型" HeaderText="类型" CommandName="Select">
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
															<TD class="label" vAlign="middle" align="left"><div style="display:none"><asp:linkbutton id="lnkCZRSLYGLSelectAll" runat="server" Font-Name="宋体" Font-Size="12px">全选</asp:linkbutton></div></TD>
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
											<tr>
											    <td>
											        <table cellspacing="0" cellpadding="0" border="1">
											            <tr >
											                <td>
											                    <table>
											                        <tr>
											                            <td align="left" colspan ="3"><div  id="displayDay" style="WIDTH: 210px; CLIP: rect(0px 210px 200px 0px);  HEIGHT: 200px;"></div></td>
											                            <script type="text/javascript">
                                                                          var cal = Calendar.setup({                                                                         
                                                                              cont: "displayDay",                                                                    
                                                                              selectionType: Calendar.SEL_MULTIPLE                                     
                                                                          });                                                                          
                                                                          
                                                                          var   Nowdate=new   Date();   
                                                                          var   MonthFirstDay=new   Date(Nowdate.getYear(),Nowdate.getMonth(),1); 
                                                                         
                                                                          var mydate=new Date();                                                                           
                                                                          var   MonthNextFirstDay=new   Date(mydate.getYear(),mydate.getMonth()+1,1);   
                                                                          var   MonthLastDay=new   Date(MonthNextFirstDay-86400000); 
                                                                          
                                                                            cal.args.min=MonthFirstDay;
                                                                            cal.args.max=MonthLastDay;
                                                                            cal.redraw(); 
                                                                            
                                                                           cal.addEventListener("onSelect", function(){
                                                                                  var strDay = document.getElementById("txtDay");
                                                                                  var objConutDay = document.getElementById("txtCont");
                                                                                  var nowYear=document.getElementById("htxtYear").value;
                                                                                  var nowMonth=document.getElementById("htxtMonth").value;
                                                                                  var dateArray = new Array();
                                                                                  for(var i=0;i<this.selection.sel.length;i++)
                                                                                  {
                                                                                    if(this.selection.sel[i] instanceof Array)
                                                                                    {
                                                                                        for(var j=this.selection.sel[i][0];j<=this.selection.sel[i][1];j++)
                                                                                        {
                                                                                            dateArray.push(j);
                                                                                        }
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        
                                                                                        var sDate=this.selection.sel[i];
                                                                                        var blnCho ;
                                                                                        sDate+="";
                                                                                        if (sDate==null)
                                                                                        {
                                                                                            
                                                                                        }
                                                                                        else
                                                                                        {                                                                                            
                                                                                         dateArray.push(this.selection.sel[i]);                                                                                                 
                                                                                        }                                                                                        					  		                                                
                                                                                    }
                                                                                  }
                                                                                  if (blnCho=true)
                                                                                  { 
                                                                                   strDay.value=dateArray.join();
                                                                                  } 
                                                                                                                                                           
                                                                          });
                                                                       </script>
											                        </tr>	
											                    </table>
											                </td>
											                <td>
											                    <table >											                  
											                        <tr>
											                            <td class="labelNotNull" align="right">考勤时段：</td>
											                            <td align="left"><asp:CheckBox id="chkSW" Runat="server" CssClass="textbox"  Text="上午" ></asp:CheckBox>	
											                            <asp:CheckBox id="chkXW" Runat="server" CssClass="textbox"  Text="下午" ></asp:CheckBox></td>										                            
											                        </tr>	
											                         <tr>
											                             <td class="labelNotNull" align="right">考勤类型：</td>
											                            <td align="left"><asp:RadioButtonList id="rblkqlx" Runat="server" CssClass="textbox" RepeatColumns="5" RepeatDirection="Horizontal" RepeatLayout="Flow"  ></asp:RadioButtonList></td>
											                        </tr>
											                        <tr>
											                            <td align="left"><asp:CheckBox id="chkWC" Runat="server" CssClass="textbox"  Text="外出" AutoPostBack="true" OnCheckedChanged="chkWC_CheckedChanged" ></asp:CheckBox></td>	
											                            <td><asp:textbox ID="txtWC" runat="server" CssClass="textbox"  Font-Size="12px" Columns="20" Font-Names="宋体"></asp:textbox></td>											                            											                        
											                        </tr>
											                        <tr>
											                            <td align="left"><asp:CheckBox id="chkCD" Runat="server" CssClass="textbox"  Text="迟到" AutoPostBack="true" OnCheckedChanged="chkCD_CheckedChanged" ></asp:CheckBox></td>	
											                            <td><asp:textbox ID="txtCD" runat="server" CssClass="textbox"  Font-Size="12px" Columns="20" Font-Names="宋体"></asp:textbox>分(填写分钟)</td>											                            											                        
											                        </tr>
											                        <tr>
											                            <td align="left"><asp:CheckBox id="chkDR" Runat="server" CssClass="textbox"  Text="调入" AutoPostBack="true" OnCheckedChanged="chkDR_CheckedChanged" ></asp:CheckBox></td>	
											                            <td><asp:textbox ID="txtDR" runat="server" CssClass="textbox"  Font-Size="12px" Columns="20" Font-Names="宋体"></asp:textbox><asp:Button id="btnSelect_DRDW" Runat="server" CssClass="button" Text="…"></asp:Button></td>											                            											                        
											                        </tr>
											                        <tr>
											                            <td align="left"><asp:CheckBox id="chkDC" Runat="server" CssClass="textbox"  Text="调出" AutoPostBack="true" OnCheckedChanged="chkDC_CheckedChanged" ></asp:CheckBox></td>	
											                            <td><asp:textbox ID="txtDC" runat="server" CssClass="textbox"  Font-Size="12px" Columns="20" Font-Names="宋体"></asp:textbox><asp:Button id="btnSelect_DCDW" Runat="server" CssClass="button" Text="…"></asp:Button></td>											                            											                        
											                        </tr>	
											                        <tr>
											                            <td align="center" colspan="2"><asp:button id="btnADD" Runat="server" CssClass="button" Font-Name="宋体" Font-Size="12px" Text=" 更  新 "></asp:button>
											                              <asp:button id="btnDELETE" Runat="server" CssClass="button" Font-Name="宋体" Font-Size="12px" Text=" 删  除 "></asp:button></td>
											                        </tr>
											                        <tr>											                
											                            <td colspan="2" ><asp:textbox id="txtDay" runat="server" CssClass="textbox" TextMode="MultiLine" Rows="2" Width="260px"></asp:textbox></td>											                
											                         </tr>						                        
											                    </table>
											                </td>		
											                <td valign="top">
											                    <table width="310px" >
											                        <tr>
											                            <td>注意:</td>
											                        </tr>
											                        <tr>
											                            <td>1、考勤类型：</td>
											                        </tr>
											                        <tr>
											                            <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;休息日--休&nbsp;&nbsp;补休--补&nbsp;&nbsp;年休假--年&nbsp;&nbsp;法定节假日--节&nbsp;&nbsp;</td> 
											                        </tr>
											                        <tr>
											                            <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;病假--病&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;事假--事&nbsp;&nbsp;旷工--旷&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;迟到--迟&nbsp;&nbsp;</td>
											                        </tr>
											                        <tr>
											                            <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;产假--产&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;婚假--婚&nbsp;&nbsp;计生假--计&nbsp;&nbsp;看护假--看护&nbsp;&nbsp;&nbsp;&nbsp;</td>
											                        </tr>
											                        <tr>
											                            <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;产检--产检&nbsp;&nbsp;丧假--丧&nbsp;&nbsp;工伤假--工&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
											                        </tr>
											                         <tr>
											                            <td>2、外出(如：出差、回总部学习、下现场、看项目等等),<br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;填上目的地。</td>
											                        </tr>
											                        <tr>
											                            <td class="labelNotNull" >3、选择考勤类型、外出、迟到只能选择一种。</td>
											                        </tr>											                        
											                    </table>											                
											                </td>
											            </tr>									            
											            
											        </table>
											    </td>
											</tr>																					
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
							function ScrollProc_divKQJLGL() {
								var oText;
								oText=null;
								oText=document.getElementById("htxtDivTopRSLYGL");
								if (oText != null) oText.value = divKQJLGL.scrollTop;
								oText=null;
								oText=document.getElementById("htxtDivLeftRSLYGL");
								if (oText != null) oText.value = divKQJLGL.scrollLeft;
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
								if (oText != null) divKQJLGL.scrollTop = oText.value;
								oText=null;
								oText=document.getElementById("htxtDivLeftRSLYGL");
								if (oText != null) divKQJLGL.scrollLeft = oText.value;

								document.body.onscroll = ScrollProc_Body;
								divKQJLGL.onscroll = ScrollProc_divKQJLGL;
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