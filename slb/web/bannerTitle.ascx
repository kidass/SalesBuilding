<%@ Control Language="vb" Codebehind="bannerTitle.ascx.vb" Inherits="Josco.JsKernal.web.BannerTitle" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" AutoEventWireup="false" %>
<%@ Import Namespace="Josco.JsKernal.web"%>
<!--BEGIN BANNER MODULE-->
<table cellSpacing="0" cellPadding="0" width="100%" border="0" background="images/bgtitle.gif">
	<tr>
		<td colSpan="3">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td noWrap height="24"><div id="timerId" style="FONT-SIZE: 11pt; COLOR: white; FONT-FAMILY: Courier New,����,������"><script language="javascript">DisplayDateAndWeekday();</script></div><input id="htxtAutoRefreshEnabled" runat="server" type="hidden" value="0" NAME="htxtAutoRefreshEnabled"><input id="htxtAutoRefreshTime" runat="server" type="hidden" value="1800" NAME="htxtAutoRefreshTime"></td>
					<td style="FONT-SIZE: 11pt; COLOR: white; FONT-FAMILY: Courier New,����,������">|<input id="htxtInfoCount" runat="server" type="hidden"></td>
					<td noWrap width="100%"><marquee id="syslogoId" onmouseover="syslogoId.stop();m_doAutoRefresh=false;" onmouseout="syslogoId.start();m_doAutoRefresh=true;" scrollAmount="4" scrollDelay="100" direction="left" behavior="scroll" loop="0"><div><span style="FONT-SIZE: 11pt; COLOR: white; FONT-FAMILY: Courier New,����,������"><asp:label id="lblRealtimeMessage" Runat="server"></asp:label></span></div></marquee></td>
					<td style="FONT-SIZE: 11pt; COLOR: white; FONT-FAMILY: Courier New,����,������" noWrap><asp:label ID="lblUserXM" Runat="server"></asp:label></td>
					<td style="FONT-SIZE: 11pt; COLOR: white; FONT-FAMILY: Courier New,����,������" noWrap><asp:Label ID="lblUserBMMC" Runat="server"></asp:Label></td>
					<td style="FONT-SIZE: 11pt; COLOR: white; FONT-FAMILY: Courier New,����,������" nowrap><asp:Label ID="lblUserEnterTime" Runat="server"></asp:Label><input id="htxtUserEnterTime" type="hidden" runat="server" size="1"><script language="javascript">ShowUserLoginTime();doAutoRefresh();</script></td>
					<!--������ 2008-03-29--><td style="FONT-SIZE: 11pt; COLOR: white; FONT-FAMILY: Courier New,����,������" nowrap><input id="btnFullScreen" type="button" class="button" value="ȫ��" onclick="btnFullScreen_onClick();"><input id="htxtFullScreen" type="hidden" value="0" runat="server" size="1" NAME="htxtFullScreen"><input id="btnLockApp" type="button" class="button" value="����" onclick="btnLockApp_onClick();"><input id="htxtLockApp" type="hidden" value="0" runat="server" size="1" NAME="htxtLockApp"></td><!--������ 2008-03-29-->
				</tr>
			</table>
		</td>
	</tr>
</table>
<!--END BANNER MODULE-->
