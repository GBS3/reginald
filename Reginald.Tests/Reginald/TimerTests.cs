﻿namespace Reginald.Tests.Reginald
{
    using global::Reginald.Models.DataModels;
    using NUnit.Framework;

    [TestFixture]
    public class TimerTests
    {
        [Test]
        [TestCase("1h Take out trash")]
        [TestCase("1h 1m Take out trash")]
        [TestCase("1h 1min Take out trash")]
        [TestCase("1h 1mins Take out trash")]
        [TestCase("1h 1minute Take out trash")]
        [TestCase("1h 1minutes Take out trash")]
        [TestCase("1h 1 m Take out trash")]
        [TestCase("1h 1 min Take out trash")]
        [TestCase("1h 1 mins Take out trash")]
        [TestCase("1h 1 minute Take out trash")]
        [TestCase("1h 1 minutes Take out trash")]
        [TestCase("1h 1m 1s Take out trash")]
        [TestCase("1h 1m 1sec Take out trash")]
        [TestCase("1h 1m 1secs Take out trash")]
        [TestCase("1h 1m 1second Take out trash")]
        [TestCase("1h 1m 1seconds Take out trash")]
        [TestCase("1h 1m 1 s Take out trash")]
        [TestCase("1h 1m 1 sec Take out trash")]
        [TestCase("1h 1m 1 secs Take out trash")]
        [TestCase("1h 1m 1 second Take out trash")]
        [TestCase("1h 1m 1 seconds Take out trash")]
        [TestCase("1h 1 min 1s Take out trash")]
        [TestCase("1h 1 min 1sec Take out trash")]
        [TestCase("1h 1 min 1secs Take out trash")]
        [TestCase("1h 1 min 1second Take out trash")]
        [TestCase("1h 1 min 1seconds Take out trash")]
        [TestCase("1h 1 min 1 s Take out trash")]
        [TestCase("1h 1 min 1 sec Take out trash")]
        [TestCase("1h 1 min 1 secs Take out trash")]
        [TestCase("1h 1 min 1 second Take out trash")]
        [TestCase("1h 1 min 1 seconds Take out trash")]
        [TestCase("1h 1 mins 1s Take out trash")]
        [TestCase("1h 1 mins 1sec Take out trash")]
        [TestCase("1h 1 mins 1secs Take out trash")]
        [TestCase("1h 1 mins 1second Take out trash")]
        [TestCase("1h 1 mins 1seconds Take out trash")]
        [TestCase("1h 1 mins 1 s Take out trash")]
        [TestCase("1h 1 mins 1 sec Take out trash")]
        [TestCase("1h 1 mins 1 secs Take out trash")]
        [TestCase("1h 1 mins 1 second Take out trash")]
        [TestCase("1h 1 mins 1 seconds Take out trash")]
        [TestCase("1h 1 minute 1s Take out trash")]
        [TestCase("1h 1 minute 1sec Take out trash")]
        [TestCase("1h 1 minute 1secs Take out trash")]
        [TestCase("1h 1 minute 1second Take out trash")]
        [TestCase("1h 1 minute 1seconds Take out trash")]
        [TestCase("1h 1 minute 1 s Take out trash")]
        [TestCase("1h 1 minute 1 sec Take out trash")]
        [TestCase("1h 1 minute 1 secs Take out trash")]
        [TestCase("1h 1 minute 1 second Take out trash")]
        [TestCase("1h 1 minute 1 seconds Take out trash")]
        [TestCase("1h 1 minutes 1s Take out trash")]
        [TestCase("1h 1 minutes 1sec Take out trash")]
        [TestCase("1h 1 minutes 1secs Take out trash")]
        [TestCase("1h 1 minutes 1second Take out trash")]
        [TestCase("1h 1 minutes 1seconds Take out trash")]
        [TestCase("1h 1 minutes 1 s Take out trash")]
        [TestCase("1h 1 minutes 1 sec Take out trash")]
        [TestCase("1h 1 minutes 1 secs Take out trash")]
        [TestCase("1h 1 minutes 1 second Take out trash")]
        [TestCase("1h 1 minutes 1 seconds Take out trash")]

        [TestCase("1hr Take out trash")]
        [TestCase("1hr 1m Take out trash")]
        [TestCase("1hr 1min Take out trash")]
        [TestCase("1hr 1mins Take out trash")]
        [TestCase("1hr 1minute Take out trash")]
        [TestCase("1hr 1minutes Take out trash")]
        [TestCase("1hr 1 m Take out trash")]
        [TestCase("1hr 1 min Take out trash")]
        [TestCase("1hr 1 mins Take out trash")]
        [TestCase("1hr 1 minute Take out trash")]
        [TestCase("1hr 1 minutes Take out trash")]
        [TestCase("1hr 1m 1s Take out trash")]
        [TestCase("1hr 1m 1sec Take out trash")]
        [TestCase("1hr 1m 1secs Take out trash")]
        [TestCase("1hr 1m 1second Take out trash")]
        [TestCase("1hr 1m 1seconds Take out trash")]
        [TestCase("1hr 1m 1 s Take out trash")]
        [TestCase("1hr 1m 1 sec Take out trash")]
        [TestCase("1hr 1m 1 secs Take out trash")]
        [TestCase("1hr 1m 1 second Take out trash")]
        [TestCase("1hr 1m 1 seconds Take out trash")]
        [TestCase("1hr 1 min 1s Take out trash")]
        [TestCase("1hr 1 min 1sec Take out trash")]
        [TestCase("1hr 1 min 1secs Take out trash")]
        [TestCase("1hr 1 min 1second Take out trash")]
        [TestCase("1hr 1 min 1seconds Take out trash")]
        [TestCase("1hr 1 min 1 s Take out trash")]
        [TestCase("1hr 1 min 1 sec Take out trash")]
        [TestCase("1hr 1 min 1 secs Take out trash")]
        [TestCase("1hr 1 min 1 second Take out trash")]
        [TestCase("1hr 1 min 1 seconds Take out trash")]
        [TestCase("1hr 1 mins 1s Take out trash")]
        [TestCase("1hr 1 mins 1sec Take out trash")]
        [TestCase("1hr 1 mins 1secs Take out trash")]
        [TestCase("1hr 1 mins 1second Take out trash")]
        [TestCase("1hr 1 mins 1seconds Take out trash")]
        [TestCase("1hr 1 mins 1 s Take out trash")]
        [TestCase("1hr 1 mins 1 sec Take out trash")]
        [TestCase("1hr 1 mins 1 secs Take out trash")]
        [TestCase("1hr 1 mins 1 second Take out trash")]
        [TestCase("1hr 1 mins 1 seconds Take out trash")]
        [TestCase("1hr 1 minute 1s Take out trash")]
        [TestCase("1hr 1 minute 1sec Take out trash")]
        [TestCase("1hr 1 minute 1secs Take out trash")]
        [TestCase("1hr 1 minute 1second Take out trash")]
        [TestCase("1hr 1 minute 1seconds Take out trash")]
        [TestCase("1hr 1 minute 1 s Take out trash")]
        [TestCase("1hr 1 minute 1 sec Take out trash")]
        [TestCase("1hr 1 minute 1 secs Take out trash")]
        [TestCase("1hr 1 minute 1 second Take out trash")]
        [TestCase("1hr 1 minute 1 seconds Take out trash")]
        [TestCase("1hr 1 minutes 1s Take out trash")]
        [TestCase("1hr 1 minutes 1sec Take out trash")]
        [TestCase("1hr 1 minutes 1secs Take out trash")]
        [TestCase("1hr 1 minutes 1second Take out trash")]
        [TestCase("1hr 1 minutes 1seconds Take out trash")]
        [TestCase("1hr 1 minutes 1 s Take out trash")]
        [TestCase("1hr 1 minutes 1 sec Take out trash")]
        [TestCase("1hr 1 minutes 1 secs Take out trash")]
        [TestCase("1hr 1 minutes 1 second Take out trash")]
        [TestCase("1hr 1 minutes 1 seconds Take out trash")]

        [TestCase("1hrs Take out trash")]
        [TestCase("1hrs 1m Take out trash")]
        [TestCase("1hrs 1min Take out trash")]
        [TestCase("1hrs 1mins Take out trash")]
        [TestCase("1hrs 1minute Take out trash")]
        [TestCase("1hrs 1minutes Take out trash")]
        [TestCase("1hrs 1 m Take out trash")]
        [TestCase("1hrs 1 min Take out trash")]
        [TestCase("1hrs 1 mins Take out trash")]
        [TestCase("1hrs 1 minute Take out trash")]
        [TestCase("1hrs 1 minutes Take out trash")]
        [TestCase("1hrs 1m 1s Take out trash")]
        [TestCase("1hrs 1m 1sec Take out trash")]
        [TestCase("1hrs 1m 1secs Take out trash")]
        [TestCase("1hrs 1m 1second Take out trash")]
        [TestCase("1hrs 1m 1seconds Take out trash")]
        [TestCase("1hrs 1m 1 s Take out trash")]
        [TestCase("1hrs 1m 1 sec Take out trash")]
        [TestCase("1hrs 1m 1 secs Take out trash")]
        [TestCase("1hrs 1m 1 second Take out trash")]
        [TestCase("1hrs 1m 1 seconds Take out trash")]
        [TestCase("1hrs 1 min 1s Take out trash")]
        [TestCase("1hrs 1 min 1sec Take out trash")]
        [TestCase("1hrs 1 min 1secs Take out trash")]
        [TestCase("1hrs 1 min 1second Take out trash")]
        [TestCase("1hrs 1 min 1seconds Take out trash")]
        [TestCase("1hrs 1 min 1 s Take out trash")]
        [TestCase("1hrs 1 min 1 sec Take out trash")]
        [TestCase("1hrs 1 min 1 secs Take out trash")]
        [TestCase("1hrs 1 min 1 second Take out trash")]
        [TestCase("1hrs 1 min 1 seconds Take out trash")]
        [TestCase("1hrs 1 mins 1s Take out trash")]
        [TestCase("1hrs 1 mins 1sec Take out trash")]
        [TestCase("1hrs 1 mins 1secs Take out trash")]
        [TestCase("1hrs 1 mins 1second Take out trash")]
        [TestCase("1hrs 1 mins 1seconds Take out trash")]
        [TestCase("1hrs 1 mins 1 s Take out trash")]
        [TestCase("1hrs 1 mins 1 sec Take out trash")]
        [TestCase("1hrs 1 mins 1 secs Take out trash")]
        [TestCase("1hrs 1 mins 1 second Take out trash")]
        [TestCase("1hrs 1 mins 1 seconds Take out trash")]
        [TestCase("1hrs 1 minute 1s Take out trash")]
        [TestCase("1hrs 1 minute 1sec Take out trash")]
        [TestCase("1hrs 1 minute 1secs Take out trash")]
        [TestCase("1hrs 1 minute 1second Take out trash")]
        [TestCase("1hrs 1 minute 1seconds Take out trash")]
        [TestCase("1hrs 1 minute 1 s Take out trash")]
        [TestCase("1hrs 1 minute 1 sec Take out trash")]
        [TestCase("1hrs 1 minute 1 secs Take out trash")]
        [TestCase("1hrs 1 minute 1 second Take out trash")]
        [TestCase("1hrs 1 minute 1 seconds Take out trash")]
        [TestCase("1hrs 1 minutes 1s Take out trash")]
        [TestCase("1hrs 1 minutes 1sec Take out trash")]
        [TestCase("1hrs 1 minutes 1secs Take out trash")]
        [TestCase("1hrs 1 minutes 1second Take out trash")]
        [TestCase("1hrs 1 minutes 1seconds Take out trash")]
        [TestCase("1hrs 1 minutes 1 s Take out trash")]
        [TestCase("1hrs 1 minutes 1 sec Take out trash")]
        [TestCase("1hrs 1 minutes 1 secs Take out trash")]
        [TestCase("1hrs 1 minutes 1 second Take out trash")]
        [TestCase("1hrs 1 minutes 1 seconds Take out trash")]

        [TestCase("1hour Take out trash")]
        [TestCase("1hour 1m Take out trash")]
        [TestCase("1hour 1min Take out trash")]
        [TestCase("1hour 1mins Take out trash")]
        [TestCase("1hour 1minute Take out trash")]
        [TestCase("1hour 1minutes Take out trash")]
        [TestCase("1hour 1 m Take out trash")]
        [TestCase("1hour 1 min Take out trash")]
        [TestCase("1hour 1 mins Take out trash")]
        [TestCase("1hour 1 minute Take out trash")]
        [TestCase("1hour 1 minutes Take out trash")]
        [TestCase("1hour 1m 1s Take out trash")]
        [TestCase("1hour 1m 1sec Take out trash")]
        [TestCase("1hour 1m 1secs Take out trash")]
        [TestCase("1hour 1m 1second Take out trash")]
        [TestCase("1hour 1m 1seconds Take out trash")]
        [TestCase("1hour 1m 1 s Take out trash")]
        [TestCase("1hour 1m 1 sec Take out trash")]
        [TestCase("1hour 1m 1 secs Take out trash")]
        [TestCase("1hour 1m 1 second Take out trash")]
        [TestCase("1hour 1m 1 seconds Take out trash")]
        [TestCase("1hour 1 min 1s Take out trash")]
        [TestCase("1hour 1 min 1sec Take out trash")]
        [TestCase("1hour 1 min 1secs Take out trash")]
        [TestCase("1hour 1 min 1second Take out trash")]
        [TestCase("1hour 1 min 1seconds Take out trash")]
        [TestCase("1hour 1 min 1 s Take out trash")]
        [TestCase("1hour 1 min 1 sec Take out trash")]
        [TestCase("1hour 1 min 1 secs Take out trash")]
        [TestCase("1hour 1 min 1 second Take out trash")]
        [TestCase("1hour 1 min 1 seconds Take out trash")]
        [TestCase("1hour 1 mins 1s Take out trash")]
        [TestCase("1hour 1 mins 1sec Take out trash")]
        [TestCase("1hour 1 mins 1secs Take out trash")]
        [TestCase("1hour 1 mins 1second Take out trash")]
        [TestCase("1hour 1 mins 1seconds Take out trash")]
        [TestCase("1hour 1 mins 1 s Take out trash")]
        [TestCase("1hour 1 mins 1 sec Take out trash")]
        [TestCase("1hour 1 mins 1 secs Take out trash")]
        [TestCase("1hour 1 mins 1 second Take out trash")]
        [TestCase("1hour 1 mins 1 seconds Take out trash")]
        [TestCase("1hour 1 minute 1s Take out trash")]
        [TestCase("1hour 1 minute 1sec Take out trash")]
        [TestCase("1hour 1 minute 1secs Take out trash")]
        [TestCase("1hour 1 minute 1second Take out trash")]
        [TestCase("1hour 1 minute 1seconds Take out trash")]
        [TestCase("1hour 1 minute 1 s Take out trash")]
        [TestCase("1hour 1 minute 1 sec Take out trash")]
        [TestCase("1hour 1 minute 1 secs Take out trash")]
        [TestCase("1hour 1 minute 1 second Take out trash")]
        [TestCase("1hour 1 minute 1 seconds Take out trash")]
        [TestCase("1hour 1 minutes 1s Take out trash")]
        [TestCase("1hour 1 minutes 1sec Take out trash")]
        [TestCase("1hour 1 minutes 1secs Take out trash")]
        [TestCase("1hour 1 minutes 1second Take out trash")]
        [TestCase("1hour 1 minutes 1seconds Take out trash")]
        [TestCase("1hour 1 minutes 1 s Take out trash")]
        [TestCase("1hour 1 minutes 1 sec Take out trash")]
        [TestCase("1hour 1 minutes 1 secs Take out trash")]
        [TestCase("1hour 1 minutes 1 second Take out trash")]
        [TestCase("1hour 1 minutes 1 seconds Take out trash")]

        [TestCase("1hours Take out trash")]
        [TestCase("1hours 1m Take out trash")]
        [TestCase("1hours 1min Take out trash")]
        [TestCase("1hours 1mins Take out trash")]
        [TestCase("1hours 1minute Take out trash")]
        [TestCase("1hours 1minutes Take out trash")]
        [TestCase("1hours 1 m Take out trash")]
        [TestCase("1hours 1 min Take out trash")]
        [TestCase("1hours 1 mins Take out trash")]
        [TestCase("1hours 1 minute Take out trash")]
        [TestCase("1hours 1 minutes Take out trash")]
        [TestCase("1hours 1m 1s Take out trash")]
        [TestCase("1hours 1m 1sec Take out trash")]
        [TestCase("1hours 1m 1secs Take out trash")]
        [TestCase("1hours 1m 1second Take out trash")]
        [TestCase("1hours 1m 1seconds Take out trash")]
        [TestCase("1hours 1m 1 s Take out trash")]
        [TestCase("1hours 1m 1 sec Take out trash")]
        [TestCase("1hours 1m 1 secs Take out trash")]
        [TestCase("1hours 1m 1 second Take out trash")]
        [TestCase("1hours 1m 1 seconds Take out trash")]
        [TestCase("1hours 1 min 1s Take out trash")]
        [TestCase("1hours 1 min 1sec Take out trash")]
        [TestCase("1hours 1 min 1secs Take out trash")]
        [TestCase("1hours 1 min 1second Take out trash")]
        [TestCase("1hours 1 min 1seconds Take out trash")]
        [TestCase("1hours 1 min 1 s Take out trash")]
        [TestCase("1hours 1 min 1 sec Take out trash")]
        [TestCase("1hours 1 min 1 secs Take out trash")]
        [TestCase("1hours 1 min 1 second Take out trash")]
        [TestCase("1hours 1 min 1 seconds Take out trash")]
        [TestCase("1hours 1 mins 1s Take out trash")]
        [TestCase("1hours 1 mins 1sec Take out trash")]
        [TestCase("1hours 1 mins 1secs Take out trash")]
        [TestCase("1hours 1 mins 1second Take out trash")]
        [TestCase("1hours 1 mins 1seconds Take out trash")]
        [TestCase("1hours 1 mins 1 s Take out trash")]
        [TestCase("1hours 1 mins 1 sec Take out trash")]
        [TestCase("1hours 1 mins 1 secs Take out trash")]
        [TestCase("1hours 1 mins 1 second Take out trash")]
        [TestCase("1hours 1 mins 1 seconds Take out trash")]
        [TestCase("1hours 1 minute 1s Take out trash")]
        [TestCase("1hours 1 minute 1sec Take out trash")]
        [TestCase("1hours 1 minute 1secs Take out trash")]
        [TestCase("1hours 1 minute 1second Take out trash")]
        [TestCase("1hours 1 minute 1seconds Take out trash")]
        [TestCase("1hours 1 minute 1 s Take out trash")]
        [TestCase("1hours 1 minute 1 sec Take out trash")]
        [TestCase("1hours 1 minute 1 secs Take out trash")]
        [TestCase("1hours 1 minute 1 second Take out trash")]
        [TestCase("1hours 1 minute 1 seconds Take out trash")]
        [TestCase("1hours 1 minutes 1s Take out trash")]
        [TestCase("1hours 1 minutes 1sec Take out trash")]
        [TestCase("1hours 1 minutes 1secs Take out trash")]
        [TestCase("1hours 1 minutes 1second Take out trash")]
        [TestCase("1hours 1 minutes 1seconds Take out trash")]
        [TestCase("1hours 1 minutes 1 s Take out trash")]
        [TestCase("1hours 1 minutes 1 sec Take out trash")]
        [TestCase("1hours 1 minutes 1 secs Take out trash")]
        [TestCase("1hours 1 minutes 1 second Take out trash")]
        [TestCase("1hours 1 minutes 1 seconds Take out trash")]

        [TestCase("1 h Take out trash")]
        [TestCase("1 h 1m Take out trash")]
        [TestCase("1 h 1min Take out trash")]
        [TestCase("1 h 1mins Take out trash")]
        [TestCase("1 h 1minute Take out trash")]
        [TestCase("1 h 1minutes Take out trash")]
        [TestCase("1 h 1 m Take out trash")]
        [TestCase("1 h 1 min Take out trash")]
        [TestCase("1 h 1 mins Take out trash")]
        [TestCase("1 h 1 minute Take out trash")]
        [TestCase("1 h 1 minutes Take out trash")]
        [TestCase("1 h 1m 1s Take out trash")]
        [TestCase("1 h 1m 1sec Take out trash")]
        [TestCase("1 h 1m 1secs Take out trash")]
        [TestCase("1 h 1m 1second Take out trash")]
        [TestCase("1 h 1m 1seconds Take out trash")]
        [TestCase("1 h 1m 1 s Take out trash")]
        [TestCase("1 h 1m 1 sec Take out trash")]
        [TestCase("1 h 1m 1 secs Take out trash")]
        [TestCase("1 h 1m 1 second Take out trash")]
        [TestCase("1 h 1m 1 seconds Take out trash")]
        [TestCase("1 h 1 min 1s Take out trash")]
        [TestCase("1 h 1 min 1sec Take out trash")]
        [TestCase("1 h 1 min 1secs Take out trash")]
        [TestCase("1 h 1 min 1second Take out trash")]
        [TestCase("1 h 1 min 1seconds Take out trash")]
        [TestCase("1 h 1 min 1 s Take out trash")]
        [TestCase("1 h 1 min 1 sec Take out trash")]
        [TestCase("1 h 1 min 1 secs Take out trash")]
        [TestCase("1 h 1 min 1 second Take out trash")]
        [TestCase("1 h 1 min 1 seconds Take out trash")]
        [TestCase("1 h 1 mins 1s Take out trash")]
        [TestCase("1 h 1 mins 1sec Take out trash")]
        [TestCase("1 h 1 mins 1secs Take out trash")]
        [TestCase("1 h 1 mins 1second Take out trash")]
        [TestCase("1 h 1 mins 1seconds Take out trash")]
        [TestCase("1 h 1 mins 1 s Take out trash")]
        [TestCase("1 h 1 mins 1 sec Take out trash")]
        [TestCase("1 h 1 mins 1 secs Take out trash")]
        [TestCase("1 h 1 mins 1 second Take out trash")]
        [TestCase("1 h 1 mins 1 seconds Take out trash")]
        [TestCase("1 h 1 minute 1s Take out trash")]
        [TestCase("1 h 1 minute 1sec Take out trash")]
        [TestCase("1 h 1 minute 1secs Take out trash")]
        [TestCase("1 h 1 minute 1second Take out trash")]
        [TestCase("1 h 1 minute 1seconds Take out trash")]
        [TestCase("1 h 1 minute 1 s Take out trash")]
        [TestCase("1 h 1 minute 1 sec Take out trash")]
        [TestCase("1 h 1 minute 1 secs Take out trash")]
        [TestCase("1 h 1 minute 1 second Take out trash")]
        [TestCase("1 h 1 minute 1 seconds Take out trash")]
        [TestCase("1 h 1 minutes 1s Take out trash")]
        [TestCase("1 h 1 minutes 1sec Take out trash")]
        [TestCase("1 h 1 minutes 1secs Take out trash")]
        [TestCase("1 h 1 minutes 1second Take out trash")]
        [TestCase("1 h 1 minutes 1seconds Take out trash")]
        [TestCase("1 h 1 minutes 1 s Take out trash")]
        [TestCase("1 h 1 minutes 1 sec Take out trash")]
        [TestCase("1 h 1 minutes 1 secs Take out trash")]
        [TestCase("1 h 1 minutes 1 second Take out trash")]
        [TestCase("1 h 1 minutes 1 seconds Take out trash")]

        [TestCase("1 hr Take out trash")]
        [TestCase("1 hr 1m Take out trash")]
        [TestCase("1 hr 1min Take out trash")]
        [TestCase("1 hr 1mins Take out trash")]
        [TestCase("1 hr 1minute Take out trash")]
        [TestCase("1 hr 1minutes Take out trash")]
        [TestCase("1 hr 1 m Take out trash")]
        [TestCase("1 hr 1 min Take out trash")]
        [TestCase("1 hr 1 mins Take out trash")]
        [TestCase("1 hr 1 minute Take out trash")]
        [TestCase("1 hr 1 minutes Take out trash")]
        [TestCase("1 hr 1m 1s Take out trash")]
        [TestCase("1 hr 1m 1sec Take out trash")]
        [TestCase("1 hr 1m 1secs Take out trash")]
        [TestCase("1 hr 1m 1second Take out trash")]
        [TestCase("1 hr 1m 1seconds Take out trash")]
        [TestCase("1 hr 1m 1 s Take out trash")]
        [TestCase("1 hr 1m 1 sec Take out trash")]
        [TestCase("1 hr 1m 1 secs Take out trash")]
        [TestCase("1 hr 1m 1 second Take out trash")]
        [TestCase("1 hr 1m 1 seconds Take out trash")]
        [TestCase("1 hr 1 min 1s Take out trash")]
        [TestCase("1 hr 1 min 1sec Take out trash")]
        [TestCase("1 hr 1 min 1secs Take out trash")]
        [TestCase("1 hr 1 min 1second Take out trash")]
        [TestCase("1 hr 1 min 1seconds Take out trash")]
        [TestCase("1 hr 1 min 1 s Take out trash")]
        [TestCase("1 hr 1 min 1 sec Take out trash")]
        [TestCase("1 hr 1 min 1 secs Take out trash")]
        [TestCase("1 hr 1 min 1 second Take out trash")]
        [TestCase("1 hr 1 min 1 seconds Take out trash")]
        [TestCase("1 hr 1 mins 1s Take out trash")]
        [TestCase("1 hr 1 mins 1sec Take out trash")]
        [TestCase("1 hr 1 mins 1secs Take out trash")]
        [TestCase("1 hr 1 mins 1second Take out trash")]
        [TestCase("1 hr 1 mins 1seconds Take out trash")]
        [TestCase("1 hr 1 mins 1 s Take out trash")]
        [TestCase("1 hr 1 mins 1 sec Take out trash")]
        [TestCase("1 hr 1 mins 1 secs Take out trash")]
        [TestCase("1 hr 1 mins 1 second Take out trash")]
        [TestCase("1 hr 1 mins 1 seconds Take out trash")]
        [TestCase("1 hr 1 minute 1s Take out trash")]
        [TestCase("1 hr 1 minute 1sec Take out trash")]
        [TestCase("1 hr 1 minute 1secs Take out trash")]
        [TestCase("1 hr 1 minute 1second Take out trash")]
        [TestCase("1 hr 1 minute 1seconds Take out trash")]
        [TestCase("1 hr 1 minute 1 s Take out trash")]
        [TestCase("1 hr 1 minute 1 sec Take out trash")]
        [TestCase("1 hr 1 minute 1 secs Take out trash")]
        [TestCase("1 hr 1 minute 1 second Take out trash")]
        [TestCase("1 hr 1 minute 1 seconds Take out trash")]
        [TestCase("1 hr 1 minutes 1s Take out trash")]
        [TestCase("1 hr 1 minutes 1sec Take out trash")]
        [TestCase("1 hr 1 minutes 1secs Take out trash")]
        [TestCase("1 hr 1 minutes 1second Take out trash")]
        [TestCase("1 hr 1 minutes 1seconds Take out trash")]
        [TestCase("1 hr 1 minutes 1 s Take out trash")]
        [TestCase("1 hr 1 minutes 1 sec Take out trash")]
        [TestCase("1 hr 1 minutes 1 secs Take out trash")]
        [TestCase("1 hr 1 minutes 1 second Take out trash")]
        [TestCase("1 hr 1 minutes 1 seconds Take out trash")]

        [TestCase("1 hrs Take out trash")]
        [TestCase("1 hrs 1m Take out trash")]
        [TestCase("1 hrs 1min Take out trash")]
        [TestCase("1 hrs 1mins Take out trash")]
        [TestCase("1 hrs 1minute Take out trash")]
        [TestCase("1 hrs 1minutes Take out trash")]
        [TestCase("1 hrs 1 m Take out trash")]
        [TestCase("1 hrs 1 min Take out trash")]
        [TestCase("1 hrs 1 mins Take out trash")]
        [TestCase("1 hrs 1 minute Take out trash")]
        [TestCase("1 hrs 1 minutes Take out trash")]
        [TestCase("1 hrs 1m 1s Take out trash")]
        [TestCase("1 hrs 1m 1sec Take out trash")]
        [TestCase("1 hrs 1m 1secs Take out trash")]
        [TestCase("1 hrs 1m 1second Take out trash")]
        [TestCase("1 hrs 1m 1seconds Take out trash")]
        [TestCase("1 hrs 1m 1 s Take out trash")]
        [TestCase("1 hrs 1m 1 sec Take out trash")]
        [TestCase("1 hrs 1m 1 secs Take out trash")]
        [TestCase("1 hrs 1m 1 second Take out trash")]
        [TestCase("1 hrs 1m 1 seconds Take out trash")]
        [TestCase("1 hrs 1 min 1s Take out trash")]
        [TestCase("1 hrs 1 min 1sec Take out trash")]
        [TestCase("1 hrs 1 min 1secs Take out trash")]
        [TestCase("1 hrs 1 min 1second Take out trash")]
        [TestCase("1 hrs 1 min 1seconds Take out trash")]
        [TestCase("1 hrs 1 min 1 s Take out trash")]
        [TestCase("1 hrs 1 min 1 sec Take out trash")]
        [TestCase("1 hrs 1 min 1 secs Take out trash")]
        [TestCase("1 hrs 1 min 1 second Take out trash")]
        [TestCase("1 hrs 1 min 1 seconds Take out trash")]
        [TestCase("1 hrs 1 mins 1s Take out trash")]
        [TestCase("1 hrs 1 mins 1sec Take out trash")]
        [TestCase("1 hrs 1 mins 1secs Take out trash")]
        [TestCase("1 hrs 1 mins 1second Take out trash")]
        [TestCase("1 hrs 1 mins 1seconds Take out trash")]
        [TestCase("1 hrs 1 mins 1 s Take out trash")]
        [TestCase("1 hrs 1 mins 1 sec Take out trash")]
        [TestCase("1 hrs 1 mins 1 secs Take out trash")]
        [TestCase("1 hrs 1 mins 1 second Take out trash")]
        [TestCase("1 hrs 1 mins 1 seconds Take out trash")]
        [TestCase("1 hrs 1 minute 1s Take out trash")]
        [TestCase("1 hrs 1 minute 1sec Take out trash")]
        [TestCase("1 hrs 1 minute 1secs Take out trash")]
        [TestCase("1 hrs 1 minute 1second Take out trash")]
        [TestCase("1 hrs 1 minute 1seconds Take out trash")]
        [TestCase("1 hrs 1 minute 1 s Take out trash")]
        [TestCase("1 hrs 1 minute 1 sec Take out trash")]
        [TestCase("1 hrs 1 minute 1 secs Take out trash")]
        [TestCase("1 hrs 1 minute 1 second Take out trash")]
        [TestCase("1 hrs 1 minute 1 seconds Take out trash")]
        [TestCase("1 hrs 1 minutes 1s Take out trash")]
        [TestCase("1 hrs 1 minutes 1sec Take out trash")]
        [TestCase("1 hrs 1 minutes 1secs Take out trash")]
        [TestCase("1 hrs 1 minutes 1second Take out trash")]
        [TestCase("1 hrs 1 minutes 1seconds Take out trash")]
        [TestCase("1 hrs 1 minutes 1 s Take out trash")]
        [TestCase("1 hrs 1 minutes 1 sec Take out trash")]
        [TestCase("1 hrs 1 minutes 1 secs Take out trash")]
        [TestCase("1 hrs 1 minutes 1 second Take out trash")]
        [TestCase("1 hrs 1 minutes 1 seconds Take out trash")]

        [TestCase("1 hour Take out trash")]
        [TestCase("1 hour 1m Take out trash")]
        [TestCase("1 hour 1min Take out trash")]
        [TestCase("1 hour 1mins Take out trash")]
        [TestCase("1 hour 1minute Take out trash")]
        [TestCase("1 hour 1minutes Take out trash")]
        [TestCase("1 hour 1 m Take out trash")]
        [TestCase("1 hour 1 min Take out trash")]
        [TestCase("1 hour 1 mins Take out trash")]
        [TestCase("1 hour 1 minute Take out trash")]
        [TestCase("1 hour 1 minutes Take out trash")]
        [TestCase("1 hour 1m 1s Take out trash")]
        [TestCase("1 hour 1m 1sec Take out trash")]
        [TestCase("1 hour 1m 1secs Take out trash")]
        [TestCase("1 hour 1m 1second Take out trash")]
        [TestCase("1 hour 1m 1seconds Take out trash")]
        [TestCase("1 hour 1m 1 s Take out trash")]
        [TestCase("1 hour 1m 1 sec Take out trash")]
        [TestCase("1 hour 1m 1 secs Take out trash")]
        [TestCase("1 hour 1m 1 second Take out trash")]
        [TestCase("1 hour 1m 1 seconds Take out trash")]
        [TestCase("1 hour 1 min 1s Take out trash")]
        [TestCase("1 hour 1 min 1sec Take out trash")]
        [TestCase("1 hour 1 min 1secs Take out trash")]
        [TestCase("1 hour 1 min 1second Take out trash")]
        [TestCase("1 hour 1 min 1seconds Take out trash")]
        [TestCase("1 hour 1 min 1 s Take out trash")]
        [TestCase("1 hour 1 min 1 sec Take out trash")]
        [TestCase("1 hour 1 min 1 secs Take out trash")]
        [TestCase("1 hour 1 min 1 second Take out trash")]
        [TestCase("1 hour 1 min 1 seconds Take out trash")]
        [TestCase("1 hour 1 mins 1s Take out trash")]
        [TestCase("1 hour 1 mins 1sec Take out trash")]
        [TestCase("1 hour 1 mins 1secs Take out trash")]
        [TestCase("1 hour 1 mins 1second Take out trash")]
        [TestCase("1 hour 1 mins 1seconds Take out trash")]
        [TestCase("1 hour 1 mins 1 s Take out trash")]
        [TestCase("1 hour 1 mins 1 sec Take out trash")]
        [TestCase("1 hour 1 mins 1 secs Take out trash")]
        [TestCase("1 hour 1 mins 1 second Take out trash")]
        [TestCase("1 hour 1 mins 1 seconds Take out trash")]
        [TestCase("1 hour 1 minute 1s Take out trash")]
        [TestCase("1 hour 1 minute 1sec Take out trash")]
        [TestCase("1 hour 1 minute 1secs Take out trash")]
        [TestCase("1 hour 1 minute 1second Take out trash")]
        [TestCase("1 hour 1 minute 1seconds Take out trash")]
        [TestCase("1 hour 1 minute 1 s Take out trash")]
        [TestCase("1 hour 1 minute 1 sec Take out trash")]
        [TestCase("1 hour 1 minute 1 secs Take out trash")]
        [TestCase("1 hour 1 minute 1 second Take out trash")]
        [TestCase("1 hour 1 minute 1 seconds Take out trash")]
        [TestCase("1 hour 1 minutes 1s Take out trash")]
        [TestCase("1 hour 1 minutes 1sec Take out trash")]
        [TestCase("1 hour 1 minutes 1secs Take out trash")]
        [TestCase("1 hour 1 minutes 1second Take out trash")]
        [TestCase("1 hour 1 minutes 1seconds Take out trash")]
        [TestCase("1 hour 1 minutes 1 s Take out trash")]
        [TestCase("1 hour 1 minutes 1 sec Take out trash")]
        [TestCase("1 hour 1 minutes 1 secs Take out trash")]
        [TestCase("1 hour 1 minutes 1 second Take out trash")]
        [TestCase("1 hour 1 minutes 1 seconds Take out trash")]

        [TestCase("1 hours Take out trash")]
        [TestCase("1 hours 1m Take out trash")]
        [TestCase("1 hours 1min Take out trash")]
        [TestCase("1 hours 1mins Take out trash")]
        [TestCase("1 hours 1minute Take out trash")]
        [TestCase("1 hours 1minutes Take out trash")]
        [TestCase("1 hours 1 m Take out trash")]
        [TestCase("1 hours 1 min Take out trash")]
        [TestCase("1 hours 1 mins Take out trash")]
        [TestCase("1 hours 1 minute Take out trash")]
        [TestCase("1 hours 1 minutes Take out trash")]
        [TestCase("1 hours 1m 1s Take out trash")]
        [TestCase("1 hours 1m 1sec Take out trash")]
        [TestCase("1 hours 1m 1secs Take out trash")]
        [TestCase("1 hours 1m 1second Take out trash")]
        [TestCase("1 hours 1m 1seconds Take out trash")]
        [TestCase("1 hours 1m 1 s Take out trash")]
        [TestCase("1 hours 1m 1 sec Take out trash")]
        [TestCase("1 hours 1m 1 secs Take out trash")]
        [TestCase("1 hours 1m 1 second Take out trash")]
        [TestCase("1 hours 1m 1 seconds Take out trash")]
        [TestCase("1 hours 1 min 1s Take out trash")]
        [TestCase("1 hours 1 min 1sec Take out trash")]
        [TestCase("1 hours 1 min 1secs Take out trash")]
        [TestCase("1 hours 1 min 1second Take out trash")]
        [TestCase("1 hours 1 min 1seconds Take out trash")]
        [TestCase("1 hours 1 min 1 s Take out trash")]
        [TestCase("1 hours 1 min 1 sec Take out trash")]
        [TestCase("1 hours 1 min 1 secs Take out trash")]
        [TestCase("1 hours 1 min 1 second Take out trash")]
        [TestCase("1 hours 1 min 1 seconds Take out trash")]
        [TestCase("1 hours 1 mins 1s Take out trash")]
        [TestCase("1 hours 1 mins 1sec Take out trash")]
        [TestCase("1 hours 1 mins 1secs Take out trash")]
        [TestCase("1 hours 1 mins 1second Take out trash")]
        [TestCase("1 hours 1 mins 1seconds Take out trash")]
        [TestCase("1 hours 1 mins 1 s Take out trash")]
        [TestCase("1 hours 1 mins 1 sec Take out trash")]
        [TestCase("1 hours 1 mins 1 secs Take out trash")]
        [TestCase("1 hours 1 mins 1 second Take out trash")]
        [TestCase("1 hours 1 mins 1 seconds Take out trash")]
        [TestCase("1 hours 1 minute 1s Take out trash")]
        [TestCase("1 hours 1 minute 1sec Take out trash")]
        [TestCase("1 hours 1 minute 1secs Take out trash")]
        [TestCase("1 hours 1 minute 1second Take out trash")]
        [TestCase("1 hours 1 minute 1seconds Take out trash")]
        [TestCase("1 hours 1 minute 1 s Take out trash")]
        [TestCase("1 hours 1 minute 1 sec Take out trash")]
        [TestCase("1 hours 1 minute 1 secs Take out trash")]
        [TestCase("1 hours 1 minute 1 second Take out trash")]
        [TestCase("1 hours 1 minute 1 seconds Take out trash")]
        [TestCase("1 hours 1 minutes 1s Take out trash")]
        [TestCase("1 hours 1 minutes 1sec Take out trash")]
        [TestCase("1 hours 1 minutes 1secs Take out trash")]
        [TestCase("1 hours 1 minutes 1second Take out trash")]
        [TestCase("1 hours 1 minutes 1seconds Take out trash")]
        [TestCase("1 hours 1 minutes 1 s Take out trash")]
        [TestCase("1 hours 1 minutes 1 sec Take out trash")]
        [TestCase("1 hours 1 minutes 1 secs Take out trash")]
        [TestCase("1 hours 1 minutes 1 second Take out trash")]
        [TestCase("1 hours 1 minutes 1 seconds Take out trash")]

        [TestCase("1m Take out trash")]
        [TestCase("1min Take out trash")]
        [TestCase("1mins Take out trash")]
        [TestCase("1minute Take out trash")]
        [TestCase("1minutes Take out trash")]
        [TestCase("1 m Take out trash")]
        [TestCase("1 min Take out trash")]
        [TestCase("1 mins Take out trash")]
        [TestCase("1 minute Take out trash")]
        [TestCase("1 minutes Take out trash")]
        [TestCase("1m 1s Take out trash")]
        [TestCase("1m 1sec Take out trash")]
        [TestCase("1m 1secs Take out trash")]
        [TestCase("1m 1second Take out trash")]
        [TestCase("1m 1seconds Take out trash")]
        [TestCase("1m 1 s Take out trash")]
        [TestCase("1m 1 sec Take out trash")]
        [TestCase("1m 1 secs Take out trash")]
        [TestCase("1m 1 second Take out trash")]
        [TestCase("1m 1 seconds Take out trash")]
        [TestCase("1 min 1s Take out trash")]
        [TestCase("1 min 1sec Take out trash")]
        [TestCase("1 min 1secs Take out trash")]
        [TestCase("1 min 1second Take out trash")]
        [TestCase("1 min 1seconds Take out trash")]
        [TestCase("1 min 1 s Take out trash")]
        [TestCase("1 min 1 sec Take out trash")]
        [TestCase("1 min 1 secs Take out trash")]
        [TestCase("1 min 1 second Take out trash")]
        [TestCase("1 min 1 seconds Take out trash")]
        [TestCase("1 mins 1s Take out trash")]
        [TestCase("1 mins 1sec Take out trash")]
        [TestCase("1 mins 1secs Take out trash")]
        [TestCase("1 mins 1second Take out trash")]
        [TestCase("1 mins 1seconds Take out trash")]
        [TestCase("1 mins 1 s Take out trash")]
        [TestCase("1 mins 1 sec Take out trash")]
        [TestCase("1 mins 1 secs Take out trash")]
        [TestCase("1 mins 1 second Take out trash")]
        [TestCase("1 mins 1 seconds Take out trash")]
        [TestCase("1 minute 1s Take out trash")]
        [TestCase("1 minute 1sec Take out trash")]
        [TestCase("1 minute 1secs Take out trash")]
        [TestCase("1 minute 1second Take out trash")]
        [TestCase("1 minute 1seconds Take out trash")]
        [TestCase("1 minute 1 s Take out trash")]
        [TestCase("1 minute 1 sec Take out trash")]
        [TestCase("1 minute 1 secs Take out trash")]
        [TestCase("1 minute 1 second Take out trash")]
        [TestCase("1 minute 1 seconds Take out trash")]
        [TestCase("1 minutes 1s Take out trash")]
        [TestCase("1 minutes 1sec Take out trash")]
        [TestCase("1 minutes 1secs Take out trash")]
        [TestCase("1 minutes 1second Take out trash")]
        [TestCase("1 minutes 1seconds Take out trash")]
        [TestCase("1 minutes 1 s Take out trash")]
        [TestCase("1 minutes 1 sec Take out trash")]
        [TestCase("1 minutes 1 secs Take out trash")]
        [TestCase("1 minutes 1 second Take out trash")]
        [TestCase("1 minutes 1 seconds Take out trash")]

        [TestCase("1s Take out trash")]
        [TestCase("1sec Take out trash")]
        [TestCase("1secs Take out trash")]
        [TestCase("1second Take out trash")]
        [TestCase("1seconds Take out trash")]
        [TestCase("1 s Take out trash")]
        [TestCase("1 sec Take out trash")]
        [TestCase("1 secs Take out trash")]
        [TestCase("1 second Take out trash")]
        [TestCase("1 seconds Take out trash")]
        [Parallelizable(ParallelScope.All)]
        public void Check_WhenGivenValidInput_ReturnTrue(string input)
        {
            string key = "timer";
            Timer timer = new()
            {
                IsEnabled = true,
                Key = key,
            };
            Assert.True(timer.Check(key + " " + input));
        }

        [Test]
        [TestCase("Take out trash 1h")]
        [TestCase("Take out trash 1m")]
        [TestCase("Take out trash 1s")]
        [TestCase(" 1 hr")]
        [Parallelizable(ParallelScope.All)]
        public void Check_WhenGivenInvalidInput_ReturnFalse(string input)
        {
            string key = "timer";
            Timer timer = new()
            {
                IsEnabled = true,
                Key = key,
            };
            Assert.False(timer.Check(key + " " + input));
        }
    }
}
