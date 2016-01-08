Imports System.Runtime.CompilerServices

Public Module ExtensionMethod
    <Extension> Public Function IsBetween(ByVal value As PageSelector, ByVal lowerBound As PageSelector, ByVal upperBound As PageSelector, Optional ByVal includeLowBound As Boolean = False, Optional ByVal includeUpperBound As Boolean = False) As Boolean
        Return (includeLowBound AndAlso value = lowerBound) OrElse (includeUpperBound AndAlso value = upperBound) OrElse (value > lowerBound AndAlso value < upperBound)
    End Function

    <Extension> Public Function IsNullOrEmpty(ByVal dt As DataTable) As Boolean
        Return (dt Is Nothing OrElse dt.Rows.Count <= 0)
    End Function

    <Extension> Function IsNullOrEmpty(ByVal drRows() As DataRow) As Boolean
        Return (drRows Is Nothing OrElse drRows.Count <= 0)
    End Function
End Module
