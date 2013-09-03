//*********************************************************************************************************************
//2008-08-04 zengxianglin rewrite this document
//*********************************************************************************************************************
//*********************************************************************************************************************
//global parameters
//*********************************************************************************************************************
var m_blnIsMicrosoftExcel;        		//is Microsoft Excel?
var m_blnIsMicrosoftWord;        		//is Microsoft Word?
var m_blnDocumentOpened;        		//document is opened ?
var m_strProtectPassword;        		//document protected password
var m_strUserXM;                 		//current user name
var m_strFileUrl;     			        //the original path of the document
var m_blnEditMode;               		//current workflow file edit mode
var m_blnAutoSave;                      //will auto save the total work flow file
var m_blnTrackRevisions;         		//will track revisions ?
var m_blnCanExportFile;               	//can do export file
var m_blnCanQSYJ;                       //can do write opinion
var m_blnCanImportFile;                 //can do import file
var m_blnCanSelectTGWJ;                 //can do select tougao file
var m_strLocalFileCache;                //local file cache
// 2009-02-20
var m_blnLocked;               			//Have workflow file locked?
// 2009-02-20






//set the command display by success or failure
function setCommandDisplay(blnSuccess)
{
	try {
		//re-open
		if (blnSuccess)
		{
			spanOPEN.style.display = "none";
			spanDYWJ.style.display = "";
		}
		else
		{
			spanOPEN.style.display = "";
			spanDYWJ.style.display = "none";
		}
		//save, cancel, close
		if (blnSuccess && m_blnEditMode)
		{
			spanSAVE.style.display = "";
			spanQXFH.style.display = "";
			spanFHSJ.style.display = "none";
		}
		else
		{
			spanSAVE.style.display = "none";
			spanQXFH.style.display = "none";
			spanFHSJ.style.display = "";
		}
		//revision
		if (blnSuccess && m_blnTrackRevisions)
		{
			spanHJCK.style.display = "";
			spanHJYC.style.display = "none";
		}
		else
		{
			spanHJCK.style.display = "none";
			spanHJYC.style.display = "none";
		}
		//select tougao file
		if (blnSuccess && m_blnCanSelectTGWJ)
			spanXZGJ.style.display = "";
		else
			spanXZGJ.style.display = "none";
		//can import file
		if (blnSuccess && m_blnCanImportFile)
			spanDRWJ.style.display = "";
		else
			spanDRWJ.style.display = "none";
		//can export file
		if (blnSuccess && m_blnCanExportFile)
			spanDCWJ.style.display = "";
		else
			spanDCWJ.style.display = "none";
		// not supported
		spanYJCK.style.display = "none";
		spanHJYC.style.display = "none";
		// always can do
		spanXGFJ.style.display = "";
		spanXGWJ.style.display = "";
		return true;
	} catch (e) {}
	return false;
}
//show word revision
function hrefHJCK_onclick() 
{
	if (ShowWordRevisions())
	{
		spanHJCK.style.display = "none";
		spanHJYC.style.display = "";
	}
}
//hide word revision
function hrefHJYC_onclick() 
{
	if (HideWordRevisions())
	{
		spanHJYC.style.display = "none";
		spanHJCK.style.display = "";
	}
}
//display opinion window
function hrefYJCK_onclick() 
{
	spanYJCK.style.display = "none";
	spanYJYC.style.display = "none";
}
//hide opinion window
function hrefYJYC_onclick() 
{
	spanYJYC.style.display = "none";
	spanYJCK.style.display = "none";
}
//open office document
function hrefOPEN_onclick() 
{
	OpenDocument();
}
//change current file
function hrefDRWJ_onclick() 
{
	if (CloseDocument(true))
		__doPostBack("lnkMLDrwj",""); 
}
//close current window, no save
function hrefFHSJ_onclick() 
{
	if (CloseDocument(false))
		__doPostBack("lnkMLClose","");
}
//when document is clean, then close window; else prompt user to do (Yes, No, Cancel)
function hrefQXFH_onclick() 
{
	var blnDo = false;
	if (objOffice)
		if (objOffice.ActiveDocument)
			if (objOffice.ActiveDocument.Saved == false)
				blnDo = true;
	if (blnDo == true)
	{
		var intValue = window.showModalDialog("../../info_button3.aspx",m_strMsg_SavePrompt,"dialogHeight:200px;dialogWidth:320px;help:no;scroll:no;status:no");
		switch (intValue)
		{
			case 6: //Yes
				if (CloseDocument(true))
					__doPostBack("lnkMLSaveAndClose","");
				break;
			case 7: //No
				if (CloseDocument(false))
					__doPostBack("lnkMLClose","");
				break;
			case 2: //Cancel
			default:
				//no operation
				objOffice.focus();
				break;
		}
	}
	else
	{
		if (CloseDocument(false))
			__doPostBack("lnkMLClose","");
	}
}
//save file to server in AutoSave mode, or save file to web server cache
function hrefSAVE_onclick() 
{
	try { document.all("htxtCursorPos").value = objOffice.ActiveDocument.Application.Selection.End.toString();} catch (e) {}
	if ((m_blnAutoSave == true) && (m_blnEditMode == true)) 
	{
		//save to web server
		if (SaveOfficeDocument() == false)
			return;
		//save to database server
		var objArray = m_strFileUrl.split("/");
		var strFile  = objArray[objArray.length-1];
		var strId    = getElementValueSafe_String("htxtISession");
		var strUrl   = "flow_editword_save.aspx?SessionId=" + strId + "&FileName=" + strFile;
		window.showModelessDialog(strUrl,null,"dialogHeight:80px;dialogWidth:280px;help:no;scroll:no;status:no");
		objOffice.focus();
	}
	else 
	{
		//save to web server
		if (SaveOfficeDocument() == false)
			return;
		objOffice.focus();
	}
	//zengxianglin 2009-03-14
	//restart watch timer
	doRestartWatchEditTimer();
	//zengxianglin 2009-03-14
}
//open fujian window
function hrefXGFJ_onclick() 
{
	try { document.all("htxtCursorPos").value = objOffice.ActiveDocument.Application.Selection.End.toString();} catch (e) {}
	if (CloseDocument(true))
		__doPostBack("lnkMLXgfj",""); 
}
//open xiangguanwenjian window
function hrefXGWJ_onclick() 
{
	try { document.all("htxtCursorPos").value = objOffice.ActiveDocument.Application.Selection.End.toString();} catch (e) {}
	if (CloseDocument(true))
		__doPostBack("lnkMLXgwj",""); 
}









