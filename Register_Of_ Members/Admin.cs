using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Register_Of__Members
{
    public class Admin
    {
        private string userName;
        private string password;
        private string firstName;
        private string lastName;
        private string oib;
        private string clearance;

        public Admin()
        {

        }

        public Admin(string userName, string password)
        {
            if (!validAdmin(userName, password))
            {
                throw new ArgumentException("Neispravni login podaci!");
            }
        }

        public string UserName
        {
            get { return userName; }

            set
            {
                if (value.Length < 4)
                    throw new ArgumentException("Korisničko ime ne može imati manje od 4 znaka.");
                userName = value;
            }
        }

        public string Password
        {
            get { return password; }
            set
            {
                if (value.Length < 5)
                    throw new ArgumentException("Lozinka ne može imati manje od 5 znakova.");
                password = value;
            }
        }

        public string FirstName
        {
            get { return firstName; }
            set
            {
                if (value.Length < 3)
                    throw new ArgumentException("Ime korisnika ne može imati manje od 3 znaka.");

                firstName = SentenceCase(value);
            }
        }

        public string LastName
        {
            get { return lastName; }
            set
            {
                if (value.Length < 3)
                    throw new ArgumentException("Ime korisnika ne može imati manje od 3 znaka.");

               lastName = SentenceCase(value);
            }
        }

        public string Oib
        {
            get { return oib; }
            set
            {
                if (value.Length != 11)
                {
                    throw new Exception("Oib mora sadržavati točni 11 znakova.");
                }

                try
                {
                    double.Parse(value);
                }
                catch (Exception)
                {
                    throw new Exception("OIB smije sadržavati samo brojeve.");
                    throw;
                }

                oib = value;
            }
        }

        public string Clearance
        {
            get { return clearance; }
            set
            {
                if (value.Length != 4)
                    throw new ArgumentException("Oznaka prava pristupa mora imati točno 4 znaka");

                if (value != "1111" && value != "0000")
                    throw new ArgumentException("Nedozvoljeni unos vrste prava pristupa aplikaciji (admin/user).");

                clearance = value;
            }
        }

        
        static public string SentenceCase(string text)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(text);

        }

        private bool validAdmin(string tmpUsername, string tmpPassword)
        {
            string path = "txt/login.txt";

            StreamReader sr;
            try
            {
                sr = new StreamReader(path, Encoding.Default);
            }
            catch (Exception)
            {
                throw new ArgumentException("Ne postoji baza podataka s korisnicima aplikacije. Javite se u centar za podršku.", "Ozbiljna pogreška.");
            }

            string line = "";
            while ((line = sr.ReadLine()) != null)
            {
                string userName, password, firstName, lastName, oib, clearance;
                int h1, h2;

                h1 = line.IndexOf('#');
                h2 = line.IndexOf('#', h1 + 1);
                userName = line.Substring(h1 + 1, h2 - h1 - 1);

                h1 = h2;
                h2 = line.IndexOf('#', h1 + 1);
                password = line.Substring(h1 + 1, h2 - h1 - 1);

                h1 = h2;
                h2 = line.IndexOf('#', h1 + 1);
                firstName = line.Substring(h1 + 1, h2 - h1 - 1);

                h1 = h2;
                h2 = line.IndexOf('#', h1 + 1);
                lastName = line.Substring(h1 + 1, h2 - h1 - 1);

                h1 = h2;
                h2 = line.IndexOf('#', h1 + 1);
                oib = line.Substring(h1 + 1, h2 - h1 - 1);

                h1 = h2;
                clearance = line.Substring(h1 + 1);

                if (userName.Equals(tmpUsername) && password.Equals(tmpPassword))
                {
                    sr.Close();
                    this.UserName = userName;
                    this.Password = password;
                    this.FirstName = firstName;
                    this.LastName = lastName;
                    this.Oib = oib;
                    this.Clearance = clearance;
                    return true;
              }
            }
            sr.Close();

            return false;
        }

        static public bool IsAdmin(Admin a)
        {
            if (a.Clearance == "1111")
            {
                return true;
            }
            return false;
        }

        public static Collection<Admin> GetAllUsers()
        {
            Collection<Admin> allAdmins = new Collection<Admin>();

            string line = "";
            string path = "txt/login.txt";
            StreamReader sr;
            try
            {
                sr = new StreamReader(path, Encoding.Default);
            }
            catch (Exception)
            {
                throw new Exception("Problem kod otvaranja txt datoteke.");
            }

            while ((line = sr.ReadLine()) != null)
            {
                string userName, password, firstName, lastName, oib, clearency;
                int h1, h2;

                h1 = line.IndexOf('#');
                h2 = line.IndexOf('#', h1 + 1);
                userName = line.Substring(h1 + 1, h2 - h1 - 1);

                h1 = h2;
                h2 = line.IndexOf('#', h1 + 1);
                password = line.Substring(h1 + 1, h2 - h1 - 1);

                h1 = h2;
                h2 = line.IndexOf('#', h1 + 1);
                firstName = line.Substring(h1 + 1, h2 - h1 - 1);

                h1 = h2;
                h2 = line.IndexOf('#', h1 + 1);
                lastName = line.Substring(h1 + 1, h2 - h1 - 1);

                h1 = h2;
                h2 = line.IndexOf('#', h1 + 1);
                oib = line.Substring(h1 + 1, h2 - h1 - 1);

                h1 = h2;
                clearency = line.Substring(h1 + 1);

                Admin a = new Admin();

                a.UserName = userName;
                a.Password = password;
                a.FirstName = firstName;
                a.LastName = lastName;
                a.Oib = oib;
                a.Clearance = clearency;

                allAdmins.Add(a);
            }
            sr.Close();
            return allAdmins;
        }

        public static Admin GetAdminsByOib(string oib)
        {
            foreach (Admin a in GetAllUsers())
            {
                if (a.Oib == oib)
                {
                    return a;
                }
            }

            Admin aa = null;

            return aa;
        }

        public static void AddAdminToDatabase(bool correctPassword, string userName, string password, string firstName, string lastName, string oib, string clerance)
        {
            if (correctPassword)
            {
                Admin a;
                try
                {
                    a = new Admin
                    {
                        UserName = userName,
                        Password = password,
                        FirstName = firstName,
                        LastName = lastName,
                        Oib = oib,
                        Clearance = clerance
                    };
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }

                StreamWriter sw;
                string path = "txt/login.txt";
                try
                {
                    sw = new StreamWriter(path, true, Encoding.Default);
                }
                catch (Exception)
                {
                    MessageBox.Show("Greška kod spremanja admina!");
                    return;
                }

                StringBuilder sb = new StringBuilder();
                sb.Append(Environment.NewLine);
                sb.Append("#");
                sb.Append(a.UserName);
                sb.Append("#");
                sb.Append(a.Password);
                sb.Append("#");
                sb.Append(a.FirstName);
                sb.Append("#");
                sb.Append(a.LastName);
                sb.Append("#");
                sb.Append(a.Oib);
                sb.Append("#");
                sb.Append(a.Clearance);

                sw.Write(sb.ToString());
                sw.Close();

                MessageBox.Show("Admin uspješno dodan u bazu.");
            }
            else
            {
                MessageBox.Show("Neispravna lozinka!");
            }

        }

        public static void UpdateAdminInDatabase(bool correctPassword, string userName, string password, string firstName, string lastName, string oib, string clerance)
        {
            Collection<Admin> allAdmins = Admin.GetAllUsers();

            if (correctPassword)
            {
                foreach (Admin aa in allAdmins)
                {
                    if (aa.Oib == oib)
                    {
                        string tmpUserName = userName;
                        string tmpPassword = password;
                        string tmpFirstName = firstName;
                        string tmpLastName = lastName;
                        string tmpOib = oib;
                        string tmpClerance = clerance;

                        Admin a;
                        try
                        {
                            a = new Admin
                            {
                                UserName = tmpUserName,
                                Password = tmpPassword,
                                FirstName = tmpFirstName,
                                LastName = tmpLastName,
                                Oib = tmpOib,
                                Clearance = tmpClerance
                            };
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                            return;
                        }

                        aa.UserName = a.UserName;
                        aa.Password = a.Password;
                        aa.FirstName = a.FirstName;
                        aa.LastName = a.LastName;
                        aa.Oib = a.Oib;
                        aa.Clearance = a.Clearance;

                        break;
                    }
                }

                StringBuilder sb = new StringBuilder();
                int counter = 1;
                foreach (Admin a in allAdmins)
                {
                    sb.Append("#");
                    sb.Append(a.UserName);
                    sb.Append("#");
                    sb.Append(a.Password);
                    sb.Append("#");
                    sb.Append(a.FirstName);
                    sb.Append("#");
                    sb.Append(a.LastName);
                    sb.Append("#");
                    sb.Append(a.Oib);
                    sb.Append("#");
                    sb.Append(a.Clearance);

                    if (counter < allAdmins.Count)
                        sb.Append(Environment.NewLine);

                    counter++;
                }
                string path = "txt/login.txt";
                StreamWriter sw = new StreamWriter(path, false, Encoding.Default);
                sw.Write(sb.ToString());
                sw.Close();

                MessageBox.Show("Admin uspješno ažuriran");
            }
            else
            {
                MessageBox.Show("Neispravna lozinka!");
            }
        }

        public static void DeleteAdminInDatabase(string oib)
        {
            Collection<Admin> allAdmins = Admin.GetAllUsers();

            DialogResult drDelete = MessageBox.Show("Želite li izbrisati admina?", "Brisanje!",
                MessageBoxButtons.YesNo);

            if (drDelete == DialogResult.Yes)
            {
                foreach (Admin a in allAdmins)
                {
                    if (a.Oib == oib)
                    {
                        allAdmins.Remove(a);
                        break;
                    }
                }

                StreamWriter sw;
                string path = "txt/login.txt";
                try
                {
                    sw = new StreamWriter(path, false, Encoding.Default);
                }
                catch (Exception)
                {
                    throw new Exception("Pogreška prilikom brisanja podataka.");
                }

                int counter = 1;
                StringBuilder sb = new StringBuilder();

                foreach (Admin a in allAdmins)
                {
                    sb.Append("#");
                    sb.Append(a.UserName);
                    sb.Append("#");
                    sb.Append(a.Password);
                    sb.Append("#");
                    sb.Append(a.FirstName);
                    sb.Append("#");
                    sb.Append(a.LastName);
                    sb.Append("#");
                    sb.Append(a.Oib);
                    sb.Append("#");
                    sb.Append(a.Clearance);

                    if (counter < allAdmins.Count)
                        sb.Append(Environment.NewLine);

                    counter++;
                }
                sw.Write(sb.ToString());
                sw.Close();

                MessageBox.Show("Admin uspješno obrisan");
            }
        }
    }
}
