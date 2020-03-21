using Golf_CA2_API_Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Golf_CA2_API_Client

{
    class Program
    {
            static async Task GetsClubsAsync()
            {
            using(HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:62457/api/GolfClub/");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("applications/json"));

                //GET api/ GolfClub / 
                HttpResponseMessage response = await client.GetAsync("all");
                if (response.IsSuccessStatusCode)
                {
                    var returnedClubs = await response.Content.ReadAsAsync<IEnumerable<GolfClub>>();
                    Console.WriteLine("*** Complete Golf Club List ****");
                    int i = 0;
                    foreach (GolfClub g in returnedClubs)
                    {
                        i += 1;
                        Console.WriteLine(i + ". " + g);
                    }
                }

                //GET api/ GolfClub /{ id}
                response = await client.GetAsync("1");
                if (response.IsSuccessStatusCode)
                {
                    var returnedGolfClub = await response.Content.ReadAsAsync<GolfClub>(); // add from Console line
                    Console.WriteLine("\nGolf Club with ID 1: " + returnedGolfClub);
                }

                //POST api/ GolfClub / AddClub
                GolfClub g1 = new GolfClub() { ID = 4, Name = "Milltown G.C." };
                response = client.PostAsJsonAsync("AddClub", g1).Result;
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("\nAdded Golf Club: " + g1.Name);
                }

                //PUT api/ GolfClub / UpdateClub
                GolfClub g2 = new GolfClub() { ID = 4, Name = "Bohernabreena G.C." };
                response = client.PutAsJsonAsync("UpdateClub", g2).Result;
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("\nUpdated Golf Club: " + g2.Name);
                }

                //DELETE api/ GolfClub / DeleteClub
                response = await client.GetAsync("4");
                var returnGolfClub = await response.Content.ReadAsAsync<GolfClub>();

                response = client.DeleteAsync("DeleteClub/4").Result;
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("\nDeleted Golf Club: " + returnGolfClub.Name);
                }
            }
        }

        static async Task GetsGolfersAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:62457/api/Golfer/");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("applications/json"));

                // GET: api/GolfClub/all
                HttpResponseMessage response = await client.GetAsync("all");
                if (response.IsSuccessStatusCode)
                {
                    var returnedGolfers = await response.Content.ReadAsAsync<IEnumerable<Golfer>>(); // add from Console line
                    Console.WriteLine("*** Complete Golfer List ***");
                    foreach (Golfer g in returnedGolfers)
                    {
                        Console.WriteLine(g);
                    }
                }

                // GET: api/GolfClub/GetByGUI/11111111
                response = await client.GetAsync("1111");
                if (response.IsSuccessStatusCode)
                {
                    var returnedGolfer = await response.Content.ReadAsAsync<Golfer>(); // add from Console line
                    Console.WriteLine("\n*** Golfer with GUI of 1111 is ***" + returnedGolfer);
                }


                // POST: api/GolfClub/AddGolfer
                Golfer g1 = new Golfer() { GUI = 5555, FirstName = "Simon", Surname = "Hughes", Handicap = 45, ClubID = 3};
                response = client.PostAsJsonAsync("AddGolfer", g1).Result;
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("\nAdded Golfer: " + g1.FirstName + " " + g1.Surname);
                }


                // PUT: api/GolfClub/UpdateGolfer
                Golfer g2 = new Golfer() { GUI = 5555, FirstName = "Rick", Surname = "Ross", Handicap = 3, };
                response = client.PutAsJsonAsync("UpdateGolfer", g2).Result;
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("\nUpdated Golfer: " + g2.FirstName + " " + g2.Surname);
                }


                // DELETE: api/GolfClub/DeleteMember/33333333
                response = await client.GetAsync("3333");
                var returnGolfer = await response.Content.ReadAsAsync<Golfer>();

                response = client.DeleteAsync("DeleteGolfer/3333").Result;
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("\nDeleted Golfer: " + returnGolfer.FirstName + " " + returnGolfer.Surname);
                }
            }
        }

        static void Main()
        {
            GetsClubsAsync().Wait();
            GetsGolfersAsync().Wait();
            Console.ReadLine();
        }
    }
}
