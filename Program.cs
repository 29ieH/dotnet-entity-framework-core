using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using entity_framework.Modelcls;

namespace entity_framework
{
    public class Program
    {
        public static void Main()
        {
            StudentUtil studentCrud = StudentUtil.Instance;
            // Sv s = new Sv
            // {
            //     Mssv = "SV36",
            //     NameSv = "Nguyen Van Huy",
            //     Dtb = 8.5,
            //     Gender = true,
            //     IdLop = 4,
            //     Ns = Convert.ToDateTime("2003/5/6")
            // };
            // studentCrud.addStudent(s);
            Sv sUpdate = new Sv
            {
                NameSv = "Nguyen Van HungTham",
                Gender = true,
                IdLop = 1,
                Ns = Convert.ToDateTime("2003/5/6")
            };
            studentCrud.updateStudent("SV35", sUpdate);
            studentCrud.deleteStudent("SV8");
            Console.WriteLine("--------------- Select All --------------");
            studentCrud.selectAllRecordStudent();
        }
    }
}
