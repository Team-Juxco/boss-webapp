using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tools
{
    public static class DateHelper
    {
        public static DateTime? YearMonthFromUrl(HttpRequestBase request, int segmentIndex)
        {
            // break up the request's url into segments (split on the '/' character)
            if (request.Url.Segments.Length <= segmentIndex) { return null; }

            // grab the requested segment
            var yearMonth = request.Url.Segments[segmentIndex];
            // make sure the segment is formatted as 'YEAR-MONTH'
            if (yearMonth.Count(x => x == '-') != 1) { return null; }

            // parse the segment into a date
            DateTime requested;
            if (!DateTime.TryParse(yearMonth, out requested)) { return null; }

            // strip down the parsed date into just the year and the month
            requested = new DateTime(requested.Year, requested.Month, 1);

            // make sure we aren't requesting a month in the future
            if (requested > DateTime.Now) { return null; }

            return requested;
        }

    }
}