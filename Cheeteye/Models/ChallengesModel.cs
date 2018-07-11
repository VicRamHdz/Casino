using System;
namespace Cheeteye.Models
{
	public class ChallengesModel : BaseModel
	{
		private string _Name;
		public string Name
		{
			get { return _Name; }
			set { SetProperty(ref _Name, value); }
		}
		private string _IconUrl;
		public string IconUrl
		{
			get { return _IconUrl; }
			set { SetProperty(ref _IconUrl, value); }
		}
		private string _Preview;
		public string Preview
		{
			get { return _Preview; }
			set { SetProperty(ref _Preview, value); }
		}
		private string _BannerUrl;
		public string BannerUrl
		{
			get { return _BannerUrl; }
			set { SetProperty(ref _BannerUrl, value); }
		}
		private string _Details;
		public string Details
		{
			get { return _Details; }
			set { SetProperty(ref _Details, value); }
		}
		private string _Footer;
		public string Footer
		{
			get { return _Footer; }
			set { SetProperty(ref _Footer, value); }
		}
		private bool _IsActive;
		public bool IsActive
		{
			get { return _IsActive; }
			set { SetProperty(ref _IsActive, value); }
		}
		private string _Id;
		public string Id
		{
			get { return _Id; }
			set { SetProperty(ref _Id, value); }
		}
	}
}
