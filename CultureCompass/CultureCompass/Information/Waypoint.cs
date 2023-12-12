namespace CultureCompass.Information
{
    public class Waypoint
    {
        public int WaypointId { get; set; }
        public string Name { get; set; }
        public int YearCreated { get; set; }
        public string PictureName { get; set; }
        public string InfoEnglish { get; set; }
        public string InfoDutch { get; set; }
        public string InfoFrench { get; set; }
        public double XCoordinate { get; set; }
        public double YCoordinate { get; set; }
    }
}
