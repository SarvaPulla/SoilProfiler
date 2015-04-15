using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DotSpatial.Controls;
using DotSpatial.Data;
using DotSpatial.Symbology;
using DotSpatial.Topology;


namespace Demo1
{
    public partial class Form1 : Form
    {
        #region "Class level variables"
        //the line layer
        MapLineLayer lineLayer;
        //the line feature set
        FeatureSet lineF;
        int lineID = 0;
        //boolean variable for first time mouse click
        Boolean firstClick = false;
        //boolean variable for ski path drawing finished
        Boolean SoilPathFinished = false;
        #endregion


        public Form1()
        {
            InitializeComponent();

            appManager1.LoadExtensions();
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            map1.AddRasterLayer();

            map1.ZoomToMaxExtent();
        }


        private void drawToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //remove any existing path
            foreach (IMapLineLayer existingPath in map1.GetLineLayers())
            {
                map1.Layers.Remove(existingPath);
            }
            //hikingpath is not finished
            SoilPathFinished = false;

            //change the mouse cursor
            map1.Cursor = Cursors.Cross;

            //initialize the polyline featureset
            lineF = new FeatureSet(FeatureType.Line);

            //set projection
            lineF.Projection = map1.Projection;

            //initialize the featureSet attribute table
            DataColumn column = new DataColumn("ID");

            lineF.DataTable.Columns.Add(column);

            //add the featureSet as map layer
            lineLayer = (MapLineLayer)map1.Layers.Add(lineF);

            //implement the symbology
            LineSymbolizer symbol = new LineSymbolizer(Color.Blue, 2);
            lineLayer.Symbolizer = symbol;

            //Set the legend text
            lineLayer.LegendText = "Soil Profile";

            //Before clicking the mouse first time
            firstClick = true;

        }

