﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:4.0.30319.18063
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On

Imports System

Namespace My.Resources
    
    'This class was auto-generated by the StronglyTypedResourceBuilder
    'class via a tool like ResGen or Visual Studio.
    'To add or remove a member, edit your .ResX file then rerun ResGen
    'with the /str option, or rebuild your VS project.
    '''<summary>
    '''  A strongly-typed resource class, for looking up localized strings, etc.
    '''</summary>
    <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0"),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute(),  _
     Global.Microsoft.VisualBasic.HideModuleNameAttribute()>  _
    Friend Module Resources
        
        Private resourceMan As Global.System.Resources.ResourceManager
        
        Private resourceCulture As Global.System.Globalization.CultureInfo
        
        '''<summary>
        '''  Returns the cached ResourceManager instance used by this class.
        '''</summary>
        <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Friend ReadOnly Property ResourceManager() As Global.System.Resources.ResourceManager
            Get
                If Object.ReferenceEquals(resourceMan, Nothing) Then
                    Dim temp As Global.System.Resources.ResourceManager = New Global.System.Resources.ResourceManager("daqartDLL.Resources", GetType(Resources).Assembly)
                    resourceMan = temp
                End If
                Return resourceMan
            End Get
        End Property
        
        '''<summary>
        '''  Overrides the current thread's CurrentUICulture property for all
        '''  resource lookups using this strongly typed resource class.
        '''</summary>
        <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Friend Property Culture() As Global.System.Globalization.CultureInfo
            Get
                Return resourceCulture
            End Get
            Set
                resourceCulture = value
            End Set
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to 
        '''use [!!dbName!!]
        '''
        '''exec sp_grant_publication_access @publication = N&apos;!!dbName!!&apos;, @login = N&apos;!!MachineName!!\Daqart_Agent&apos;
        '''
        '''.
        '''</summary>
        Friend ReadOnly Property addPAL() As String
            Get
                Return ResourceManager.GetString("addPAL", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to 
        '''use [!!dbName!!]
        '''
        '''exec sp_grant_publication_access @publication = N&apos;!!dbName!!&apos;, @login = N&apos;daqart_sa&apos;
        '''
        '''.
        '''</summary>
        Friend ReadOnly Property addPALSQL() As String
            Get
                Return ResourceManager.GetString("addPALSQL", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to USE [!!dbName!!]
        '''
        '''CREATE USER [!!MachineName!!\Daqart_Agent] FOR LOGIN [!!MachineName!!\Daqart_Agent]
        '''
        '''
        '''.
        '''</summary>
        Friend ReadOnly Property addRoles() As String
            Get
                Return ResourceManager.GetString("addRoles", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to USE [!!dbName!!]
        '''
        '''CREATE USER [daqart_sa] FOR LOGIN [daqart_sa]
        '''
        '''
        '''.
        '''</summary>
        Friend ReadOnly Property addRolesSQL() As String
            Get
                Return ResourceManager.GetString("addRolesSQL", resourceCulture)
            End Get
        End Property
    End Module
End Namespace
