//*********************************************************************************************************************
//2008-08-04 zengxianglin rewrite this document
//*********************************************************************************************************************
//*********************************************************************************************************************
//global parameters
//*********************************************************************************************************************
var m_blnIsMicrosoftExcel;        		//is Microsoft Excel?
var m_blnIsMicrosoftWord;        		//is Microsoft Word?
var m_blnDocumentOpened;        		//document is opened ?
var m_strUserXM;                 		//current user name
var m_strFileUrl;     			        //the original path of the document
var m_blnEditMode;               		//current workflow file edit mode
var m_blnCanExportFile;               	//can do export file
var m_blnTrackRevisions;         		//will track revisions ?
var m_strProtectPassword;        		//document protected password
var m_strLocalFileCache;                //local file cache
var m_strFileType                       //file extension








//set the command display by success or failure
function setCommandDisplay(blnSuccess)
{
	try {
		//expand, collapse
		if (blnSuccess && m_blnEditMode)
		{
			divContent.style.display = "";
			spanNRYC.style.display = "";
			spanNRXS.style.display = "none";
		}
		else if (blnSuccess == false)
		{
			divContent.style.display = "";
			spanNRYC.style.display = "";
			spanNRXS.style.display = "none";
		}
		else
		{
			if (m_blnIsMicrosoftExcel || m_blnIsMicrosoftWord)
			{
				divContent.style.display = "none";
				spanNRYC.style.display = "none";
				spanNRXS.style.display = "";
			}
			else
			{
				//not doc,xls
				divContent.style.display = "";
				spanNRYC.style.display = "";
				spanNRXS.style.display = "none";
			}
		}
		//download file
		if (blnSuccess && (!(m_blnIsMicrosoftExcel || m_blnIsMicrosoftWord)))
		{
			if (m_strFileUrl == "")
				spanXZWJ.style.display = "none";
			else
				spanXZWJ.style.display = "";
			spanDYWJ.style.display = "none";
		}
		else
		{
			spanXZWJ.style.display = "none";
			spanDYWJ.style.display = "";
		}
		//re-open
		if (blnSuccess)
		{
			spanOPEN.style.display = "none";
		}
		else
		{
			spanOPEN.style.display = "";
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
		if (blnSuccess && m_blnTrackRevisions && (m_blnIsMicrosoftExcel || m_blnIsMicrosoftWord))
		{
			spanHJCK.style.display = "";
			spanHJYC.style.display = "none";
		}
		else
		{
			spanHJCK.style.display = "none";
			spanHJYC.style.display = "none";
		}
		//can export file
		if (blnSuccess && m_blnCanExportFile && (m_blnIsMicrosoftExcel || m_blnIsMicrosoftWord))
			spanDCWJ.style.display = "";
		else
			spanDCWJ.style.display = "none";
		return true;
	} catch (e) {}
	return false;
}
//save file+data and close window (edit mode)
function btnSAVE_onclick() 
{	
	if (CloseDocument(true))
		__doPostBack("lnkMLSave","");
	
}
//close window with no save file+data (edit mode)
function btnQXFH_onclick() 
{	
	if (window.confirm(m_strMsg_CancelPrompt))
		if (CloseDocument(false))
			__doPostBack("lnkMLClose","");
}
//close window (read mode)
function btnFHSJ_onclick() 
{
	if (CloseDocument(false))
		__doPostBack("lnkMLClose","");
}
//download file where type is not doc,xls
function btnXZWJ_onclick() 
{
	if (CloseDocument(false))
		__doPostBack("lnkMLXzwj","");
}
//open document (doc,xls)
function btnOPEN_onclick() 
{
	OpenDocument();
}
//display revisions (doc, xls)
function btnHJCK_onclick() 
{
	try {
		if (ShowWordRevisions()) {
			spanHJCK.style.display = "none";
			spanHJYC.style.display = "";
		}
	} catch(e) {}
}
//hide revisions (doc, xls)
function btnHJYC_onclick() 
{
	try {
		if (HideWordRevisions())
		{
			spanHJYC.style.display = "none";
			spanHJCK.style.display = "";
		}
	} catch(e) {}
}
//expand detail info window
function btnNRXS_onclick() 
{
	try 
	{
		spanNRXS.style.display   = "none";
		spanNRYC.style.display   = "";
		divContent.style.display = "";
	} catch(e) {}
}
//collapse detail info window
function btnNRYC_onclick() 
{
	try {
		spanNRXS.style.display   = "";
		spanNRYC.style.display   = "none";
		divContent.style.display = "none";
	} catch(e) {}
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
	m_strFileUrl          = getElementValueSafe_String("htxtFileSpec");
	//******************************************************************************************************
	m_strProtectPassword  = getElementValueSafe_String("htxtProtectPassword");
	m_strUserXM           = getElementValueSafe_String("htxtUserName");
	//******************************************************************************************************
	m_blnCanExportFile    = getElementValueSafe_Bool("htxtCanExportFile");
	//******************************************************************************************************
	var objArray          = m_strFileUrl.split(".");
	if (objArray.length < 1)
		m_strFileType     = "";
	else
		m_strFileType     = objArray[objArray.length-1];
	m_strFileType         = m_strFileType.toLowerCase();
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