//*********************************************************************************************************************
//the follow programs is common
//*********************************************************************************************************************
//Is Url Path?
function IsUrlPath(strFilePath)
{
	var blnIs = false;
	try	{
		var strUrlPrefix = "";
		if (strFilePath.length >= 6) {
			strUrlPrefix = strFilePath.substring(0,5);
			if (strUrlPrefix.toUpperCase() == "HTTP:")
				blnIs = true;
			if (! blnIs) {
				strUrlPrefix = strFilePath.substring(0,6);
				if (strUrlPrefix.toUpperCase() == "HTTPS:")
					blnIs = true;
			}
		}
	} catch (e) {}
	return blnIs;
}
//Is Microsoft Word ?
function IsMicrosoftWord()
{
	var blnIs   = false;
	try {
		if (! m_blnDocumentOpened)
			return blnIs;
		var objDocument = objOffice.ActiveDocument;
		if (! objDocument)
			return blnIs;
		if (objDocument.Application.Name.toUpperCase() == "MICROSOFT WORD")
			blnIs = true;
	} catch (e) {}
	return blnIs;
}
//Is Microsoft Excel ?
function IsMicrosoftExcel()
{
	var blnIs   = false;
	try {
		if (! m_blnDocumentOpened)
			return blnIs;
		var objDocument = objOffice.ActiveDocument;
		if (! objDocument)
			return blnIs;
		if (objDocument.Application.Name.toUpperCase() == "MICROSOFT EXCEL")
			blnIs = true;
	} catch (e) {}
	return blnIs;
}









