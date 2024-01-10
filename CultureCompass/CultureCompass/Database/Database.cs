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
        
        public int CreateWaypoint(Waypoint point)
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
                return _connection.ExecuteScalar<int>("SELECT last_insert_rowid()");
            }
            else return 0;
        }

        public WaypointTable ReadWaypoint(int pointId)
        {
            var waypoint = from w in _connection.Table<WaypointTable>() where w.WaypointId == pointId select w;
            return waypoint.FirstOrDefault();
        }

        public List<Waypoint>? ReadWaypoints()
        {
            int count = _connection.Table<WaypointTable>().Count();
            if(count == 0)
            {
                return new List<Waypoint>();
            }
            else
            {
                return _connection.FindWithQuery<List<Waypoint>>("SELECT * FROM WaypointTable");
            }
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

        internal void DeleteAllWaypoints()
        {
            _connection.DeleteAll<WaypointTable>();
        }
    }
}
