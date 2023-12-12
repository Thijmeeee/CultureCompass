using CultureCompass.Database;
using CultureCompass.Information;

namespace CultureCompass.UI
{
    public partial class MainPage : ContentPage
    {
        private Database.Database _database;
        public MainPage()
        {
            InitializeComponent();
            TestDatabase();
        }

        private void TestDatabase()
        {
            //create database
            _database = new Database.Database();
            
            //create waypoint
            Waypoint waypoint = new Waypoint()
            {
                WaypointId = 1,
                Name = "test",
                YearCreated = 2,
                PictureName = "what",
                InfoEnglish = "yes",
                InfoDutch = "ja",
                InfoFrench = "oui",
                XCoordinate = 1.2,
                YCoordinate = 16.7
            };
            
            //create and save new database waypoint object
            _database.CreateWaypoint(waypoint);
            
            //get/read waypoint object from database by name
            Waypoint received =  _database.ReadWaypoint("test");
            
            //make database waypoint object
            WaypointTable updatedReceived = new WaypointTable()
            {
                WaypointId = received.WaypointId,
                Name = received.Name,
                YearCreated = 6969,
                PictureName = received.PictureName,
                InfoEnglish = received.InfoEnglish,
                InfoDutch = received.InfoDutch,
                InfoFrench = received.InfoFrench,
                XCoordinate = received.XCoordinate,
                YCoordinate = received.YCoordinate
            };
            
            //update the existing waypoint in the database by giving new object
            //primary key (waypointid) is the same, so will overwrite it
            _database.UpdateWaypoint(updatedReceived);
            
            //get/read new updated waypoint object
            Waypoint newReceived =  _database.ReadWaypoint("test");
            
            //show properties of waypoint object in labels in app
            waypointid.Text = newReceived.WaypointId.ToString();
            name.Text = newReceived.Name;
            yearcreated.Text = newReceived.YearCreated.ToString();
            picturename.Text = newReceived.PictureName;
            infoenglish.Text = newReceived.InfoEnglish;
            infodutch.Text = newReceived.InfoDutch;
            infofrench.Text = newReceived.InfoFrench;
            xcoordinate.Text = newReceived.XCoordinate.ToString();
            ycoordinate.Text = newReceived.YCoordinate.ToString();
            
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
    }
}
