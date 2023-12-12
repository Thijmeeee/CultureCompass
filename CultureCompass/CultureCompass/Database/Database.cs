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
            string applicationFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "DatabaseFile");
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
                    WaypointId = point.WaypointId,
                    Name = point.Name,
                    YearCreated = point.YearCreated,
                    PictureName = point.PictureName,
                    InfoEnglish = point.InfoEnglish,
                    InfoDutch = point.InfoDutch,
                    InfoFrench = point.InfoFrench,
                    XCoordinate = point.XCoordinate,
                    YCoordinate = point.YCoordinate
                };
                _connection.Insert(waypoint);
            }
        }

        public Waypoint ReadWaypoint(string name)
        {
            return _connection.FindWithQuery<Waypoint>("SELECT * FROM WaypointTable WHERE [Name] = ?", name);
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
                    WaypointId = point.WaypointId,
                    Name = point.Name,
                    YearCreated = point.YearCreated,
                    PictureName = point.PictureName,
                    InfoEnglish = point.InfoEnglish,
                    InfoDutch = point.InfoDutch,
                    InfoFrench = point.InfoFrench,
                    XCoordinate = point.XCoordinate,
                    YCoordinate = point.YCoordinate
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
