using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace TMXLoader.Classes
{
    public class TMXError
    {
        private const string TMXSUBJECT = "TMX ERRORS: Errors have been found while loading files. See email.";
        static Dictionary<string, string> errors = new Dictionary<string, string>();

        public static void add(string filename, string message)
        {
            errors.Add(filename, message);
        }

        public static void notify()
        {
            if (errors.Count <= 0)
                return;

            Email e = new Email(ConfigHelper.getFromEmail(),
                ConfigHelper.getToEmail(), ConfigHelper.getSmtpHost());
            e.addSubject(TMXSUBJECT);

            StringBuilder b = new StringBuilder();
            foreach (KeyValuePair<string, string> err in errors)
                b.Append(err.Key + " - " + err.Value + "</br>");
            e.addBody(b.ToString());

            try
            {
                e.send();
            }
            catch (SmtpException ex)
            {
                Logger.Error("Unable to send email: " + ex.Message);
            }

            updateErrors();
        }

        public static void updateErrors()
        {
            if (errors.Count <= 0)
                return;

            foreach (KeyValuePair<string, string> err in errors)
                DataHelper.updateErrorMessage(err.Key, err.Value);

            Logger.Info("Error messages updated within FileHistory table");
        }

        public static int errorCount()
        {
            return errors.Count;
        }
    }
}
