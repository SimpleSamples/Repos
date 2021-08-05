Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks

'Want a challenge III
' https://social.msdn.microsoft.com/Forums/en-US/06610ab7-9fd4-416d-aba7-95d0906d6dae/want-a-challenge-iii?forum=vbgeneral

Namespace ChallengeIII
	Public Class Product
		Implements IEquatable(Of Product)

		Public Property ProductName() As String
		Public Property CategoryIdentifier() As Integer

		Public Overrides Function GetHashCode() As Integer
			Return Me.ProductName.GetHashCode() + CategoryIdentifier
		End Function

		Public Overrides Function Equals(ByVal obj As Object) As Boolean
			If Not (TypeOf obj Is Product) Then
				Return False
			End If
			Return Equals(DirectCast(obj, Product))
		End Function

        Public Overloads Function Equals(ByVal other As Product) As Boolean Implements IEquatable(Of Product).Equals
            If ProductName <> other.ProductName Then
                Return False
            End If
            Return CategoryIdentifier = other.CategoryIdentifier
        End Function

        Public Shared Operator =(ByVal product1 As Product, ByVal product2 As Product) As Boolean
			Return product1.Equals(product2)
		End Operator

		Public Shared Operator <>(ByVal product1 As Product, ByVal product2 As Product) As Boolean
			Return Not product1.Equals(product2)
		End Operator
	End Class

	Friend Class Program

		Shared Sub Main(ByVal args() As String)
			Dim products As New List(Of Product)() From {
				New Product() With {
					.CategoryIdentifier = 5,
					.ProductName = "Apples"
				},
				New Product() With {
					.CategoryIdentifier = 7,
					.ProductName = "Apples"
				},
				New Product() With {
					.CategoryIdentifier = 5,
					.ProductName = "Apples"
				},
				New Product() With {
					.CategoryIdentifier = 1,
					.ProductName = "Grapes"
				},
				New Product() With {
					.CategoryIdentifier = 11,
					.ProductName = "Bread"
				}
			}

            Dim noDuplicates = products.Distinct() 'As IEnumerable(Of Product)
            For Each product As Product In noDuplicates
				Console.WriteLine($"{product.CategoryIdentifier}, {product.ProductName}")
			Next product
		End Sub
	End Class
End Namespace
