using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfferMicroservice.Models;
using OfferMicroservice.Repositories;
using OfferMicroservice.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using OfferMicroservice.Service;
using Microsoft.AspNetCore.Authorization;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OfferMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    public class OfferController : ControllerBase
    {
        public readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(OfferController));
        public readonly OfferService _service;
        public OfferController()
        {
            _service = new OfferService();
        }

        // GET: api/<OfferController>
        [HttpGet]
        [Route("GetOffersList")]
        public ActionResult<Offer> GetOffersList()
        {
            _log4net.Info("GetOfferList Method Called and result is displayed");
            return Ok(_service.GetOffersList());
        }

        // GET api/<OfferController>/5
        [HttpGet]
        [Route("GetOfferById/{id}")]
        public ActionResult<Offer> GetOfferById(int id)
        {
            var offer = _service.GetOfferById(id);
            if (offer==null)
            {
                _log4net.Info("GetOfferById Method Called and result is not found");
                return BadRequest("Invalid Input as it is null");
            }            
            return offer; 
        }
        [HttpGet]
        [Route("GetOfferByCategory/{category}")]
        public ActionResult<Offer> GetOfferByCategory(string category)
        {

            var offer = _service.GetOfferByCategory(category);
            if (offer.Count()==0)
            {
                _log4net.Info("GetOfferByCategory Method Called and result is not found");
                return BadRequest("Category does  not exist");
            }
            return Ok(offer); // results in 200 ok status 

        }
        [HttpGet]
        [Route("GetOfferByOpenedDate/{openedDate}")]
        public ActionResult<Offer> GetOfferByOpenedDate(string openedDate)
        {
            var offer = _service.GetOfferByOpenedDate(openedDate);
            if (offer.Count()==0)
            {
                _log4net.Info("GetOfferByOpenDate Method Called and result is not found");
                return BadRequest("Opening date is invalid");
            }
            return Ok(offer); // results in 200 ok status 
        }
        [HttpGet]
        [Route("GetOfferByTopThreeLikes/{category}")]
        public ActionResult<Offer> GetOfferByTopThreeLikes(string category)
        {

            var offer = _service.GetOfferByTopThreeLikes(category);
            if (offer.Count()==0)
            {
                _log4net.Info("GetOfferByTopThreeLikes Method Called and result is not found");
                return BadRequest("Given Category is invalid");
            }
            return Ok(offer); // results in 200 ok status 
        }
        [HttpGet]
        [Route("EditOfferList")]
        public ActionResult<Offer> EditOfferList(Offer offer)
        {
            offer.EmployeeId = Convert.ToInt32(HttpContext.Session.GetInt32("EmployeeId"));
            Offer offerObj = _service.EditOfferList(offer);
            _log4net.Info("EditOfferList Method is called and list is successfully edited");
            return offer;
        }
        [HttpPost]
        [Route("PostOffer")]
        public ActionResult<IEnumerable<Offer>> PostOffer(Offer newOffer)
        {
            if (newOffer.OfferId == 0 || newOffer.EmployeeId == 0 || newOffer.Category == null || newOffer.Details == null)
            {
                _log4net.Info("PostOffer Method Called and result is not found");
                return NotFound();
            }
            else
            {
                _log4net.Info("New Offer Is posted");
                _service.GetOffersList().Add(newOffer);
            }

            return _service.GetOffersList();
        }
        [HttpPost]
        [Route("EditOffer")]
        public ActionResult<Offer> EditOffer(Offer updatedOffer)
        {
            Offer offer = _service.EditOffer(updatedOffer);
            if (offer == null)
            {
                _log4net.Info("PostOffer Method Called and result is not found");
                return NotFound("Offer not found");
            }
            offer.ClosedDate = updatedOffer.ClosedDate;
            offer.Status = updatedOffer.Status;
            offer.Details = updatedOffer.Details;
            offer.Category = updatedOffer.Category;
            if (offer.ClosedDate > offer.EngagedDate && offer.Status != "Closed")
            {
                _log4net.Info("PostOffer Method Called and Updated status to close");
                return BadRequest("Please update status to Closed");
            }
            return Ok("Edited Successfully");
        }
        [HttpPost]
        [Route("EngageOffer")]
        public ActionResult<IEnumerable<Offer>> EngageOffer(Offer offerDetails)
        {
            Offer offer = _service.EngageOffer(offerDetails);
            if (offer == null)
            {
                _log4net.Info("PostOffer Method Called and result is not found");
                return NotFound("Offer not found");
            }
            else if (offer.Status == "Engaged" || offer.Status == "Closed")
            {
                return BadRequest("Offer is either Engaged or Closed");
            }
            else
            {
                offer.Status = "Engaged";
                offer.EngagedDate = DateTime.Now;
                return Ok("Offer status updated to Engaged");
                //return offers;
            }
        }   
        [HttpPost]
        [Route("LikeOffer")]
        public  ActionResult<Offer> LikeOffer(Offer o)
        {
            Offer offer = _service.LikeOffer(o);
            if (offer == null)
            {
                return NotFound("Offer not found");
            }
            else
            {
                offer.Likes = offer.Likes + 1;
                return Ok("Liked");
            }
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

    }
}