//*********************************************************************************************************************
//the follow programs is for initializing the parameters
//*********************************************************************************************************************
//initialize the global parameters
function InitializedParameters()
{
	//******************************************************************************************************
	m_blnIsMicrosoftWord  = false;
	m_blnIsMicrosoftExcel = false;
	//******************************************************************************************************
	m_blnDocumentOpened   = false;
	m_strLocalFileCache   = "";
	//******************************************************************************************************
	m_blnTrackRevisions   = getElementValueSafe_Bool("htxtTrackRevisions");
	m_blnEditMode         = getElementValueSafe_Bool("htxtEditMode");
	// 2009-02-20
	m_blnLocked			  = getElementValueSafe_Bool("htxtLocked");
	// 2009-02-20
	m_blnAutoSave         = getElementValueSafe_Bool("htxtAutoSave");
	m_strFileUrl          = getElementValueSafe_String("htxtFileSpec");
	//******************************************************************************************************
	m_strProtectPassword  = getElementValueSafe_String("htxtProtectPassword");
	m_strUserXM           = getElementValueSafe_String("htxtUserName");
	//******************************************************************************************************
	m_blnCanQSYJ          = getElementValueSafe_Bool("htxtCanQSYJ");
	m_blnCanImportFile    = getElementValueSafe_Bool("htxtCanImportFile");
	m_blnCanExportFile    = getElementValueSafe_Bool("htxtCanExportFile");
	m_blnCanSelectTGWJ    = getElementValueSafe_Bool("htxtCanSelectTGWJ");
	//******************************************************************************************************
	//is in edit mode?
	if (m_blnEditMode == true)
	{
		hrefXGFJ.innerHTML = m_strMsg_EditFJ;
		hrefXGWJ.innerHTML = m_strMsg_EditXGWJ;
	}
	else
	{
		hrefXGFJ.innerHTML = m_strMsg_ReadFJ;
		hrefXGWJ.innerHTML = m_strMsg_ReadXGWJ;
	}
	return true;
}
//open the given file (local or url)
function OpenOfficeDocument()
{
	var blnRe = false;
	try 
	{
		//close current document
		try {objOffice.close();} catch(e) {}
		//check the file path
		if (m_strFileUrl == "") 
			throw m_strMsg_FileNameNull;
		//open document (readonly)
		objOffice.Open(m_strFileUrl, true);
		objOffice.EnableFileCommand(0) = false; //new
		objOffice.EnableFileCommand(1) = false; //open
		objOffice.EnableFileCommand(3) = false; //save
		objOffice.EnableFileCommand(5) = false; //print
		m_blnDocumentOpened = true;
		//is microsoft word or Excel?
		m_blnIsMicrosoftExcel = IsMicrosoftExcel();
		m_blnIsMicrosoftWord  = IsMicrosoftWord();
		
		if (m_blnIsMicrosoftWord) 
		{
			//protect or unprotect document
			if (m_blnEditMode) 
				blnRe = UnprotectWord();
			else 
				blnRe = ProtectWord();
			//save or do not save revisions
			
			if (blnRe)
			{
				if (m_blnTrackRevisions) 
					blnRe = EnabledWordRevisions();						
				else 
					{	
						blnRe = DisableWordRevisions();
						//'2009-08-24 LJ 复制的时候，不带痕迹文件
						objOffice.ActiveDocument.AcceptAllRevisions();	
					}
			}
			//show toolbars
			if (blnRe)
				blnRe = ShowWordToolbars();
			//restore the cursor position
			if (blnRe)
			{
				try { var strCursorPos = document.all("htxtCursorPos").value;
					if (!((strCursorPos == "") || (strCursorPos == undefined))) {
						var intCursorPos = parseInt(strCursorPos, 10);
						objOffice.ActiveDocument.Range(intCursorPos, intCursorPos).Select();
					}
				} catch (e) {}
			}
			//mark the document clean
			if (blnRe)
				objOffice.ActiveDocument.Saved = true;
		}
		if (m_blnIsMicrosoftExcel)
		{
			blnRe = ShowExcelToolbars();
			//mark the document clean
			if (blnRe)
				objOffice.ActiveDocument.Saved = true;
		}
		//set command status
		setCommandDisplay(true);
		return true;
	}
	catch (e) 
	{
		alert(m_strMsg_FileCanNotOpen);
		return false;
	}
	return blnRe;
}
//save the document to the original path
function SaveOfficeDocument()
{
	try 
	{
		if (! m_blnDocumentOpened) 
			throw m_strMsg_FileNotOpen;
		var objDocument = objOffice.ActiveDocument;
		if (! objDocument) 
			throw m_strMsg_FileNotOpen;
		if (m_blnIsMicrosoftWord)
		{
			var strLocalFile = "";
			if (m_strLocalFileCache != "")
				strLocalFile = m_strLocalFileCache;
			else
			{
				strLocalFile = objOffice.GetTempLocalFile(m_strFileUrl);
				if (strLocalFile.length < 1)
					throw m_strMsg_CanNotGetTempLocalFile;
				m_strLocalFileCache = strLocalFile;
			}
			objDocument.SaveAs(strLocalFile);
			objOffice.HttpFileUpload(strLocalFile, m_strFileUrl);
			objDocument.Saved = true;
		}
		else if (m_blnIsMicrosoftExcel)
		{
			var strLocalFile = "";
			if (m_strLocalFileCache != "")
				strLocalFile = m_strLocalFileCache;
			else
			{
				strLocalFile = objOffice.GetTempLocalFile(m_strFileUrl);
				if (strLocalFile.length < 1)
					throw m_strMsg_CanNotGetTempLocalFile;
				m_strLocalFileCache = strLocalFile;
			}
			try {objOffice.DeleteTempFile(m_strLocalFileCache);} catch (e) {}
			objDocument.SaveAs(strLocalFile);
			objOffice.HttpFileUpload(strLocalFile, m_strFileUrl);
			objDocument.Saved = true;
		}
		else
		{
			objOffice.Save();					
		}
		return true;
	}
	catch (e) 
	{
		alert(m_strMsg_FileCanNotSave);
	}
	return false;
}
//close current document. blnSave = true: save file; false: no save
function CloseDocument(blnSave)
{
	try 
	{
		if (!m_blnDocumentOpened)
			return true;
		var objDocument = objOffice.ActiveDocument;
		if (! objDocument)
			return true;
		if (m_blnEditMode && blnSave)
			if (! SaveOfficeDocument())
				return false;
		try { objOffice.Close(); } catch (e) {}
		m_blnDocumentOpened = false;
		return true;
	}
	catch (e) 
	{
		alert(m_strMsg_CanNotCloseDocument);
		return false;
	}
	return false;
}









