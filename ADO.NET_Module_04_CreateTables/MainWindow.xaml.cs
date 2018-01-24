using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Configuration;
using System.Data.Common;
using System.Data.OleDb;
using ADO.NET_Module_04_CreateTables.Model;

namespace ADO.NET_Module_04_CreateTables
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        private DataBase db = new DataBase();
       
        public MainWindow()
        {
            InitializeComponent();
            MessageBox.Show("Итак, данные выгружаются\n Таблички создаются, И бонусом делается сортировка))");
            var list = db.TrackEvaluationParts.Select(s => new
            {
                s.intEvaluationPartId,
                s.intEvalutionId,
                s.intMasterPartId,
                s.floatQuantity,
                s.floatUnitCostTrack,
                s.floatUnitCostAvia
            }).AsQueryable();
            TrackEvaluationPartList.ItemsSource = list.ToList();
            DataSet ds = new DataSet();
            #region TrackEvaluationPart
            DataTable TrackEvaluationPart = new DataTable("TrackEvaluationPart");
            DataColumn intEvaluationPartId = TrackEvaluationPart.Columns.Add("intEvaluationPartId", typeof(int));
            intEvaluationPartId.AllowDBNull = false;
            intEvaluationPartId.Unique = true;
            TrackEvaluationPart.PrimaryKey = new DataColumn[]
            {
                TrackEvaluationPart.Columns["intEvaluationPartId"]
            };

            intEvaluationPartId.AutoIncrement = true;
            intEvaluationPartId.AutoIncrementSeed = 0;
            intEvaluationPartId.AutoIncrementStep = 1;
            intEvaluationPartId.ReadOnly = true;
            TrackEvaluationPart.Columns.AddRange(new DataColumn[]
            {
                new DataColumn("intEvaluationId",typeof(int)){AllowDBNull=true},
                new DataColumn("intMasterPartId",typeof(int)){AllowDBNull=false},
                new DataColumn("floatQuantity",typeof(float)){AllowDBNull=true},
                new DataColumn("floatUnitCostTrack",typeof(float)){AllowDBNull=true},
                new DataColumn("floatUnitCostAvia",typeof(float)){AllowDBNull=true},
                new DataColumn("strAvailability",typeof(string)){AllowDBNull=true,MaxLength=50},
                new DataColumn("strDescription",typeof(string)){AllowDBNull=true,MaxLength=2500},
                new DataColumn("intSimsId",typeof(int)){AllowDBNull=true},
                new DataColumn("intPartStatus",typeof(int)){AllowDBNull=true}
            });
            #endregion
            #region TrackComponent
            DataTable TrackComponent = new DataTable("TrackComponent");
            TrackComponent.PrimaryKey = new DataColumn[]
            {
                TrackComponent.Columns["intComponentId"]

            };
            DataColumn intComponentId = TrackComponent.Columns.Add("intComponentId", typeof(int));
            intComponentId.AllowDBNull = false;
            intComponentId.Unique = true;
            intComponentId.AutoIncrement = true;
            intComponentId.AutoIncrementSeed = 0;
            intComponentId.AutoIncrementStep = 1;
            intComponentId.ReadOnly = true;

            TrackComponent.Columns.AddRange(new DataColumn[]
            {
                new DataColumn("strComponentId",typeof(string)){AllowDBNull=true,MaxLength=12},
                new DataColumn("strUntil",typeof(string)){AllowDBNull=true,MaxLength=10},
                new DataColumn("intComponentTypeID",typeof(int)){AllowDBNull=true},
                new DataColumn("dInstalledInMCS",typeof(DateTime)){AllowDBNull=false},
                new DataColumn("intEstimatedLife",typeof(int)){AllowDBNull=false},
                new DataColumn("dInitCycleDate",typeof(DateTime)){AllowDBNull=true},
                new DataColumn("intInitCycleUnits",typeof(int)){AllowDBNull=true},
                new DataColumn("intInitTotalUnits",typeof(int)){AllowDBNull=true},
                new DataColumn("intEquipmentID",typeof(int)){AllowDBNull=true},
                new DataColumn("LastDate",typeof(DateTime)){AllowDBNull=false},
                new DataColumn("intLastMetered",typeof(float)){AllowDBNull=false},
                new DataColumn("intTotalMetered",typeof(float)){AllowDBNull=true},
                new DataColumn("intSMCSComponent",typeof(int)){AllowDBNull=true},
                new DataColumn("intModelID",typeof(int)){AllowDBNull=true},
                new DataColumn("intLocation",typeof(int)){AllowDBNull=true},
                new DataColumn("isRemoved",typeof(byte)){AllowDBNull=true},
                new DataColumn("intStatusComponent",typeof(int)){AllowDBNull=true},
                new DataColumn("intModifierId",typeof(int)){AllowDBNull=true}
            });
            #endregion
            #region PMChecklistPart
            DataTable PMChecklistPart = new DataTable("PMChecklistPart");
            DataColumn intPMchecklistPartID = PMChecklistPart.Columns.Add("intPMchecklistPartID", typeof(int));
            PMChecklistPart.PrimaryKey = new DataColumn[]
      {
                 PMChecklistPart.Columns["intPMchecklistPartID"]
      };

            intPMchecklistPartID.AllowDBNull = false;
            intPMchecklistPartID.Unique = true;
            intPMchecklistPartID.AutoIncrement = true;
            intPMchecklistPartID.AutoIncrementSeed = 0;
            intPMchecklistPartID.AutoIncrementStep = 1;
            intPMchecklistPartID.ReadOnly = true;

            PMChecklistPart.Columns.AddRange(new DataColumn[]
            {
                new DataColumn("intPMchecklistStepID",typeof(int)){AllowDBNull=false},
                new DataColumn("strPartNo",typeof(string)){AllowDBNull=true,MaxLength=20},
                new DataColumn("intQuantity",typeof(int)){AllowDBNull=true},
                new DataColumn("intExtendedCost",typeof(int)){AllowDBNull=true},
                new DataColumn("bitOptional",typeof(byte)){AllowDBNull=true},
                new DataColumn("intOriginalPartID",typeof(int)){AllowDBNull=true},
                new DataColumn("strPartDesciption",typeof(string)){AllowDBNull=true,MaxLength=550},
                new DataColumn("intPMChecklistID",typeof(int)){AllowDBNull=true},
            });
            #endregion
            DataTable[] tables = new DataTable[] { TrackComponent, TrackEvaluationPart, PMChecklistPart };
            TrackEvaluationPart.Rows.Add(SetDataRow_TrackEvaluationPart(ref TrackEvaluationPart));
            TrackComponent.Rows.Add(SetDataRow_TrackComponent(ref TrackComponent));
            PMChecklistPart.Rows.Add(SetDataRow_PMChecklistPart(ref PMChecklistPart));
            ds.Tables.AddRange(tables);
            try
            {

                var a = ds.Tables["TrackComponent"].Rows[0];

            }
            catch (Exception ex)
            {
                ErrorOrSuccesTextBlock.Text += ex.Message;
            }


        }
        #region Здесь Загружаем данные в таблички
        static DataRow SetDataRow_TrackComponent(ref DataTable TrackComponent)
        {
            DataRow dr = TrackComponent.NewRow();
            dr["strComponentId"] = "1";
            dr["strUntil"] = "until";
            dr["intComponentTypeID"] = 1;
            dr["dInstalledInMCS"] = DateTime.Now;
            dr["intEstimatedLife"] = 0;
            dr["dInitCycleDate"] = DateTime.Now.AddDays(1);
            dr["intInitCycleUnits"] = 123;
            dr["intInitTotalUnits"] = 654;
            dr["intEquipmentID"] = 1;
            dr["LastDate"] = DateTime.Now;
            dr["intLastMetered"] = 1.145;
            dr["intTotalMetered"] = 2.178;
            dr["intSMCSComponent"] = 45;
            dr["intModelID"] = 2;
            dr["intLocation"] = 3;
            dr["isRemoved"] = 0;
            dr["intStatusComponent"] = 6;
            dr["intModifierId"] = 7;
            return dr;
        }
        static DataRow SetDataRow_TrackEvaluationPart(ref DataTable TrackEvaluationPart)
        {
            DataRow dr = TrackEvaluationPart.NewRow();
            dr["intEvaluationId"] = 1;
            dr["intMasterPartId"] = 244;
            dr["floatQuantity"] = 1;
            dr["floatUnitCostTrack"] = 2.26;
            dr["floatUnitCostAvia"] = 2.03;
            dr["strAvailability"] = "To add new records into a dataset, a new data row";
            dr["strDescription"] = "Examples are provided for both typed and untyped datasets.";
            dr["intSimsId"] = 0;
            dr["intPartStatus"] = 1;
            return dr;

        }
        static DataRow SetDataRow_PMChecklistPart(ref DataTable PMChecklistPart)
        {
            DataRow dr = PMChecklistPart.NewRow();
            dr["intPMchecklistStepID"] = 0;
            dr["strPartNo"] = "Hello";
            dr["intQuantity"] = 0;
            dr["intExtendedCost"] = 1;
            dr["bitOptional"] = 2;
            dr["intOriginalPartID"] = 1;
            dr["strPartDesciption"] = "The following code creates a new row, populates it with data, and adds it to the table's Rows collection.";
            dr["intPMChecklistID"] = 0;
            return dr;
        }
        #endregion

        private void GetSetDataButton_Click(object sender, RoutedEventArgs e)
        {
            TrackEvaluationPartList.Visibility = Visibility.Visible;
            var list = db.TrackEvaluationParts.Select(s => new
            {
                s.intEvaluationPartId,
                s.intEvalutionId,
                s.intMasterPartId,
                s.floatQuantity,
                s.floatUnitCostTrack,
                s.floatUnitCostAvia
            }).AsQueryable();
            TrackEvaluationPartList.ItemsSource = list.ToList();
            OrderBy_ButRandomField.Visibility = Visibility.Visible;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Random rnd = new Random();
        
            int rand = rnd.Next(0, 4);
            if (rand == 0)
            {
                var list = db.TrackEvaluationParts.Select(s => new
                {
                    s.intEvaluationPartId,
                    s.intEvalutionId,
                    s.intMasterPartId,
                    s.floatQuantity,
                    s.floatUnitCostTrack,
                    s.floatUnitCostAvia
                }).OrderByDescending(o => o.intEvaluationPartId);
                TrackEvaluationPartList.ItemsSource = list.ToList();
            }
            else if (rand == 1)
            {
                var list = db.TrackEvaluationParts.Select(s => new
                {
                    s.intEvaluationPartId,
                    s.intEvalutionId,
                    s.intMasterPartId,
                    s.floatQuantity,
                    s.floatUnitCostTrack,
                    s.floatUnitCostAvia
                }).OrderByDescending(o => o.intEvaluationPartId);
                TrackEvaluationPartList.ItemsSource = list.ToList();

            }
            else if (rand == 2)
            {
                var list = db.TrackEvaluationParts.Select(s => new
                {
                    s.intEvaluationPartId,
                    s.intEvalutionId,
                    s.intMasterPartId,
                    s.floatQuantity,
                    s.floatUnitCostTrack,
                    s.floatUnitCostAvia
                }).OrderBy(o => o.intMasterPartId);
                TrackEvaluationPartList.ItemsSource = list.ToList();
            }
            else if (rand == 3)
            {
                var list = db.TrackEvaluationParts.Select(s => new
                {
                    s.intEvaluationPartId,
                    s.intEvalutionId,
                    s.intMasterPartId,
                    s.floatQuantity,
                    s.floatUnitCostTrack,
                    s.floatUnitCostAvia
                }).OrderByDescending(o => o.floatUnitCostAvia);
                TrackEvaluationPartList.ItemsSource = list.ToList();
            }
           
        }
    }
}
