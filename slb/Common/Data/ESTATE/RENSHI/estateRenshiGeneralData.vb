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
Imports System.Runtime.Serialization

Namespace Josco.JSOA.Common.Data

    '----------------------------------------------------------------
    ' �����ռ䣺Josco.JSOA.Common.Data
    ' ����    ��estateRenshiGeneralData
    '
    ' ����������
    '     ������ͨ�����¹�����ر�����ݷ��ʸ�ʽ
    '----------------------------------------------------------------
    <System.ComponentModel.DesignerCategory("RENSHI"), SerializableAttribute()> Public Class estateRenshiGeneralData
        Inherits System.Data.DataSet

        '������_B_����ְ�ơ�����Ϣ����
        '������
        Public Const TABLE_RS_B_JISHUZHICHENG As String = "����_B_����ְ��"
        '�ֶ�����
        Public Const FIELD_RS_B_JISHUZHICHENG_ZCDM As String = "ְ�ƴ���"
        Public Const FIELD_RS_B_JISHUZHICHENG_ZCMC As String = "ְ������"
        '��ʾ�ֶ�����
        'Լ��������Ϣ

        '������_B_ѧ�����֡�����Ϣ����
        '������
        Public Const TABLE_RS_B_XUELIHUAFEN As String = "����_B_ѧ������"
        '�ֶ�����
        Public Const FIELD_RS_B_XUELIHUAFEN_XLDM As String = "ѧ������"
        Public Const FIELD_RS_B_XUELIHUAFEN_XLMC As String = "ѧ������"
        '��ʾ�ֶ�����
        'Լ��������Ϣ

        '������_B_ѧλ���֡�����Ϣ����
        '������
        Public Const TABLE_RS_B_XUEWEIHUAFEN As String = "����_B_ѧλ����"
        '�ֶ�����
        Public Const FIELD_RS_B_XUEWEIHUAFEN_XWDM As String = "ѧλ����"
        Public Const FIELD_RS_B_XUEWEIHUAFEN_XWMC As String = "ѧλ����"
        '��ʾ�ֶ�����
        'Լ��������Ϣ

        '������_B_������ò������Ϣ����
        '������
        Public Const TABLE_RS_B_ZHENGZHIMIANMAO As String = "����_B_������ò"
        '�ֶ�����
        Public Const FIELD_RS_B_ZHENGZHIMIANMAO_MMDM As String = "��ò����"
        Public Const FIELD_RS_B_ZHENGZHIMIANMAO_MMMC As String = "��ò����"
        '��ʾ�ֶ�����
        'Լ��������Ϣ

        '������_B_ִҵ�ʸ񡱱���Ϣ����
        '������
        Public Const TABLE_RS_B_ZHIYEZIGE As String = "����_B_ִҵ�ʸ�"
        '�ֶ�����
        Public Const FIELD_RS_B_ZHIYEZIGE_ZGDM As String = "�ʸ����"
        Public Const FIELD_RS_B_ZHIYEZIGE_ZGMC As String = "�ʸ�����"
        '��ʾ�ֶ�����
        'Լ��������Ϣ

        '������_B_�䶯ԭ�򡱱���Ϣ����
        '������
        Public Const TABLE_RS_B_BIANDONGYUANYIN As String = "����_B_�䶯ԭ��"
        '�ֶ�����
        Public Const FIELD_RS_B_BIANDONGYUANYIN_YYDM As String = "ԭ�����"
        Public Const FIELD_RS_B_BIANDONGYUANYIN_YYMC As String = "ԭ������"
        '��ʾ�ֶ�����
        'Լ��������Ϣ

        '������_B_ְ�����ԡ�����Ϣ����
        '������
        Public Const TABLE_RS_B_ZHIGONGSHUXING As String = "����_B_ְ������"
        '�ֶ�����
        Public Const FIELD_RS_B_ZHIGONGSHUXING_SXDM As String = "���Դ���"
        Public Const FIELD_RS_B_ZHIGONGSHUXING_SXMC As String = "��������"
        '��ʾ�ֶ�����
        'Լ��������Ϣ






        '������_B_���¿�Ƭ������Ϣ����
        '������
        Public Const TABLE_RS_B_RENSHIKAPIAN As String = "����_B_���¿�Ƭ"
        '�ֶ�����
        Public Const FIELD_RS_B_RENSHIKAPIAN_WYBS As String = "Ψһ��ʶ"
        Public Const FIELD_RS_B_RENSHIKAPIAN_RYDM As String = "��Ա����"
        Public Const FIELD_RS_B_RENSHIKAPIAN_XM As String = "����"
        Public Const FIELD_RS_B_RENSHIKAPIAN_BMDM As String = "����"
        Public Const FIELD_RS_B_RENSHIKAPIAN_XB As String = "�Ա�"
        Public Const FIELD_RS_B_RENSHIKAPIAN_CSRQ As String = "��������"
        Public Const FIELD_RS_B_RENSHIKAPIAN_RBDWSJ As String = "�뱾��λʱ��"
        Public Const FIELD_RS_B_RENSHIKAPIAN_YWXM As String = "Ӣ������"
        Public Const FIELD_RS_B_RENSHIKAPIAN_SJHM As String = "�ֻ�����"
        Public Const FIELD_RS_B_RENSHIKAPIAN_ZZDH As String = "סլ�绰"
        Public Const FIELD_RS_B_RENSHIKAPIAN_SFZH As String = "���֤��"
        Public Const FIELD_RS_B_RENSHIKAPIAN_MZ As String = "����"
        Public Const FIELD_RS_B_RENSHIKAPIAN_JG As String = "����"
        Public Const FIELD_RS_B_RENSHIKAPIAN_HJDZ As String = "������ַ"
        Public Const FIELD_RS_B_RENSHIKAPIAN_XZDZ As String = "��ס��ַ"
        Public Const FIELD_RS_B_RENSHIKAPIAN_YJDZ As String = "�ʼĵ�ַ"
        Public Const FIELD_RS_B_RENSHIKAPIAN_HKZT As String = "����״̬"
        Public Const FIELD_RS_B_RENSHIKAPIAN_RYXPWZ As String = "��Ա��Ƭλ��"
        Public Const FIELD_RS_B_RENSHIKAPIAN_HYZK As String = "����״��"
        Public Const FIELD_RS_B_RENSHIKAPIAN_SYZK As String = "�������"
        Public Const FIELD_RS_B_RENSHIKAPIAN_XXLX As String = "ѧϰ����"
        Public Const FIELD_RS_B_RENSHIKAPIAN_ZGXL As String = "���ѧ��"
        Public Const FIELD_RS_B_RENSHIKAPIAN_ZGXW As String = "���ѧλ"
        Public Const FIELD_RS_B_RENSHIKAPIAN_BYYX As String = "��ҵԺУ"
        Public Const FIELD_RS_B_RENSHIKAPIAN_BYZY As String = "��ҵרҵ"
        Public Const FIELD_RS_B_RENSHIKAPIAN_BYSJ As String = "��ҵʱ��"
        Public Const FIELD_RS_B_RENSHIKAPIAN_CJGZSJ As String = "�μӹ���ʱ��"
        'zengxianglin 2009-01-12
        Public Const FIELD_RS_B_RENSHIKAPIAN_TXSJ As String = "����ʱ��"
        'zengxianglin 2009-01-12
        Public Const FIELD_RS_B_RENSHIKAPIAN_ZCQDSJ As String = "ְ��ȡ��ʱ��"
        'zengxianglin 2009-01-07
        Public Const FIELD_RS_B_RENSHIKAPIAN_ZGQDSJ As String = "�ʸ�ȡ��ʱ��"
        'zengxianglin 2009-01-07
        Public Const FIELD_RS_B_RENSHIKAPIAN_JSZC As String = "����ְ��"
        Public Const FIELD_RS_B_RENSHIKAPIAN_ZYZG As String = "ִҵ�ʸ�"
        Public Const FIELD_RS_B_RENSHIKAPIAN_ZZMM As String = "������ò"
        Public Const FIELD_RS_B_RENSHIKAPIAN_RDSJ As String = "�뵳ʱ��"
        Public Const FIELD_RS_B_RENSHIKAPIAN_ZZGX As String = "��֯��ϵ"
        Public Const FIELD_RS_B_RENSHIKAPIAN_SFGHCY As String = "�Ƿ񹤻��Ա"
        Public Const FIELD_RS_B_RENSHIKAPIAN_SFSGGB As String = "�Ƿ��йܸɲ�"
        Public Const FIELD_RS_B_RENSHIKAPIAN_RYQYTX As String = "��Ա��������"
        Public Const FIELD_RS_B_RENSHIKAPIAN_JZQK As String = "��ס���"
        Public Const FIELD_RS_B_RENSHIKAPIAN_ZJZG As String = "�н��ʸ�"
        Public Const FIELD_RS_B_RENSHIKAPIAN_BRSDSZ As String = "�����Ƕ�����"
        Public Const FIELD_RS_B_RENSHIKAPIAN_SFLDSZ As String = "�Ƿ������֤"
        Public Const FIELD_RS_B_RENSHIKAPIAN_SFJZGB As String = "�Ƿ��ת�ɲ�"
        Public Const FIELD_RS_B_RENSHIKAPIAN_GRFYKS As String = "���˷��ۿ�ʼ"
        Public Const FIELD_RS_B_RENSHIKAPIAN_GRFYJS As String = "���˷��۽���"
        Public Const FIELD_RS_B_RENSHIKAPIAN_GRFYSM As String = "���˷���˵��"
        Public Const FIELD_RS_B_RENSHIKAPIAN_GRFYZT As String = "���˷���״̬"
        Public Const FIELD_RS_B_RENSHIKAPIAN_CYFYSM As String = "��Ա����˵��"
        Public Const FIELD_RS_B_RENSHIKAPIAN_CYFYZT As String = "��Ա����״̬"
        Public Const FIELD_RS_B_RENSHIKAPIAN_BZXX As String = "��ע��Ϣ"
        '��ʾ�ֶ�����
        Public Const FIELD_RS_B_RENSHIKAPIAN_BMMC As String = "��������"
        Public Const FIELD_RS_B_RENSHIKAPIAN_NN As String = "����"
        Public Const FIELD_RS_B_RENSHIKAPIAN_HKZTMC As String = "����״̬����"
        Public Const FIELD_RS_B_RENSHIKAPIAN_HYZKMC As String = "����״������"
        Public Const FIELD_RS_B_RENSHIKAPIAN_SYZKMC As String = "�����������"
        Public Const FIELD_RS_B_RENSHIKAPIAN_ZGXLMC As String = "���ѧ������"
        Public Const FIELD_RS_B_RENSHIKAPIAN_ZGXWMC As String = "���ѧλ����"
        Public Const FIELD_RS_B_RENSHIKAPIAN_JSZCMC As String = "����ְ������"
        Public Const FIELD_RS_B_RENSHIKAPIAN_ZYZGMC As String = "ִҵ�ʸ�����"
        Public Const FIELD_RS_B_RENSHIKAPIAN_ZZMMMC As String = "������ò����"
        Public Const FIELD_RS_B_RENSHIKAPIAN_SFGHCYMC As String = "�Ƿ񹤻��Ա����"
        Public Const FIELD_RS_B_RENSHIKAPIAN_SFSGGBMC As String = "�Ƿ��йܸɲ�����"
        Public Const FIELD_RS_B_RENSHIKAPIAN_RYQYTXMC As String = "��Ա������������"
        Public Const FIELD_RS_B_RENSHIKAPIAN_JZQKMC As String = "��ס�������"
        Public Const FIELD_RS_B_RENSHIKAPIAN_BRSDSZMC As String = "�����Ƕ���������"
        Public Const FIELD_RS_B_RENSHIKAPIAN_SFLDSZMC As String = "�Ƿ������֤����"
        Public Const FIELD_RS_B_RENSHIKAPIAN_SFJZGBMC As String = "�Ƿ��ת�ɲ�����"
        Public Const FIELD_RS_B_RENSHIKAPIAN_CYFYZTMC As String = "��Ա����״̬����"
        Public Const FIELD_RS_B_RENSHIKAPIAN_GRFYZTMC As String = "���˷���״̬����"
        Public Const FIELD_RS_B_RENSHIKAPIAN_DRZW As String = "����ְ��"
        Public Const FIELD_RS_B_RENSHIKAPIAN_ZJDM As String = "ְ������"
        Public Const FIELD_RS_B_RENSHIKAPIAN_ZJMC As String = "ְ������"
        Public Const FIELD_RS_B_RENSHIKAPIAN_SFZZ As String = "�Ƿ���ְ"
        Public Const FIELD_RS_B_RENSHIKAPIAN_ZZSJ As String = "ת��ʱ��"
        Public Const FIELD_RS_B_RENSHIKAPIAN_ZZZW As String = "ת��ְλ"
        Public Const FIELD_RS_B_RENSHIKAPIAN_ZNSL As String = "��Ů����"
        Public Const FIELD_RS_B_RENSHIKAPIAN_LZYY As String = "��ְԭ��"
        'Լ��������Ϣ

        '������_B_��ͥ��Ա������Ϣ����
        '������
        Public Const TABLE_RS_B_JIATINGCHENGYUAN As String = "����_B_��ͥ��Ա"
        '�ֶ�����
        Public Const FIELD_RS_B_JIATINGCHENGYUAN_WYBS As String = "Ψһ��ʶ"
        Public Const FIELD_RS_B_JIATINGCHENGYUAN_RYDM As String = "��Ա����"
        Public Const FIELD_RS_B_JIATINGCHENGYUAN_CYXM As String = "��Ա����"
        Public Const FIELD_RS_B_JIATINGCHENGYUAN_XYGX As String = "ѪԵ��ϵ"
        Public Const FIELD_RS_B_JIATINGCHENGYUAN_CSNY As String = "��������"
        Public Const FIELD_RS_B_JIATINGCHENGYUAN_FWDW As String = "����λ"
        Public Const FIELD_RS_B_JIATINGCHENGYUAN_DRZW As String = "����ְ��"
        Public Const FIELD_RS_B_JIATINGCHENGYUAN_XJDZ As String = "�־ӵ�ַ"
        '��ʾ�ֶ�����
        'Լ��������Ϣ

        '������_B_ѧϰ����������Ϣ����
        '������
        Public Const TABLE_RS_B_XUEXIJINGLI As String = "����_B_ѧϰ����"
        '�ֶ�����
        Public Const FIELD_RS_B_XUEXIJINGLI_WYBS As String = "Ψһ��ʶ"
        Public Const FIELD_RS_B_XUEXIJINGLI_RYDM As String = "��Ա����"
        Public Const FIELD_RS_B_XUEXIJINGLI_KSNY As String = "��ʼ����"
        Public Const FIELD_RS_B_XUEXIJINGLI_ZZNY As String = "��ֹ����"
        Public Const FIELD_RS_B_XUEXIJINGLI_XXLX As String = "ѧϰ����"
        Public Const FIELD_RS_B_XUEXIJINGLI_XXYX As String = "ѧϰԺУ"
        Public Const FIELD_RS_B_XUEXIJINGLI_XXZY As String = "ѧϰרҵ"
        Public Const FIELD_RS_B_XUEXIJINGLI_XXJG As String = "ѧϰ���"
        Public Const FIELD_RS_B_XUEXIJINGLI_BZXX As String = "��ע��Ϣ"
        '��ʾ�ֶ�����
        'Լ��������Ϣ

        '������_B_��������������Ϣ����
        '������
        Public Const TABLE_RS_B_GONGZUOJINGLI As String = "����_B_��������"
        '�ֶ�����
        Public Const FIELD_RS_B_GONGZUOJINGLI_WYBS As String = "Ψһ��ʶ"
        Public Const FIELD_RS_B_GONGZUOJINGLI_RYDM As String = "��Ա����"
        Public Const FIELD_RS_B_GONGZUOJINGLI_KSNY As String = "��ʼ����"
        Public Const FIELD_RS_B_GONGZUOJINGLI_ZZNY As String = "��ֹ����"
        Public Const FIELD_RS_B_GONGZUOJINGLI_FWDW As String = "����λ"
        Public Const FIELD_RS_B_GONGZUOJINGLI_DRZW As String = "����ְ��"
        Public Const FIELD_RS_B_GONGZUOJINGLI_BZXX As String = "��ע��Ϣ"
        '��ʾ�ֶ�����
        'Լ��������Ϣ

        '������_B_��ѵ��¼������Ϣ����
        '������
        Public Const TABLE_RS_B_PEIXUNJILU As String = "����_B_��ѵ��¼"
        '�ֶ�����
        Public Const FIELD_RS_B_PEIXUNJILU_WYBS As String = "Ψһ��ʶ"
        Public Const FIELD_RS_B_PEIXUNJILU_RYDM As String = "��Ա����"
        Public Const FIELD_RS_B_PEIXUNJILU_PXMC As String = "��ѵ����"
        Public Const FIELD_RS_B_PEIXUNJILU_KSSJ As String = "��ʼʱ��"
        Public Const FIELD_RS_B_PEIXUNJILU_ZZSJ As String = "��ֹʱ��"
        Public Const FIELD_RS_B_PEIXUNJILU_NBPX As String = "�ڲ���ѵ"
        Public Const FIELD_RS_B_PEIXUNJILU_PXXG As String = "��ѵЧ��"
        Public Const FIELD_RS_B_PEIXUNJILU_BZXX As String = "��ע��Ϣ"
        Public Const FIELD_RS_B_PEIXUNJILU_PXKS As String = "��ѵ��ʱ"
        '��ʾ�ֶ�����
        Public Const FIELD_RS_B_PEIXUNJILU_RYMC As String = "��Ա����"
        Public Const FIELD_RS_B_PEIXUNJILU_NBPXMC As String = "�ڲ���ѵ����"
        'Լ��������Ϣ

        '������_B_�����춯������Ϣ����
        '������
        Public Const TABLE_RS_B_RENSHIYIDONG As String = "����_B_�����춯"
        '�ֶ�����
        Public Const FIELD_RS_B_RENSHIYIDONG_WYBS As String = "Ψһ��ʶ"
        Public Const FIELD_RS_B_RENSHIYIDONG_RYDM As String = "��Ա����"
        Public Const FIELD_RS_B_RENSHIYIDONG_KSSJ As String = "��ʼʱ��"
        Public Const FIELD_RS_B_RENSHIYIDONG_ZZSJ As String = "��ֹʱ��"
        Public Const FIELD_RS_B_RENSHIYIDONG_GLBS As String = "������ʶ"
        Public Const FIELD_RS_B_RENSHIYIDONG_BDYY As String = "�䶯ԭ��"
        Public Const FIELD_RS_B_RENSHIYIDONG_RZDW As String = "��ְ��λ"
        Public Const FIELD_RS_B_RENSHIYIDONG_RZJB As String = "��ְ����"
        Public Const FIELD_RS_B_RENSHIYIDONG_JBBZ As String = "�����־"
        Public Const FIELD_RS_B_RENSHIYIDONG_FGGZ As String = "�ֹܹ���"
        Public Const FIELD_RS_B_RENSHIYIDONG_ZGSX As String = "ְ������"
        Public Const FIELD_RS_B_RENSHIYIDONG_GWSX As String = "��λ����"
        Public Const FIELD_RS_B_RENSHIYIDONG_YRDW As String = "ԭ�ε�λ"
        Public Const FIELD_RS_B_RENSHIYIDONG_YRJB As String = "ԭ�μ���"
        Public Const FIELD_RS_B_RENSHIYIDONG_BZXX As String = "��ע��Ϣ"
        'zengxianglin 2008-10-14
        Public Const FIELD_RS_B_RENSHIYIDONG_SSFZ As String = "��������"
        Public Const FIELD_RS_B_RENSHIYIDONG_YSFZ As String = "ԭ������"
        'zengxianglin 2008-10-14
        'zengxianglin 2010-01-06
        Public Const FIELD_RS_B_RENSHIYIDONG_YGSX As String = "ԭ������"
        Public Const FIELD_RS_B_RENSHIYIDONG_YZSX As String = "ԭְ����"
        Public Const FIELD_RS_B_RENSHIYIDONG_BCZB As String = "����ռ��"
        Public Const FIELD_RS_B_RENSHIYIDONG_SCZB As String = "�ϴ�ռ��"
        Public Const FIELD_RS_B_RENSHIYIDONG_XSTD As String = "�����Ŷ�"
        Public Const FIELD_RS_B_RENSHIYIDONG_YSTD As String = "ԭ���Ŷ�"
        'zengxianglin 2010-01-06
        '��ʾ�ֶ�����
        Public Const FIELD_RS_B_RENSHIYIDONG_RYMC As String = "��Ա����"
        Public Const FIELD_RS_B_RENSHIYIDONG_BDYYMC As String = "�䶯ԭ������"
        Public Const FIELD_RS_B_RENSHIYIDONG_RZDWMC As String = "��ְ��λ����"
        Public Const FIELD_RS_B_RENSHIYIDONG_ZGSXMC As String = "ְ����������"
        Public Const FIELD_RS_B_RENSHIYIDONG_GWSXMC As String = "��λ��������"
        Public Const FIELD_RS_B_RENSHIYIDONG_YRDWMC As String = "ԭ�ε�λ����"
        Public Const FIELD_RS_B_RENSHIYIDONG_JBBZMC As String = "�����־����"
        'zengxianglin 2010-01-06
        Public Const FIELD_RS_B_RENSHIYIDONG_YGSXMC As String = "ԭ����������"
        Public Const FIELD_RS_B_RENSHIYIDONG_YZSXMC As String = "ԭְ��������"
        'zengxianglin 2010-01-06
        'Լ��������Ϣ

        '������_B_�Ͷ���ͬ������Ϣ����
        '������
        Public Const TABLE_RS_B_LAODONGHETONG As String = "����_B_�Ͷ���ͬ"
        '�ֶ�����
        Public Const FIELD_RS_B_LAODONGHETONG_WYBS As String = "Ψһ��ʶ"
        Public Const FIELD_RS_B_LAODONGHETONG_RYDM As String = "��Ա����"
        Public Const FIELD_RS_B_LAODONGHETONG_KSSJ As String = "��ʼʱ��"
        Public Const FIELD_RS_B_LAODONGHETONG_JSSJ As String = "����ʱ��"
        'zengxianglin 2009-01-12
        Public Const FIELD_RS_B_LAODONGHETONG_SYKS As String = "���ÿ�ʼ"
        Public Const FIELD_RS_B_LAODONGHETONG_SYJS As String = "���ý���"
        'zengxianglin 2009-01-12
        Public Const FIELD_RS_B_LAODONGHETONG_HTLX As String = "��ͬ����"
        Public Const FIELD_RS_B_LAODONGHETONG_SFXY As String = "�Ƿ���Լ"
        Public Const FIELD_RS_B_LAODONGHETONG_HTWJ As String = "��ͬ�ļ�"
        '��ʾ�ֶ�����
        Public Const FIELD_RS_B_LAODONGHETONG_RYMC As String = "��Ա����"
        Public Const FIELD_RS_B_LAODONGHETONG_HTLXMC As String = "��ͬ��������"
        Public Const FIELD_RS_B_LAODONGHETONG_SFXYMC As String = "�Ƿ���Լ����"
        Public Const FIELD_RS_B_LAODONGHETONG_HTWJMC As String = "��ͬ�ļ�����"
        'Լ��������Ϣ
        'Ŀ¼�趨
        Public Const FILEDIR_RS_RSKP_LDHT As String = "RS\RSKP\LDHT"  '��ͬ�ļ���Ż�׼Ŀ¼

        'zengxianglin 2009-01-07
        '������_VT_��Ա�����춯���������Ϣ����
        '������
        Public Const TABLE_RS_VT_RYZJYDB As String = "����_VT_��Ա�����춯��"
        '�ֶ�����
        Public Const FIELD_RS_VT_RYZJYDB_TJNY As String = "ͳ������"
        Public Const FIELD_RS_VT_RYZJYDB_JLXH As String = "��¼���"
        '***************************************************************************
        Public Const FIELD_RS_VT_RYZJYDB_RZXM As String = "��ְ����"
        Public Const FIELD_RS_VT_RYZJYDB_RZRQ As String = "��ְ����"
        Public Const FIELD_RS_VT_RYZJYDB_RZBM As String = "��ְ����"
        Public Const FIELD_RS_VT_RYZJYDB_RZZJ As String = "��ְְ��"
        '***************************************************************************
        Public Const FIELD_RS_VT_RYZJYDB_LZXM As String = "��ְ����"
        Public Const FIELD_RS_VT_RYZJYDB_LZJCHT As String = "��ְ�����ͬ"
        Public Const FIELD_RS_VT_RYZJYDB_LZQMZZ As String = "��ְ������ֹ"
        Public Const FIELD_RS_VT_RYZJYDB_LZDC As String = "��ְ����"
        Public Const FIELD_RS_VT_RYZJYDB_LZTX As String = "��ְ����"
        Public Const FIELD_RS_VT_RYZJYDB_LZSW As String = "��ְ����"
        Public Const FIELD_RS_VT_RYZJYDB_LZQT As String = "��ְ����"
        Public Const FIELD_RS_VT_RYZJYDB_LZRQ As String = "��ְ����"
        Public Const FIELD_RS_VT_RYZJYDB_LZBM As String = "��ְ����"
        '***************************************************************************
        Public Const FIELD_RS_VT_RYZJYDB_SXXM As String = "ʵϰ����"
        Public Const FIELD_RS_VT_RYZJYDB_SXYX As String = "ʵϰԺУ"
        Public Const FIELD_RS_VT_RYZJYDB_SXRQ As String = "ʵϰ����"
        Public Const FIELD_RS_VT_RYZJYDB_SXBM As String = "ʵϰ����"
        '***************************************************************************
        Public Const FIELD_RS_VT_RYZJYDB_YDXM As String = "�춯����"
        Public Const FIELD_RS_VT_RYZJYDB_YDRQ As String = "�춯����"
        Public Const FIELD_RS_VT_RYZJYDB_YDXBM As String = "�춯�²���"
        Public Const FIELD_RS_VT_RYZJYDB_YDXZJ As String = "�춯��ְ��"
        Public Const FIELD_RS_VT_RYZJYDB_YDYBM As String = "�춯ԭ����"
        Public Const FIELD_RS_VT_RYZJYDB_YDYZJ As String = "�춯ԭְ��"
        Public Const FIELD_RS_VT_RYZJYDB_YDZZ As String = "�춯ת��"
        Public Const FIELD_RS_VT_RYZJYDB_YDCQCJ As String = "�춯���ڲ���"
        '***************************************************************************
        Public Const FIELD_RS_VT_RYZJYDB_YDSBZY As String = "�춯�籣��Ա"
        Public Const FIELD_RS_VT_RYZJYDB_YDSBJY As String = "�춯�籣��Ա"
        Public Const FIELD_RS_VT_RYZJYDB_YDKJGJJ As String = "�춯���ɹ�����"
        Public Const FIELD_RS_VT_RYZJYDB_YDTJGJJ As String = "�춯ͣ�ɹ�����"
        Public Const FIELD_RS_VT_RYZJYDB_YDPXQK As String = "�춯��ѵ���"
        '��ʾ�ֶ�����
        'Լ��������Ϣ
        'zengxianglin 2009-01-07

        'zengxianglin 2009-01-08
        '������_VT_������Դ��Ϣ���ܱ��������Ϣ����
        '������
        Public Const TABLE_RS_VT_RLZYXXHZB As String = "����_VT_������Դ��Ϣ���ܱ�"
        '�ֶ�����
        Public Const FIELD_RS_VT_RLZYXXHZB_DWDM As String = "��λ����"
        Public Const FIELD_RS_VT_RLZYXXHZB_DWMC As String = "��λ����"
        Public Const FIELD_RS_VT_RLZYXXHZB_DWXH As String = "��λ���"
        '***************************************************************************
        Public Const FIELD_RS_VT_RLZYXXHZB_RZRS As String = "��ְ����"
        Public Const FIELD_RS_VT_RLZYXXHZB_DRRS As String = "��������"
        Public Const FIELD_RS_VT_RLZYXXHZB_DCRS As String = "��������"
        Public Const FIELD_RS_VT_RLZYXXHZB_LZRS As String = "��ְ����"
        '***************************************************************************
        Public Const FIELD_RS_VT_RLZYXXHZB_PJRSY As String = "ƽ��������"
        Public Const FIELD_RS_VT_RLZYXXHZB_PJRSJ As String = "ƽ��������"
        Public Const FIELD_RS_VT_RLZYXXHZB_PJRSN As String = "ƽ��������"
        '***************************************************************************
        Public Const FIELD_RS_VT_RLZYXXHZB_DWCSY As String = "��λ������"
        Public Const FIELD_RS_VT_RLZYXXHZB_DWCSJ As String = "��λ���ռ�"
        Public Const FIELD_RS_VT_RLZYXXHZB_DWCSN As String = "��λ������"
        '***************************************************************************
        Public Const FIELD_RS_VT_RLZYXXHZB_PJCSY As String = "ƽ��������"
        Public Const FIELD_RS_VT_RLZYXXHZB_PJCSJ As String = "ƽ�����ռ�"
        Public Const FIELD_RS_VT_RLZYXXHZB_PJCSN As String = "ƽ��������"
        '��ʾ�ֶ�����
        'Լ��������Ϣ
        'zengxianglin 2009-01-08

        'zengxianglin 2009-01-12
        '������_VT_�Ͷ���ͬ�������ޱ��������Ϣ����
        '������
        Public Const TABLE_RS_VT_LDHTJMQXB As String = "����_VT_�Ͷ���ͬ�������ޱ�"
        '�ֶ�����
        Public Const FIELD_RS_VT_LDHTJMQXB_JLXH As String = "��¼���"
        Public Const FIELD_RS_VT_LDHTJMQXB_TJNY As String = "ͳ������"
        '***************************************************************************
        Public Const FIELD_RS_VT_LDHTJMQXB_SLBRYDM As String = "��¥����Ա����"
        Public Const FIELD_RS_VT_LDHTJMQXB_SLBRYMC As String = "��¥����Ա����"
        Public Const FIELD_RS_VT_LDHTJMQXB_SLBHTQX As String = "��¥����ͬ����"
        Public Const FIELD_RS_VT_LDHTJMQXB_SLBXYQK As String = "��¥����Լ���"
        Public Const FIELD_RS_VT_LDHTJMQXB_SLBRZSJ As String = "��¥����ְʱ��"
        '***************************************************************************
        Public Const FIELD_RS_VT_LDHTJMQXB_FHRYDM As String = "������Ա����"
        Public Const FIELD_RS_VT_LDHTJMQXB_FHRYMC As String = "������Ա����"
        Public Const FIELD_RS_VT_LDHTJMQXB_FHHTQX As String = "���к�ͬ����"
        Public Const FIELD_RS_VT_LDHTJMQXB_FHXYQK As String = "������Լ���"
        Public Const FIELD_RS_VT_LDHTJMQXB_FHRZSJ As String = "������ְʱ��"
        '***************************************************************************
        Public Const FIELD_RS_VT_LDHTJMQXB_ZBRYDM As String = "�ܲ���Ա����"
        Public Const FIELD_RS_VT_LDHTJMQXB_ZBRYMC As String = "�ܲ���Ա����"
        Public Const FIELD_RS_VT_LDHTJMQXB_ZBHTQX As String = "�ܲ���ͬ����"
        Public Const FIELD_RS_VT_LDHTJMQXB_ZBXYQK As String = "�ܲ���Լ���"
        Public Const FIELD_RS_VT_LDHTJMQXB_ZBRZSJ As String = "�ܲ���ְʱ��"
        Public Const FIELD_RS_VT_LDHTJMQXB_ZBGWQX As String = "�ܲ���λ����"
        '***************************************************************************
        '��ʾ�ֶ�����
        'Լ��������Ϣ
        'zengxianglin 2009-01-12

        'zengxianglin 2009-01-12
        '������_VT_�Ͷ��ּ������������Ϣ����
        '������
        Public Const TABLE_RS_VT_LDJJBB As String = "����_VT_�Ͷ��ּ�����"
        '�ֶ�����
        Public Const FIELD_RS_VT_LDJJBB_JLXH As String = "��¼���"
        Public Const FIELD_RS_VT_LDJJBB_TJNJ As String = "ͳ���꼾"
        '***************************************************************************
        Public Const FIELD_RS_VT_LDJJBB_ZBMC As String = "ָ������"
        Public Const FIELD_RS_VT_LDJJBB_ZBDW As String = "ָ�굥λ"
        Public Const FIELD_RS_VT_LDJJBB_ZBDM As String = "ָ�����"
        '***************************************************************************
        Public Const FIELD_RS_VT_LDJJBB_BJSJ As String = "����ʵ��"
        Public Const FIELD_RS_VT_LDJJBB_NCZBJZ As String = "���������ֹ"
        '***************************************************************************
        '��ʾ�ֶ�����
        'Լ��������Ϣ
        'zengxianglin 2009-01-12

        'zengxianglin 2009-01-12
        '������_VT_�Ͷ����걨���������Ϣ����
        '������
        Public Const TABLE_RS_VT_LDJNBB As String = "����_VT_�Ͷ����걨��"
        '�ֶ�����
        Public Const FIELD_RS_VT_LDJNBB_JLXH As String = "��¼���"
        Public Const FIELD_RS_VT_LDJNBB_TJND As String = "ͳ�����"
        '***************************************************************************
        Public Const FIELD_RS_VT_LDJNBB_ZBMC As String = "ָ������"
        Public Const FIELD_RS_VT_LDJNBB_ZBDW As String = "ָ�굥λ"
        Public Const FIELD_RS_VT_LDJNBB_ZBDM As String = "ָ�����"
        '***************************************************************************
        Public Const FIELD_RS_VT_LDJNBB_BNSJ As String = "����ʵ��"
        '***************************************************************************
        '��ʾ�ֶ�����
        'Լ��������Ϣ
        'zengxianglin 2009-01-12




       



        '�����ʼ��������enum
        Public Enum enumTableType
            RS_B_JISHUZHICHENG = 1
            RS_B_XUELIHUAFEN = 2
            RS_B_XUEWEIHUAFEN = 3
            RS_B_ZHENGZHIMIANMAO = 4
            RS_B_ZHIYEZIGE = 5
            RS_B_BIANDONGYUANYIN = 6
            RS_B_ZHIGONGSHUXING = 7

            RS_B_RENSHIKAPIAN = 8
            RS_B_JIATINGCHENGYUAN = 9
            RS_B_XUEXIJINGLI = 10
            RS_B_GONGZUOJINGLI = 11
            RS_B_PEIXUNJILU = 12
            RS_B_RENSHIYIDONG = 13
            RS_B_LAODONGHETONG = 14

            'zengxianglin 2009-01-07
            RS_VT_RYZJYDB = 15
            'zengxianglin 2009-01-07
            'zengxianglin 2009-01-08
            RS_VT_RLZYXXHZB = 16
            'zengxianglin 2009-01-08
            'zengxianglin 2009-01-12
            RS_VT_LDHTJMQXB = 17
            RS_VT_LDJJBB = 18
            RS_VT_LDJNBB = 19
            'zengxianglin 2009-01-12
        End Enum










        '----------------------------------------------------------------
        ' ���캯��
        '----------------------------------------------------------------
        Private Sub New(ByVal info As SerializationInfo, ByVal context As StreamingContext)
            MyBase.New(info, context)
        End Sub

        '----------------------------------------------------------------
        ' ���캯��
        '----------------------------------------------------------------
        Public Sub New()
            MyBase.New()
        End Sub

        '----------------------------------------------------------------
        ' ���캯��
        '----------------------------------------------------------------
        Public Sub New(ByVal objenumTableType As enumTableType)
            MyBase.New()
            Try
                Dim objDataTable As System.Data.DataTable
                Dim strErrMsg As String
                objDataTable = Me.createDataTables(strErrMsg, objenumTableType)
                If Not (objDataTable Is Nothing) Then
                    Me.Tables.Add(objDataTable)
                End If
            Catch ex As Exception
            End Try

        End Sub

        '----------------------------------------------------------------
        ' ��ȫ�ͷű�����Դ
        '----------------------------------------------------------------
        Public Shared Sub SafeRelease(ByRef obj As Josco.JSOA.Common.Data.estateRenshiGeneralData)
            Try
                If Not (obj Is Nothing) Then
                    obj.Dispose()
                End If
            Catch ex As Exception
            End Try
            obj = Nothing
        End Sub








        '----------------------------------------------------------------
        ' ר���б�
        '----------------------------------------------------------------
        ' ����״̬�б�
        Public Enum enumHunyinZhuangtai
            WeiHun = 1
            YiHun = 2
            LiYi = 4
        End Enum
        '----------------------------------------------------------------
        ' ����������
        '     ���ݻ���״̬intCodeValue�ж��Ƿ�Ϊ����״̬objenumHunyinZhuangtai
        ' ����ӿڣ�
        '     intCodeValue - ����״̬
        '     objenumHunyinZhuangtai - �������״̬
        ' ����ӿڣ�
        '     True - ��
        '     False - ��
        ' ��ע��Ϣ��
        '     ������ 2008-05-19 ���
        '----------------------------------------------------------------
        Public Shared Function isHunyinZhuangtai( _
            ByVal intCodeValue As Integer, _
            ByVal objenumHunyinZhuangtai As enumHunyinZhuangtai) As Boolean

            isHunyinZhuangtai = False
            Try
                Dim intValue As Integer = objenumHunyinZhuangtai
                If (intCodeValue And intValue) = intValue Then
                    isHunyinZhuangtai = True
                End If
            Catch ex As Exception
            End Try

        End Function
        '----------------------------------------------------------------
        ' ����������
        '     ���ݸ���״̬����״̬��
        ' ����ӿڣ�
        '     blnWeiHun - δ��״̬
        '     blnYiHun - �ѻ�״̬
        '     blnLiYi - ����״̬
        ' ����ӿڣ�
        '     True - ��
        '     False - ��
        ' ��ע��Ϣ��
        '     ������ 2008-05-19 ���
        '----------------------------------------------------------------
        Public Shared Function getHunyinZhuangtai( _
            ByVal blnWeiHun As Boolean, _
            ByVal blnYiHun As Boolean, _
            ByVal blnLiYi As Boolean) As Integer

            getHunyinZhuangtai = 0
            Try
                If blnWeiHun = True Then
                    getHunyinZhuangtai += enumHunyinZhuangtai.WeiHun
                End If
                If blnYiHun = True Then
                    getHunyinZhuangtai += enumHunyinZhuangtai.YiHun
                End If
                If blnLiYi = True Then
                    getHunyinZhuangtai += enumHunyinZhuangtai.LiYi
                End If
            Catch ex As Exception
            End Try

        End Function

        ' ����״���б�
        Public Enum enumShengyuZhuangkuang
            WeiYu = 1
            YiYu = 2
        End Enum
        '----------------------------------------------------------------
        ' ����������
        '     ��������״��intCodeValue�ж��Ƿ�Ϊ����״̬objenumShengyuZhuangkuang
        ' ����ӿڣ�
        '     intCodeValue - ����״��
        '     objenumShengyuZhuangkuang - ��������״��
        ' ����ӿڣ�
        '     True - ��
        '     False - ��
        ' ��ע��Ϣ��
        '     ������ 2008-05-19 ���
        '----------------------------------------------------------------
        Public Shared Function isShengyuZhuangkuang( _
            ByVal intCodeValue As Integer, _
            ByVal objenumShengyuZhuangkuang As enumShengyuZhuangkuang) As Boolean

            isShengyuZhuangkuang = False
            Try
                Dim intValue As Integer = objenumShengyuZhuangkuang
                If (intCodeValue And intValue) = intValue Then
                    isShengyuZhuangkuang = True
                End If
            Catch ex As Exception
            End Try

        End Function
        '----------------------------------------------------------------
        ' ����������
        '     ���ݸ���״̬����״̬��
        ' ����ӿڣ�
        '     blnWeiYu - δ��״̬
        '     blnYiYu - ����״̬
        ' ����ӿڣ�
        '     True - ��
        '     False - ��
        ' ��ע��Ϣ��
        '     ������ 2008-05-19 ���
        '----------------------------------------------------------------
        Public Shared Function getShengyuZhuangkuang( _
            ByVal blnWeiYu As Boolean, _
            ByVal blnYiYu As Boolean) As Integer

            getShengyuZhuangkuang = 0
            Try
                If blnWeiYu = True Then
                    getShengyuZhuangkuang += enumShengyuZhuangkuang.WeiYu
                End If
                If blnYiYu = True Then
                    getShengyuZhuangkuang += enumShengyuZhuangkuang.YiYu
                End If
            Catch ex As Exception
            End Try

        End Function


        ' ��ס����б�
        Public Enum enumJuzhuQingkuang
            ZiyouWuye = 1
            ZulinWuye = 2
            ShiAnjie = 4
            BushiAnjie = 8
        End Enum
        '----------------------------------------------------------------
        ' ����������
        '     ���ݾ�ס���intCodeValue�ж��Ƿ�Ϊ����״̬objenumJuzhuQingkuang
        ' ����ӿڣ�
        '     intCodeValue - ��ס���
        '     objenumJuzhuQingkuang - �����ס���
        ' ����ӿڣ�
        '     True - ��
        '     False - ��
        ' ��ע��Ϣ��
        '     ������ 2008-05-19 ���
        '----------------------------------------------------------------
        Public Shared Function isJuzhuQingkuang( _
            ByVal intCodeValue As Integer, _
            ByVal objenumJuzhuQingkuang As enumJuzhuQingkuang) As Boolean

            isJuzhuQingkuang = False
            Try
                Dim intValue As Integer = objenumJuzhuQingkuang
                Select Case intCodeValue
                    Case enumJuzhuQingkuang.ZiyouWuye, enumJuzhuQingkuang.ZulinWuye
                        If (intCodeValue And intValue) = intValue Then
                            isJuzhuQingkuang = True
                        End If
                    Case Else
                        If (intCodeValue And enumJuzhuQingkuang.ZiyouWuye) = enumJuzhuQingkuang.ZiyouWuye Then
                            If (intCodeValue And intValue) = intValue Then
                                isJuzhuQingkuang = True
                            End If
                        Else
                            isJuzhuQingkuang = False
                        End If
                End Select
            Catch ex As Exception
            End Try

        End Function
        '----------------------------------------------------------------
        ' ����������
        '     ���ݸ���״̬����״̬��
        ' ����ӿڣ�
        '     blnZiyouWuye - ������ҵ
        '     blnZulinWuye - ������ҵ
        '     blnShiAnjie - �ǰ���
        '     blnBushiAnjie - �񰴽�
        ' ����ӿڣ�
        '     True - ��
        '     False - ��
        ' ��ע��Ϣ��
        '     ������ 2008-05-19 ���
        '----------------------------------------------------------------
        Public Shared Function getJuzhuQingkuang( _
            ByVal blnZiyouWuye As Boolean, _
            ByVal blnZulinWuye As Boolean, _
            ByVal blnShiAnjie As Boolean, _
            ByVal blnBushiAnjie As Boolean) As Integer

            getJuzhuQingkuang = 0
            Try
                If blnZiyouWuye = True Then
                    getJuzhuQingkuang += enumJuzhuQingkuang.ZiyouWuye
                End If
                If blnZulinWuye = True Then
                    getJuzhuQingkuang += enumJuzhuQingkuang.ZulinWuye
                End If
                If blnShiAnjie = True Then
                    getJuzhuQingkuang += enumJuzhuQingkuang.ShiAnjie
                End If
                If blnBushiAnjie = True Then
                    getJuzhuQingkuang += enumJuzhuQingkuang.BushiAnjie
                End If
            Catch ex As Exception
            End Try

        End Function

        ' ��Ա����״̬�б�
        Public Enum enumChengyuanFuyuZhuangtai
            KongBai = 0
            XianYu = 1
            ZhuanYe = 2
            FuYuan = 3
        End Enum
        '----------------------------------------------------------------
        ' ����������
        '     ���ݳ�Ա����״̬intCodeValue�ж��Ƿ�Ϊ����״̬objenumChengyuanFuyuZhuangtai
        ' ����ӿڣ�
        '     intCodeValue - ��Ա����״̬
        '     objenumChengyuanFuyuZhuangtai - �����Ա����״̬
        ' ����ӿڣ�
        '     True - ��
        '     False - ��
        ' ��ע��Ϣ��
        '     ������ 2008-05-19 ���
        '----------------------------------------------------------------
        Public Shared Function isChengyuanFuyuZhuangtai( _
            ByVal intCodeValue As Integer, _
            ByVal objenumChengyuanFuyuZhuangtai As enumChengyuanFuyuZhuangtai) As Boolean

            isChengyuanFuyuZhuangtai = False
            Try
                Dim intValue As Integer = objenumChengyuanFuyuZhuangtai
                If intValue = intCodeValue Then
                    isChengyuanFuyuZhuangtai = True
                End If
            Catch ex As Exception
            End Try

        End Function
        '----------------------------------------------------------------
        ' ����������
        '     ���ݸ���״̬����״̬��
        ' ����ӿڣ�
        '     strValue - ѡ��ֵ
        ' ����ӿڣ�
        '     True - ��
        '     False - ��
        ' ��ע��Ϣ��
        '     ������ 2008-05-19 ���
        '----------------------------------------------------------------
        Public Shared Function getChengyuanFuyuZhuangtai(ByVal strValue As String) As Integer

            getChengyuanFuyuZhuangtai = 0
            Try
                Select Case strValue
                    Case "�հ�"
                        getChengyuanFuyuZhuangtai = enumChengyuanFuyuZhuangtai.KongBai
                    Case "����"
                        getChengyuanFuyuZhuangtai = enumChengyuanFuyuZhuangtai.XianYu
                    Case "תҵ"
                        getChengyuanFuyuZhuangtai = enumChengyuanFuyuZhuangtai.ZhuanYe
                    Case "��Ա"
                        getChengyuanFuyuZhuangtai = enumChengyuanFuyuZhuangtai.FuYuan
                    Case Else
                End Select
            Catch ex As Exception
            End Try

        End Function

        ' ��Ա���������б�
        Public Enum enumRenyuanQuyuTexing
            GuoNei = 0
            GuiQiao = 1
            XiangGang = 2
            AoMen = 3
            TaiWan = 4
            WaiJi = 5
        End Enum
        '----------------------------------------------------------------
        ' ����������
        '     ������Ա��������intCodeValue�ж��Ƿ�Ϊ����״̬objenumRenyuanQuyuTexing
        ' ����ӿڣ�
        '     intCodeValue - ��Ա��������
        '     objenumRenyuanQuyuTexing - ������Ա��������
        ' ����ӿڣ�
        '     True - ��
        '     False - ��
        ' ��ע��Ϣ��
        '     ������ 2008-05-19 ���
        '----------------------------------------------------------------
        Public Shared Function isRenyuanQuyuTexing( _
            ByVal intCodeValue As Integer, _
            ByVal objenumRenyuanQuyuTexing As enumRenyuanQuyuTexing) As Boolean

            isRenyuanQuyuTexing = False
            Try
                Dim intValue As Integer = objenumRenyuanQuyuTexing
                If intValue = intCodeValue Then
                    isRenyuanQuyuTexing = True
                End If
            Catch ex As Exception
            End Try

        End Function
        '----------------------------------------------------------------
        ' ����������
        '     ���ݸ���״̬����״̬��
        ' ����ӿڣ�
        '     strValue - ѡ��ֵ
        ' ����ӿڣ�
        '     True - ��
        '     False - ��
        ' ��ע��Ϣ��
        '     ������ 2008-05-19 ���
        '----------------------------------------------------------------
        Public Shared Function getRenyuanQuyuTexing(ByVal strValue As String) As Integer

            getRenyuanQuyuTexing = 0
            Try
                Select Case strValue
                    Case "����"
                        getRenyuanQuyuTexing = enumRenyuanQuyuTexing.GuoNei
                    Case "����"
                        getRenyuanQuyuTexing = enumRenyuanQuyuTexing.GuiQiao
                    Case "���"
                        getRenyuanQuyuTexing = enumRenyuanQuyuTexing.XiangGang
                    Case "����"
                        getRenyuanQuyuTexing = enumRenyuanQuyuTexing.AoMen
                    Case "̨��"
                        getRenyuanQuyuTexing = enumRenyuanQuyuTexing.TaiWan
                    Case "�⼮��Ա"
                        getRenyuanQuyuTexing = enumRenyuanQuyuTexing.WaiJi
                    Case Else
                End Select
            Catch ex As Exception
            End Try

        End Function

        ' ��Ա�����־�б�
        Public Enum enumRenyuanJibieBiaozhi
            FeiGuanliRenyuan = 0
            ZhongcengGuanliRenyuan = 1
            GaocengGuanliRenyuan = 2
        End Enum
        '----------------------------------------------------------------
        ' ����������
        '     ������Ա��������intCodeValue�ж��Ƿ�Ϊ����״̬objenumRenyuanQuyuTexing
        ' ����ӿڣ�
        '     intCodeValue - ��Ա�����־
        '     objenumRenyuanJibieBiaozhi - ������Ա�����־
        ' ����ӿڣ�
        '     True - ��
        '     False - ��
        ' ��ע��Ϣ��
        '     ������ 2008-05-19 ���
        '----------------------------------------------------------------
        Public Shared Function isRenyuanJibieBiaozhi( _
            ByVal intCodeValue As Integer, _
            ByVal objenumRenyuanJibieBiaozhi As enumRenyuanJibieBiaozhi) As Boolean

            isRenyuanJibieBiaozhi = False
            Try
                Dim intValue As Integer = objenumRenyuanJibieBiaozhi
                If intValue = intCodeValue Then
                    isRenyuanJibieBiaozhi = True
                End If
            Catch ex As Exception
            End Try

        End Function
        '----------------------------------------------------------------
        ' ����������
        '     ���ݸ���״̬����״̬��
        ' ����ӿڣ�
        '     strValue - ѡ��ֵ
        ' ����ӿڣ�
        '     True - ��
        '     False - ��
        ' ��ע��Ϣ��
        '     ������ 2008-05-19 ���
        '----------------------------------------------------------------
        Public Shared Function getRenyuanJibieBiaozhi(ByVal strValue As String) As Integer

            getRenyuanJibieBiaozhi = 0
            Try
                Select Case strValue
                    Case "�ǹ�����Ա"
                        getRenyuanJibieBiaozhi = enumRenyuanJibieBiaozhi.FeiGuanliRenyuan
                    Case "�в������Ա"
                        getRenyuanJibieBiaozhi = enumRenyuanJibieBiaozhi.ZhongcengGuanliRenyuan
                    Case "�߲������Ա"
                        getRenyuanJibieBiaozhi = enumRenyuanJibieBiaozhi.GaocengGuanliRenyuan
                    Case Else
                End Select
            Catch ex As Exception
            End Try

        End Function









        '----------------------------------------------------------------
        '������DataTable���뵽DataSet��
        '----------------------------------------------------------------
        Public Function appendDataTable(ByVal table As System.Data.DataTable) As String

            Dim strErrMsg As String = ""

            Try
                Me.Tables.Add(table)
            Catch ex As Exception
                strErrMsg = ex.Message
            End Try

            appendDataTable = strErrMsg

        End Function

        '----------------------------------------------------------------
        '����ָ�����ʹ���dataTable
        '----------------------------------------------------------------
        Public Function createDataTables( _
            ByRef strErrMsg As String, _
            ByVal enumType As enumTableType) As System.Data.DataTable

            Dim table As System.Data.DataTable

            Select Case enumType
                Case enumTableType.RS_B_JISHUZHICHENG
                    table = createDataTables_JishuZhicheng(strErrMsg)
                Case enumTableType.RS_B_XUELIHUAFEN
                    table = createDataTables_XueliHuafen(strErrMsg)
                Case enumTableType.RS_B_XUEWEIHUAFEN
                    table = createDataTables_XueweiHuafen(strErrMsg)
                Case enumTableType.RS_B_ZHENGZHIMIANMAO
                    table = createDataTables_ZhengzhiMianmao(strErrMsg)
                Case enumTableType.RS_B_ZHIYEZIGE
                    table = createDataTables_ZhiyeZige(strErrMsg)
                Case enumTableType.RS_B_BIANDONGYUANYIN
                    table = createDataTables_BiandongYuanyin(strErrMsg)
                Case enumTableType.RS_B_ZHIGONGSHUXING
                    table = createDataTables_ZhigongShuxing(strErrMsg)

                Case enumTableType.RS_B_RENSHIKAPIAN
                    table = createDataTables_RenshiKapian(strErrMsg)
                Case enumTableType.RS_B_JIATINGCHENGYUAN
                    table = createDataTables_JiatingChengyuan(strErrMsg)
                Case enumTableType.RS_B_XUEXIJINGLI
                    table = createDataTables_XuexiJingli(strErrMsg)
                Case enumTableType.RS_B_GONGZUOJINGLI
                    table = createDataTables_GongzuoJingli(strErrMsg)
                Case enumTableType.RS_B_PEIXUNJILU
                    table = createDataTables_PeixunJilu(strErrMsg)
                Case enumTableType.RS_B_RENSHIYIDONG
                    table = createDataTables_RenshiYidong(strErrMsg)
                Case enumTableType.RS_B_LAODONGHETONG
                    table = createDataTables_LaodongHetong(strErrMsg)

                    'zengxianglin 2009-01-07
                Case enumTableType.RS_VT_RYZJYDB
                    table = createDataTables_RS_VT_RYZJYDB(strErrMsg)
                    'zengxianglin 2009-01-07

                    'zengxianglin 2009-01-08
                Case enumTableType.RS_VT_RLZYXXHZB
                    table = createDataTables_RS_VT_RLZYXXHZB(strErrMsg)
                    'zengxianglin 2009-01-08

                    'zengxianglin 2009-01-12
                Case enumTableType.RS_VT_LDHTJMQXB
                    table = createDataTables_RS_VT_LDHTJMQXB(strErrMsg)
                Case enumTableType.RS_VT_LDJJBB
                    table = createDataTables_RS_VT_LDJJBB(strErrMsg)
                Case enumTableType.RS_VT_LDJNBB
                    table = createDataTables_RS_VT_LDJNBB(strErrMsg)
                    'zengxianglin 2009-01-12

                Case Else
                    strErrMsg = "��Ч�ı����ͣ�"
                    table = Nothing
            End Select

            createDataTables = table

        End Function










        '----------------------------------------------------------------
        '����TABLE_RS_B_JISHUZHICHENG
        '----------------------------------------------------------------
        Private Function createDataTables_JishuZhicheng(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_RS_B_JISHUZHICHENG)
                With table.Columns
                    .Add(FIELD_RS_B_JISHUZHICHENG_ZCDM, GetType(System.String))
                    .Add(FIELD_RS_B_JISHUZHICHENG_ZCMC, GetType(System.String))
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_JishuZhicheng = table

        End Function

        '----------------------------------------------------------------
        '����TABLE_RS_B_XUELIHUAFEN
        '----------------------------------------------------------------
        Private Function createDataTables_XueliHuafen(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_RS_B_XUELIHUAFEN)
                With table.Columns
                    .Add(FIELD_RS_B_XUELIHUAFEN_XLDM, GetType(System.String))
                    .Add(FIELD_RS_B_XUELIHUAFEN_XLMC, GetType(System.String))
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_XueliHuafen = table

        End Function

        '----------------------------------------------------------------
        '����TABLE_RS_B_XUEWEIHUAFEN
        '----------------------------------------------------------------
        Private Function createDataTables_XueweiHuafen(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_RS_B_XUEWEIHUAFEN)
                With table.Columns
                    .Add(FIELD_RS_B_XUEWEIHUAFEN_XWDM, GetType(System.String))
                    .Add(FIELD_RS_B_XUEWEIHUAFEN_XWMC, GetType(System.String))
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_XueweiHuafen = table

        End Function

        '----------------------------------------------------------------
        '����TABLE_RS_B_ZHENGZHIMIANMAO
        '----------------------------------------------------------------
        Private Function createDataTables_ZhengzhiMianmao(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_RS_B_ZHENGZHIMIANMAO)
                With table.Columns
                    .Add(FIELD_RS_B_ZHENGZHIMIANMAO_MMDM, GetType(System.String))
                    .Add(FIELD_RS_B_ZHENGZHIMIANMAO_MMMC, GetType(System.String))
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_ZhengzhiMianmao = table

        End Function

        '----------------------------------------------------------------
        '����TABLE_RS_B_ZHIYEZIGE
        '----------------------------------------------------------------
        Private Function createDataTables_ZhiyeZige(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_RS_B_ZHIYEZIGE)
                With table.Columns
                    .Add(FIELD_RS_B_ZHIYEZIGE_ZGDM, GetType(System.String))
                    .Add(FIELD_RS_B_ZHIYEZIGE_ZGMC, GetType(System.String))
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_ZhiyeZige = table

        End Function

        '----------------------------------------------------------------
        '����TABLE_RS_B_BIANDONGYUANYIN
        '----------------------------------------------------------------
        Private Function createDataTables_BiandongYuanyin(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_RS_B_BIANDONGYUANYIN)
                With table.Columns
                    .Add(FIELD_RS_B_BIANDONGYUANYIN_YYDM, GetType(System.String))
                    .Add(FIELD_RS_B_BIANDONGYUANYIN_YYMC, GetType(System.String))
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_BiandongYuanyin = table

        End Function

        '----------------------------------------------------------------
        '����TABLE_RS_B_ZHIGONGSHUXING
        '----------------------------------------------------------------
        Private Function createDataTables_ZhigongShuxing(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_RS_B_ZHIGONGSHUXING)
                With table.Columns
                    .Add(FIELD_RS_B_ZHIGONGSHUXING_SXDM, GetType(System.String))
                    .Add(FIELD_RS_B_ZHIGONGSHUXING_SXMC, GetType(System.String))
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_ZhigongShuxing = table

        End Function








        '----------------------------------------------------------------
        '����TABLE_RS_B_RENSHIKAPIAN
        '----------------------------------------------------------------
        Private Function createDataTables_RenshiKapian(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_RS_B_RENSHIKAPIAN)
                With table.Columns
                    .Add(FIELD_RS_B_RENSHIKAPIAN_WYBS, GetType(System.String))
                    .Add(FIELD_RS_B_RENSHIKAPIAN_RYDM, GetType(System.String))
                    .Add(FIELD_RS_B_RENSHIKAPIAN_XM, GetType(System.String))
                    .Add(FIELD_RS_B_RENSHIKAPIAN_BMDM, GetType(System.String))
                    .Add(FIELD_RS_B_RENSHIKAPIAN_XB, GetType(System.String))
                    .Add(FIELD_RS_B_RENSHIKAPIAN_CSRQ, GetType(System.DateTime))
                    .Add(FIELD_RS_B_RENSHIKAPIAN_RBDWSJ, GetType(System.DateTime))

                    .Add(FIELD_RS_B_RENSHIKAPIAN_YWXM, GetType(System.String))
                    .Add(FIELD_RS_B_RENSHIKAPIAN_SJHM, GetType(System.String))
                    .Add(FIELD_RS_B_RENSHIKAPIAN_ZZDH, GetType(System.String))
                    .Add(FIELD_RS_B_RENSHIKAPIAN_SFZH, GetType(System.String))

                    .Add(FIELD_RS_B_RENSHIKAPIAN_MZ, GetType(System.String))
                    .Add(FIELD_RS_B_RENSHIKAPIAN_JG, GetType(System.String))
                    .Add(FIELD_RS_B_RENSHIKAPIAN_HJDZ, GetType(System.String))
                    .Add(FIELD_RS_B_RENSHIKAPIAN_XZDZ, GetType(System.String))
                    .Add(FIELD_RS_B_RENSHIKAPIAN_YJDZ, GetType(System.String))
                    .Add(FIELD_RS_B_RENSHIKAPIAN_HKZT, GetType(System.Int32))
                    .Add(FIELD_RS_B_RENSHIKAPIAN_RYXPWZ, GetType(System.String))

                    .Add(FIELD_RS_B_RENSHIKAPIAN_HYZK, GetType(System.Int32))
                    .Add(FIELD_RS_B_RENSHIKAPIAN_SYZK, GetType(System.Int32))

                    .Add(FIELD_RS_B_RENSHIKAPIAN_XXLX, GetType(System.String))
                    .Add(FIELD_RS_B_RENSHIKAPIAN_ZGXL, GetType(System.String))
                    .Add(FIELD_RS_B_RENSHIKAPIAN_ZGXW, GetType(System.String))
                    .Add(FIELD_RS_B_RENSHIKAPIAN_BYYX, GetType(System.String))
                    .Add(FIELD_RS_B_RENSHIKAPIAN_BYZY, GetType(System.String))
                    .Add(FIELD_RS_B_RENSHIKAPIAN_BYSJ, GetType(System.DateTime))

                    .Add(FIELD_RS_B_RENSHIKAPIAN_CJGZSJ, GetType(System.DateTime))
                    'zengxianglin 2009-01-12
                    .Add(FIELD_RS_B_RENSHIKAPIAN_TXSJ, GetType(System.DateTime))
                    'zengxianglin 2009-01-12
                    .Add(FIELD_RS_B_RENSHIKAPIAN_ZCQDSJ, GetType(System.DateTime))
                    'zengxianglin 2009-01-07
                    .Add(FIELD_RS_B_RENSHIKAPIAN_ZGQDSJ, GetType(System.DateTime))
                    'zengxianglin 2009-01-07
                    .Add(FIELD_RS_B_RENSHIKAPIAN_JSZC, GetType(System.String))
                    .Add(FIELD_RS_B_RENSHIKAPIAN_ZYZG, GetType(System.String))

                    .Add(FIELD_RS_B_RENSHIKAPIAN_ZZMM, GetType(System.String))
                    .Add(FIELD_RS_B_RENSHIKAPIAN_RDSJ, GetType(System.DateTime))
                    .Add(FIELD_RS_B_RENSHIKAPIAN_ZZGX, GetType(System.String))
                    .Add(FIELD_RS_B_RENSHIKAPIAN_SFGHCY, GetType(System.Int32))
                    .Add(FIELD_RS_B_RENSHIKAPIAN_SFSGGB, GetType(System.Int32))
                    .Add(FIELD_RS_B_RENSHIKAPIAN_RYQYTX, GetType(System.Int32))

                    .Add(FIELD_RS_B_RENSHIKAPIAN_JZQK, GetType(System.Int32))
                    .Add(FIELD_RS_B_RENSHIKAPIAN_ZJZG, GetType(System.String))

                    .Add(FIELD_RS_B_RENSHIKAPIAN_BRSDSZ, GetType(System.Int32))
                    .Add(FIELD_RS_B_RENSHIKAPIAN_SFLDSZ, GetType(System.Int32))
                    .Add(FIELD_RS_B_RENSHIKAPIAN_SFJZGB, GetType(System.Int32))
                    .Add(FIELD_RS_B_RENSHIKAPIAN_GRFYKS, GetType(System.DateTime))
                    .Add(FIELD_RS_B_RENSHIKAPIAN_GRFYJS, GetType(System.DateTime))
                    .Add(FIELD_RS_B_RENSHIKAPIAN_GRFYSM, GetType(System.String))
                    .Add(FIELD_RS_B_RENSHIKAPIAN_CYFYSM, GetType(System.String))
                    .Add(FIELD_RS_B_RENSHIKAPIAN_CYFYZT, GetType(System.Int32))
                    .Add(FIELD_RS_B_RENSHIKAPIAN_GRFYZT, GetType(System.Int32))

                    .Add(FIELD_RS_B_RENSHIKAPIAN_BZXX, GetType(System.String))


                    .Add(FIELD_RS_B_RENSHIKAPIAN_BMMC, GetType(System.String))
                    .Add(FIELD_RS_B_RENSHIKAPIAN_NN, GetType(System.Int32))
                    .Add(FIELD_RS_B_RENSHIKAPIAN_HKZTMC, GetType(System.String))
                    .Add(FIELD_RS_B_RENSHIKAPIAN_HYZKMC, GetType(System.String))
                    .Add(FIELD_RS_B_RENSHIKAPIAN_SYZKMC, GetType(System.String))
                    .Add(FIELD_RS_B_RENSHIKAPIAN_ZGXLMC, GetType(System.String))
                    .Add(FIELD_RS_B_RENSHIKAPIAN_ZGXWMC, GetType(System.String))
                    .Add(FIELD_RS_B_RENSHIKAPIAN_JSZCMC, GetType(System.String))
                    .Add(FIELD_RS_B_RENSHIKAPIAN_ZYZGMC, GetType(System.String))
                    .Add(FIELD_RS_B_RENSHIKAPIAN_ZZMMMC, GetType(System.String))
                    .Add(FIELD_RS_B_RENSHIKAPIAN_SFGHCYMC, GetType(System.String))
                    .Add(FIELD_RS_B_RENSHIKAPIAN_SFSGGBMC, GetType(System.String))
                    .Add(FIELD_RS_B_RENSHIKAPIAN_RYQYTXMC, GetType(System.String))
                    .Add(FIELD_RS_B_RENSHIKAPIAN_JZQKMC, GetType(System.String))
                    .Add(FIELD_RS_B_RENSHIKAPIAN_BRSDSZMC, GetType(System.String))
                    .Add(FIELD_RS_B_RENSHIKAPIAN_SFLDSZMC, GetType(System.String))
                    .Add(FIELD_RS_B_RENSHIKAPIAN_SFJZGBMC, GetType(System.String))
                    .Add(FIELD_RS_B_RENSHIKAPIAN_CYFYZTMC, GetType(System.String))
                    .Add(FIELD_RS_B_RENSHIKAPIAN_GRFYZTMC, GetType(System.String))
                    .Add(FIELD_RS_B_RENSHIKAPIAN_DRZW, GetType(System.String))
                    .Add(FIELD_RS_B_RENSHIKAPIAN_ZJDM, GetType(System.String))
                    .Add(FIELD_RS_B_RENSHIKAPIAN_ZJMC, GetType(System.String))

                    .Add(FIELD_RS_B_RENSHIKAPIAN_SFZZ, GetType(System.String))
                    .Add(FIELD_RS_B_RENSHIKAPIAN_ZZSJ, GetType(System.DateTime))
                    .Add(FIELD_RS_B_RENSHIKAPIAN_ZZZW, GetType(System.String))
                    .Add(FIELD_RS_B_RENSHIKAPIAN_ZNSL, GetType(System.Int32))
                    .Add(FIELD_RS_B_RENSHIKAPIAN_LZYY, GetType(System.String))
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_RenshiKapian = table

        End Function

        '----------------------------------------------------------------
        '����TABLE_RS_B_JIATINGCHENGYUAN
        '----------------------------------------------------------------
        Private Function createDataTables_JiatingChengyuan(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_RS_B_JIATINGCHENGYUAN)
                With table.Columns
                    .Add(FIELD_RS_B_JIATINGCHENGYUAN_WYBS, GetType(System.String))
                    .Add(FIELD_RS_B_JIATINGCHENGYUAN_RYDM, GetType(System.String))

                    .Add(FIELD_RS_B_JIATINGCHENGYUAN_CYXM, GetType(System.String))
                    .Add(FIELD_RS_B_JIATINGCHENGYUAN_XYGX, GetType(System.String))
                    .Add(FIELD_RS_B_JIATINGCHENGYUAN_CSNY, GetType(System.String))
                    .Add(FIELD_RS_B_JIATINGCHENGYUAN_FWDW, GetType(System.String))
                    .Add(FIELD_RS_B_JIATINGCHENGYUAN_DRZW, GetType(System.String))
                    .Add(FIELD_RS_B_JIATINGCHENGYUAN_XJDZ, GetType(System.String))
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_JiatingChengyuan = table

        End Function

        '----------------------------------------------------------------
        '����TABLE_RS_B_XUEXIJINGLI
        '----------------------------------------------------------------
        Private Function createDataTables_XuexiJingli(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_RS_B_XUEXIJINGLI)
                With table.Columns
                    .Add(FIELD_RS_B_XUEXIJINGLI_WYBS, GetType(System.String))
                    .Add(FIELD_RS_B_XUEXIJINGLI_RYDM, GetType(System.String))

                    'zengxianglin 2009-01-12
                    '.Add(FIELD_RS_B_XUEXIJINGLI_KSNY, GetType(System.String))
                    '.Add(FIELD_RS_B_XUEXIJINGLI_ZZNY, GetType(System.String))
                    .Add(FIELD_RS_B_XUEXIJINGLI_KSNY, GetType(System.DateTime))
                    .Add(FIELD_RS_B_XUEXIJINGLI_ZZNY, GetType(System.DateTime))
                    'zengxianglin 2009-01-12
                    .Add(FIELD_RS_B_XUEXIJINGLI_XXLX, GetType(System.String))
                    .Add(FIELD_RS_B_XUEXIJINGLI_XXYX, GetType(System.String))
                    .Add(FIELD_RS_B_XUEXIJINGLI_XXZY, GetType(System.String))
                    .Add(FIELD_RS_B_XUEXIJINGLI_XXJG, GetType(System.String))
                    .Add(FIELD_RS_B_XUEXIJINGLI_BZXX, GetType(System.String))
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_XuexiJingli = table

        End Function

        '----------------------------------------------------------------
        '����TABLE_RS_B_GONGZUOJINGLI
        '----------------------------------------------------------------
        Private Function createDataTables_GongzuoJingli(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_RS_B_GONGZUOJINGLI)
                With table.Columns
                    .Add(FIELD_RS_B_GONGZUOJINGLI_WYBS, GetType(System.String))
                    .Add(FIELD_RS_B_GONGZUOJINGLI_RYDM, GetType(System.String))

                    .Add(FIELD_RS_B_GONGZUOJINGLI_KSNY, GetType(System.String))
                    .Add(FIELD_RS_B_GONGZUOJINGLI_ZZNY, GetType(System.String))
                    .Add(FIELD_RS_B_GONGZUOJINGLI_FWDW, GetType(System.String))
                    .Add(FIELD_RS_B_GONGZUOJINGLI_DRZW, GetType(System.String))
                    .Add(FIELD_RS_B_GONGZUOJINGLI_BZXX, GetType(System.String))
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_GongzuoJingli = table

        End Function

        '----------------------------------------------------------------
        '����TABLE_RS_B_PEIXUNJILU
        '----------------------------------------------------------------
        Private Function createDataTables_PeixunJilu(ByRef strErrMsg As String) As System.Data.DataTable


            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_RS_B_PEIXUNJILU)
                With table.Columns
                    .Add(FIELD_RS_B_PEIXUNJILU_WYBS, GetType(System.String))
                    .Add(FIELD_RS_B_PEIXUNJILU_RYDM, GetType(System.String))

                    .Add(FIELD_RS_B_PEIXUNJILU_PXMC, GetType(System.String))
                    .Add(FIELD_RS_B_PEIXUNJILU_KSSJ, GetType(System.DateTime))
                    .Add(FIELD_RS_B_PEIXUNJILU_ZZSJ, GetType(System.DateTime))
                    .Add(FIELD_RS_B_PEIXUNJILU_NBPX, GetType(System.Int32))
                    .Add(FIELD_RS_B_PEIXUNJILU_PXXG, GetType(System.String))
                    .Add(FIELD_RS_B_PEIXUNJILU_BZXX, GetType(System.String))
                    .Add(FIELD_RS_B_PEIXUNJILU_PXKS, GetType(System.Int32))


                    .Add(FIELD_RS_B_PEIXUNJILU_RYMC, GetType(System.String))
                    .Add(FIELD_RS_B_PEIXUNJILU_NBPXMC, GetType(System.String))
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_PeixunJilu = table

        End Function

        '----------------------------------------------------------------
        '����TABLE_RS_B_RENSHIYIDONG
        '----------------------------------------------------------------
        Private Function createDataTables_RenshiYidong(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_RS_B_RENSHIYIDONG)
                With table.Columns
                    .Add(FIELD_RS_B_RENSHIYIDONG_WYBS, GetType(System.String))
                    .Add(FIELD_RS_B_RENSHIYIDONG_RYDM, GetType(System.String))
                    .Add(FIELD_RS_B_RENSHIYIDONG_KSSJ, GetType(System.DateTime))
                    .Add(FIELD_RS_B_RENSHIYIDONG_ZZSJ, GetType(System.DateTime))
                    .Add(FIELD_RS_B_RENSHIYIDONG_GLBS, GetType(System.String))
                    .Add(FIELD_RS_B_RENSHIYIDONG_BDYY, GetType(System.String))
                    .Add(FIELD_RS_B_RENSHIYIDONG_RZDW, GetType(System.String))
                    .Add(FIELD_RS_B_RENSHIYIDONG_RZJB, GetType(System.String))
                    .Add(FIELD_RS_B_RENSHIYIDONG_JBBZ, GetType(System.Int32))
                    .Add(FIELD_RS_B_RENSHIYIDONG_FGGZ, GetType(System.String))
                    .Add(FIELD_RS_B_RENSHIYIDONG_ZGSX, GetType(System.String))
                    .Add(FIELD_RS_B_RENSHIYIDONG_GWSX, GetType(System.Int32))
                    .Add(FIELD_RS_B_RENSHIYIDONG_YRDW, GetType(System.String))
                    .Add(FIELD_RS_B_RENSHIYIDONG_YRJB, GetType(System.String))
                    .Add(FIELD_RS_B_RENSHIYIDONG_BZXX, GetType(System.String))
                    'zengxianglin 2008-10-14
                    .Add(FIELD_RS_B_RENSHIYIDONG_SSFZ, GetType(System.String))
                    .Add(FIELD_RS_B_RENSHIYIDONG_YSFZ, GetType(System.String))
                    'zengxianglin 2008-10-14
                    'zengxianglin 2010-01-06
                    .Add(FIELD_RS_B_RENSHIYIDONG_YGSX, GetType(System.Int32))
                    .Add(FIELD_RS_B_RENSHIYIDONG_YZSX, GetType(System.String))
                    .Add(FIELD_RS_B_RENSHIYIDONG_BCZB, GetType(System.Int32))
                    .Add(FIELD_RS_B_RENSHIYIDONG_SCZB, GetType(System.Int32))
                    .Add(FIELD_RS_B_RENSHIYIDONG_XSTD, GetType(System.Int32))
                    .Add(FIELD_RS_B_RENSHIYIDONG_YSTD, GetType(System.Int32))
                    'zengxianglin 2010-01-06

                    .Add(FIELD_RS_B_RENSHIYIDONG_RYMC, GetType(System.String))
                    .Add(FIELD_RS_B_RENSHIYIDONG_BDYYMC, GetType(System.String))
                    .Add(FIELD_RS_B_RENSHIYIDONG_RZDWMC, GetType(System.String))
                    .Add(FIELD_RS_B_RENSHIYIDONG_ZGSXMC, GetType(System.String))
                    .Add(FIELD_RS_B_RENSHIYIDONG_GWSXMC, GetType(System.String))
                    .Add(FIELD_RS_B_RENSHIYIDONG_YRDWMC, GetType(System.String))
                    .Add(FIELD_RS_B_RENSHIYIDONG_JBBZMC, GetType(System.String))
                    'zengxianglin 2010-01-06
                    .Add(FIELD_RS_B_RENSHIYIDONG_YGSXMC, GetType(System.String))
                    .Add(FIELD_RS_B_RENSHIYIDONG_YZSXMC, GetType(System.String))
                    'zengxianglin 2010-01-06
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_RenshiYidong = table

        End Function

        '----------------------------------------------------------------
        '����TABLE_RS_B_LAODONGHETONG
        '----------------------------------------------------------------
        Private Function createDataTables_LaodongHetong(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_RS_B_LAODONGHETONG)
                With table.Columns
                    .Add(FIELD_RS_B_LAODONGHETONG_WYBS, GetType(System.String))
                    .Add(FIELD_RS_B_LAODONGHETONG_RYDM, GetType(System.String))

                    .Add(FIELD_RS_B_LAODONGHETONG_KSSJ, GetType(System.DateTime))
                    .Add(FIELD_RS_B_LAODONGHETONG_JSSJ, GetType(System.DateTime))
                    'zengxianglin 2009-01-12
                    .Add(FIELD_RS_B_LAODONGHETONG_SYKS, GetType(System.DateTime))
                    .Add(FIELD_RS_B_LAODONGHETONG_SYJS, GetType(System.DateTime))
                    'zengxianglin 2009-01-12

                    .Add(FIELD_RS_B_LAODONGHETONG_HTLX, GetType(System.Int32))
                    .Add(FIELD_RS_B_LAODONGHETONG_SFXY, GetType(System.Int32))

                    .Add(FIELD_RS_B_LAODONGHETONG_HTWJ, GetType(System.String))


                    .Add(FIELD_RS_B_LAODONGHETONG_RYMC, GetType(System.String))
                    .Add(FIELD_RS_B_LAODONGHETONG_HTLXMC, GetType(System.String))
                    .Add(FIELD_RS_B_LAODONGHETONG_SFXYMC, GetType(System.String))
                    .Add(FIELD_RS_B_LAODONGHETONG_HTWJMC, GetType(System.String))
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_LaodongHetong = table

        End Function

        'zengxianglin 2009-01-07
        '----------------------------------------------------------------
        '����TABLE_RS_VT_RYZJYDB
        '----------------------------------------------------------------
        Private Function createDataTables_RS_VT_RYZJYDB(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_RS_VT_RYZJYDB)
                With table.Columns
                    '***************************************************************************
                    .Add(FIELD_RS_VT_RYZJYDB_TJNY, GetType(System.Int32))
                    .Add(FIELD_RS_VT_RYZJYDB_JLXH, GetType(System.Int32))
                    '***************************************************************************
                    .Add(FIELD_RS_VT_RYZJYDB_RZXM, GetType(System.String))
                    .Add(FIELD_RS_VT_RYZJYDB_RZRQ, GetType(System.DateTime))
                    .Add(FIELD_RS_VT_RYZJYDB_RZBM, GetType(System.String))
                    .Add(FIELD_RS_VT_RYZJYDB_RZZJ, GetType(System.String))
                    '***************************************************************************
                    .Add(FIELD_RS_VT_RYZJYDB_LZXM, GetType(System.String))
                    .Add(FIELD_RS_VT_RYZJYDB_LZJCHT, GetType(System.Int32))
                    .Add(FIELD_RS_VT_RYZJYDB_LZQMZZ, GetType(System.Int32))
                    .Add(FIELD_RS_VT_RYZJYDB_LZDC, GetType(System.Int32))
                    .Add(FIELD_RS_VT_RYZJYDB_LZTX, GetType(System.Int32))
                    .Add(FIELD_RS_VT_RYZJYDB_LZSW, GetType(System.Int32))
                    .Add(FIELD_RS_VT_RYZJYDB_LZQT, GetType(System.Int32))
                    .Add(FIELD_RS_VT_RYZJYDB_LZRQ, GetType(System.DateTime))
                    .Add(FIELD_RS_VT_RYZJYDB_LZBM, GetType(System.String))
                    '***************************************************************************
                    .Add(FIELD_RS_VT_RYZJYDB_SXXM, GetType(System.String))
                    .Add(FIELD_RS_VT_RYZJYDB_SXYX, GetType(System.String))
                    .Add(FIELD_RS_VT_RYZJYDB_SXRQ, GetType(System.DateTime))
                    .Add(FIELD_RS_VT_RYZJYDB_SXBM, GetType(System.String))
                    '***************************************************************************
                    .Add(FIELD_RS_VT_RYZJYDB_YDXM, GetType(System.String))
                    .Add(FIELD_RS_VT_RYZJYDB_YDRQ, GetType(System.DateTime))
                    .Add(FIELD_RS_VT_RYZJYDB_YDXBM, GetType(System.String))
                    .Add(FIELD_RS_VT_RYZJYDB_YDXZJ, GetType(System.String))
                    .Add(FIELD_RS_VT_RYZJYDB_YDYBM, GetType(System.String))
                    .Add(FIELD_RS_VT_RYZJYDB_YDYZJ, GetType(System.String))
                    .Add(FIELD_RS_VT_RYZJYDB_YDZZ, GetType(System.Int32))
                    .Add(FIELD_RS_VT_RYZJYDB_YDCQCJ, GetType(System.Int32))
                    '***************************************************************************
                    .Add(FIELD_RS_VT_RYZJYDB_YDSBZY, GetType(System.Int32))
                    .Add(FIELD_RS_VT_RYZJYDB_YDSBJY, GetType(System.Int32))
                    .Add(FIELD_RS_VT_RYZJYDB_YDKJGJJ, GetType(System.Int32))
                    .Add(FIELD_RS_VT_RYZJYDB_YDTJGJJ, GetType(System.Int32))
                    .Add(FIELD_RS_VT_RYZJYDB_YDPXQK, GetType(System.String))
                    '***************************************************************************
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_RS_VT_RYZJYDB = table

        End Function
        'zengxianglin 2009-01-07

        'zengxianglin 2009-01-08
        '----------------------------------------------------------------
        '����TABLE_RS_VT_RLZYXXHZB
        '----------------------------------------------------------------
        Private Function createDataTables_RS_VT_RLZYXXHZB(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_RS_VT_RLZYXXHZB)
                With table.Columns
                    '***************************************************************************
                    .Add(FIELD_RS_VT_RLZYXXHZB_DWDM, GetType(System.String))
                    .Add(FIELD_RS_VT_RLZYXXHZB_DWMC, GetType(System.String))
                    .Add(FIELD_RS_VT_RLZYXXHZB_DWXH, GetType(System.Int32))
                    '***************************************************************************
                    .Add(FIELD_RS_VT_RLZYXXHZB_RZRS, GetType(System.Int32))
                    .Add(FIELD_RS_VT_RLZYXXHZB_DRRS, GetType(System.Int32))
                    .Add(FIELD_RS_VT_RLZYXXHZB_DCRS, GetType(System.Int32))
                    .Add(FIELD_RS_VT_RLZYXXHZB_LZRS, GetType(System.Int32))
                    '***************************************************************************
                    .Add(FIELD_RS_VT_RLZYXXHZB_PJRSY, GetType(System.Double))
                    .Add(FIELD_RS_VT_RLZYXXHZB_PJRSJ, GetType(System.Double))
                    .Add(FIELD_RS_VT_RLZYXXHZB_PJRSN, GetType(System.Double))
                    '***************************************************************************
                    .Add(FIELD_RS_VT_RLZYXXHZB_DWCSY, GetType(System.Double))
                    .Add(FIELD_RS_VT_RLZYXXHZB_DWCSJ, GetType(System.Double))
                    .Add(FIELD_RS_VT_RLZYXXHZB_DWCSN, GetType(System.Double))
                    '***************************************************************************
                    .Add(FIELD_RS_VT_RLZYXXHZB_PJCSY, GetType(System.Double))
                    .Add(FIELD_RS_VT_RLZYXXHZB_PJCSJ, GetType(System.Double))
                    .Add(FIELD_RS_VT_RLZYXXHZB_PJCSN, GetType(System.Double))
                    '***************************************************************************
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_RS_VT_RLZYXXHZB = table

        End Function
        'zengxianglin 2009-01-08

        'zengxianglin 2009-01-12
        '----------------------------------------------------------------
        '����TABLE_RS_VT_LDHTJMQXB
        '----------------------------------------------------------------
        Private Function createDataTables_RS_VT_LDHTJMQXB(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_RS_VT_LDHTJMQXB)
                With table.Columns
                    '***************************************************************************
                    .Add(FIELD_RS_VT_LDHTJMQXB_JLXH, GetType(System.Int32))
                    .Add(FIELD_RS_VT_LDHTJMQXB_TJNY, GetType(System.Int32))
                    '***************************************************************************
                    .Add(FIELD_RS_VT_LDHTJMQXB_SLBRYDM, GetType(System.String))
                    .Add(FIELD_RS_VT_LDHTJMQXB_SLBRYMC, GetType(System.String))
                    .Add(FIELD_RS_VT_LDHTJMQXB_SLBHTQX, GetType(System.String))
                    .Add(FIELD_RS_VT_LDHTJMQXB_SLBXYQK, GetType(System.String))
                    .Add(FIELD_RS_VT_LDHTJMQXB_SLBRZSJ, GetType(System.DateTime))
                    '***************************************************************************
                    .Add(FIELD_RS_VT_LDHTJMQXB_FHRYDM, GetType(System.String))
                    .Add(FIELD_RS_VT_LDHTJMQXB_FHRYMC, GetType(System.String))
                    .Add(FIELD_RS_VT_LDHTJMQXB_FHHTQX, GetType(System.String))
                    .Add(FIELD_RS_VT_LDHTJMQXB_FHXYQK, GetType(System.String))
                    .Add(FIELD_RS_VT_LDHTJMQXB_FHRZSJ, GetType(System.DateTime))
                    '***************************************************************************
                    .Add(FIELD_RS_VT_LDHTJMQXB_ZBRYDM, GetType(System.String))
                    .Add(FIELD_RS_VT_LDHTJMQXB_ZBRYMC, GetType(System.String))
                    .Add(FIELD_RS_VT_LDHTJMQXB_ZBHTQX, GetType(System.String))
                    .Add(FIELD_RS_VT_LDHTJMQXB_ZBXYQK, GetType(System.String))
                    .Add(FIELD_RS_VT_LDHTJMQXB_ZBRZSJ, GetType(System.DateTime))
                    .Add(FIELD_RS_VT_LDHTJMQXB_ZBGWQX, GetType(System.String))
                    '***************************************************************************
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_RS_VT_LDHTJMQXB = table

        End Function
        'zengxianglin 2009-01-12

        'zengxianglin 2009-01-12
        '----------------------------------------------------------------
        '����TABLE_RS_VT_LDJJBB
        '----------------------------------------------------------------
        Private Function createDataTables_RS_VT_LDJJBB(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_RS_VT_LDJJBB)
                With table.Columns
                    '***************************************************************************
                    .Add(FIELD_RS_VT_LDJJBB_JLXH, GetType(System.Int32))
                    .Add(FIELD_RS_VT_LDJJBB_TJNJ, GetType(System.Int32))
                    '***************************************************************************
                    .Add(FIELD_RS_VT_LDJJBB_ZBMC, GetType(System.String))
                    .Add(FIELD_RS_VT_LDJJBB_ZBDW, GetType(System.String))
                    .Add(FIELD_RS_VT_LDJJBB_ZBDM, GetType(System.String))
                    '***************************************************************************
                    .Add(FIELD_RS_VT_LDJJBB_BJSJ, GetType(System.Double))
                    .Add(FIELD_RS_VT_LDJJBB_NCZBJZ, GetType(System.Double))
                    '***************************************************************************
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_RS_VT_LDJJBB = table

        End Function
        'zengxianglin 2009-01-12

        'zengxianglin 2009-01-12
        '----------------------------------------------------------------
        '����TABLE_RS_VT_LDJNBB
        '----------------------------------------------------------------
        Private Function createDataTables_RS_VT_LDJNBB(ByRef strErrMsg As String) As System.Data.DataTable

            Dim table As System.Data.DataTable
            Try
                table = New DataTable(TABLE_RS_VT_LDJNBB)
                With table.Columns
                    '***************************************************************************
                    .Add(FIELD_RS_VT_LDJNBB_JLXH, GetType(System.Int32))
                    .Add(FIELD_RS_VT_LDJNBB_TJND, GetType(System.Int32))
                    '***************************************************************************
                    .Add(FIELD_RS_VT_LDJNBB_ZBMC, GetType(System.String))
                    .Add(FIELD_RS_VT_LDJNBB_ZBDW, GetType(System.String))
                    .Add(FIELD_RS_VT_LDJNBB_ZBDM, GetType(System.String))
                    '***************************************************************************
                    .Add(FIELD_RS_VT_LDJNBB_BNSJ, GetType(System.Double))
                    '***************************************************************************
                End With
            Catch ex As Exception
                strErrMsg = ex.Message
                table = Nothing
            End Try
            createDataTables_RS_VT_LDJNBB = table

        End Function
        'zengxianglin 2009-01-12

    End Class 'estateRenshiGeneralData

End Namespace 'Josco.JsKernal.Common.Data
