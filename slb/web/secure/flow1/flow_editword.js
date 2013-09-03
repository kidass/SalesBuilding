//*********************************************************************************************************************
//global parameters
//*********************************************************************************************************************
var m_blnIsMicrosoftExcel;        		//is Microsoft Excel?
var m_blnIsMicrosoftWord;        		//is Microsoft Word?
var m_blnDocumentIsDirty;				//document is dirty?
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




//*********************************************************************************************************************
//jsoffice event handler
//*********************************************************************************************************************
//BeforeDocumentSaved events handler
//user click save command
function objOffice_BeforeDocumentSaved()
{
	try 
	{
		m_blnDocumentIsDirty = true;
	} catch (e) {}
}




//*********************************************************************************************************************
//command event handler
//*********************************************************************************************************************
//hrefHJCK_onclick: show word revision
function hrefHJCK_onclick() 
{
	if (ShowWordRevisions())
	{
		spanHJCK.style.display = "none";
		spanHJYC.style.display = "";
	}
}

//hrefHJYC_onclick: hide word revision
function hrefHJYC_onclick() 
{
	if (HideWordRevisions())
	{
		spanHJYC.style.display = "none";
		spanHJCK.style.display = "";
	}
}

//hrefYJCK_onclick: display opinion window
function hrefYJCK_onclick() 
{
	spanYJCK.style.display = "none";
	spanYJYC.style.display = "";
}

//hrefYJYC_onclick: hide opinion window
function hrefYJYC_onclick() 
{
	spanYJYC.style.display = "none";
	spanYJCK.style.display = "";
}

//hrefOPEN_onclick: open office document
function hrefOPEN_onclick() 
{
	OpenDocument();
}

//hrefDRWJ_onclick: change current document
function hrefDRWJ_onclick() 
{
	if (CloseDocument(true))
		__doPostBack("lnkMLDrwj",""); //submit to http server to close the module
}

//hrefFHSJ_onclick: not prompt to cancel, not save data and close current window
function hrefFHSJ_onclick() 
{
	if (CloseDocument(false))
		__doPostBack("lnkMLClose","");         //submit to http server to close the module
}

//hrefQXFH_onclick: prompt to cancel, not save data and close current window
function hrefQXFH_onclick() 
{
	if (window.confirm(m_strMsg_CancelPrompt)) //prompt to cancel?
		if (CloseDocument(false))
			__doPostBack("lnkMLClose","");     //submit to http server to close the module
}

//hrefSAVE_onclick: save data and close current window
function hrefSAVE_onclick() 
{
	if (CloseDocument(true))
		__doPostBack("lnkMLSave",""); //submit to http server to close the module
}

//hrefXGFJ_onclick: open fujian window
function hrefXGFJ_onclick() 
{
	try {
		document.all("htxtCursorPos").value = objOffice.ActiveDocument.Application.Selection.End.toString();
	} 
	catch (e) {}
	if (CloseDocument(true))
		__doPostBack("lnkMLXgfj",""); //submit to http server to close the module
}

//hrefXGWJ_onclick: open xiangguanwenjian window
function hrefXGWJ_onclick() 
{
	try {
		document.all("htxtCursorPos").value = objOffice.ActiveDocument.Application.Selection.End.toString();
	} 
	catch (e) {}
	if (CloseDocument(true))
		__doPostBack("lnkMLXgwj",""); //submit to http server to close the module
}






//*********************************************************************************************************************
//the follow programs is common
//*********************************************************************************************************************
//Is Url Path?
function IsUrlPath(strFilePath)
{
	var blnIs = false;
	try	
	{
		var strUrlPrefix = "";
		if (strFilePath.length >= 6) 
		{
			strUrlPrefix = strFilePath.substring(0,5);
			if (strUrlPrefix.toUpperCase() == "HTTP:")
				blnIs = true;
			if (! blnIs) 
			{
				strUrlPrefix = strFilePath.substring(0,6);
				if (strUrlPrefix.toUpperCase() == "HTTPS:")
					blnIs = true;
			}
		}
	}
	catch (e) {}
	return blnIs;
}

//Is Microsoft Word ?
function IsMicrosoftWord()
{
	var blnIs   = false;
	try 
	{
		var objDocument = null;
		if (! m_blnDocumentOpened)
			return blnIs;
		objDocument = objOffice.ActiveDocument;
		if (! objDocument)
			return blnIs;
		if (objDocument.Application.Name.toUpperCase() == "MICROSOFT WORD")
			blnIs = true;
	}
	catch (e) {}
	return blnIs;
}

