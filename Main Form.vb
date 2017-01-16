'Written by Salleh Jahaf
'POS Program written to calculate subtotal, sales tax, and total sale when clerk enters quantity of donuts, bagels, and/or coffee customer buys
'Program v1 completed on 09/14/2015
'Updated on 09/15/2015, program v1.01

Public Class frmMain
    'Declare strClerk variable for clerk's name
    Dim strClerk As String

    'Load prompt for clerk's name
    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Const strPrompt As String = "Enter your name:"
        Const strTitle As String = "Name Entry"

        strClerk = InputBox(strPrompt, strTitle)

        'Output clerk's name to title bar of main form 
        Me.Text = "Order Created By " & strClerk


    End Sub

    'Clear all outputs when text within textboxes are changed
    Private Sub ClearAllOutput(sender As Object, e As EventArgs) Handles txtDonutsOrdered.TextChanged, txtBagelsOrdered.TextChanged, txtCoffeeOrdered.TextChanged
        lblSubtotal.Text = String.Empty
        lblSalesTax.Text = String.Empty
        lblTotalSales.Text = String.Empty

    End Sub

    'process prices and totals
    Private Sub btnCalculate_Click(sender As Object, e As EventArgs) Handles btnCalculate.Click
        Const decDONUT_PRICE As Decimal = 1.09D
        Const decBAGEL_PRICE As Decimal = 0.99D
        Const decCOFFEE_PRICE As Decimal = 1.2D
        Const decTAX_RATE As Decimal = 0.06D 'Tax rate for Michigan
        Dim decPriceOfDonuts As Decimal
        Dim decPriceOfBagels As Decimal
        Dim decPriceOfCoffee As Decimal
        Dim intNumDonuts As Integer
        Dim intNumBagels As Integer
        Dim intNumCoffee As Integer
        Dim decSubtotal As Decimal
        Dim decSalesTax As Decimal
        Dim decTotalSales As Decimal

        'Convert inputs to numbers
        Integer.TryParse(txtDonutsOrdered.Text, intNumDonuts)
        Integer.TryParse(txtBagelsOrdered.Text, intNumBagels)
        Integer.TryParse(txtCoffeeOrdered.Text, intNumCoffee)

        'process prices
        decPriceOfDonuts = intNumDonuts * decDONUT_PRICE
        decPriceOfBagels = intNumBagels * decBAGEL_PRICE
        decPriceOfCoffee = intNumCoffee * decCOFFEE_PRICE
        decSubtotal = decPriceOfDonuts + decPriceOfBagels + decPriceOfCoffee
        decSalesTax = decSubtotal * decTAX_RATE
        decTotalSales = decSubtotal + decSalesTax

        'output
        lblSubtotal.Text = decSubtotal.ToString("C2")
        lblSalesTax.Text = decSalesTax.ToString("C2")
        lblTotalSales.Text = decTotalSales.ToString("C2")


    End Sub

    'Clear all inputs and outputs when clicking Clear button
    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click

        'Clear all fields
        txtDonutsOrdered.Text = String.Empty
        txtBagelsOrdered.Text = String.Empty
        txtCoffeeOrdered.Text = String.Empty
        lblSubtotal.Text = String.Empty
        lblSalesTax.Text = String.Empty
        lblTotalSales.Text = String.Empty

        Call txtDonutsOrdered.Focus()


    End Sub
End Class
