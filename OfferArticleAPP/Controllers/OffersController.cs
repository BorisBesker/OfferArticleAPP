using AutoMapper;
using Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;
using OfferArticleWebApi.Helpers;
using RetailProcurementApp.Dto;
using ServiceLayer.Services;

namespace OfferArticleWebApi.Controllers
{
    [ApiController]
    [Route("/api/offers")]
    public class OffersController : ControllerBase
    {
        private readonly ILogger<OffersController> _logger;
        private readonly IOfferService _offerService;
        private readonly IMapper _mapper;

        public OffersController(ILogger<OffersController> logger, IOfferService storeItemService, IMapper mapper)
        {
            _logger = logger;
            _offerService = storeItemService;
            _mapper = mapper;
        }


        [HttpGet()]
        [ProducesResponseType(200, Type = typeof(IEnumerable<OfferIdDto>))]
        [ProducesResponseType(400)]
        public IActionResult GetOffers([FromQuery] OfferQueryParams offerParameters)
        {
            try
            {
                var offers = _mapper.Map<List<OfferIdDto>>(_offerService.GetOffers(offerParameters.Page, offerParameters.PageSize));

                if (!ModelState.IsValid)
                {
                    return BadRequest("Not a valid model");
                }

                return Ok(offers);
            }
            catch (Exception)
            {
                // Log the exception or handle it appropriately
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(OfferIdDto))]
        [ProducesResponseType(400)]
        public IActionResult GetOffer(int id)
        {
            try
            {
                var offerModel = _offerService.GetSpecificOffer(id);

                if (offerModel == null)
                {
                    return NotFound();
                }

                var offer = _mapper.Map<OfferIdDto>(offerModel);

                if (!ModelState.IsValid)
                {
                    return BadRequest("Not a valid model");
                }

                return Ok(offer);
            }
            catch (Exception)
            {
                // Log the exception or handle it appropriately
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost()]
        [ProducesResponseType(200, Type = typeof(OfferIdDto))]
        [ProducesResponseType(400)]
        [ProducesResponseType(422)]
        public IActionResult CreateOffer([FromBody] OfferDto offer)
        {
            try
            {
                if (offer == null)
                {
                    return BadRequest();
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest("Not a valid model");
                }

                var offerModel = _mapper.Map<Offer>(offer);

                var response = _offerService.CreateOffer(offerModel);

                if (!response.RecordExists)
                {
                    return NotFound();
                }

                var responseModel = _mapper.Map<OfferIdDto>(response.Entity);

                return Ok(responseModel);
            }
            catch (Exception)
            {
                // Log the exception or handle it appropriately
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult UpdateStoreItem([FromRoute] int id, [FromBody] OfferDto updateOfferModel)
        {
            try
            {
                if (updateOfferModel == null)
                {
                    return BadRequest();
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest("Not a valid model");
                }

                var offerDbModel = _mapper.Map<Offer>(updateOfferModel);

                var response = _offerService.UpdateOffer(id, offerDbModel);

                if (!response.RecordExists)
                {
                    return NotFound();
                }

                return NoContent();
            }
            catch (Exception)
            {
                // Log the exception or handle it appropriately
                return StatusCode(500, "Internal server error");
            }
        }

        //[HttpDelete("{id}")]
        //[ProducesResponseType(200)]
        //[ProducesResponseType(400)]
        //[ProducesResponseType(404)]
        //public IActionResult DeleteStoreItem([FromRoute] int id)
        //{
        //    try
        //    {
        //        var response = _offerService.DeleteSuplier(id);

        //        if (!response.RecordExists)
        //        {
        //            return NotFound();
        //        }

        //        return NoContent();
        //    }
        //    catch (Exception)
        //    {
        //        // Log the exception or handle it appropriately
        //        return StatusCode(500, "Internal server error");
        //    }
        //}
    }
}
