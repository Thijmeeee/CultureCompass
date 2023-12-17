using CultureCompass.Information;
using SQLite;

namespace CultureCompass.Database
{
    public class Database
    {
        private SQLiteConnection _connection;
        private const string _databasePath = "database.db";
        public Database()
        {
            string applicationFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "CultureCompassDatabaseFile");
            Directory.CreateDirectory(applicationFolderPath);

            string databaseFileName = Path.Combine(applicationFolderPath, _databasePath);
            _connection = new SQLiteConnection(databaseFileName);

            _connection.CreateTable<WaypointTable>();
        }
        
        public void CreateWaypoint(Waypoint point)
        {
            if (point != null)
            {

                WaypointTable waypoint = new WaypointTable()
                {
                    WaypointId = point.ID,
                    Name = point.Name,
                    YearCreated = point.Year,
                    PictureName = point.ImagePath,
                    InfoEnglish = point.InfoEnglish,
                    InfoDutch = point.InfoDutch,
                    InfoFrench = point.InfoFrench,
                    XCoordinate = point.X,
                    YCoordinate = point.Y
                };
                _connection.Insert(waypoint);
            }
        }

        public Waypoint ReadWaypoint(int pointId)
        {
            return _connection.FindWithQuery<Waypoint>("SELECT * FROM WaypointTable WHERE [WaypointId] = ?", pointId);
        }

        public List<Waypoint> ReadWaypoints()
        {
            return _connection.FindWithQuery<List<Waypoint>>("SELECT * FROM WaypointTable");
        }

        public void UpdateWaypoint(WaypointTable updatedPoint)
        {
            _connection.Update(updatedPoint);
        }
        
        public void DeleteWaypoint(Waypoint point)
        {
            if (point != null)
            {
                WaypointTable waypoint = new WaypointTable()
                {
                    WaypointId = point.ID,
                    Name = point.Name,
                    YearCreated = point.Year,
                    PictureName = point.ImagePath,
                    InfoEnglish = point.InfoEnglish,
                    InfoDutch = point.InfoDutch,
                    InfoFrench = point.InfoFrench,
                    XCoordinate = point.X,
                    YCoordinate = point.Y
                };
                _connection.Delete<WaypointTable>(waypoint.WaypointId);
            }
        }

        public void CloseDatabase()
        {
            _connection.Close();
        }
    }
}
