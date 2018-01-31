using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment2.Models;

namespace Assignment2.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ClubContext context)
        {
            context.Database.EnsureCreated();

            // Look for any members
            if (context.Members.Any())
            {
                return;   // DB has been seeded
            }

            var members = new Member[]
            {
            new Member{FirstName="Tim",LastName="Sanchez",Classification="Senior", MemberID="abc123"},
            new Member{FirstName="Christian",LastName="Loya",Classification="Senior", MemberID="abc123"},
            new Member{FirstName="Saru",LastName="Pahari",Classification="Senior", MemberID="abc123"},
            new Member{FirstName="Sarah",LastName="Valdez",Classification="Senior", MemberID="abc123"},
            new Member{FirstName="Eric",LastName="Sanchez",Classification="Senior", MemberID="abc123"}
            };
            foreach (Member m in members)
            {
                context.Members.Add(m);
            }
            context.SaveChanges();

            var clients = new Client[]
            {
            new Client{Name="CSI", Location="Amarillo", Phone="(800)000-0000", ClientID="1"},
            new Client{Name="Golden Spread Eletric", Location="Lubbock", Phone="(800)111-1111", ClientID="2"},
            new Client{Name="The Vested Group", Location="Plano", Phone="(800)222-2222", ClientID="3" }
            };
            foreach (Client c in clients)
            {
                context.Clients.Add(c);
            }
            context.SaveChanges();

            var smes = new Sme[]
           {
            new Sme{EmployeeID="1", FirstName="Brett", LastName="Ponder", Title="Advisor or Expert"}
           };
            foreach (Sme s in smes)
            {
                context.Smes.Add(s);
            }
            context.SaveChanges();
        }
    }
}
