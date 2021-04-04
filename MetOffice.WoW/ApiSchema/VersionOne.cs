/*
 * C# MetOffice Weather Observation Website API Client
 * http://github.com/networkfusion/metoffice-wow
 * Copyright (C) 2021 Robin Jones

 * This program is free software; you can redistribute it and/or
 * modify it under the terms of the GNU General Public License
 * as published by the Free Software Foundation; either version 2
 * of the License, or (at your option) any later version.

 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.

 * You should have received a copy of the GNU General Public License
 * along with this program; if not, write to the Free Software
 * Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
 */

using System;

namespace MetOffice.WoW.ApiSchema
{
    public class VersionOne
    {
#pragma warning disable IDE1006 // Naming Styles, disabled due to being case sensitive

        /// <summary>
        /// Barometric Pressure
        /// </summary>
        /// <remarks>
        /// Inch of Mercury
        /// </remarks>
        public int baromin { get; set; }
        /// <summary>
        /// Accumulated rainfall so far today
        /// </summary>
        /// <remarks>
        ///  Inches
        /// </remarks>
        public int dailyrainin { get; set; }
        /// <summary>
        /// Outdoor Dewpoint Fahrenheit
        /// </summary>
        public int dewptf { get; set; }
        /// <summary>
        /// Outdoor Humidity
        /// </summary>
        /// <remarks>
        /// 0 to 100 Percent (%)
        /// </remarks>
        public int humidity { get; set; }
        /// <summary>
        /// Accumulated rainfall since the previous observation
        /// </summary>
        /// <remarks>
        /// In Inches
        /// </remarks>
        public int rainin { get; set; }
        /// <summary>
        /// Soil moisture content
        /// </summary>
        /// <remarks>
        /// 0 to 100 Percent (%)
        /// </remarks>
        public int soilmoisture { get; set; }
        /// <summary>
        /// Soil Temperature (10cm depth)
        /// </summary>
        /// <remarks>
        /// In Fahrenheit
        /// </remarks>
        public int soiltempf { get; set; }
        /// <summary>
        /// Outdoor Temperature
        /// </summary>
        /// <remarks>
        /// In Fahrenheit
        /// </remarks>
        public int tempf { get; set; }
        /// <summary>
        /// Visibility
        /// </summary>
        /// <remarks>
        /// In Kilometres
        /// </remarks>
        public int visibility { get; set; }
        /// <summary>
        /// Instantaneous Wind Direction
        /// </summary>
        /// <remarks>
        /// In Degrees (0 to 360)
        /// </remarks>
        public int winddir { get; set; }
        /// <summary>
        /// Instantaneous Wind Speed
        /// </summary>
        /// <remarks>
        /// In Miles per Hour
        /// </remarks>
        public int windspeedmph { get; set; }
        /// <summary>
        /// Current Wind Gust Direction(using software specific time period)
        /// </summary>
        /// <remarks>
        /// In Degrees (0 to 360)
        /// </remarks>
        public int windgustdir { get; set; }
        /// <summary>
        /// Current Wind Gust(using software specific time period)
        /// </summary>
        /// <remarks>
        /// In Miles per Hour
        /// </remarks>
        public int windgustmph { get; set; }

#pragma warning restore IDE1006 // Naming Styles
    }
}

