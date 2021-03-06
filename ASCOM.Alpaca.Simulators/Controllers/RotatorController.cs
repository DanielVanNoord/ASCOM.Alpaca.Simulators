﻿using Alpaca;
using ASCOM.Alpaca.Responses;
using ASCOM.Standard.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ASCOM.Alpaca.Simulators
{
    [ServiceFilter(typeof(AuthorizationFilter))]
    [ApiController]
    [Route("api/v1/rotator/")]
    public class RotatorController : AlpacaController
    {
        [NonAction]
        public override IAscomDevice GetDevice(int DeviceNumber)
        {
            return DeviceManager.GetRotator(DeviceNumber);
        }

        [HttpGet]
        [Route("{DeviceNumber}/canreverse")]
        public ActionResult<BoolResponse> CanReverse([DefaultValue(0)] int DeviceNumber, uint ClientID = 0, uint ClientTransactionID = 0)
        {
            return ProcessRequest(() => DeviceManager.GetRotator(DeviceNumber).CanReverse, DeviceManager.ServerTransactionID, ClientID, ClientTransactionID);
        }

        [HttpGet]
        [Route("{DeviceNumber}/ismoving")]
        public ActionResult<BoolResponse> IsMoving([DefaultValue(0)] int DeviceNumber, uint ClientID = 0, uint ClientTransactionID = 0)
        {
            return ProcessRequest(() => DeviceManager.GetRotator(DeviceNumber).IsMoving, DeviceManager.ServerTransactionID, ClientID, ClientTransactionID);
        }

        [HttpGet]
        [Route("{DeviceNumber}/position")]
        public ActionResult<DoubleResponse> Position([DefaultValue(0)] int DeviceNumber, uint ClientID = 0, uint ClientTransactionID = 0)
        {
            return ProcessRequest(() => DeviceManager.GetRotator(DeviceNumber).Position, DeviceManager.ServerTransactionID, ClientID, ClientTransactionID);
        }

        [HttpGet]
        [Route("{DeviceNumber}/mechanicalposition")]
        public ActionResult<DoubleResponse> MechanicalPosition([DefaultValue(0)] int DeviceNumber, uint ClientID = 0, uint ClientTransactionID = 0)
        {
            return ProcessRequest(() => DeviceManager.GetRotator(DeviceNumber).MechanicalPosition, DeviceManager.ServerTransactionID, ClientID, ClientTransactionID);
        }

        [HttpGet]
        [Route("{DeviceNumber}/reverse")]
        public ActionResult<BoolResponse> Reverse([DefaultValue(0)] int DeviceNumber, uint ClientID = 0, uint ClientTransactionID = 0)
        {
            return ProcessRequest(() => DeviceManager.GetRotator(DeviceNumber).Reverse, DeviceManager.ServerTransactionID, ClientID, ClientTransactionID);
        }

        [HttpPut]
        [Route("{DeviceNumber}/reverse")]
        public ActionResult<Response> Reverse([DefaultValue(0)] int DeviceNumber, [Required][FromForm] bool Reverse, [FromForm] uint ClientID = 0, [FromForm] uint ClientTransactionID = 0)
        {
            return ProcessRequest(() => { DeviceManager.GetRotator(DeviceNumber).Reverse = Reverse; }, DeviceManager.ServerTransactionID, ClientID, ClientTransactionID);
        }

        [HttpGet]
        [Route("{DeviceNumber}/stepsize")]
        public ActionResult<DoubleResponse> StepSize([DefaultValue(0)] int DeviceNumber, uint ClientID = 0, uint ClientTransactionID = 0)
        {
            return ProcessRequest(() => DeviceManager.GetRotator(DeviceNumber).StepSize, DeviceManager.ServerTransactionID, ClientID, ClientTransactionID);
        }

        [HttpGet]
        [Route("{DeviceNumber}/targetposition")]
        public ActionResult<DoubleResponse> TargetPosition([DefaultValue(0)] int DeviceNumber, uint ClientID = 0, uint ClientTransactionID = 0)
        {
            return ProcessRequest(() => DeviceManager.GetRotator(DeviceNumber).TargetPosition, DeviceManager.ServerTransactionID, ClientID, ClientTransactionID);
        }

        [HttpPut]
        [Route("{DeviceNumber}/halt")]
        public ActionResult<Response> Halt([DefaultValue(0)] int DeviceNumber, [FromForm] uint ClientID = 0, [FromForm] uint ClientTransactionID = 0)
        {
            return ProcessRequest(() => DeviceManager.GetRotator(DeviceNumber).Halt(), DeviceManager.ServerTransactionID, ClientID, ClientTransactionID);
        }

        [HttpPut]
        [Route("{DeviceNumber}/move")]
        public ActionResult<Response> Move([DefaultValue(0)] int DeviceNumber, [Required][DefaultValue(0)][FromForm] double Position, [FromForm] uint ClientID = 0, [FromForm] uint ClientTransactionID = 0)
        {
            return ProcessRequest(() => DeviceManager.GetRotator(DeviceNumber).Move((float)Position), DeviceManager.ServerTransactionID, ClientID, ClientTransactionID);
        }

        [HttpPut]
        [Route("{DeviceNumber}/moveabsolute")]
        public ActionResult<Response> MoveAbsolute([DefaultValue(0)] int DeviceNumber, [Required][DefaultValue(0)][FromForm] double Position, [FromForm] uint ClientID = 0, [FromForm] uint ClientTransactionID = 0)
        {
            return ProcessRequest(() => DeviceManager.GetRotator(DeviceNumber).MoveAbsolute((float)Position), DeviceManager.ServerTransactionID, ClientID, ClientTransactionID);
        }

        [HttpPut]
        [Route("{DeviceNumber}/movemechanical")]
        public ActionResult<Response> MoveMechanical([DefaultValue(0)] int DeviceNumber, [Required][DefaultValue(0)][FromForm] double Position, [FromForm] uint ClientID = 0, [FromForm] uint ClientTransactionID = 0)
        {
            return ProcessRequest(() => DeviceManager.GetRotator(DeviceNumber).MoveMechanical((float)Position), DeviceManager.ServerTransactionID, ClientID, ClientTransactionID);
        }

        [HttpPut]
        [Route("{DeviceNumber}/sync")]
        public ActionResult<Response> Sync([DefaultValue(0)] int DeviceNumber, [Required][DefaultValue(0)][FromForm] double Position, [FromForm] uint ClientID = 0, [FromForm] uint ClientTransactionID = 0)
        {
            return ProcessRequest(() => DeviceManager.GetRotator(DeviceNumber).Sync((float)Position), DeviceManager.ServerTransactionID, ClientID, ClientTransactionID);
        }
    }
}