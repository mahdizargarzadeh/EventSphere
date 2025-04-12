using System;
using Newtonsoft.Json;

namespace Mqeb.Application.DTOs.GoogleRecaptcha
{
    public class RecaptchaResponse
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("challenge_ts")]
        public DateTimeOffset ChallengeTs { get; set; }

        [JsonProperty("hostname")]
        public string HostName { get; set; }
    }
}