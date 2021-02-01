using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.IO;

namespace PRG2_T02_Team11
{
    class Program
    {
        static void Main(string[] args)
        {
            /* create an empty list to store the data */
            List<Vistor> vistorList = new List<Vistor>();
            List<SHNFacility> sHNFacilityList = new List<SHNFacility>();
            List<SafeEntry> safeList = new List<SafeEntry>();
            List<BusinessLocation> businessList = new List<BusinessLocation>();
            List<TravelEntry> travelList = new List<TravelEntry>();
            List<Person> personList = new List<Person>();
            List<TraceTogetherToken> tracetogetherList = new List<TraceTogetherToken>();

            LoadPerson(personList);
            LoadBusiness(businessList);

            /* the progam will keep running until the users type 8 to exit the progam*/
            while (true)
            {
                try
                {
                    DisplayMenu();
                    Console.Write("Enter the option: ");
                    int menuopt = Convert.ToInt32(Console.ReadLine());
                    /* Display Resident / Vistor from a list and output to the main program */
                    if (menuopt == 1)
                    {
                        DisplayVistor(personList);
                    }
                    /* calling method from the api to the main program*/
                    else if (menuopt == 2)
                    {
                        DisplayFacility(sHNFacilityList);
                       
                    }
                    else if(menuopt == 3)
                    {
                        Console.Write("Name of the indiviual: ");
                        string option = Console.ReadLine();
                        ListPersonParticulars(personList, option);
                    }
                    // calling method from addVistor to add new record and display output.
                    else if (menuopt == 4)
                    { 
                        AddVistor(vistorList);
                    }
                    //search the name through the person.csv file
                    else if (menuopt == 5)
                    {
                        Console.Write("Name of the indivual: ");
                        string selectopt = Console.ReadLine();
                        Search(personList, travelList, sHNFacilityList, selectopt);
                        DisplayFacility(sHNFacilityList);
                        
                        Console.Write("Enter Facility Name: ");
                        string option = Console.ReadLine();
                        AssignSHNFacility(personList,travelList, sHNFacilityList, option);
                    }
                    // search the name through the person.csv file if found searchSHNCharges method to calculate and display to main program.
                    else if(menuopt == 6)
                    {
                        Console.Write("Name of the indivual: ");
                        string option = Console.ReadLine();
                        SearchsHNCharges(personList, travelList, sHNFacilityList, option);
                    }
                    else if (menuopt == 7)
                    {
                        Console.Write("Name of the indivual: ");
                        string name = Console.ReadLine();
                        SearchPerson(personList, name);

                        foreach (BusinessLocation b in businessList)
                        {
                            Console.WriteLine(b);
                        }

                        Console.Write("Enter Branch Code: ");
                        string code = Console.ReadLine();
                        BusinessLocation result = SearchLocation(businessList, code);

                        if (result != null)
                        {
                            bool full = result.IsFull(code);

                            if (full == true)
                            {
                                Console.WriteLine("Location has reached max capacity. ");
                            }
                            else
                            {
                                result.VisitorsNow += 1;
                                SafeEntry s1 = new SafeEntry(DateTime.Now, result);
                                safeList.Add(s1);
                                Person personresult = SearchPerson(personList, name);
                                personresult.AddSafeEntry(s1);

                                Console.WriteLine("Check In: " + s1.CheckIn);
                            }
                        }
                        else
                        {
                            Console.WriteLine("BranchCode not found. ");
                        }
                    }

                    else if (menuopt == 8)
                    {
                        Console.Write("Name of the indivual: ");
                        string name = Console.ReadLine();
                        SearchPerson(personList, name);

                        foreach (BusinessLocation b in businessList)
                        {
                            Console.WriteLine(b);
                        }

                        Console.Write("Enter Branch Code: ");
                        string code = Console.ReadLine();
                        BusinessLocation result2 = SearchLocation(businessList, code);
                        if (result2 != null)
                        {
                            result2.VisitorsNow -= 1;
                            SafeEntry result3 = SearchCheckIn(safeList, result2);

                            if (result3 != null)
                            {
                                result3.PerformCheckOut(code);
                                Console.WriteLine("Check Out: " + result3.CheckOut);
                                safeList.Remove(result3);

                                foreach (SafeEntry s in safeList)
                                {
                                    Console.WriteLine(s);
                                }
                            }

                            else
                            {
                                Console.WriteLine("You have not Checked In to this Location. ");
                            }

                        }

                        else
                        {
                            Console.WriteLine("BranchCode not found. ");
                        }
                    }

                    else if (menuopt == 8)
                    {
                        foreach (BusinessLocation b in businessList)
                        {
                            Console.WriteLine(b);
                        }

                        Console.Write("Enter Branch Code: ");
                        string code = Console.ReadLine();
                        BusinessLocation locationresult = SearchLocation(businessList,code);
                        if (locationresult != null)
                        {
                            Console.Write("Enter New Capacity: ");
                            int capacity = Convert.ToInt32(Console.ReadLine());
                            locationresult.MaximumCapacity = capacity;
                        }

                        else
                        {
                            Console.WriteLine("BranchCode not found. ");
                        }

                    }

                    else if (menuopt == 9)
                    {
                        Console.Write("Enter Individual Name: ");
                        string name = Console.ReadLine();
                        Person personresult = SearchPerson(personList, name);
                        
                        Console.Write("Serial Number: ");
                        string serial = Console.ReadLine();
                        Console.Write("Collection Location: ");
                        string collection = Console.ReadLine();
                        Console.Write("Expiry Date: ");
                        DateTime expiry = Convert.ToDateTime(Console.ReadLine());
                        TraceTogetherToken t = new TraceTogetherToken(serial, collection, expiry);
                        tracetogetherList.Add(t);
                        Console.WriteLine("Token has been added to the list sucessfully.");

                    }

                    else
                    {
                        Console.WriteLine("bye");
                        break;
                    }
                }
                catch(FormatException fe)
                {
                    Console.WriteLine("You have entered an invalid input. Please try again.");
                    Console.WriteLine("Error Message:{0} ", fe.Message);
                }
            }
        }      
        /* Display a menu for the user to interact. */
        static void DisplayMenu()
        {
            Console.WriteLine("");
            Console.WriteLine("--------Main Menu--------");
            Console.WriteLine("1) Display Resident & Visitor List");
            Console.WriteLine("2) Display SHN Facilities");
            Console.WriteLine("3) Create Vistor");
            Console.WriteLine("4) Create TravelEntry Record");
            Console.WriteLine("5) Calculate SHNCharges");
            Console.WriteLine("6) SafeEntry CheckIn");
            Console.WriteLine("7) SafeEntry CheckOut");
            Console.WriteLine("8) Edit Business Location Capacity");
            Console.WriteLine("9) Assign/Replace TraceTogether Token");
            Console.WriteLine("10) Exit");
            Console.WriteLine("-------------------------");
        }
        
