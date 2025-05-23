using System;
using System.Collections.Generic;
using System.Diagnostics; //Email 
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Small_Map_Virtual
{
    public partial class Form1 : Form
    {
        private MapGraph graph;
        private List<City> cities;
        private List<Road> roads;
        private City highlightedCity = null; 
        public Form1()
        {
            InitializeComponent(); //note me : وظیفه ایجاد و مقداردهی اولیه کنترل‌ها و تنظیمات فرم را به عهده دارد.
            graph = new MapGraph();
            cities = new List<City>();
            roads = new List<Road>();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            int x = int.Parse(textBox2.Text);
            int y = int.Parse(textBox3.Text);
            City newCity = new City(name, x, y);
            graph.AddCity(newCity);
            cities.Add(newCity);
            panel1.Invalidate();
            MessageBox.Show($"city {name} added.");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string cityAName = textBox5.Text;
            string cityBName = textBox6.Text;

            City cityA = null;
            City cityB = null;

         
            for (int i = 0; i < cities.Count; i++)
            {
                if (cities[i].Name == cityAName)
                    cityA = cities[i];
                if (cities[i].Name == cityBName)
                    cityB = cities[i];
            }

            if (cityA != null && cityB != null)
            {
                double distance = graph.CalculateDistance(cityA, cityB);
                roads.Add(new Road(cityA, cityB, distance));// نمونه جدید درست میکند ارسال میکنند به به اضافه کنننه جاده ها
                panel1.Invalidate();
                MessageBox.Show($"distance between {cityA.Name} and {cityB.Name} is {distance} km.");
            }
            else
            {
                MessageBox.Show("یک یا هر دو شهر پیدا نشد!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox4.Text = graph.PrintGraph();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string cityAName = textBox7.Text;
            string cityBName = textBox8.Text;

            City cityA = null;
            City cityB = null;


            for (int i = 0; i < cities.Count; i++)
            {
                if (cities[i].Name == cityAName)
                    cityA = cities[i];
                if (cities[i].Name == cityBName)
                    cityB = cities[i];
            }

            if (cityA != null && cityB != null)
            {
                double distance = graph.CalculateDistance(cityA, cityB);
                graph.AddRoad(new Road(cityA, cityB, distance));
                roads.Add(new Road(cityA, cityB, distance));
                panel1.Invalidate();
                MessageBox.Show($"Road added between {cityA.Name} and {cityB.Name}.");
            }
            else
            {
                MessageBox.Show("یک یا هر دو شهر پیدا نشد.");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string cityName = textBox9.Text;
            highlightedCity = null;

            
            for (int i = 0; i < cities.Count; i++)
            {
                if (cities[i].Name == cityName)
                {
                    highlightedCity = cities[i];
                    break;
                }
            }

            if (highlightedCity != null)
            {
                panel1.Invalidate();
            }
            else
            {
                MessageBox.Show("City not found.");
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            for (int i = 0; i < cities.Count; i++)
            {
                g.FillRectangle(Brushes.Black, cities[i].X, cities[i].Y, 5, 5);
                g.DrawString(cities[i].Name, DefaultFont, Brushes.Black, cities[i].X + 5, cities[i].Y + 5);
            }

            for (int i = 0; i < roads.Count; i++)
            {
                g.DrawLine(Pens.Black, roads[i].CityA.X + 2, roads[i].CityA.Y + 2, roads[i].CityB.X + 2, roads[i].CityB.Y + 2);
            }

            if (highlightedCity != null)
            {
                g.FillEllipse(Brushes.Red, highlightedCity.X - 5, highlightedCity.Y - 5, 15, 15);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string email = "mailto:hesamporakbar20@gmail.com";
            Process.Start(new ProcessStartInfo(email) { UseShellExecute = true });
            //note me: UseShellExecute = true | میره سیستم دنبال نرم افزار پیش فرض که این رو باز کنه.
            //ProcessStartInfo / Process.start |  این کلاس‌ها به شما اجازه می‌دهند تا برنامه‌های دیگر را از داخل برنامه‌ی خود اجرا کنید
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }
    }
}
