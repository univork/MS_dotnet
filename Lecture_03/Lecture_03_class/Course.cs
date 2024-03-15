
namespace Lecture_03_class
{
    public class Course
    {
        private List<string> subjectList = [];

        public void AddSubject(string subject)
        {
            subjectList.Add(subject);
        }

        public void PrintSubjects()
        {
            foreach (string subject in subjectList)
            {
                Console.WriteLine(subject);
            }
        }
    }
}
