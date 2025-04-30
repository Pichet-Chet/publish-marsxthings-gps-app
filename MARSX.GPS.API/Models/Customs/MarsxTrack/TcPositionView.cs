using System;
namespace MARSX.GPS.API.Models.Customs.MarsxTrack
{
	public class TcPositionView
	{
		public TcPositionView()
		{
			tcPosition = new TcPosition();
			tcAttribute = new TcAttributesView();

        }

		public TcPosition tcPosition { get; set; }

		public TcAttributesView tcAttribute { get; set; }
    }
}

