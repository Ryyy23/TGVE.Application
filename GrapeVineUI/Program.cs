using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Net.Http;



namespace GrapeVineUI
{
    class Program
    {
        static int _menuNum = 0;
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("1. CLIENT \n2. TOURS");
                _menuNum = int.Parse(Console.ReadLine());
                switch (_menuNum)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("1. GET \n2. POST \n3. PUT \n4. DELETE \n5. Exit");
                        _menuNum = int.Parse(Console.ReadLine());
                        switch (_menuNum)
                        {
                            case 1:
                                Console.Clear();
                                Task.Run(ClientGETAsync).Wait();
                                break;
                            case 2:
                                Console.Clear();
                                //Task.Run(ClientPOSTAsync).Wait();
                                break;
                            case 3:
                                Console.Clear();
                                //Task.Run(ClientPUTAsync).Wait();
                                break;
                            case 4:
                                Console.Clear();
                                //Task.Run(ClientDELETEAsync).Wait();
                                break;
                            case 5:
                                Console.Clear();
                                break;
                        }
                        break;

                    case 2:
                        Console.Clear();
                        Console.WriteLine("1. GET \n2. POST \n3. PUT \n4. DELETE \n5. Exit");
                        _menuNum = int.Parse(Console.ReadLine());
                        switch (_menuNum)
                        {
                            case 1:
                                Console.Clear();
                                Task.Run(TourGETAsync).Wait();
                                break;
                            case 2:
                                Console.Clear();
                                //Task.Run(TourPOSTAsync).Wait();
                                break;
                            case 3:
                                Console.Clear();
                                //Task.Run(TourPUTAsync).Wait();
                                break;
                            case 4:
                                Console.Clear();
                                //Task.Run(TourDELETEAsync).Wait();
                                break;
                            case 5:
                                Console.Clear();
                                break;
                        }
                        break;
                }


            }

        }
        public static async Task ClientGETAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                var keyResponse = await client.GetAsync("http://localhost:59741/api/Clients/");
                var stringKeyResponse = await keyResponse.Content.ReadAsStringAsync();
                var KeyResponseObject = JsonConvert.DeserializeObject<List<ClientList>>(stringKeyResponse);

                foreach (var item in KeyResponseObject)
                {
                    Console.WriteLine("\nID: " + item.Id + "\nFirstName: " + item.FirstName + "\nLastName: " + item.LastName + "\nPhoneNumber: " + item.PhoneNumber + "\nAddress:" + item.Address + "\nDateOfBirth:" + item.DateOfBirth + "\nEmail:" + item.Email);
                }
                Console.ReadLine();
                  
     
    }
        }

        public static async Task TourGETAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                var keyResponse = await client.GetAsync("http://localhost:59741/api/Tours/");
                var stringKeyResponse = await keyResponse.Content.ReadAsStringAsync();
                var KeyResponseObject = JsonConvert.DeserializeObject<List<TourList>>(stringKeyResponse);

                foreach (var item in KeyResponseObject)
                {
                    Console.WriteLine("\nID: " + item.Id + "\nTourStartTime: " + item.TourStartTime + "\nTourEndTime: " + item.TourEndTime + "\nName: " + item.Name + "\nDescrption:" + item.Description + "\nArea:" + item.Area + "\nLocation:" + item.Location);
                }
                Console.ReadLine();
            }
        }
        public static async Task ClientPOSTAsync()
        {
            Console.WriteLine("Enter Client ID");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Client first name");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter Client last name");
            string lastname = Console.ReadLine();
            Console.WriteLine("Enter Client Phone Number");
            string phoneNumber = Console.ReadLine();
            Console.WriteLine("Enter Client Email");
            string email = Console.ReadLine();
            Console.WriteLine("Enter Client Address");
            string address = Console.ReadLine();
            Console.WriteLine("Enter Client DOB");
            DateTime dateofbirth = new DateTime();


            using (var client = new HttpClient())
            {
                var obj = JsonConvert.SerializeObject(new ClientList
                {
                    Id = id,
                    FirstName = firstName,
                    LastName = lastname,
                    PhoneNumber = phoneNumber,
                    Email = email,
                    Address = address,
                    DateOfBirth = dateofbirth

                },
                new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver(),
                    NullValueHandling = NullValueHandling.Ignore,
                });
                var content = new StringContent(obj, Encoding.Unicode, "application/json");
                await client.PostAsync("http://localhost:59741/api/Clients/" + id, content);
            }
        }
        public static async Task TourPOSTAsync()
        {
            Console.WriteLine("Enter Tour ID");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Tour Start Time ");
            DateTime tourstarttime = new DateTime();
            Console.WriteLine("Enter Tour End Time");
            DateTime tourendtime = new DateTime();
            Console.WriteLine("Enter Tour Name");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Tour Descrption");
            string descrption = Console.ReadLine();
            Console.WriteLine("Enter Tour Area");
            float area = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter Tour Location");
            string location = Console.ReadLine();
            using (var client = new HttpClient())
            {
                var obj = JsonConvert.SerializeObject(new TourList
                {
                    Id = id,
                    TourStartTime = tourstarttime,
                    TourEndTime = tourendtime,
                    Name = name,
                    Description = descrption,
                    Area = area,
                    Location = location
             

                },
                new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver(),
                    NullValueHandling = NullValueHandling.Ignore,
                });
                var content = new StringContent(obj, Encoding.Unicode, "application/json");
                await client.PostAsync("http://localhost:59741/api/Tours/" + id, content);
            }
        }
        public static async Task ClientPUTAsync()
        {
         
            using (HttpClient client = new HttpClient())
            {

                Console.WriteLine("Enter Client ID");
                int id = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter Client first name");
                string firstName = Console.ReadLine();
                Console.WriteLine("Enter Client last name");
                string lastname = Console.ReadLine();
                Console.WriteLine("Enter Client Phone Number");
                string phoneNumber = Console.ReadLine();
                Console.WriteLine("Enter Client Email");
                string email = Console.ReadLine();
                Console.WriteLine("Enter Client Address");
                string address = Console.ReadLine();
                Console.WriteLine("Enter Client DOB");
                DateTime dateofbirth = new DateTime();
                var obj = JsonConvert.SerializeObject(new ClientList
                { 
                    Id = id,
                    FirstName = firstName,
                    LastName = lastname,
                    PhoneNumber = phoneNumber,
                    Email = email,
                    Address = address,
                    DateOfBirth = dateofbirth
                },
                    new JsonSerializerSettings
                    {
                        ContractResolver = new CamelCasePropertyNamesContractResolver(),
                        NullValueHandling = NullValueHandling.Ignore,

                    });
                var content = new StringContent(obj, Encoding.Unicode, "application/json");
                var url = "http://localhost:59741/api/Clients/" + id;
                await client.PutAsync(url, content);
                

            }
        }
        public static async Task TourPUTAsync()
        {

            using (HttpClient client = new HttpClient())
            {

                Console.WriteLine("Enter Tour ID");
                int id = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter Tour Start Time ");
                DateTime tourstarttime = new DateTime();
                Console.WriteLine("Enter Tour End Time");
                DateTime tourendtime = new DateTime();
                Console.WriteLine("Enter Tour Name");
                string name = Console.ReadLine();
                Console.WriteLine("Enter Tour Descrption");
                string descrption = Console.ReadLine();
                Console.WriteLine("Enter Tour Area");
                float area = float.Parse(Console.ReadLine());
                Console.WriteLine("Enter Tour Location");
                string location = Console.ReadLine();
                var obj = JsonConvert.SerializeObject(new TourList
                {
                    Id = id,
                    TourStartTime = tourstarttime,
                    TourEndTime = tourendtime,
                    Name = name,
                    Description = descrption,
                    Area = area,
                    Location = location
                },
                    new JsonSerializerSettings
                    {
                        ContractResolver = new CamelCasePropertyNamesContractResolver(),
                        NullValueHandling = NullValueHandling.Ignore,

                    });
                var content = new StringContent(obj, Encoding.Unicode, "application/json");
                var url = "http://localhost:59741/api/Tours/" + id;
                await client.PutAsync(url, content);


            }
        }
       
        public static async Task ClientDELETEAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                Console.Write("Enter  Client id to delete");
                string id = Console.ReadLine();
                var url = "http://localhost:59741/api/Clients/" + id;
                await client.DeleteAsync(url);
            }
        }

        public static async Task TourDELETEAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                Console.Write("Enter Tour id to delete");
                string id = Console.ReadLine();
                var url = "http://localhost:59741/api/Tours/" + id;
                await client.DeleteAsync(url);
            }
        }

        public class ClientList
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string PhoneNumber { get; set; }

            public string Address { get; set; }

            public DateTime DateOfBirth { get; set; }
            public string Email { get; set; }




        }

        public class TourList
        {
            public int Id { get; set; }
            public DateTime TourStartTime { get; set; }
            public DateTime TourEndTime { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public float Area { get; set; }
            public string Location { get; set; }

        }
    }
}
