using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Register_Of__Members
{
    class Members
    {
        private string id;
        string firstName;
        string lastName;
        string gender;
        DateTime dateOfBirth = new DateTime();
        string oib;
        string adress;
        string email;
        string contact;
        bool activeCompetitor;
        string levelOfCompetition;
        string trainingGroup;
        DateTime dateOfJoining = new DateTime();
        private string picture;


        public string Id
        {
            get { return id; }
            set
            {
                if (value.Length < 1)
                {
                    throw new Exception("ID ne može biti manji od 1!");
                }
                try
                {
                    int.Parse(value);
                }
                catch (Exception)
                {
                    throw new Exception("Id mora biti broj!");
                    throw;
                }

                id = value;
            }
        }

        public string FirstName
        {
            get { return firstName; }
            set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("Neispravno ime.");
                }

                firstName = Admin.SentenceCase(value);
            }
        }

        public string LastName
        {
            get { return lastName; }
            set
            {
                if (value.Length < 3)
                    throw new ArgumentException("Ime korisnika ne može imati manje od 3 znaka.");

                lastName = Admin.SentenceCase(value);
            }
        }

        public string Gender
        {
            get { return gender; }
            set
            {
                if (value != "Ž" && value != "M")
                {
                    throw new Exception("Neispravan unos spola! Spol može biti samo Ž ili M!");
                }
                gender = value.ToUpper();
            }
        }

        public DateTime DateOfBirth
        {
            get { return dateOfBirth; }
            set
            {
                if (DateTime.Today <= value)
                {
                    throw new Exception("Nevaljani datum rođenja.");
                }
                dateOfBirth = value;
            }
        }

        public string Oib
        {
            get { return oib; }
            set {
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

        public string Adress
        {
            get { return adress; }
            set
            {
                if (value.Length < 5)
                {
                    throw new ArgumentException("Neispravna adresa. Ne može biti manje od 5 znakova.");
                }

                adress = Admin.SentenceCase(value);
            }
        }

        public string Email
        {
            get { return email; }
            set {
                value = value.Trim();
                if (value.Length < 5)
                {
                    throw new ArgumentException("Neispravna dužina email adrese.");
                }

                if ((value.IndexOf('@') != value.LastIndexOf('@')) && value.IndexOf('@') != -1)
                {
                    throw new ArgumentException("Mora biti točno jedan @ znak.");
                }

                if (value.IndexOf('@') == 0)
                {
                    throw new ArgumentException("Znak @ ne može biti prvi znak.");
                }

                int counter = 0;
                int dotCounter = 0;
                foreach (char character in value)
                {
                    if (character == '.')
                    {
                        dotCounter++;
                        if (counter == 0)
                        {
                            throw new Exception("Točka ne smije biti na početku adrese.");
                        }

                        if (counter == value.Length - 1)
                        {
                            throw new ArgumentException("Točka ne smije biti posljednji simbol u adresi.");
                        }

                        if (value.Length - 1 != counter)
                        {
                            if (value[counter + 1] == '@' || value[counter + 1] == '.')
                            {
                                throw new ArgumentException("Točka ne smije biti odmah uz @ znak ili uz drugu točku.");
                            }

                            if (value[counter - 1] == '@')
                            {
                                throw new ArgumentException("TOčka ne smije biti odmah uz @ znak");
                            }
                        }
                    }
                    counter++;
                }

                if (value.IndexOf('@') + 1 == value.Length)
                {
                    throw new ArgumentException("@ znak ne može biti na kraju.");
                }

                if (value.IndexOf(' ') != -1)
                {
                    throw new ArgumentException("Razmaci u email adresi nisu dozvoljeni.");
                }

                if (dotCounter < 1 || dotCounter > 3)
                {
                    throw new Exception("Previše točaka u Email adresi.");
                }


                email = value;
            }
        }

        public string Contact
        {
            get { return contact; }
            set
            {
                if (value.Length < 8)
                {
                    throw new Exception("Neispravan unos broja, broj prekratak!");
                }
                try
                {
                    double.Parse(value);
                }
                catch (Exception)
                {
                    throw new Exception("Neispravan unos broja!");
                    throw;
                }
                contact = value;
            }
        }

        public bool ActiveCompetitor
        {
            get { return activeCompetitor; }
            set{ activeCompetitor = value; }
        }

        public string LevelOfCompetition
        {
            get { return levelOfCompetition; }
            set
            {
                if (Gender == "Ž")
                {
                    if (!Enum.GetNames(typeof(levelOfCompetitionSelectF)).Contains(value) && value != "NEMA")
                    {
                        throw new Exception("Kategorije natjecanja u ŽSG mogu biti: A, B ili C!");
                    }
                }
                else if (Gender == "M")
                {
                    if (!Enum.GetNames(typeof(levelOfCompetitionSelectM)).Contains(value) && value != "NEMA")
                    {
                        throw new Exception("Kategorije natjecanja u MSG mogu biti: A, B, C ili D!");
                    }
                }

                levelOfCompetition = value.ToUpper();
            }
        }

        public string TrainingGroup
        {
            get { return trainingGroup; }
            set
            {
               if (!Enum.GetNames(typeof(trainingGroupSelect)).Contains(value))
                {
                    throw new Exception("Krivi unos grupe!");
                }
                trainingGroup = value;
            }
        }

        public DateTime DateOfJoining
        {
            get { return dateOfJoining; }
            set
            {
                if (DateTime.Today < value)
                {
                    throw new Exception("Nevaljani datum učlanjenja.");
                }
                dateOfJoining = value;
            }
        }

        public string Picture
        {
            get { return picture; }
            set
            {
                try
                {
                    value.ToString();
                }
                catch (Exception)
                {
                    throw new Exception("Neispravni podaci o slici člana!");
                    throw;
                }
                picture = value;
            }
        }

        
        public static Collection<Members> GetAllMembers()
        {
            Collection<Members> allMembers = new Collection<Members>();

            StreamReader sr;

            string path = "txt/members.txt";

            try
            {
                sr = new StreamReader(path, Encoding.Default);
            }
            catch (Exception)
            {
                throw new Exception("Nije moguće otvoriti datoteku.");
                throw;
            }

            string row = "";

            while ((row = sr.ReadLine()) != null)
            {
                string id;
                string firstName;
                string lastName;
                string gender;
                DateTime dateOfBirth = new DateTime();
                string oib;
                string adress;
                string email;
                string contact;
                bool activeCompetitor;
                string levelOfCompetition;
                string trainingGroup;
                DateTime dateOfJoining = new DateTime();
                string picture;

                int h1, h2;

                h1 = row.IndexOf('#');
                h2 = row.IndexOf('#', h1 + 1);
                id = row.Substring(h1 + 1, h2 - h1 - 1);

                h1 = h2;
                h2 = row.IndexOf('#', h1 + 1);
                firstName = row.Substring(h1 + 1, h2 - h1 - 1);

                h1 = h2;
                h2 = row.IndexOf('#', h1 + 1);
                lastName = row.Substring(h1 + 1, h2 - h1 - 1);

                h1 = h2;
                h2 = row.IndexOf('#', h1 + 1);
                gender = row.Substring(h1 + 1, h2 - h1 - 1);

                h1 = h2;
                h2 = row.IndexOf('#', h1 + 1);
                dateOfBirth = DateTime.Parse(row.Substring(h1 + 1, h2 - h1 - 1));

                h1 = h2;
                h2 = row.IndexOf('#', h1 + 1);
                oib = row.Substring(h1 + 1, h2 - h1 - 1);

                h1 = h2;
                h2 = row.IndexOf('#', h1 + 1);
                adress = row.Substring(h1 + 1, h2 - h1 - 1);

                h1 = h2;
                h2 = row.IndexOf('#', h1 + 1);
                email = row.Substring(h1 + 1, h2 - h1 - 1);

                h1 = h2;
                h2 = row.IndexOf('#', h1 + 1);
                contact = row.Substring(h1 + 1, h2 - h1 - 1);

                h1 = h2;
                h2 = row.IndexOf('#', h1 + 1);
                activeCompetitor = bool.Parse(row.Substring(h1 + 1, h2 - h1 - 1));

                h1 = h2;
                h2 = row.IndexOf('#', h1 + 1);
                levelOfCompetition = row.Substring(h1 + 1, h2 - h1 - 1);

                h1 = h2;
                h2 = row.IndexOf('#', h1 + 1);
                trainingGroup = row.Substring(h1 + 1, h2 - h1 - 1);

                h1 = h2;
                h2 = row.IndexOf('#', h1 + 1);
                dateOfJoining = DateTime.Parse(row.Substring(h1 + 1, h2 - h1 - 1)); 

                h1 = h2;
                picture = row.Substring(h1 + 1);

                Members m = new Members
                {
                    Id = id,
                    FirstName = firstName,
                    LastName = lastName,
                    Gender = gender,
                    dateOfBirth = dateOfBirth,
                    Oib = oib,
                    Adress = adress,
                    Email = email,
                    Contact = contact,
                    ActiveCompetitor = activeCompetitor,
                    LevelOfCompetition = levelOfCompetition,
                    TrainingGroup = trainingGroup,
                    DateOfJoining = dateOfJoining,
                    Picture = picture
                };

                allMembers.Add(m);
            }
            sr.Close();
            return allMembers;
        }

        public static string pictureLocation(Members m)
        {
            string picture = m.Picture;
            return "picture/" + picture + ".jpg";
        }

        public static string AgeCategoryOfCompetition(Members m)
        {
            DateTime presentYear = DateTime.Today;
            int yearsOld = presentYear.Year - m.DateOfBirth.Year;
            if (m.Gender == "M")
            {
                if (m.LevelOfCompetition == "A")
                {
                    if (yearsOld <= 9)
                    {
                        return "mlađi kadet";
                    }
                    else if (yearsOld == 10 || yearsOld == 11 || yearsOld == 12)
                    {
                        return "kadet";
                    }
                    else if (yearsOld == 13 || yearsOld == 14 || yearsOld == 15)
                    {
                        return "mlađi junior";
                    }
                    else if (yearsOld == 16 || yearsOld == 17 || yearsOld == 18)
                    {
                        return "junior";
                    }
                    else { return "senior";}
                }
                else if (m.LevelOfCompetition == "B")
                {
                    if (yearsOld <= 10)
                    {
                        return "mlađi kadet";
                    }
                    else if (yearsOld == 11 || yearsOld == 12 || yearsOld == 13)
                    {
                        return "kadet";
                    }
                    else if (yearsOld == 14 || yearsOld == 15 || yearsOld == 16)
                    {
                        return "junior";
                    }
                    else { return "senior";}
                }
                else if (m.LevelOfCompetition == "C")
                {
                    if (yearsOld <= 8)
                    {
                        return "mlađi kadet";
                    }
                    else if (yearsOld == 9 || yearsOld == 10 || yearsOld == 11 || yearsOld == 12)
                    {
                        return "kadet";
                    }
                    else if (yearsOld == 13 || yearsOld == 14 || yearsOld == 15 || yearsOld == 16)
                    {
                        return "junior";
                    }
                    else { return "senior";}
                }
                else if (m.levelOfCompetition == "D")
                {
                    if (yearsOld <= 11)
                    {
                        return "kadet";
                    }
                    else if (yearsOld == 12 || yearsOld == 13 || yearsOld == 14 || yearsOld == 15 || yearsOld == 16)
                    {
                        return "junior";
                    }
                    else { return "senior"; }
                }
            }
            else if (m.Gender == "Ž")
            {
                if (m.LevelOfCompetition == "A")
                {
                    if (yearsOld <= 9)
                    {
                        return "mlađa kadetkinja";
                    }
                    else if (yearsOld == 10 || yearsOld == 11)
                    {
                        return "kadetkinja";
                    }
                    else if (yearsOld == 12 || yearsOld == 13)
                    {
                        return "mlađa juniorka";
                    }
                    else if (yearsOld == 14 || yearsOld == 15)
                    {
                        return "juniorka";
                    }
                    else { return "seniorka"; }
                }
                else if (m.LevelOfCompetition == "B")
                {
                    if (yearsOld <= 9)
                    {
                        return "mlađa kadetkinja";
                    }
                    else if (yearsOld == 10)
                    {
                        return "kadetkinja";
                    }
                    else if (yearsOld == 11 || yearsOld == 12)
                    {
                        return "mlađa juniorka";
                    }
                    else if (yearsOld == 13 || yearsOld == 14 || yearsOld == 15)
                    {
                        return "juniorka";
                    }
                    else { return "seniorka"; }
                }
                else if (m.LevelOfCompetition == "C")
                {
                    if (yearsOld <= 8)
                    {
                        return "mlađa kadetkinja";
                    }
                    else if (yearsOld == 9)
                    {
                        return "kadetkinja";
                    }
                    else if (yearsOld == 10 || yearsOld == 11)
                    {
                        return "mlađa juniorka";
                    }
                    else if (yearsOld == 12 || yearsOld == 13 || yearsOld == 14)
                    {
                        return "juniorka";
                    }
                    else { return "seniorka"; }
                }
            }

            return "nema kategorije, greška!";
        }

        public static string GetLastIdPlusOne()
        {
            Collection<Members> allMembers;
            try
            {
                allMembers = GetAllMembers();
            }
            catch (Exception)
            {
               allMembers = null;
            }
            if (allMembers == null)
            {
                return "-1";
            }

            string id = allMembers[allMembers.Count - 1].Id;
            int id1 = int.Parse(id) + 1;

            return id1.ToString();
        }

        public static Members GetMemberById(string id)
        {
            foreach (Members m in GetAllMembers())
            {
                if (m.Id == id)
                {
                    return m;
                }
            }

            Members mm = null;

            return mm;
        }

        public static void AddMembersToDatabase(string firstName, string lastName, string gender, DateTime dateOfBirth, string oib, string adress, string email, string contact, bool activeCompetitor, string levelOfCompetition, string trainingGroup, DateTime dateOfJoining, string picture )
        {
            string id = Members.GetLastIdPlusOne();
            Members m;
            try
            {
                m = new Members 
                {
                    Id = id,
                    FirstName = firstName,
                    LastName = lastName,
                    Gender = gender,
                    dateOfBirth = dateOfBirth,
                    Oib = oib,
                    Adress = adress,
                    Email = email,
                    Contact = contact,
                    ActiveCompetitor = activeCompetitor,
                    LevelOfCompetition = levelOfCompetition,
                    TrainingGroup = trainingGroup,
                    DateOfJoining = dateOfJoining,
                    Picture = picture
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            StreamWriter sw;
            string path = "txt/members.txt";
            try
            {
                sw = new StreamWriter(path, true, Encoding.Default);
            }
            catch (Exception)
            {
                MessageBox.Show("Greška kod spremanja člana!");
                return;
            }

            StringBuilder sb = new StringBuilder();
            sb.Append(Environment.NewLine);
            sb.Append("#");
            sb.Append(m.Id);
            sb.Append("#");
            sb.Append(m.FirstName);
            sb.Append("#");
            sb.Append(m.LastName);
            sb.Append("#");
            sb.Append(m.Gender);
            sb.Append("#");
            sb.Append(m.DateOfBirth.ToShortDateString());
            sb.Append("#");
            sb.Append(m.Oib);
            sb.Append("#");
            sb.Append(m.Adress);
            sb.Append("#");
            sb.Append(m.Email);
            sb.Append("#");
            sb.Append(m.Contact);
            sb.Append("#");
            sb.Append(m.ActiveCompetitor);
            sb.Append("#");
            sb.Append(m.LevelOfCompetition);
            sb.Append("#");
            sb.Append(m.TrainingGroup);
            sb.Append("#");
            sb.Append(m.DateOfJoining.ToShortDateString());
            sb.Append("#");
            sb.Append(m.Picture);

            sw.Write(sb.ToString());
            sw.Close();

            MessageBox.Show("Član uspješno dodan u bazu.");

    }

        public static void UpdateMembersInDatabase(string id, string firstName, string lastName, string gender, DateTime dateOfBirth, string oib, string adress, string email, string contact, bool activeCompetitor, string levelOfCompetition, string trainingGroup, DateTime dateOfJoining, string picture)
        {
            Collection<Members> allMemberses = Members.GetAllMembers();
     
            foreach (Members tmpM in allMemberses)
            {
                if (tmpM.Id == id)
                {
                    string tmpId = id; 
                    string tmpFirstName = firstName;
                    string tmpLastName = lastName;
                    string tmpGender = gender;
                    DateTime tmpDateOfBirth = dateOfBirth;
                    string tmpOib = oib;
                    string tmpAdress = adress;
                    string tmpEmail = email;
                    string tmpContact = contact;
                    string tmpLevelOfCompetition = levelOfCompetition;
                    bool tmpActiveCompetitor = activeCompetitor;
                    string tmpTrainingGroup = trainingGroup;
                    DateTime tmpDateOfJoining = dateOfJoining;
                    string tmpPicture = picture;

                    Members m;
                    try
                    {
                        m = new Members
                        {
                            Id = tmpId,
                            FirstName = tmpFirstName,
                            LastName = tmpLastName,
                            Gender = tmpGender,
                            dateOfBirth = tmpDateOfBirth,
                            Oib = tmpOib,
                            Adress = tmpAdress,
                            Email = tmpEmail,
                            Contact = tmpContact,
                            ActiveCompetitor = tmpActiveCompetitor,
                            LevelOfCompetition = tmpLevelOfCompetition,
                            TrainingGroup = tmpTrainingGroup,
                            DateOfJoining = tmpDateOfJoining,
                            Picture = tmpPicture
                        };
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        return;
                    }

                    tmpM.Id = m.Id;
                    tmpM.FirstName = m.FirstName;
                    tmpM.LastName = m.LastName;
                    tmpM.Gender = m.Gender;
                    tmpM.DateOfBirth = m.DateOfBirth;
                    tmpM.Oib = m.Oib;
                    tmpM.Adress = m.Adress;
                    tmpM.Email = m.Email;
                    tmpM.Contact = m.Contact;
                    tmpM.ActiveCompetitor = m.ActiveCompetitor;
                    tmpM.LevelOfCompetition = m.LevelOfCompetition;
                    tmpM.TrainingGroup = m.TrainingGroup;
                    tmpM.DateOfJoining = m.DateOfJoining;
                    tmpM.Picture = m.Picture;

                    break;
                }
            }

            StringBuilder sb = new StringBuilder();
            int counter = 1;
            foreach (Members m in allMemberses)
            {
                sb.Append("#");
                sb.Append(m.Id);
                sb.Append("#");
                sb.Append(m.FirstName);
                sb.Append("#");
                sb.Append(m.LastName);
                sb.Append("#");
                sb.Append(m.Gender);
                sb.Append("#");
                sb.Append(m.DateOfBirth.ToShortDateString());
                sb.Append("#");
                sb.Append(m.Oib);
                sb.Append("#");
                sb.Append(m.Adress);
                sb.Append("#");
                sb.Append(m.Email);
                sb.Append("#");
                sb.Append(m.Contact);
                sb.Append("#");
                sb.Append(m.ActiveCompetitor);
                sb.Append("#");
                sb.Append(m.LevelOfCompetition);
                sb.Append("#");
                sb.Append(m.TrainingGroup);
                sb.Append("#");
                sb.Append(m.DateOfJoining.ToShortDateString());
                sb.Append("#");
                sb.Append(m.Picture);

                if (counter < allMemberses.Count)
                    sb.Append(Environment.NewLine);

                counter++;
            }
            string path = "txt/members.txt";
            StreamWriter sw = new StreamWriter(path, false, Encoding.Default);
            sw.Write(sb.ToString());
            sw.Close();

            MessageBox.Show("Član uspješno ažuriran");
        }

        public static void DeleteMembersInDatabase(string id)
        {
            Collection<Members> allMemberses = Members.GetAllMembers();
            
            DialogResult drDelete = MessageBox.Show("Želite li izbrisati člana?", "Brisanje člana!",
                MessageBoxButtons.YesNo);
            if (drDelete == DialogResult.Yes)
            {
                foreach (Members m in allMemberses)
                {
                    if (m.Id == id)
                    {
                        allMemberses.Remove(m);
                        break;
                    }
                }

                StreamWriter sw;
                string path = "txt/members.txt";
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

                foreach (Members m in allMemberses)
                {
                    sb.Append("#");
                    sb.Append(m.Id);
                    sb.Append("#");
                    sb.Append(m.FirstName);
                    sb.Append("#");
                    sb.Append(m.LastName);
                    sb.Append("#");
                    sb.Append(m.Gender);
                    sb.Append("#");
                    sb.Append(m.DateOfBirth);
                    sb.Append("#");
                    sb.Append(m.Oib);
                    sb.Append("#");
                    sb.Append(m.Adress);
                    sb.Append("#");
                    sb.Append(m.Email);
                    sb.Append("#");
                    sb.Append(m.Contact);
                    sb.Append("#");
                    sb.Append(m.ActiveCompetitor);
                    sb.Append("#");
                    sb.Append(m.LevelOfCompetition);
                    sb.Append("#");
                    sb.Append(m.TrainingGroup);
                    sb.Append("#");
                    sb.Append(m.DateOfJoining);
                    sb.Append("#");
                    sb.Append(m.Picture);

                    if (counter < allMemberses.Count)
                        sb.Append(Environment.NewLine);

                    counter++;
                }
                sw.Write(sb.ToString());
                sw.Close();

                MessageBox.Show("Član uspješno obrisan");
            }
        }

        public static void PrintAllMembers()
        {
            Collection<Members> allMemberses = Members.GetAllMembers();

            foreach (Members tmpM in allMemberses)
            {
               Members m;
                try
                {
                    m = new Members();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    throw;
                }
               break;
                
            }

            StringBuilder s = new StringBuilder();
            s.Append("Rbr. ");
            s.Append("IME I PREZIME,  ");
            s.Append("DATUM ROĐENJA,  ");
            s.Append("NIVO NATJECANJA  ");
            s.Append(Environment.NewLine);
            s.Append(Environment.NewLine);

            StringBuilder sb = new StringBuilder();
            int counter = 1;
            int number = 1;

            foreach (Members m in allMemberses)
            {
                sb.Append(number + "." + " ");
                sb.Append(m.FirstName + " ");
                sb.Append(m.LastName + ", ");
                sb.Append(m.DateOfBirth.ToShortDateString() + ", ");
                sb.Append(m.LevelOfCompetition);
                
                if (counter < allMemberses.Count)
                    sb.Append(Environment.NewLine);

                counter++;
                number++;
            }
            
            string path = "print/printAllMembers.txt";
            StreamWriter sw = new StreamWriter(path, false, Encoding.Default);
            sw.Write(s.ToString());
            sw.Write(sb.ToString());
            sw.Close();

            MessageBox.Show("Datoteka spremna za ispis. Nalzi se u mapi: \n\n" + Path.GetFullPath(path));
        }

        public static void PrintCurrentMember(string id)
        {
            Members m;
            try
            {
                m = GetMemberById(id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }

            StringBuilder s = new StringBuilder();
            s.Append("Podaci za člana: ");
            s.Append(m.firstName + " " + m.lastName);
            s.Append(Environment.NewLine);
            s.Append(Environment.NewLine);

            StringBuilder sb = new StringBuilder();
            sb.Append("Ime: " + m.FirstName);
            sb.Append(Environment.NewLine);
            sb.Append("Prezime: " + m.LastName);
            sb.Append(Environment.NewLine);
            sb.Append("Spol: " + m.Gender);
            sb.Append(Environment.NewLine);
            sb.Append("Datum rođenja: " + m.DateOfBirth.ToShortDateString());
            sb.Append(Environment.NewLine);
            sb.Append("OIB: " + m.Oib);
            sb.Append(Environment.NewLine);
            sb.Append("Adresa: " + m.Adress);
            sb.Append(Environment.NewLine);
            sb.Append("E-mail: " + m.Email);
            sb.Append(Environment.NewLine);
            sb.Append("Kontakt broj: " + m.Contact);
            sb.Append(Environment.NewLine);
            sb.Append("Aktivan natjecatelj: ");
            if (m.ActiveCompetitor == true)
            {
                sb.Append("DA");
            }
            else
            {
                sb.Append("NE");
            }
            sb.Append(Environment.NewLine);
            sb.Append("Nivo natjecanja: " + m.LevelOfCompetition);
            sb.Append(Environment.NewLine);
            sb.Append("Trenira u grupi: " + m.TrainingGroup);
            sb.Append(Environment.NewLine);
            sb.Append("Datum učlanjenja: " + m.DateOfJoining.ToShortDateString());

            string path = "print/print_" + m.FirstName + "_" + m.lastName + ".txt";
            StreamWriter sw = new StreamWriter(path, false, Encoding.Default);
            sw.Write(s.ToString());
            sw.Write(sb.ToString());
            sw.Close();

            MessageBox.Show("Datoteka za člana: " + m.FirstName + " " + m.LastName + " spremna za ispis. Nalzi se mapi: \n\n" + Path.GetFullPath(path));
        }

        public enum trainingGroupSelect
        {
            rekreacija, selekcija, predškolci, predškolci1, rekreacija1  
        }

        public enum levelOfCompetitionSelectM
        {
           A, B, C, D
        }

        public enum levelOfCompetitionSelectF
        {
            A, B, C
        }
    }
}
