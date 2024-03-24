Imports System.Drawing.Text

Public Class Form1
    Private firstOperand As Double = 0
    Private currentOperator As String = ""
    Private isNewInput As Boolean = True

    Private Sub NumericButton_Click(sender As Object, e As EventArgs) Handles btn0.Click, btn1.Click, btn2.Click, btn3.Click, btn4.Click, btn5.Click, btn6.Click, btn7.Click, btn8.Click, btn9.Click
        Dim button As Button = CType(sender, Button)

        If isNewInput Then
            txtDisplay.Text = button.Text
            isNewInput = False
        Else
            txtDisplay.Text += button.Text
        End If
    End Sub

    Private Sub OperationButton_Click(sender As Object, e As EventArgs) Handles btnAdd.Click, btnSubtract.Click, btnMultiply.Click, btnDivide.Click, btnMod.Click
        Dim button As Button = CType(sender, Button)
        firstOperand = Double.Parse(txtDisplay.Text)
        currentOperator = button.Text
        isNewInput = True
        hasDecimal = False
    End Sub
    Private Sub btnEqual_Click(sender As Object, e As EventArgs) Handles btnEqual.Click
        Dim secondOperand As Double = Double.Parse(txtDisplay.Text)
        Dim result As Double
        Select Case currentOperator
            Case "+"
                result = firstOperand + secondOperand
            Case "-"
                result = firstOperand - secondOperand
            Case "x"
                result = firstOperand * secondOperand
            Case "Mod"
                result = firstOperand Mod secondOperand
            Case "/"
                If secondOperand <> 0 Then
                    result = firstOperand / secondOperand
                Else
                    txtDisplay.Text = "Error"
                    Return
                End If
        End Select

        txtDisplay.Text = result.ToString()

        isNewInput = True
        currentOperator = ""
        firstOperand = 0
        hasDecimal = False
    End Sub
    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        txtDisplay.Text = "0"
        isNewInput = True
        currentOperator = ""
        firstOperand = 0
        hasDecimal = False
    End Sub
    Private hasDecimal As Boolean = False
    Private Sub btnDecimal_Click(sender As Object, e As EventArgs) Handles btnDecimal.Click
        If Not hasDecimal Then
            txtDisplay.Text += "."
            hasDecimal = True
        End If
    End Sub
End Class
