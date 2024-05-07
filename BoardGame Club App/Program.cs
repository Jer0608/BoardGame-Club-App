//imports

using System.Reflection.Metadata.Ecma335;

namespace Insurance_App
{
    public class Program
    {


        //global variables

        static int deviceCounter = 0;
        static string topDevice;
        static float topexpensiveDevice = 0;
        static float totalvalueforinsurancecounter = 0;
        readonly static List<string> ERRORMESSAGES = new List<string>();
        static int laptopCount = 0, desktopCount = 0, otherDevicesCount = 0;



        //methods and functions

        static string checkname()
        {
            while (true)
            {
                Console.WriteLine("Enter the device name:\n");
                string name = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(name))
                {
                    name = name[0].ToString().ToUpper() + name.Substring(1);
                    return name;
                }
                DisplayErrorMessage("ERROR: You must enter a device name");
            }


        }

        static string MenuChoice(string menuType, List<string> listData)
        {
            string menu = GenerateMenu(menuType, listData);
            return listData[CheckInt(menu, 1, listData.Count) - 1];
        }

        static int CheckInt(string deviceCategory, int min, int max)
        {
            while (true)
            {
                try
                {
                    Console.WriteLine(deviceCategory);

                    int userInt = Convert.ToInt32(Console.ReadLine());

                    if (userInt >= min && userInt <= max)
                    {
                        return userInt;
                    }

                    DisplayErrorMessage($"ERROR: You must enter an integer between {min} and {max}");
                }

                catch
                {
                    DisplayErrorMessage($"ERROR: You must enter an integer between {min} and {max}");
                }

            }
        }

        static float Checkfloat(string deviceCost, float min, float max)
        {
            while (true)
            {
                try
                {
                    Console.WriteLine(deviceCost);

                    float userfloat = (float)Convert.ToDecimal(Console.ReadLine());

                    if (userfloat >= min && userfloat <= max)
                    {
                        return userfloat;
                    }
                    DisplayErrorMessage($"ERROR: You must enter an integer between {min} and {max}");
                }
                catch
                {
                    DisplayErrorMessage($"ERROR: You must enter an integer between {min} and {max}");
                }
            }

        }
        static string GenerateMenu(string menuType, List<string> listData)
        {
            string menu = $"Enter the {menuType}:\n";
            for (int loop = 0; loop < listData.Count; loop++)
            {
                menu += $"{loop + 1}. {listData[loop]}\n";
            }
            return menu;
        }

        static void OneDevice()
        {
            List<string> deviceCategories = new List<string> { "Laptops", "Desktops", "other devices such as smartphones" };
            deviceCategories.AsReadOnly();

            //user enters device name
            string deviceName = checkname();

            //user enters number of devices
            int numberofdevices = CheckInt("Enter the number of devices:\n", 0, 1000);

            //user enters the device cost
            float deviceCost = Checkfloat("Enter the device cost:\n", 1, 5000);

            //user enters the device category
            int deviceCategory = CheckInt(GenerateMenu("device category", deviceCategories), 1, 3);


            Console.WriteLine($"{deviceName}\n");

            //calculate the insurance amount
            float insuranceCost = 0;

            if (numberofdevices > 5)

            {
                insuranceCost += 5 * deviceCost;
                insuranceCost += (numberofdevices - 5) * deviceCost * 0.9f;
            }

            else

            {
                insuranceCost += numberofdevices * deviceCost;
            }


            string id = GenerateID(deviceName, numberofdevices, deviceCost, deviceCategory);

            //Display the device summary
            string deviceSummary = $" ID: {id}\nName: {deviceName} {deviceCategory} {deviceCost} {numberofdevices} {deviceCounter}\n";
            Console.WriteLine($"The total cost for {numberofdevices} x {deviceName} devices is equal to ${insuranceCost}");

            //Calculate device's depreciation: value will reduce by 5% over 6 months
            Console.WriteLine("month\t value loss");

            float depreciation = deviceCost;
            for (int month = 0; month < 6; month++)
            {
                depreciation = depreciation * 0.95f;
                Console.WriteLine($"{month + 1}\t{depreciation}");
            }

            if (deviceCost > topexpensiveDevice)
            {
                topexpensiveDevice = deviceCost;
                topDevice = deviceName;

            }

            if (deviceCategory.Equals(1))
            {
                laptopCount += numberofdevices;
            }
            else if (deviceCategory.Equals(2))
            {
                desktopCount += numberofdevices;
            }
            else if (deviceCategory.Equals(3))
            {
                otherDevicesCount += numberofdevices;
            }

            if (insuranceCost > 0)
            {
                totalvalueforinsurancecounter += insuranceCost;
            }

            Console.WriteLine($"Category:{deviceCategories[deviceCategory - 1]}");

            //Calculate the most expensive device
            Console.WriteLine($"{topDevice} is the most {topexpensiveDevice} expensive device");

            //Display the number of laptops, desktops, and other devices
            Console.WriteLine($" the number of laptops is: {laptopCount}");
            Console.WriteLine($" the number of desktops is: {desktopCount}");
            Console.WriteLine($" the number of other devices is: {otherDevicesCount}");

        }

