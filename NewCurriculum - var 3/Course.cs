namespace NewCurriculum
{
    internal class Course
    {
        public int Code { get; set; }
        public string Title { get; set; }
        public bool IsSpecial { get; set; }
        public int LectureHours { get; set; }
        public int PractiseHours { get; set; }
        public bool HasExam { get; set; }
        public bool HasCoursePaper { get; set; }
        public List<int> Prerequisities { get; set; }

        public static List<Course> ListCourses = new List<Course> {
        new Course(
                    1,
                    "Объектно-ориентированное програмирование",
                    true,
                    150,
                    200,
                    true,
                    true,
                    new List<int>() { 2, 3 }),

                new Course(
                    2,
                    "Дискретная математика",
                    true,
                    40,
                    20,
                    true,
                    false,
                    null),

                new Course(
                    3,
                    "Математический анализ",
                    true,
                    40,
                    20,
                    true,
                    false,
                    null),

                new Course(
                    4,
                    "Русский язык",
                    false,
                    10,
                    30,
                    true,
                    false,
                    null),

                new Course(
                    5,
                    "Английский язык",
                    false,
                    10,
                    70,
                    true,
                    false,
                    null),

                new Course(
                    6,
                    "Алгебра и геометрия",
                    false,
                    150,
                    200,
                    true,
                    false,
                    null),

                new Course(
                    7,
                    "Физкультура",
                    false,
                    150,
                    200,
                    true,
                    false,
                    null),

                new Course(
                    8,
                    "Веб-разработка",
                    false,
                    5,
                    40,
                    true,
                    false,
                    null),

                new Course(
                    9,
                    "Язык программирования C++",
                    true,
                    30,
                    150,
                    true,
                    true,
                    new List<int>() { 2, 3, 6 }),

                new Course(
                    10,
                    "Язык программирования C#",
                    true,
                    30,
                    150,
                    true,
                    true,
                    new List<int>() { 2, 3, 6 }),

                new Course(
                    11,
                    "Язык программирования Java",
                    true,
                    30,
                    150,
                    true,
                    true,
                    new List<int>() { 2, 3, 6 }),

                new Course(
                    12,
                    "Черчение",
                    false,
                    10,
                    50,
                    true,
                    false,
                    new List<int> { 6 }),

                new Course(
                    13,
                    "История Руси",
                    false,
                    50,
                    10,
                    true,
                    false,
                    null),

                new Course(
                    14,
                    "История до нашей эры",
                    false,
                    50,
                    10,
                    true,
                    false,
                    null),

                new Course(
                    15,
                    "Язык программирования Python",
                    true,
                    20,
                    120,
                    true,
                    true,
                    new List<int>() { 2, 3 })};

        public Course(int code, string title, bool isSpecial, int lectureHours,
            int practiseHours, bool hasExam, bool hasCoursePaper, List<int> prerequisities)
        {
            Code = code;
            Title = title;
            IsSpecial = isSpecial;
            LectureHours = lectureHours;
            PractiseHours = practiseHours;
            HasExam = hasExam;
            HasCoursePaper = hasCoursePaper;
            Prerequisities = prerequisities;
        }

        public override string ToString()
        {
            return "[---------------------\n" +
                $"\tКод: {Code}\n" +
                $"\tНазвание: {Title}\n " +
                $"\tСпецкурс: {IsSpecial}\n " +
                $"\tКоличество часов лекций: {LectureHours}\n " +
                $"\tКоличество часов практик: {PractiseHours}\n " +
                $"\tЭкзамен: {HasExam}\n " +
                $"\tКурсовая работа: {HasCoursePaper}\n" + //Номера дополнительных курсов: {PrintPrerequisities()
                $"\tНомера дополнительных курсов: {PrintPrerequisities()}\n" +
                "---------------------]";
        }

        public static Course GetCourse(int code)
        {
            foreach (Course course in ListCourses)
                if (course.Code == code) return course;
            return null;
        }

        public string PrintPrerequisities()
        {
            if (Prerequisities != null)
            {
                string r = "";
                foreach (int numberCourse in Prerequisities)
                    r += $"{Convert.ToString(numberCourse)} ";

                return r;
            }
            return "[пусто]";
        }
    }
}
