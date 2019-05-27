using System;
using System.Collections.Generic;
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
using System.Windows.Threading;
namespace _184905GameOfLife
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int PosX;
        int PosY;
        int LiveCounter;

        Rectangle w = new Rectangle();

        Rectangle[,] GridNoColour= new Rectangle[20, 20];
        Rectangle[,] FutureGrid = new Rectangle[20, 20];
        //Rectangle[][] grid = new Rectangle[20][];
        bool livetest = new bool();

        DispatcherTimer dt = new DispatcherTimer();

        public MainWindow()
        {
            InitializeComponent();
            dt.Interval = new TimeSpan(0,0,1);
            dt.Tick += Dt_Tick;

            for (int j = 0; j < 20; j++)
            {
                for (int i = 0; i < 20; i++)
                {
                    Rectangle w = new Rectangle();
                    w.Height = 30;
                    w.Width = 30;
                    w.Fill = Brushes.White;
                    w.Stroke = Brushes.Black;
                    GridNoColour[j, i] = w;
                    canvas.Children.Add(GridNoColour[j, i]);
                    Canvas.SetTop(w, i * 30 + 125);
                    Canvas.SetLeft(w, j * 30);
                    
                }



            }
            for (int j = 0; j < 20; j++)
            {
                for (int i = 0; i < 20; i++)
                {
                    Rectangle w = new Rectangle();
                    w.Height = 30;
                    w.Width = 30;
                    w.Fill = Brushes.White;
                    w.Stroke = Brushes.Black;
                    FutureGrid[j, i] = w;
                    
                    Canvas.SetTop(w, i * 30 + 125);
                    Canvas.SetLeft(w, j * 30);

                }



            }


            WhatDoLabel.Content = "Put in an X co-ordinate in the top box, followed by a Y co-ordinate in the second box";
            

        }

        private void Dt_Tick(object sender, EventArgs e)
        {
            for (int j = 0; j < 20; j++)
            {
                for (int i = 0; i < 20; i++)
                {
                    if(LiveCounter == 3)
                        //eVERYTHING DIES ONE AT A TIME, SO NEED TO MAKE NEW ARRAY TO HOLD VALUES TEMPORARRLY, THEN APLLY TO PROPER TIME
                    {
                    FutureGrid[j, i].Fill = Brushes.Yellow;
                    }
                    else if (LiveCounter < 2)
                    {
                        FutureGrid[j, i].Fill = Brushes.White;
                    }
                    else if (LiveCounter > 3)
                    {
                        FutureGrid[j, i].Fill = Brushes.White;
                    }
                    //if(LiveCounter == 3)
                    //{
                    //GridNoColour[j, i].Fill = Brushes.Yellow;
                    //}
                    
                   
                }
            }
            GridNoColour = FutureGrid;
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            
            int.TryParse(StartPositionX.Text, out PosX);
            int.TryParse(StartPositionY.Text, out PosY);
            if (PosX <= 0 || PosY <= 0)
            {
                MessageBox.Show("there is no zero, try again");
            }
            else
            {
                GridNoColour[PosX - 1, PosY - 1].Fill = Brushes.Yellow;
            }
           
            StartPositionX.Text = "";
            StartPositionY.Text = "";
            
        }

        private void GameStartButton_Click(object sender, RoutedEventArgs e)
        {
            for (int j = 0; j < 20; j++)
            {
                for (int i = 0; i < 20; i++)
                {
                    LiveCounter = 0;
                    if (GridNoColour[j, i].Fill.ToString() == "#FFFFFF00")
                    {
                        if (GridNoColour[j, i + 1].Fill.ToString() == "#FFFFFF00")
                        {
                            LiveCounter += 1;
                        }
                        if (GridNoColour[j, i - 1].Fill.ToString() == "#FFFFFF00")
                        {
                            LiveCounter += 1;
                        }
                        if (GridNoColour[j + 1, i].Fill.ToString() == "#FFFFFF00")
                        {
                            LiveCounter += 1;
                        }
                        if (GridNoColour[j - 1, i].Fill.ToString() == "#FFFFFF00")
                        {
                            LiveCounter += 1;
                        }
                        if (GridNoColour[j - 1, i - 1].Fill.ToString() == "#FFFFFF00")
                        {
                            LiveCounter += 1;
                        }
                        if (GridNoColour[j - 1, i + 1].Fill.ToString() == "#FFFFFF00")
                        {
                            LiveCounter += 1;
                        }
                        if (GridNoColour[j + 1, i - 1].Fill.ToString() == "#FFFFFF00")
                        {
                            LiveCounter += 1;
                        }
                        if (GridNoColour[j + 1, i + 1].Fill.ToString() == "#FFFFFF00")
                        {
                            LiveCounter += 1;
                        }
                        MessageBox.Show(LiveCounter.ToString());
                    }
                    else
                    {

                    }
                }
            }
            dt.Start();
        }
    }
}
