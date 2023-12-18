using CultureCompass.Database;
using CultureCompass.Information;
using CultureCompass.Navigation;
using Microsoft.Maui.Controls.Maps;
using Map = Microsoft.Maui.Controls.Maps.Map;
using CultureCompass.UI;

namespace CultureCompass.UI
{
    public partial class MainPage : ContentPage
    {
        private Database.Database _database;
        public MainPage()
        {
            InitializeComponent();

            //RouteManager routeManager = new RouteManager(new NavigationPage());
            //routeManager.SetRoute(new Route());

           // LoadWaypointsIntoDatabase();

            // TestDatabase();
        }

        private void LoadWaypointsIntoDatabase()
        {
            Waypoint waypoint1 = new Waypoint()
            {
                ID = 1,
                X = 4.774812,
                Y = 51.58905,
                Name = "Grote Kerk Breda",
                Year = 1410,
                ImagePath = "grote_kerk_breda.jpg",
                InfoEnglish = "The church is the landmark of Breda. It is the most important monument in Breda. The tower is 97 meters high.",
                InfoFrench = "L'église est l'emblème de Breda. C'est le monument le plus important de Breda. La tour mesure 97 mètres de haut.",
                InfoDutch = "De kerk is hét herkenningspunt van Breda. Het is het belangrijkste monument van Breda. De toren is 97 meter hoog."
            };

            Waypoint waypoint2 = new Waypoint()
            {
                ID = 2,
                X = 3.824452,
                Y = 50.889297,
                Name = "Kasteel van Breda",
                Year = 1353,
                ImagePath = "kasteel_van_breda.jpg",
                InfoEnglish = "Since 1826, the Royal Military Academy has been located in the castle. The castle was restored around 1900.",
                InfoFrench = "Depuis 1826, l'Académie Royale Militaire est installée dans le château. Le château a été restauré vers 1900.",
                InfoDutch = "Sinds 1826 is de Koninklijke Militaire Academie gevestigd in het kasteel. Het kasteel is rond 1900 gerestaureerd."
            };

            Waypoint waypoint3 = new Waypoint()
            {
                ID = 3,
                X = 4.779008,
                Y = 51.5914394,
                Name = "Valkenberg Park Breda",
                Year = 1537,
                ImagePath = "valkenberg_park_breda.jpg",
                InfoEnglish = "The park is located on the transit route to Central Station. The park used to be the garden of the castle.",
                InfoFrench = "Le parc est situé sur la voie de transit vers la gare centrale. Le parc était autrefois le jardin du château.",
                InfoDutch = "Het park ligt op de doorgangsroute naar het Centraal Station. Vroeger was het park de tuin van het kasteel."
            };

            Waypoint waypoint4 = new Waypoint()
            {
                ID = 4,
                X = 4.7733628,
                Y = 51.5908353,
                Name = "Spanjaardsgat Breda",
                Year = 1590,
                ImagePath = "spanjaardsgat_breda.jpg",
                InfoEnglish = "The Spanjaardsgat is a water gate located between the Granaattoren and the Pigeon Tower of Breda Castle.",
                InfoFrench = "Le Spanjaardsgat est une porte d'eau située entre le Granaattoren et le pigeonnier du château de Breda.",
                InfoDutch = "Het Spanjaardsgat is een waterpoort die ligt tussen de Granaattoren en de Duiventoren van het Kasteel van Breda."
            };

            Waypoint waypoint5 = new Waypoint()
            {
                ID = 5,
                X = 4.7766003,
                Y = 51.5901373,
                Name = "Begijnhof Breda",
                Year = 1267,
                ImagePath = "begijnhof_breda.jpg",
                InfoEnglish = "The Begijnhof is a complex surrounded by walls consisting of houses and a small church in the center of Breda.",
                InfoFrench = "Le Begijnhof est un complexe entouré de murs composé de maisons et d'une petite église au centre de Breda.",
                InfoDutch = "De Begijnhof is een door muren omringd complex wat bestaat uit huisjes en een kleine kerk in het centrum van Breda."
            };

            Waypoint waypoint6 = new Waypoint()
            {
                ID = 6,
                X = 4.7764614,
                Y = 51.589438,
                Name = "Miniaturen en Poppenhuismuseum Breda",
                Year = 1883,
                ImagePath = "miniaturen_en_poppenhuismuseum_breda.jpg",
                InfoEnglish = "In this museum you will find centuries-old miniatures of reality. It consists of 20 houses.",
                InfoFrench = "Dans ce musée, vous trouverez des miniatures séculaires de la réalité. Il se compose de 20 maisons.",
                InfoDutch = "In dit museum vind je eeuwen oude miniatuur van de werkelijkheid. Het bestaat uit 20 huisjes."
            };

            Waypoint waypoint7 = new Waypoint()
            {
                ID = 7,
                X = 4.7810102,
                Y = 51.5896392,
                Name = "Stedelijk Museum Breda",
                Year = 1903,
                ImagePath = "stedelijk_museum_breda.jpg",
                InfoEnglish = "This is a museum for the heritage and history of Breda. The museum emerged from the Museum of the Image and Breda's museum.",
                InfoFrench = "Il s'agit d'un musée sur le patrimoine et l'histoire de Breda. Le musée est issu du Musée de l'Image et du musée de Breda.",
                InfoDutch = "Dit is een museum voor erfgoed en geschiedenis van Breda. Het museum is voorgekomen uit het Museum of the Image en het Breda's museum."
            };

            Waypoint waypoint8 = new Waypoint()
            {
                ID = 8,
                X = 4.7834422,
                Y = 51.5626307,
                Name = "Kasteel Bouvigne",
                Year = 1554,
                ImagePath = "kasteel_bouvigne.jpg",
                InfoEnglish = "",
                InfoFrench = "",
                InfoDutch = ""
            };

            Waypoint waypoint9 = new Waypoint()
            {
                ID = 9,
                X = 4.8152961,
                Y = 51.5929603,
                Name = "Reptielenhuis De Aarde",
                Year = 2012,
                ImagePath = "reptielenhuis_de_aarde.jpg",
                InfoEnglish = "A total of eight princes in succession have owned the castle. It served as headquarters.",
                InfoFrench = "Au total, huit princes se sont succédé en possession du château. Il servait de quartier général.",
                InfoDutch = "In totaal hebben achter elkaar acht prinsen het kasteel in hun bezit. Het heeft gediend als hoofdkwartier."
            };

            Waypoint waypoint10 = new Waypoint()
            {
                ID = 10,
                X = 4.7474242,
                Y = 51.5818591,
                Name = "Maczek Memorial Breda",
                Year = 2020,
                ImagePath = "maczek_memorial_breda.jpg",
                InfoEnglish = "This is a museum that tells the story of the liberation of Breda. It emerged from the General Maczek Museum from 2015.",
                InfoFrench = "C'est un musée qui raconte l'histoire de la libération de Breda. Il est sorti du Musée Général Maczek en 2015.",
                InfoDutch = "Dit is een museum dat het verhaal vertelt van de bevrijding van Breda. Het is voortgekomen uit het Generaal Maczek Museum uit 2015."
            };

            DatabaseManager databaseManager = new DatabaseManager();
            databaseManager.AddWaypoint(waypoint1);
            databaseManager.AddWaypoint(waypoint2);
            databaseManager.AddWaypoint(waypoint3);
            databaseManager.AddWaypoint(waypoint4);
            databaseManager.AddWaypoint(waypoint5);
            databaseManager.AddWaypoint(waypoint6);
            databaseManager.AddWaypoint(waypoint7);
            databaseManager.AddWaypoint(waypoint8);
            databaseManager.AddWaypoint(waypoint9);
            databaseManager.AddWaypoint(waypoint10);
        }

