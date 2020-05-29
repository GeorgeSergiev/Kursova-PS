using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInfoSystem
{
    public class StudentData
    {
        static private List<Student> _testStudent;
        static public List<Student> TestStudent
        {
            get { PopulateTestData(); return _testStudent; }
            private set { }
        }

        static private void PopulateTestData()
        {
            _testStudent = new List<Student>(3);
            for (int i = 0; i < 3; i++)
            {
                _testStudent.Add(new Student());
            }
            _testStudent[0].Name = "Georgi";
            _testStudent[0].MiddleName = "Georgiev";
            _testStudent[0].LastName = "Sergiev";
            _testStudent[0].Faculty = "FKST";
            _testStudent[0].Course = "KSI";
            _testStudent[0].Degree = "Bachelor";
            _testStudent[0].Status = "Regular";
            _testStudent[0].FacNum = "121217109";
            _testStudent[0].Year = 3;
            _testStudent[0].Flow = 9;
            _testStudent[0].Group = 36;

            _testStudent[1].Name = "Pencho";
            _testStudent[1].MiddleName = "Hristianov";
            _testStudent[1].LastName = "Peshev";
            _testStudent[1].Faculty = "FKST";
            _testStudent[1].Course = "KSI";
            _testStudent[1].Degree = "Bachelor";
            _testStudent[1].Status = "Regular";
            _testStudent[1].FacNum = "121217888";
            _testStudent[1].Year = 2;
            _testStudent[1].Flow = 4;
            _testStudent[1].Group = 26;

            _testStudent[2].Name = "Atanas";
            _testStudent[2].MiddleName = "Penchev";
            _testStudent[2].LastName = "Penchev";
            _testStudent[2].Faculty = "FKST";
            _testStudent[2].Course = "KSI";
            _testStudent[2].Degree = "Bachelor";
            _testStudent[2].Status = "Regular";
            _testStudent[2].FacNum = "121217898";
            _testStudent[2].Year = 1;
            _testStudent[2].Flow = 7;
            _testStudent[2].Group = 16;
        }
    }
}
