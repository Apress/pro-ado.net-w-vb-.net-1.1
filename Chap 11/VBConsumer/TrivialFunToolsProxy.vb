﻿'------------------------------------------------------------------------------
' <autogenerated>
'     This code was generated by a tool.
'     Runtime Version: 1.0.3705.0
'
'     Changes to this file may cause incorrect behavior and will be lost if 
'     the code is regenerated.
' </autogenerated>
'------------------------------------------------------------------------------

Option Strict Off
Option Explicit On

Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Xml.Serialization

'
'This source code was auto-generated by wsdl, Version=1.0.3705.0.
'
Namespace VBConsumer.Proxies
    
    '<remarks/>
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Web.Services.WebServiceBindingAttribute(Name:="TrivialFunToolsSoap", [Namespace]:="http://www.dotnetjunkies.com")>  _
    Public Class TrivialFunTools
        Inherits System.Web.Services.Protocols.SoapHttpClientProtocol
        
        '<remarks/>
        Public Sub New()
            MyBase.New
            Dim urlSetting As String = System.Configuration.ConfigurationSettings.AppSettings("TrivialFunToolsUrl")
            If (Not (urlSetting) Is Nothing) Then
                Me.Url = urlSetting
            Else
                Me.Url = "http://localhost/ProADONET/VBProvider/TrivialFunTools.asmx"
            End If
        End Sub
        
        '<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://www.dotnetjunkies.com/RandomNumberGenerator", RequestNamespace:="http://www.dotnetjunkies.com", ResponseNamespace:="http://www.dotnetjunkies.com", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function RandomNumberGenerator(ByVal LowNumber As Integer, ByVal HighNumber As Integer) As Integer
            Dim results() As Object = Me.Invoke("RandomNumberGenerator", New Object() {LowNumber, HighNumber})
            Return CType(results(0),Integer)
        End Function
        
        '<remarks/>
        Public Function BeginRandomNumberGenerator(ByVal LowNumber As Integer, ByVal HighNumber As Integer, ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As System.IAsyncResult
            Return Me.BeginInvoke("RandomNumberGenerator", New Object() {LowNumber, HighNumber}, callback, asyncState)
        End Function
        
        '<remarks/>
        Public Function EndRandomNumberGenerator(ByVal asyncResult As System.IAsyncResult) As Integer
            Dim results() As Object = Me.EndInvoke(asyncResult)
            Return CType(results(0),Integer)
        End Function
    End Class
End Namespace
