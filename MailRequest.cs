﻿namespace HangOver1.Models
{
	public class MailRequest
	{

		public List<int> UserIds { get; set; }
		public string Subject { get; set; }
		public string Body { get; set; }

	
	}

	public class MailSettings
	{
		public string Mail { get; set; }
		public string DisplayName { get; set; }
		public string Password { get; set; }
		public string Host { get; set; }
		public int Port { get; set; }
	}

}
