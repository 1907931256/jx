Imports ITSBase
Imports UIControlLib
Public Class FrmDrugManager
#Region "Member Variable"
    Private _frmDrugDispatchReg As FrmDrugDispatchReg
    Private _frmDrugInReg As FrmDrugInReg
    Private _frmDrugOutReg As FrmDrugOutReg
    Private _frmDrugStockTaking As FrmDrugStockTaking
    Private _frmDrugInOutStatistics As FrmDrugInOutStatistics
    Private _frmDrugConsumeStatistics As FrmDrugConsumeStatistics
#End Region
    Private Sub FrmDrugManager_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.PageManager.Register(New PageEntity With {.AssociateButton = btnDrugDispatch, .PageType = GetType(FrmDrugDispatchReg), .PageHost = Me.pnlMain, .PageGenerator = Me, .PageSelector = PageSelector.DrugDispatch})
        Me.PageManager.Register(New PageEntity With {.AssociateButton = btnDrugIn, .PageIsDefault = True, .PageType = GetType(FrmDrugInReg), .PageHost = Me.pnlMain, .PageGenerator = Me, .PageSelector = PageSelector.DrugStorageIn})
        Me.PageManager.Register(New PageEntity With {.AssociateButton = btnDrugOut, .PageType = GetType(FrmDrugOutReg), .PageHost = Me.pnlMain, .PageGenerator = Me, .PageSelector = PageSelector.DrugStorageOut})
        Me.PageManager.Register(New PageEntity With {.AssociateButton = btnStockTaking, .PageType = GetType(FrmDrugStockTaking), .PageHost = Me.pnlMain, .PageGenerator = Me, .PageSelector = PageSelector.DrugStockTaking})
        Me.PageManager.Register(New PageEntity With {.AssociateButton = btnInOutStatistics, .PageType = GetType(FrmDrugInOutStatistics), .PageHost = Me.pnlMain, .PageGenerator = Me, .PageSelector = PageSelector.DrugInOutStatistics})
        Me.PageManager.Register(New PageEntity With {.AssociateButton = btnConsumeStatistics, .PageType = GetType(FrmDrugConsumeStatistics), .PageHost = Me.pnlMain, .PageGenerator = Me, .PageSelector = PageSelector.DrugConsumeStatistics})
        Me.PageManager.Register(New PageEntity With {.AssociateButton = btnBack, .PageHost = Me.Parent, .PageInstance = Me.Generator})
    End Sub
End Class
