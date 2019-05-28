﻿using System;
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
        int gridSize;

        Rectangle w = new Rectangle();

        Rectangle[,] GridNoColour;
        Rectangle[,] FutureGrid;
        //Rectangle[][] grid = new Rectangle[20][];
        

        DispatcherTimer dt = new DispatcherTimer();

        public MainWindow()
        {
            InitializeComponent();
            //variables
            gridSize = 20;
            GridNoColour = new Rectangle[gridSize, gridSize];
            FutureGrid = new Rectangle[gridSize, gridSize];

            dt.Interval = new TimeSpan(0,0,1);
            dt.Tick += Dt_Tick;

            for (int j = 0; j < gridSize; j++)
            {
                for (int i = 0; i < gridSize; i++)
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

            //debugging
           // for (int i = 1; i < 4; i++)
            //{
              //  GridNoColour[i, 1].Fill = Brushes.Yellow;
                //GridNoColour[i%2+1, 2].Fill = Brushes.Yellow;
            //}
            //end debugging

            for (int j = 0; j < gridSize; j++)
            {
                for (int i = 0; i < gridSize; i++)
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
            for (int j = 0; j < gridSize; j++)
            {
                for (int i = 0; i < gridSize; i++)
                {
                    LiveCounter = 0;
                    if (i < gridSize-1 &&
                        GridNoColour[j, i + 1].Fill.ToString() == "#FFFFFF00")
                    {
                        LiveCounter += 1;
                    }
                    if (i>0 &&
                        GridNoColour[j, i - 1].Fill.ToString() == "#FFFFFF00")
                    {
                        LiveCounter += 1;
                    }
                    if (j< gridSize - 1 &&
                        GridNoColour[j + 1, i].Fill.ToString() == "#FFFFFF00")
                    {
                        LiveCounter += 1;
                    }
                    if (j > 0 &&
                        GridNoColour[j - 1, i].Fill.ToString() == "#FFFFFF00")
                    {
                        LiveCounter += 1;
                    }
                    if (j > 0 && i > 0 &&
                        GridNoColour[j - 1, i - 1].Fill.ToString() == "#FFFFFF00")
                    {
                        LiveCounter += 1;
                    }
                    if (j > 0 && i < gridSize - 1 &&
                        GridNoColour[j - 1, i + 1].Fill.ToString() == "#FFFFFF00")
                    {
                        LiveCounter += 1;
                    }
                    if (i > 0 && j < gridSize - 1 &&
                        GridNoColour[j + 1, i - 1].Fill.ToString() == "#FFFFFF00")
                    {
                        LiveCounter += 1;
                    }
                    if (j < gridSize - 1 && i < gridSize - 1 &&
                        GridNoColour[j + 1, i + 1].Fill.ToString() == "#FFFFFF00")
                    {
                        LiveCounter += 1;
                    }
              //      MessageBox.Show(LiveCounter.ToString());
               
                    if (GridNoColour[j, i].Fill.ToString() == "#FFFFFF00")
                    {
                      
                        if (LiveCounter == 3|| LiveCounter==2)

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

                        //  FutureGrid[j, i].Fill = Brushes.Yellow;
                    }
                    else 
                    {
                        if (LiveCounter == 3)
                        {
                            FutureGrid[j, i].Fill = Brushes.Yellow;
                        }



                    }

                }
            }
            

//            GridNoColour = FutureGrid;
            for (int j = 0; j < gridSize; j++)
            {
                for (int i = 0; i < gridSize; i++)
                {
                    GridNoColour[j, i].Fill = FutureGrid[j, i].Fill;
                    FutureGrid[j, i].Fill = Brushes.White;
                }
            }
            
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
           
            dt.Start();
        }

        private void GamePause_Click(object sender, RoutedEventArgs e)
        {
            dt.Stop();
        }
    }
}