        static void DisplayErrorMessage(string error)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(error);
            Console.ForegroundColor = ConsoleColor.White;

        }
        static string CheckName(string question)
        {
            while (true)
            {


                Console.WriteLine(question);
                string deviceName = Console.ReadLine();


                int number;

                bool test = !int.TryParse(deviceName, out number);

                if (!string.IsNullOrEmpty(deviceName) && !int.TryParse(deviceName, out number))
                {
                    deviceName = deviceName[0].ToString().ToUpper() + deviceName.Substring(1);
                    return deviceName;
                }

            }
        }


        static string GenerateID(string devicename, int numberofdevices, float deviceCost, int deviceCategory)
        {
            return "";
        }




        //main process or when run
        static void Main(string[] args)
        {

            //Display App title

            Console.WriteLine(
"██╗ ███     ██║ ███████╗  ██╗   ██╗  ██████╗   █████╗  ███╗   ██  ███████╗ ███████╗      █████╗   ████╗   ████╗                 \n" +
"██║ ████╗   ██║ ██╔════   ██║   ██║  ██╔══██╗ ██╔══██╗ ████╗  ██║ ██╔════╝ ██╔════╝     ██╔══██╗ ██╔══██╗██╔══██╗              \n" +
"██║ ██╔██╗  ██║ ███████╗  ██║   ██║  ██████╔╝ ███████║ ██╔██╗ ██║ ██║      █████╗       ███████║ ██████╔╝██████╔╝            \\\n" +
"██║ ██║╚██╗ ██║ ╚════ ██  ██║   ██║  ██╔══██╗ ██╔══██║ ██║╚██╗██║ ██║      ██╔══╝       ██╔══██║ ██╔═══╝ ██╔═══╝              \n" +
"██║ ██║  ╚████║ ███████║  ██████ ╔╝  ██║  ██║ ██║  ██║ ██║ ╚████║ ╚██████╗ ███████╗     ██║  ██║ ██║     ██║     		       \n" +
"╚═╝ ╚═╝   ╚═══╝ ╚══════╝  ╚═════╝    ╚═╝  ╚═╝ ╚═╝  ╚═╝ ╚═╝  ╚═══╝   ╚════╝  ╚═════╝     ╚═╝  ╚═╝ ╚═╝     ╚═╝                   \n");
            //call oneDevice

            string proceed = "";
            while (proceed.Equals(""))
            {
                OneDevice();
                proceed = CheckProceed();
            }



            //Check if user wants to add another device

            static string CheckProceed()
            {

                while (true)
                {
                    Console.WriteLine("Press <ENTER> to add another device or type 'X' to exit");
                    string checkProceed = Console.ReadLine();

                    //if true repeast from step 2

                    if (checkProceed.Equals("") || checkProceed.Equals("X") || checkProceed.Equals("x"))
                    {
                        return checkProceed;
                    }

                    Console.WriteLine(ERRORMESSAGES[0]);

                    DisplayErrorMessage($"ERROR: Invalid choice");

                }
            }

            //if false then display total insurance value
            Console.WriteLine($"Total value for insurance ${totalvalueforinsurancecounter}");




        }



    }

}