//Is Microsoft Excel ?
function IsMicrosoftExcel()
{
	var blnIs   = false;
	try 
	{
		var objDocument = null;
		if (! m_blnDocumentOpened)
			return blnIs;
		objDocument = objOffice.ActiveDocument;
		if (! objDocument)
			return blnIs;
		if (objDocument.Application.Name.toUpperCase() == "MICROSOFT EXCEL")
			blnIs = true;
	}
	catch (e) {}
	return blnIs;
}




//*********************************************************************************************************************
//the follow programs is for initializing the parameters
//*********************************************************************************************************************
//initialize the global parameters
function InitializedParameters()
{
	var objControl = null;
	
	//**********************************
	m_blnIsMicrosoftWord = false;
	m_blnIsMicrosoftExcel = false;
	//**********************************
	m_blnDocumentIsDirty = false;
	m_blnDocumentOpened = false;
	spanOPEN.style.display = "none"; //default set
	//**********************************
	m_blnTrackRevisions = false;
	m_blnEditMode = false;
	m_blnAutoSave= false;
	m_strFileUrl = "";
	//**********************************
	m_strProtectPassword = "";
	m_strUserXM = "";
	//**********************************
	m_blnCanQSYJ = false;
	m_blnCanImportFile = false;
	m_blnCanExportFile = false;
	m_blnCanSelectTGWJ = false;
	//**********************************
	
	//**********************************
	objControl = null;
	objControl = document.getElementById("htxtFileSpec");
	if (objControl)
		m_strFileUrl = objControl.value;
	//**********************************
	objControl = null;
	objControl = document.getElementById("htxtUserName");
	if (objControl)
		m_strUserXM = objControl.value;
	//**********************************
	objControl = null;
	objControl = document.getElementById("htxtProtectPassword");
	if (objControl)
		m_strProtectPassword = objControl.value;
	//**********************************
	objControl = null;
	objControl = document.getElementById("htxtAutoSave");
	if (objControl)
		if (objControl.value == "1") 
			m_blnAutoSave = true;
	//**********************************
	objControl = null;
	objControl = document.getElementById("htxtEditMode");
	if (objControl)
		if (objControl.value == "1") 
			m_blnEditMode = true;
	//**********************************
	objControl = null;
	objControl = document.getElementById("htxtTrackRevisions");
	if (objControl)
		if (objControl.value == "1") 
			m_blnTrackRevisions = true;
	if (m_blnTrackRevisions == false)
		spanHJCK.style.display = "none";
	//**********************************
	objControl = null;
	objControl = document.getElementById("htxtCanQSYJ");
	if (objControl)
		if (objControl.value == "1") 
			m_blnCanQSYJ = true;
	if (m_blnCanQSYJ == false)
		spanYJCK.style.display = "none";
	//**********************************
	objControl = null;
	objControl = document.getElementById("htxtCanImportFile");
	if (objControl)
		if (objControl.value == "1") 
			m_blnCanImportFile = true;
	if (m_blnCanImportFile == false)
		spanDRWJ.style.display = "none";
	//**********************************
	objControl = null;
	objControl = document.getElementById("htxtCanExportFile");
	if (objControl)
		if (objControl.value == "1") 
			m_blnCanExportFile = true;
	spanDCWJ.style.display = "none"; //default set
	//**********************************
	objControl = null;
	objControl = document.getElementById("htxtCanSelectTGWJ");
	if (objControl)
		if (objControl.value == "1") 
			m_blnCanSelectTGWJ = true;
	if (m_blnCanSelectTGWJ && m_blnEditMode)
		spanXZGJ.style.display = "";
	else
		spanXZGJ.style.display = "none";

	//is in edit mode?
	if (m_blnEditMode == true)
	{
		hrefXGFJ.innerHTML = m_strMsg_EditFJ;
		hrefXGWJ.innerHTML = m_strMsg_EditXGWJ;
		if (spanDRWJ.style.display == "")
			spanDRWJ.style.display = "";
		if (spanXZGJ.style.display == "")
			spanXZGJ.style.display = "";
		spanSAVE.style.display = "";
		spanQXFH.style.display = "";
		spanFHSJ.style.display = "none";
	}
	else
	{
		spanDRWJ.style.display = "none";
		spanXZGJ.style.display = "none";
		spanSAVE.style.display = "none";
		spanQXFH.style.display = "none";
		spanFHSJ.style.display = "";
	}

	return true;
}




