using System.Collections.Generic;

namespace TP1_Base_Prof
{
    public class Course
    {

        public string Id;
        public string Name;
        public Semester Semester;
        public int Group;
        public List<CoursePeriod> CoursePeriods;
        public int TeacherId;
        public List<int> StudentIds;
        public List<Evaluation> Evaluations;

    }
}
