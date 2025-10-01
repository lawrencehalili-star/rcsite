using System.Text;

namespace richmindale_app.Server.Helpers
{
    public static class CodeGenerator
    {
        public static string Passkey(int length)
        {
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();  
            while (0 < length--)
            {
                res.Append(valid[rnd.Next(valid.Length)]);
            }
            return res.ToString();
        }

        public static string AdmissionNumber(int count)
        {
            return  DateTime.Now.Year.ToString().PadLeft(4,'0') + 
                    DateTime.Now.Month.ToString().PadLeft(2,'0') +
                    DateTime.Now.Day.ToString().PadLeft(2,'0') +
                    DateTime.Now.Hour.ToString().PadLeft(2,'0') + 
                    DateTime.Now.Minute.ToString().PadLeft(2,'0') +
                    count.ToString().PadLeft(8, '0');
        }

        public static string RequestNumber(int count)
        {
            return "DRN" +
            DateTime.Now.Year.ToString().PadLeft(4,'0') + 
            DateTime.Now.Month.ToString().PadLeft(2,'0') +
            DateTime.Now.Day.ToString().PadLeft(2,'0') +
            DateTime.Now.Hour.ToString().PadLeft(2,'0') + 
            DateTime.Now.Minute.ToString().PadLeft(2,'0') +
            (count + 1).ToString().PadLeft(6, '0');
        }

        public static string GrievanceCode(int count)
        {
            return "GVN" +
            DateTime.Now.Year.ToString().PadLeft(4,'0') + 
            DateTime.Now.Month.ToString().PadLeft(2,'0') +
            DateTime.Now.Day.ToString().PadLeft(2,'0') +
            DateTime.Now.Hour.ToString().PadLeft(2,'0') + 
            DateTime.Now.Minute.ToString().PadLeft(2,'0') +
            (count + 1).ToString().PadLeft(6, '0');
        }

        public static string ExpenseCode(int loc, int act, int count)
        {
            return "EXP" +
            DateTime.Now.Year.ToString().PadLeft(4,'0') + 
            DateTime.Now.Month.ToString().PadLeft(2,'0') +
            (loc).ToString().PadLeft(2,'0') +
            (act).ToString().PadLeft(2,'0') +
            (count + 1).ToString().PadLeft(6, '0');
        }
    }
}