        //private void TestDatabase()
        //{
        //    //create database
        //    _database = new Database.Database();


        //    //create waypoint
        //    Waypoint waypoint = new Waypoint()
        //    {
        //        ID = 1,
        //        Name = "test",
        //        Year = 2,
        //        ImagePath = "what",
        //        InfoEnglish = "yes",
        //        InfoDutch = "ja",
        //        InfoFrench = "oui",
        //        X = 1.2,
        //        Y = 16.7
        //    };

        //    //create and save new database waypoint object
        //    _database.CreateWaypoint(waypoint);

        //    //get/read waypoint object from database by id
        //    Waypoint received = _database.ReadWaypoint(1);

        //    //make database waypoint object
        //    WaypointTable updatedReceived = new WaypointTable()
        //    {
        //        WaypointId = received.ID,
        //        Name = received.Name,
        //        YearCreated = 6969,
        //        PictureName = received.ImagePath,
        //        InfoEnglish = received.InfoEnglish,
        //        InfoDutch = received.InfoDutch,
        //        InfoFrench = received.InfoFrench,
        //        XCoordinate = received.X,
        //        YCoordinate = received.Y
        //    };

        //    //update the existing waypoint in the database by giving new object
        //    //primary key (waypointid) is the same, so will overwrite it
        //    _database.UpdateWaypoint(updatedReceived);

        //    //get/read new updated waypoint object
        //    Waypoint newReceived = _database.ReadWaypoint(1);

        //    //show properties of waypoint object in labels in app
        //    //waypointid.Text = newReceived.ID.ToString();
        //    //name.Text = newReceived.Name;
        //    //yearcreated.Text = newReceived.Year.ToString();
        //    //picturename.Text = newReceived.ImagePath;
        //    //infoenglish.Text = newReceived.InfoEnglish;
        //    //infodutch.Text = newReceived.InfoDutch;
        //    //infofrench.Text = newReceived.InfoFrench;
        //    //xcoordinate.Text = newReceived.X.ToString();
        //    //ycoordinate.Text = newReceived.Y.ToString();

        //    //xaml code:
        //    // <Label x:Name="waypointid"></Label>
        //    // <Label x:Name="name"></Label>
        //    // <Label x:Name="yearcreated"></Label>
        //    // <Label x:Name="picturename"></Label>
        //    // <Label x:Name="infoenglish"></Label>
        //    // <Label x:Name="infodutch"></Label>
        //    // <Label x:Name="infofrench"></Label>
        //    // <Label x:Name="xcoordinate"></Label>
        //    // <Label x:Name="ycoordinate"></Label>

        //}

        public void OnStartClicked(object sender, EventArgs e)
        {
            RouteCollection routeCollection = new RouteCollection();
            var routes = routeCollection.routes;

            ChooseRoutePage chooseRoutePage = new ChooseRoutePage();
            chooseRoutePage.BindingContext = routes;

            Navigation.PushAsync(chooseRoutePage);
        }
    }
}
