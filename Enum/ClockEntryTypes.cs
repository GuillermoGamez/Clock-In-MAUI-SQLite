using System;
using System.ComponentModel;

namespace Clock_In_System_with_MAUI_and_SQLite
{
	public enum ClockEntryTypes
	{
		[Description("ClockIn")]
		ClockIn = 1,
		[Description("ClockOut")]
		ClockOut = 2,
	}
}