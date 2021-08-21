<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ServiceCharge.aspx.cs" Inherits="PS_ServiceCharge.ServiceCharge" %>

<%@ Register assembly="DevExpress.Web.ASPxPivotGrid.v17.1, Version=17.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPivotGrid" tagprefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <center>
           <%-- <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                <Triggers>

                </Triggers>
                <ContentTemplate>
                    
                        
                   
                </ContentTemplate>
            </asp:UpdatePanel>--%>
           
             <dx:ASPxRoundPanel ID="ASPxRoundPanel2" runat="server" ShowCollapseButton="true" Width="70%" Font-Bold="True" Font-Size="X-Large" ForeColor="Black" HeaderText="ค่าบริการรถตัด" Theme="Material">
                             <PanelCollection>
                                 <dx:PanelContent runat="server">
                                     <dx:ASPxFormLayout ID="ASPxFormLayout2" runat="server" ColCount="2">
                                         <Items>
                                             <dx:LayoutGroup Caption="ค้นหาย้อนหลัง">
                                                 <Items>
                                                     <dx:LayoutItem Caption="วันที่">
                                                         <LayoutItemNestedControlCollection>
                                                             <dx:LayoutItemNestedControlContainer runat="server">
                                                                 <dx:ASPxDateEdit ID="PriceDate" runat="server" AutoPostBack="True" DisplayFormatString="dd/MM/yyyy" EditFormat="Custom" EditFormatString="dd/MM/yyyy">
                                                                     <ClearButton DisplayMode="OnHover">
                                                                     </ClearButton>
                                                                 </dx:ASPxDateEdit>
                                                             </dx:LayoutItemNestedControlContainer>
                                                         </LayoutItemNestedControlCollection>
                                                     </dx:LayoutItem>
                                                 </Items>
                                             </dx:LayoutGroup>
                                             <dx:LayoutGroup Caption="ออกรายงาย" ColCount="3">
                                                 <Items>
                                                     <dx:LayoutItem Caption="วันที่">
                                                         <LayoutItemNestedControlCollection>
                                                             <dx:LayoutItemNestedControlContainer runat="server">
                                                                 <dx:ASPxDateEdit ID="DateS" runat="server" DisplayFormatString="dd/MM/yyyy" EditFormat="Custom" EditFormatString="dd/MM/yyyy">
                                                                 </dx:ASPxDateEdit>
                                                             </dx:LayoutItemNestedControlContainer>
                                                         </LayoutItemNestedControlCollection>
                                                     </dx:LayoutItem>
                                                     <dx:LayoutItem Caption="ถึง">
                                                         <LayoutItemNestedControlCollection>
                                                             <dx:LayoutItemNestedControlContainer runat="server">
                                                                 <dx:ASPxDateEdit ID="DateE" runat="server" DisplayFormatString="dd/MM/yyyy" EditFormat="Custom" EditFormatString="dd/MM/yyyy">
                                                                 </dx:ASPxDateEdit>
                                                             </dx:LayoutItemNestedControlContainer>
                                                         </LayoutItemNestedControlCollection>
                                                     </dx:LayoutItem>
                                                     <dx:LayoutItem Caption="">
                                                         <LayoutItemNestedControlCollection>
                                                             <dx:LayoutItemNestedControlContainer runat="server">
                                                                 <dx:ASPxButton ID="ASPxFormLayout2_E5" runat="server" Text="ออกรายงาน" OnClick="ASPxFormLayout2_E5_Click">
                                                                 </dx:ASPxButton>
                                                             </dx:LayoutItemNestedControlContainer>
                                                         </LayoutItemNestedControlCollection>
                                                     </dx:LayoutItem>
                                                 </Items>
                                             </dx:LayoutGroup>
                                         </Items>
                                     </dx:ASPxFormLayout>
                                     <dx:ASPxGridView ID="ASPxGridView1" runat="server" AutoGenerateColumns="False" EnableTheming="True" OnPageIndexChanged="ASPxGridView1_PageIndexChanged" OnRowCommand="ASPxGridView1_RowCommand" Theme="Material" Width="100%">
                                         <SettingsPager PageSize="50">
                                         </SettingsPager>
                                         <SettingsDataSecurity AllowDelete="False" AllowEdit="False" AllowInsert="False" />
                                         <Columns>
                                             <dx:GridViewBandColumn Caption="รายการรถตัด" ShowInCustomizationForm="True" VisibleIndex="1">
                                                 <HeaderStyle Font-Size="Large" HorizontalAlign="Center" />
                                                 <Columns>
                                                     <dx:GridViewDataTextColumn Caption="ชื่อรถตัด" FieldName="NO_Name" ShowInCustomizationForm="True" VisibleIndex="1">
                                                         <HeaderStyle HorizontalAlign="Center" />
                                                         <CellStyle HorizontalAlign="Center">
                                                         </CellStyle>
                                                     </dx:GridViewDataTextColumn>
                                                     <dx:GridViewDataTextColumn Caption="ราคา" FieldName="NO_Price" ShowInCustomizationForm="True" VisibleIndex="2">
                                                         <HeaderStyle HorizontalAlign="Center" />
                                                         <CellStyle HorizontalAlign="Center">
                                                         </CellStyle>
                                                     </dx:GridViewDataTextColumn>
                                                     <dx:GridViewDataTextColumn Caption="วันที่" FieldName="NO_Date" ShowInCustomizationForm="True" VisibleIndex="3">
                                                         <HeaderStyle HorizontalAlign="Center" />
                                                         <CellStyle HorizontalAlign="Center">
                                                         </CellStyle>
                                                     </dx:GridViewDataTextColumn>
                                                     <dx:GridViewDataButtonEditColumn Caption=" " ShowInCustomizationForm="True" VisibleIndex="4">
                                                         <DataItemTemplate>
                                                             &nbsp; &nbsp;<dx:ASPxButton ID="ASPxButton2" runat="server" CommandName="B" Font-Size="Medium" ForeColor="#FF3300" OnClick="ASPxButton2_Click" RenderMode="Link" Text="ลบ">
                                                             </dx:ASPxButton>
                                                         </DataItemTemplate>
                                                         <HeaderStyle HorizontalAlign="Center" />
                                                         <CellStyle HorizontalAlign="Center">
                                                         </CellStyle>
                                                         <HeaderTemplate>
                                                             <dx:ASPxButton ID="ASPxButton7" runat="server" Font-Size="Medium" ForeColor="#99CC00" OnClick="ASPxButton3_Click" RenderMode="Link" Text="เพิ่มข้อมูล">
                                                             </dx:ASPxButton>
                                                             &nbsp;
                                                             <dx:ASPxButton ID="ASPxButton3" runat="server" CommandName="A" Font-Size="Medium" ForeColor="#99CC00" OnClick="ASPxButton3_Click1" RenderMode="Link" Text="แก้ไข">
                                                             </dx:ASPxButton>
                                                         </HeaderTemplate>
                                                     </dx:GridViewDataButtonEditColumn>
                                                     <dx:GridViewDataTextColumn Caption="รหัส" FieldName="SC_No" ShowInCustomizationForm="True" VisibleIndex="0">
                                                         <HeaderStyle HorizontalAlign="Center" />
                                                         <CellStyle HorizontalAlign="Center">
                                                         </CellStyle>
                                                     </dx:GridViewDataTextColumn>
                                                 </Columns>
                                             </dx:GridViewBandColumn>
                                         </Columns>
                                     </dx:ASPxGridView>
                                     <dx:ASPxPopupControl ID="ASPxPopupControl1" runat="server" HeaderText="" PopupHorizontalAlign="WindowCenter" ShowHeader="False" Theme="Material">
                                         <ContentCollection>
                                             <dx:PopupControlContentControl runat="server">
                                                 <dx:ASPxFormLayout ID="ASPxFormLayout1" runat="server" EnableTheming="True" Theme="Material">
                                                     <Items>
                                                         <dx:LayoutGroup Caption="">
                                                             <Items>
                                                                 <dx:LayoutItem Caption="ชื่อรถตัด">
                                                                     <LayoutItemNestedControlCollection>
                                                                         <dx:LayoutItemNestedControlContainer runat="server">
                                                                             <dx:ASPxTextBox ID="NO_Name" runat="server">
                                                                             </dx:ASPxTextBox>
                                                                         </dx:LayoutItemNestedControlContainer>
                                                                     </LayoutItemNestedControlCollection>
                                                                 </dx:LayoutItem>
                                                                 <dx:LayoutItem Caption="รหัสรถตัด">
                                                                     <LayoutItemNestedControlCollection>
                                                                         <dx:LayoutItemNestedControlContainer runat="server">
                                                                             <dx:ASPxTextBox ID="SC_Notxt" runat="server">
                                                                             </dx:ASPxTextBox>
                                                                         </dx:LayoutItemNestedControlContainer>
                                                                     </LayoutItemNestedControlCollection>
                                                                 </dx:LayoutItem>
                                                                 <dx:LayoutItem Caption="ราคา">
                                                                     <LayoutItemNestedControlCollection>
                                                                         <dx:LayoutItemNestedControlContainer runat="server">
                                                                             <dx:ASPxTextBox ID="NO_Price" runat="server">
                                                                             </dx:ASPxTextBox>
                                                                         </dx:LayoutItemNestedControlContainer>
                                                                     </LayoutItemNestedControlCollection>
                                                                 </dx:LayoutItem>
                                                                 <dx:LayoutItem Caption="วันที่">
                                                                     <LayoutItemNestedControlCollection>
                                                                         <dx:LayoutItemNestedControlContainer runat="server">
                                                                             <dx:ASPxDateEdit ID="NO_Date" runat="server" DisplayFormatString="dd/MM/yyyy" EditFormat="Custom" EditFormatString="dd/MM/yyyy">
                                                                             </dx:ASPxDateEdit>
                                                                         </dx:LayoutItemNestedControlContainer>
                                                                     </LayoutItemNestedControlCollection>
                                                                 </dx:LayoutItem>
                                                                 <dx:LayoutItem Caption="">
                                                                     <LayoutItemNestedControlCollection>
                                                                         <dx:LayoutItemNestedControlContainer runat="server">
                                                                             <dx:ASPxButton ID="ASPxFormLayout1_E4" runat="server" OnClick="ASPxFormLayout1_E4_Click" Text="บันทึก">
                                                                             </dx:ASPxButton>
                                                                         </dx:LayoutItemNestedControlContainer>
                                                                     </LayoutItemNestedControlCollection>
                                                                 </dx:LayoutItem>
                                                             </Items>
                                                         </dx:LayoutGroup>
                                                     </Items>
                                                 </dx:ASPxFormLayout>
                                             </dx:PopupControlContentControl>
                                         </ContentCollection>
                                     </dx:ASPxPopupControl>
                                     <dx:ASPxGridView ID="ASPxGridView2" runat="server" AutoGenerateColumns="False" EnableTheming="True" Theme="Material" Width="100%" OnPageIndexChanged="ASPxGridView2_PageIndexChanged" OnRowCommand="ASPxGridView2_RowCommand">
                                         <SettingsPager PageSize="50">
                                         </SettingsPager>
                                         <Columns>
                                             <dx:GridViewBandColumn Caption="รายการราคารถตัด" ShowInCustomizationForm="True" VisibleIndex="5" Visible="False">
                                                 <HeaderStyle HorizontalAlign="Center" />
                                             </dx:GridViewBandColumn>
                                             <dx:GridViewDataTextColumn Caption="รหัสรถตัด" FieldName="SC_No" ShowInCustomizationForm="True" VisibleIndex="0"> 
                                                  <DataItemTemplate>
                                                     <dx:ASPxTextBox ID="SC_Notxt" runat="server" Text='<%# Eval("SC_No") %>' Width="170px" Enabled="false">
                                                     </dx:ASPxTextBox>
                                                 </DataItemTemplate>
                                                 <HeaderStyle HorizontalAlign="Center" />
                                                 <CellStyle HorizontalAlign="Center">
                                                 </CellStyle>
                                             </dx:GridViewDataTextColumn>
                                             <dx:GridViewDataTextColumn Caption="ชื่อรถตัด" FieldName="NO_Name" ShowInCustomizationForm="True" VisibleIndex="1">
                                                 <DataItemTemplate>
                                                     <dx:ASPxTextBox ID="Nametxt" runat="server" Text='<%# Eval("NO_Name") %>' Width="170px">
                                                     </dx:ASPxTextBox>
                                                 </DataItemTemplate>
                                                 <HeaderStyle HorizontalAlign="Center" />
                                                 <CellStyle HorizontalAlign="Center">
                                                 </CellStyle>
                                             </dx:GridViewDataTextColumn>
                                             <dx:GridViewDataTextColumn Caption="ราคา" FieldName="NO_Price" ShowInCustomizationForm="True" VisibleIndex="3">
                                                 <DataItemTemplate>
                                                     <dx:ASPxTextBox ID="Pricetxt" runat="server" Text='<%# Eval("NO_Price") %>' Width="170px">
                                                     </dx:ASPxTextBox>
                                                 </DataItemTemplate>
                                                 <HeaderStyle HorizontalAlign="Center" />
                                                 <CellStyle HorizontalAlign="Center">
                                                 </CellStyle>
                                             </dx:GridViewDataTextColumn>
                                             <dx:GridViewDataTextColumn Caption="วันที่แก้ไข" FieldName="NO_Date" ShowInCustomizationForm="True" Visible="False" VisibleIndex="2">
                                                 <DataItemTemplate>
                                                     <dx:ASPxDateEdit ID="ASPxDateEdit1" runat="server" DisplayFormatString="dd/mm/yyyy" EditFormat="Custom" EditFormatString="dd/mm/yyyy" EnableTheming="True" Theme="Material">
                                                     </dx:ASPxDateEdit>
                                                 </DataItemTemplate>
                                                 <HeaderStyle HorizontalAlign="Center" />
                                                 <CellStyle HorizontalAlign="Center">
                                                 </CellStyle>
                                             </dx:GridViewDataTextColumn>
                                             <dx:GridViewDataButtonEditColumn ShowInCustomizationForm="True" VisibleIndex="4">
                                                 <DataItemTemplate>
                                                     <dx:ASPxButton ID="ASPxButton5" runat="server" Font-Size="Medium" ForeColor="#99CC00" Height="19px" RenderMode="Link" Text="แก้ไข" Visible="False">
                                                     </dx:ASPxButton>
                                                     &nbsp;
                                                     <dx:ASPxButton ID="ASPxButton6" runat="server" Font-Size="Medium" ForeColor="#FF3300" RenderMode="Link" Text="ลบ" CommandName="B">
                                                     </dx:ASPxButton>
                                                 </DataItemTemplate>
                                                 <HeaderStyle HorizontalAlign="Center" />
                                                 <CellStyle HorizontalAlign="Center">
                                                 </CellStyle>
                                                 <HeaderTemplate>
                                                     <dx:ASPxButton ID="ASPxButton4" runat="server" Font-Size="Medium" ForeColor="#99CC00" OnClick="ASPxButton4_Click" RenderMode="Link" Text="บันทึกข้อมูล">
                                                     </dx:ASPxButton>
                                                 </HeaderTemplate>
                                             </dx:GridViewDataButtonEditColumn>
                                         </Columns>
                                     </dx:ASPxGridView>
                                     &nbsp;<dx:ASPxPivotGrid ID="ASPxPivotGrid1" runat="server" ClientIDMode="AutoID" Width="100%" Visible="False">
                                         <Fields>
                                             <dx:PivotGridField ID="fieldNOPrice" Area="DataArea" AreaIndex="0" FieldName="NO_Price" Name="fieldNOPrice" Caption="ราคา">
                                                 <HeaderStyle Font-Names="Angsana New" />
                                             </dx:PivotGridField>
                                             <dx:PivotGridField ID="fieldNODate1" Area="RowArea" AreaIndex="0" FieldName="NODate" Name="fieldNODate1" ValueFormat-FormatString="dd/MM/yyyy" ValueFormat-FormatType="Custom" Caption="วันที่">
                                                 <HeaderStyle Font-Names="Angsana New" ForeColor="Black" />
                                             </dx:PivotGridField>
                                             <dx:PivotGridField ID="fieldNOName" Area="ColumnArea" AreaIndex="0" FieldName="NO_Name" Name="fieldNOName" Caption="ชื่อ">
                                                 <HeaderStyle Font-Names="Angsana New" BackColor="#CCFF99" ForeColor="Black" />
                                             </dx:PivotGridField>
                                         </Fields>
                                         <OptionsPager RowsPerPage="50">
                                         </OptionsPager>
                                         <OptionsData DataProcessingEngine="LegacyOptimized" />
                                     </dx:ASPxPivotGrid>
                                     <dx:ASPxPivotGridExporter ID="ASPxPivotGridExporter1" runat="server" ASPxPivotGridID="ASPxPivotGrid1" OnCustomExportCell="ASPxPivotGridExporter1_CustomExportCell" OnInit="ASPxPivotGridExporter1_Init">
                                         <OptionsPrint PrintColumnHeaders="True">
                                         </OptionsPrint>
                                     </dx:ASPxPivotGridExporter>
                                     <dx:ASPxGridViewExporter ID="ASPxGridViewExporter1" runat="server" ExportedRowType="All" GridViewID="ASPxGridView1">
                                     </dx:ASPxGridViewExporter>
                                     <dx:ASPxLoadingPanel ID="ASPxLoadingPanel1" runat="server" ClientInstanceName="loadingPanel">
                                     </dx:ASPxLoadingPanel>
                                 </dx:PanelContent>
                             </PanelCollection>
                    </dx:ASPxRoundPanel>
                 </center>
        </div>
    </form>
</body>
</html>
