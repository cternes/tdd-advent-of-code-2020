﻿namespace app.Service
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class AdapterBag
    {
        private readonly List<int> adapters;
        
        public int NumberOf1JoltDifferences { get; private set; }

        public AdapterBag(List<int> adapters)
        {
            this.adapters = adapters;
        }

        public int GetBuiltInAdapterRate()
        {
            return adapters.Max() + 3;
        }

        public int FindFirstMatchingAdapter(int output)
        {
            return FindMatchingAdapter(output, true);
        }

        public int FindNextAdapter(int output)
        {
            return FindMatchingAdapter(output, false);
        }

        private int FindMatchingAdapter(int output, bool canEqualOutput)
        {
            var startingJoltDiff = canEqualOutput ? 0 : 1;
            for (var i = startingJoltDiff; i < 4; i++)
            {
                var matchingAdapter = HasMatchingAdapter(output + i);
                if (matchingAdapter != null)
                {
                    return (int) matchingAdapter;
                }
            }

            throw new NotSupportedException("Could not find matching adapter");
        }

        private int? HasMatchingAdapter(int output)
        {
            try
            {
                return adapters.First(i => i == output);
            }
            catch (InvalidOperationException)
            {
                return null;
            }
        }
    }
}