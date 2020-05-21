﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Gyms.DomainObjects;
using Gyms.ApplicationServices.GetGymPointListUseCase;
using Gyms.InfrastructureServices.Presenters;

namespace Gyms.InfrastructureServices.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GymPointController : ControllerBase
    {
        private readonly ILogger<GymPointController> _logger;
        private readonly IGetGymPointListUseCase _getGymPointListUseCase;

        public GymPointController(ILogger<GymPointController> logger,
                                IGetGymPointListUseCase getGymPointListUseCase)
        {
            _logger = logger;
            _getGymPointListUseCase = getGymPointListUseCase;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllGyms()
        {
            var presenter = new GymPointListPresenter();
            await _getGymPointListUseCase.Handle(GetGymPointListUseCaseRequest.CreateAllGymPointsRequest(), presenter);
            return presenter.ContentResult;
        }

        [HttpGet("{gympointId}")]
        public async Task<ActionResult> GetGymPoint(long gympointId)
        {
            var presenter = new GymPointListPresenter();
            await _getGymPointListUseCase.Handle(GetGymPointListUseCaseRequest.CreateGymPointRequest(gympointId), presenter);
            return presenter.ContentResult;
        }

        [HttpGet("{district}")]
        public async Task<ActionResult> GetDistrictGymPoints(string district)
        {
            var presenter = new GymPointListPresenter();
            await _getGymPointListUseCase.Handle(GetGymPointListUseCaseRequest.CreateDistrictGymPointsRequest(district), presenter);
            return presenter.ContentResult;
        }
    }
}
