using Alpaca;
using ASCOM.Alpaca.Responses;
using System;
using System.Collections.Generic;

namespace ASCOM.Alpaca.Simulators
{
    internal static class DeviceManager
    {
        internal static uint RawTransactionID
        {
            get;
            set;
        } = 0;

        /// <summary>
        /// A server wide Transaction ID Counter
        /// </summary>
        internal static uint ServerTransactionID
        {
            get
            {
                return RawTransactionID++;
            }
        }

        // These store the actual instance of the device drivers. They are keyed to the Device Number
        private readonly static Dictionary<int, ASCOM.Standard.Interfaces.ICameraV3> cameraV3s = new Dictionary<int, ASCOM.Standard.Interfaces.ICameraV3>();
        private readonly static Dictionary<int, ASCOM.Standard.Interfaces.ICoverCalibratorV1> coverCalibratorV1s = new Dictionary<int, ASCOM.Standard.Interfaces.ICoverCalibratorV1>();
        private readonly static Dictionary<int, ASCOM.Standard.Interfaces.IDomeV2> domeV2s = new Dictionary<int, ASCOM.Standard.Interfaces.IDomeV2>();
        private readonly static Dictionary<int, ASCOM.Standard.Interfaces.IFilterWheelV2> filterWheelV2s = new Dictionary<int, ASCOM.Standard.Interfaces.IFilterWheelV2>();
        private readonly static Dictionary<int, ASCOM.Standard.Interfaces.IFocuserV3> focuserV3s = new Dictionary<int, ASCOM.Standard.Interfaces.IFocuserV3>();
        private readonly static Dictionary<int, ASCOM.Standard.Interfaces.IObservingConditions> observingConditions = new Dictionary<int, ASCOM.Standard.Interfaces.IObservingConditions>();
        private readonly static Dictionary<int, ASCOM.Standard.Interfaces.IRotatorV3> rotatorV3s = new Dictionary<int, ASCOM.Standard.Interfaces.IRotatorV3>();
        private readonly static Dictionary<int, ASCOM.Standard.Interfaces.ISafetyMonitor> safetyMonitors = new Dictionary<int, ASCOM.Standard.Interfaces.ISafetyMonitor>();
        private readonly static Dictionary<int, ASCOM.Standard.Interfaces.ISwitchV2> switchV2s = new Dictionary<int, ASCOM.Standard.Interfaces.ISwitchV2>();
        private readonly static Dictionary<int, ASCOM.Standard.Interfaces.ITelescopeV3> telescopeV3s = new Dictionary<int, ASCOM.Standard.Interfaces.ITelescopeV3>();

        static DeviceManager()
        {
            //Only one instance of each in this simulator
            coverCalibratorV1s.Add(0, new ASCOM.Simulators.CoverCalibratorSimulator(0, Logging.Log,
                new ASCOM.Standard.Utilities.XMLProfile(ServerSettings.ServerFileName, "CoverCalibrator", 0)));

            domeV2s.Add(0, new ASCOM.Simulators.Dome(0, Logging.Log,
                new ASCOM.Standard.Utilities.XMLProfile(ServerSettings.ServerFileName, "Dome", 0)));

            filterWheelV2s.Add(0, new ASCOM.Simulators.FilterWheel(0, Logging.Log,
                new ASCOM.Standard.Utilities.XMLProfile(ServerSettings.ServerFileName, "FilterWheel", 0)));

            focuserV3s.Add(0, new ASCOM.Simulators.Focuser(0, Logging.Log,
                new ASCOM.Standard.Utilities.XMLProfile(ServerSettings.ServerFileName, "Focuser", 0)));

            observingConditions.Add(0, new ASCOM.Simulators.ObservingConditions(0, Logging.Log,
                new ASCOM.Standard.Utilities.XMLProfile(ServerSettings.ServerFileName, "ObservingConditions", 0)));

            rotatorV3s.Add(0, new ASCOM.Simulators.Rotator(0, Logging.Log,
                new ASCOM.Standard.Utilities.XMLProfile(ServerSettings.ServerFileName, "Rotator", 0)));

            safetyMonitors.Add(0, new ASCOM.Simulators.SafetyMonitor(0, Logging.Log,
                new ASCOM.Standard.Utilities.XMLProfile(ServerSettings.ServerFileName, "SafetyMonitor", 0)));

            switchV2s.Add(0, new ASCOM.Simulators.Switch(0, Logging.Log,
                new ASCOM.Standard.Utilities.XMLProfile(ServerSettings.ServerFileName, "Switch", 0)));

            telescopeV3s.Add(0, new ASCOM.Simulators.Telescope(0, Logging.Log,
                new ASCOM.Standard.Utilities.XMLProfile(ServerSettings.ServerFileName, "Telescope", 0)));

            cameraV3s.Add(0, new ASCOM.Simulators.Camera(0, Logging.Log,
                new ASCOM.Standard.Utilities.XMLProfile(ServerSettings.ServerFileName, "Camera", 0)));
        }

