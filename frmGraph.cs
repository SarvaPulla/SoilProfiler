using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demo1
{
    public partial class frmGraph : Form
    {
        /*
         *  public frmGraph(List<PathPoint> pathList, string layerName)
        {
         * 
         * 
         * */

        public static List<string> lname; 

        public frmGraph(Dictionary<int, List<PathPoint>> ssv,List<String> sss )
        {
            InitializeComponent();

            
            //Creating an empty list
            List<PathPoint> pathList = null;

            var extrele = new List<PathPoint>();

            //populating the graph with lots of points
            for (int l = 0; l < ssv.Count ; l++)
            {
                var vall = ssv.ElementAt(l);

                 var  exe  = vall.Value;

                 pathList = exe;

                 double[] distanceArray = new double[pathList.Count];

                 double[] elevationArray = new double[pathList.Count];

                 for (int i = 0; i <= pathList.Count - 1; i++)
                 {
                     distanceArray[i] = pathList[i].Distance;

                     elevationArray[i] = pathList[i].Elevation;
                 }

                //Creating the Zed Graph, the settings are are also mentioned here
                 ZedGraph.LineItem myCurve = zedGraphControl1.GraphPane.AddCurve(sss[l], distanceArray, elevationArray, Color.Blue);
                 myCurve.Line.Width = 1f;
                 myCurve.Symbol.Type = ZedGraph.SymbolType.HDash;

            }

            zedGraphControl1.GraphPane.Title = "Soil Profile";

                
            zedGraphControl1.GraphPane.XAxis.Title = "Distance (meters)";

            zedGraphControl1.GraphPane.YAxis.Title = "Depth (meters)";

            //populate the graph
            //create the distance and elevation arrays..
          

           // zedGraphControl1.GraphPane.CurveList.Clear();

           
            //refresh the graph
            zedGraphControl1.AxisChange();




        }


       


        private void frmGraph_Load(object sender, EventArgs e)
        {

        }

        private void zedGraphControl1_Load(object sender, EventArgs e)
        {

        }
    }
}