        private void map1_MouseDown(object sender, MouseEventArgs e)
        {
            

            //if soil path is fininshed, don't draw any line
            if (SoilPathFinished == true)
                return;
            
            if (e.Button == MouseButtons.Left)
            {
                //left click - fill array of coordinates

                //coordinate of clicked point
                Coordinate coord = map1.PixelToProj(e.Location);

                //first time left click - create empty line feature
                if (firstClick)
                {
                    MessageBox.Show("Click on the map to draw a polyline. Right click to stop drawing.");
                    //Create a new List called lineArray.
                    //This list will store the Coordinates
                    //We are going to store the mouse click coordinates into this array.
                    List<Coordinate> lineArray = new List<Coordinate>();

                    //Create an instance for LineString class.
                    //We need to pass collection of list coordinates
                    LineString lineGeometry = new LineString(lineArray);

                    //Add the linegeometry to line feature
                    IFeature lineFeature = lineF.AddFeature(lineGeometry);

                    //add first coordinate to the line feature
                    lineFeature.Coordinates.Add(coord);

                    //set the line feature attribute
                    lineID = lineID + 1;
                    lineFeature.DataRow["ID"] = lineID;

                    firstClick = false;
                }
                else
                {
                    //second or more clicks - add points to the existing feature
                    IFeature existingFeature = lineF.Features[lineF.Features.Count - 1];

                    existingFeature.Coordinates.Add(coord);

                    //refresh the map if line has 2 or more points
                    if (existingFeature.Coordinates.Count >= 2)
                    {
                        lineF.InitializeVertices();
                        map1.ResetBuffer();
                    }
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                //right click - reset first mouse click
                firstClick = true;
                map1.ResetBuffer();
                lineF.SaveAs("c:\\MW\\linepath.shp", true);
                MessageBox.Show("The line shapefile has been saved.");
                map1.Cursor = Cursors.Arrow;
                //the soil path is finished
                SoilPathFinished = true;
            }

        }

        private void viewElevationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //extract the complete elevation
                //get the raster layer
                IMapRasterLayer rasterLayer = default(IMapRasterLayer);

                if (map1.GetRasterLayers().Count() == 0)
                {
                    MessageBox.Show("Please load the DEM");
                    return;
                }

                //get the soil path line layer
                IMapLineLayer pathLayer = default(IMapLineLayer);

                if (map1.GetLineLayers().Count() == 0)
                {
                    MessageBox.Show("Please draw a line");
                    return;
                }

                pathLayer = map1.GetLineLayers()[0];

                IFeatureSet featureSet = pathLayer.DataSet;

                //get the coordinates of the drawn path. this is the first feature of
                //the feature set.
                IList<Coordinate> coordinateList = featureSet.Features[0].Coordinates;

            

                //use the first raster layer in the map              
                int nooflayer = map1.GetRasterLayers().Count();
                List<string> layerNames = new List<string>();

                Dictionary<int, List<PathPoint>> ss = new Dictionary<int, List<PathPoint>>();
                int j;
                for ( j= 0; j < nooflayer; j++)
                {
                    //get elevation of all segments of the path
                    List<PathPoint> fullPathList = new List<PathPoint>();

                    rasterLayer = map1.GetRasterLayers()[j];

                    for (int i = 0; i < coordinateList.Count - 1; i++)
                    {
                        //for each line segment
                        Coordinate startCoord = coordinateList[i];
                        Coordinate endCoord = coordinateList[i + 1];
                        List<PathPoint> segmentPointList = ExtractElevation(startCoord.X, startCoord.Y, endCoord.X, endCoord.Y, rasterLayer);
                        //add list of points from this line segment to the complete list
                        fullPathList.AddRange(segmentPointList);
                    }

                    //calculate the distance
                    double distanceFromStart = 0;

                    for (int i = 1; i <= fullPathList.Count - 1; i++)
                    {
                        //distance between two neighbouring points
                        double x1 = fullPathList[i - 1].X;
                        double y1 = fullPathList[i - 1].Y;
                        double x2 = fullPathList[i].X;
                        double y2 = fullPathList[i].Y;
                        double distance12 = Math.Sqrt(((x2 - x1) * (x2 - x1)) + ((y2 - y1) * (y2 - y1)));
                        distanceFromStart += distance12;
                        fullPathList[i].Distance = distanceFromStart;
                    }

                    ss.Add(j, fullPathList);
                    layerNames.Add((map1.GetRasterLayers()[j].LegendText.ToString()));
                 
                    //just for testing
                }

                frmGraph graphForm = new frmGraph(ss,layerNames);

                graphForm.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error calculating elevation. the whole path should be inside the DEM area" + ex.Message);
            }


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// This function is used to get the elevation. 
        /// Based on the given line segment's start and endpoint, 100 points will be divided and based on the points  elevation will be claculated.
        /// </summary>
        /// <param name="startX">Line segement's start X point</param>
        /// <param name="startY">Line segement's start Y point</param>
        /// <param name="endX">Line segement's end X point</param>
        /// <param name="endY">Line segement's end Y point</param>
        /// <param name="raster">Raster DEM</param>
        /// <returns>List of elevation</returns>
        /// <remarks></remarks>
        /// 
        public List<PathPoint> ExtractElevation(double startX, double startY, double endX, double endY, IMapRasterLayer raster)
        {
            double curX = startX;
            double curY = startY;
            double curElevation = 0;

            List<PathPoint> pathPointList = new List<PathPoint>();

            int numberofpoints = 100;

            double constXdif = ((endX - startX) / numberofpoints);

            double constYdif = ((endY - startY) / numberofpoints);

            for (int i = 0; i <= numberofpoints; i++)
            {
                PathPoint newPathPoint = new PathPoint();

                if ((i == 0))
                {
                    curX = startX;
                    curY = startY;
                }
                else
                {
                    curX = curX + constXdif;
                    curY = curY + constYdif;
                }

                Coordinate coordinate = new Coordinate(curX, curY);

                RcIndex rowColumn = raster.DataSet.Bounds.ProjToCell(coordinate);

                curElevation = raster.DataSet.Value[rowColumn.Row, rowColumn.Column];

                //set the properties of new PathPoint
                newPathPoint.X = curX;
                newPathPoint.Y = curY;
                newPathPoint.Elevation = curElevation;
                pathPointList.Add(newPathPoint);
            }

            return pathPointList;
        }

        private void zoomInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            map1.FunctionMode = DotSpatial.Controls.FunctionMode.ZoomIn;
        }

        private void zoomOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            map1.FunctionMode = DotSpatial.Controls.FunctionMode.ZoomOut;
        }
     
    }
}

