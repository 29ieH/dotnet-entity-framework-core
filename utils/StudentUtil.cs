using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using entity_framework.Modelcls;

namespace entity_framework
{
    public class StudentUtil
    {
        private static StudentUtil _Instance;
        private QuanLyLopContext db;
        StudentUtil()
        {
            db = new QuanLyLopContext();
        }
        public static StudentUtil Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new StudentUtil();
                }
                return _Instance;
            }
            private set { }
        }
        public void selectAllRecordStudent()
        {
            var selectAll = db.Svs.Select(p => p);
            foreach (var i in selectAll)
            {
                Console.WriteLine(i.Mssv + " " + i.NameSv);
            }
        }
        // public void selectRecordByConditions(Dictionary<string, dynamic> conditions)
        // {
        //     var query = db.Svs.AsQueryable();

        //     foreach (var condition in conditions)
        //     {
        //         query = query.Where($"p.{condition.Key} == @0", condition.Value);
        //     }

        //     var result = query.FirstOrDefault();

        //     if (result != null)
        //     {
        //         Console.WriteLine($"Mssv: {result.Mssv}, NameSv: {result.NameSv}");
        //     }
        //     else
        //     {
        //         Console.WriteLine("Không tìm thấy kết quả phù hợp.");
        //     }
        // }
        public void selectAllRecordOrderByDESC()
        {
            var selectAndOrderDESC = db.Svs.OrderByDescending(p => p.NameSv).Select(p => p);
            foreach (var i in selectAndOrderDESC)
            {
                Console.WriteLine(i.Mssv + " " + i.NameSv);
            }
        }
        public void selectAllRecordOrderByASC()
        {
            var selectAndOrderASC = db.Svs.OrderBy(p => p.NameSv).Select(p => p);
            // if add conditions -> " then ", for example: db.Svs.OrderBy(p => p.NameSv).Then(p => p.IdLop)Select(p => p);
            foreach (var i in selectAndOrderASC)
            {
                Console.WriteLine(i.Mssv + " " + i.NameSv);
            }
        }
        public void addStudent(Sv s)
        {
            try
            {
                db.Svs.Add(s);
                if (db.SaveChanges() > 1) Console.WriteLine("Add successfully");
                else Console.WriteLine("Add Failed");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        public void updateStudent(String Mssv, Sv s)
        {
            try
            {
                var studentCurrent = db.Svs.Where(p => p.Mssv == Mssv).FirstOrDefault();
                if (s.NameSv != null) studentCurrent.NameSv = s.NameSv;
                if (s.Dtb != null) studentCurrent.Dtb = s.Dtb;
                if (s.Gender != null) studentCurrent.Gender = s.Gender;
                if (s.Ns != null) studentCurrent.Ns = s.Ns;
                if (s.IdLop != null) studentCurrent.IdLop = s.IdLop;
                db.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }
        public void deleteStudent(String Mssv)
        {
            try
            {
                var studentCurrent = db.Svs.Where(p => p.Mssv == Mssv).FirstOrDefault();
                db.Svs.Remove(studentCurrent);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}