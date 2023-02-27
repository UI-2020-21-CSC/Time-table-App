

namespace Time_table.Model
{
    //The lecturer model
    public class Lecturer
    {
        public UInt16 Id { get; set; }
        public string Name { get; set; }

    }

    //The Venue Model
    public class Venue
    {
        public UInt16 Id { get; set; }
        public string Name { get; set; }
        public UInt16 capacity { get; set; }
        
    }

    //The Course Model
    public class Course
    {
        public UInt16 Id { get; set; }

        public string Name { get; set; }
        public string FullName { get; set; }

        public Lecturer CourseLecturer { get; set; }

    }

    //The time table cell model by hour
    public class Cell
    {
        public UInt16 Id { get; set; }
    }
}
