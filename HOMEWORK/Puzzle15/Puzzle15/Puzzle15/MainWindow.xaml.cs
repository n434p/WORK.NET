﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace Puzzle15
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int btnSize;
        int move = 0;
        Button space;
        Button target;
        Game g = new Game();

        public MainWindow()
        {
            InitializeComponent();
            Init();
            currentNum.ItemsSource = g.table.Values;
           
                
        }

        public void Init() 
        {
            btnSize = g.btnSize;
            foreach (var item in g.table)
            {
                Button b = new Button();
                b.Click += b_Click;
                b.Height = b.Width = btnSize;
                b.Content = item.Value;
                b.Margin = new Thickness(item.Key.X,item.Key.Y,0,0);
                if (b.Content.ToString() == "0") {b.Opacity = 0; space = b;}
                field.Children.Add(b);
            }
        }

        void b_Click(object sender, RoutedEventArgs e)
        {
            target = sender as Button;
            move++;
            Swap();
            if (g.Win()) MessageBox.Show("You win!", "Congrats!");
        }



        void Swap() 
        {   
            //logical
            g.space = new Point(space.Margin.Left, space.Margin.Top);
            g.target = new Point(target.Margin.Left, target.Margin.Top);
            if (g.Swap()) 
            {
            // visual
            Thickness s = target.Margin;
            target.Margin = space.Margin;
            space.Margin = s;
            }
           
            
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {

            //(byte)currentNum.SelectedItem
            g.Process();
            g.Rotation(g.Current);
            Button b = new Button();
            foreach (var item in field.Children)
            {
                b = item as Button;
                if (b.Margin.Left == g.target.X && b.Margin.Top == g.target.Y) break;
            }
            target = b;
            spaceL.Content = "SPACE: " + g.space;
            targetL.Content = "TARGET: " + g.target;
            goalL.Content = "FIT: " + g.fit.Count;
            move++;
            window.Title = "Puzzle15 MOVE: " + move;
            Swap();
           
            if (g.Win()) MessageBox.Show("Puzzle complete!", "Congrats!");
        }

    
       
    }
}