//*********************************************************************************************************************
//the follow programs is for Word
//*********************************************************************************************************************
//show Word revisions
function ShowWordRevisions()
{
	try 
	{
		if (! m_blnDocumentOpened)
			throw m_strMsg_FileNotOpen;
		var objDocument = objOffice.ActiveDocument;
		if (! objDocument)
			throw m_strMsg_FileNotOpen;
		if (! m_blnIsMicrosoftWord)
			throw m_strMsg_FileNotWord;
		objDocument.TrackRevisions = true;
		objDocument.ShowRevisions  = true;
		objDocument.PrintRevisions = true;
		return true;
	}
	catch (e) 
	{
		alert(m_strMsg_CanNotShowRevisions);
	}
	return false;
}
//hide Word revisions
function HideWordRevisions()
{
	try 
	{
		if (! m_blnDocumentOpened)
			throw m_strMsg_FileNotOpen;
		var objDocument = objOffice.ActiveDocument;
		if (! objDocument)
			throw m_strMsg_FileNotOpen;
		if (! m_blnIsMicrosoftWord)
			throw m_strMsg_FileNotWord;
		objDocument.TrackRevisions = true;
		objDocument.ShowRevisions  = false;
		objDocument.PrintRevisions = false;
		return true;
	}
	catch (e) 
	{
		alert(m_strMsg_CanNotHideRevisions);
	}
	return false;
}
//disable tracking the Word revisions
function DisableWordRevisions()
{
	try 
	{
		if (! m_blnDocumentOpened)
			throw m_strMsg_FileNotOpen;
		var objDocument = objOffice.ActiveDocument;
		if (! objDocument)
			throw m_strMsg_FileNotOpen;
		if (! m_blnIsMicrosoftWord)
			throw m_strMsg_FileNotWord;
		objDocument.TrackRevisions = false;
		objDocument.ShowRevisions  = false;
		objDocument.PrintRevisions = false;
		return true;
	}
	catch (e) 
	{
		alert(m_strMsg_CanNotDisableRevisions);
	}
	return false;
}
//enable tracking the Word revisions
function EnabledWordRevisions()
{
	try 
	{
		if (! m_blnDocumentOpened)
			throw m_strMsg_FileNotOpen;
		var objDocument = objOffice.ActiveDocument;
		if (! objDocument)
			throw m_strMsg_FileNotOpen;
		if (! m_blnIsMicrosoftWord)
			throw m_strMsg_FileNotWord;
		objDocument.Application.UserName = m_strUserXM;
		objDocument.TrackRevisions = true;
		objDocument.ShowRevisions  = false;
		objDocument.PrintRevisions = false;
		return true;
	}
	catch (e) 
	{
		alert(m_strMsg_CanNotEnabledRevisions);
	}
	return false;
}
//protect current Word
function ProtectWord()
{
	try 
	{
		if (! m_blnDocumentOpened)
			throw m_strMsg_FileNotOpen;
		var objDocument = objOffice.ActiveDocument;
		if (! objDocument)
			throw m_strMsg_FileNotOpen;
		if (! m_blnIsMicrosoftWord)
			throw m_strMsg_FileNotWord;
		if (m_strProtectPassword != "")
		{
			try { objDocument.Protect(1, true, m_strProtectPassword); } catch (e) {}
		}
		return true;
	}
	catch (e) 
	{
		alert(m_strMsg_CanNotProtectDocument);
	}
	return false;
}
//unprotect current Word
function UnprotectWord()
{
	try 
	{
		if (! m_blnDocumentOpened)
			throw m_strMsg_FileNotOpen;
		var objDocument = objOffice.ActiveDocument;
		if (! objDocument)
			throw m_strMsg_FileNotOpen;
		if (! m_blnIsMicrosoftWord)
			throw m_strMsg_FileNotWord;
		if (m_strProtectPassword != "")
		{
			try { objDocument.Unprotect(m_strProtectPassword); } catch (e) {}
		}
		return true;
	}
	catch (e) 
	{
		alert(m_strMsg_CanNotUnProtectDocument);
	}
	return false;
}
//show Word toolbars
function ShowWordToolbars()
{
	try	{
		if (! m_blnDocumentOpened)
			throw m_strMsg_FileNotOpen;
		var objDocument = objOffice.ActiveDocument;
		if (! objDocument)
			throw m_strMsg_FileNotOpen;
		if (! m_blnIsMicrosoftWord)
			throw m_strMsg_FileNotWord;
		objOffice.Toolbars = true;
		return true;
	}
	catch (e) 
	{
		alert(m_strMsg_FileNotOpen);
	}
	return false;
}









