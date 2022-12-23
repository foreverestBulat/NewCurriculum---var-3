namespace NewCurriculum
{
    internal class Curriculum
    {
        public int Code { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ConfirmationDate { get; set; }
        public Student Student { get; set; }
        public int DegreeCode { get; set; }

        public Curriculum(Student student = null, int degreeCode = 0, int code = 0, DateTime creationDate = new DateTime())
        {
            Student = student;
            DegreeCode = degreeCode;
            Code = code;
            CreationDate = creationDate;
        }

        public void AddNewCourse(int code, string title, bool isSpecial, int lectureHours,
            int practiseHours, bool hasExam, bool hasCoursePaper, List<int> prerequisities)
        {
            Course course = new Course(code, title, isSpecial, lectureHours,
                practiseHours, hasExam, hasCoursePaper, prerequisities);
            Course.ListCourses.Add(course);
        }

        public void DeleteCourse(int code)
        {
            for (int i = 0; i < Course.ListCourses.Count; i++)
                if (Course.ListCourses[i].Code == code)
                    Course.ListCourses.RemoveAt(i);
        }




        public void CheckSelectedCourses(List<int> selectedCourses, int i = 0)
        {
            // Поскольку некоторые курсы содержат дополнительные курсы,
            // то этот метод проверяет есть номера этих доп курсов в выбранных.
            // Если нету, то его добавляет
            // я сделал рекурсию, потому что если сделать циклом, то выйдет ошибка связанная с тем,
            // что список выбранных курсов изменяется, что нельзя делать во время цикла

            if (i >= selectedCourses.Count) return;

            var code = selectedCourses[i];

            if (Course.GetCourse(code).Prerequisities == null)
            {
                CheckSelectedCourses(selectedCourses, ++i);
                return;
            }

            foreach (int numAdditionalCourse in Course.GetCourse(code).Prerequisities)
            {
                if (!selectedCourses.Contains(numAdditionalCourse))
                {
                    Console.WriteLine("--");
                    selectedCourses.Add(numAdditionalCourse);
                }
            }

            CheckSelectedCourses(selectedCourses, ++i);
        }

        public bool LaborIntensityOfCourse(List<int> numbers, int countCredit, int needingCountSpecialCourse)
        {
            int c = 0;
            int lecH = 0;
            int pracH = 0;

            int countSpecialCourse = 0;

            for (int i = 0; i < Course.ListCourses.Count; i++)
            {
                if (numbers.Contains(Course.ListCourses[i].Code))
                {
                    lecH += Course.ListCourses[i].LectureHours;
                    pracH += Course.ListCourses[i].PractiseHours;

                    if (Course.ListCourses[i].HasExam) c++;
                    if (Course.ListCourses[i].HasCoursePaper) c += 2;
                    if (Course.ListCourses[i].IsSpecial) countSpecialCourse++;
                }
            }

            c += (int)(lecH + pracH * 1.25) / 18;

            if (countSpecialCourse >= needingCountSpecialCourse)
            {
                return c >= countCredit;
            }

            Console.WriteLine("Не хватает кол-ва спецкурсов");
            return false;
        }

        public void PrintCourse()
        {
            Console.WriteLine("Список курсов:");

            foreach (Course course in Course.ListCourses)
                Console.WriteLine(course.ToString());
        }

        public void PrintDegrees()
        {
            Console.WriteLine("Список квалификационных степеней: ");
            foreach (var degree in Degree.ListDegree)
                Console.WriteLine(degree.ToString());
        }


    public void ExchangeDegree(int code)
        {
            Console.WriteLine("Изменить нужное кол-во спец-курсов 1\n" +
                "Изменить нужное кол-во кредитов для получения: 2\n" +
                "Написать свое условие(письменно): 3\n");

            int change = int.Parse(Console.ReadLine());
            switch (change)
            {
                case 1:
                    Degree.GetDegree(code).SpecialCoursesRequired = int.Parse(Console.ReadLine());
                    break;

                case 2:
                    Degree.GetDegree(code).CreditsRequired = int.Parse(Console.ReadLine());
                    break;

                case 3:
                    Degree.GetDegree(code).OtherCondition = Console.ReadLine();
                    break;

                default:
                    break;
            }
        }

        public void ExchangeCourse()
        {
            PrintCourse();

            Console.WriteLine("Напишите код курса, который вы хотите изменить: ");

            int code = int.Parse(Console.ReadLine());

            Console.WriteLine("Сделать курс специальным/обычным: 1\n" +
                "Изменить кол-во часов лекций: 2\n" +
                "Изменить кол-во часов практики: 3\n" +
                "Сделать курс с экзаменом/без экзамена: 4\n" +
                "Сделать курс с курсовой работой/без курсовой работы: 5\n" +
                "Добавить номера доп-курсов: 6\n");

            var change = int.Parse(Console.ReadLine());
            switch (change)
            {
                case 1:
                    Course.GetCourse(code).IsSpecial = !Course.GetCourse(code).IsSpecial;
                    break;

                case 2:
                    Course.GetCourse(code).LectureHours = int.Parse(Console.ReadLine());
                    break;

                case 3:
                    Course.GetCourse(code).PractiseHours = int.Parse(Console.ReadLine());
                    break;

                case 4:
                    Course.GetCourse(code).HasExam = !Course.GetCourse(code).HasExam;
                    break;

                case 5:
                    Course.GetCourse(code).HasCoursePaper = !Course.GetCourse(code).HasCoursePaper;
                    break;

                case 6:
                    string str = Console.ReadLine();
                    if (str != "")
                        foreach (string i in str.Split(' '))
                        {
                            if (!Course.GetCourse(code).Prerequisities.Contains(int.Parse(i)))
                                Course.GetCourse(code).Prerequisities.Add(int.Parse(i));
                        }
                    break;

                default:
                    break;
            }
        }
    }
}
