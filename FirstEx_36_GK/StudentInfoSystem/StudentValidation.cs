using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserLogin;

namespace StudentInfoSystem
{
    public class StudentValidation
    {
        static public Student GetStudentDataByUser(User user)
        {
            //int[] array = new int[2];
            //array[0] = 5;
            //array[1] = 3;
            //for (int i = 0; i < 2; i++)
            //{
            //    Console.WriteLine(array[i]);
            //}
            //foreach (int num in array)
            //{
            //    Console.WriteLine(num);
            //}
            //foreach (Student st in StudentData.TestStudent)
            //{
            //    if (user.FacNum == st.FacNum)
            //    {
            //        return st;
            //    }
            //}
            //return null;
            StudentInfoContext context = new StudentInfoContext();

            Student result =
            (from st in context.Students
             where st.FacNum == user.FacNum
             select st).First();
            return result;
        }

    }
}
