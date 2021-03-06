﻿namespace Forum.Models.ViewModels.Messages {
	public class CreateTopicForm : IMessageFormViewModel {
		public string Id { get; set; }
		public string BoardId { get; set; }
		public string Body { get; set; }
		public string FormAction { get; } = nameof(Controllers.Messages.Create);
		public string FormController { get; } = nameof(Controllers.Messages);
		public string ElementId { get; set; }
	}
}