        /// <summary>
        /// Reset all device settings profiles.
        /// </summary>
        internal static void Reset()
        {
            foreach (var dev in cameraV3s.Values)
            {
                try
                {
                    (dev as ASCOM.Simulators.Camera)?.ClearProfile();
                }
                catch (Exception ex)
                {
                    Logging.LogError($"Failed to reset Camera settings with error: {ex.Message}");
                }
            }

            foreach (var dev in coverCalibratorV1s.Values)
            {
                try
                {
                    (dev as ASCOM.Simulators.CoverCalibratorSimulator)?.ResetSettings();
                }
                catch (Exception ex)
                {
                    Logging.LogError($"Failed to reset CoverCalibrator settings with error: {ex.Message}");
                }
            }

            foreach (var dev in domeV2s.Values)
            {
                try
                {
                    (dev as ASCOM.Simulators.Dome)?.ResetConfig();
                }
                catch (Exception ex)
                {
                    Logging.LogError($"Failed to reset Dome settings with error: {ex.Message}");
                }
            }

            try
            {
                ASCOM.Simulators.FilterWheelHardware.ResetProfile();
            }
            catch (Exception ex)
            {
                Logging.LogError($"Failed to reset Filter Wheel settings with error: {ex.Message}");
            }

            foreach (var dev in focuserV3s.Values)
            {
                try
                {
                    (dev as ASCOM.Simulators.Focuser)?.Reset();
                }
                catch (Exception ex)
                {
                    Logging.LogError($"Failed to reset Focuser settings with error: {ex.Message}");
                }
            }

            try
            {
                ASCOM.Simulators.OCSimulator.ClearProfile();
            }
            catch (Exception ex)
            {
                Logging.LogError($"Failed to reset Observing Conditions settings with error: {ex.Message}");
            }

            try
            {
                ASCOM.Simulators.RotatorHardware.ResetProfile();
            }
            catch (Exception ex)
            {
                Logging.LogError($"Failed to reset Rotator settings with error: {ex.Message}");
            }

            foreach (var dev in safetyMonitors.Values)
            {
                try
                {
                    (dev as ASCOM.Simulators.SafetyMonitor)?.ResetProfile();
                }
                catch (Exception ex)
                {
                    Logging.LogError($"Failed to reset SafetyMonitor settings with error: {ex.Message}");
                }
            }

            foreach (var dev in switchV2s.Values)
            {
                try
                {
                    (dev as ASCOM.Simulators.Switch)?.ResetProfile();
                }
                catch (Exception ex)
                {
                    Logging.LogError($"Failed to reset Switch settings with error: {ex.Message}");
                }
            }

            try
            {
                ASCOM.Simulators.TelescopeHardware.ClearProfile();
            }
            catch(Exception ex)
            {
                Logging.LogError($"Failed to reset Telescope settings with error: {ex.Message}");
            }
        }

        //Returns a list of every single device type for the Management API
        internal static List<AlpacaConfiguredDevice> GetDevices()
        {
            List<AlpacaConfiguredDevice> devices = new List<AlpacaConfiguredDevice>();

            foreach (var dev in cameraV3s)
            {
                devices.Add((dev.Value as Standard.Interfaces.IAlpacaDevice).Configuration);
            }

            foreach (var dev in coverCalibratorV1s)
            {
                devices.Add((dev.Value as Standard.Interfaces.IAlpacaDevice).Configuration);
            }

            foreach (var dev in domeV2s)
            {
                devices.Add((dev.Value as Standard.Interfaces.IAlpacaDevice).Configuration);
            }

            foreach (var dev in filterWheelV2s)
            {
                devices.Add((dev.Value as Standard.Interfaces.IAlpacaDevice).Configuration);
            }

            foreach (var dev in focuserV3s)
            {
                devices.Add((dev.Value as Standard.Interfaces.IAlpacaDevice).Configuration);
            }

            foreach (var dev in observingConditions)
            {
                devices.Add((dev.Value as Standard.Interfaces.IAlpacaDevice).Configuration);
            }

            foreach (var dev in rotatorV3s)
            {
                devices.Add((dev.Value as Standard.Interfaces.IAlpacaDevice).Configuration);
            }

            foreach (var dev in safetyMonitors)
            {
                devices.Add((dev.Value as Standard.Interfaces.IAlpacaDevice).Configuration);
            }

            foreach (var dev in switchV2s)
            {
                devices.Add((dev.Value as Standard.Interfaces.IAlpacaDevice).Configuration);
            }

            foreach (var dev in telescopeV3s)
            {
                devices.Add((dev.Value as Standard.Interfaces.IAlpacaDevice).Configuration);
            }

            return devices;
        }

