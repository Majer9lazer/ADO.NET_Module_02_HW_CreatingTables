using System;
using System.Collections.Generic;
using System.Data;
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

namespace ADO.NET_Module_04_CreateTables
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataSet ds = new DataSet();
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
            DataTable TrackComponent = new DataTable("TrackComponent");
            TrackComponent.PrimaryKey = new DataColumn[]
            { new DataColumn("intComponentId"){AllowDBNull=false,Unique=true,AutoIncrement=true,AutoIncrementSeed=0,AutoIncrementStep=1}
            };
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
           DataTable []tables = new DataTable[] { TrackComponent ,TrackEvaluationPart};
            ds.Tables.AddRange(tables);
        }
    }
}
