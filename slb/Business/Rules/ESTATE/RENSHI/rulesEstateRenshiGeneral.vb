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
Imports System.Text.RegularExpressions
Imports Microsoft.VisualBasic

Imports Josco.JsKernal.SystemFramework
Imports Josco.JsKernal.Common
Imports Josco.JsKernal.Common.Data
Imports Josco.JsKernal.DataAccess

Namespace Josco.JSOA.BusinessRules

    '----------------------------------------------------------------
    ' 命名空间：Josco.JSOA.BusinessRules
    ' 类名    ：rulesEstateRenshiGeneral
    '
    ' 功能描述： 
    '   　提供对通用人事管理处理的业务规则
    '----------------------------------------------------------------
    Public Class rulesEstateRenshiGeneral
        Implements System.IDisposable

        Private m_objdacEstateRenshiGeneral As Josco.JSOA.DataAccess.dacEstateRenshiGeneral

        '----------------------------------------------------------------
        ' 构造函数
        '----------------------------------------------------------------
        Public Sub New()
            MyBase.New()
            m_objdacEstateRenshiGeneral = New Josco.JSOA.DataAccess.dacEstateRenshiGeneral
        End Sub

        '----------------------------------------------------------------
        ' 安全释放本身资源
        '----------------------------------------------------------------
        Public Shared Sub SafeRelease(ByRef obj As Josco.JSOA.BusinessRules.rulesEstateRenshiGeneral)
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
            If Not (m_objdacEstateRenshiGeneral Is Nothing) Then
                m_objdacEstateRenshiGeneral.Dispose()
                m_objdacEstateRenshiGeneral = Nothing
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
            With Me.m_objdacEstateRenshiGeneral
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
            With Me.m_objdacEstateRenshiGeneral
                doExportToExcel = .doExportToExcel(strErrMsg, objDataSet, strExcelFile, strColorFieldName, objColors, strMacroName, strMacroValue, strDateFormat)
            End With
        End Function

        '----------------------------------------------------------------
        ' 将strSrcFile中的strSrcSheet复制到strDesFile中的strDesSheet
        '     strErrMsg              ：如果错误，则返回错误信息
        '     strSrcFile             ：源文件的完整路径
        '     strSrcSheet            ：源文件的sheet名
        '     strDesFile             ：目标文件的完整路径
        '     strDesSheet            ：目标文件的sheet名
        ' 返回
        '     True                   ：成功
        '     False                  ：失败
        ' 更改描述
        '     zengxianglin 2009-05-18 创建
        '----------------------------------------------------------------
        Public Function doExcelAddCopy( _
            ByRef strErrMsg As String, _
            ByVal strSrcFile As String, _
            ByVal strSrcSheet As String, _
            ByVal strDesFile As String, _
            ByVal strDesSheet As String) As Boolean
            With Me.m_objdacEstateRenshiGeneral
                doExcelAddCopy = .doExcelAddCopy(strErrMsg, strSrcFile, strSrcSheet, strDesFile, strDesSheet)
            End With
        End Function

        '----------------------------------------------------------------
        ' 删除strSrcFile中的strSrcSheet
        '     strErrMsg              ：如果错误，则返回错误信息
        '     strSrcFile             ：源文件的完整路径
        '     strSrcSheet            ：源文件的sheet名
        ' 返回
        '     True                   ：成功
        '     False                  ：失败
        ' 更改描述
        '     zengxianglin 2009-05-18 创建
        '----------------------------------------------------------------
        Public Function doExcelSheetDelete( _
            ByRef strErrMsg As String, _
            ByVal strSrcFile As String, _
            ByVal strSrcSheet As String) As Boolean
            With Me.m_objdacEstateRenshiGeneral
                doExcelSheetDelete = .doExcelSheetDelete(strErrMsg, strSrcFile, strSrcSheet)
            End With
        End Function












        '----------------------------------------------------------------
        ' 获取“人事_B_技术职称”的SQL语句(以“职称代码”升序排序)
        ' 返回
        '                          ：SQL
        '----------------------------------------------------------------
        Public Function getTableSQL_JishuZhicheng() As String
            With m_objdacEstateRenshiGeneral
                getTableSQL_JishuZhicheng = .getTableSQL_JishuZhicheng()
            End With
        End Function

        '----------------------------------------------------------------
        ' 根据“职称代码”获取“职称名称”
        '     strErrMsg                 ：如果错误，则返回错误信息
        '     strUserId                 ：用户标识
        '     strPassword               ：用户密码
        '     strZcdm                   ：职称代码
        '     strZcmc                   ：职称名称(返回)
        ' 返回
        '     True                      ：成功
        '     False                     ：失败
        '----------------------------------------------------------------
        Public Function getZcmc( _
            ByVal strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strZcdm As String, _
            ByRef strZcmc As String) As Boolean
            With m_objdacEstateRenshiGeneral
                getZcmc = .getZcmc(strErrMsg, strUserId, strPassword, strZcdm, strZcmc)
            End With
        End Function

        '----------------------------------------------------------------
        ' 根据“职称名称”获取“职称代码”
        '     strErrMsg                 ：如果错误，则返回错误信息
        '     strUserId                 ：用户标识
        '     strPassword               ：用户密码
        '     strZcmc                   ：职称名称
        '     strZcdm                   ：职称代码(返回)
        ' 返回
        '     True                      ：成功
        '     False                     ：失败
        '----------------------------------------------------------------
        Public Function getZcdm( _
            ByVal strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strZcmc As String, _
            ByRef strZcdm As String) As Boolean
            With m_objdacEstateRenshiGeneral
                getZcdm = .getZcdm(strErrMsg, strUserId, strPassword, strZcmc, strZcdm)
            End With
        End Function

        '----------------------------------------------------------------
        ' 获取“人事_B_技术职称”完全数据的数据集(以“职称代码”升序排序)
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     strWhere                   ：搜索字符串
        '     objestateRenshiGeneralData ：信息数据集
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
        '----------------------------------------------------------------
        Public Function getDataSet_JishuZhicheng( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWhere As String, _
            ByRef objestateRenshiGeneralData As Josco.JSOA.Common.Data.estateRenshiGeneralData) As Boolean
            With m_objdacEstateRenshiGeneral
                getDataSet_JishuZhicheng = .getDataSet_JishuZhicheng(strErrMsg, strUserId, strPassword, strWhere, objestateRenshiGeneralData)
            End With
        End Function

        '----------------------------------------------------------------
        ' 保存“人事_B_技术职称”的数据
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
        Public Function doSaveData_JishuZhicheng( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objOldData As System.Data.DataRow, _
            ByVal objNewData As System.Collections.Specialized.NameValueCollection, _
            ByVal objenumEditType As Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType) As Boolean
            With m_objdacEstateRenshiGeneral
                doSaveData_JishuZhicheng = .doSaveData_JishuZhicheng(strErrMsg, strUserId, strPassword, objOldData, objNewData, objenumEditType)
            End With
        End Function

        '----------------------------------------------------------------
        ' 删除“人事_B_技术职称”的数据
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     objOldData           ：旧数据
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        '----------------------------------------------------------------
        Public Function doDeleteData_JishuZhicheng( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objOldData As System.Data.DataRow) As Boolean
            With m_objdacEstateRenshiGeneral
                doDeleteData_JishuZhicheng = .doDeleteData_JishuZhicheng(strErrMsg, strUserId, strPassword, objOldData)
            End With
        End Function











        '----------------------------------------------------------------
        ' 获取“人事_B_学历划分”的SQL语句(以“学历代码”升序排序)
        ' 返回
        '                          ：SQL
        '----------------------------------------------------------------
        Public Function getTableSQL_XueliHuafen() As String
            With m_objdacEstateRenshiGeneral
                getTableSQL_XueliHuafen = .getTableSQL_XueliHuafen()
            End With
        End Function

        '----------------------------------------------------------------
        ' 根据“学历代码”获取“学历名称”
        '     strErrMsg                 ：如果错误，则返回错误信息
        '     strUserId                 ：用户标识
        '     strPassword               ：用户密码
        '     strXldm                   ：学历代码
        '     strXlmc                   ：学历名称(返回)
        ' 返回
        '     True                      ：成功
        '     False                     ：失败
        '----------------------------------------------------------------
        Public Function getXlmc( _
            ByVal strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strXldm As String, _
            ByRef strXlmc As String) As Boolean
            With m_objdacEstateRenshiGeneral
                getXlmc = .getXlmc(strErrMsg, strUserId, strPassword, strXldm, strXlmc)
            End With
        End Function

        '----------------------------------------------------------------
        ' 根据“学历名称”获取“学历代码”
        '     strErrMsg                 ：如果错误，则返回错误信息
        '     strUserId                 ：用户标识
        '     strPassword               ：用户密码
        '     strXlmc                   ：学历名称
        '     strXldm                   ：学历代码(返回)
        ' 返回
        '     True                      ：成功
        '     False                     ：失败
        '----------------------------------------------------------------
        Public Function getXldm( _
            ByVal strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strXlmc As String, _
            ByRef strXldm As String) As Boolean
            With m_objdacEstateRenshiGeneral
                getXldm = .getXldm(strErrMsg, strUserId, strPassword, strXlmc, strXldm)
            End With
        End Function

        '----------------------------------------------------------------
        ' 获取“人事_B_学历划分”完全数据的数据集(以“学历代码”升序排序)
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     strWhere                   ：搜索字符串
        '     objestateRenshiGeneralData ：信息数据集
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
        '----------------------------------------------------------------
        Public Function getDataSet_XueliHuafen( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWhere As String, _
            ByRef objestateRenshiGeneralData As Josco.JSOA.Common.Data.estateRenshiGeneralData) As Boolean
            With m_objdacEstateRenshiGeneral
                getDataSet_XueliHuafen = .getDataSet_XueliHuafen(strErrMsg, strUserId, strPassword, strWhere, objestateRenshiGeneralData)
            End With
        End Function

        '----------------------------------------------------------------
        ' 保存“人事_B_学历划分”的数据
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
        Public Function doSaveData_XueliHuafen( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objOldData As System.Data.DataRow, _
            ByVal objNewData As System.Collections.Specialized.NameValueCollection, _
            ByVal objenumEditType As Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType) As Boolean
            With m_objdacEstateRenshiGeneral
                doSaveData_XueliHuafen = .doSaveData_XueliHuafen(strErrMsg, strUserId, strPassword, objOldData, objNewData, objenumEditType)
            End With
        End Function

        '----------------------------------------------------------------
        ' 删除“人事_B_学历划分”的数据
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     objOldData           ：旧数据
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        '----------------------------------------------------------------
        Public Function doDeleteData_XueliHuafen( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objOldData As System.Data.DataRow) As Boolean
            With m_objdacEstateRenshiGeneral
                doDeleteData_XueliHuafen = .doDeleteData_XueliHuafen(strErrMsg, strUserId, strPassword, objOldData)
            End With
        End Function










        '----------------------------------------------------------------
        ' 获取“人事_B_学位划分”的SQL语句(以“学位代码”升序排序)
        ' 返回
        '                          ：SQL
        '----------------------------------------------------------------
        Public Function getTableSQL_XueweiHuafen() As String
            With m_objdacEstateRenshiGeneral
                getTableSQL_XueweiHuafen = .getTableSQL_XueweiHuafen()
            End With
        End Function

        '----------------------------------------------------------------
        ' 根据“学位代码”获取“学位名称”
        '     strErrMsg                 ：如果错误，则返回错误信息
        '     strUserId                 ：用户标识
        '     strPassword               ：用户密码
        '     strXwdm                   ：学位代码
        '     strXwmc                   ：学位名称(返回)
        ' 返回
        '     True                      ：成功
        '     False                     ：失败
        '----------------------------------------------------------------
        Public Function getXwmc( _
            ByVal strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strXwdm As String, _
            ByRef strXwmc As String) As Boolean
            With m_objdacEstateRenshiGeneral
                getXwmc = .getXwmc(strErrMsg, strUserId, strPassword, strXwdm, strXwmc)
            End With
        End Function

        '----------------------------------------------------------------
        ' 根据“学位名称”获取“学位代码”
        '     strErrMsg                 ：如果错误，则返回错误信息
        '     strUserId                 ：用户标识
        '     strPassword               ：用户密码
        '     strXwmc                   ：学位名称
        '     strXwdm                   ：学位代码(返回)
        ' 返回
        '     True                      ：成功
        '     False                     ：失败
        '----------------------------------------------------------------
        Public Function getXwdm( _
            ByVal strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strXwmc As String, _
            ByRef strXwdm As String) As Boolean
            With m_objdacEstateRenshiGeneral
                getXwdm = .getXwdm(strErrMsg, strUserId, strPassword, strXwmc, strXwdm)
            End With
        End Function

        '----------------------------------------------------------------
        ' 获取“人事_B_学位划分”完全数据的数据集(以“学位代码”升序排序)
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     strWhere                   ：搜索字符串
        '     objestateRenshiGeneralData ：信息数据集
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
        '----------------------------------------------------------------
        Public Function getDataSet_XueweiHuafen( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWhere As String, _
            ByRef objestateRenshiGeneralData As Josco.JSOA.Common.Data.estateRenshiGeneralData) As Boolean
            With m_objdacEstateRenshiGeneral
                getDataSet_XueweiHuafen = .getDataSet_XueweiHuafen(strErrMsg, strUserId, strPassword, strWhere, objestateRenshiGeneralData)
            End With
        End Function

        '----------------------------------------------------------------
        ' 保存“人事_B_学位划分”的数据
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
        Public Function doSaveData_XueweiHuafen( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objOldData As System.Data.DataRow, _
            ByVal objNewData As System.Collections.Specialized.NameValueCollection, _
            ByVal objenumEditType As Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType) As Boolean
            With m_objdacEstateRenshiGeneral
                doSaveData_XueweiHuafen = .doSaveData_XueweiHuafen(strErrMsg, strUserId, strPassword, objOldData, objNewData, objenumEditType)
            End With
        End Function

        '----------------------------------------------------------------
        ' 删除“人事_B_学位划分”的数据
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     objOldData           ：旧数据
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        '----------------------------------------------------------------
        Public Function doDeleteData_XueweiHuafen( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objOldData As System.Data.DataRow) As Boolean
            With m_objdacEstateRenshiGeneral
                doDeleteData_XueweiHuafen = .doDeleteData_XueweiHuafen(strErrMsg, strUserId, strPassword, objOldData)
            End With
        End Function











        '----------------------------------------------------------------
        ' 获取“人事_B_政治面貌”的SQL语句(以“面貌代码”升序排序)
        ' 返回
        '                          ：SQL
        '----------------------------------------------------------------
        Public Function getTableSQL_ZhengzhiMianmao() As String
            With m_objdacEstateRenshiGeneral
                getTableSQL_ZhengzhiMianmao = .getTableSQL_ZhengzhiMianmao()
            End With
        End Function

        '----------------------------------------------------------------
        ' 根据“面貌代码”获取“面貌名称”
        '     strErrMsg                 ：如果错误，则返回错误信息
        '     strUserId                 ：用户标识
        '     strPassword               ：用户密码
        '     strMmdm                   ：面貌代码
        '     strMmmc                   ：面貌名称(返回)
        ' 返回
        '     True                      ：成功
        '     False                     ：失败
        '----------------------------------------------------------------
        Public Function getMmmc( _
            ByVal strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strMmdm As String, _
            ByRef strMmmc As String) As Boolean
            With m_objdacEstateRenshiGeneral
                getMmmc = .getMmmc(strErrMsg, strUserId, strPassword, strMmdm, strMmmc)
            End With
        End Function

        '----------------------------------------------------------------
        ' 根据“面貌名称”获取“面貌代码”
        '     strErrMsg                 ：如果错误，则返回错误信息
        '     strUserId                 ：用户标识
        '     strPassword               ：用户密码
        '     strMmmc                   ：面貌名称
        '     strMmdm                   ：面貌代码(返回)
        ' 返回
        '     True                      ：成功
        '     False                     ：失败
        '----------------------------------------------------------------
        Public Function getMmdm( _
            ByVal strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strMmmc As String, _
            ByRef strMmdm As String) As Boolean
            With m_objdacEstateRenshiGeneral
                getMmdm = .getMmdm(strErrMsg, strUserId, strPassword, strMmmc, strMmdm)
            End With
        End Function

        '----------------------------------------------------------------
        ' 获取“人事_B_政治面貌”完全数据的数据集(以“面貌代码”升序排序)
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     strWhere                   ：搜索字符串
        '     objestateRenshiGeneralData ：信息数据集
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
        '----------------------------------------------------------------
        Public Function getDataSet_ZhengzhiMianmao( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWhere As String, _
            ByRef objestateRenshiGeneralData As Josco.JSOA.Common.Data.estateRenshiGeneralData) As Boolean
            With m_objdacEstateRenshiGeneral
                getDataSet_ZhengzhiMianmao = .getDataSet_ZhengzhiMianmao(strErrMsg, strUserId, strPassword, strWhere, objestateRenshiGeneralData)
            End With
        End Function

        '----------------------------------------------------------------
        ' 保存“人事_B_政治面貌”的数据
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
        Public Function doSaveData_ZhengzhiMianmao( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objOldData As System.Data.DataRow, _
            ByVal objNewData As System.Collections.Specialized.NameValueCollection, _
            ByVal objenumEditType As Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType) As Boolean
            With m_objdacEstateRenshiGeneral
                doSaveData_ZhengzhiMianmao = .doSaveData_ZhengzhiMianmao(strErrMsg, strUserId, strPassword, objOldData, objNewData, objenumEditType)
            End With
        End Function

        '----------------------------------------------------------------
        ' 删除“人事_B_政治面貌”的数据
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     objOldData           ：旧数据
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        '----------------------------------------------------------------
        Public Function doDeleteData_ZhengzhiMianmao( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objOldData As System.Data.DataRow) As Boolean
            With m_objdacEstateRenshiGeneral
                doDeleteData_ZhengzhiMianmao = .doDeleteData_ZhengzhiMianmao(strErrMsg, strUserId, strPassword, objOldData)
            End With
        End Function










        '----------------------------------------------------------------
        ' 获取“人事_B_执业资格”的SQL语句(以“资格代码”升序排序)
        ' 返回
        '                          ：SQL
        '----------------------------------------------------------------
        Public Function getTableSQL_ZhiyeZige() As String
            With m_objdacEstateRenshiGeneral
                getTableSQL_ZhiyeZige = .getTableSQL_ZhiyeZige()
            End With
        End Function

        '----------------------------------------------------------------
        ' 根据“资格代码”获取“资格名称”
        '     strErrMsg                 ：如果错误，则返回错误信息
        '     strUserId                 ：用户标识
        '     strPassword               ：用户密码
        '     strZgdm                   ：资格代码
        '     strZgmc                   ：资格名称(返回)
        ' 返回
        '     True                      ：成功
        '     False                     ：失败
        '----------------------------------------------------------------
        Public Function getZgmc( _
            ByVal strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strZgdm As String, _
            ByRef strZgmc As String) As Boolean
            With m_objdacEstateRenshiGeneral
                getZgmc = .getZgmc(strErrMsg, strUserId, strPassword, strZgdm, strZgmc)
            End With
        End Function

        '----------------------------------------------------------------
        ' 根据“资格名称”获取“资格代码”
        '     strErrMsg                 ：如果错误，则返回错误信息
        '     strUserId                 ：用户标识
        '     strPassword               ：用户密码
        '     strZgmc                   ：资格名称
        '     strZgdm                   ：资格代码(返回)
        ' 返回
        '     True                      ：成功
        '     False                     ：失败
        '----------------------------------------------------------------
        Public Function getZgdm( _
            ByVal strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strZgmc As String, _
            ByRef strZgdm As String) As Boolean
            With m_objdacEstateRenshiGeneral
                getZgdm = .getZgdm(strErrMsg, strUserId, strPassword, strZgmc, strZgdm)
            End With
        End Function

        '----------------------------------------------------------------
        ' 获取“人事_B_执业资格”完全数据的数据集(以“资格代码”升序排序)
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     strWhere                   ：搜索字符串
        '     objestateRenshiGeneralData ：信息数据集
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
        '----------------------------------------------------------------
        Public Function getDataSet_ZhiyeZige( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWhere As String, _
            ByRef objestateRenshiGeneralData As Josco.JSOA.Common.Data.estateRenshiGeneralData) As Boolean
            With m_objdacEstateRenshiGeneral
                getDataSet_ZhiyeZige = .getDataSet_ZhiyeZige(strErrMsg, strUserId, strPassword, strWhere, objestateRenshiGeneralData)
            End With
        End Function

        '----------------------------------------------------------------
        ' 保存“人事_B_执业资格”的数据
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
        Public Function doSaveData_ZhiyeZige( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objOldData As System.Data.DataRow, _
            ByVal objNewData As System.Collections.Specialized.NameValueCollection, _
            ByVal objenumEditType As Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType) As Boolean
            With m_objdacEstateRenshiGeneral
                doSaveData_ZhiyeZige = .doSaveData_ZhiyeZige(strErrMsg, strUserId, strPassword, objOldData, objNewData, objenumEditType)
            End With
        End Function

        '----------------------------------------------------------------
        ' 删除“人事_B_执业资格”的数据
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     objOldData           ：旧数据
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        '----------------------------------------------------------------
        Public Function doDeleteData_ZhiyeZige( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objOldData As System.Data.DataRow) As Boolean
            With m_objdacEstateRenshiGeneral
                doDeleteData_ZhiyeZige = .doDeleteData_ZhiyeZige(strErrMsg, strUserId, strPassword, objOldData)
            End With
        End Function










        '----------------------------------------------------------------
        ' 获取“人事_B_变动原因”的SQL语句(以“原因代码”升序排序)
        ' 返回
        '                          ：SQL
        '----------------------------------------------------------------
        Public Function getTableSQL_BiandongYuanyin() As String
            With m_objdacEstateRenshiGeneral
                getTableSQL_BiandongYuanyin = .getTableSQL_BiandongYuanyin()
            End With
        End Function

        '----------------------------------------------------------------
        ' 根据“原因代码”获取“原因名称”
        '     strErrMsg                 ：如果错误，则返回错误信息
        '     strUserId                 ：用户标识
        '     strPassword               ：用户密码
        '     strYydm                   ：原因代码
        '     strYymc                   ：原因名称(返回)
        ' 返回
        '     True                      ：成功
        '     False                     ：失败
        '----------------------------------------------------------------
        Public Function getYymc( _
            ByVal strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strYydm As String, _
            ByRef strYymc As String) As Boolean
            With m_objdacEstateRenshiGeneral
                getYymc = .getYymc(strErrMsg, strUserId, strPassword, strYydm, strYymc)
            End With
        End Function

        '----------------------------------------------------------------
        ' 根据“原因名称”获取“原因代码”
        '     strErrMsg                 ：如果错误，则返回错误信息
        '     strUserId                 ：用户标识
        '     strPassword               ：用户密码
        '     strYymc                   ：原因名称
        '     strYydm                   ：原因代码(返回)
        ' 返回
        '     True                      ：成功
        '     False                     ：失败
        '----------------------------------------------------------------
        Public Function getYydm( _
            ByVal strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strYymc As String, _
            ByRef strYydm As String) As Boolean
            With m_objdacEstateRenshiGeneral
                getYydm = .getYydm(strErrMsg, strUserId, strPassword, strYymc, strYydm)
            End With
        End Function

        '----------------------------------------------------------------
        ' 获取“人事_B_变动原因”完全数据的数据集(以“原因代码”升序排序)
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     strWhere                   ：搜索字符串
        '     objestateRenshiGeneralData ：信息数据集
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
        '----------------------------------------------------------------
        Public Function getDataSet_BiandongYuanyin( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWhere As String, _
            ByRef objestateRenshiGeneralData As Josco.JSOA.Common.Data.estateRenshiGeneralData) As Boolean
            With m_objdacEstateRenshiGeneral
                getDataSet_BiandongYuanyin = .getDataSet_BiandongYuanyin(strErrMsg, strUserId, strPassword, strWhere, objestateRenshiGeneralData)
            End With
        End Function

        '----------------------------------------------------------------
        ' 保存“人事_B_变动原因”的数据
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
        Public Function doSaveData_BiandongYuanyin( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objOldData As System.Data.DataRow, _
            ByVal objNewData As System.Collections.Specialized.NameValueCollection, _
            ByVal objenumEditType As Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType) As Boolean
            With m_objdacEstateRenshiGeneral
                doSaveData_BiandongYuanyin = .doSaveData_BiandongYuanyin(strErrMsg, strUserId, strPassword, objOldData, objNewData, objenumEditType)
            End With
        End Function

        '----------------------------------------------------------------
        ' 删除“人事_B_变动原因”的数据
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     objOldData           ：旧数据
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        '----------------------------------------------------------------
        Public Function doDeleteData_BiandongYuanyin( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objOldData As System.Data.DataRow) As Boolean
            With m_objdacEstateRenshiGeneral
                doDeleteData_BiandongYuanyin = .doDeleteData_BiandongYuanyin(strErrMsg, strUserId, strPassword, objOldData)
            End With
        End Function










        '----------------------------------------------------------------
        ' 获取“人事_B_职工属性”的SQL语句(以“属性代码”升序排序)
        ' 返回
        '                          ：SQL
        '----------------------------------------------------------------
        Public Function getTableSQL_ZhigongShuxing() As String
            With m_objdacEstateRenshiGeneral
                getTableSQL_ZhigongShuxing = .getTableSQL_ZhigongShuxing()
            End With
        End Function

        '----------------------------------------------------------------
        ' 根据“属性代码”获取“属性名称”
        '     strErrMsg                 ：如果错误，则返回错误信息
        '     strUserId                 ：用户标识
        '     strPassword               ：用户密码
        '     strSxdm                   ：属性代码
        '     strSxmc                   ：属性名称(返回)
        ' 返回
        '     True                      ：成功
        '     False                     ：失败
        '----------------------------------------------------------------
        Public Function getSxmc( _
            ByVal strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strSxdm As String, _
            ByRef strSxmc As String) As Boolean
            With m_objdacEstateRenshiGeneral
                getSxmc = .getSxmc(strErrMsg, strUserId, strPassword, strSxdm, strSxmc)
            End With
        End Function

        '----------------------------------------------------------------
        ' 根据“属性名称”获取“属性代码”
        '     strErrMsg                 ：如果错误，则返回错误信息
        '     strUserId                 ：用户标识
        '     strPassword               ：用户密码
        '     strSxmc                   ：属性名称
        '     strSxdm                   ：属性代码(返回)
        ' 返回
        '     True                      ：成功
        '     False                     ：失败
        '----------------------------------------------------------------
        Public Function getSxdm( _
            ByVal strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strSxmc As String, _
            ByRef strSxdm As String) As Boolean
            With m_objdacEstateRenshiGeneral
                getSxdm = .getSxdm(strErrMsg, strUserId, strPassword, strSxmc, strSxdm)
            End With
        End Function

        '----------------------------------------------------------------
        ' 获取“人事_B_职工属性”完全数据的数据集(以“属性代码”升序排序)
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     strWhere                   ：搜索字符串
        '     objestateRenshiGeneralData ：信息数据集
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
        '----------------------------------------------------------------
        Public Function getDataSet_ZhigongShuxing( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWhere As String, _
            ByRef objestateRenshiGeneralData As Josco.JSOA.Common.Data.estateRenshiGeneralData) As Boolean
            With m_objdacEstateRenshiGeneral
                getDataSet_ZhigongShuxing = .getDataSet_ZhigongShuxing(strErrMsg, strUserId, strPassword, strWhere, objestateRenshiGeneralData)
            End With
        End Function

        '----------------------------------------------------------------
        ' 保存“人事_B_职工属性”的数据
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
        Public Function doSaveData_ZhigongShuxing( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objOldData As System.Data.DataRow, _
            ByVal objNewData As System.Collections.Specialized.NameValueCollection, _
            ByVal objenumEditType As Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType) As Boolean
            With m_objdacEstateRenshiGeneral
                doSaveData_ZhigongShuxing = .doSaveData_ZhigongShuxing(strErrMsg, strUserId, strPassword, objOldData, objNewData, objenumEditType)
            End With
        End Function

        '----------------------------------------------------------------
        ' 删除“人事_B_职工属性”的数据
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     objOldData           ：旧数据
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        '----------------------------------------------------------------
        Public Function doDeleteData_ZhigongShuxing( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objOldData As System.Data.DataRow) As Boolean
            With m_objdacEstateRenshiGeneral
                doDeleteData_ZhigongShuxing = .doDeleteData_ZhigongShuxing(strErrMsg, strUserId, strPassword, objOldData)
            End With
        End Function










        '----------------------------------------------------------------
        ' 获取“人事_B_人事卡片”完全数据的数据集(以“人员代码”升序排序)
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     strWhere                   ：搜索字符串
        '     objestateRenshiGeneralData ：信息数据集
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
        '----------------------------------------------------------------
        Public Function getDataSet_RSKP( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWhere As String, _
            ByRef objestateRenshiGeneralData As Josco.JSOA.Common.Data.estateRenshiGeneralData) As Boolean
            With m_objdacEstateRenshiGeneral
                getDataSet_RSKP = .getDataSet_RSKP(strErrMsg, strUserId, strPassword, strWhere, objestateRenshiGeneralData)
            End With
        End Function

        '----------------------------------------------------------------
        ' 获取“人事_B_家庭成员”完全数据的数据集(以“血缘关系”升序排序)
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     strRYDM                    ：人员代码
        '     strWhere                   ：搜索字符串
        '     objestateRenshiGeneralData ：信息数据集
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
        '----------------------------------------------------------------
        Public Function getDataSet_RSKP_JTCY( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strRYDM As String, _
            ByVal strWhere As String, _
            ByRef objestateRenshiGeneralData As Josco.JSOA.Common.Data.estateRenshiGeneralData) As Boolean
            With m_objdacEstateRenshiGeneral
                getDataSet_RSKP_JTCY = .getDataSet_RSKP_JTCY(strErrMsg, strUserId, strPassword, strRYDM, strWhere, objestateRenshiGeneralData)
            End With
        End Function

        '----------------------------------------------------------------
        ' 获取“人事_B_学习经历”完全数据的数据集(以“开始年月”升序排序)
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     strRYDM                    ：人员代码
        '     strWhere                   ：搜索字符串
        '     objestateRenshiGeneralData ：信息数据集
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
        '----------------------------------------------------------------
        Public Function getDataSet_RSKP_XXJL( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strRYDM As String, _
            ByVal strWhere As String, _
            ByRef objestateRenshiGeneralData As Josco.JSOA.Common.Data.estateRenshiGeneralData) As Boolean
            With m_objdacEstateRenshiGeneral
                getDataSet_RSKP_XXJL = .getDataSet_RSKP_XXJL(strErrMsg, strUserId, strPassword, strRYDM, strWhere, objestateRenshiGeneralData)
            End With
        End Function

        '----------------------------------------------------------------
        ' 获取“人事_B_工作经历”完全数据的数据集(以“开始年月”升序排序)
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     strRYDM                    ：人员代码
        '     strWhere                   ：搜索字符串
        '     objestateRenshiGeneralData ：信息数据集
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
        '----------------------------------------------------------------
        Public Function getDataSet_RSKP_GZJL( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strRYDM As String, _
            ByVal strWhere As String, _
            ByRef objestateRenshiGeneralData As Josco.JSOA.Common.Data.estateRenshiGeneralData) As Boolean
            With m_objdacEstateRenshiGeneral
                getDataSet_RSKP_GZJL = .getDataSet_RSKP_GZJL(strErrMsg, strUserId, strPassword, strRYDM, strWhere, objestateRenshiGeneralData)
            End With
        End Function

        '----------------------------------------------------------------
        ' 保存“人事_B_人事卡片”数据记录(整个事务完成)
        '     strErrMsg              ：如果错误，则返回错误信息
        '     strUserId              ：用户标识
        '     strPassword            ：用户密码
        '     objNewData             ：记录新值(返回保存后的新值)
        '     objOldData             ：记录旧值
        '     objenumEditType        ：编辑类型
        '     strUploadFile          ：上载文件的WEB本地完全路径
        '     strAppRoot             ：应用根Http路径(不带/)
        '     strBasePath            ：从应用根到存放地的相对HTTP目录(开头不带/)
        '     objServer              ：服务器对象
        '     objDataSet_JTCY        ：家庭成员数据集
        '     objDataSet_XXJL        ：学习经历数据集
        '     objDataSet_GZJL        ：工作经历数据集
        ' 返回
        '     True                   ：成功
        '     False                  ：失败
        '----------------------------------------------------------------
        Public Function doSaveData_RSKP( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByRef objNewData As System.Collections.Specialized.NameValueCollection, _
            ByVal objOldData As System.Data.DataRow, _
            ByVal objenumEditType As Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType, _
            ByVal strUploadFile As String, _
            ByVal strAppRoot As String, _
            ByVal strBasePath As String, _
            ByVal objServer As System.Web.HttpServerUtility, _
            ByVal objDataSet_JTCY As Josco.JSOA.Common.Data.estateRenshiGeneralData, _
            ByVal objDataSet_XXJL As Josco.JSOA.Common.Data.estateRenshiGeneralData, _
            ByVal objDataSet_GZJL As Josco.JSOA.Common.Data.estateRenshiGeneralData) As Boolean
            With m_objdacEstateRenshiGeneral
                doSaveData_RSKP = .doSaveData_RSKP(strErrMsg, strUserId, strPassword, objNewData, objOldData, objenumEditType, strUploadFile, strAppRoot, strBasePath, objServer, objDataSet_JTCY, objDataSet_XXJL, objDataSet_GZJL)
            End With
        End Function

        '----------------------------------------------------------------
        ' 获取“人事_B_培训记录”完全数据的数据集(以“开始时间”升序排序)
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     strRYDM                    ：人员代码
        '     strWhere                   ：搜索字符串
        '     objestateRenshiGeneralData ：信息数据集
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
        '----------------------------------------------------------------
        Public Function getDataSet_RSKP_PXJL( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strRYDM As String, _
            ByVal strWhere As String, _
            ByRef objestateRenshiGeneralData As Josco.JSOA.Common.Data.estateRenshiGeneralData) As Boolean
            With m_objdacEstateRenshiGeneral
                getDataSet_RSKP_PXJL = .getDataSet_RSKP_PXJL(strErrMsg, strUserId, strPassword, strRYDM, strWhere, objestateRenshiGeneralData)
            End With
        End Function

        '----------------------------------------------------------------
        ' 获取“人事_B_人事异动”完全数据的数据集(以“开始时间”升序排序)
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     strRYDM                    ：人员代码
        '     strWhere                   ：搜索字符串
        '     objestateRenshiGeneralData ：信息数据集
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
        '----------------------------------------------------------------
        Public Function getDataSet_RSKP_YDJL( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strRYDM As String, _
            ByVal strWhere As String, _
            ByRef objestateRenshiGeneralData As Josco.JSOA.Common.Data.estateRenshiGeneralData) As Boolean
            With m_objdacEstateRenshiGeneral
                getDataSet_RSKP_YDJL = .getDataSet_RSKP_YDJL(strErrMsg, strUserId, strPassword, strRYDM, strWhere, objestateRenshiGeneralData)
            End With
        End Function

        '----------------------------------------------------------------
        ' 获取“人事_B_劳动合同”完全数据的数据集(以“开始时间”升序排序)
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     strRYDM                    ：人员代码
        '     strWhere                   ：搜索字符串
        '     objestateRenshiGeneralData ：信息数据集
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
        '----------------------------------------------------------------
        Public Function getDataSet_RSKP_LDHT( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strRYDM As String, _
            ByVal strWhere As String, _
            ByRef objestateRenshiGeneralData As Josco.JSOA.Common.Data.estateRenshiGeneralData) As Boolean
            With m_objdacEstateRenshiGeneral
                getDataSet_RSKP_LDHT = .getDataSet_RSKP_LDHT(strErrMsg, strUserId, strPassword, strRYDM, strWhere, objestateRenshiGeneralData)
            End With
        End Function

        '----------------------------------------------------------------
        ' 保存“人事_B_培训记录”的数据
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
        Public Function doSaveData_RSKP_PXJL( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objOldData As System.Data.DataRow, _
            ByRef objNewData As System.Collections.Specialized.NameValueCollection, _
            ByVal objenumEditType As Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType) As Boolean
            With m_objdacEstateRenshiGeneral
                doSaveData_RSKP_PXJL = .doSaveData_RSKP_PXJL(strErrMsg, strUserId, strPassword, objOldData, objNewData, objenumEditType)
            End With
        End Function

        '----------------------------------------------------------------
        ' 删除“人事_B_培训记录”的数据
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     strWYBS              ：唯一标识
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        '----------------------------------------------------------------
        Public Function doDeleteData_RSKP_PXJL( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWYBS As String) As Boolean
            With m_objdacEstateRenshiGeneral
                doDeleteData_RSKP_PXJL = .doDeleteData_RSKP_PXJL(strErrMsg, strUserId, strPassword, strWYBS)
            End With
        End Function

        '----------------------------------------------------------------
        ' 保存“人事_B_人事异动”的数据
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
        Public Function doSaveData_RSKP_YDJL( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal objOldData As System.Data.DataRow, _
            ByRef objNewData As System.Collections.Specialized.NameValueCollection, _
            ByVal objenumEditType As Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType) As Boolean
            With m_objdacEstateRenshiGeneral
                doSaveData_RSKP_YDJL = .doSaveData_RSKP_YDJL(strErrMsg, strUserId, strPassword, objOldData, objNewData, objenumEditType)
            End With
        End Function

        '----------------------------------------------------------------
        ' 删除“人事_B_人事异动”的数据
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：用户标识
        '     strPassword          ：用户密码
        '     strWYBS              ：唯一标识
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        '----------------------------------------------------------------
        Public Function doDeleteData_RSKP_YDJL( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWYBS As String) As Boolean
            With m_objdacEstateRenshiGeneral
                doDeleteData_RSKP_YDJL = .doDeleteData_RSKP_YDJL(strErrMsg, strUserId, strPassword, strWYBS)
            End With
        End Function

        '----------------------------------------------------------------
        ' 保存“人事_B_劳动合同”数据记录(整个事务完成)
        '     strErrMsg              ：如果错误，则返回错误信息
        '     strUserId              ：用户标识
        '     strPassword            ：用户密码
        '     objNewData             ：记录新值(返回保存后的新值)
        '     objOldData             ：记录旧值
        '     objenumEditType        ：编辑类型
        '     strUploadFile          ：上载文件的Web本地完全路径
        ' 返回
        '     True                   ：成功
        '     False                  ：失败
        '----------------------------------------------------------------
        Public Function doSaveData_RSKP_LDHT( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByRef objNewData As System.Collections.Specialized.NameValueCollection, _
            ByVal objOldData As System.Data.DataRow, _
            ByVal objenumEditType As Josco.JsKernal.Common.Utilities.PulicParameters.enumEditType, _
            ByVal strUploadFile As String) As Boolean
            With m_objdacEstateRenshiGeneral
                doSaveData_RSKP_LDHT = .doSaveData_RSKP_LDHT(strErrMsg, strUserId, strPassword, objNewData, objOldData, objenumEditType, strUploadFile)
            End With
        End Function

        '----------------------------------------------------------------
        ' 删除“人事_B_劳动合同”记录
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：连接用户名
        '     strPassword          ：连接用户密码
        '     strWYBS              ：要删除的唯一标识
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        '----------------------------------------------------------------
        Public Function doDeleteData_RSKP_LDHT( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWYBS As String) As Boolean
            With m_objdacEstateRenshiGeneral
                doDeleteData_RSKP_LDHT = .doDeleteData_RSKP_LDHT(strErrMsg, strUserId, strPassword, strWYBS)
            End With
        End Function

        '----------------------------------------------------------------
        ' 删除“人事_B_人事卡片”记录及相关记录
        '     strErrMsg            ：如果错误，则返回错误信息
        '     strUserId            ：连接用户名
        '     strPassword          ：连接用户密码
        '     strWYBS              ：要删除的唯一标识
        '     objServer            ：System.Web.HttpServerUtility
        '     strHttpPathPrefix    ：Http目录前缀部分(末尾=/)
        ' 返回
        '     True                 ：成功
        '     False                ：失败
        '----------------------------------------------------------------
        Public Function doDeleteData_RSKP( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strWYBS As String, _
            ByVal objServer As System.Web.HttpServerUtility, _
            ByVal strHttpPathPrefix As String) As Boolean
            With m_objdacEstateRenshiGeneral
                doDeleteData_RSKP = .doDeleteData_RSKP(strErrMsg, strUserId, strPassword, strWYBS, objServer, strHttpPathPrefix)
            End With
        End Function

        '----------------------------------------------------------------
        ' 根据“地产_B_人事_个人履历”创建“人事_B_人事卡片”信息
        '     strErrMsg              ：如果错误，则返回错误信息
        '     strUserId              ：用户标识
        '     strPassword            ：用户密码
        '     strGRLLRYDM            ：“地产_B_人事_个人履历”中的“人员代码”
        '     strUploadFile          ：上载文件的WEB本地完全路径
        '     strAppRoot             ：应用根Http路径(不带/)
        '     strBasePath            ：从应用根到存放地的相对HTTP目录(开头不带/)
        '     objServer              ：服务器对象
        ' 返回
        '     True                   ：成功
        '     False                  ：失败
        '----------------------------------------------------------------
        Public Function doCopyFromGRLLToRSKP( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strGRLLRYDM As String, _
            ByVal strUploadFile As String, _
            ByVal strAppRoot As String, _
            ByVal strBasePath As String, _
            ByVal objServer As System.Web.HttpServerUtility) As Boolean
            With m_objdacEstateRenshiGeneral
                doCopyFromGRLLToRSKP = .doCopyFromGRLLToRSKP(strErrMsg, strUserId, strPassword, strGRLLRYDM, strUploadFile, strAppRoot, strBasePath, objServer)
            End With
        End Function

        '----------------------------------------------------------------
        ' 计算[广州兴业_人事管理_人力资源状况调查表]的数据
        '     strErrMsg              ：如果错误，则返回错误信息
        '     strUserId              ：用户标识
        '     strPassword            ：用户密码
        '     strJZRQ                ：统计截止日期
        '     strExcelFile           ：导出到WEB服务器中的Excel文件路径
        '     strMacroName           ：宏名列表
        '     strMacroValue          ：宏值列表
        ' 返回
        '     True                   ：成功
        '     False                  ：失败
        ' 更改描述
        '     zengxianglin 2009-01-07 创建
        '----------------------------------------------------------------
        Public Function doPrint_RSBB_RLZYZKDCB( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strJZRQ As String, _
            ByVal strExcelFile As String, _
            Optional ByVal strMacroName As String = "", _
            Optional ByVal strMacroValue As String = "") As Boolean
            With m_objdacEstateRenshiGeneral
                doPrint_RSBB_RLZYZKDCB = .doPrint_RSBB_RLZYZKDCB(strErrMsg, strUserId, strPassword, strJZRQ, strExcelFile, strMacroName, strMacroValue)
            End With
        End Function

        '----------------------------------------------------------------
        ' 计算[人员增减异动表]数据
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     strKSRQ                    ：开始日期
        '     strZZRQ                    ：终止日期
        '     objDataSet                 ：信息数据集
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
        ' 更改描述
        '     zengxianglin 2009-01-07 创建
        '----------------------------------------------------------------
        Public Function getDataSet_BB_RYZJYDB( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strKSRQ As String, _
            ByVal strZZRQ As String, _
            ByRef objDataSet As Josco.JSOA.Common.Data.estateRenshiGeneralData) As Boolean
            With m_objdacEstateRenshiGeneral
                getDataSet_BB_RYZJYDB = .getDataSet_BB_RYZJYDB(strErrMsg, strUserId, strPassword, strKSRQ, strZZRQ, objDataSet)
            End With
        End Function

        '----------------------------------------------------------------
        ' 打印[广州兴业_人事管理_人员增减异动表]的数据
        '     strErrMsg              ：如果错误，则返回错误信息
        '     objDataSet             ：要打印的数据
        '     strExcelFile           ：导出到WEB服务器中的Excel文件路径
        '     strMacroName           ：宏名列表
        '     strMacroValue          ：宏值列表
        ' 返回
        '     True                   ：成功
        '     False                  ：失败
        ' 更改描述
        '     zengxianglin 2009-01-07 创建
        '----------------------------------------------------------------
        Public Function doPrint_RSBB_RYZJYDB( _
            ByRef strErrMsg As String, _
            ByVal objDataSet As System.Data.DataSet, _
            ByVal strExcelFile As String, _
            Optional ByVal strMacroName As String = "", _
            Optional ByVal strMacroValue As String = "") As Boolean
            With m_objdacEstateRenshiGeneral
                doPrint_RSBB_RYZJYDB = .doPrint_RSBB_RYZJYDB(strErrMsg, objDataSet, strExcelFile, strMacroName, strMacroValue)
            End With
        End Function

        '----------------------------------------------------------------
        ' 计算[人力资源信息汇总表]数据
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     strKSRQ                    ：开始日期
        '     strZZRQ                    ：终止日期
        '     strYJZR                    ：月截止日
        '     objDataSet                 ：信息数据集
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
        ' 更改描述
        '     zengxianglin 2009-01-08 创建
        '----------------------------------------------------------------
        Public Function getDataSet_BB_RLZYXXHZB( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strKSRQ As String, _
            ByVal strZZRQ As String, _
            ByVal strYJZR As String, _
            ByRef objDataSet As Josco.JSOA.Common.Data.estateRenshiGeneralData) As Boolean
            With m_objdacEstateRenshiGeneral
                getDataSet_BB_RLZYXXHZB = .getDataSet_BB_RLZYXXHZB(strErrMsg, strUserId, strPassword, strKSRQ, strZZRQ, strYJZR, objDataSet)
            End With
        End Function

        '----------------------------------------------------------------
        ' 计算[广州兴业_人事管理_越秀集团在岗人员及其他数据统计表]的数据
        '     strErrMsg              ：如果错误，则返回错误信息
        '     strUserId              ：用户标识
        '     strPassword            ：用户密码
        '     strJZRQ                ：统计截止日期
        '     strExcelFile           ：导出到WEB服务器中的Excel文件路径
        '     strMacroName           ：宏名列表
        '     strMacroValue          ：宏值列表
        ' 返回
        '     True                   ：成功
        '     False                  ：失败
        ' 更改描述
        '     zengxianglin 2009-01-09 创建
        '----------------------------------------------------------------
        Public Function doPrint_RSBB_YXJTZGRYJQTSJTJB( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strJZRQ As String, _
            ByVal strExcelFile As String, _
            Optional ByVal strMacroName As String = "", _
            Optional ByVal strMacroValue As String = "") As Boolean
            With m_objdacEstateRenshiGeneral
                doPrint_RSBB_YXJTZGRYJQTSJTJB = .doPrint_RSBB_YXJTZGRYJQTSJTJB(strErrMsg, strUserId, strPassword, strJZRQ, strExcelFile, strMacroName, strMacroValue)
            End With
        End Function

        '----------------------------------------------------------------
        ' 计算[劳动合同届满期限表]数据
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     strKSRQ                    ：开始日期
        '     strZZRQ                    ：终止日期
        '     objDataSet                 ：信息数据集
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
        ' 更改描述
        '     zengxianglin 2009-01-12 创建
        '----------------------------------------------------------------
        Public Function getDataSet_BB_LDHTJMQXB( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strKSRQ As String, _
            ByVal strZZRQ As String, _
            ByRef objDataSet As Josco.JSOA.Common.Data.estateRenshiGeneralData) As Boolean
            With m_objdacEstateRenshiGeneral
                getDataSet_BB_LDHTJMQXB = .getDataSet_BB_LDHTJMQXB(strErrMsg, strUserId, strPassword, strKSRQ, strZZRQ, objDataSet)
            End With
        End Function

        '----------------------------------------------------------------
        ' 计算[劳动局季报表]数据
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     strTJND                    ：统计年度
        '     strTJJD                    ：统计季度
        '     objDataSet                 ：信息数据集
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
        ' 更改描述
        '     zengxianglin 2009-01-12 创建
        '----------------------------------------------------------------
        Public Function getDataSet_BB_LDJJBB( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strTJND As String, _
            ByVal strTJJD As String, _
            ByRef objDataSet As Josco.JSOA.Common.Data.estateRenshiGeneralData) As Boolean
            With m_objdacEstateRenshiGeneral
                getDataSet_BB_LDJJBB = .getDataSet_BB_LDJJBB(strErrMsg, strUserId, strPassword, strTJND, strTJJD, objDataSet)
            End With
        End Function

        '----------------------------------------------------------------
        ' 计算[劳动局年报表]数据
        '     strErrMsg                  ：如果错误，则返回错误信息
        '     strUserId                  ：用户标识
        '     strPassword                ：用户密码
        '     strTJND                    ：统计年度
        '     objDataSet                 ：信息数据集
        ' 返回
        '     True                       ：成功
        '     False                      ：失败
        ' 更改描述
        '     zengxianglin 2009-01-12 创建
        '----------------------------------------------------------------
        Public Function getDataSet_BB_LDJNBB( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strTJND As String, _
            ByRef objDataSet As Josco.JSOA.Common.Data.estateRenshiGeneralData) As Boolean
            With m_objdacEstateRenshiGeneral
                getDataSet_BB_LDJNBB = .getDataSet_BB_LDJNBB(strErrMsg, strUserId, strPassword, strTJND, objDataSet)
            End With
        End Function

        '----------------------------------------------------------------
        ' 录用[地产_B_人事_个人履历]指定[简历编号]对应的人员
        '     strErrMsg              ：如果错误，则返回错误信息
        '     strUserId              ：用户标识
        '     strPassword            ：用户密码
        '     strJLBH                ：[地产_B_人事_个人履历][简历编号]
        '     objServer              ：服务器对象
        '     strAppRoot             ：应用根WEB路径(不带/)
        '     strBasePath            ：应用根到存放地的相对HTTP目录(开头不带/)
        ' 返回
        '     True                   ：成功
        '     False                  ：失败
        ' 更改记录
        '     zengxianglin 2009-05-15 创建
        '----------------------------------------------------------------
        Public Function doLuyong( _
            ByRef strErrMsg As String, _
            ByVal strUserId As String, _
            ByVal strPassword As String, _
            ByVal strJLBH As String, _
            ByVal objServer As System.Web.HttpServerUtility, _
            ByVal strAppRoot As String, _
            ByVal strBasePath As String) As Boolean
            With m_objdacEstateRenshiGeneral
                doLuyong = .doLuyong(strErrMsg, strUserId, strPassword, strJLBH, objServer, strAppRoot, strBasePath)
            End With
        End Function

    End Class 'rulesEstateRenshiGeneral

End Namespace 'Josco.JsKernal.BusinessRules
