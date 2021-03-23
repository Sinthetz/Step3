//#define __LIGHT_VERSION__
#if (__LIGHT_VERSION__)
	using Kompas6LTAPI5;
#else
using Kompas6API5;
#endif
using System.Collections;

namespace Steps.NET
{
	public static class Global
	{
		public static ArrayList EventList { get; set; } = new ArrayList();

		public static KompasObject Kompas => null;
	}
}
