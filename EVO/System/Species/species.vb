Public Class species
    Dim DB As New DataBaseConnection
    Private SpecieID As Integer
    Private SpecieName As String
    Private SpeciePrice As Double
    Private SpecieType As SpeciesType
    Private Is_Availabel As Boolean
    Private SetDate As Date
    Public Sub New(ByVal SpecieId As Integer)

        Dim sql As String = "SELECT * FROM `species` WHERE `Id` = '" + Str(SpecieId) + "'"
        Dim Row As DataRow = DB.executeSQL(sql)(0)
        Me.SpecieID = SpecieId
        Me.Name = Row(1)
        Me.Price = CDbl(Row(2))
        Me.Type = New SpeciesType(Row(3))
        Me.IsAvailabel = CBool(Row(4))




    End Sub




    ReadOnly Property Id As Integer
        Get
            Return Me.SpecieID
        End Get
    End Property

    Property Name As String
        Set(ByVal value As String)
            Me.SpecieName = value
        End Set
        Get
            Return Me.SpecieName
        End Get
    End Property

    Property Price As Double
        Set(ByVal value As Double)
            Me.SpeciePrice = value
        End Set
        Get
            Return Me.SpeciePrice
        End Get
    End Property
    Property AddDate As Date
        Set(ByVal value As Date)
            Me.SetDate = value
        End Set
        Get
            Return Me.SetDate
        End Get
    End Property
    Property Type As SpeciesType
        Set(ByVal value As SpeciesType)
            Me.SpecieType = value
        End Set
        Get
            Return Me.SpecieType
        End Get
    End Property

    Property IsAvailabel As Boolean
        Set(ByVal value As Boolean)
            Me.Is_Availabel = value

        End Set
        Get
            Return Me.Is_Availabel
        End Get
    End Property
    Public Function GetString() As String
        Dim Str As String = String.Format("الطلب  : {0} | {1} | {2}", Me.Name, CStr(Me.Price), Me.Type.Name)
        Return Str
    End Function

    Public Shared Function InsertSpecies(ByVal Name As String, ByVal Price As Double, ByVal type As SpeciesType) As Integer
        Dim DB As New DataBaseConnection
        Dim Sql As String = "INSERT INTO `species` (`id`, `Name`, `Price`, `Type`, `IsAvailabel` ) VALUES (NULL, '" + Name + "', '" + CStr(Price) + "', '" + CStr(type.Id) + "', '1');"
        Return DB.executeDMLSQL(Sql)
    End Function
    Public Function Delete() As Integer
        Dim SQl = "DELETE FROM `species` WHERE `Id` ='" + CStr(Me.Id) + "'"
        Return DB.executeDMLSQL(SQl)
    End Function

    Public Function UpdateSpecies() As Integer

        Dim Sql = "UPDATE `species` SET `Name`='" + Me.Name + "',`Price`='" + CStr(Me.Price) + "',`Type`='" + CStr(Me.Type.Id) + "',`IsAvailabel`='" + CStr(Me.IsAvailabel) + "' WHERE `Id` ='" + Str(Me.Id) + "'"
        Return DB.executeDMLSQL(Sql)
    End Function
End Class

Public Class SpeciesType
    Dim DB As New DataBaseConnection
    Private SpecieTypeID As Integer
    Private SpecieTypeName As String
    Public Sub New(ByVal SpecieTypeId As Integer)
        Dim sql As String = "SELECT * FROM `types` WHERE `Id` = '" + CStr(SpecieTypeId) + "'"
        Dim Row As DataRow = DB.executeSQL(sql)(0)

        Me.SpecieTypeID = SpecieTypeId
        Me.Name = Row(1)

    End Sub
    ReadOnly Property Id As Integer
        Get
            Return Me.SpecieTypeID
        End Get
    End Property

    Property Name As String
        Set(ByVal value As String)
              Me.SpecieTypeName = value
        End Set
        Get
            Return Me.SpecieTypeName
        End Get
    End Property
    Public Shared Function InsertSpecieType(ByVal name As String) As Integer
        Dim DB As New DataBaseConnection
        Dim Sql = "INSERT INTO `types` (`id`, `Name`) VALUES (NULL, '" + name + "');"
        Return DB.executeDMLSQL(Sql)
    End Function
    Public Function Update() As Integer
        Dim sql As String = "UPDATE `types` SET `Name`='" + Me.Name + "' WHERE `id`='" + CStr(Me.Id) + "'"
        Return DB.executeDMLSQL(sql)

    End Function
    Public Function Delete()
        Dim SQl = "DELETE FROM `types` WHERE `Id` ='" + Str(Me.Id) + "'"
        Return DB.executeDMLSQL(SQl)
    End Function
  
End Class

