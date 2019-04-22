Imports System
Imports System.Collections.Generic
Imports System.Text
Imports DevExpress.Xpo

Namespace DevExpress.Xpo.ConsoleCoreDemo
	Friend Class StatisticInfo
		Inherits XPLiteObject

        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub
        Private _key As Guid
        <Key(True)>
        Public Property Key() As Guid
            Get
                Return _key
            End Get
            Set(ByVal value As Guid)
                SetPropertyValue(NameOf(Key), _key, value)
            End Set
        End Property
        Private _info As String
        <Size(255)>
        Public Property Info() As String
            Get
                Return _info
            End Get
            Set(ByVal value As String)
                SetPropertyValue(NameOf(Info), _info, value)
            End Set
        End Property
        Private _date As Date
        Public Property [Date]() As Date
			Get
                Return _date
            End Get
			Set(ByVal value As Date)
                SetPropertyValue(NameOf([Date]), _date, value)
            End Set
		End Property
	End Class
End Namespace
