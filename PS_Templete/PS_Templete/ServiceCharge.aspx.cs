using DevExpress.Export;
using DevExpress.Web;
using DevExpress.XtraPrinting;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PS_ServiceCharge
{
    public partial class ServiceCharge : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
            }
            if (PriceDate.Text == "")
            {
                LoadDataDT();
            }
            else
            {
                LoadDataDTP();
            }
           
            ASPxGridView2.Visible = false;
        }

        protected void ASPxButton3_Click(object sender, EventArgs e)
        {
            ASPxPopupControl1.ShowOnPageLoad = true;
        }
        private void LoadDataDT()
        {
            string lvSQL = "Select Distinct SC_No,NO_Name  from Cane_ServiceCharge ";
            DataTable DT = new DataTable();
            DT = GsysSQL.fncGetQueryData(lvSQL, DT);

            DataTable DTnew = new DataTable();
            DTnew.Columns.Add("NO_Name");
            DTnew.Columns.Add("NO_Price");
            DTnew.Columns.Add("NO_Date");
            DTnew.Columns.Add("SC_No");

            for (int i = 0; i < DT.Rows.Count; i++)
            {               
                string Name = DT.Rows[i]["NO_Name"].ToString();
                string Price = GsysSQL.fncCheckPrice(Name);
                string Date = Gstr.fncChangeSDate(GsysSQL.fncCheckDate(Name));
                string SC_No = DT.Rows[i]["SC_No"].ToString();

                DTnew.Rows.Add(new object[] { Name, Price, Date , SC_No });
            }
           
            ASPxGridView1.DataSource = DTnew;
            ASPxGridView1.DataBind();
        }

        private void LoadDataDTAA(string DateS,string DateE)
        {
            string lvSQL = "Select NO_Name,NO_Price, TRY_CONVERT(datetime, NO_Date, 103) AS NODate ,SC_No from Cane_ServiceCharge WHERE NO_Date BETWEEN "+ DateS + "  and "+ DateE + "";
            DataTable DT = new DataTable();
            DT = GsysSQL.fncGetQueryData(lvSQL, DT);            
            ASPxPivotGrid1.DataSource = DT;
            ASPxPivotGrid1.DataBind();
        }

        private void LoadDataDTP()
        {
            string lvSQL = "Select Distinct * from Cane_ServiceCharge  WHERE NO_Date ='" + Gstr.fncChangeTDate(PriceDate.Text) + "'";
            DataTable DT = new DataTable();
            DT = GsysSQL.fncGetQueryData(lvSQL, DT);

            DataTable DTnew = new DataTable();
            DTnew.Columns.Add("NO_Name");
            DTnew.Columns.Add("NO_Price");
            DTnew.Columns.Add("NO_Date");
            DTnew.Columns.Add("SC_No");

            for (int i = 0; i < DT.Rows.Count; i++)
            {
                string Name = DT.Rows[i]["NO_Name"].ToString();
                string Price = DT.Rows[i]["NO_Price"].ToString();
                string Date = Gstr.fncChangeSDate(DT.Rows[i]["NO_Date"].ToString());
                string SC_No = DT.Rows[i]["SC_No"].ToString();

                DTnew.Rows.Add(new object[] { Name, Price, Date, SC_No });
            }

            ASPxGridView1.DataSource = DTnew;
            ASPxGridView1.DataBind();
        }
        private void LoadDataDT2()
        {
            string lvSQL = "Select Distinct SC_No,NO_Name from Cane_ServiceCharge ";

            DataTable DT = new DataTable();
            DT = GsysSQL.fncGetQueryData(lvSQL, DT);

            DataTable DTnew = new DataTable();
            DTnew.Columns.Add("SC_No");
            DTnew.Columns.Add("NO_Name");
            DTnew.Columns.Add("NO_Price");
            DTnew.Columns.Add("NO_Date");
           

            for (int i = 0; i < DT.Rows.Count; i++)
            { 

                //GridViewDataColumn NO_Name = ASPxGridView2.Columns["NO_Name"] as GridViewDataColumn;
                //ASPxTextBox TxTNO_Name = ASPxGridView2.FindRowCellTemplateControl(i, NO_Name, "Nametxt") as ASPxTextBox;

                //GridViewDataColumn NO_Price = ASPxGridView2.Columns["NO_Price"] as GridViewDataColumn;
                //ASPxTextBox TxtPrice = ASPxGridView2.FindRowCellTemplateControl(i, NO_Price, "Pricetxt") as ASPxTextBox;

                //GridViewDataColumn NO_Date = ASPxGridView2.Columns["NO_Date"] as GridViewDataColumn;
                //ASPxTextBox TxtDate = ASPxGridView2.FindRowCellTemplateControl(i, NO_Date, "Datetxt") as ASPxTextBox;

                //GridViewDataColumn SC_No = ASPxGridView2.Columns["SC_No"] as GridViewDataColumn;
                //ASPxTextBox TxtSC_No = ASPxGridView2.FindRowCellTemplateControl(i, SC_No, "SC_Notxt") as ASPxTextBox;


                string Name = DT.Rows[i]["NO_Name"].ToString();
                string Price = GsysSQL.fncCheckPrice(Name);
                string Date = "";
                string ID = DT.Rows[i]["SC_No"].ToString();

                DTnew.Rows.Add(new object[] { ID, Name, Price, Date});
            }
            ASPxGridView2.DataSource = DTnew;
            ASPxGridView2.DataBind();
        }
        protected void ASPxFormLayout1_E4_Click(object sender, EventArgs e)
        {
            string SC = GsysSQL.fncCheckID(NO_Name.Text, Gstr.fncChangeTDate(NO_Date.Text), SC_Notxt.Text);
            if (SC!="")
            {
                string lvSQL = "UPDATE  Cane_ServiceCharge SET NO_Name='"+ NO_Name.Text + "',NO_Price='" + NO_Price.Text + "' WHERE NO_Date='"+ Gstr.fncChangeTDate(NO_Date.Text) + "'  and SC_No='"+ SC_Notxt.Text + "' ";
               
                string lvResault = GsysSQL.fncExecuteQueryData(lvSQL);
            }
            else
            {
                string lvSQL = "Insert into Cane_ServiceCharge(NO_Name,NO_Price,NO_Date,SC_No) ";
                lvSQL += "Values ('" + NO_Name.Text + "','" + NO_Price.Text + "','" + Gstr.fncChangeTDate(NO_Date.Text) + "','" + SC_Notxt.Text + "')";
                string lvResault = GsysSQL.fncExecuteQueryData(lvSQL);
            }
            
            LoadDataDT();

            ASPxPopupControl1.ShowOnPageLoad = false;
        }

        protected void ASPxButton2_Click(object sender, EventArgs e)
        {
          //  ASPxPopupControl1.ShowOnPageLoad = true; v  
        }
        protected void ASPxGridView1_RowCommand(object sender, ASPxGridViewRowCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.VisibleIndex);
            string Date = ASPxGridView1.GetRowValues(index, "NO_Date").ToString();
            string Name = ASPxGridView1.GetRowValues(index, "NO_Name").ToString();
            string ID = ASPxGridView1.GetRowValues(index, "SC_No").ToString();

            //if (e.CommandArgs.CommandName == "A")
            //{                              
            //    //DataTable DT = new DataTable();
            //    //string lvSQL = "Select * from Cane_ServiceCharge WHERE NO_Date='"+ Gstr.fncChangeTDate(Date) + "' and NO_Name ='" + Name + "' and SC_No='"+ ID + "' ";
            //    //DT = GsysSQL.fncGetQueryData(lvSQL, DT);
            //    //int lvNumRow = DT.Rows.Count;
            //    //for (int i = 0; i < lvNumRow; i++)
            //    //{
            //    //    NO_Name.Text = DT.Rows[i]["NO_Name"].ToString();
            //    //    NO_Price.Text = DT.Rows[i]["NO_Price"].ToString();
            //    //    NO_Date.Text =Gstr.fncChangeSDate(DT.Rows[i]["NO_Date"].ToString());
            //    //    SC_No.Text = DT.Rows[i]["SC_No"].ToString();                   
            //    //}

            //   // LoadDataDT2();
            //}
            if (e.CommandArgs.CommandName == "B")
            {
                string lvSQL = "DELETE FROM Cane_ServiceCharge WHERE NO_Name ='" + Name + "' and SC_No='" + ID + "' ";
                string lvResault = GsysSQL.fncExecuteQueryData(lvSQL);
                LoadDataDT();

            }
        }
        protected void ASPxGridView1_PageIndexChanged(object sender, EventArgs e)
        {
                //LoadDataDT();
        }
        protected void ASPxButton4_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < ASPxGridView2.VisibleRowCount; i++)
            {
                GridViewDataColumn SC_No = ASPxGridView2.Columns["SC_No"] as GridViewDataColumn;
                ASPxTextBox TxtSC_No = ASPxGridView2.FindRowCellTemplateControl(i, SC_No, "SC_Notxt") as ASPxTextBox;

                GridViewDataColumn NO_Name = ASPxGridView2.Columns["NO_Name"] as GridViewDataColumn;
                ASPxTextBox TxTNO_Name = ASPxGridView2.FindRowCellTemplateControl(i, NO_Name, "Nametxt") as ASPxTextBox;

                GridViewDataColumn NO_Price = ASPxGridView2.Columns["NO_Price"] as GridViewDataColumn;
                ASPxTextBox TxtPrice = ASPxGridView2.FindRowCellTemplateControl(i, NO_Price, "Pricetxt") as ASPxTextBox;

                //GridViewDataColumn NO_Date = ASPxGridView2.Columns["NO_Date"] as GridViewDataColumn;
                //ASPxTextBox TxtDate = ASPxGridView2.FindRowCellTemplateControl(i, NO_Date, "Datetxt") as ASPxTextBox; 
                
                string TxtDate = Gstr.fncChangeTDate(DateTime.Now.ToString("dd/MM/yyyy"));
                
                string lvSQL = "Insert into Cane_ServiceCharge(NO_Name,NO_Price,NO_Date,SC_No) ";
                lvSQL += "Values ('" + TxTNO_Name.Text + "','" + TxtPrice.Text + "','" + TxtDate + "','" + TxtSC_No.Text + "')";
                string lvResault = GsysSQL.fncExecuteQueryData(lvSQL);

            }
            ASPxGridView1.Visible = true;
            // บันทึกหลังแก้
            //ASPxGridView1.Visible = true;
            //ASPxGridView2.Visible = false;
            LoadDataDT();
        }

        protected void ASPxButton3_Click1(object sender, EventArgs e)
        {
            LoadDataDT2();

            ASPxGridView1.Visible = false;
            ASPxGridView2.Visible = true;
        }

        protected void ASPxGridView2_PageIndexChanged(object sender, EventArgs e)
        {
            LoadDataDT2();
        }

        protected void ASPxGridView2_RowCommand(object sender, ASPxGridViewRowCommandEventArgs e)
        {

            int index = Convert.ToInt32(e.VisibleIndex);
            string Date = ASPxGridView2.GetRowValues(index, "NO_Date").ToString();
            string Name = ASPxGridView2.GetRowValues(index, "NO_Name").ToString();
            string ID = ASPxGridView2.GetRowValues(index, "SC_No").ToString();

            if (e.CommandArgs.CommandName == "A")
            {
                
            }
            if (e.CommandArgs.CommandName == "B")
            {
                string lvSQL = "DELETE FROM Cane_ServiceCharge WHERE NO_Name ='" + Name + "' and SC_No='" + ID + "' ";
                string lvResault = GsysSQL.fncExecuteQueryData(lvSQL);
                LoadDataDT();
                ASPxGridView1.Visible = true;
            }
        }

        protected void ASPxFormLayout2_E5_Click(object sender, EventArgs e)
        {
            LoadDataDTAA(Gstr.fncChangeTDate(DateS.Text), Gstr.fncChangeTDate(DateE.Text));
            string lvFileName = "PivotData-" + DateTime.Now.ToString("yyyyMMdd") + ".xls";
            string uploadDirectory = Server.MapPath("/Export");
            string lvPathFile = uploadDirectory + "\\" + lvFileName;

            //ลบไฟล์เก่่า ถ้ามี
            //if (File.Exists(lvPathFile))
            //{
            //    File.Delete(lvPathFile);
            //}
            //CsvExportOptionsEx Gridoptions;
            //Gridoptions = new CsvExportOptionsEx()
            //{
            //    ExportType = ExportType.WYSIWYG,
            //    TextExportMode = TextExportMode.Text
            //}
            //;

            CsvExportOptionsEx options;
            options = new CsvExportOptionsEx()
            {
                ExportType = ExportType.WYSIWYG,
                TextExportMode = TextExportMode.Text
            };
            //ASPxGridViewExporter1.WriteXlsToResponse("รายงานประจำวัน", true);
            ASPxPivotGridExporter1.ExportCsvToResponse("Export File", options, true);

            MessageboxAlert("Export Complete");
        }
        private void MessageboxAlert(string lvMessage)
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "alert", "alert('" + lvMessage + "');", true);
        }

        protected void ASPxPivotGridExporter1_CustomExportCell(object sender, DevExpress.Web.ASPxPivotGrid.WebCustomExportCellEventArgs e)
        {

        }

        protected void ASPxPivotGridExporter1_Init(object sender, EventArgs e)
        {
            
        }
    }
}