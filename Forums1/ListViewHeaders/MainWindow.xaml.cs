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

namespace ListViewHeaders
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<classTeam> Teams = new List<classTeam>();

        public MainWindow()
        {
            InitializeComponent();
            classTeam team;
            //
            team = new classTeam();
            team.Pos = 1;
            team.Team = "Cougars";
            team.Data = "2 9 5";
            Teams.Add(team);
            //
            team = new classTeam();
            team.Pos = 2;
            team.Team = "Whales";
            team.Data = "9 5 3";
            Teams.Add(team);
            //
            team = new classTeam();
            team.Pos = 3;
            team.Team = "Hats";
            team.Data = "4 0 2";
            Teams.Add(team);
            //
            TeamGrid.ItemsSource = Teams;
        }
    }

    public class classTeam
    {
        public int Pos { get; set; }
        public string Team { get; set; }
        public string Data { get; set; }
    }
}

/*
        <ListView x:Name="ListTeams">
            <ListView.ItemTemplate>
                <DataTemplate>
                    <Grid>
                        <Grid.ColumnDefinitions>
                            <ColumnDefinition x:Name="PosCol" Width="2*"/>
                            <ColumnDefinition x:Name="TeamCol" Width="20*"/>
                            <ColumnDefinition x:Name="DataCol" Width="Auto"/>
                        </Grid.ColumnDefinitions>
                        <TextBox Grid.Column="0" x:Name="BoxPos" Text="{Binding Pos}"/>
                        <TextBox Grid.Column="1" x:Name="BoxTean" Text="{Binding Team}"/>
                        <TextBox Grid.Column="2" x:Name="BoxData" Text="{Binding Data}"/>
                    </Grid>
                </DataTemplate>
            </ListView.ItemTemplate>
        </ListView>
 */