        //These methods allow access to specific devices for the API controllers and the device Blazor UI Pages

        internal static ASCOM.Standard.Interfaces.ICameraV3 GetCamera(int DeviceID)
        {
            if (cameraV3s.ContainsKey(DeviceID))
            {
                return cameraV3s[DeviceID];
            }
            else
            {
                throw new DeviceNotFoundException(string.Format("Instance {0} does not exist in this server.", DeviceID));
            }
        }

        internal static ASCOM.Standard.Interfaces.ICoverCalibratorV1 GetCoverCalibrator(int DeviceID)
        {
            if (coverCalibratorV1s.ContainsKey(DeviceID))
            {
                return coverCalibratorV1s[DeviceID];
            }
            else
            {
                throw new DeviceNotFoundException(string.Format("Instance {0} does not exist in this server.", DeviceID));
            }
        }

        internal static ASCOM.Standard.Interfaces.IDomeV2 GetDome(int DeviceID)
        {
            if (domeV2s.ContainsKey(DeviceID))
            {
                return domeV2s[DeviceID];
            }
            else
            {
                throw new DeviceNotFoundException(string.Format("Instance {0} does not exist in this server.", DeviceID));
            }
        }

        internal static ASCOM.Standard.Interfaces.IFilterWheelV2 GetFilterWheel(int DeviceID)
        {
            if (filterWheelV2s.ContainsKey(DeviceID))
            {
                return filterWheelV2s[DeviceID];
            }
            else
            {
                throw new DeviceNotFoundException(string.Format("Instance {0} does not exist in this server.", DeviceID));
            }
        }

        internal static ASCOM.Standard.Interfaces.IFocuserV3 GetFocuser(int DeviceID)
        {
            if (focuserV3s.ContainsKey(DeviceID))
            {
                return focuserV3s[DeviceID];
            }
            else
            {
                throw new DeviceNotFoundException(string.Format("Instance {0} does not exist in this server.", DeviceID));
            }
        }

        internal static ASCOM.Standard.Interfaces.IObservingConditions GetObservingConditions(int DeviceID)
        {
            if (observingConditions.ContainsKey(DeviceID))
            {
                return observingConditions[DeviceID];
            }
            else
            {
                throw new DeviceNotFoundException(string.Format("Instance {0} does not exist in this server.", DeviceID));
            }
        }

        internal static ASCOM.Standard.Interfaces.IRotatorV3 GetRotator(int DeviceID)
        {
            if (rotatorV3s.ContainsKey(DeviceID))
            {
                return rotatorV3s[DeviceID];
            }
            else
            {
                throw new DeviceNotFoundException(string.Format("Instance {0} does not exist in this server.", DeviceID));
            }
        }

        internal static ASCOM.Standard.Interfaces.ISafetyMonitor GetSafetyMonitor(int DeviceID)
        {
            if (safetyMonitors.ContainsKey(DeviceID))
            {
                return safetyMonitors[DeviceID];
            }
            else
            {
                throw new DeviceNotFoundException(string.Format("Instance {0} does not exist in this server.", DeviceID));
            }
        }

        internal static ASCOM.Standard.Interfaces.ISwitchV2 GetSwitch(int DeviceID)
        {
            if (switchV2s.ContainsKey(DeviceID))
            {
                return switchV2s[DeviceID];
            }
            else
            {
                throw new DeviceNotFoundException(string.Format("Instance {0} does not exist in this server.", DeviceID));
            }
        }

        internal static ASCOM.Standard.Interfaces.ITelescopeV3 GetTelescope(int DeviceID)
        {
            if (telescopeV3s.ContainsKey(DeviceID))
            {
                return telescopeV3s[DeviceID];
            }
            else
            {
                throw new DeviceNotFoundException(string.Format("Instance {0} does not exist in this server.", DeviceID));
            }
        }
    }
}