//*********************************************************************************************************************
//the follow programs is for all office document
//*********************************************************************************************************************
//open the given file (local or url)
function OpenOfficeDocument()
{
	try 
	{
		var blnReadOnly = true;
		//check the file path
		if (m_strFileUrl == "")
		{
			alert("Error: File name is blank!");
			return false;
		}
		//get the open mode
		if (m_blnEditMode)
			blnReadOnly = false;
		//open document
		objOffice.Open(m_strFileUrl, blnReadOnly);
		objOffice.EnableFileCommand(0) = false; //new
		objOffice.EnableFileCommand(1) = false; //open
		objOffice.EnableFileCommand(3) = false; //save
		objOffice.EnableFileCommand(5) = false; //print
		//save the opened mark
		m_blnDocumentOpened = true;
		spanDCWJ.style.display = "";
		spanOPEN.style.display = ""; //default set
		//is microsoft word or Excel?
		m_blnIsMicrosoftExcel = false;
		m_blnIsMicrosoftExcel = IsMicrosoftExcel();
		m_blnIsMicrosoftWord  = false;
		m_blnIsMicrosoftWord  = IsMicrosoftWord();
		if (m_blnIsMicrosoftWord) 
		{
			if (m_blnEditMode) 
			{
				if (!UnprotectWord()) //unprotect the document
					return false;
			}
			else 
			{
				if (!ProtectWord())   //protect current document
					return false;
			}
			if (m_blnTrackRevisions) 
			{
				if (!EnabledWordRevisions()) //enable document track revisions
					return false;
				if (!HideWordRevisions())    //hide the revisions
					return false;
			}
			else 
			{
				if (!DisableWordRevisions()) //disable document track revisions
					return false;
			}
			if (!ShowWordToolbars()) //show office toolbars
				return false;
			
			try {
				var strCursorPos = "";
				strCursorPos = document.all("htxtCursorPos").value;
				if (!((strCursorPos == "") || (strCursorPos == undefined)))
				{
					var intCursorPos = 0;
					intCursorPos = parseInt(strCursorPos, 10);
					objOffice.ActiveDocument.Range(intCursorPos, intCursorPos).Select();
				}
			} catch (e) {}
		}
		if (m_blnIsMicrosoftExcel)
		{
			if (!ShowExcelToolbars()) //show office toolbars
				return false;
		}
		//mark the document is not dirty
		m_blnDocumentIsDirty = false;
		
		return true;
	}
	catch (e) 
	{
		alert(m_strMsg_FileCanNotOpen);
	}
	return false;
}

//save the document to the original path
function SaveOfficeDocument()
{
	try 
	{
		var blnIsUrlPath = false;
		var strOldFile   = "";
		var strLocalFile = "";
		var objDocument  = null;
		if (! m_blnDocumentOpened)
		{
			alert(m_strMsg_FileNotOpen);
			return false;
		}
		objDocument = objOffice.ActiveDocument;
		if (! objDocument) 
		{
			alert(m_strMsg_FileNotOpen);
			return false;
		}
		if (m_blnIsMicrosoftWord)
		{
			strOldFile = objOffice.DocumentFullName;
			blnIsUrlPath = IsUrlPath(strOldFile);
			//protect document
			if (!ProtectWord())
				return false;
			try
			{
				//unlock the current document
				objOffice.UnlockDocument();
				if (blnIsUrlPath) 
				{
					//get the local file
					strLocalFile = objOffice.GetTempLocalFile(strOldFile);
					if (strLocalFile.length < 1)
					{
						UnprotectWord();
						alert(m_strMsg_CanNotGetTempLocalFile);
						return false;
					}
					//save the local file by word
					objDocument.SaveAs(strLocalFile);
					//upload to url
					objOffice.HttpFileUpload(strLocalFile, strOldFile);
					//delete the local file
					try
					{
						objOffice.DeleteTempFile(strLocalFile);
					} catch (e) {}
				}
				else
				{
					//default save mothed
					objOffice.Save();
				}
			}
			catch (e)
			{
				UnprotectWord();
				alert(m_strMsg_FileCanNotSave);
				return false;
			}
			//unprotect the document
			if (!UnprotectWord())
				return false;
		}
		else if (m_blnIsMicrosoftExcel)
		{
			//default save mothed
			objOffice.Save();
		}
		else
		{
			//default save mothed
			objOffice.Save();
		}
		//mark the document is not dirty
		m_blnDocumentIsDirty = false;
		return true;
	}
	catch (e) 
	{
		alert(m_strMsg_FileCanNotSave);
	}
	return false;
}

