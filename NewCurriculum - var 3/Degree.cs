namespace NewCurriculum
{
    internal class Degree
    {
        public int Code { get; set; }
        public string Title { get; set; }
        public int CreditsRequired { get; set; }
        public int SpecialCoursesRequired { get; set; }
        public string OtherCondition { get; set; }

        public static List<Degree> ListDegree = new List<Degree> {
            new Degree(
                1,
                "Интеллектуальные системы",
                70,
                2),
            new Degree(
                2,
                "Прикладная математика",
                60,
                1),
            new Degree(
                3,
                "Психология личной эффективности",
                30,
                0)};

        public Degree(int code, string title, int creditsRequired, int specialCoursesRequired, string otherCondition = null)

        {
            Code = code;
            Title = title;
            CreditsRequired = creditsRequired;
            SpecialCoursesRequired = specialCoursesRequired;

            OtherCondition = otherCondition;
        }

        public static Degree GetDegree(int code)
        {
            foreach (Degree degree in ListDegree)
                if (degree.Code == code) return degree;
            return null;

        }

        public override string ToString()
        {
            return "[---------------\n" +
                $"\tКод: {Code}\n" +
                $"\tНазвагие {Title}\n" +
                $"\tНужное количество кредитов: {CreditsRequired}\n" +
                $"\tМнимальное кол-во спецкурсов {SpecialCoursesRequired}\n" +
                $"\tДополнительное условие: {OtherCondition}\n" +
                    "---------------]";
        }
    }
}