//*********************************************************************************************************************
//the follow programs is for Excel
//*********************************************************************************************************************
//show Excel revisions
function ShowExcelRevisions()
{
	alert(m_strMsg_CanNotShowRevisions);
	return false;
}
//hide Excel revisions
function HideExcelRevisions()
{
	alert(m_strMsg_CanNotHideRevisions);
	return false;
}
//disable tracking the Excel revisions
function DisableExcelRevisions()
{
	alert(m_strMsg_CanNotDisableRevisions);
	return false;
}
//enable tracking the Excel revisions
function EnabledExcelRevisions()
{
	alert(m_strMsg_CanNotEnabledRevisions);
	return false;
}
//protect current Excel
function ProtectExcel()
{
	try 
	{
		if (! m_blnDocumentOpened)
			throw m_strMsg_FileNotOpen;
		var objDocument = objOffice.ActiveDocument;
		if (! objDocument)
			throw m_strMsg_FileNotOpen;
		if (! m_blnIsMicrosoftExcel)
			throw m_strMsg_FileNotExcel;
		if (m_strProtectPassword != "") 
		{
			try { objDocument.Protect(m_strProtectPassword); } catch (e) {}
		}
		return true;
	}
	catch (e) 
	{
		alert(m_strMsg_CanNotProtectDocument);
	}
	return false;
}
//unprotect current Excel
function UnprotectExcel()
{
	try 
	{
		if (! m_blnDocumentOpened)
			throw m_strMsg_FileNotOpen;
		var objDocument = objOffice.ActiveDocument;
		if (! objDocument)
			throw m_strMsg_FileNotOpen;
		if (! m_blnIsMicrosoftExcel)
			throw m_strMsg_FileNotExcel;
		if (m_strProtectPassword != "")
		{
			try { objDocument.Unprotect(m_strProtectPassword); } catch (e) {}
		}
		return true;
	}
	catch (e) 
	{
		alert(m_strMsg_CanNotUnProtectDocument);
	}
	return false;
}
//show Excel toolbars
function ShowExcelToolbars()
{
	try	
	{
		if (! m_blnDocumentOpened)
			throw m_strMsg_FileNotOpen;
		var objDocument = objOffice.ActiveDocument;
		if (! objDocument)
			throw m_strMsg_FileNotOpen;
		if (! m_blnIsMicrosoftExcel)
			throw m_strMsg_FileNotExcel;
		objOffice.Toolbars = true;
		return true;
	}
	catch (e) 
	{
		alert(m_strMsg_FileNotOpen);
		return false;
	}
	return false;
}
