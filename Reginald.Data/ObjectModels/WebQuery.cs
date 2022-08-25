﻿namespace Reginald.Data.ObjectModels
{
    using System;
    using Newtonsoft.Json;
    using Reginald.Core.Extensions;
    using Reginald.Data.Inputs;
    using Reginald.Data.Producers;
    using Reginald.Data.Products;
    using Reginald.Services.Utilities;

    public class WebQuery : ObjectModel, ISingleProducer<SearchResult>
    {
        private string _keyInput;

        [JsonProperty("altUrl")]
        public string AltUrl { get; set; }

        [JsonProperty("altDescription")]
        public string AltDescription { get; set; }

        [JsonProperty("descriptionFormat")]
        public string DescriptionFormat { get; set; }

        [JsonProperty("isEnabled")]
        public bool IsEnabled { get; set; }

        [JsonProperty("encodeInput")]
        public bool EncodeInput { get; set; }

        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("placeholder")]
        public string Placeholder { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("urlFormat")]
        public string UrlFormat { get; set; }

        public bool Check(string keyInput)
        {
            if (!IsEnabled)
            {
                return false;
            }

            _keyInput = keyInput;
            if (!string.IsNullOrEmpty(Description))
            {
                if (_keyInput.Length < Key.Length)
                {
                    return Key.StartsWith(_keyInput, StringComparison.OrdinalIgnoreCase);
                }

                return _keyInput == Key;
            }

            if (_keyInput.Length <= Key.Length)
            {
                return Key.StartsWith(_keyInput, StringComparison.OrdinalIgnoreCase);
            }

            return _keyInput.StartsWith(Key + " ", StringComparison.OrdinalIgnoreCase);
        }

        public SearchResult Produce()
        {
            SearchResult result = new(Caption, IconPath);
            result.AltAndEnterKeysPressed += OnAltAndEnterKeysPressed;
            result.AltKeyPressed += OnAltKeyPressed;
            result.AltKeyReleased += OnAltKeyReleased;
            result.EnterKeyPressed += OnEnterKeyPressed;
            result.TabKeyPressed += OnTabKeyPressed;

            if (!string.IsNullOrEmpty(Description))
            {
                result.Description = Description;
                return result;
            }

            if (_keyInput.Length <= Key.Length)
            {
                result.Description = string.Format(DescriptionFormat, Placeholder);
                return result;
            }

            string input = _keyInput.Split(' ', 2)[^1];
            result.Description = string.Format(DescriptionFormat, input == string.Empty ? Placeholder : input);
            return result;
        }

        private void OnAltAndEnterKeysPressed(object sender, InputProcessingEventArgs e)
        {
            if (string.IsNullOrEmpty(AltUrl))
            {
                return;
            }

            e.Handled = true;
            ProcessUtility.GoTo(AltUrl);
        }

        private void OnAltKeyPressed(object sender, InputProcessingEventArgs e)
        {
            SearchResult result = (SearchResult)sender;
            result.Description = AltDescription;
        }

        private void OnAltKeyReleased(object sender, InputProcessingEventArgs e)
        {
            string[] keyInputArray = _keyInput.Split(' ', 2);
            string input = keyInputArray[^1];
            SearchResult result = (SearchResult)sender;
            result.Description = string.Format(DescriptionFormat, keyInputArray.Length < 2 || input == string.Empty ? Placeholder : input);
        }

        private void OnEnterKeyPressed(object sender, InputProcessingEventArgs e)
        {
            string[] keyInputArray = _keyInput.Split(' ', 2);
            string input = keyInputArray[^1];
            if (keyInputArray.Length < 2 || string.IsNullOrEmpty(input))
            {
                if (input == Key + " ")
                {
                    return;
                }

                // Handles autocompletion.
                e.IsInputIncomplete = true;
                e.CompleteInput = string.IsNullOrEmpty(Description) ? Key + " " : Key;
                return;
            }

            e.Handled = true;
            ProcessUtility.GoTo(string.IsNullOrEmpty(Url) ? string.Format(UrlFormat, input.Quote(EncodeInput)) : Url);
        }

        private void OnTabKeyPressed(object sender, InputProcessingEventArgs e)
        {
            string[] keyInputArray = _keyInput.Split(' ', 2);
            string input = keyInputArray[^1];
            if (keyInputArray.Length < 2 || string.IsNullOrEmpty(input))
            {
                bool isDescriptionNullOrEmpty = string.IsNullOrEmpty(Description);
                if (input == (isDescriptionNullOrEmpty ? Key + " " : Key))
                {
                    return;
                }

                // Handles autocompletion.
                e.IsInputIncomplete = true;
                e.CompleteInput = isDescriptionNullOrEmpty ? Key + " " : Key;
                return;
            }
        }
    }
}
