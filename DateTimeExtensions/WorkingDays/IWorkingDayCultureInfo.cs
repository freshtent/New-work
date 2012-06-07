﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DateTimeExtensions.WorkingDays {
	public interface IWorkingDayCultureInfo {
		bool IsHoliday(DateTime date);
		bool IsWorkingDay(DateTime date);
		bool IsWorkingDay(DayOfWeek dayOfWeek);
		IEnumerable<Holiday> Holidays { get; }
		IEnumerable<Holiday> GetHolidaysOfYear(int year);
		string Name { get; }
	}
}