        // Display the vistor object to personList and display the output.
        static void DisplayVistor(List<Person> personList)
        {
            int counter = 1;   
            Console.WriteLine("---------------------------------------------------------------");
            Console.WriteLine("{0,3} {1,-18} {2,18} {3,21}","", "Name", "PassportNumber", "Nationality");
            Console.WriteLine("---------------------------------------------------------------");
            foreach(Vistor p in personList)
            {
                 Console.WriteLine("[{0,1}] {1,-20} {2,16} {3,21}", counter, p.Name, p.PassportNo, p.Nationality);
                 counter++;
             }
        }
        /* Create a vistor object */
        public static Vistor AddVistor(List<Vistor> vistorList)
        {
            Console.Write("Name of the indivual: ");
            string name = Console.ReadLine();
            Console.Write("Passport number: ");
            string pass = Console.ReadLine();
            Console.Write("Nationality: ");
            string nati = Console.ReadLine();
            Vistor vl = new Vistor(name, pass, nati);
            vistorList.Add(vl);
            Console.WriteLine("New Vistor has been added to the list sucessfully.");
            return vl;
        }
        /* Display the SHNFacilities and store into a list for output.*/
        static void DisplayFacility(List<SHNFacility> sHNFacilityList)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://covidmonitoringapiprg2.azurewebsites.net");
                Task<HttpResponseMessage> responsetask = client.GetAsync("/facility");
                responsetask.Wait();
                HttpResponseMessage result = responsetask.Result;
                if (result.IsSuccessStatusCode)
                {
                    Task<string> Readtask = result.Content.ReadAsStringAsync();
                    Readtask.Wait();
                    string data = Readtask.Result;
                    sHNFacilityList = JsonConvert.DeserializeObject<List<SHNFacility>>(data);
                    Console.WriteLine("---------------------------------------------------------------------------------------------------------");
                    Console.WriteLine("{0,3} {1,-20} {2,-20} {3,-20} {4,-20} {5,-23}", "","FacilityName", "FacilityCapacity", "Distance From Air", "Distance From Land",
                    "Distance From Sea");
                    Console.WriteLine("---------------------------------------------------------------------------------------------------------");
                    int counter = 1;
                    foreach (SHNFacility s in sHNFacilityList)
                    {
                        Console.WriteLine("[{0,1}] {1,-20} {2,16} {3,21} {4,21} {5,19}", counter, s.FacilityName, s.FacilityCapacity, s.DistFromAirCheckpoint,
                        s.DistFromLandCheckpoint, s.DistFromSeaCheckpoint);
                        counter++;
                    }
                }
            }
        }
        // create a list for the person particular and display on main program.
        static bool ListPersonParticulars(List<Person> personList, string option)
        {
            using StreamReader sr = new StreamReader("resource/Person.csv");
            string read = sr.ReadLine();
            while ((read = sr.ReadLine()) != null)
            {
                string[] body = read.Split(",");
                foreach(Person p in personList)
                {   
                    if (option == p.Name)
                    {
                        Console.WriteLine("{0, -8} {1,-8} {2,-8} {3,-8} {4,-8} {5,-8} {6,-8} {7,-8} {8,-8} {9,-8} {10,-8} {11,-8} {12,-8} {13,-8} {14,-8}",
                        body[0], body[1], body[2], body[3], body[4], body[5], body[6], body[7], body[8], body[9], body[10],
                        body[11], body[12], body[13], body[14]);
                        return true;
                    }
                }
            }
            Console.WriteLine("There is an invalid input. Therefore unable to create successfully");
            return false;
        }
        // search name through the person.csv if found create an object and calculate SHNDate.
        static bool Search(List<Person> personList, List<TravelEntry> travelList, List<SHNFacility> sHNFacilityList,
        string name)
        {
            foreach (Person p in personList)
            {
                if (name == p.Name)
                {
                    Console.Write("Last Of Embarkment: ");
                    string loe = Console.ReadLine();
                    Console.Write("Entry Mode: ");
                    string EM = Console.ReadLine();
                    Console.Write("Entry Date: ");
                    DateTime ed = Convert.ToDateTime(Console.ReadLine());
                    travelList.Add(new TravelEntry(loe, EM, ed));
                    foreach (TravelEntry t in travelList)
                    {
                        t.CalculateSHNDuration();
                    }
                    return true;
                }
            }
            Console.WriteLine(name + " is not found on the system.");
            return false;
        }

        static Person SearchPerson(List<Person> personList, string name)
        {
            foreach (Person p in personList)
            {
                if (name == p.Name)
                {
                    return p;
                }
            }
            Console.WriteLine(name + " is not found on the system.");
            return null;
        }
        // create and implement the personList method when the program runs.
        static void LoadPerson(List<Person> personList)
        {
            using StreamReader sr = new StreamReader("resource/Person.csv");
            string read = sr.ReadLine();
            while ((read = sr.ReadLine()) != null)
            {
                string[] body = read.Split(",");
                string name = body[1];
                string passportno = body[4];
                string nationality = body[5];
                Person p = new Vistor(name,passportno,nationality);
                personList.Add(p);
            }
        }
        // assign shnFacility to the user and display the output.
        static bool AssignSHNFacility(List<Person> personList, List<TravelEntry> travelList, List<SHNFacility> sHNFacilityList, string name)
        {
            foreach (TravelEntry t in travelList)
            {
                //Console.WriteLine("test");
                foreach (SHNFacility s in sHNFacilityList)
                {
                    if (name == s.FacilityName)
                    {
                        t.AssignSHNFacility(s);
                    }
                    Console.WriteLine("New Record Has Been Created Successfully.");
                    return true;
                }
            }
            Console.WriteLine("There is an invalid input. Therefore unable to create successfully");
            return false;
        }   
        // create and implement the BusinessList method when the program runs.
        static void LoadBusiness(List<BusinessLocation> businessList)
        {
            string[] csvLines = File.ReadAllLines("resource/BusinessLocation.csv");
            string[] heading = csvLines[0].Split(",");

            for (int i = 1; i < csvLines.Length; i++)
            {
                string[] lines = csvLines[i].Split(",");
                BusinessLocation s = new BusinessLocation(lines[0], lines[1], Convert.ToInt32(lines[2]));
                businessList.Add(s);
            }
        }
        // search person name through the personList and calculate SHNCharges.
        static bool SearchsHNCharges(List<Person> personList, List<TravelEntry> travelList,
        List<SHNFacility> sHNFacilityList, string option)
        {
            foreach (Person p in personList)
            {
                if (option == p.Name)
                {
                    p.CalculateSHNCharges();
                    Console.WriteLine("Do you wish to make a payment: ");
                    string yesorno = Console.ReadLine();
                    if(yesorno == "Yes")
                    {
                        // code is not working at the moment.
                    }
                    else
                    {
                        // code is not working at the moment.
                    }
                    Console.WriteLine("New Records Has Been updated successfully.");
                    return true;
                }
            }
            Console.WriteLine("You have entered an invaild input. Please renter again.");
            return false;
        }
       
        static BusinessLocation SearchLocation(List<BusinessLocation> businessList, string code)
        {
            foreach (BusinessLocation b in businessList)
            {
                if (code == b.BranchCode)
                {
                    return b;
                }
            }
            return null;
        }

        static SafeEntry SearchCheckIn(List<SafeEntry> safeList, BusinessLocation location)
        {
            foreach (SafeEntry s in safeList)
            {
                if (location == s.Location)
                {
                    return s;
                }
            }
            return null;
        }
    }
}
             
