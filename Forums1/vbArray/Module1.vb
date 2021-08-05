Module Module1

    Sub Main()
        For Each retunedLicence In LicenceCollection.Entities
            Globals.clsGlobals.WrtietoErrorLog(retunedLicence.GetAttributeValue(Of EntityReference)("new__licenceid").Id.ToString)
        Next
    End Sub

End Module
