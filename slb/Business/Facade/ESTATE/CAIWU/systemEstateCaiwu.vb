'----------------------------------------------------------------
' Copyright (C) 2006-2016 Josco Software Corporation
' All rights reserved.
'
' This source code is intended only as a supplement to Microsoft
' Development Tools and/or on-line documentation. See these other
' materials for detailed information regarding Microsoft code samples.
'
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY 
' OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT 
' LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR 
' FITNESS FOR A PARTICULAR PURPOSE.
'----------------------------------------------------------------
Option Strict On
Option Explicit On 

Imports System
Imports System.Data
Imports System.Security.Cryptography
Imports Microsoft.VisualBasic

Imports Josco.JsKernal.SystemFramework
Imports Josco.JsKernal.Common.Data
Imports Josco.JsKernal.BusinessRules

Namespace Josco.JSOA.BusinessFacade
    '----------------------------------------------------------------
    ' 命名空间：Josco.JSOA.BusinessFacade
    ' 类名    ：systemEstateCaiwu
    '
    ' 功能描述： 
    '   　提供对财务处理的表现层支持
    '----------------------------------------------------------------
    Public Class systemEstateCaiwu
        Implements System.IDisposable

        Private m_objrulesEstateCaiwu As Josco.JSOA.BusinessRules.rulesEstateCaiwu

        '----------------------------------------------------------------
        ' 构造函数
        '----------------------------------------------------------------
        Public Sub New()
            MyBase.New()
            m_objrulesEstateCaiwu = New Josco.JSOA.BusinessRules.rulesEstateCaiwu
        End Sub

        '----------------------------------------------------------------
        ' 安全释放本身资源
        '----------------------------------------------------------------
        Public Shared Sub SafeRelease(ByRef obj As Josco.JSOA.BusinessFacade.systemEstateCaiwu)
            Try
                If Not (obj Is Nothing) Then
                    obj.Dispose()
                End If
            Catch ex As Exception
            End Try
            obj = Nothing
        End Sub

        '----------------------------------------------------------------
        ' 虚拟析构函数
        '----------------------------------------------------------------
        Public Sub Dispose() Implements System.IDisposable.Dispose
            Dispose(True)
            GC.SuppressFinalize(True)
        End Sub

        '----------------------------------------------------------------
        ' 析构函数重载
        '----------------------------------------------------------------
        Protected Overridable Sub Dispose(ByVal disposing As Boolean)
            If (Not disposing) Then
                Exit Sub
            End If
            If Not (m_objrulesEstateCaiwu Is Nothing) Then
                m_objrulesEstateCaiwu.Dispose()
                m_objrulesEstateCaiwu = Nothing
            End If
        End Sub











        '----------------------------------------------------------------
        ' 将数据从DataSet导出到Excel
        '     strErrMsg              ：如果错误，则返回错误信息
        '     objDataSet             ：要导出的数据集
        '     strExcelFile           ：导出到WEB服务器中的Excel文件路径
        '     strMacroName           ：宏名列表
        '     strMacroValue          ：宏值列表
        '     strDateFormat          ：日期格式字符串
        ' 返回
        '     True                   ：成功
        '     False                  ：失败
        '----------------------------------------------------------------
        Public Function doExportToExcel( _
            ByRef strErrMsg As String, _
            ByVal objDataSet As System.Data.DataSet, _
            ByVal strExcelFile As String, _
            Optional ByVal strMacroName As String = "", _
            Optional ByVal strMacroValue As String = "", _
            Optional ByVal strDateFormat As String = "") As Boolean
            With Me.m_objrulesEstateCaiwu
                doExportToExcel = .doExportToExcel(strErrMsg, objDataSet, strExcelFile, strMacroName, strMacroValue, strDateFormat)
            End With
        End Function

        '----------------------------------------------------------------
        ' 将数据从DataSet导出到Excel
        '     strErrMsg              ：如果错误，则返回错误信息
        '     objDataSet             ：要导出的数据集
        '     strExcelFile           ：导出到WEB服务器中的Excel文件路径
        '     strColorFieldName      ：用来确定行颜色的字段名
        '     objColors              ：字段值对应的颜色集合
        '     strMacroName           ：宏名列表
        '     strMacroValue          ：宏值列表
        '     strDateFormat          ：日期格式字符串
        ' 返回
        '     True                   ：成功
        '     False                  ：失败
        '----------------------------------------------------------------
        Public Function doExportToExcel( _
            ByRef strErrMsg As String, _
            ByVal objDataSet As System.Data.DataSet, _
            ByVal strExcelFile As String, _
            ByVal strColorFieldName As String, _
            ByVal objColors As System.Collections.Specialized.ListDictionary, _
            Optional ByVal strMacroName As String = "", _
            Optional ByVal strMacroValue As String = "", _
            Optional ByVal strDateFormat As String = "") As Boolean
            With Me.m_objrulesEstateCaiwu
                doExportToExcel = .doExportToExcel(strErrMsg, objDataSet, strExcelFile, strColorFieldName, objColors, strMacroName, strMacroValue, strDateFormat)
            End With
        End Function









        '----------------------------------------------------------------
        ' 获取“地产_B_财务_票据使用情况”完全数据的数据集
        ' 以“发给分行”、“票据批号”、“票据号码”升序排序
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     strWhere                   ：搜索字符串
        '     objestateCaiwuData         ：信息数据集
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
        '----------------------------------------------------------------
        Public Function getDataSet_PJSY( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWhere As String, _
            ByRef objestateCaiwuData As Josco.JSOA.Common.Data.estateCaiwuData) As Boolean
            With m_objrulesEstateCaiwu
                getDataSet_PJSY = .getDataSet_PJSY(strErrMsg, strUserId, strPassword, strWhere, objestateCaiwuData)
            End With
        End Function

        '----------------------------------------------------------------
        ' 发放票据
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     strPrefix            ：票据前导符
        '     intMin               ：本批开始号
        '     intMax               ：本批结束号
        '     strPJLX              ：票据类型
        '     strFGFH              ：发给分行的代码
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        ' 更改描述
        '     zengxianglin 2008-11-18 add 
        '         ByVal strFFPC As String
        '----------------------------------------------------------------
        Public Function doPiaoju_Fafang( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strPrefix As String, _
            ByVal intMin As Integer, _
            ByVal intMax As Integer, _
            ByVal strPJLX As String, _
            ByVal strFGFH As String, _
            ByVal strFFPC As String) As Boolean
            With m_objrulesEstateCaiwu
                doPiaoju_Fafang = .doPiaoju_Fafang(strErrMsg, strUserId, strPassword, strPrefix, intMin, intMax, strPJLX, strFGFH, strFFPC)
            End With
        End Function

        '----------------------------------------------------------------
        ' 标记票据的使用情况
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     strWYBS              ：要标记的票据的“唯一标识”
        '     objenumPiaojuStatus  ：标记类型
        '     objParams            ：额外参数
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        '----------------------------------------------------------------
        Public Function doPiaoju_Mark( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWYBS As String, _
            ByVal objenumPiaojuStatus As Josco.JSOA.Common.Data.estateCaiwuData.enumPiaojuStatus, _
            ByVal objParams As System.Collections.Specialized.NameValueCollection) As Boolean
            With m_objrulesEstateCaiwu
                doPiaoju_Mark = .doPiaoju_Mark(strErrMsg, strUserId, strPassword, strWYBS, objenumPiaojuStatus, objParams)
            End With
        End Function

        '----------------------------------------------------------------
        ' 删除票据
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     strWYBS              ：票据的唯一标识
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        '----------------------------------------------------------------
        Public Function doPiaoju_Delete( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWYBS As String) As Boolean
            With m_objrulesEstateCaiwu
                doPiaoju_Delete = .doPiaoju_Delete(strErrMsg, strUserId, strPassword, strWYBS)
            End With
        End Function

        '----------------------------------------------------------------
        ' 判断给定的票据号码是否为连续开具？
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     strFGFH              ：发给分行
        '     strPJPH              ：发放批次
        '     strPJHM              ：票据号码
        '     blnIS                ：返回是否
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        '----------------------------------------------------------------
        Public Function isPjhmContinue( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strFGFH As String, _
            ByVal strPJPH As String, _
            ByVal strPJHM As String, _
            ByRef blnIS As Boolean) As Boolean
            With m_objrulesEstateCaiwu
                isPjhmContinue = .isPjhmContinue(strErrMsg, strUserId, strPassword, strFGFH, strPJPH, strPJHM, blnIS)
            End With
        End Function

        '----------------------------------------------------------------
        ' 根据“确认书号”获取“地产_B_财务_二手应收应付”完全数据的数据集
        ' 以“应收日期”升序排序
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     strQRSH                    ：确认书号
        '     strWhere                   ：搜索字符串
        '     objestateCaiwuData         ：信息数据集
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
        '----------------------------------------------------------------
        Public Function getDataSet_ES_YSYF( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strQRSH As String, _
            ByVal strWhere As String, _
            ByRef objestateCaiwuData As Josco.JSOA.Common.Data.estateCaiwuData) As Boolean
            With m_objrulesEstateCaiwu
                getDataSet_ES_YSYF = .getDataSet_ES_YSYF(strErrMsg, strUserId, strPassword, strQRSH, strWhere, objestateCaiwuData)
            End With
        End Function

        '----------------------------------------------------------------
        ' 保存“地产_B_财务_二手应收应付”的数据
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     objOldData           ：旧数据
        '     objNewData           ：新数据
        '     objenumEditType      ：编辑类型
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        '----------------------------------------------------------------
        Public Function doSaveData_ES_YSYF( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objOldData As System.Data.DataRow, _
            ByRef objNewData As System.Collections.Specialized.NameValueCollection, _
            ByVal objenumEditType As Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType) As Boolean
            With m_objrulesEstateCaiwu
                doSaveData_ES_YSYF = .doSaveData_ES_YSYF(strErrMsg, strUserId, strPassword, objOldData, objNewData, objenumEditType)
            End With
        End Function

        '----------------------------------------------------------------
        ' 删除“地产_B_财务_二手应收应付”的数据
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     strWYBS              ：唯一标识
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        '----------------------------------------------------------------
        Public Function doDeleteData_ES_YSYF( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWYBS As String) As Boolean
            With m_objrulesEstateCaiwu
                doDeleteData_ES_YSYF = .doDeleteData_ES_YSYF(strErrMsg, strUserId, strPassword, strWYBS)
            End With
        End Function

        '----------------------------------------------------------------
        ' 根据模板创建“地产_B_财务_二手应收应付”的数据
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     strQRSH              ：确认书号
        '     strMBDM              ：模版代码
        '     blnClear             ：清除标志
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        '----------------------------------------------------------------
        Public Function doMakeYSYF( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strQRSH As String, _
            ByVal strMBDM As String, _
            ByVal blnClear As Boolean) As Boolean
            With m_objrulesEstateCaiwu
                doMakeYSYF = .doMakeYSYF(strErrMsg, strUserId, strPassword, strQRSH, strMBDM, blnClear)
            End With
        End Function

        '----------------------------------------------------------------
        ' 判断给定的确认书号是否已有实际收支？
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     strQRSH              ：确认书号
        '     blnIS                ：返回是否
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        '----------------------------------------------------------------
        Public Function isFashengShishou( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strQRSH As String, _
            ByRef blnIS As Boolean) As Boolean
            With m_objrulesEstateCaiwu
                isFashengShishou = .isFashengShishou(strErrMsg, strUserId, strPassword, strQRSH, blnIS)
            End With
        End Function

        '----------------------------------------------------------------
        ' 根据“确认书号”获取“地产_B_财务_二手实收实付”完全数据的数据集
        ' 以“发生日期”升序排序
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     strQRSH                    ：确认书号
        '     strWhere                   ：搜索字符串
        '     objestateCaiwuData         ：信息数据集
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
        '----------------------------------------------------------------
        Public Function getDataSet_ES_SSSF( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strQRSH As String, _
            ByVal strWhere As String, _
            ByRef objestateCaiwuData As Josco.JSOA.Common.Data.estateCaiwuData) As Boolean
            With m_objrulesEstateCaiwu
                getDataSet_ES_SSSF = .getDataSet_ES_SSSF(strErrMsg, strUserId, strPassword, strQRSH, strWhere, objestateCaiwuData)
            End With
        End Function

        '----------------------------------------------------------------
        ' 保存“地产_B_财务_二手实收实付”的数据
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     objOldData           ：旧数据
        '     objNewData           ：新数据
        '     objenumEditType      ：编辑类型
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        '----------------------------------------------------------------
        Public Function doSaveData_ES_SSSF( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objOldData As System.Data.DataRow, _
            ByRef objNewData As System.Collections.Specialized.NameValueCollection, _
            ByVal objenumEditType As Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType) As Boolean
            With m_objrulesEstateCaiwu
                doSaveData_ES_SSSF = .doSaveData_ES_SSSF(strErrMsg, strUserId, strPassword, objOldData, objNewData, objenumEditType)
            End With
        End Function

        '----------------------------------------------------------------
        ' 根据收款计划收取款项
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     objNewData           ：相关参数
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        '----------------------------------------------------------------
        Public Function doAddNew_ES_SSSF( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objNewData As System.Collections.Specialized.NameValueCollection) As Boolean
            With m_objrulesEstateCaiwu
                doAddNew_ES_SSSF = .doAddNew_ES_SSSF(strErrMsg, strUserId, strPassword, objNewData)
            End With
        End Function

        '----------------------------------------------------------------
        ' 将指定款项按指定方式结转处理
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     objNewData           ：相关参数
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        '----------------------------------------------------------------
        Public Function doJiezhuan_ES_SSSF( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objNewData As System.Collections.Specialized.NameValueCollection) As Boolean
            With m_objrulesEstateCaiwu
                doJiezhuan_ES_SSSF = .doJiezhuan_ES_SSSF(strErrMsg, strUserId, strPassword, objNewData)
            End With
        End Function

        '----------------------------------------------------------------
        ' 获取“地产_B_财务_二手实收实付”完全数据的数据集
        ' 以“发生日期”升序排序
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     strWhere                   ：搜索字符串
        '     blnUnused                  ：接口重载
        '     objestateCaiwuData         ：信息数据集
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
        '----------------------------------------------------------------
        Public Function getDataSet_ES_SSSF( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWhere As String, _
            ByVal blnUnused As Boolean, _
            ByRef objestateCaiwuData As Josco.JSOA.Common.Data.estateCaiwuData) As Boolean
            With m_objrulesEstateCaiwu
                getDataSet_ES_SSSF = .getDataSet_ES_SSSF(strErrMsg, strUserId, strPassword, strWhere, blnUnused, objestateCaiwuData)
            End With
        End Function

        '----------------------------------------------------------------
        ' 删除“地产_B_财务_二手实收实付”的数据(必须没有审过)
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     strWYBS              ：唯一标识
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        '----------------------------------------------------------------
        Public Function doDeleteData_ES_SSSF( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWYBS As String) As Boolean
            With m_objrulesEstateCaiwu
                doDeleteData_ES_SSSF = .doDeleteData_ES_SSSF(strErrMsg, strUserId, strPassword, strWYBS)
            End With
        End Function

        '----------------------------------------------------------------
        ' 审定款项
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     blnTongguo           ：True通过审核
        '     objNewData           ：相关参数
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        '----------------------------------------------------------------
        Public Function doShenhe_ES_SSSF( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal blnTongguo As Boolean, _
            ByVal objNewData As System.Collections.Specialized.NameValueCollection) As Boolean
            With m_objrulesEstateCaiwu
                doShenhe_ES_SSSF = .doShenhe_ES_SSSF(strErrMsg, strUserId, strPassword, blnTongguo, objNewData)
            End With
        End Function

        '----------------------------------------------------------------
        ' 计算指定确认书的备用金数据：甲方、乙方
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     strQRSH              ：确认书号
        '     dblBYJ_JF            ：甲方备用金
        '     dblBYJ_YF            ：乙方备用金
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        '----------------------------------------------------------------
        Public Function getHetongBeiyongjin( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strQRSH As String, _
            ByRef dblBYJ_JF As Double, _
            ByRef dblBYJ_YF As Double) As Boolean
            With m_objrulesEstateCaiwu
                getHetongBeiyongjin = .getHetongBeiyongjin(strErrMsg, strUserId, strPassword, strQRSH, dblBYJ_JF, dblBYJ_YF)
            End With
        End Function

        '----------------------------------------------------------------
        ' 计算指定确认书、指定收付标志、指定税费的财务实收数据：甲方、乙方
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     strQRSH              ：确认书号
        '     strSFBZ              ：收、付
        '     strSFDM              ：税费代码
        '     dblBYJ_JF            ：甲方备用金
        '     dblBYJ_YF            ：乙方备用金
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        '----------------------------------------------------------------
        Public Function getHetongBeiyongjin( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strQRSH As String, _
            ByVal strSFBZ As String, _
            ByVal strSFDM As String, _
            ByRef dblBYJ_JF As Double, _
            ByRef dblBYJ_YF As Double) As Boolean
            With m_objrulesEstateCaiwu
                getHetongBeiyongjin = .getHetongBeiyongjin(strErrMsg, strUserId, strPassword, strQRSH, strSFBZ, strSFDM, dblBYJ_JF, dblBYJ_YF)
            End With
        End Function

        '----------------------------------------------------------------
        ' 计算指定确认书、指定收付标志、不是指定税费的财务实收数据：甲方、乙方
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     strQRSH              ：确认书号
        '     strSFBZ              ：收、付
        '     strSFDMList          ：要剔除的税费代码
        '     blnUnused            ：接口重载
        '     dblBYJ_JF            ：甲方备用金
        '     dblBYJ_YF            ：乙方备用金
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        '----------------------------------------------------------------
        Public Function getHetongBeiyongjin( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strQRSH As String, _
            ByVal strSFBZ As String, _
            ByVal strSFDMList As String, _
            ByVal blnUnused As Boolean, _
            ByRef dblBYJ_JF As Double, _
            ByRef dblBYJ_YF As Double) As Boolean
            With m_objrulesEstateCaiwu
                getHetongBeiyongjin = .getHetongBeiyongjin(strErrMsg, strUserId, strPassword, strQRSH, strSFBZ, strSFDMList, blnUnused, dblBYJ_JF, dblBYJ_YF)
            End With
        End Function









        '----------------------------------------------------------------
        ' 计算新的[票据批号]
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     strFGFH              ：发给分行
        '     strPJPH              ：发放批次(返回)
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        ' 更改描述
        '     zengxianglin 2008-11-18 创建
        '----------------------------------------------------------------
        Public Function getNewPjph( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strFGFH As String, _
            ByRef strPJPH As String) As Boolean
            With m_objrulesEstateCaiwu
                getNewPjph = .getNewPjph(strErrMsg, strUserId, strPassword, strFGFH, strPJPH)
            End With
        End Function

        '----------------------------------------------------------------
        ' 判断给定的票据是否为[已使用]？
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     strWYBS              ：唯一标识
        '     blnIS                ：返回是否
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        ' 更改记录
        '     zengxianglin 2009-05-17 创建
        '----------------------------------------------------------------
        Public Function isPiaojuUsed( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWYBS As String, _
            ByRef blnIS As Boolean) As Boolean
            With m_objrulesEstateCaiwu
                isPiaojuUsed = .isPiaojuUsed(strErrMsg, strUserId, strPassword, strWYBS, blnIS)
            End With
        End Function

        '----------------------------------------------------------------
        ' 判断给定的票据是否为[已作废]？
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     strWYBS              ：唯一标识
        '     blnIS                ：返回是否
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        ' 更改记录
        '     zengxianglin 2009-05-17 创建
        '----------------------------------------------------------------
        Public Function isPiaojuZuofei( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWYBS As String, _
            ByRef blnIS As Boolean) As Boolean
            With m_objrulesEstateCaiwu
                isPiaojuZuofei = .isPiaojuZuofei(strErrMsg, strUserId, strPassword, strWYBS, blnIS)
            End With
        End Function

        '----------------------------------------------------------------
        ' 票据核销
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     strWYBS              ：要标记的票据的“唯一标识”
        '     strHXRY              ：核销人员
        '     strHXRQ              ：核销日期
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        ' 更改记录
        '     zengxianglin 2009-05-17 创建
        '----------------------------------------------------------------
        Public Function doPiaoju_Hexiao( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWYBS As String, _
            ByVal strHXRY As String, _
            ByVal strHXRQ As String) As Boolean
            With m_objrulesEstateCaiwu
                doPiaoju_Hexiao = .doPiaoju_Hexiao(strErrMsg, strUserId, strPassword, strWYBS, strHXRY, strHXRQ)
            End With
        End Function

        '----------------------------------------------------------------
        ' 将指定款项按指定方式结转处理
        ' 不同客户、收->收方向时的结转处理
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     objNewData           ：相关参数
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        ' 更改
        '     zengxianglin 2010-12-30 创建
        '----------------------------------------------------------------
        Public Function doJiezhuan_ES_SSSF_TFX( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objNewData As System.Collections.Specialized.NameValueCollection) As Boolean
            With m_objrulesEstateCaiwu
                doJiezhuan_ES_SSSF_TFX = .doJiezhuan_ES_SSSF_TFX(strErrMsg, strUserId, strPassword, objNewData)
            End With
        End Function

        '----------------------------------------------------------------
        ' 将指定款项按指定方式结转处理
        ' 不同客户、收->付方向时的结转处理
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     objNewData           ：相关参数
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        ' 更改
        '     zengxianglin 2010-12-30 创建
        '----------------------------------------------------------------
        Public Function doJiezhuan_ES_SSSF_BTFX( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objNewData As System.Collections.Specialized.NameValueCollection) As Boolean
            With m_objrulesEstateCaiwu
                doJiezhuan_ES_SSSF_BTFX = .doJiezhuan_ES_SSSF_BTFX(strErrMsg, strUserId, strPassword, objNewData)
            End With
        End Function

        '----------------------------------------------------------------
        ' 计算指定[确认书号][税费代码][收付对象]的余额
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     strQRSH              ：确认书号
        '     strSFDM              ：税费代码
        '     strSFDX              ：收付对象
        '     dblBalance           ：余额
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        ' 更改
        '     zengxianglin 2010-12-30 创建
        '----------------------------------------------------------------
        Public Function getBalance( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strQRSH As String, _
            ByVal strSFDM As String, _
            ByVal strSFDX As String, _
            ByRef dblBalance As Double) As Boolean
            With m_objrulesEstateCaiwu
                getBalance = .getBalance(strErrMsg, strUserId, strPassword, strQRSH, strSFDM, strSFDX, dblBalance)
            End With
        End Function

    End Class

End Namespace
