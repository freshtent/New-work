﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DateTimeExtensions;
using DateTimeExtensions.WorkingDays;
using DateTimeExtensions.WorkingDays.CultureStrategies;
using NUnit.Framework;

namespace DateTimeExtensions.Tests  {

	[TestFixture]
	public class ARSAWorkingDays  {

		[Test]
		public void can_get_strateryies() {
			var dateTimeCulture = new WorkingDayCultureInfo("ar-SA");
			var holidaysStrategy = dateTimeCulture.LocateHolidayStrategy(dateTimeCulture.Name);
			Assert.AreEqual(typeof(AR_SAHolidayStrategy), holidaysStrategy.GetType());
			var workingDaysStrategy = dateTimeCulture.LocateWorkingDayOfWeekStrategy(dateTimeCulture.Name);
			Assert.AreEqual(typeof(AR_SAWorkingDayOfWeekStrategy), workingDaysStrategy.GetType());
		}

		[Test]
		public void are_working_days_on_thursday_and_friday() {
			var dateTimeCulture = new WorkingDayCultureInfo("ar-SA");
			Assert.IsFalse(dateTimeCulture.IsWorkingDay(DayOfWeek.Thursday));
			Assert.IsFalse(dateTimeCulture.IsWorkingDay(DayOfWeek.Friday));
		}

		[Test]
		public void holiday_days_span()
		{
			var dateTimeCulture = new WorkingDayCultureInfo("ar-SA");
			var holiday = AR_SAHolidayStrategy.EndOfHajj;
			var startDay = holiday.GetInstance(2012);
			//Eid-al-Fitr
			DateTime day = new DateTime(2012, 8, 19);
			do {
				Assert.IsFalse(dateTimeCulture.IsWorkingDay(day), day.ToString() + " shouldn't be a working day");
				day = day.AddDays(1);
			} while (day <= new DateTime(2012, 8, 25));

			//Eid-al-Adha
			day = new DateTime(2012, 10, 26);
			do {
				Assert.IsFalse(dateTimeCulture.IsWorkingDay(day), day.ToString() + " shouldn't be a working day");
				day = day.AddDays(1);
			} while (day <= new DateTime(2012, 10, 31));
		}
	}
}
