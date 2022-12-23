using NewCurriculum;

Curriculum curriculum = new Curriculum();

while (true)
{
    Console.WriteLine("Создать учебную программу: 1\n" +
        "Добавить учебный курс: 2\n" +
        "Изменить правила получения квалификационной степени: 3\n" +
        "Изменить курс: 4\n" +
        "Показать квалификационные степени: 5\n" +
        "Показать курсы: 6\n" +
        "Удалить курс: 7\n" +
        "Закончить программу: 8");


    int change = int.Parse(Console.ReadLine());

    switch (change)
    {
        case 1:
            Console.WriteLine("Введите номер заявления: ");
            int applicationNumber = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите ФИО студента: ");
            string fullName = Console.ReadLine();

            Console.WriteLine("Введите регистрационный номер учебной программы: ");
            int regNumber = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите через пробел дату рождения студента(дд/мм/гггг): ");
            string[] date = Console.ReadLine().Split(' ');
            DateTime dateBirth = new DateTime(int.Parse(date[2]), int.Parse(date[1]), int.Parse(date[0]));

            var student = new Student(applicationNumber, fullName, dateBirth);

            Console.WriteLine("Выберите квалификационную степень: ");
            curriculum.PrintDegrees();
            int code = int.Parse(Console.ReadLine());

            curriculum = new Curriculum(student, code, regNumber, DateTime.Now);

            Console.WriteLine("Выберите какие курсы вы хотите изучить(вводите номера курсов через пробел): ");
            curriculum.PrintCourse();
            string strSelectedСourses = Console.ReadLine();
            List<int> selectedCourses = new List<int>();
            foreach (var num in strSelectedСourses.Split(' '))
                selectedCourses.Add(int.Parse(num));

            curriculum.CheckSelectedCourses(selectedCourses);

            //foreach (var i in selectedCourses)
            //    Console.WriteLine(i);

            if (curriculum.LaborIntensityOfCourse(selectedCourses, Degree.ListDegree[code - 1].CreditsRequired, Degree.ListDegree[code - 1].SpecialCoursesRequired))
            {
                Console.WriteLine("Вы можете получить выбранную степень");

                Console.Write("Ваши курсы: ");
                foreach (var i in selectedCourses)
                    Console.Write($"{i} ");
                Console.WriteLine();
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Вы не можете получить выбранную степень");
            }
            continue;

        case 2:
            Console.WriteLine("Введите название нового курса: ");
            string title = Console.ReadLine();

            Console.WriteLine("Ваш курс является специальным(ДА - 1, НЕТ - 0)?");
            int intSpecCourse = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите кол-во часов лекций: ");
            int lectureHours = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите кол-во часов практик: ");
            int practiseHours = int.Parse(Console.ReadLine());

            Console.WriteLine("У вашего курса есть экзамен(ДА - 1, НЕТ - 0)?");
            int intHasExam = int.Parse(Console.ReadLine());

            Console.WriteLine("У вашего курса есть курсовая работа(ДА - 1, НЕТ - 0)?");
            int intHasCoursePaper = int.Parse(Console.ReadLine());

            Console.WriteLine("Напишите номера курсов через пробел(если нету, ничего не пишите): ");
            curriculum.PrintCourse();

            List<int> numbers = null;

            string str = Console.ReadLine();
            if (str != "")
                foreach (var number in str.Split())
                {
                    numbers = new List<int>();
                    numbers.Add(int.Parse(number));
                }

            curriculum.AddNewCourse(Course.ListCourses.Count + 1, title, Convert.ToBoolean(intSpecCourse), lectureHours, practiseHours, Convert.ToBoolean(intHasExam), Convert.ToBoolean(intHasCoursePaper), numbers);
            continue;

        case 3:
            curriculum.PrintDegrees();

            Console.WriteLine("Напишите код курса, который хотите изменить");

            code = int.Parse(Console.ReadLine());

            curriculum.ExchangeDegree(code);

            continue;

        case 4:
            curriculum.ExchangeCourse();
            continue;

        case 5:
            curriculum.PrintDegrees();
            continue;

        case 6:
            curriculum.PrintCourse();
            continue;

        case 7:
            Console.WriteLine("Напишите код курса который хотите удалить: ");
            curriculum.PrintCourse();
            int a = int.Parse(Console.ReadLine());

            curriculum.DeleteCourse(a);
            continue;


        default:
            return;
    }
}