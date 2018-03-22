using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Inlamning3
{
    public partial class Form1 : Form
    {
        SqlConnection myConnection = new SqlConnection();
        private City cityVal, BarcelonaX, AmsterdamX, BostonX;
        List<Accommodation> skatter, histo;
        int choice = 10000, minChoice = 0;
        string itm;

        public Form1()
        {
            InitializeComponent();
            myConnection.ConnectionString = "Data Source=ADMIN;Initial Catalog=airbnbtest;Integrated Security=True";

        }



        private List<Accommodation> AccommodationsObject(string stad)
        {
            List<Accommodation> Accommodations = new List<Accommodation> ();

            try
            {
                myConnection.Open();

                SqlCommand myCommandForBoston = new SqlCommand($"select * from dbo.{stad}", myConnection);
                SqlDataReader myReaderBos = myCommandForBoston.ExecuteReader();

                int roomId, hostId, minstay, accommodates, bedrooms, price;
                string roomType, borough, neighbourhood, lastModified;
                Int32 reviews;
                double overallSatisfaction, latitude, longitude;

                while (myReaderBos.Read())
                {
                    roomId = (int)myReaderBos["room_id"];
                    hostId = (int)myReaderBos["host_id"];
                    roomType = myReaderBos["room_type"].ToString();
                    borough = myReaderBos["borough"].ToString(); 
                    neighbourhood = myReaderBos["neighborhood"].ToString();
                    reviews = (Int32)myReaderBos["reviews"];
                    overallSatisfaction = double.TryParse(myReaderBos["overall_satisfaction"].ToString(), out var test) ? test : 0;
                    accommodates = (int)myReaderBos["accommodates"];
                    double.TryParse(myReaderBos["bedrooms"].ToString(), out var bedroom);
                    bedrooms = Convert.ToInt32(Math.Round(bedroom)); //Math.Round(
                    double.TryParse(myReaderBos["price"].ToString(), out var test2); //Math.Round(
                    price = (int)Math.Round(test2);
                    int.TryParse(myReaderBos["minstay"].ToString(), out minstay); // TryParse
                    double.TryParse(myReaderBos["latitude"].ToString(), out latitude);
                    double.TryParse(myReaderBos["longitude"].ToString(), out longitude);
                    lastModified = myReaderBos["last_modified"].ToString();

                    Accommodation acco = new Accommodation(roomId, hostId, roomType, borough, neighbourhood, reviews,
                        overallSatisfaction, accommodates, bedrooms, price, minstay, latitude,
                        longitude, lastModified);

                    Accommodations.Add(acco);

                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                MessageBox.Show(e.ToString());
            }
            finally
            {
                myConnection.Close();
            }

                
            return Accommodations;

        }



        private void Creation()
        {
            List<Accommodation> bostonList = AccommodationsObject("boston");
            City Boston = new City("Boston", 100000, 20000, 40000, bostonList, 400000);
            List<Accommodation> amsterdamList = AccommodationsObject("amsterdam");
            City Amsterdam = new City("Amsterdam", 50000, 30000, 60000, amsterdamList, 350000);
            List<Accommodation> barcelonaList = AccommodationsObject("barcelona");
            City Barcelona = new City("Barcelona", 300000, 15000, 70000, barcelonaList, 200000);

            Country usa = new Country("USA", 100000, 3000000, Boston);
            //usa.Cities.Add(Boston);
            Country spain = new Country("USA", 100000, 3000000, Barcelona);
            Country netherland = new Country("USA", 100000, 3000000, Amsterdam);

            BostonX = Boston; AmsterdamX = Amsterdam; BarcelonaX = Barcelona;

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int.TryParse(textBox1.Text, out choice);
            if (choice > 50)
            {
                SkatterPlot();
                HistogramPlot();
            }
            else
                choice = 5000;
        }

        private void chart2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            int.TryParse(textBox2.Text, out minChoice);
            if (minChoice > 0 && minChoice< choice-100)
            {
                SkatterPlot();
                HistogramPlot();
            }
            else
                minChoice = 0;

        }

        private void SkatterPlot()
        {
            
            if (itm == "Barcelona")
                cityVal = BarcelonaX; 
            else if (itm == "Amsterdam")
                cityVal = AmsterdamX;
            else
                cityVal = BostonX;

            if (minChoice > 0 && minChoice > choice - 100)
            {
                minChoice = 0;
            }

            skatter = cityVal.Accommodation;
                        
            var dataPoints = from line in skatter
                             where line.OverallSatisfaction < 4.5 && line.Price < choice && line.Price > minChoice
                             select new {line.OverallSatisfaction, line.Price};

            string s = "Series1";

            chart1.Series[s].Points.Clear();
            foreach (var x in dataPoints)
            {
                chart1.Series[s].Points.AddXY(x.Price, x.OverallSatisfaction);
            }

            chart1.Series["Series1"].ChartType = SeriesChartType.Point;



        }

        private void HistogramPlot()
        {
            if (itm == "Barcelona")
                cityVal = BarcelonaX; 
            else if (itm == "Amsterdam")
                cityVal = AmsterdamX;
            else
                cityVal = BostonX;

            if (minChoice > 0 && minChoice > choice - 100)
            {
                minChoice = 0;
            }
                


            histo = cityVal.Accommodation;

            var histogram = from line in histo
                            where line.Price < choice && line.Price > minChoice && line.RoomType == "Private room" 
                            select line;

            var query = from r in histogram
                       
                     group r by r.Price - (r.Price % 10) into r
                        select new
                        {
                            Range = r.Key,
                            Count = r.Count()
                        };


            chart2.Series["Series1"].Points.Clear();
            foreach (var x in query)
            {
                chart2.Series["Series1"].Points.AddXY(x.Range, x.Count);
            }

            //chart2.Series["Series1"].ChartType = SeriesChartType.Bar;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Creation();
            SkatterPlot();
            HistogramPlot();


            comboBox1.Items.Add("Amsterdam");
            comboBox1.Items.Add("Boston");
            comboBox1.Items.Add("Barcelona");

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            itm = comboBox1.SelectedItem.ToString();
            SkatterPlot();
            HistogramPlot();
        }
    }
}
