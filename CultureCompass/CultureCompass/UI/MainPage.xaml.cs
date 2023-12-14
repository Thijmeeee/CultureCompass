using CultureCompass.Database;
using CultureCompass.Information;
using CultureCompass.Navigation;
using Microsoft.Maui.Controls.Maps;
using Map = Microsoft.Maui.Controls.Maps.Map;
﻿using CultureCompass.UI;

namespace CultureCompass.UI
{
    public partial class MainPage : ContentPage
    {
        private Database.Database _database;
        public MainPage()
        {
            InitializeComponent();

           // TestDatabase();
        }

        private void TestDatabase()
        {
            //create database
            _database = new Database.Database();

            
            //create waypoint
            Waypoint waypoint = new Waypoint()
            {
                ID = 1,
                Name = "test",
                Year = 2,
                ImagePath = "what",
                InfoEnglish = "yes",
                InfoDutch = "ja",
                InfoFrench = "oui",
                X = 1.2,
                Y = 16.7
            };
            
            //create and save new database waypoint object
            _database.CreateWaypoint(waypoint);
            
            //get/read waypoint object from database by id
            Waypoint received =  _database.ReadWaypoint(1);
            
            //make database waypoint object
            WaypointTable updatedReceived = new WaypointTable()
            {
                WaypointId = received.ID,
                Name = received.Name,
                YearCreated = 6969,
                PictureName = received.ImagePath,
                InfoEnglish = received.InfoEnglish,
                InfoDutch = received.InfoDutch,
                InfoFrench = received.InfoFrench,
                XCoordinate = received.X,
                YCoordinate = received.Y
            };
            
            //update the existing waypoint in the database by giving new object
            //primary key (waypointid) is the same, so will overwrite it
            _database.UpdateWaypoint(updatedReceived);
            
            //get/read new updated waypoint object
            Waypoint newReceived =  _database.ReadWaypoint(1);
            
            //show properties of waypoint object in labels in app
            //waypointid.Text = newReceived.ID.ToString();
            //name.Text = newReceived.Name;
            //yearcreated.Text = newReceived.Year.ToString();
            //picturename.Text = newReceived.ImagePath;
            //infoenglish.Text = newReceived.InfoEnglish;
            //infodutch.Text = newReceived.InfoDutch;
            //infofrench.Text = newReceived.InfoFrench;
            //xcoordinate.Text = newReceived.X.ToString();
            //ycoordinate.Text = newReceived.Y.ToString();
            
            //xaml code:
            // <Label x:Name="waypointid"></Label>
            // <Label x:Name="name"></Label>
            // <Label x:Name="yearcreated"></Label>
            // <Label x:Name="picturename"></Label>
            // <Label x:Name="infoenglish"></Label>
            // <Label x:Name="infodutch"></Label>
            // <Label x:Name="infofrench"></Label>
            // <Label x:Name="xcoordinate"></Label>
            // <Label x:Name="ycoordinate"></Label>
            
        }

       

        public void OnStartClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NavigationPage());
        }
    }
}
