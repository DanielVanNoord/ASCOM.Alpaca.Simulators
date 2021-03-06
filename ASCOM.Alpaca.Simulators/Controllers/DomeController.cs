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
    [Route("api/v1/dome/")]
    public class DomeController : AlpacaController
    {
        [NonAction]
        public override IAscomDevice GetDevice(int DeviceNumber)
        {
            return DeviceManager.GetDome(DeviceNumber);
        }

        [HttpGet]
        [Route("{DeviceNumber}/altitude")]
        public ActionResult<DoubleResponse> Altitude([DefaultValue(0)] int DeviceNumber, uint ClientID = 0, uint ClientTransactionID = 0)
        {
            return ProcessRequest(() => DeviceManager.GetDome(DeviceNumber).Altitude, DeviceManager.ServerTransactionID, ClientID, ClientTransactionID);
        }

        [HttpGet]
        [Route("{DeviceNumber}/athome")]
        public ActionResult<BoolResponse> AtHome([DefaultValue(0)] int DeviceNumber, uint ClientID = 0, uint ClientTransactionID = 0)
        {
            return ProcessRequest(() => DeviceManager.GetDome(DeviceNumber).AtHome, DeviceManager.ServerTransactionID, ClientID, ClientTransactionID);
        }

        [HttpGet]
        [Route("{DeviceNumber}/atpark")]
        public ActionResult<BoolResponse> AtPark([DefaultValue(0)] int DeviceNumber, uint ClientID = 0, uint ClientTransactionID = 0)
        {
            return ProcessRequest(() => DeviceManager.GetDome(DeviceNumber).AtPark, DeviceManager.ServerTransactionID, ClientID, ClientTransactionID);
        }

        [HttpGet]
        [Route("{DeviceNumber}/azimuth")]
        public ActionResult<DoubleResponse> Azimuth([DefaultValue(0)] int DeviceNumber, uint ClientID = 0, uint ClientTransactionID = 0)
        {
            return ProcessRequest(() => DeviceManager.GetDome(DeviceNumber).Azimuth, DeviceManager.ServerTransactionID, ClientID, ClientTransactionID);
        }

        [HttpGet]
        [Route("{DeviceNumber}/canfindhome")]
        public ActionResult<BoolResponse> CanFindHome([DefaultValue(0)] int DeviceNumber, uint ClientID = 0, uint ClientTransactionID = 0)
        {
            return ProcessRequest(() => DeviceManager.GetDome(DeviceNumber).CanFindHome, DeviceManager.ServerTransactionID, ClientID, ClientTransactionID);
        }

        [HttpGet]
        [Route("{DeviceNumber}/canpark")]
        public ActionResult<BoolResponse> CanPark([DefaultValue(0)] int DeviceNumber, uint ClientID = 0, uint ClientTransactionID = 0)
        {
            return ProcessRequest(() => DeviceManager.GetDome(DeviceNumber).CanPark, DeviceManager.ServerTransactionID, ClientID, ClientTransactionID);
        }

        [HttpGet]
        [Route("{DeviceNumber}/cansetaltitude")]
        public ActionResult<BoolResponse> CanSetAltitude([DefaultValue(0)] int DeviceNumber, uint ClientID = 0, uint ClientTransactionID = 0)
        {
            return ProcessRequest(() => DeviceManager.GetDome(DeviceNumber).CanSetAltitude, DeviceManager.ServerTransactionID, ClientID, ClientTransactionID);
        }

        [HttpGet]
        [Route("{DeviceNumber}/cansetazimuth")]
        public ActionResult<BoolResponse> CanSetAzimuth([DefaultValue(0)] int DeviceNumber, uint ClientID = 0, uint ClientTransactionID = 0)
        {
            return ProcessRequest(() => DeviceManager.GetDome(DeviceNumber).CanSetAzimuth, DeviceManager.ServerTransactionID, ClientID, ClientTransactionID);
        }

        [HttpGet]
        [Route("{DeviceNumber}/cansetpark")]
        public ActionResult<BoolResponse> CanSetPark([DefaultValue(0)] int DeviceNumber, uint ClientID = 0, uint ClientTransactionID = 0)
        {
            return ProcessRequest(() => DeviceManager.GetDome(DeviceNumber).CanSetPark, DeviceManager.ServerTransactionID, ClientID, ClientTransactionID);
        }

        [HttpGet]
        [Route("{DeviceNumber}/cansetshutter")]
        public ActionResult<BoolResponse> CanSetShutter([DefaultValue(0)] int DeviceNumber, uint ClientID = 0, uint ClientTransactionID = 0)
        {
            return ProcessRequest(() => DeviceManager.GetDome(DeviceNumber).CanSetShutter, DeviceManager.ServerTransactionID, ClientID, ClientTransactionID);
        }

        [HttpGet]
        [Route("{DeviceNumber}/canslave")]
        public ActionResult<BoolResponse> CanSlave([DefaultValue(0)] int DeviceNumber, uint ClientID = 0, uint ClientTransactionID = 0)
        {
            return ProcessRequest(() => DeviceManager.GetDome(DeviceNumber).CanSlave, DeviceManager.ServerTransactionID, ClientID, ClientTransactionID);
        }

        [HttpGet]
        [Route("{DeviceNumber}/cansyncazimuth")]
        public ActionResult<BoolResponse> CanSyncAzimuth([DefaultValue(0)] int DeviceNumber, uint ClientID = 0, uint ClientTransactionID = 0)
        {
            return ProcessRequest(() => DeviceManager.GetDome(DeviceNumber).CanSyncAzimuth, DeviceManager.ServerTransactionID, ClientID, ClientTransactionID);
        }

        [HttpGet]
        [Route("{DeviceNumber}/shutterstatus")]
        public ActionResult<IntResponse> ShutterStatus([DefaultValue(0)] int DeviceNumber, uint ClientID = 0, uint ClientTransactionID = 0)
        {
            return ProcessRequest(() => (int)DeviceManager.GetDome(DeviceNumber).ShutterStatus, DeviceManager.ServerTransactionID, ClientID, ClientTransactionID);
        }

        [HttpGet]
        [Route("{DeviceNumber}/slaved")]
        public ActionResult<BoolResponse> Slaved([DefaultValue(0)] int DeviceNumber, uint ClientID = 0, uint ClientTransactionID = 0)
        {
            return ProcessRequest(() => DeviceManager.GetDome(DeviceNumber).Slaved, DeviceManager.ServerTransactionID, ClientID, ClientTransactionID);
        }

        [HttpPut]
        [Route("{DeviceNumber}/slaved")]
        public ActionResult<Response> Slaved([DefaultValue(0)] int DeviceNumber, [FromForm] bool Slaved, [FromForm] uint ClientID = 0, [FromForm] uint ClientTransactionID = 0)
        {
            return ProcessRequest(() => { DeviceManager.GetDome(DeviceNumber).Slaved = Slaved; }, DeviceManager.ServerTransactionID, ClientID, ClientTransactionID);
        }

        [HttpGet]
        [Route("{DeviceNumber}/slewing")]
        public ActionResult<BoolResponse> Slewing([DefaultValue(0)] int DeviceNumber, uint ClientID = 0, uint ClientTransactionID = 0)
        {
            return ProcessRequest(() => DeviceManager.GetDome(DeviceNumber).Slewing, DeviceManager.ServerTransactionID, ClientID, ClientTransactionID);
        }

        [HttpPut]
        [Route("{DeviceNumber}/abortslew")]
        public ActionResult<Response> AbortSlew([DefaultValue(0)] int DeviceNumber, [FromForm] uint ClientID = 0, [FromForm] uint ClientTransactionID = 0)
        {
            return ProcessRequest(() => DeviceManager.GetDome(DeviceNumber).AbortSlew(), DeviceManager.ServerTransactionID, ClientID, ClientTransactionID);
        }

        [HttpPut]
        [Route("{DeviceNumber}/closeshutter")]
        public ActionResult<Response> CloseShutter([DefaultValue(0)] int DeviceNumber, [FromForm] uint ClientID = 0, [FromForm] uint ClientTransactionID = 0)
        {
            return ProcessRequest(() => DeviceManager.GetDome(DeviceNumber).CloseShutter(), DeviceManager.ServerTransactionID, ClientID, ClientTransactionID);
        }

        [HttpPut]
        [Route("{DeviceNumber}/findhome")]
        public ActionResult<Response> FindHome([DefaultValue(0)] int DeviceNumber, [FromForm] uint ClientID = 0, [FromForm] uint ClientTransactionID = 0)
        {
            return ProcessRequest(() => DeviceManager.GetDome(DeviceNumber).FindHome(), DeviceManager.ServerTransactionID, ClientID, ClientTransactionID);
        }

        [HttpPut]
        [Route("{DeviceNumber}/openshutter")]
        public ActionResult<Response> OpenShutter([DefaultValue(0)] int DeviceNumber, [FromForm] uint ClientID = 0, [FromForm] uint ClientTransactionID = 0)
        {
            return ProcessRequest(() => DeviceManager.GetDome(DeviceNumber).OpenShutter(), DeviceManager.ServerTransactionID, ClientID, ClientTransactionID);
        }

        [HttpPut]
        [Route("{DeviceNumber}/park")]
        public ActionResult<Response> Park([DefaultValue(0)] int DeviceNumber, [FromForm] uint ClientID = 0, [FromForm] uint ClientTransactionID = 0)
        {
            return ProcessRequest(() => DeviceManager.GetDome(DeviceNumber).Park(), DeviceManager.ServerTransactionID, ClientID, ClientTransactionID);
        }

        [HttpPut]
        [Route("{DeviceNumber}/setpark")]
        public ActionResult<Response> SetPark([DefaultValue(0)] int DeviceNumber, [FromForm] uint ClientID = 0, [FromForm] uint ClientTransactionID = 0)
        {
            return ProcessRequest(() => DeviceManager.GetDome(DeviceNumber).SetPark(), DeviceManager.ServerTransactionID, ClientID, ClientTransactionID);
        }

        [HttpPut]
        [Route("{DeviceNumber}/slewtoaltitude")]
        public ActionResult<Response> SlewToAltitude([DefaultValue(0)] int DeviceNumber, [FromForm] double Altitude, [FromForm] uint ClientID = 0, [FromForm] uint ClientTransactionID = 0)
        {
            return ProcessRequest(() => DeviceManager.GetDome(DeviceNumber).SlewToAltitude(Altitude), DeviceManager.ServerTransactionID, ClientID, ClientTransactionID);
        }

        [HttpPut]
        [Route("{DeviceNumber}/slewtoazimuth")]
        public ActionResult<Response> SlewToAzimuth([DefaultValue(0)] int DeviceNumber, [FromForm] double Azimuth, [FromForm] uint ClientID = 0, [FromForm] uint ClientTransactionID = 0)
        {
            return ProcessRequest(() => DeviceManager.GetDome(DeviceNumber).SlewToAzimuth(Azimuth), DeviceManager.ServerTransactionID, ClientID, ClientTransactionID);
        }

        [HttpPut]
        [Route("{DeviceNumber}/synctoazimuth")]
        public ActionResult<Response> SyncToAzimuth([DefaultValue(0)] int DeviceNumber, [FromForm] double Azimuth, [FromForm] uint ClientID = 0, [FromForm] uint ClientTransactionID = 0)
        {
            return ProcessRequest(() => DeviceManager.GetDome(DeviceNumber).SyncToAzimuth(Azimuth), DeviceManager.ServerTransactionID, ClientID, ClientTransactionID);
        }
    }
}