﻿using System.Collections.Generic;
using Forum3.Interfaces.Models.ViewModels;
using Forum3.Models.ViewModels.Boards.Items;
using Forum3.Models.ViewModels.Topics.Items;

namespace Forum3.Models.ViewModels.Topics.Pages {
	public class TopicDisplayPage {
		public int Id { get; internal set; }
		public TopicHeader TopicHeader { get; internal set; }
		public List<Message> Messages { get; internal set; }
		public List<IndexCategory>	Categories { get; set; }
		public List<IndexBoard> AssignedBoards { get; set; }
		public bool CanManage { get; internal set; }
		public int TotalPages { get; internal set; }
		public int CurrentPage { get; internal set; }
		public bool IsAuthenticated { get; internal set; }
		public IMessageViewModel ReplyForm { get; set; }
		public string RedirectPath { get; set; }
	}
}