using Microsoft.EntityFrameworkCore;
using OfferMicroservice.DBContext;
using OfferMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OfferMicroservice.Repositories
{
  
    public class OfferRepository: DbContext
    {
        
        public List<Offer> offers = new List<Offer>
            {
                 new Offer() { EmployeeId=101,OfferId = 1, Status = "Available", Likes = 10, Category = "Electronics", OpenedDate =new DateTime(2021,10,01), Details="Resale of Mobile",ClosedDate=new DateTime(),EngagedDate=new DateTime(2021,10,10)},

                 new Offer() { EmployeeId=102,OfferId = 2, Status = "Engaged", Likes = 55, Category = "Electronics", OpenedDate = new DateTime(2021,10,04),ClosedDate=new DateTime(2021,12,04) , Details="Resale of washing machine",EngagedDate=new DateTime(2021,11,09)},

                 new Offer() { EmployeeId=103,OfferId = 3, Status = "Engaged", Likes = 20, Category = "Pets", OpenedDate = new DateTime(2021,10,04),ClosedDate=new DateTime(2021,12,05) , Details="Golden Retriever for Adoption",EngagedDate=new DateTime(2021,11,07)},

                 new Offer() { EmployeeId=103,OfferId = 4, Status = "Available", Likes = 25, Category = "Electronics", OpenedDate = new DateTime(2021,10,09),ClosedDate=new DateTime(2021,12,09) , Details="Resale of Mobile",EngagedDate=new DateTime(2021,11,12)},

                 new Offer() { EmployeeId=103,OfferId = 5, Status = "Available", Likes = 10, Category = "Electronics", OpenedDate = new DateTime(2021,10,09),ClosedDate=new DateTime(2021,12,10) , Details="Resale of Laptop",EngagedDate=new DateTime(2021,01,12)},

                 new Offer() { EmployeeId=104,OfferId = 6 ,Status = "Closed", Likes = 24, Category = "Books", OpenedDate = new DateTime(2021,10,09),EngagedDate=new  DateTime(2021,12,09), ClosedDate=new DateTime(2021,05,10),Details="Wings Of Fire"},

                 new Offer() {EmployeeId=104,OfferId = 7, Status = "Available", Likes = 25, Category = "Pets", OpenedDate =new DateTime(2021,10,18), Details="Dan Brown for Adoption",ClosedDate=new DateTime(2021,12,13),EngagedDate=new DateTime(2021,11,12)},

                 new Offer() { EmployeeId=105,OfferId = 8, Status = "Engaged", Likes = 22, Category = "Electronics", OpenedDate = new DateTime(2021,09,04),ClosedDate=new DateTime(2021,11,04) , Details="Resale of Mobile",EngagedDate=new DateTime(2021,11,06)},


                 new Offer() { EmployeeId=105,OfferId = 9, Status = "Closed", Likes = 18, Category = "Books", OpenedDate = new DateTime(2021,10,01),EngagedDate=new  DateTime(2021,11,03), ClosedDate=new DateTime(2021,12,05),Details="Harry Potter Books"},

            };

    }
}
