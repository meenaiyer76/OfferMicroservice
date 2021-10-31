using OfferMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OfferMicroservice.Constants
{
     public interface IConstant
    {
        public List<Offer> GetOffersList();

        public Offer GetOfferById(int id);
        public Offer EditOffer(Offer updatedOffer);
        public IEnumerable<Offer> GetOfferByCategory(string category);
        public IEnumerable<Offer> GetOfferByOpenedDate(string openedDate);
        public IEnumerable<Offer> GetOfferByTopThreeLikes(string category);
        public Offer EngageOffer(Offer offerDetails);
        public Offer LikeOffer(Offer o);
    }
}