//close current document
//when in edit mode and document is modified, then prompt to save?
function CloseDocument(blnSave)
{
	try {
		var objDocument = null;
		if (!m_blnDocumentOpened)
			return true;
		objDocument = objOffice.ActiveDocument;
		if (! objDocument)
			return true;
		if (m_blnEditMode)
			if (blnSave)
				if (SaveOfficeDocument() == false)
					return false;
		//close current document
		objOffice.Close();
		//mark the document is close
		m_blnDocumentOpened = false;
		return true;
	}
	catch (e) 
	{
		alert(m_strMsg_CanNotCloseDocument);
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
		var objDocument = null;
		if (! m_blnDocumentOpened)
		{
			alert(m_strMsg_FileNotOpen);
			return false;
		}
		objDocument = objOffice.ActiveDocument;
		if (! objDocument)
		{
			alert(m_strMsg_FileNotOpen);
			return false;
		}
		if (! m_blnIsMicrosoftWord)
		{
			alert(m_strMsg_FileNotWord);
			return false;
		}
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
		var objDocument = null;
		if (! m_blnDocumentOpened)
		{
			alert(m_strMsg_FileNotOpen);
			return false;
		}
		objDocument = objOffice.ActiveDocument;
		if (! objDocument)
		{
			alert(m_strMsg_FileNotOpen);
			return false;
		}
		if (! m_blnIsMicrosoftWord)
		{
			alert(m_strMsg_FileNotWord);
			return false;
		}
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
		var objDocument = null;
		if (! m_blnDocumentOpened)
		{
			alert(m_strMsg_FileNotOpen);
			return false;
		}
		objDocument = objOffice.ActiveDocument;
		if (! objDocument)
		{
			alert(m_strMsg_FileNotOpen);
			return false;
		}
		if (! m_blnIsMicrosoftWord)
		{
			alert(m_strMsg_FileNotWord);
			return false;
		}
		objDocument.AcceptAllRevisions();
		objDocument.Application.UserName = m_strUserXM;
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
		var objDocument = null;
		if (! m_blnDocumentOpened)
		{
			alert(m_strMsg_FileNotOpen);
			return false;
		}
		objDocument = objOffice.ActiveDocument;
		if (! objDocument)
		{
			alert(m_strMsg_FileNotOpen);
			return false;
		}
		if (! m_blnIsMicrosoftWord)
		{
			alert(m_strMsg_FileNotWord);
			return false;
		}
		objDocument.Application.UserName = m_strUserXM;
		objDocument.TrackRevisions = true;
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
		var objDocument = null;
		if (! m_blnDocumentOpened)
		{
			alert(m_strMsg_FileNotOpen);
			return false;
		}
		objDocument = objOffice.ActiveDocument;
		if (! objDocument)
		{
			alert(m_strMsg_FileNotOpen);
			return false;
		}
		if (! m_blnIsMicrosoftWord)
		{
			alert(m_strMsg_FileNotWord);
			return false;
		}
		if (m_strProtectPassword != "")
		{
			try 
			{
				objDocument.Protect(1, true, m_strProtectPassword);
			} catch (e) {}
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
		var objDocument = null;
		if (! m_blnDocumentOpened)
		{
			alert(m_strMsg_FileNotOpen);
			return false;
		}
		objDocument = objOffice.ActiveDocument;
		if (! objDocument)
		{
			alert(m_strMsg_FileNotOpen);
			return false;
		}
		if (! m_blnIsMicrosoftWord)
		{
			alert(m_strMsg_FileNotWord);
			return false;
		}
		if (m_strProtectPassword != "")
		{
			try 
			{
				objDocument.Unprotect(m_strProtectPassword);
			} catch (e) {}
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
		var objDocument = null;
		if (! m_blnDocumentOpened)
		{
			alert(m_strMsg_FileNotOpen);
			return false;
		}
		objDocument = objOffice.ActiveDocument;
		if (! objDocument)
		{
			alert(m_strMsg_FileNotOpen);
			return false;
		}
		if (! m_blnIsMicrosoftWord)
		{
			alert(m_strMsg_FileNotWord);
			return false;
		}
		objOffice.Toolbars = true;
		objDocument.CommandBars("Standard").Visible = true;
		objDocument.CommandBars("Standard").RowIndex = 1;
		objDocument.CommandBars("Standard").Protection = 8;
		objDocument.CommandBars("Standard").Left = 0;
		objDocument.CommandBars("Formatting").Visible = true;
		objDocument.CommandBars("Formatting").RowIndex = 2;
		objDocument.CommandBars("Formatting").Protection = 8;
		objDocument.CommandBars("Formatting").Left = 0;
		
		return true;
	}
	catch (e) {
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
	try 
	{
		var objDocument = null;
		if (! m_blnDocumentOpened)
		{
			alert(m_strMsg_FileNotOpen);
			return false;
		}
		objDocument = objOffice.ActiveDocument;
		if (! objDocument)
		{
			alert(m_strMsg_FileNotOpen);
			return false;
		}
		if (! m_blnIsMicrosoftExcel)
		{
			alert(m_strMsg_FileNotExcel);
			return false;
		}
		return true;
	}
	catch (e) 
	{
		alert(m_strMsg_CanNotShowRevisions);
	}
	return false;
}

//hide Excel revisions
function HideExcelRevisions()
{
	try 
	{
		var objDocument = null;
		if (! m_blnDocumentOpened)
		{
			alert(m_strMsg_FileNotOpen);
			return false;
		}
		objDocument = objOffice.ActiveDocument;
		if (! objDocument)
		{
			alert(m_strMsg_FileNotOpen);
			return false;
		}
		if (! m_blnIsMicrosoftExcel)
		{
			alert(m_strMsg_FileNotExcel);
			return false;
		}
		return true;
	}
	catch (e) 
	{
		alert(m_strMsg_CanNotHideRevisions);
	}
	return false;
}

//disable tracking the Excel revisions
function DisableExcelRevisions()
{
	try 
	{
		var objDocument = null;
		if (! m_blnDocumentOpened)
		{
			alert(m_strMsg_FileNotOpen);
			return false;
		}
		objDocument = objOffice.ActiveDocument;
		if (! objDocument)
		{
			alert(m_strMsg_FileNotOpen);
			return false;
		}
		if (! m_blnIsMicrosoftExcel)
		{
			alert(m_strMsg_FileNotExcel);
			return false;
		}
		return true;
	}
	catch (e) 
	{
		alert(m_strMsg_CanNotDisableRevisions);
	}
	return false;
}

//enable tracking the Excel revisions
function EnabledExcelRevisions()
{
	try 
	{
		var objDocument = null;
		if (! m_blnDocumentOpened)
		{
			alert(m_strMsg_FileNotOpen);
			return false;
		}
		objDocument = objOffice.ActiveDocument;
		if (! objDocument)
		{
			alert(m_strMsg_FileNotOpen);
			return false;
		}
		if (! m_blnIsMicrosoftExcel)
		{
			alert(m_strMsg_FileNotExcel);
			return false;
		}
		objDocument.Application.UserName = m_strUserXM;
		return true;
	}
	catch (e) 
	{
		alert(m_strMsg_CanNotEnabledRevisions);
	}
	return false;
}

//protect current Excel
function ProtectExcel()
{
	try 
	{
		var objDocument = null;
		if (! m_blnDocumentOpened)
		{
			alert(m_strMsg_FileNotOpen);
			return false;
		}
		objDocument = objOffice.ActiveDocument;
		if (! objDocument)
		{
			alert(m_strMsg_FileNotOpen);
			return false;
		}
		if (! m_blnIsMicrosoftExcel)
		{
			alert(m_strMsg_FileNotExcel);
			return false;
		}
		if (m_strProtectPassword != "")
		{
			try 
			{
				objDocument.Protect(m_strProtectPassword);
			} catch (e) {}
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
		var objDocument = null;
		if (! m_blnDocumentOpened)
		{
			alert(m_strMsg_FileNotOpen);
			return false;
		}
		objDocument = objOffice.ActiveDocument;
		if (! objDocument)
		{
			alert(m_strMsg_FileNotOpen);
			return false;
		}
		if (! m_blnIsMicrosoftExcel)
		{
			alert(m_strMsg_FileNotExcel);
			return false;
		}
		if (m_strProtectPassword != "")
		{
			try 
			{
				objDocument.Unprotect(m_strProtectPassword);
			} catch (e) {}
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
	try	{
		var objDocument = null;
		if (! m_blnDocumentOpened)
		{
			alert(m_strMsg_FileNotOpen);
			return false;
		}
		objDocument = objOffice.ActiveDocument;
		if (! objDocument)
		{
			alert(m_strMsg_FileNotOpen);
			return false;
		}
		if (! m_blnIsMicrosoftExcel)
		{
			alert(m_strMsg_FileNotExcel);
			return false;
		}
		objOffice.Toolbars = true;
		objDocument.CommandBars("Standard").Visible = true;
		objDocument.CommandBars("Standard").RowIndex = 1;
		objDocument.CommandBars("Standard").Protection = 8;
		objDocument.CommandBars("Standard").Left = 0;
		objDocument.CommandBars("Formatting").Visible = true;
		objDocument.CommandBars("Formatting").RowIndex = 2;
		objDocument.CommandBars("Formatting").Protection = 8;
		objDocument.CommandBars("Formatting").Left = 0;

		return true;
	}
	catch (e) {
		alert(m_strMsg_FileNotOpen);
		return false;
	}
	return false;
}