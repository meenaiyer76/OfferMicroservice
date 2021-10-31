using OfferMicroservice.Models;
using OfferMicroservice.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OfferMicroservice.Constants;
using Microsoft.AspNetCore.Http;

namespace OfferMicroservice.Service
{
    public class OfferService : IConstant
    {

        public readonly OfferRepository _offer;
        public OfferService()
        {
            _offer = new OfferRepository();
        }

        public Offer EditOfferList(Offer offer)
        {
            return _offer.offers.FirstOrDefault(c => c.OfferId == offer.OfferId && c.EmployeeId == offer.EmployeeId);
        }

        public IEnumerable<Offer> GetOfferByCategory(string category)
        {
            var offer = from c in _offer.offers where c.Category == category select c;
            return offer; 
        }

        public Offer GetOfferById(int id)
        {
            return _offer.offers.FirstOrDefault(c => c.OfferId == id);
        }

        public IEnumerable<Offer> GetOfferByOpenedDate(string openedDate)
        {
            var offer= from c in _offer.offers where c.OpenedDate.ToString("yyyy-MM-dd") == openedDate select c;
            return offer;
        }

        public IEnumerable<Offer> GetOfferByTopThreeLikes(string category)
        {
            var offer = (from c in _offer.offers where c.Category == category orderby c.Likes descending select c).Take(3);
            return offer;
        }

        public List<Offer> GetOffersList()
        {
            return _offer.offers;
        }
        public Offer EngageOffer(Offer offerDetails)
        {
            return _offer.offers.FirstOrDefault(c => c.OfferId == offerDetails.OfferId && c.EmployeeId == offerDetails.EmployeeId);
        }
        public Offer LikeOffer(Offer o)
        {
            return _offer.offers.FirstOrDefault(c => c.OfferId == o.OfferId);
        }
        public Offer EditOffer(Offer updatedOffer)
        {
            return _offer.offers.FirstOrDefault(c => c.OfferId == updatedOffer.OfferId && c.EmployeeId == updatedOffer.EmployeeId);
        }

    }
}
