using API_Investidor.NotificationHubs;
using API_Investidor.Options;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.NotificationHubs;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Investidor.Controllers
{
    [ApiController]
    public class PushNotificationsController : RootController
    {
        private NotificationHubProxy _notificationHubProxy;

        public PushNotificationsController(IOptions<NotificationHubOptions> standardNotificationHubConfiguration)
        {
            _notificationHubProxy = new NotificationHubProxy(standardNotificationHubConfiguration.Value);
        }

        /// 
        /// <summary>
        /// Get registration ID
        /// </summary>
        /// <returns></returns>
        [HttpGet("register")]
        public async Task<IActionResult> CreatePushRegistrationId()
        {
            var registrationId = await _notificationHubProxy.CreateRegistrationId();
            return Ok(registrationId);
        }

        /// 
        /// <summary>
        /// Delete registration ID and unregister from receiving push notifications
        /// </summary>
        /// <param name="registrationId"></param>
        /// <returns></returns>
        [HttpDelete("unregister/{registrationId}")]
        public async Task<IActionResult> UnregisterFromNotifications(string registrationId)
        {
            await _notificationHubProxy.DeleteRegistration(registrationId);
            return Ok();
        }

        /// 
        /// <summary>
        /// Register to receive push notifications
        /// </summary>
        /// <param name="id"></param>
        /// <param name="deviceUpdate"></param>
        /// <returns></returns>
        [HttpPut("enable/{id}")]
        public async Task<IActionResult> RegisterForPushNotifications(string id, [FromBody] DeviceRegistration deviceUpdate)
        {
            HubResponse registrationResult = await _notificationHubProxy.RegisterForPushNotifications(id, deviceUpdate);

            if (registrationResult.CompletedWithSuccess)
                return Ok();

            return BadRequest("An error occurred while sending push notification: " + registrationResult.FormattedErrorMessages);
        }

        /// 
        /// <summary>
        /// Send push notification
        /// </summary>
        /// <param name="newNotification"></param>
        /// <returns></returns>
        [HttpPost("send")]
        public async Task<IActionResult> SendNotification([FromBody] NotificationHubs.Notification newNotification)
        {
            HubResponse<NotificationOutcome> pushDeliveryResult = await _notificationHubProxy.SendNotification(newNotification);

            if (pushDeliveryResult.CompletedWithSuccess)
                return Ok();

            return BadRequest("An error occurred while sending push notification: " + pushDeliveryResult.FormattedErrorMessages);
        }
    }
}
