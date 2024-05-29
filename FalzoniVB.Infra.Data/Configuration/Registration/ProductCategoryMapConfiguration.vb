﻿Imports System.Data.Entity.ModelConfiguration
Imports FalzoniVB.Domain.Entities.Registration

Namespace Configuration.Registration
    Public Class ProductCategoryMapConfiguration
        Inherits EntityTypeConfiguration(Of ProductCategory)

        Public Sub New()
            HasKey(Function(p) p.Id)

            [Property](Function(p) p.Name).IsRequired().HasMaxLength(512)

            [Property](Function(p) p.Created).IsRequired()

            [Property](Function(p) p.Modified).IsOptional()
        End Sub
    End Class
End Namespace
